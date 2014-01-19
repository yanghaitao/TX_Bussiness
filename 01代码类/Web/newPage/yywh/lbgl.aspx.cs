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

namespace TX_Bussiness.Web.newPage.yywh
{
    public partial class lbgl : Comm.BasePage
    {
        protected int pagesize = int.Parse(ConfigurationManager.AppSettings["PageSize"]);
        protected int pageindex = 1;
        protected int totalcount;
        protected string txt_classcode, txt_bigclass;
        protected string txt_classname;
        protected List<Projectclass> projectlist = new List<Projectclass>();
        protected void Page_Load(object sender, EventArgs e)
        {
            pageindex = Utility.GetIntParameter("page") > 0 ? Utility.GetIntParameter("page") : 1;
            txt_classname = Utility.GetParameter("txt_classname");
            txt_classcode = Utility.GetParameter("txt_classcode");
            txt_bigclass = Utility.GetParameter("txt_bigclass");
            SqlQuery query = new Select().From(Projectclass.Schema);
            query.Where("1=1");
            if (!string.IsNullOrEmpty(txt_classname))
                query.And(Projectclass.ClassnameColumn).Like("%" + txt_classname + "%");
            if (!string.IsNullOrEmpty(txt_classcode) && txt_classcode != "0")
            {
                if (!string.IsNullOrEmpty(txt_bigclass) && txt_bigclass != "0")
                {
                    query.And(Projectclass.ParentidColumn).IsEqualTo(txt_bigclass);
                }
                else
                {
                    query.And(Projectclass.ParentidColumn).IsEqualTo(txt_classcode);
                }
            }
            query.And(Projectclass.IsdelColumn).IsNotEqualTo(true);
            totalcount = query.GetRecordCount();
            query.Paged(pageindex, pagesize);
            query.OrderDesc(Projectclass.IdColumn.ColumnName);
            projectlist = query.ExecuteTypedList<Projectclass>();

            string pageUrl = "/newPage/yywh/lbedit.aspx?txt_classname={0}&txt_classcode={1}&txt_bigclass={2}&page=__id__";
            pageUrl = string.Format(pageUrl, txt_classname, txt_classcode, txt_bigclass);
            PageContent.InnerHtml = Comm.PageControl.OutPageList(this.pagesize, this.pageindex, this.totalcount, pageUrl, 8);

        }
    }
}