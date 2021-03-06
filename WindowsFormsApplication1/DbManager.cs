﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using System.Windows;

namespace VodUpload
{
    public class DbLimitDef
    {
        public DbLimitDef(string strCol, string strOp, object objVal)
        {
            m_strCol = strCol;
            m_strOp = strOp;
            m_objVal = objVal;
        }
        public string m_strCol;
        public object m_objVal;
        public string m_strOp;
    }
    public class DbManager
    {
        SQLiteConnection m_sqlConn;
        const string STR_DB_PATH = "vod.db";
        public int Init()
        {
            m_sqlConn = new SQLiteConnection();
            SQLiteConnectionStringBuilder connsb = new SQLiteConnectionStringBuilder();
            connsb.DataSource = STR_DB_PATH;
            connsb.Password = "";
            m_sqlConn.ConnectionString = connsb.ToString();
            m_sqlConn.Open();
            return 0;
        }
        public int ChangeUser(long id)
        {
            SQLiteCommand cmd = new SQLiteCommand(m_sqlConn);
            cmd.CommandText = "update UserCfg set status = 1 where id=@id;update UserCfg set status = 0 where id!=@id;";
            cmd.Parameters.Add(new SQLiteParameter("@id", id));
            cmd.ExecuteNonQuery();
            return 0;
        }
        public int GetUser(ref List<Dictionary<string, string>> arrUser, int status=-1)
        {
            string[] arrPara = { "id", "appid", "secKey", "secId",
                "status", "update_time","isScreenshort", "isTranscode",
                "isWatermark","notifyUrl" };
            SQLiteCommand cmd = new SQLiteCommand(m_sqlConn);
            if (status == -1)
            {
                cmd.CommandText = "select id,appid,secKey,secId,status,update_time," +
                    "isTranscode,isScreenshort,isWatermark,notifyUrl " +
                    "from UserCfg order by status desc,update_time desc";
            }
            else
            {
                cmd.CommandText = "select id,appid,secKey,secId,status,update_time," +
                    "isTranscode,isScreenshort,isWatermark,notifyUrl " +
                    "from UserCfg where status=@status order by status desc,update_time desc";
                cmd.Parameters.Add(new SQLiteParameter("@status", status));
            }
            SQLiteDataReader data = cmd.ExecuteReader(System.Data.CommandBehavior.SingleResult);
            while (data.Read())
            {
                int iIndex = 0;
                Dictionary<string, string> dicPara = new Dictionary<string, string>();
                for (iIndex = 0; iIndex < arrPara.Length; iIndex++)
                {
                    dicPara[arrPara[iIndex]] = data.GetValue(iIndex).ToString();
                }
                arrUser.Add(dicPara);
            }
            return 0;
        }
        public int DeleteUser(Int64 user_id)
        {
            SQLiteCommand cmd = new SQLiteCommand(m_sqlConn);
            cmd.CommandText = "delete from UserCfg where id=@id";
            cmd.Parameters.Add(new SQLiteParameter("@id", user_id));
            int ret = cmd.ExecuteNonQuery();
            return 0;
        }
        public int UpdateFileInfo(long id, string strFileId, string strFileSha, long status, long errCode, string strDesc)
        {
            SQLiteCommand cmd = new SQLiteCommand(m_sqlConn);
            cmd.CommandText = "update File set status=@status, fileSha=@fileSha, errCode=@errCode, errDesc=@strDesc,fileId=@fileId where id=@id";
            cmd.Parameters.Add(new SQLiteParameter("@id", id));
            cmd.Parameters.Add(new SQLiteParameter("@status", status));
            cmd.Parameters.Add(new SQLiteParameter("@errCode", errCode));
            cmd.Parameters.Add(new SQLiteParameter("@strDesc", strDesc));
            cmd.Parameters.Add(new SQLiteParameter("@fileId", strFileId));
            cmd.Parameters.Add(new SQLiteParameter("@fileSha", strFileSha));
            int ret = cmd.ExecuteNonQuery();
            return 0;
        }
        public int AddFile(UInt64 qwAppid, 
                           string strPath, 
                           string strName, 
                           int status,
                           int errCode,
                           int isTranscode,
                           int isScreenshort,
                           int isWatermark, 
                           string notifyUrl,
                           ref long fileId)
        {
            SQLiteCommand cmd = new SQLiteCommand(m_sqlConn);
            cmd.CommandText = "insert into File (appid, status, errCode, "+
                "update_time,filePath,fileName,isTranscode,isScreenshort,isWatermark,notifyUrl)" +
                "values(@appid, @status, @errCode, strftime('%s', 'now'), @filePath, @fileName," +
                "@isTranscode,@isScreenshort,@isWatermark,@notifyUrl);" +
                "SELECT seq from SQLITE_SEQUENCE where name=\"File\";";
            cmd.Parameters.Add(new SQLiteParameter("@appid", qwAppid));
            cmd.Parameters.Add(new SQLiteParameter("@status", status));
            cmd.Parameters.Add(new SQLiteParameter("@errCode", errCode));
            cmd.Parameters.Add(new SQLiteParameter("@filePath", strPath));
            cmd.Parameters.Add(new SQLiteParameter("@fileName", strName));
            cmd.Parameters.Add(new SQLiteParameter("@isTranscode", isTranscode));
            cmd.Parameters.Add(new SQLiteParameter("@isScreenshort", isScreenshort));
            cmd.Parameters.Add(new SQLiteParameter("@isWatermark", isWatermark));
            cmd.Parameters.Add(new SQLiteParameter("@notifyUrl", notifyUrl));
            SQLiteDataReader data = cmd.ExecuteReader(System.Data.CommandBehavior.SingleResult);
            if (data.Read())
            {
                fileId = (long)data.GetValue(0);
            }
            else
            {
                return -1;
            }
            return 0;
        }
        public int GetFileCount(UInt64 qwAppid, int status=-1)
        {
            SQLiteCommand cmd = new SQLiteCommand(m_sqlConn);
            string strcmd = "select count(id) from File where appid=@appid";
            if (status != -1)
            {
                cmd.Parameters.Add(new SQLiteParameter("@status", status));
                strcmd += " and status=@status";
            }
            cmd.Parameters.Add(new SQLiteParameter("@appid", qwAppid));
            cmd.CommandText = strcmd;
            SQLiteDataReader data = cmd.ExecuteReader(System.Data.CommandBehavior.SingleResult);
            if (data.Read())
            {
                Object obj = data.GetValue(0);
                return int.Parse(obj.ToString());
            }
            return 0;
        }
        public int SearchFile(UInt64 qwAppid, ref List<Dictionary<string, string>> arrFile,
                                ref List<DbLimitDef> arrCond,
                                int status = -1,
                                int page_size = -1,
                                int page_num = 1)
        {
            string[] arrPara = { "id", "appid", "errCode",
                "filePath", "fileName", "status", "fileId", "errDesc","fileSha",
                "isScreenshort", "isTranscode", "isWatermark","notifyUrl", "createTime"};
            SQLiteCommand cmd = new SQLiteCommand(m_sqlConn);
            string cmdText = "select id,appid,errCode,filePath,fileName,status,fileId,errDesc,fileSha," +
                "isTranscode,isScreenshort,isWatermark,notifyUrl,create_time " +
                "from file where appid=@appid";
            if (status != -1)
            {
                cmdText += " and status = @status";
                cmd.Parameters.Add(new SQLiteParameter("@status", status));
            }
            foreach (DbLimitDef def in arrCond)
            {
                cmdText += (" and " + def.m_strCol + def.m_strOp + def.m_objVal);
            }
            cmdText += " order by create_time desc";
            if (page_size != -1)
            {
                if (page_num != 0)
                    cmdText += (" limit " + page_size * (page_num - 1) + "," + page_size);
                else
                    cmdText += (" limit " + page_size);
            }
            cmd.Parameters.Add(new SQLiteParameter("@appid", qwAppid));
            cmd.CommandText = cmdText;
            SQLiteDataReader data = cmd.ExecuteReader(System.Data.CommandBehavior.SingleResult);
            while (data.Read())
            {
                int iIndex = 0;
                Dictionary<string, string> dicPara = new Dictionary<string, string>();
                for (iIndex = 0; iIndex < arrPara.Length; iIndex++)
                {
                    dicPara[arrPara[iIndex]] = data.GetValue(iIndex).ToString();
                }
                arrFile.Add(dicPara);
            }
            return 0;
        }
        public int GetFileInfo(UInt64 qwAppid, ref List<Dictionary<string, string>> arrFile, 
                                int status=-1, 
                                int page_size = -1,
                                int page_num = 1,
                                long start_id = 0)
        {
            string[] arrPara = { "id", "appid", "errCode",
                "filePath", "fileName", "status", "fileId", "errDesc","fileSha",
                "isScreenshort", "isTranscode", "isWatermark","notifyUrl", "createTime"};
            SQLiteCommand cmd = new SQLiteCommand(m_sqlConn);
            string cmdText = "select id,appid,errCode,filePath,fileName,status,fileId,errDesc,fileSha,"+
                "isTranscode,isScreenshort,isWatermark,notifyUrl,create_time " +
                "from file where appid=@appid";
            if (status != -1)
            {
                cmdText += " and status = @status";
                cmd.Parameters.Add(new SQLiteParameter("@status", status));
            }
            if (start_id != 0)
            {
                cmdText += " and id < $id ";
                cmd.Parameters.Add(new SQLiteParameter("@id", start_id));
            }
            cmdText += " order by create_time desc";
            if (page_size != -1)
            {
                if (page_num != 0)
                    cmdText += (" limit " + page_size*(page_num - 1) + "," + page_size);
                else 
                    cmdText += (" limit " + page_size);
            }
            cmd.Parameters.Add(new SQLiteParameter("@appid", qwAppid));
            cmd.CommandText = cmdText;
            SQLiteDataReader data = cmd.ExecuteReader(System.Data.CommandBehavior.SingleResult);
            while (data.Read())
            {
                int iIndex = 0;
                Dictionary<string, string> dicPara = new Dictionary<string, string>();
                for (iIndex = 0; iIndex < arrPara.Length; iIndex++)
                {
                    dicPara[arrPara[iIndex]] = data.GetValue(iIndex).ToString();
                }
                arrFile.Add(dicPara);
            }
            return 0;
        }
        public int AddUsr(UInt64 qwAppid, 
                          string strSecId, 
                          string strSecKey,
                          int isTranscode,
                          int isScreenshort,
                          int isWatermark,
                          string notifyUrl,
                          ref Int64 user_id)
        {
            SQLiteCommand cmd = new SQLiteCommand(m_sqlConn);
            string cmdText = "insert into UserCfg (appid, secKey, secId, status, update_time,"+
                "isTranscode,isScreenshort,isWatermark,notifyUrl)" +
                "values(@appid, @secKey, @secId, 1, strftime('%s', 'now'),"+
                "@isTranscode,@isScreenshort,@isWatermark,@notifyUrl);" +
                "SELECT seq from SQLITE_SEQUENCE  where name=\"UserCfg\";";
            long time_stamp = MultiPartUpload.GetTimeStamp();
            cmd.Parameters.Add(new SQLiteParameter("@appid", qwAppid));
            cmd.Parameters.Add(new SQLiteParameter("@secKey", strSecKey));
            cmd.Parameters.Add(new SQLiteParameter("@secId", strSecId));
            cmd.Parameters.Add(new SQLiteParameter("@isTranscode", isTranscode));
            cmd.Parameters.Add(new SQLiteParameter("@isScreenshort", isScreenshort));
            cmd.Parameters.Add(new SQLiteParameter("@isWatermark", isWatermark));
            cmd.Parameters.Add(new SQLiteParameter("@notifyUrl", notifyUrl));
            cmd.CommandText = cmdText;
            try
            {
                SQLiteDataReader data = cmd.ExecuteReader(System.Data.CommandBehavior.SingleResult);
                if (data.Read())
                {
                    user_id = (Int64)data.GetValue(0);
                }
                else
                    return -2;
            }
            catch (Exception ex)
            {
                return -3;
            }
            SQLiteCommand cmdSetStatus = new SQLiteCommand(m_sqlConn);
            cmdSetStatus.CommandText = "update UserCfg set status=0 where id!=@id";
            cmdSetStatus.Parameters.Add(new SQLiteParameter("@id", user_id));
            cmdSetStatus.ExecuteNonQuery();
            return 0;
        }
    }
}
