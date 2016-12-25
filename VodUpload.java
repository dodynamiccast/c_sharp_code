import java.io.*;
import java.net.HttpURLConnection;
import java.net.MalformedURLException;
import java.net.URL;
import java.net.URLEncoder;
import java.security.MessageDigest;
import java.util.*;

import javax.crypto.*;
import javax.crypto.spec.SecretKeySpec;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import sun.misc.BASE64Encoder;

class FilePartInfo {
	long m_offset;
	long m_dataSize;
	int m_isSend = 0;

	int SetSend() {
		m_isSend = 1;
		return 0;
	}

	int Init(long offset, long dataSize) {
		return 0;
	}
}

class PartUploadThread extends Thread  {
	VodUpload m_upload;
	ArrayList<Integer> m_arrPartIndex = new ArrayList<Integer>();
	int m_iRet = 0;
	int m_errIndex = -1;
	int m_iThreadId = 0;
	public PartUploadThread(VodUpload upload, int iThreadId) {
		m_upload = upload;
		m_iThreadId = iThreadId;
	}
	public int Reset() {
		m_arrPartIndex.clear();
		m_errIndex = -1;
		m_iRet = 0;
		return 0;
	}
	int AddPartIndex(int i) {
		m_arrPartIndex.add(i);
		return 0;
	}
	public void run() {
		for (int i = 0; i < m_arrPartIndex.size(); i++) {
			System.out.println(m_iThreadId);
			try {
				m_iRet = m_upload.PartUpload(m_arrPartIndex.get(i));
				if (m_iRet < 0) {
					m_errIndex = i;
					break;
				}
			} catch (Exception e) {
				// TODO Auto-generated catch block
				e.printStackTrace();
			}
		}
	}
}

public class VodUpload {
	String m_strSecId;
	String m_strSecKey;
	String m_strFilePath;
	String m_strFileName;
	String m_strFileSha;
	String m_strRegion = "gz";
	String m_strReqHost = "vod2.qcloud.com:5598";
	String m_strReqPath = "/v3/index.php";
	String m_strFileType;
	String m_strFileId;
	File m_stFile;
	public ArrayList<FilePartInfo> m_arrPartInfo;
	ArrayList<PartUploadThread> m_arrThreadList;
	ArrayList<String> m_arrTags;
	int m_isTrans = 0;
	int m_isScreenShot = 0;
	int m_isWaterMark = 0;
	long m_qwFileSize = 0;
	long m_dataSize = 1024 * 1024;
	// 缂栫爜鏂瑰紡
	private static final String CONTENT_CHARSET = "UTF-8";
	// HMAC绠楁硶
	private static final String HMAC_ALGORITHM = "HmacSHA1";
	private static final int MAX_RETRY_TIME = 3;
	
	private int m_iThreadNum = 6;

	public VodUpload() {
		m_arrThreadList = new ArrayList<PartUploadThread>(m_iThreadNum);
		for (int i = 0; i < m_iThreadNum; i++) {
			m_arrThreadList.add(new PartUploadThread(this, i));
		}
	}
	public VodUpload(int threadNum) {
		if (threadNum < 100 && threadNum >= 1) 
			m_iThreadNum = threadNum;
		m_arrThreadList = new ArrayList<PartUploadThread>(m_iThreadNum);
		for (int i = 0; i < m_iThreadNum; i++) {
			m_arrThreadList.add(new PartUploadThread(this, i));
		}
	}
	int Init(String secId, String secKey) {
		m_strSecId = secId;
		m_strSecKey = secKey;
		m_arrTags = new ArrayList<String>();
		m_arrPartInfo = new ArrayList<FilePartInfo>();
		return 0;
	}

	int InitCommPara(TreeMap<String, Object> mapVals) {
		mapVals.put("Region", m_strRegion);
		mapVals.put("SecretId", m_strSecId);
		mapVals.put("fileSha", m_strFileSha);
		mapVals.put("Timestamp", System.currentTimeMillis() / 1000);
		mapVals.put("Nonce", new Random().nextInt(java.lang.Integer.MAX_VALUE));
		return 0;
	}
	
	int SetTransCfg(int isTrans, int isScreenShot, int isWaterMark) {
		m_isTrans = isTrans;
		m_isScreenShot = isScreenShot;
		m_isWaterMark = isWaterMark;
		return 0;
	}

