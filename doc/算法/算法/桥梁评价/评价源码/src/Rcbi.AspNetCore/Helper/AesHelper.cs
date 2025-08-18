using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Rcbi.AspNetCore.Helper
{
    public sealed class AesHelper
    {
        /// <summary>
        /// 默认密钥-密钥的长度必须是32
        /// </summary>
        private const string PublicKey = "5jhkkgn65dkgnkfj946utef7y63k3wed";

        /// <summary>
        /// 默认向量-长度必须是16
        /// </summary>
        private const string Iv = "abcdefghijklmnop";
        /// <summary>  
        /// AES加密  
        /// </summary>  
        /// <param name="str">需要加密字符串</param>  
        /// <returns>加密后字符串</returns>  
        public static String Encrypt(string str)
        {
             try
            {
            return Encrypt(str, PublicKey);
            }
             catch
             {
                throw;
             }
        }

        /// <summary>  
        /// AES解密  
        /// </summary>  
        /// <param name="str">需要解密字符串</param>  
        /// <returns>解密后字符串</returns>  
        public static String Decrypt(string str)
        {
            try
            {
                return Decrypt(str, PublicKey);
            }
            catch
            {
                throw;
            }
        }
        /// <summary>
        /// AES加密
        /// </summary>
        /// <param name="str">需要加密的字符串</param>
        /// <param name="key">32位密钥</param>
        /// <returns>加密后的字符串</returns>
        public static string Encrypt(string str, string key)
        {
            Byte[] keyArray = System.Text.Encoding.UTF8.GetBytes(key);
            Byte[] toEncryptArray = System.Text.Encoding.UTF8.GetBytes(str);
            var rijndael = new System.Security.Cryptography.RijndaelManaged();
            rijndael.Key = keyArray;
            rijndael.Mode = System.Security.Cryptography.CipherMode.ECB;
            rijndael.Padding = System.Security.Cryptography.PaddingMode.PKCS7;
            rijndael.IV = System.Text.Encoding.UTF8.GetBytes(Iv);
            System.Security.Cryptography.ICryptoTransform cTransform = rijndael.CreateEncryptor();
            Byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }
        /// <summary>
        /// AES解密
        /// </summary>
        /// <param name="str">需要解密的字符串</param>
        /// <param name="key">32位密钥</param>
        /// <returns>解密后的字符串</returns>
        public static string Decrypt(string str, string key)
        {
            Byte[] keyArray = System.Text.Encoding.UTF8.GetBytes(key);
            Byte[] toEncryptArray = Convert.FromBase64String(str);
            var rijndael = new System.Security.Cryptography.RijndaelManaged();
            rijndael.Key = keyArray;
            rijndael.Mode = System.Security.Cryptography.CipherMode.ECB;
            rijndael.Padding = System.Security.Cryptography.PaddingMode.PKCS7;
            rijndael.IV = System.Text.Encoding.UTF8.GetBytes(Iv);
            System.Security.Cryptography.ICryptoTransform cTransform = rijndael.CreateDecryptor();
            Byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
            return System.Text.Encoding.UTF8.GetString(resultArray);
        }

        public static string SSODecrypt(string encryptText, string key)
        {
            using (var md5 = new MD5CryptoServiceProvider())
            {
                byte[] algorithm = md5.ComputeHash(Encoding.Default.GetBytes(key));
                byte[] encryptBytes = Convert.FromBase64String(encryptText);

                // Create a new MemoryStream using the passed 
                // array of encrypted data.
                MemoryStream msDecrypt = new MemoryStream(encryptBytes);
                Rijndael aes = Rijndael.Create();
                aes.Mode = CipherMode.ECB;
                aes.Padding = PaddingMode.PKCS7;
                // Create a CryptoStream using the MemoryStream 
                // and the passed key and initialization vector (IV).
                CryptoStream csDecrypt = new CryptoStream(msDecrypt,
                    aes.CreateDecryptor(algorithm, null),
                    CryptoStreamMode.Read);
                // Create buffer to hold the decrypted data.
                byte[] fromEncrypt = new byte[encryptBytes.Length];
                // Read the decrypted data out of the crypto stream
                // and place it into the temporary buffer.
                int len = csDecrypt.Read(fromEncrypt, 0, fromEncrypt.Length);
                //Convert the buffer into a string and return it.
                return Encoding.Default.GetString(fromEncrypt, 0, len);
            }
        }

        public static string SSOEncrypt(string originalText, string key)
        {
            using (var md5 = new MD5CryptoServiceProvider())
            {
                byte[] algorithm = md5.ComputeHash(Encoding.Default.GetBytes(key));
                byte[] originalBytes = Encoding.Default.GetBytes(originalText);

                // Create a new MemoryStream using the passed 
                // array of encrypted data.
                MemoryStream msEncrypt = new MemoryStream();
                Rijndael aes = Rijndael.Create();
                aes.Mode = CipherMode.ECB;
                aes.Padding = PaddingMode.PKCS7;
                // Create a CryptoStream using the MemoryStream 
                // and the passed key and initialization vector (IV).
                CryptoStream csEncrypt = new CryptoStream(msEncrypt,
                    aes.CreateEncryptor(algorithm, null),
                    CryptoStreamMode.Write);
                // Write the decrypted data out of the crypto stream
                // and place it into the temporary buffer.
                csEncrypt.Write(originalBytes, 0, originalBytes.Length);
                csEncrypt.FlushFinalBlock();
                //Convert the buffer into a string and return it.
                return Convert.ToBase64String(msEncrypt.ToArray());
            }
        }
    }
}
