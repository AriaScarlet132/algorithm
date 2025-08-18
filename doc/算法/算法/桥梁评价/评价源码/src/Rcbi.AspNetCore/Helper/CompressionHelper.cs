
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rcbi.AspNetCore.Helper
{
    /// <summary>
    /// 压缩算法接口
    /// </summary>
    public interface ICompression
    {
        /// <summary>
        /// 压缩
        /// </summary>
        /// <typeparam name="T">待压缩的实体类型</typeparam>
        /// <param name="t">待压缩实体</param>
        /// <returns>string</returns>
        string Compress2String<T>(T t);

        /// <summary>
        /// 压缩
        /// </summary>
        /// <typeparam name="T">待压缩的实体类型</typeparam>
        /// <param name="t">待压缩实体</param>
        /// <returns>byte[]</returns>
        byte[] Compress2Byte<T>(T t);

        /// <summary>
        /// 解压缩
        /// </summary>
        /// <typeparam name="T">解压缩压缩的实体类型</typeparam>
        /// <param name="content">解压缩内容</param>
        /// <returns>实体</returns>
        T DeCompress<T>(string content);

        /// <summary>
        /// 解压缩
        /// </summary>
        /// <typeparam name="T">解压缩的实体类型</typeparam>
        /// <param name="content">解压缩内容</param>
        /// <returns>实体</returns>
        T DeCompress<T>(byte[] content);
    }

    public class GZip : ICompression
    {
        public byte[] Compress2Byte<T>(T t)
        {
            Newtonsoft.Json.JsonSerializerSettings json = new Newtonsoft.Json.JsonSerializerSettings();
            //json.
            string tStr = Newtonsoft.Json.JsonConvert.SerializeObject(t);
            byte[] byt = System.Text.Encoding.UTF8.GetBytes(tStr);

            //var objser = new ObjectSerializer();
            //byte[] byt = objser.Serialize(t);
            
            using (MemoryStream stream = new MemoryStream())
            {
                System.IO.Compression.GZipStream gzip = new System.IO.Compression.GZipStream(stream, System.IO.Compression.CompressionMode.Compress);
                gzip.Write(byt, 0, byt.Length);
                gzip.Close();

                return stream.ToArray();
            }

        }

        public string Compress2String<T>(T t)
        {
            byte[] result = Compress2Byte<T>(t);

            return System.Text.Encoding.Default.GetString(result);
        }

        public T DeCompress<T>(byte[] content)
        {
            T t = default(T);

            using (MemoryStream tempStream = new MemoryStream())
            {
                using (MemoryStream stream = new MemoryStream(content))
                {
                    System.IO.Compression.GZipStream gzip = new System.IO.Compression.GZipStream(stream, System.IO.Compression.CompressionMode.Decompress);
                    gzip.CopyTo(tempStream);
                    gzip.Close();

                    string result = System.Text.Encoding.UTF8.GetString(tempStream.ToArray());

                    t = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(result);

                    //var objser = new ObjectSerializer();
                    //t = (T)objser.Deserialize(tempStream.ToArray());
                }
            }

            return t;
        }

        public T DeCompress<T>(string content)
        {
            byte[] byt = System.Text.Encoding.Default.GetBytes(content);

            return DeCompress<T>(byt);
        }
    }
}
