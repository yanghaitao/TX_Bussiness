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

namespace TX_Bussiness.Web.bussiness.Template
{
    public partial class Person_Detail : Comm.BasePage
    {
        protected int pagesize = int.Parse(ConfigurationManager.AppSettings["PageSize"]);
        protected int pageindex = 1;
        protected int totalcount;
        protected List<Yannis.DAO.Project> project_list;
        protected void Page_Load(object sender, EventArgs e)
        {
            pageindex = Utility.GetIntParameter("page") > 0 ? Utility.GetIntParameter("page") : 1;
            SqlQuery query = new Select().From(Project.Schema);
            query.Where("1=1");
            query.And(Project.ReportpersonidColumn).IsEqualTo(GetUserInfo().Id);
            totalcount = query.GetRecordCount();
            query.Paged(pageindex, pagesize);
            query.OrderDesc(Project.AdddateColumn.ColumnName);
            project_list = query.ExecuteTypedList<Project>();
            string pageUrl = "/bussiness/template/projectlist.aspx?page=__id__";
            PageContent.InnerHtml = Comm.PageControl.OutPageList(this.pagesize, this.pageindex, this.totalcount, pageUrl, 8);
        }
    }
}