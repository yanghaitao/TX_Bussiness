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

namespace TX_Bussiness.Web.bussiness.Template
{
    public partial class projectlist :Comm.BasePage
    {
        protected int pagesize = int.Parse(ConfigurationManager.AppSettings["PageSize"]);
        protected int pageindex = 1;
        protected int totalcount;
        protected List<Yannis.DAO.Project> project_list;
        string txt_projectcode, txt_projecttype, txt_depart, txt_dispatcher
            , txt_handler, txt_projectstate, txt_area, txt_street, txt_commnuity, txt_startdate
            , txt_enddate;
        protected void Page_Load(object sender, EventArgs e)
        {
            pageindex = Utility.GetIntParameter("page") > 0 ? Utility.GetIntParameter("page") : 1;
            txt_projectcode = Utility.GetParameter("txt_projectcode");
            txt_projecttype = Utility.GetParameter("txt_projecttype");
            txt_depart = Utility.GetParameter("txt_depart");
            txt_dispatcher = Utility.GetParameter("txt_dispatcher");
            txt_handler = Utility.GetParameter("txt_handler");
            txt_area = Utility.GetParameter("txt_area");
            txt_street = Utility.GetParameter("txt_street");
            txt_commnuity = Utility.GetParameter("txt_commnuity");
            txt_startdate = Utility.GetParameter("txt_startdate");
            txt_enddate = Utility.GetParameter("txt_enddate");
            SqlQuery query = new Select().From(Project.Schema);
            query.Where("1=1");
            if (CheckRole(GetUserInfo().Id, Comm.Constant.RoleCode_JLD))
            {
                query.And(Project.NodeidColumn).IsEqualTo(1);
                query.And(Project.ReportpersonidColumn).IsEqualTo(GetUserInfo().Id);
            }
            else if (CheckRole(GetUserInfo().Id, Comm.Constant.RoleCode_ZDZ))
            {
                query.And(Project.NodeidColumn).IsEqualTo(2);
                query.And(Project.DepartcodeColumn).IsEqualTo(GetUserInfo().Departcode);
            }
            else if (CheckRole(GetUserInfo().Id, Comm.Constant.RoleCode_ZFRY))
            {
                query.And(Project.NodeidColumn).IsEqualTo(3);
                query.And(Project.HandleridColumn).IsEqualTo(GetUserInfo().Id);
            }
            totalcount = query.GetRecordCount();
            query.Paged(pageindex,pagesize);
            query.OrderDesc(Project.AdddateColumn.ColumnName);
            project_list = query.ExecuteTypedList<Project>();
            if (!IsPostBack && Request.HttpMethod == "POST")
            {
                SqlQuery sqlquery = new Select().From(Project.Schema);
                sqlquery.Where("1=1");
                if (CheckRole(GetUserInfo().Id, Comm.Constant.RoleCode_JLD))
                {
                    query.And(Project.NodeidColumn).IsEqualTo(1);
                    query.And(Project.ReportpersonidColumn).IsEqualTo(GetUserInfo().Id);
                }
                else if (CheckRole(GetUserInfo().Id, Comm.Constant.RoleCode_ZDZ))
                {
                    query.And(Project.NodeidColumn).IsEqualTo(2);
                    query.And(Project.DepartcodeColumn).IsEqualTo(GetUserInfo().Departcode);
                }
                else if (CheckRole(GetUserInfo().Id, Comm.Constant.RoleCode_ZFRY))
                {
                    query.And(Project.NodeidColumn).IsEqualTo(3);
                    query.And(Project.HandleridColumn).IsEqualTo(GetUserInfo().Id);
                }
                if (!string.IsNullOrEmpty(txt_projectcode))
                    sqlquery.And(Project.ProjcodeColumn).IsEqualTo(txt_projectcode);
                if(!string.IsNullOrEmpty(txt_projecttype)&&txt_projecttype!="0")
                    sqlquery.And(Project.ProjectTypeColumn).IsEqualTo(txt_projecttype);
                if(!string .IsNullOrEmpty(txt_depart)&&txt_depart!="0")
                    sqlquery.And(Project.DispatchernameColumn).IsEqualTo(txt_dispatcher);
                if (!string.IsNullOrEmpty(txt_dispatcher))
                    sqlquery.And(Project.HandlernameColumn).IsEqualTo(txt_handler);
                if (!string.IsNullOrEmpty(txt_handler))
                    sqlquery.And(Project.HandlernameColumn).IsEqualTo(txt_handler);
                if (!string.IsNullOrEmpty(txt_area) && txt_area != "0")
                    sqlquery.And(Project.AreacodeColumn).IsEqualTo(txt_area);
                if (!string.IsNullOrEmpty(txt_street) && txt_street != "0")
                    sqlquery.And(Project.StreetcodeColumn).IsEqualTo(txt_street);
                if (!string.IsNullOrEmpty(txt_commnuity) && txt_commnuity != "0")
                    sqlquery.And(Project.CommunitycodeColumn).IsEqualTo(txt_commnuity);
                if (!string.IsNullOrEmpty(txt_startdate))
                    sqlquery.And(Project.StartdateColumn).IsGreaterThan(txt_startdate);
                if (!string.IsNullOrEmpty(txt_enddate))
                    sqlquery.And(Project.StartdateColumn).IsLessThan(txt_enddate);
                query.OrderDesc(Project.AdddateColumn.ColumnName);
                project_list = sqlquery.ExecuteTypedList<Project>();
            }
            string pageUrl = "/bussiness/template/projectlist.aspx?page=__id__";
            PageContent.InnerHtml = Comm.PageControl.OutPageList(this.pagesize, this.pageindex, this.totalcount, pageUrl, 8);
        }

        protected List<Depart> departlist(object departcode)
        {
           SqlQuery query = new Select().From(Depart.Schema);
           List <Depart> list= query.Where(Depart.IdColumn).IsEqualTo(departcode).ExecuteTypedList<Depart>();
           if (list != null && list.Count > 0)
               return list;
           else
               return new List<Depart>();
        
        }
    }
}