	int AddFileTag(String strTag) {
		m_arrTags.add(strTag);
		return 0;
	}

	int SetFileInfo(String strFilePath, String strFileName, String strFileType) {
		m_strFilePath = strFilePath;
		m_strFileName = strFileName;
		m_strFileType = strFileType;
		m_arrTags.clear();
		return 0;
	}

	public static String stringToSHA(String str) {
		try {
			byte[] strTemp = str.getBytes();
			MessageDigest mdTemp = MessageDigest.getInstance("SHA-1"); // SHA-256
			mdTemp.update(strTemp);
			return toHexString(mdTemp.digest());
		} catch (Exception e) {
			return null;
		}
	}

	public static String calFileSha(String filePath) {
		InputStream inputStream = null;
		try {
			inputStream = new FileInputStream(filePath);
			return calStreamShaMd5(inputStream, "SHA-1");
		} catch (Exception e) {
			return null;
		} finally {
			if (inputStream != null) {
				try {
					inputStream.close();
				} catch (IOException e) {
					e.printStackTrace();
				}
			}
		}
	}

	public static String calStreamShaMd5(InputStream inputStream, String strMethod) {
		try {
			MessageDigest mdTemp = MessageDigest.getInstance(strMethod); // SHA-256
			byte[] buffer = new byte[1024];
			int numRead = 0;
			while ((numRead = inputStream.read(buffer)) > 0) {
				mdTemp.update(buffer, 0, numRead);
			}
			return toHexString(mdTemp.digest());
		} catch (Exception e) {
			return null;
		}
	}

