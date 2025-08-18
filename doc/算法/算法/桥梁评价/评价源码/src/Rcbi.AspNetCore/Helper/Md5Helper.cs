using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Rcbi.AspNetCore.Helper
{
    public class Md5Helper
    {
        /// <summary>
        /// 获取32位长度的Md5摘要
        /// </summary>
        /// <param name="input"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static string Get32Md5(string input, Encoding encoding = null)
        {
            if (encoding == null) encoding = Encoding.UTF8;
            StringBuilder buff = new StringBuilder(32);
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] t = md5.ComputeHash(encoding.GetBytes(input));
            foreach (byte t1 in t)
                buff.Append(t1.ToString("x").PadLeft(2, '0'));
            return buff.ToString();
        }
    }
}
