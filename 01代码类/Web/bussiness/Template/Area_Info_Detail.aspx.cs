using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SubSonic;
using Yannis.DAO;
using TX_Bussiness.Web.Comm;
using Bussiness.Common;

namespace TX_Bussiness.Web.bussiness.Template
{
    public partial class Area_Info_Detail : Comm.BasePage
    {
        protected int pagesize = 10;
        protected int pageindex = 1;
        protected int totalcount;
        protected List<Project> project_list = new List<Project>();
        protected void Page_Load(object sender, EventArgs e)
        {
            pageindex = Utility.GetIntParameter("page") > 0 ? Utility.GetIntParameter("page") : 1;
            string id = Utility.GetParameter("id");
            int areatype = Utility.GetIntParameter("areatype");
            string starttime = Utility.GetParameter("starttime");
            string endtime = Utility.GetParameter("endtime");
            SqlQuery query = new Select(InfoArea.ProjcodeColumn).From(InfoArea.Schema);
            query.Where("1=1");
            if (areatype == (int)Enums.AreaCountType.Area)
            {
                query.And(InfoArea.AreacodeColumn).IsEqualTo(id);
            }
            if (areatype == (int)Enums.AreaCountType.Street)
            {
                query.And(InfoArea.StreetcodeColumn).IsEqualTo(id);
            }
            if (areatype == (int)Enums.AreaCountType.Commnuity)
            {
                query.And(InfoArea.CommnuitycodeColumn).IsEqualTo(id);
            }
            if (!string.IsNullOrEmpty(starttime))
            {
                query.And(InfoArea.AdddateColumn).IsGreaterThanOrEqualTo(starttime);
            }
            if (!string.IsNullOrEmpty(endtime))
            {
                query.And(InfoArea.AdddateColumn).IsLessThanOrEqualTo(endtime);
            }
            SqlQuery projectquery = new Select().From(Project.Schema).Where(Project.ProjcodeColumn).In(query);
            totalcount = projectquery.GetRecordCount();
            projectquery.Paged(pageindex, pagesize);
            project_list = projectquery.ExecuteTypedList<Project>();
            string pageUrl = "/bussiness/template/area_info_detail.aspx?id={0}&areatype={1}&page=__id__";
            pageUrl = string.Format(pageUrl, id, areatype);
            PageContent.InnerHtml = Comm.PageControl.OutPageList(this.pagesize, this.pageindex, this.totalcount, pageUrl, 8);
        }
    }
}