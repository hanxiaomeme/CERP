using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace Lanyun.Common.FTP
{
    public class Ftp
    {
        public Ftp(string ftpServerIP, string ftpUserID, string ftpPassword)  
        {  
            this.FtpServerIP = ftpServerIP;  
            this.FtpUserID = ftpUserID;  
            this.FtpPassword = ftpPassword;
            this.ftpURI = "ftp://" + FtpServerIP + "/";
        }

        /// <summary>
        /// 连接FTP
        /// </summary>
        /// <param name="FtpServerIP">FTP连接地址</param>
        /// <param name="FtpRemotePath">指定FTP连接成功后的当前目录, 如果不指定即默认为根目录</param>
        /// <param name="FtpUserID">用户名</param>
        /// <param name="FtpPassword">密码</param>
        public Ftp(string ftpServerIP, string ftpRemotePath, string ftpUserID, string ftpPassword)
        {
            this.FtpServerIP = ftpServerIP;
            this.FtpRemotePath = ftpRemotePath;
            this.FtpUserID = ftpUserID;
            this.FtpPassword = ftpPassword;
            ftpURI = "ftp://" + FtpServerIP + "/" + FtpRemotePath + "/";
        }

        public string FtpRemotePath;
        private string FtpServerIP;
        private string FtpUserID;
        private string FtpPassword;
        private string ftpURI;

        FtpWebRequest reqFTP;

        /// <summary>
        /// 连接ftp 服务器
        /// </summary>
        /// <param name="path">服务器地址</param>
        private void Connect(string path)
        {  
            // 根据uri创建FtpWebRequest对象  
            reqFTP = (FtpWebRequest)WebRequest.Create(new Uri(path));  
            // 指定数据传输类型  
            reqFTP.UseBinary = true;  
            // ftp用户名和密码  
            reqFTP.Credentials = new NetworkCredential(FtpUserID, FtpPassword);  
        }  

        //都调用这个  
        private string[] GetFileList(string path, string WRMethods = WebRequestMethods.Ftp.ListDirectory)
        {  
            //上面的代码示例了如何从ftp服务器上获得文件列表  
            string[] downloadFiles;  
            StringBuilder result = new StringBuilder();  
            try  
            {  
                Connect(path);  
                reqFTP.Method = WRMethods;  
                WebResponse response = reqFTP.GetResponse();  
                StreamReader reader = new StreamReader(response.GetResponseStream(), System.Text.Encoding.UTF8);//中文文件名  
                string line = reader.ReadLine();  
                while (line != null)  
                {  
                    result.Append(line);  
                    result.Append("/");  
                    line = reader.ReadLine();  
                }  
                // to remove the trailing '/n'  
                if (result.Length > 0)
                {
                    result.Remove(result.ToString().LastIndexOf('/'), 1);
                    reader.Close();
                    response.Close();
                    return result.ToString().Split('/');
                }
                else
                    return null;
            }  
            catch (Exception ex)  
            {  
                System.Windows.Forms.MessageBox.Show(ex.Message);  
                downloadFiles = null;  
                return downloadFiles;  
            }  
        }

  
        //从ftp服务器上获得文件列表  
        public string[] GetFileList()
        {  
            return GetFileList(ftpURI, WebRequestMethods.Ftp.ListDirectory);  
        }


        //从ftp服务器上载文件的功能  
        public string Upload(string filename) 
        {  
            #region 上传
		    FileInfo fileInf = new FileInfo(filename);  
            string uri = ftpURI + fileInf.Name;  
            Connect(uri);//连接           
            // 默认为true，连接不会被关闭  
            // 在一个命令之后被执行  
            reqFTP.KeepAlive = false;  
            // 指定执行什么命令  
            reqFTP.Method = WebRequestMethods.Ftp.UploadFile;  
            // 上传文件时通知服务器文件的大小  
            reqFTP.ContentLength = fileInf.Length;  
            // 缓冲大小设置为kb  
            int buffLength = 2048;  
            byte[] buff = new byte[buffLength];  
            int contentLen;  
            // 打开一个文件流(System.IO.FileStream) 去读上传的文件  
            FileStream fs = fileInf.OpenRead();  
            try  
            {  
                // 把上传的文件写入流  
                Stream strm = reqFTP.GetRequestStream();  
                // 每次读文件流的kb  
                contentLen = fs.Read(buff, 0, buffLength);  
                // 流内容没有结束  
                while (contentLen != 0)  
                {  
                    // 把内容从file stream 写入upload stream  
                    strm.Write(buff, 0, contentLen);  
                    contentLen = fs.Read(buff, 0, buffLength);  
                }  
                // 关闭两个流  
                strm.Close();  
                fs.Close();
                filename = uri;
                return "";  
            }  
            catch (Exception ex)  
            {  
                return "Upload Error"+ex.Message;  
            }   
	        #endregion
        }


        //从ftp服务器下载文件的功能
        public string Download(string filePath, string fileName)  
        {  
            #region 下载
            try  
            {  
                string remoteFileName = Path.GetFileName(fileName);  
                string newFileName = filePath + "//" + remoteFileName;  
                if (File.Exists(newFileName))  
                {  
                    return "本地文件" + newFileName + "已存在,无法下载";  
                }  
                string url = ftpURI + fileName;  
                Connect(url);//连接   
                reqFTP.Credentials = new NetworkCredential(FtpUserID, FtpPassword);  
                FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();  
                Stream ftpStream = response.GetResponseStream();  
                long cl = response.ContentLength;  
                int bufferSize = 2048;  
                int readCount;  
                byte[] buffer = new byte[bufferSize];  
                readCount = ftpStream.Read(buffer, 0, bufferSize);  
                FileStream outputStream = new FileStream(newFileName, FileMode.Create);  
                while (readCount > 0)  
                {  
                    outputStream.Write(buffer, 0, readCount);  
                    readCount = ftpStream.Read(buffer, 0, bufferSize);  
                }  
                ftpStream.Close();  
                outputStream.Close();  
                response.Close();  
  
                return "";  
            }  
            catch (Exception ex)  
            {   
                return "因"+ex.Message+",无法下载";  
            }  
	        #endregion 
        }

        public string SavetoTemp(string fileFullName)
        {
            #region 下载 到temp
            try
            {
                FileInfo file = new FileInfo(fileFullName);

                string url = "ftp://" + FtpServerIP + "/" + file.Name;
                Connect(url);//连接   
                reqFTP.Credentials = new NetworkCredential(FtpUserID, FtpPassword);
                FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();
                Stream ftpStream = response.GetResponseStream();
                long cl = response.ContentLength;
                int bufferSize = 2048;
                int readCount;
                byte[] buffer = new byte[bufferSize];
                readCount = ftpStream.Read(buffer, 0, bufferSize);
                FileStream outputStream = new FileStream(fileFullName, FileMode.OpenOrCreate);
                while (readCount > 0)
                {
                    outputStream.Write(buffer, 0, readCount);
                    readCount = ftpStream.Read(buffer, 0, bufferSize);
                }
                ftpStream.Close();
                outputStream.Close();
                response.Close();

                return "";
            }
            catch (Exception ex)
            {
                return "因" + ex.Message + ",无法下载";
            }
            #endregion 

        }
        

        //删除文件  
        public void DeleteFileName(string fileName)  
        {  
            try  
            {  
                FileInfo fileInf = new FileInfo(fileName);  
                string uri = ftpURI + fileInf.Name;  
                Connect(uri);//连接           
                // 默认为true，连接不会被关闭  
                // 在一个命令之后被执行  
                reqFTP.KeepAlive = false;  
                // 指定执行什么命令  
                reqFTP.Method = WebRequestMethods.Ftp.DeleteFile;  
                FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();  
                response.Close();  
            }  
            catch (Exception ex)  
            {  
                MessageBox.Show(ex.Message, "删除错误");  
            }  
        }

        public void DeleteFiles(params string[] fileNames)
        {
            try
            {
                foreach (string fileName in fileNames)
                {
                    FileInfo fileInf = new FileInfo(fileName);
                    string uri = ftpURI + fileInf.Name;
                    Connect(uri);//连接           
                    // 默认为true，连接不会被关闭  
                    // 在一个命令之后被执行  
                    reqFTP.KeepAlive = false;
                    // 指定执行什么命令  
                    reqFTP.Method = WebRequestMethods.Ftp.DeleteFile;
                    FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();
                    response.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "删除错误");  
            }
        }
 
        //创建目录  
        public string MakeDir(string dirName)  
        {  
            try  
            {  
                string uri = ftpURI + dirName;  
                Connect(uri);//连接        
                reqFTP.Method = WebRequestMethods.Ftp.MakeDirectory;  
                FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();  
                response.Close();  
                return "";  
            }  
            catch (WebException ex)  
            {  
                return "[Make Dir]"+ex.Message;  
            }  
        }  

        //删除目录  
        public void DelDir(string dirName)  
        {  
            try  
            {  
                string uri = ftpURI + dirName;  
                Connect(uri);//连接        
                reqFTP.Method = WebRequestMethods.Ftp.RemoveDirectory;  
                FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();  
                response.Close();  
            }  
            catch (Exception ex)  
            {
                MessageBox.Show(ex.ToString());
                throw ex; 
            }  
        }  

        //获得文件大小  
        public long GetFileSize(string filename)  
        {  
            long fileSize = 0;  
            try  
            {  
                FileInfo fileInf = new FileInfo(filename);  
                string uri = ftpURI + fileInf.Name;  
                Connect(uri);//连接        
                reqFTP.Method = WebRequestMethods.Ftp.GetFileSize;  
                FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();  
                fileSize = response.ContentLength;  
                response.Close();  
            }  
            catch (Exception ex)  
            {  
                MessageBox.Show(ex.Message);  
            }  
            return fileSize;  
        }  

        //文件改名  
        public void Rename(string currentFilename, string newFilename)  
        {  
            try  
            {  
                FileInfo fileInf = new FileInfo(currentFilename);  
                string uri = ftpURI + fileInf.Name;  
                Connect(uri);//连接  
                reqFTP.Method = WebRequestMethods.Ftp.Rename;  
                reqFTP.RenameTo = newFilename;  
                FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();  
                //Stream ftpStream = response.GetResponseStream();  
                //ftpStream.Close();  
                response.Close();  
            }  
            catch (Exception ex)  
            {  
                MessageBox.Show(ex.Message);  
            }  
        }  

        //获得文件明晰  
        public string[] GetFilesDetailList()  
        {  
            return GetFileList(ftpURI, WebRequestMethods.Ftp.ListDirectoryDetails);  
        }  


        //文件是否存在
        public bool FileExist(string fileName)
        {
            string uri = ftpURI + fileName; 
            reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(uri));  
            reqFTP.UseBinary = true;
            reqFTP.Credentials = new NetworkCredential(FtpUserID, FtpPassword);
            reqFTP.Method = WebRequestMethods.Ftp.ListDirectoryDetails;

            try
            {
                FtpWebResponse ftpresponse = (FtpWebResponse)reqFTP.GetResponse();
                StreamReader reader = new StreamReader(ftpresponse.GetResponseStream(), Encoding.Default);
 
                string line = reader.ReadLine();
                if (string.IsNullOrEmpty(line))
                {
                    return false;
                }

                reader.Close();
                ftpresponse.Close();

                return true;
            }
            catch
            {     
                return false;
            }
        }

        public bool FolderExist(string folderName)
        {
            reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(ftpURI));
            reqFTP.UseBinary = true;
            reqFTP.Credentials = new NetworkCredential(FtpUserID, FtpPassword);
            reqFTP.Method = WebRequestMethods.Ftp.ListDirectoryDetails;

            try
            {
                FtpWebResponse ftpresponse = (FtpWebResponse)reqFTP.GetResponse();
                StreamReader reader = new StreamReader(ftpresponse.GetResponseStream(), Encoding.Default);

                
                string line = reader.ReadLine();
                while (line != null)
                {
                    if (line.Contains(folderName))
                    {
                        return true;
                    }
                    reader.ReadLine();
                }

                reader.Close();
                ftpresponse.Close();

                return false;
            }
            catch
            {
                return false;
            }
        }
    }   
}
