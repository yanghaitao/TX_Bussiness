using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SubSonic;
using Yannis.DAO;
using System.Text;
using System.Data;
using Bussiness.Common;

namespace TX_Bussiness.Web.newPage.qwsj
{
    public partial class departchart : Comm.BasePage
    {
        protected string chartpath = "";
        protected string chartdatapath = "";
        protected string txt_depart, txt_startdate, txt_enddate, txt_charttype, txt_chartstyle, expportexcel;
        protected List<Depart> departlist = new List<Depart>();
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
            chartpath = GetAppSeeting("ChartFilePath") + "Line.swf";//默认图标类型
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

            #region [ 获取图表所需部门数据 ]
            SqlQuery query = new Select().From(Depart.Schema);
            query.Where("1=1");
            query.And(Depart.IsdelColumn).IsNotEqualTo(true);
            ///中队长只能查看自己部门的统计数据
            if (CheckRole(user.Id, TX_Bussiness.Web.Comm.Constant.RoleCode_ZDZ))
            {
                query.And(Depart.DepartcodeColumn).IsEqualTo(user.Departcode);
            }
            if (!string.IsNullOrEmpty(txt_depart) && txt_depart != "0")
            {
                query.And(Depart.ParentcodeColumn).IsEqualTo(txt_depart);
            }
            departlist = query.ExecuteTypedList<Depart>();
            WriteColumXML("Depart_ChartData.xml");
            chartdatapath = GetAppSeeting("ChartDataPath") + "Depart_ChartData.xml";
            #endregion
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
            DataTable dt = new DataTable();
            //区域统计合计数据
            int totlecount = 0;
            //excel表格导出xml数据
            StringBuilder excelxmlsb = new StringBuilder("<data>");
            StringBuilder areasb = new StringBuilder();

            #region [ 获取图表所需xml数据 ]
            areasb.Append("<chart yAxisName=\"工作量\" caption=\"部门工作量统计\" useRoundEdges=\"1\" bgColor=\"FFFFFF,FFFFFF\" showBorder=\"0\" exportEnabled=\"1\" exportAtClient=\"1\" exportHandler=\"fcExporter1\" exportDialogMessage=\"正在生成，请稍等...\" exportFormats=\"JPG=生成JPG图片|PDF=生成PDF文件\">");
            foreach (var v in departlist)
            {
                int departcount = GetDepartCount(v.Id);
                areasb.Append("<set label=\"" + v.Departname + "\" value=\"" + departcount + "\"  />");
                excelxmlsb.Append("<set label=\"" + v.Departname + "\" value=\"" + departcount + "\"  />");
                totlecount += departcount;
            }
            areasb.Append("</chart>");
            FileHelper.WriteText(Server.MapPath(GetAppSeeting("ChartDataPath") + filename), areasb.ToString());
            #endregion

            #region[ 导出excel表格 ]
            if (expportexcel == "1")
            {
                excelxmlsb.Append("</data>");
                dt = Utility.ConvertToDateSetByXmlString(excelxmlsb.ToString()).Tables[0];
                dt.TableName = "桐乡市勤务执法平台部门工作量统计";
                dt.Columns[0].ColumnName = "部门名称";
                dt.Columns[1].ColumnName = "工作量";
                DataRow row = dt.NewRow();
                row[0] = "总计";
                row[1] = totlecount;
                dt.Rows.Add(row);
                Utility.ExportToExcel("桐乡市勤务执法平台-部门统计", dt);
            }
            #endregion
        }
    }
}