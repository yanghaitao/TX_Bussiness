using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Yannis.DAO;
using Bussiness.Common;
using SubSonic;

namespace TX_Bussiness.Web.bussiness.Template
{
    public partial class Depart_Info_Detail : Comm.BasePage
    {
        protected int pagesize = 10;
        protected int pageindex = 1;
        protected int totalcount;
        protected List<Project> project_list = new List<Project>();
        protected void Page_Load(object sender, EventArgs e)
        {
            pageindex = Utility.GetIntParameter("page") > 0 ? Utility.GetIntParameter("page") : 1;
            string id = Utility.GetParameter("id");
            string starttime = Utility.GetParameter("starttime");
            string endtime = Utility.GetParameter("endtime");
            SqlQuery query = new Select(InfoDepart.ProjcodeColumn).From(InfoDepart.Schema);
            query.Where("1=1");
            query.And(InfoDepart.DepartcodeColumn).IsEqualTo(id);
            if (!string.IsNullOrEmpty(starttime))
            {
                query.And(InfoDepart.AdddateColumn).IsGreaterThanOrEqualTo(starttime);
            }
            if (!string.IsNullOrEmpty(endtime))
            {
                query.And(InfoDepart.AdddateColumn).IsLessThanOrEqualTo(endtime);
            }
            SqlQuery projectquery = new Select().From(Project.Schema).Where(Project.ProjcodeColumn).In(query).OrderDesc(Project.Columns.Adddate);
            totalcount = projectquery.GetRecordCount();
            projectquery.Paged(pageindex, pagesize);
            project_list = projectquery.ExecuteTypedList<Project>();

            string pageUrl = "/bussiness/template/depart_info_detail.aspx?id={0}&page=__id__";
            pageUrl = string.Format(pageUrl, id);
            PageContent.InnerHtml = Comm.PageControl.OutPageList(this.pagesize, this.pageindex, this.totalcount, pageUrl, 8);
        }
    }
}