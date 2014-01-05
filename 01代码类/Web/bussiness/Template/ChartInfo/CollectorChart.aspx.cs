using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Bussiness.Common;
using SubSonic;
using Yannis.DAO;
using System.Text;
using TX_Bussiness.Web.Comm;
using System.Data;

namespace TX_Bussiness.Web.bussiness.Template.ChartInfo
{
    public partial class CollectorChart : Comm.BasePage
    {
        protected string chartpath = "";
        protected string chartdatapath = "";
        protected string txt_depart, txt_startdate, txt_enddate, txt_charttype, txt_chartstyle,expportexcel;
        protected List<Yannis.DAO.User> userlist = new List<Yannis.DAO.User>();
        protected void Page_Load(object sender, EventArgs e)
        {
            Yannis.DAO.User user = GetUserInfo();

            #region [ 获取参数列表 ]
            expportexcel = Utility.GetParameter("expportexcel");//是否导出EXCEL
            txt_depart = Utility.GetParameter("txt_depart");
            txt_startdate = Utility.GetParameter("txt_startdate");
            txt_enddate = Utility.GetParameter("txt_enddate");
            #endregion

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

            #region [ 获取图表所需人员数据 ]
            chartdatapath = GetAppSeeting("ChartDataPath") + "Collectoe_ChartData.xml";
            SqlQuery query = new Select().From(Yannis.DAO.User.Schema);
            query.Where("1=1");
            ///中队长只能查看自己部门下面的人员工作量
            if (CheckRole(user.Id, TX_Bussiness.Web.Comm.Constant.RoleCode_ZDZ))
            {
                query.Where(Yannis.DAO.User.DepartcodeColumn).IsEqualTo(GetUserInfo().Departcode);
            }
            if (!string.IsNullOrEmpty(txt_depart) && txt_depart != "0")
            {
                query.And(Yannis.DAO.User.DepartcodeColumn).IsEqualTo(txt_depart);
            }
            userlist = query.ExecuteTypedList<Yannis.DAO.User>();
            WriteColumXML("Collectoe_ChartData.xml");
            #endregion
        }
        /// <summary>
        /// 获取人员工作量统计数据
        /// </summary>
        /// <param name="departid"></param>
        /// <returns></returns>
        protected int GetCollectorCount(object userid)
        {
            SqlQuery query = new Select().From(InfoCollector.Schema);
            List<Aggregate> list = new List<Aggregate>();
            list.Add(new Aggregate(InfoArea.Columns.Projcode, "listcount", AggregateFunction.Count));
            query.Aggregates = list;
            query.Where("1=1");
            query.Where(InfoCollector.CollectoridColumn).IsEqualTo(userid);

            if (!string.IsNullOrEmpty(txt_startdate))
            {
                query.And(InfoCollector.AdddateColumn).IsGreaterThanOrEqualTo(txt_startdate);
            }
            if (!string.IsNullOrEmpty(txt_enddate))
            {
                query.And(InfoCollector.AdddateColumn).IsLessThanOrEqualTo(txt_enddate);
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
            DataTable dt = new DataTable();
            //区域统计合计数据
            int totlecount = 0;
            //excel表格导出xml数据
            StringBuilder excelxmlsb = new StringBuilder("<data>");
            StringBuilder areasb = new StringBuilder();
            #region [ 获取图表所需xml数据 ]
            areasb.Append("<chart yAxisName=\"工作量\" caption=\"人员工作量统计\" useRoundEdges=\"1\" bgColor=\"FFFFFF,FFFFFF\" showBorder=\"0\" exportEnabled=\"1\" exportAtClient=\"1\" exportHandler=\"fcExporter1\" exportDialogMessage=\"正在生成，请稍等...\" exportFormats=\"JPG=生成JPG图片|PDF=生成PDF文件\">");
            foreach (var v in userlist)
            {
                int collectorcount = GetCollectorCount(v.Id);
                areasb.Append("<set label=\"" + v.Username + "\" value=\"" + collectorcount + "\"  />");
                excelxmlsb.Append("<set label=\"" + v.Username + "\" value=\"" + collectorcount + "\"  />");
                totlecount += collectorcount;
            }
            areasb.Append("</chart>");
            #endregion
            FileHelper.WriteText(Server.MapPath(GetAppSeeting("ChartDataPath") + filename), areasb.ToString());

            #region[ 导出excel表格 ]
            if (expportexcel == "1")
            {
                excelxmlsb.Append("</data>");
                dt = Utility.ConvertToDateSetByXmlString(excelxmlsb.ToString()).Tables[0];
                dt.TableName = "桐乡市勤务执法平台人员工作量统计";
                dt.Columns[0].ColumnName = "姓名";
                dt.Columns[1].ColumnName = "工作量";
                DataRow row = dt.NewRow();
                row[0] = "总计";
                row[1] = totlecount;
                dt.Rows.Add(row);
                Utility.ExportToExcel("桐乡市勤务执法平台-人员统计", dt);
            }
            #endregion
        }
    }
}