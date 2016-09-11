using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
/*
$arguments = array(
'Action' => $name,
'Nonce' => $Nonce,
'Region' => $this->_defaultRegion,
'SecretId' => $this->_secretId,
'Timestamp' => $timestamp,
'dataSize' => $sliceSize,
'fileName' => $fileName_NoSurfix,
'fileSha' => $fileSha,
'fileSize' => $fileSize,
'fileType' => $fileType,
'isTranscode' => isset($params['isTranscode'])? $params['isTranscode']:0,
'isScreenshot' => isset($params['isScreenshot'])? $params['isScreenshot']:0,
'isWatermark' => isset($params['isWatermark'])? $params['isWatermark']:0,
'name' => $fileName,
'offset' => $nextOffset,
'notifyUrl' => isset($params['notifyUrl'])?$params['notifyUrl']:""
);
*/
namespace VodUpload
{
    class MultiPartUpload
    {
        private string m_strSecId;
        private string m_strSecKey;
        private string m_strReqHost;
        private string m_strReqPath;
 //       private string m_strFilePath;
 //       private string m_strFileName;
        private string m_strFileType;
        private ulong m_qwDataSize;
        private int m_iIsTranscoed;
        private int m_iIsScreenShort;
        private int m_iIsWaterMark;
        private ulong m_qwFileSize;
        private string m_strNotifyUrl;
        private string m_strFileSha;
        private string m_strReqUrl;
        private Dictionary<string, string> m_mapPara = new Dictionary<string, string>();
        private int m_iHttpTimeOut = 200 * 1000;

        private Random m_rand;
        private string m_strRegion;
        private System.IO.FileStream m_fileReader;
        private const int MIN_DATA_SIZE = 512 * 1024;
        private const int MAX_DATA_SIZE = 5 * 1024 * 1024;
        private const int HTTP_TIME_OUT = -1;
        private const int HTTP_CLIENT_ERROR = -2;

        public MultiPartUpload()
        {
            m_iIsTranscoed = 0;
            m_iIsScreenShort = 0;
            m_strRegion = "sz";
            m_qwDataSize = MIN_DATA_SIZE;
            SetScreenShort(0);
            SetTranscode(0);
            SetWatermark(0);
            m_strReqHost = "vod.qcloud.com";
            m_strReqPath = "/v2/index.php";
            SetNotifyUrl("");
        }
        public static string GetTimeStamp()
        {
            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt64(ts.TotalSeconds).ToString();
        }
        public int SetDataSize(ulong dwDataSize)
        {
            if (dwDataSize > MIN_DATA_SIZE && dwDataSize < MAX_DATA_SIZE)
                m_qwDataSize = dwDataSize;
            return 0;
        }
        public int Init(string strSecId, string strSecKey)
        {
            m_strSecId = strSecId;
            m_strSecKey = strSecKey;
            m_rand = new Random();
            //m_mapPara["Action"] = "MultipartUploadVodFile";
            //m_mapPara["Region"] = "sz";
            //m_mapPara["Nonce"] = rand.Next(0, 1000000).ToString();
            //m_mapPara["SecretId"] = strSecId;
            //m_mapPara["Timestamp"] = GetTimeStamp();
            m_mapPara["Action"] = "MultipartUploadVodFile";
            m_mapPara["Region"] = m_strRegion;
            m_mapPara["SecretId"] = m_strSecId;
            return 0;
        }
        public int SetTranscode(int iIsTranscode)
        {
            m_iIsTranscoed = iIsTranscode;
            m_mapPara["isTranscode"] = iIsTranscode.ToString();
            return 0;
        }
        public int SetScreenShort(int iIsScreenShort)
        {
            m_iIsScreenShort = iIsScreenShort;
            m_mapPara["isScreenshot"] = iIsScreenShort.ToString();
            return 0;
        }
        public int SetWatermark(int iIsWaterMark)
        {
            m_iIsWaterMark = iIsWaterMark;
            m_mapPara["isWatermark"] = iIsWaterMark.ToString();
            return 0;
        }
        public int SetNotifyUrl(string url)
        {
            m_strNotifyUrl = url;
            m_mapPara["notifyUrl"] = url;
            return 0;
        }
        public int UploadFile(string strFilePath, string strFileName, ref UInt64 qwFileId)
        {
            if (!System.IO.File.Exists(strFilePath))
            {
                Console.Write("no such file");
                return -1;
            }
            m_fileReader = new System.IO.FileStream(strFilePath, System.IO.FileMode.Open, System.IO.FileAccess.Read);
            string[] arrSplit = strFilePath.Split(new char[] { '.' });
            m_strFileType = arrSplit.Last();
            m_mapPara["fileType"] = m_strFileType;
            m_mapPara["fileName"] = strFileName;
            m_mapPara["fileSize"] = m_fileReader.Length.ToString();
            m_strFileSha = CalFileSha();
            m_mapPara["fileSha"] = m_strFileSha;
            byte[] byteBuf = new byte[m_qwDataSize];

            long offset = 0;
            int iReadLen = 0;
            ulong uMaxRetry = m_qwFileSize/m_qwDataSize + 3;
            while (true)
            {
                m_fileReader.Seek(offset, SeekOrigin.Begin);
                iReadLen = m_fileReader.Read(byteBuf, 0, Convert.ToInt32(m_qwDataSize));
                if(iReadLen == 0)
                {
                    break;
                }
                m_mapPara["Timestamp"] = GetTimeStamp();
                m_mapPara["Nonce"] = m_rand.Next(0, 1000000).ToString();
                m_mapPara["dataSize"] = iReadLen.ToString();
                m_mapPara["offset"] = offset.ToString();
                m_mapPara["Signature"] = GetReqSign();
                JObject jo = new JObject();
                int ret = SendData(byteBuf, iReadLen,ref jo);
           
                if (ret == HTTP_TIME_OUT && uMaxRetry > 0)
                {
                    uMaxRetry--;
                    continue;
                }
                else if (ret < 0)
                {
                    return -1;
                }

                if (!jo.HasValues)
                {
                    uMaxRetry--;
                    continue;
                }
                long flag = 0;
                long code = 0;
                if (GetIntValue(jo, "code", ref code) != 0)
                {
                    return -1001;
                }
                if (IsTimeoutRet(code) == 1)
                {
                    offset = 0;
                    uMaxRetry--;
                    continue;
                }
                if (GetIntValue(jo, "flag", ref flag) != 0)
                {
                    return -2;
                }
                if (flag == 1 && code == 0)
                {
                    if (GetUIntValue(jo, "fileId", ref qwFileId) != 0)
                        return -1;
                    return 0;
                }
                if (flag == 0 && code == 0)
                {
                    long offset_ret = 0;
                    if (GetIntValue(jo, "offset", ref offset_ret) != 0)
                        return -3;
                    offset = offset_ret;
                    continue;
                }
            }
            Console.Write("error happened");
            return -1;
        }
        //后台内部超时，可重试
        private int IsTimeoutRet(long ret)
        {
            if (ret == 28996 ||
                ret == 24983 ||
                ret == 24987 ||
                ret == 24991 ||
                ret == 24995 ||
                ret == 24998 ||
                ret == 24979 ||
                ret == 24971 ||
                ret == 24977 ||
                ret == 24967 ||
                ret == 10000)
                return 1;
            return 0;
        }
        private int GetIntValue(JObject jo, string strKey, ref long ret)
        {
            if (jo[strKey].Type == JTokenType.Integer|| jo[strKey].Type==JTokenType.String)
            {
                ret = Convert.ToInt64(jo[strKey].ToString());
                return 0;
            }
            else 
                return -1;
        }
        private int GetUIntValue(JObject jo, string strKey, ref ulong ret)
        {
            if (jo[strKey].Type == JTokenType.String)
            {
                ret = Convert.ToUInt64(jo[strKey].ToString());
                return 0;
            }
            else
                return -1;
        }
        private int GetStringValue(JObject jo, string strKey, ref string ret)
        {
            if (jo[strKey].Type == JTokenType.String)
            {
                ret = jo[strKey].ToString();
                return 0;
            }
            else
                return -1;
        }

