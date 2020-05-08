using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace QWF.Framework.Common
{
    public class DES3
    {
         
        /// <summary>
        /// DES3 加密 ECB 模式
        /// </summary>
        /// <param name="str"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string DES3EncryptECB(string str, string key)
        {
            string result = string.Empty;
            try
            {
                TripleDESCryptoServiceProvider des3 = new TripleDESCryptoServiceProvider();
                //Encoding.UTF8.GetBytes(key);
                des3.Key = Convert.FromBase64String(key);
               
                des3.Mode = CipherMode.ECB;
                des3.Padding = PaddingMode.PKCS7;


                ICryptoTransform DESEncrypt = des3.CreateEncryptor();

                byte[] buffer = Encoding.UTF8.GetBytes(str);
                result = Convert.ToBase64String(DESEncrypt.TransformFinalBlock(buffer, 0, buffer.Length));
            }
            catch (Exception e)
            {
                result = e.Message;
            }
            return result;

        }

        /// <summary>
        ///  DES3 解密 ECB 模式
        /// </summary>
        /// <param name="str"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string DES3DecryptECB(string str, string key)
        {
            string result = "";
            try
            {
                TripleDESCryptoServiceProvider des = new TripleDESCryptoServiceProvider();

                //DES.Key = Encoding.UTF8.GetBytes(key);
                des.Key = Convert.FromBase64String(key);
                des.Mode = CipherMode.ECB;
                des.Padding = PaddingMode.PKCS7;

                ICryptoTransform DESDecrypt = des.CreateDecryptor();


                byte[] buffer = Convert.FromBase64String(str);
                result = Encoding.UTF8.GetString(DESDecrypt.TransformFinalBlock(buffer, 0, buffer.Length));
            }
            catch (Exception e)
            {
                result = e.Message;
            }
            return result;
        }
    }
}