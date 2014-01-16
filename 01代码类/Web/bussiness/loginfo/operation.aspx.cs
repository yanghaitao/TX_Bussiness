using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SubSonic;
using System.Configuration;
using Bussiness.Common;
using Yannis.DAO;

namespace TX_Bussiness.Web.bussiness.loginfo
{
    public partial class operation : System.Web.UI.Page
    {
        protected int pagesize = 15;
        protected int pageindex = 1;
        protected int totalcount;
        protected List<SysLog> loglist = new List<SysLog>();
        protected void Page_Load(object sender, EventArgs e)
        {
            pageindex = Utility.GetIntParameter("page") > 0 ? Utility.GetIntParameter("page") : 1;

            SqlQuery query = new Select().From(Yannis.DAO.SysLog.Schema);
            query.Where("1=1");
            totalcount = query.GetRecordCount();
            query.Paged(pageindex, pagesize);
            query.OrderDesc(SysLog.Columns.CuDate);
            loglist = query.ExecuteTypedList<SysLog>();

            string pageUrl = "/bussiness/loginfo/operation.aspx?page=__id__";
            PageContent.InnerHtml = Comm.PageControl.OutPageList(this.pagesize, this.pageindex, this.totalcount, pageUrl, 8);
        }
    }
}