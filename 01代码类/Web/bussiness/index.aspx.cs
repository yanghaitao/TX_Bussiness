using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Yannis.DAO;
using SubSonic;
using Bussiness.Common;
using TX_Bussiness.Web.Comm;

namespace TX_Bussiness.Web.bussiness
{
    public partial class index : Comm.BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string action = Utility.GetParameter("action");
            if (action == "exit")
            {
                WriteLog("退出登陆");
                //清险Session
                HttpContext.Current.Session[Comm.Constant.SESSION_USER_INFO] = null;
                //清除Cookies
                Utility.WriteCookie(Comm.Constant.COOKIE_USER_NAME_REMEMBER, "TX_SZCG", -43200);
                Utility.WriteCookie(Comm.Constant.COOKIE_USER_PWD_REMEMBER, "TX_SZCG", -43200);
                Utility.WriteCookie("UserName", "TX_SZCG", -1);
                Utility.WriteCookie("Password", "TX_SZCG", -1);
              
                //自动登录,跳转URL
                HttpContext.Current.Response.Redirect("/login2/login.aspx");
            }
        }
    }
}