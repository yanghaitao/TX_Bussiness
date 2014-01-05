using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Bussiness.Common;
using SubSonic;
using Yannis.DAO;

namespace TX_Bussiness.Web.bussiness.Template
{
    public partial class Depart_Info : Comm.BasePage
    {
        protected int pagesize = 10;
        protected int pageindex = 1;
        protected int totalcount;
        protected string txt_depart, txt_startdate, txt_enddate;
        protected List<Depart> departlist = new List<Depart>();
        protected void Page_Load(object sender, EventArgs e)
        {
            Yannis.DAO.User user = GetUserInfo();
            pageindex = Utility.GetIntParameter("page") > 0 ? Utility.GetIntParameter("page") : 1;
            txt_depart = Utility.GetParameter("txt_depart");
            txt_startdate = Utility.GetParameter("txt_startdate");
            txt_enddate = Utility.GetParameter("txt_enddate");

            SqlQuery query = new Select().From(Depart.Schema);
            query.Where("1=1");
            ///中队长只能查看自己部门的统计数据
            if (CheckRole(user.Id, TX_Bussiness.Web.Comm.Constant.RoleCode_ZDZ))
            {
                query.And(Depart.DepartcodeColumn).IsEqualTo(user.Departcode);
            }
            if (!string.IsNullOrEmpty(txt_depart) && txt_depart != "0")
            {
                query.And(Depart.ParentcodeColumn).IsEqualTo(txt_depart);
            }
            totalcount = query.GetRecordCount();
            query.Paged(pageindex, pagesize);
            departlist = query.ExecuteTypedList<Depart>();
            string pageUrl = "/bussiness/template/depart_info.aspx?txt_depart={0}&txt_startdate={1}&txt_enddate={2}&page=__id__";
            pageUrl = string.Format(pageUrl, txt_depart, txt_startdate, txt_enddate);
            PageContent.InnerHtml = Comm.PageControl.OutPageList(this.pagesize, this.pageindex, this.totalcount, pageUrl, 8);
        }
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
    }
}