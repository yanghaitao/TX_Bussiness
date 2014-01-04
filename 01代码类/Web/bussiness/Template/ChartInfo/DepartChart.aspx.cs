using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Yannis.DAO;
using Bussiness.Common;
using SubSonic;
using System.Text;

namespace TX_Bussiness.Web.bussiness.Template.ChartInfo
{
    public partial class DepartChart : Comm.BasePage
    {
        protected string chartpath = "";
        protected string chartdatapath = "";
        protected string txt_depart, txt_startdate, txt_enddate, txt_charttype, txt_chartstyle;
        protected List<Depart> departlist = new List<Depart>();
        protected void Page_Load(object sender, EventArgs e)
        {
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
            chartdatapath = GetAppSeeting("ChartDataPath") + "Depart_ChartData.xml";
            txt_depart = Utility.GetParameter("txt_depart");
            txt_startdate = Utility.GetParameter("txt_startdate");
            txt_enddate = Utility.GetParameter("txt_enddate");
            SqlQuery query = new Select().From(Depart.Schema);
            query.Where("1=1");
            if (!string.IsNullOrEmpty(txt_depart) && txt_depart != "0")
            {
                query.And(Depart.ParentcodeColumn).IsEqualTo(txt_depart);
            }
            departlist = query.ExecuteTypedList<Depart>();
            WriteColumXML("Depart_ChartData.xml");
        }
        /// <summary>
        /// 获取部门工作量统计数据
        /// </summary>
        /// <param name="departid"></param>
        /// <returns></returns>
        protected int GetDepartCount(object departid)
        {
            SqlQuery query = new Select().From(InfoDepart.Schema);
            List<Aggregate> list = new List<Aggregate>();
            list.Add(new Aggregate(InfoDepart.Columns.Projcode, "listcount", AggregateFunction.Count));
            query.Aggregates = list;
            query.Where("1=1");
            query.Where(InfoDepart.DepartcodeColumn).IsEqualTo(departid);

            if (!string.IsNullOrEmpty(txt_startdate))
            {
                query.And(InfoDepart.AdddateColumn).IsGreaterThanOrEqualTo(txt_startdate);
            }
            if (!string.IsNullOrEmpty(txt_enddate))
            {
                query.And(InfoDepart.AdddateColumn).IsLessThanOrEqualTo(txt_enddate);
            }
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


            foreach (var v in departlist)
            {
                areasb.Append("<set label=\"" + v.Departname + "\" value=\"" + GetDepartCount(v.Id) + "\"  />");
            }

            areasb.Append("</chart>");

            FileHelper.WriteText(Server.MapPath(GetAppSeeting("ChartDataPath") + filename), areasb.ToString());
        }
    }
}