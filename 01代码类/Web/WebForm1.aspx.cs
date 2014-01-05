using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SubSonic;
using Yannis.DAO;
using LitJson;
using System.Data;
using Bussiness.Common;
using System.IO;
using System.Xml;

namespace TX_Bussiness.Web
{
    public partial class WebForm1 : Comm.BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           string xmlstr= FileHelper.GetFileText(Server.MapPath("/Charts/Data/Area_ChartData.xml"));
           DataSet ds= ConvertToDateSetByXmlString(xmlstr);
            Utility.ExportToExcel("test",ds.Tables[0]);
        }
        /// <summary>
        /// 将XML字符串转换成DATASET
        /// </summary>
        /// <param name="xmlStr"></param>
        /// <returns></returns>
        public static DataSet ConvertToDateSetByXmlString(string xmlStr)
        {
            if (xmlStr.Length > 0)
            {
                StringReader StrStream = null;
                XmlTextReader Xmlrdr = null;
                try
                {
                    DataSet ds = new DataSet();
                    //读取字符串中的信息
                    StrStream = new StringReader(xmlStr);
                    //获取StrStream中的数据
                    Xmlrdr = new XmlTextReader(StrStream);
                    //ds获取Xmlrdr中的数据  
                    //ds.ReadXmlSchema(Xmlrdr);
                    ds.ReadXml(Xmlrdr);
                    return ds;
                }
                catch (Exception e)
                {
                    throw e;
                }
                finally
                {
                    //释放资源
                    if (Xmlrdr != null)
                    {
                        Xmlrdr.Close();
                        StrStream.Close();
                    }
                }
            }
            else
            {
                return null;
            }
        }
    }
}