        private int SendData(byte[] byteBuf, int size, ref JObject jo)
        {
            string strUrl = "http://" + m_strReqHost + m_strReqPath + "?";
            List<string> arrKeys = new List<string>(m_mapPara.Keys);

            for (int i = 0; i < arrKeys.Count() - 1; i++)
            {
                strUrl += arrKeys[i];
                strUrl += "=";
                strUrl += m_mapPara[arrKeys[i]];
                strUrl += "&";
            }
            strUrl += arrKeys[arrKeys.Count() - 1];
            strUrl += "=";
            strUrl += m_mapPara[arrKeys[arrKeys.Count() - 1]];

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(strUrl);
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = size;
            request.Timeout = m_iHttpTimeOut;

            Stream reqStream = request.GetRequestStream();
            reqStream.Write(byteBuf, 0, size);

            try
            {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream myResponseStream = response.GetResponseStream();
                StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));
                string retString = myStreamReader.ReadToEnd();

                jo = JObject.Parse(retString);
                myStreamReader.Close();
                myResponseStream.Close();
            }
            catch (WebException webEx)
            {
                if (webEx.Status == WebExceptionStatus.Timeout)
                {
                    return HTTP_TIME_OUT;
                }
                return HTTP_CLIENT_ERROR;
            }

            return 0;
        }
        private string CalFileSha()
        {
            System.Security.Cryptography.HashAlgorithm algorithm;
            algorithm = System.Security.Cryptography.SHA1.Create();
            byte[] hashBytes = algorithm.ComputeHash(m_fileReader);
            return BitConverter.ToString(hashBytes).Replace("-", "");
        }
        private string hash_hmac(string signatureString, string secretKey)
        {
            var enc = Encoding.UTF8;
            HMACSHA1 hmac = new HMACSHA1(enc.GetBytes(secretKey));
            hmac.Initialize();

            byte[] buffer = enc.GetBytes(signatureString);
           return Convert.ToBase64String(hmac.ComputeHash(buffer));
        }
        private string GetReqSign()
        {
            List<string> arrKeys = new List<string>(m_mapPara.Keys);
            arrKeys.Remove("Signature");
            arrKeys.Sort(string.CompareOrdinal);
            if (arrKeys.Count() <= 0)
            {
                return "";
            }
            string strContex = "POST"+m_strReqHost+ m_strReqPath+"?";
            for (int i = 0; i < arrKeys.Count() - 1; i++)
            {
                strContex += arrKeys[i];
                strContex += "=";
                strContex += m_mapPara[arrKeys[i]];
                strContex += "&";
            }
            strContex += arrKeys[arrKeys.Count() - 1];
            strContex += "=";
            strContex += m_mapPara[arrKeys[arrKeys.Count() - 1]];
            return hash_hmac(strContex, m_strSecKey);
        }

    }
}
