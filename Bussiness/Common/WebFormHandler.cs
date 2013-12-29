using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Collections;
using System.Web;
using System.IO;

namespace Bussiness.Common
{
   public  class WebFormHandler
    {

        /// <summary>
        /// 上传文件
        /// </summary>
        /// <returns></returns>
        public static ArrayList SaveFiles(string filePath, string newFileName)
        {
            ///'遍历File表单元素
            HttpFileCollection files = HttpContext.Current.Request.Files;
            ArrayList list = new ArrayList();
            try
            {
                for (int i = 0; i < files.Count; i++)
                {
                    ///'检查文件扩展名字
                    HttpPostedFile postedFile = files[i];
                    string fileExtension = System.IO.Path.GetExtension(postedFile.FileName);
                    string fileName = newFileName + fileExtension;
                    if (fileName != "")
                    {
                        ///注意：可能要修改你的文件夹的匿名写入权限。
                        postedFile.SaveAs(System.Web.HttpContext.Current.Request.MapPath(filePath) + fileName);
                    }
                    list.Add(fileName);
                }
                list.TrimToSize();
                return list;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 显示状态
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        public static string StateView(bool state)
        {
            if (state)
                return string.Format("<font color=\"red\">{0}</font>", "√");
            else
                return "×";
        }
        ///   <summary> 
        ///   传入URL返回网页的html代码 
        ///   </summary> 
        ///   <param   name="Url">URL</param> 
        ///   <returns></returns> 
        public static string GetUrltoHtml(string Url)
        {
            string html = "";
            Uri uri = new Uri(Url);
            System.Net.HttpWebRequest wReq = (System.Net.HttpWebRequest)System.Net.HttpWebRequest.Create(uri);
            System.Net.HttpWebResponse wResp = (System.Net.HttpWebResponse)wReq.GetResponse();
            using (System.IO.Stream respStream = wResp.GetResponseStream())
            {
                using (System.IO.StreamReader reader = new System.IO.StreamReader(respStream, System.Text.Encoding.GetEncoding("UTF-8")))
                {
                    html = reader.ReadToEnd();
                }
            }
            return html;
        }
        /// <summary>
        /// 根据文件名和url创建静态文件
        /// </summary>
        /// <param name="fileName">静态文件名,不带后缀名,后缀名为htm</param>
        /// <param name="url">带域名的url</param>
        public static void CreateHMTLFile(string fileName, string url)
        {
            string pathFile = HttpContext.Current.Server.MapPath("~/" + fileName + ".htm");
            string html = GetUrltoHtml(url);
            if (!File.Exists(pathFile))
            {
                using (FileStream fs = File.Create(pathFile))
                {
                    using (StreamWriter sw = new StreamWriter(fs))
                    {
                        sw.Write(html);
                    }
                }
            }
            else
            {
                using (StreamWriter sw = new StreamWriter(pathFile))
                {
                    sw.Write(html);
                }

            }
        }
       
        /// <summary>
        /// 将dataTable转成XML格式
        /// </summary>
        /// <param name="dt">DataTabel对象</param>
        /// <returns>xml字符串</returns>
        public static string CreateXMLParameters(DataTable dt)
        {
            StringBuilder xmlstring = new StringBuilder();
            xmlstring.Append("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
            xmlstring.Append("<" + dt.TableName + ">");
            for (int i = 0; i < dt.Rows.Count; i++)
            {

                xmlstring.Append("<rows>");
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    xmlstring.Append("<" + dt.Columns[j].ColumnName + ">");
                    xmlstring.Append("<![CDATA[" + dt.Rows[i][j].ToString() + "]]>");
                    xmlstring.Append("</" + dt.Columns[j].ColumnName + ">");
                }
                xmlstring.Append("</rows>");
            }
            xmlstring.Append("</" + dt.TableName + ">");
            return xmlstring.ToString();
        }
        
    }
}
