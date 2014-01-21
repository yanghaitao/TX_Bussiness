using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SubSonic;
using Yannis.DAO;
using Bussiness.Common;

namespace TX_Bussiness.Web.newPage.qwsj
{
    public partial class collector_info :Comm.BasePage
    {
        protected int pagesize = 10;
        protected int pageindex = 1;
        protected int totalcount;
        protected string txt_depart, txt_startdate, txt_enddate;
        protected List<Yannis.DAO.User> userlist = new List<Yannis.DAO.User>();
        protected void Page_Load(object sender, EventArgs e)
        {
            Yannis.DAO.User user = GetUserInfo();
            pageindex = Utility.GetIntParameter("page") > 0 ? Utility.GetIntParameter("page") : 1;
            txt_depart = Utility.GetParameter("txt_depart");
            txt_startdate = Utility.GetParameter("txt_startdate");
            txt_enddate = Utility.GetParameter("txt_enddate");
            SqlQuery query = new Select().From(Yannis.DAO.User.Schema);
            query.Where("1=1");
            query.And(Yannis.DAO.User.IsdelColumn).IsNotEqualTo(true);
            ///中队长只能查看自己部门下面的人员工作量
            if (CheckRole(user.Id, TX_Bussiness.Web.Comm.Constant.RoleCode_ZDZ))
            {
                query.Where(Yannis.DAO.User.DepartcodeColumn).IsEqualTo(GetUserInfo().Departcode);
            }
            if (!string.IsNullOrEmpty(txt_depart) && txt_depart != "0")
            {
                query.And(Yannis.DAO.User.DepartcodeColumn).IsEqualTo(txt_depart);
            }
            totalcount = query.GetRecordCount();
            query.Paged(pageindex, pagesize);
            userlist = query.ExecuteTypedList<Yannis.DAO.User>();
            string pageUrl = "/bussiness/template/collector_info.aspx?txt_depart={0}&txt_startdate={1}&txt_enddate={2}&page=__id__";
            pageUrl = string.Format(pageUrl, txt_depart, txt_startdate, txt_enddate);
            PageContent.InnerHtml = Comm.PageControl.OutPageList(this.pagesize, this.pageindex, this.totalcount, pageUrl, 8);
        }
        protected int GetCollectorCount(object userid)
        {
            SqlQuery query = new Select().From(Project.Schema);
            List<Aggregate> list = new List<Aggregate>();
            list.Add(new Aggregate(Project.Columns.Projcode, "listcount", AggregateFunction.Count));
            query.Aggregates = list;
            query.Where("1=1");
            query.And(Project.NodeidColumn).IsEqualTo(4);
            query.And(Project.HandleridColumn).IsEqualTo(userid);

            if (!string.IsNullOrEmpty(txt_startdate))
            {
                query.And(Project.AdddateColumn).IsGreaterThanOrEqualTo(txt_startdate);
            }
            if (!string.IsNullOrEmpty(txt_enddate))
            {
                query.And(Project.AdddateColumn).IsLessThanOrEqualTo(txt_enddate);
            }
            object o = query.ExecuteScalar();
            if (o != null)
                return Convert.ToInt32(o);
            return 0;
        }
    }
}