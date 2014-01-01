using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SubSonic;
using Yannis.DAO;
using System.Configuration;
using Bussiness.Common;
using TX_Bussiness.Web.Comm;

namespace TX_Bussiness.Web.bussiness.Template
{
    public partial class CompleteProject : Comm.BasePage
    {
        protected int pagesize = int.Parse(ConfigurationManager.AppSettings["PageSize"]);
        protected int pageindex = 1;
        protected int totalcount;
        protected List<Yannis.DAO.Project> project_list;
        protected string txt_projectcode, txt_projectstate, txt_depart, txt_area, txt_street, txt_commnuity, txt_startdate
            , txt_enddate;
        protected void Page_Load(object sender, EventArgs e)
        {
            #region [ 获取参数列表 ]
            pageindex = Utility.GetIntParameter("page") > 0 ? Utility.GetIntParameter("page") : 1;
            txt_projectcode = Utility.GetParameter("txt_projectcode");
            txt_projectstate = Utility.GetParameter("txt_projectstate");
            txt_depart = Utility.GetParameter("txt_depart");
            txt_area = Utility.GetParameter("txt_area");
            txt_street = Utility.GetParameter("txt_street");
            txt_commnuity = Utility.GetParameter("txt_commnuity");
            txt_startdate = Utility.GetParameter("txt_startdate");
            txt_enddate = Utility.GetParameter("txt_enddate");
            #endregion
            SqlQuery query = new Select().From(Project.Schema);
            query.Where("1=1");
            #region[ 组合查询条件 ]
            if (CheckRole(GetUserInfo().Id, Comm.Constant.RoleCode_JLD))
            {
                query.And(Project.NodeidColumn).IsGreaterThan(1);
                query.And(Project.ReportpersonidColumn).IsEqualTo(GetUserInfo().Id);
            }
            else if (CheckRole(GetUserInfo().Id, Comm.Constant.RoleCode_ZDZ))
            {
                query.And(Project.NodeidColumn).IsGreaterThan(2);
                query.And(Project.DepartcodeColumn).IsEqualTo(GetUserInfo().Departcode);
            }
            else if (CheckRole(GetUserInfo().Id, Comm.Constant.RoleCode_ZFRY))
            {
                query.And(Project.NodeidColumn).IsGreaterThan(3);
                query.And(Project.HandleridColumn).IsEqualTo(GetUserInfo().Id);
            }
            if (!string.IsNullOrEmpty(txt_projectstate) && txt_projectstate != "0")
            {
                query.And(Project.ProjectstateColumn).IsEqualTo(txt_projectstate);
            }
            if (!string.IsNullOrEmpty(txt_projectcode))
                query.And(Project.ProjcodeColumn).IsEqualTo(txt_projectcode);
            if (!string.IsNullOrEmpty(txt_depart) && txt_depart != "0")
                query.And(Project.DepartcodeColumn).IsEqualTo(txt_depart);
            if (!string.IsNullOrEmpty(txt_area) && txt_area != "0")
                query.And(Project.AreacodeColumn).IsEqualTo(txt_area);
            if (!string.IsNullOrEmpty(txt_street) && txt_street != "0")
                query.And(Project.StreetcodeColumn).IsEqualTo(txt_street);
            if (!string.IsNullOrEmpty(txt_commnuity) && txt_commnuity != "0")
                query.And(Project.CommunitycodeColumn).IsEqualTo(txt_commnuity);
            if (!string.IsNullOrEmpty(txt_startdate))
                query.And(Project.AdddateColumn).IsGreaterThan(txt_startdate);
            if (!string.IsNullOrEmpty(txt_enddate))
                query.And(Project.AdddateColumn).IsLessThan(txt_enddate);
            #endregion
            totalcount = query.GetRecordCount();
            query.Paged(pageindex, pagesize);
            query.OrderDesc(Project.AdddateColumn.ColumnName);
            project_list = query.ExecuteTypedList<Project>();
            string pageUrl = "/bussiness/template/completeproject.aspx?txt_projectcode={0}&txt_projectstate={1}&txt_depart={2}&txt_area={3}&txt_street={4}&txt_commnuity={5}&txt_startdate={6}&txt_enddate={7}&page=__id__";
            pageUrl = string.Format(pageUrl, txt_projectcode, txt_projectstate, txt_depart, txt_area, txt_street, txt_commnuity, txt_startdate, txt_enddate);
            PageContent.InnerHtml = Comm.PageControl.OutPageList(this.pagesize, this.pageindex, this.totalcount, pageUrl, 8);
        }
    }
}