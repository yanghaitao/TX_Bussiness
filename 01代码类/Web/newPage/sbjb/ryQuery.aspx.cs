using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Yannis.DAO;
using SubSonic;
using Bussiness.Common;
using System.Configuration;
using System.Data;

namespace TX_Bussiness.Web.newPage.sbjb
{
    public partial class ryQuery : Comm.BasePage
    {
        protected int pagesize = int.Parse(ConfigurationManager.AppSettings["PageSize"]);
        protected int pageindex = 1;
        protected int totalcount;
        protected List<Yannis.DAO.Project> project_list;
        protected List<Yannis.DAO.ProjectTrace> project_trace;
        protected Yannis.DAO.User user;
        protected string dname="";
     //   protected List<Yannis.DAO.User> user_list;
        protected string txt_projectcode, txt_projectstate, txt_depart, txt_area, txt_street, txt_user, txt_startdate
            , txt_enddate;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (user == null)
            {
                user = GetUserInfo();
                dname = GetDepartName(user.Departcode.ToString());
            }
           
                #region[ 获取参数列表 ]
                pageindex = Utility.GetIntParameter("page") > 0 ? Utility.GetIntParameter("page") : 1;
                txt_depart = Utility.GetParameter("txt_depart");
                txt_user = Utility.GetParameter("txt_user");
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
                    if (!string.IsNullOrEmpty(user.Departcode.ToString()) && txt_depart != "0")
                        query.And(Project.DepartcodeColumn).IsEqualTo(user.Departcode.ToString());
                }
                if (!string.IsNullOrEmpty(txt_startdate))
                    query.And(Project.AdddateColumn).IsGreaterThan(txt_startdate);
                if (!string.IsNullOrEmpty(txt_enddate))
                    query.And(Project.AdddateColumn).IsLessThan(txt_enddate);

                if (!string.IsNullOrEmpty(txt_user) && txt_user != "0")
                {
                    SqlQuery sq = new Select(ProjectTrace.ProjcodeColumn).From(ProjectTrace.Schema).Distinct();
                    sq.Where("1").IsEqualTo("1");
                    sq.And(ProjectTrace.OperatoridColumn).IsEqualTo(txt_user);
                    query.And(Project.ProjcodeColumn).In(sq);
                }

                #endregion
                totalcount = query.GetRecordCount();
                query.Paged(pageindex, pagesize);
                query.OrderDesc(Project.AdddateColumn.ColumnName);
                project_list = query.ExecuteTypedList<Project>();
                string pageUrl = "/newPage/sbjb/ryQuery.aspx?txt_depart={0}&txt_user={1}&txt_startdate={2}&txt_enddate={3}&page=__id__";
                pageUrl = string.Format(pageUrl, txt_depart, txt_user, txt_startdate, txt_enddate);
                PageContent.InnerHtml = Comm.PageControl.OutPageList(this.pagesize, this.pageindex, this.totalcount, pageUrl, 8);
           
        }
    }
}