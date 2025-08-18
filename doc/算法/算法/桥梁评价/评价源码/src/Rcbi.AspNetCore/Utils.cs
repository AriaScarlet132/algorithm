using System;
using System.Text;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.IO;
using System.Configuration;

namespace Rcbi.AspNetCore
{
    public sealed class Utils
    {
        /// <summary>
        /// 获取文件的真实媒体类型。目前只支持JPG, GIF, PNG, BMP四种图片文件。
        /// </summary>
        /// <param name="fileData"></param>
        /// <returns></returns>
        public static string GetMimeType(byte[] fileData)
        {
            string suffix = GetFileSuffix(fileData);
            string mimeType;

            switch (suffix)
            {
                case "JPG": mimeType = "image/jpeg"; break;
                case "GIF": mimeType = "image/gif"; break;
                case "PNG": mimeType = "image/png"; break;
                case "BMP": mimeType = "image/bmp"; break;
                default: mimeType = "application/octet-stream"; break;
            }

            return mimeType;
        }
        /// <summary>
        /// 获取图片扩展名。目前只支持JPG, GIF, PNG, BMP四种图片文件。
        /// </summary>
        /// <param name="fileData"></param>
        /// <returns></returns>
        public static string GetFileSuffix(byte[] fileData)
        {
            if (fileData == null || fileData.Length < 10)
            {
                return null;
            }

            if (fileData[0] == 'G' && fileData[1] == 'I' && fileData[2] == 'F')
            {
                return "GIF";
            }
            else if (fileData[1] == 'P' && fileData[2] == 'N' && fileData[3] == 'G')
            {
                return "PNG";
            }
            else if (fileData[6] == 'J' && fileData[7] == 'F' && fileData[8] == 'I' && fileData[9] == 'F')
            {
                return "JPG";
            }
            else if (fileData[0] == 'B' && fileData[1] == 'M')
            {
                return "BMP";
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// HtmlEncode
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string HtmlEncode(string str)
        {
            string s = string.Empty;
            if (str.Length > 0)
            {
                s = str.Replace("&", "&gt;");
                s = s.Replace("<", "&lt;");
                s = s.Replace(">", "&gt;");
                s = s.Replace(" ", "&nbsp;");
                s = s.Replace("\'", "&#39;");
                s = s.Replace("\"", "&quot;");
                s = s.Replace("\n", "<br>");
            }
            return s;
        }
        /// <summary>
        /// HtmlDecode
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string HtmlDecode(string str)
        {
            string s = string.Empty;
            if (str.Length > 0)
            {
                s = str.Replace("&gt;", "&");
                s = s.Replace("&lt;", "<");
                s = s.Replace("&gt;", ">");
                s = s.Replace("&nbsp;", " ");
                s = s.Replace("&#39;", "\'");
                s = s.Replace("&quot;", "\"");
                s = s.Replace("<br>", "\n");
            }
            return s;
        }

        public static string QuoteJScriptString(string value)
        {
            return QuoteJScriptString(value, false);
        }

        public static string QuoteJScriptString(string value, bool forUrl)
        {
            StringBuilder builder = null;
            if (string.IsNullOrEmpty(value))
            {
                return string.Empty;
            }
            int startIndex = 0;
            int count = 0;
            for (int i = 0; i < value.Length; i++)
            {
                switch (value[i])
                {
                    case '%':
                        {
                            if (!forUrl)
                            {
                                break;
                            }
                            if (builder == null)
                            {
                                builder = new StringBuilder(value.Length + 6);
                            }
                            if (count > 0)
                            {
                                builder.Append(value, startIndex, count);
                            }
                            builder.Append("%25");
                            startIndex = i + 1;
                            count = 0;
                            continue;
                        }
                    case '\'':
                        {
                            if (builder == null)
                            {
                                builder = new StringBuilder(value.Length + 5);
                            }
                            if (count > 0)
                            {
                                builder.Append(value, startIndex, count);
                            }
                            builder.Append(@"\'");
                            startIndex = i + 1;
                            count = 0;
                            continue;
                        }
                    case '\\':
                        {
                            if (builder == null)
                            {
                                builder = new StringBuilder(value.Length + 5);
                            }
                            if (count > 0)
                            {
                                builder.Append(value, startIndex, count);
                            }
                            builder.Append(@"\\");
                            startIndex = i + 1;
                            count = 0;
                            continue;
                        }
                    case '\t':
                        {
                            if (builder == null)
                            {
                                builder = new StringBuilder(value.Length + 5);
                            }
                            if (count > 0)
                            {
                                builder.Append(value, startIndex, count);
                            }
                            builder.Append(@"\t");
                            startIndex = i + 1;
                            count = 0;
                            continue;
                        }
                    case '\n':
                        {
                            if (builder == null)
                            {
                                builder = new StringBuilder(value.Length + 5);
                            }
                            if (count > 0)
                            {
                                builder.Append(value, startIndex, count);
                            }
                            builder.Append(@"\n");
                            startIndex = i + 1;
                            count = 0;
                            continue;
                        }
                    case '\r':
                        {
                            if (builder == null)
                            {
                                builder = new StringBuilder(value.Length + 5);
                            }
                            if (count > 0)
                            {
                                builder.Append(value, startIndex, count);
                            }
                            builder.Append(@"\r");
                            startIndex = i + 1;
                            count = 0;
                            continue;
                        }
                    case '"':
                        {
                            if (builder == null)
                            {
                                builder = new StringBuilder(value.Length + 5);
                            }
                            if (count > 0)
                            {
                                builder.Append(value, startIndex, count);
                            }
                            builder.Append("\\\"");
                            startIndex = i + 1;
                            count = 0;
                            continue;
                        }
                }
                count++;
            }
            if (builder == null)
            {
                return value;
            }
            if (count > 0)
            {
                builder.Append(value, startIndex, count);
            }
            return builder.ToString();
        }

        /// <summary>
        /// 统一CA验证方法
        /// </summary>
        /// <param name="inData"></param>
        /// <param name="signData"></param>
        /// <param name="cert"></param>
        /// <returns></returns>
        public static bool VerifySign(string inData, string signData, string cert)
        {
            try
            {
                byte[] bCert = Convert.FromBase64String(cert);
                byte[] bInData = Encoding.GetEncoding("UTF-8").GetBytes(inData);
                byte[] bSignData = Convert.FromBase64String(signData);

                X509Certificate2 x509Cert = new X509Certificate2(bCert);

                RSACryptoServiceProvider oRSA4 = new RSACryptoServiceProvider();
                oRSA4.FromXmlString(x509Cert.PublicKey.Key.ToXmlString(false));
                bool bVerify = oRSA4.VerifyData(bInData, "SHA1", bSignData);
                return bVerify;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// 加密字符串
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string Encrypt(string str)
        {
            byte[] data = System.Text.ASCIIEncoding.ASCII.GetBytes(str);
            return System.Convert.ToBase64String(data);
        }

        /// <summary>
        /// 解密字符串
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string Decrypt(string str)
        {
            byte[] data = System.Convert.FromBase64String(str);
            return System.Text.ASCIIEncoding.ASCII.GetString(data);
        }

    }
}