	private static String toHexString(byte[] md) {
		char hexDigits[] = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'a', 'b', 'c', 'd', 'e', 'f' };
		int j = md.length;
		char str[] = new char[j * 2];
		for (int i = 0; i < j; i++) {
			byte byte0 = md[i];
			str[2 * i] = hexDigits[byte0 >>> 4 & 0xf];
			str[i * 2 + 1] = hexDigits[byte0 & 0xf];
		}
		return new String(str);
	}

	String GetReqSign(TreeMap<String, Object> mapVals) {
		InitCommPara(mapVals);
		String strSign = "";
		try {
			String reqStr = "";
			for (String key : mapVals.keySet()) {
				if (reqStr.isEmpty()) {
					reqStr += '?';
				} else {
					reqStr += '&';
				}
				reqStr += key + '=' + mapVals.get(key).toString();
			}
			String contextStr = "";
			contextStr += "POST";
			contextStr += m_strReqHost;
			contextStr += m_strReqPath;
			contextStr += reqStr;

			String sig = null;
			Mac mac = Mac.getInstance(HMAC_ALGORITHM);
			SecretKeySpec secretKey = new SecretKeySpec(m_strSecKey.getBytes(CONTENT_CHARSET), mac.getAlgorithm());

			mac.init(secretKey);
			byte[] hash = mac.doFinal(contextStr.getBytes(CONTENT_CHARSET));
			// base64
			strSign = new String(new BASE64Encoder().encode(hash).getBytes());
		} catch (Exception e) {
			return "";
		}
		return strSign;
	}

	public String GetReqUrl(TreeMap<String, Object> mapVals, String strSign) {
		String reqStr = "";
		for (String key : mapVals.keySet()) {
			if (reqStr.isEmpty()) {
				reqStr += '?';
			} else {
				reqStr += '&';
			}
			reqStr += key + '=' + URLEncoder.encode(mapVals.get(key).toString());
		}
		reqStr += ("&" + "Signature=" + URLEncoder.encode(strSign));
		return "http://" + m_strReqHost + m_strReqPath + reqStr;
	}

	// 生成分片信息
	int GeneratePartInfo() {
		long partNum = m_qwFileSize / m_dataSize;
		for (int i = 0; i < partNum; i++) {
			FilePartInfo stInfo = new FilePartInfo();
			stInfo.m_dataSize = m_dataSize;
			stInfo.m_isSend = 0;
			stInfo.m_offset = m_dataSize * i;
			this.m_arrPartInfo.add(stInfo);
		}
		if (partNum * m_dataSize < m_qwFileSize) {
			FilePartInfo stInfo = new FilePartInfo();
			stInfo.m_dataSize = m_qwFileSize - partNum * m_dataSize;
			stInfo.m_isSend = 0;
			stInfo.m_offset = partNum * m_dataSize;
			this.m_arrPartInfo.add(stInfo);
		}
		return 0;
	}

	public JSONObject DoHttpReq(String strReq, byte[] data, int size) throws IOException, JSONException {
		URL url = new URL(strReq);
		HttpURLConnection connection = (HttpURLConnection) url.openConnection();

		// 设置http连接属性
		connection.setRequestMethod("POST");
		connection.setRequestProperty("accept", "**");
		connection.setRequestProperty("connection", "Keep-Alive");
		connection.setRequestProperty("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1;SV1)");
		connection.setDoOutput(true);
		connection.setDoInput(true);
		connection.setReadTimeout(1000 * 1000);
		connection.setConnectTimeout(1000 * 1000);
		connection.connect();
		if (size != 0) {
			BufferedOutputStream out = new BufferedOutputStream(connection.getOutputStream());
			out.write(data, 0, size);
			out.close();
		}
		// connection.connect();

		BufferedReader in = null;
		String result = "";
		JSONObject jsonobj = null;

		InputStream inputStream = connection.getInputStream();
		in = new BufferedReader(new InputStreamReader(inputStream));

		String line;
		while ((line = in.readLine()) != null) {
			line = new String(line.getBytes(), "utf-8");
			result += line;
		}
		// in.close();
		// connection.disconnect();
		System.out.println(result);

		jsonobj = new JSONObject(result);

		return jsonobj;
	}

	public int PartUpload(int iIndex) throws Exception {
		int retryLimit = MAX_RETRY_TIME;
		TreeMap<String, Object> mapVals = new TreeMap<String, Object>();		
		while (true) {
			FilePartInfo partInfo = m_arrPartInfo.get(iIndex);
			if (partInfo.m_isSend == 1) {
				return 0;
			}
			RandomAccessFile stFile = new RandomAccessFile(m_strFilePath, "r");
			stFile.seek(partInfo.m_offset);
			byte[] buf = new byte[(int) partInfo.m_dataSize];
			int ret = stFile.read(buf);
			stFile.close();
			if (ret != partInfo.m_dataSize) {
				System.out.printf("%d %d", ret, partInfo.m_dataSize);
				return -1;
			}
			mapVals.put("Action", "UploadPart");
			mapVals.put("dataSize", partInfo.m_dataSize);
			mapVals.put("offset", partInfo.m_offset);
			InputStream stInput = new ByteArrayInputStream(buf);
			String strMd5 = calStreamShaMd5(stInput, "MD5");
			mapVals.put("dataMd5", strMd5);

			String strSign = GetReqSign(mapVals);
			String strReq = GetReqUrl(mapVals, strSign);
			System.out.println(strReq);
			JSONObject jsonobj= null;
			try {
				jsonobj = DoHttpReq(strReq, buf, (int) (partInfo.m_dataSize));
			} catch (Exception e) {
				if (retryLimit > 0) {
					retryLimit--;
					continue;
				}
				return -3;
			}
			int retCode = jsonobj.getInt("code");
			if (retCode == 0) {
				partInfo.m_isSend = 1;
			} else {
				int canRetry = jsonobj.getInt("canRetry");
				if (canRetry == 1 && retryLimit > 0) {
					retryLimit--;
					continue;
				}
				return -2;
			}
			return 0;
		}
	}

	public int FinishUpload() throws IOException, JSONException {
		int retryLimit = MAX_RETRY_TIME;
		TreeMap<String, Object> mapVals = new TreeMap<String, Object>();
		while (true) {
			mapVals.put("Action", "FinishUpload");
			String strSign = GetReqSign(mapVals);
			if (strSign == "") {
				return -3;
			}
			String strReq = GetReqUrl(mapVals, strSign);
			JSONObject jsonobj= null;
			try {
				jsonobj = DoHttpReq(strReq, null, 0);
			} catch (Exception e) {
				retryLimit--;
				continue;
			}
			int retCode = jsonobj.getInt("code");
			if (retCode == 0) {
				m_strFileId = jsonobj.getString("fileId");
			} else {
				int canRetry = jsonobj.getInt("canRetry");
				if (canRetry == 1 && retryLimit > 0) {
					if (retryLimit > 0) {
						retryLimit--;
						continue;
					}
					return -3;
				}
				return -2;
			}
			return 0;
		}
	}

	public int InitUpload() throws IOException, JSONException {
		int retryLimit = MAX_RETRY_TIME;
		TreeMap<String, Object> mapVals = new TreeMap<String, Object>();
		while (true) {
			m_stFile = new File(m_strFilePath);
			if (!m_stFile.exists()) {
				return -1;
			}
			mapVals.put("Action", "InitUpload");
			m_qwFileSize = m_stFile.length();
			mapVals.put("fileSize", m_qwFileSize);
			mapVals.put("dataSize", m_dataSize);
			mapVals.put("fileName", m_strFileName);
			mapVals.put("fileType", m_strFileType);
			mapVals.put("isTranscode", m_isTrans);
			mapVals.put("isScreenshot", m_isScreenShot);
			mapVals.put("isWatermark", m_isWaterMark);
			for (int i = 0; i < m_arrTags.size(); i++) {
				String key = "tag." + (i + 1);
				mapVals.put(key, m_arrTags.get(i));
			}

			m_strFileSha = calFileSha(m_strFilePath);
			if (m_strFileSha == null || m_strFileSha == "") {
				return -2;
			}

			String strSign = GetReqSign(mapVals);
			if (strSign == "") {
				return -3;
			}
			String strReq = GetReqUrl(mapVals, strSign);
			System.out.println(strReq);
			JSONObject jsonobj= null;
			try {
				jsonobj = DoHttpReq(strReq, null, 0);
			} catch (Exception e) {
				if (retryLimit > 0) {
					retryLimit--;
					continue;
				}
				return -4;
			}
			int retCode = jsonobj.getInt("code");
			if (retCode == 2) {
				m_strFileId = jsonobj.getString("fileId");
			} else if (retCode == 1) {
				m_dataSize = jsonobj.getLong("dataSize");
				JSONArray existPart = jsonobj.getJSONArray("listParts");
				GeneratePartInfo();
				for (int i = 0; i < existPart.length(); i++) {
					JSONObject item = existPart.getJSONObject(i);
					long offset = item.getLong("offset");
					int index = (int) ((long) offset / (long) m_dataSize);
					m_arrPartInfo.get(index).m_isSend = 1;
				}
			} else if (retCode == 0) {
				GeneratePartInfo();
			} else {
				int canRetry = jsonobj.getInt("canRetry");
				if (canRetry == 1 && retryLimit > 0) {
					retryLimit--;
					continue;
				}
				return -1;
			}
			return 0;
		}
	}
	
	public int Upload() {
		try {
			InitUpload();
			for (int i = 0; i < m_arrPartInfo.size(); i++) {
				this.m_arrThreadList.get(i%m_arrThreadList.size()).AddPartIndex(i);
			}
			for (int i = 0; i < m_arrThreadList.size(); i++) {
				this.m_arrThreadList.get(i).start();
			}
			for (int i = 0; i < m_arrThreadList.size(); i++) {
				this.m_arrThreadList.get(i).join();
			}
			for (int i = 0; i < m_arrThreadList.size(); i++) {
				if (m_arrThreadList.get(i).m_iRet != 0)
				{
					System.out.printf("error thread i");
					return -1;
				}
			}
			FinishUpload();
		} catch (Exception e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
		return 0;
	}
}

class HttpSvc {
	public static void main(String[] args) {
		/* try */ {
			/*
			 * HttpServer hs = HttpServer.create(new
			 * InetSocketAddress("127.0.0.1", 7777), 0);
			 * hs.createContext("/myrequest", new MyHandler());
			 * hs.setExecutor(null); hs.start();
			 */
			VodUpload test = new VodUpload(10);
			test.Init("AKIDywHSpWDragT7ESvCtqUrEg8Weuz8ibWj", "wLuplid8L7LsgENlaB2FtyKgUaYsBuqR");
			test.SetFileInfo("F:\\office2007.zip", "test.zip", "zip");
			test.AddFileTag("test");

			//多线程方式上传
			int ret = test.Upload();
			System.out.printf("%d %s", ret, test.m_strFileId);
			
			
			//单线程方式上传
			/*
			try {
				test.InitUpload();
				for (int i = 0; i < test.m_arrPartInfo.size(); i++) {
					test.PartUpload(i);
				}
				test.FinishUpload();
			} catch (Exception e) {
				// TODO Auto-generated catch block
				e.printStackTrace();
			}*/
		}
		/*
		 * catch (IOException e) { e.printStackTrace(); }
		 */
	}

}
