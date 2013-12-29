using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bussiness.Common
{
    public class SHA1
    {
        /// <summary>
        /// 得到文件的SHA1值（判断文件是否相同的唯一标识）
        /// </summary>
        /// <param name="pathName">文件路径</param>
        /// <returns>SHA1值</returns>
        public string GetSHA1Hash(string pathName)
        {
            string strResult = "";
            string strHashData = "";
            byte[] arrbytHashValue;

            System.IO.FileStream oFileStream = null;
            System.Security.Cryptography.SHA1CryptoServiceProvider osha1 = new System.Security.Cryptography.SHA1CryptoServiceProvider();
            try
            {
                oFileStream = new System.IO.FileStream(pathName.Replace("\"", ""), System.IO.FileMode.Open, System.IO.FileAccess.Read, System.IO.FileShare.ReadWrite);

                arrbytHashValue = osha1.ComputeHash(oFileStream); //计算指定Stream 对象的哈希值

                oFileStream.Close();

                //由以连字符分隔的十六进制对构成的String，其中每一对表示value 中对应的元素；例如“F-2C-4A”

                strHashData = System.BitConverter.ToString(arrbytHashValue);

                //替换-
                strHashData = strHashData.Replace("-", "");

                strResult = strHashData;
                Console.WriteLine(strResult);
            }

            catch (System.Exception ex)
            { Console.WriteLine(ex.Message); }
            return strResult;
        }
    }
}
