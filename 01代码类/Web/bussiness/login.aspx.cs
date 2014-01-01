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
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack && Request.HttpMethod == "POST")
            {
                string username = Utility.GetParameter("username");
                string password = Utility.GetParameter("password");

                SqlQuery query = new Select().From(Yannis.DAO.User.Schema).Where(Yannis.DAO.User.LoginnameColumn).IsEqualTo(username)
                    .And(Yannis.DAO.User.PasswordColumn).IsEqualTo(password);
                Yannis.DAO.User model = query.ExecuteSingle<Yannis.DAO.User>();
                if (model != null)
                {
                    Session[Comm.Constant.SESSION_USER_INFO] = model;
                    Session.Timeout = 45;

                    Utility.WriteCookie(Comm.Constant.COOKIE_USER_NAME_REMEMBER, "TX_SZCG", model.Loginname, 43200);
                    Utility.WriteCookie(Comm.Constant.COOKIE_USER_PWD_REMEMBER, "TX_SZCG", model.Password, 43200);
                    new SysLog()
                    {
                        Actionname = "登陆系统",
                        CuDate = DateTime.Now,
                        Ip = Utility.GetIP(),
                        Loginname = model.Loginname,
                        Userid = model.Id
                    }.Save();
                    Response.Redirect("/bussiness/index.aspx");

                }
                else
                {
                    RegisterClientScriptBlock("", "<script>alert('用户名或密码错误！')</script>");
                }
            }
        }
    }
}