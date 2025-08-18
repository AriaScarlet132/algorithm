using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Rcbi.AspNetCore.Helper
{
    public sealed class Des3Helper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="strString"></param>
        /// <param name="strKey"></param>
        /// <returns></returns>
        public static string DES3Encrypt(string strString, string strKey)
        {
            TripleDESCryptoServiceProvider DES = new TripleDESCryptoServiceProvider();
            DES.Key = UTF8Encoding.UTF8.GetBytes(strKey);
            DES.Mode = CipherMode.ECB;
            DES.Padding = PaddingMode.PKCS7;

            ICryptoTransform DESEncrypt = DES.CreateEncryptor();
            byte[] Buffer = UTF8Encoding.UTF8.GetBytes(strString);
            return Convert.ToBase64String(DESEncrypt.TransformFinalBlock(Buffer, 0, Buffer.Length));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="strString"></param>
        /// <param name="strKey"></param>
        /// <returns></returns>
        public static string DES3Decrypt(string strString, string strKey)
        {
            TripleDESCryptoServiceProvider DES = new TripleDESCryptoServiceProvider();
            DES.Key = UTF8Encoding.UTF8.GetBytes(strKey);
            DES.Mode = CipherMode.ECB;
            ICryptoTransform DESDecrypt = DES.CreateDecryptor();
            string result = "";
            try
            {
                byte[] Buffer = Convert.FromBase64String(strString);
                result = UTF8Encoding.UTF8.GetString(DESDecrypt.TransformFinalBlock(Buffer, 0, Buffer.Length));
            }
            catch (System.Exception e)
            {
                throw (new System.Exception("The Key or Mode is wrong!", e));
            }
            return result;

            //TripleDESCryptoServiceProvider DES = new TripleDESCryptoServiceProvider(); 
            //MD5CryptoServiceProvider hashMD5 = new MD5CryptoServiceProvider(); 
            //DES.Key = hashMD5.ComputeHash(Encoding.Default.GetBytes(strKey)); 
            //DES.Mode = CipherMode.ECB; ICryptoTransform DESEncrypt = DES.CreateEncryptor(); 
            //byte[] Buffer = Encoding.Default.GetBytes(strString); 
            //return Convert.ToBase64String(DESEncrypt.TransformFinalBlock(Buffer, 0, Buffer.Length)); 
        }
    }
}
