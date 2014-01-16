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
    public partial class rydw : Comm.BasePage
    {
        protected int pagesize = int.Parse(ConfigurationManager.AppSettings["PageSize"]);
        protected int pageindex = 1;
        protected int totalcount;
        public List<Yannis.DAO.User> user_list;
        //protected string txt_projectcode, txt_projectstate, txt_depart, txt_area, txt_street, txt_commnuity, txt_startdate
        //    , txt_enddate;
        protected string txt_usercode,txt_username,txt_departId;
        protected void Page_Load(object sender, EventArgs e)
        {
            #region[ 获取参数列表 ]
            pageindex = Utility.GetIntParameter("page") > 0 ? Utility.GetIntParameter("page") : 1;
            txt_usercode = Utility.GetParameter("txt_usercode");
            txt_username = Utility.GetParameter("txt_username");
            txt_departId=Utility.GetParameter("txt_departId");
            #endregion
            SqlQuery query = new Select().From(Yannis.DAO.User.Schema);
            query.Where("1=1");
            #region[ 组合查询条件 ]
            if (CheckRole(GetUserInfo().Id, Comm.Constant.RoleCode_JLD))
            {
                query.And(Yannis.DAO.User.IsdelColumn).IsEqualTo(0);
                query.And(Yannis.DAO.User.UsertypeColumn).IsEqualTo(2);
            }
            else if (CheckRole(GetUserInfo().Id, Comm.Constant.RoleCode_ZDZ))
            {
                query.And(Yannis.DAO.User.IsdelColumn).IsEqualTo(0);
                query.And(Yannis.DAO.User.UsertypeColumn).IsEqualTo(2);
                query.And(Yannis.DAO.User.DepartcodeColumn).IsEqualTo(GetUserInfo().Departcode);
            }
           
            if (!string.IsNullOrEmpty(txt_usercode))
                query.And(Yannis.DAO.User.IdColumn).IsEqualTo(txt_usercode);
            //if (!string.IsNullOrEmpty(txt_projectstate) && txt_projectstate != "0")
            //    query.And(Project.ProjectstateColumn).IsEqualTo(txt_projectstate);
            //if (!string.IsNullOrEmpty(txt_depart) && txt_depart != "0")
            //    query.And(Project.DepartcodeColumn).IsEqualTo(txt_depart);
            //if (!string.IsNullOrEmpty(txt_area) && txt_area != "0")
            //    query.And(Project.AreacodeColumn).IsEqualTo(txt_area);
            //if (!string.IsNullOrEmpty(txt_street) && txt_street != "0")
            //    query.And(Project.StreetcodeColumn).IsEqualTo(txt_street);
            //if (!string.IsNullOrEmpty(txt_commnuity) && txt_commnuity != "0")
            //    query.And(Project.CommunitycodeColumn).IsEqualTo(txt_commnuity);
            if (!string.IsNullOrEmpty(txt_username))
                query.And(Yannis.DAO.User.UsernameColumn).IsEqualTo(txt_username);
            if (!string.IsNullOrEmpty(txt_departId)&&txt_departId!="0")
                query.And(Yannis.DAO.User.DepartcodeColumn).IsEqualTo(txt_departId);
            #endregion
            totalcount = query.GetRecordCount();
            query.Paged(pageindex,pagesize);
            query.OrderDesc(Yannis.DAO.User.UseridColumn.ColumnName);
            user_list = query.ExecuteTypedList<Yannis.DAO.User>();
            string pageUrl = "/bussiness/template/rydw.aspx?txt_usercode={0}&txt_username={1}&txt_departId={2}&page=__id__";
            pageUrl = string.Format(pageUrl, txt_usercode, txt_username, txt_departId);
            PageContent.InnerHtml = Comm.PageControl.OutPageList(this.pagesize, this.pageindex, this.totalcount, pageUrl, 8);
        }
    }
    
}