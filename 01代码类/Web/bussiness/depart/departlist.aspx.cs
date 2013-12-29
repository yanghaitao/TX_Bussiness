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

namespace TX_Bussiness.Web.bussiness.depart
{
    public partial class departlist : Comm.BasePage
    {
        protected int pagesize = int.Parse(ConfigurationManager.AppSettings["PageSize"]);
        protected int pageindex = 1;
        protected int totalcount;
        protected string txt_departname;
        protected List<Depart> depart_list = new List<Depart>();
        protected void Page_Load(object sender, EventArgs e)
        {
            pageindex = Utility.GetIntParameter("page") > 0 ? Utility.GetIntParameter("page") : 1;
            txt_departname = Utility.GetParameter("txt_departname");
            SqlQuery query = new Select().From(Depart.Schema);
            query.Where("1=1");
            if (!string.IsNullOrEmpty(txt_departname))
                query.And(Depart.DepartnameColumn).Like("%" + txt_departname + "%");
            query.And(Depart.IsdelColumn).IsNotEqualTo(true);
            totalcount = query.GetRecordCount();
            query.Paged(pageindex, pagesize);
            query.OrderDesc(Depart.AdddateColumn.ColumnName);
            depart_list = query.ExecuteTypedList<Depart>();

            string pageUrl = "/bussiness/depart/departlist.aspx?txt_departname={0}&page=__id__";
            pageUrl = string.Format(pageUrl,txt_departname);
            PageContent.InnerHtml = Comm.PageControl.OutPageList(this.pagesize, this.pageindex, this.totalcount, pageUrl, 8);
        }
    }
}