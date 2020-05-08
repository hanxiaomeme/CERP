using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace QWF.Framework.Common
{
    public class HttpHelper
    {
        public static string TryGet(string url,int tryNum)
        {
            string result = string.Empty;

            while (true)
            {
                try
                {
                    result = Get(url);
                    break;
                }
                catch(Exception e)
                {
                    tryNum--;

                    if (tryNum == 0)
                        throw e;
                }
            }
            return result;
        }

        public static string Get(string url, string method = "GET")
        {
            HttpWebRequest request = null;
            if (url.StartsWith("https", StringComparison.OrdinalIgnoreCase))
            {
                System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

                ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(CheckValidationResult);
                request = WebRequest.Create(url) as HttpWebRequest;
                request.ProtocolVersion = HttpVersion.Version10;
                
            }
            else
            {
                request = (HttpWebRequest)WebRequest.Create(url);
            }
            request.Method = method;
            request.ContentType = "text/html";
            request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8";
            request.Headers.Add("Accept-Encoding", "gzip, deflate");
            request.Headers.Add("Accept-Language", "zh-CN,zh;q=0.9");
            request.Headers.Add("Cache-Control", "max-age=0");
            request.UserAgent = "Mozilla/5.0 (Linux; Android 6.0; Nexus 5 Build/MRA58N) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/63.0.3239.84 Mobile Safari/537.36";
            request.Headers.Add("Upgrade-Insecure-Requests", "1");

            //request.ca = "Cache-Control";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream myResponseStream = response.GetResponseStream();
            StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.UTF8);
            string retString = myStreamReader.ReadToEnd();
            myStreamReader.Close();
            myResponseStream.Close();
            return retString;
        }
        /// <summary>
        /// URL请求
        /// </summary>
        /// <param name="url">请求地址</param>
        /// <param name="urlParameter">请求参数(如：id=360doo&pwd=123456)</param>
        /// <returns></returns>
        public static string Post(string url, string postData)
        {
            try
            {
                HttpWebRequest request = null;
                if (url.StartsWith("https", StringComparison.OrdinalIgnoreCase))
                {
                    ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(CheckValidationResult);
                    request = WebRequest.Create(url) as HttpWebRequest;
                    request.ProtocolVersion = HttpVersion.Version10;
                }
                else
                {
                    request = (HttpWebRequest)WebRequest.Create(url);
                }

                byte[] data = System.Text.Encoding.GetEncoding("UTF-8").GetBytes(postData);
                // 准备请求 
                // HttpWebRequest req = (HttpWebRequest)WebRequest.Create(postUrl);
                request.Method = "POST";
                request.ContentType = "application/json; charset=UTF-8";
                request.ContentLength = data.Length;
                Stream stream = request.GetRequestStream();
                // 发送数据 
                stream.Write(data, 0, data.Length);
                stream.Close();
                HttpWebResponse rep = (HttpWebResponse)request.GetResponse();
                Stream receiveStream = rep.GetResponseStream();
                Encoding encode = System.Text.Encoding.GetEncoding("UTF-8");
                // Pipes the stream to a higher level stream reader with the required encoding format. 
                StreamReader readStream = new StreamReader(receiveStream, encode);
                char[] read = new char[256];
                int count = readStream.Read(read, 0, 256);
                StringBuilder sb = new StringBuilder("");
                while (count > 0)
                {
                    String readstr = new String(read, 0, count);
                    sb.Append(readstr);
                    count = readStream.Read(read, 0, 256);
                }
                rep.Close();
                readStream.Close();
                return sb.ToString();
            }
            catch (WebException ex)
            {
                if (ex.Status == WebExceptionStatus.Timeout)
                {
                    return "连接超时";
                }
                return new StreamReader(((HttpWebResponse)ex.Response).GetResponseStream(), Encoding.UTF8).ReadToEnd();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string PostDataToUrl(string data, string url, string encoding)
        {
            Encoding ecode = Encoding.GetEncoding(encoding);
            Byte[] bs = ecode.GetBytes(data);
            return PostDataToUrl(bs, url);
        }

        private string PostDataToUrl(byte[] data, string url)
        {
            HttpWebRequest httpwebRequest = (HttpWebRequest)WebRequest.Create(url);

            if (httpwebRequest == null)
            {
                throw new ApplicationException(string.Format("无效请求连接:{0}", url));
            }
            //填充httpwebRequest
            httpwebRequest.ContentType = "application/x-www-form-urlencoded";
            httpwebRequest.Method = "POST";
            //填充要发送的数据
            httpwebRequest.ContentLength = data.Length;
            Stream requestStream = httpwebRequest.GetRequestStream();
            requestStream.Write(data, 0, data.Length);
            requestStream.Close();
            //发送请求
            Stream responseStream;
            try
            {
                responseStream = httpwebRequest.GetResponse().GetResponseStream();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            //读取服务器返回信息
            string resultResponseString = string.Empty;
            using (StreamReader responseReader = new StreamReader(responseStream, Encoding.GetEncoding("UTF-8")))
            {
                resultResponseString = responseReader.ReadToEnd();
            }
            responseStream.Close();
            return resultResponseString;
        }


        private static bool CheckValidationResult(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
        {
            return true; //总是接受  
        }


    }
}
