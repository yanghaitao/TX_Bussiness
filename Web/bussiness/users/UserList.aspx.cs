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
using TX_Bussiness.Web.Comm;

namespace TX_Bussiness.Web.bussiness.users
{
    public partial class UserList : Comm.BasePage
    {
       
        protected int pagesize = int.Parse(ConfigurationManager.AppSettings["PageSize"]);
        protected int pageindex = 1;
        protected int totalcount;
        protected List<User> userlist = new List<User>();
        protected string txt_username, txt_usertype, txt_depart;
        protected void Page_Load(object sender, EventArgs e)
        {
            pageindex = Utility.GetIntParameter("page") > 0 ? Utility.GetIntParameter("page") : 1;
            txt_username = Utility.GetParameter("txt_username");
            txt_usertype = Utility.GetParameter("txt_usertype");
            txt_depart = Utility.GetParameter("txt_depart");
            SqlQuery query = new Select().From(Yannis.DAO.User.Schema);
            query.Where("1=1");
            if (!string.IsNullOrEmpty(txt_username))
                query.And(Yannis.DAO.User.UsernameColumn).Like("%"+txt_username+"%");
            if (!string.IsNullOrEmpty(txt_usertype) && txt_usertype != "0")
                query.And(Yannis.DAO.User.UsertypeColumn).IsEqualTo(txt_usertype);
            if (!string.IsNullOrEmpty(txt_depart)&&txt_depart!="0")
                query.And(Yannis.DAO.User.DepartcodeColumn).IsEqualTo(txt_depart);
            query.And(Yannis.DAO.User.IsdelColumn).IsNotEqualTo(true);
            totalcount = query.GetRecordCount();
            query.Paged(pageindex, pagesize);
            query.OrderDesc(Yannis.DAO.User.AdddateColumn.ColumnName);
            userlist = query.ExecuteTypedList<User>();

            string pageUrl = "/bussiness/users/userlist.aspx?txt_username={0}&txt_usertype={1}&txt_depart={2}&page=__id__";
            pageUrl = string.Format(pageUrl, txt_username, txt_usertype, txt_depart);
            PageContent.InnerHtml = Comm.PageControl.OutPageList(this.pagesize, this.pageindex, this.totalcount, pageUrl, 8);
        }
        public string GetUserState(object state)
        {
            if (int.Parse(state.ToString()) == Convert.ToInt32(Enums.AccountState.Normal))
                return "正常";
            if (int.Parse(state.ToString()) == Convert.ToInt32(Enums.AccountState.Enable))
                return "可用";
            if (int.Parse(state.ToString()) == Convert.ToInt32(Enums.AccountState.Disable))
                return "不可用";
            if (int.Parse(state.ToString()) == Convert.ToInt32(Enums.AccountState.Delete))
                return "已删除";
            return "未知";
        }
        public string GetUserType(object usertype)
        {
            if (int.Parse(usertype.ToString()) == Convert.ToInt32(Enums.UserType.Normal))
                return "普通用户";
            if (int.Parse(usertype.ToString()) == Convert.ToInt32(Enums.UserType.Mobile))
                return "城管通";
            return "未知";
        }
    }
}