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
            SqlQuery query = new Select().From(Project.Schema);
            query.Where("1=1");
            query.And(Project.NodeidColumn).IsEqualTo(4);
            if (areatype == (int)Enums.AreaCountType.Area)
            {
                query.And(Project.AreacodeColumn).IsEqualTo(id);
            }
            if (areatype == (int)Enums.AreaCountType.Street)
            {
                query.And(Project.StreetcodeColumn).IsEqualTo(id);
            }
            if (areatype == (int)Enums.AreaCountType.Commnuity)
            {
                query.And(Project.CommunitycodeColumn).IsEqualTo(id);
            }
            if (!string.IsNullOrEmpty(starttime))
            {
                query.And(Project.AdddateColumn).IsGreaterThanOrEqualTo(starttime);
            }
            if (!string.IsNullOrEmpty(endtime))
            {
                query.And(InfoArea.AdddateColumn).IsLessThanOrEqualTo(endtime);
            }

            //SqlQuery projectquery = new Select().From(Project.Schema);
            //projectquery.Where(Project.ProjcodeColumn).In(query);
            query.OrderDesc(Project.Columns.Adddate);
            totalcount = query.GetRecordCount();
            query.Paged(pageindex, pagesize);
            project_list = query.ExecuteTypedList<Project>();
            string pageUrl = "/bussiness/template/area_info_detail.aspx?id={0}&areatype={1}&page=__id__";
            pageUrl = string.Format(pageUrl, id, areatype);
            PageContent.InnerHtml = Comm.PageControl.OutPageList(this.pagesize, this.pageindex, this.totalcount, pageUrl, 8);
        }
    }
}