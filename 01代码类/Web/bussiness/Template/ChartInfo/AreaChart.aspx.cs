using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Bussiness.Common;
using TX_Bussiness.Web.Comm;
using SubSonic;
using Yannis.DAO;
using System.Text;

namespace TX_Bussiness.Web.bussiness.Template.ChartInfo
{
    public partial class AreaChart : Comm.BasePage
    {
        protected string chartpath = "";
        protected string chartdatapath = "";
        protected string txt_area, txt_street, txt_commnuity, txt_startdate
               , txt_enddate, txt_infotype, txt_charttype, txt_chartstyle;
        protected List<SArea> arealist = new List<SArea>();
        protected List<SStreet> streetlist = new List<SStreet>();
        protected List<SCommunity> commnuitylist = new List<SCommunity>();
        protected void Page_Load(object sender, EventArgs e)
        {
            txt_area = Utility.GetParameter("txt_area");
            txt_street = Utility.GetParameter("txt_street");
            txt_commnuity = Utility.GetParameter("txt_commnuity");
            txt_startdate = Utility.GetParameter("txt_startdate");
            txt_enddate = Utility.GetParameter("txt_enddate");
            txt_infotype = !string.IsNullOrEmpty(Utility.GetParameter("txt_infotype")) ? Utility.GetParameter("txt_infotype") : "1";
            #region [ 图表类型 ]
            txt_charttype = Utility.GetParameter("txt_charttype");
            txt_chartstyle = Utility.GetParameter("txt_chartstyle");
            if (txt_charttype == "1")
            {
                if (txt_chartstyle == "1")
                    chartpath = GetAppSeeting("ChartFilePath") + "Line.swf";
                if (txt_chartstyle == "2")
                    chartpath = GetAppSeeting("ChartFilePath") + "ZoomLine.swf";
             
            }
            if (txt_charttype == "2")
            {
                if (txt_chartstyle == "1")
                    chartpath = GetAppSeeting("ChartFilePath") + "Column2D.swf";
                if (txt_chartstyle == "2")
                    chartpath = GetAppSeeting("ChartFilePath") + "Column3D.swf";
               
            }
            if (txt_charttype == "3")
            {
                if (txt_chartstyle == "1")
                    chartpath = GetAppSeeting("ChartFilePath") + "Pie2D.swf";
                if (txt_chartstyle == "2")
                    chartpath = GetAppSeeting("ChartFilePath") + "Pie3D.swf";
            }
            #endregion
            if (int.Parse(txt_infotype) == (int)Enums.AreaCountType.Area)
            {
                SqlQuery query = new Select().From(SArea.Schema);
                query.Where("1=1");
                if (txt_area != "0" && !string.IsNullOrEmpty(txt_area))
                    query.And(SArea.AreacodeColumn).IsEqualTo(txt_area);
                arealist = query.ExecuteTypedList<SArea>();
                WriteColumXML("Area_ChartData.xml");
                chartdatapath = GetAppSeeting("ChartDataPath") + "Area_ChartData.xml";
            }
            if (int.Parse(txt_infotype) == (int)Enums.AreaCountType.Street)
            {
                SqlQuery query = new Select().From(SStreet.Schema);
                query.Where("1=1");
                if (!string.IsNullOrEmpty(txt_area) && txt_area != "0")
                    query.And(SStreet.AreacodeColumn).IsEqualTo(txt_area);
                if (!string.IsNullOrEmpty(txt_street) && txt_street != "0")
                    query.And(SStreet.StreetcodeColumn).IsEqualTo(txt_street);
                streetlist = query.ExecuteTypedList<SStreet>();
                WriteColumXML("Street_ChartData.xml");
                chartdatapath = GetAppSeeting("ChartDataPath") + "Street_ChartData.xml";
            }
            if (int.Parse(txt_infotype) == (int)Enums.AreaCountType.Commnuity)
            {
                SqlQuery query = new Select().From(SCommunity.Schema);
                query.Where("1=1");
                if (!string.IsNullOrEmpty(txt_street) && txt_street != "0")
                    query.And(SCommunity.StreetcodeColumn).IsEqualTo(txt_street);
                if (!string.IsNullOrEmpty(txt_commnuity) && txt_commnuity != "0")
                    query.And(SCommunity.CommcodeColumn).IsEqualTo(txt_commnuity);
                commnuitylist = query.ExecuteTypedList<SCommunity>();
                WriteColumXML("Commnuity_ChartData.xml");
                chartdatapath = GetAppSeeting("ChartDataPath") + "Commnuity_ChartData.xml";
            }
        }
        /// <summary>
        /// 获取工作量统计数据
        /// </summary>
        /// <param name="code"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        protected int GetAreacount(object code, Enums.AreaCountType type)
        {
            SqlQuery query = new Select().From(InfoArea.Schema);
            List<Aggregate> list = new List<Aggregate>();
            list.Add(new Aggregate(InfoArea.Columns.Projcode, "listcount", AggregateFunction.Count));
            query.Aggregates = list;
            query.Where("1=1");
            if (!string.IsNullOrEmpty(txt_startdate))
            {
                query.And(InfoArea.AdddateColumn).IsGreaterThanOrEqualTo(txt_startdate);
            }
            if (!string.IsNullOrEmpty(txt_enddate))
            {
                query.And(InfoArea.AdddateColumn).IsLessThanOrEqualTo(txt_enddate);
            }
            if (type == Enums.AreaCountType.Area)
                query.And(InfoArea.AreacodeColumn).IsEqualTo(code);
            if (type == Enums.AreaCountType.Street)
                query.And(InfoArea.StreetcodeColumn).IsEqualTo(code);
            if (type == Enums.AreaCountType.Commnuity)
                query.And(InfoArea.CommnuitycodeColumn).IsEqualTo(code);
            object o = query.ExecuteScalar();
            if (o != null)
                return Convert.ToInt32(o);
            return 0;
        }
        /// <summary>
        /// 写入统计图表xml文件
        /// </summary>
        /// <param name="filename"></param>
        protected void WriteColumXML(string filename)
        {
            StringBuilder areasb = new StringBuilder();
            areasb.Append("<chart yAxisName=\"工作量\" caption=\"人员工作量统计\" useRoundEdges=\"1\" bgColor=\"FFFFFF,FFFFFF\" showBorder=\"0\" exportEnabled=\"1\" exportAtClient=\"1\" exportHandler=\"fcExporter1\" exportDialogMessage=\"正在生成，请稍等...\" exportFormats=\"JPG=生成JPG图片|PDF=生成PDF文件\">");
            if (int.Parse(txt_infotype) == (int)Enums.AreaCountType.Area)
            {
                foreach (var v in arealist)
                {
                    areasb.Append("<set label=\"" + v.Areaname + "\" value=\"" + GetAreacount(v.Areacode, Enums.AreaCountType.Area) + "\"  />");
                }
            }
            if (int.Parse(txt_infotype) == (int)Enums.AreaCountType.Street)
            {
                foreach (var v in streetlist)
                {
                    areasb.Append("<set label=\"" + v.Streetname + "\" value=\"" + GetAreacount(v.Streetcode, Enums.AreaCountType.Street) + "\"  />");
                }
            }
            if (int.Parse(txt_infotype) == (int)Enums.AreaCountType.Commnuity)
            {
                foreach (var v in commnuitylist)
                {
                    areasb.Append("<set label=\"" + v.Commname + "\" value=\"" + GetAreacount(v.Commcode, Enums.AreaCountType.Commnuity) + "\"  />");
                }
            }
            areasb.Append("</chart>");

            FileHelper.WriteText(Server.MapPath(GetAppSeeting("ChartDataPath") + filename), areasb.ToString());
        }
    }
}