using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SubSonic;
using Yannis.DAO;
using Bussiness.Common;
using System.Configuration;

namespace TX_Bussiness.Web.bussiness.p_class
{
    public partial class classlist : Comm.BasePage
    {
        protected int pagesize = int.Parse(ConfigurationManager.AppSettings["PageSize"]);
        protected int pageindex = 1;
        protected int totalcount;
        protected string txt_parentid;
        protected string txt_classname;
        protected List<Projectclass> projectlist = new List<Projectclass>();
        protected void Page_Load(object sender, EventArgs e)
        {
            pageindex = Utility.GetIntParameter("page") > 0 ? Utility.GetIntParameter("page") : 1;
            txt_classname = Utility.GetParameter("txt_classname");
            txt_parentid = Utility.GetParameter("txt_parentid");
            SqlQuery query = new Select().From(Projectclass.Schema);
            query.Where("1=1");
            if(!string.IsNullOrEmpty(txt_classname))
            query.And(Projectclass.ClassnameColumn).Like("%"+txt_classname+"%");
            if (!string.IsNullOrEmpty(txt_parentid) && txt_parentid != "0")
                query.And(Projectclass.ParentidColumn).IsEqualTo(txt_parentid);
            query.And(Projectclass.IsdelColumn).IsNotEqualTo(true);
            totalcount = query.GetRecordCount();
            query.Paged(pageindex,pagesize);
            query.OrderDesc(Projectclass.IdColumn.ColumnName);
            projectlist = query.ExecuteTypedList<Projectclass>();

            string pageUrl = "/bussiness/p_class/classlist.aspx?txt_classname={0}&txt+parentid={1}&page=__id__";
            pageUrl = string.Format(pageUrl, txt_classname, txt_parentid);
            PageContent.InnerHtml = Comm.PageControl.OutPageList(this.pagesize, this.pageindex, this.totalcount, pageUrl, 8);

        }
    }
}