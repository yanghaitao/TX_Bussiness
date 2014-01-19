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
    public partial class qyQuery : Comm.BasePage
    {
        protected int pagesize = int.Parse(ConfigurationManager.AppSettings["PageSize"]);
        protected int pageindex = 1;
        protected int totalcount;
        protected List<Yannis.DAO.Project> project_list;
        protected List<Yannis.DAO.ProjectTrace> project_trace;
        protected Yannis.DAO.User user;
        protected string dname = "";
        //   protected List<Yannis.DAO.User> user_list;
        protected string txt_area, txt_street, txt_commnuity, txt_startdate
            , txt_enddate;
        protected void Page_Load(object sender, EventArgs e)
        {
             #region[ 获取参数列表 ]
            pageindex = Utility.GetIntParameter("page") > 0 ? Utility.GetIntParameter("page") : 1;
            txt_area = Utility.GetParameter("txt_area");
            txt_street = Utility.GetParameter("txt_street");
            txt_commnuity = Utility.GetParameter("txt_commnuity");
            txt_startdate = Utility.GetParameter("txt_startdate");
            txt_enddate = Utility.GetParameter("txt_enddate");
            #endregion
            SqlQuery query = new Select().From(Project.Schema);
            query.Where("1=1");
            #region[ 组合查询条件 ]
            
            
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
            query.Paged(pageindex,pagesize);
            query.OrderDesc(Project.AdddateColumn.ColumnName);
            project_list = query.ExecuteTypedList<Project>();
            string pageUrl = "/newPage/sbjb/qyQuery.aspx?txt_area={0}&txt_street={1}&txt_commnuity={2}&txt_startdate={3}&txt_enddate={4}&page=__id__";
            pageUrl = string.Format(pageUrl,txt_area, txt_street, txt_commnuity, txt_startdate, txt_enddate);
            PageContent.InnerHtml = Comm.PageControl.OutPageList(this.pagesize, this.pageindex, this.totalcount, pageUrl, 8);
            
        }
    }
}