using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;

namespace Rcbi.AspNetCore.Helper
{
    public sealed class CryptRandomHelper
    {
        //随机数对象
        private RNGCryptoServiceProvider _rng;

        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        public CryptRandomHelper()
        {
            //为随机数对象赋值
            this._rng = new RNGCryptoServiceProvider();
        }
        #endregion

        #region 生成一个指定范围的随机整数
        /// <summary>
        /// 生成一个范围从1到指定值的随机整数,包括1和最大值
        /// </summary>        
        /// <param name="maxNum">最大值</param>
        public int GetRandomInt(int maxNum)
        {
            //接收随机数的字节数组
            byte[] bytes = new byte[1];

            //填充字节数组
            this._rng.GetBytes(bytes);

            //返回范围从1到最大值的整数
            return (int)((decimal)bytes[0] / 256 * maxNum) + 1;
        }
        #endregion

        /// <summary>
        /// 中随机生成指定长度的密码
        /// </summary>
        /// <param name="pwdLength">长度</param>
        /// <returns></returns>
        public static string MakeRandomPassword(int pwdLength)
        {     //声明要返回的字符串    
            string tmpstr = "";
            //密码中包含的字符数组    
            string pwdchars = "abcdefghijklmnopqrstuvwxyz0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            //数组索引随机数    
            int iRandNum;
            //随机数生成器    
            Random rnd = new Random();
            for (int i = 0; i < pwdLength; i++)
            {      //Random类的Next方法生成一个指定范围的随机数     
                iRandNum = rnd.Next(pwdchars.Length);
                //tmpstr随机添加一个字符     
                tmpstr += pwdchars[iRandNum];
            }
            return tmpstr;
        }
        /// <summary>
        /// 字符串中随机生成指定长度
        /// </summary>
        /// <param name="pwdchars"></param>
        /// <param name="pwdLength"></param>
        /// <returns></returns>
        public static string MakeRandomPassword(string pwdchars, int pwdLength)
        {     //声明要返回的字符串    
            string tmpstr = "";
            //密码中包含的字符数组    
            //数组索引随机数    
            int iRandNum;
            //随机数生成器    
            Random rnd = new Random();
            for (int i = 0; i < pwdLength; i++)
            {      //Random类的Next方法生成一个指定范围的随机数     
                iRandNum = rnd.Next(pwdchars.Length);
                //tmpstr随机添加一个字符     
                tmpstr += pwdchars[iRandNum];
            }
            return tmpstr;
        } 

    }
}
