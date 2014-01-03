using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Bussiness.Common;
using Yannis.DAO;
using SubSonic;
using TX_Bussiness.Web.Comm;

namespace TX_Bussiness.Web.bussiness.users
{
    public partial class UserEdit : Comm.BasePage
    {
        protected User model = new User();
        protected void Page_Load(object sender, EventArgs e)
        {
            string action = Utility.GetParameter("action");
            string id = Utility.GetParameter("id");
            if (action == "edit")
            {
                model = Yannis.DAO.User.FetchByID(id);
            }
            if (!IsPostBack && Request.HttpMethod == "POST")
            {
                if (id == "0")
                {
                    #region [ 新增 ]
                    model = new Yannis.DAO.User();
                    model.IsNew = true;
                    model.Accountdtate = Convert.ToInt32(Enums.AccountState.Normal);
                    model.Adddate = DateTime.Now;
                    model.Collectorareacode = Utility.GetParameter("txt_area");
                    model.Collectorgpsstate = 0;
                    model.Communitycode = Utility.GetParameter("txt_commnuity");
                    model.Departcode = Convert.ToInt32(Utility.GetParameter("txt_depart"));
                    model.Loginname = Utility.GetParameter("txt_username");
                    model.Loginstate = 0;
                    model.Password = Utility.GetParameter("txt_password");
                    model.Streetcode = Utility.GetParameter("txt_street");
                    model.Useremail = Utility.GetParameter("txt_email");
                    model.Usermobile = Utility.GetParameter("txt_mobile");
                    model.Username = Utility.GetParameter("txt_name");
                    model.Usertel = Utility.GetParameter("txt_tel");
                    model.Usertype = int.Parse(Utility.GetParameter("txt_ismobile"));
                    model.Roleid = Utility.GetIntParameter("txt_rolecode");
                    model.Isdel = false;
                    #endregion
                }
                else
                {
                    #region [ 修改 ] 
                    model = Yannis.DAO.User.FetchByID(id);
                    model.IsNew = false;
                    model.Collectorareacode = Utility.GetParameter("txt_area");
                    model.Communitycode = Utility.GetParameter("txt_commnuity");
                    model.Departcode = Convert.ToInt32(Utility.GetParameter("txt_depart"));
                    model.Loginname = Utility.GetParameter("txt_username");
                    model.Password = Utility.GetParameter("txt_password");
                    model.Streetcode = Utility.GetParameter("txt_street");
                    model.Useremail = Utility.GetParameter("txt_email");
                    model.Usermobile = Utility.GetParameter("txt_mobile");
                    model.Username = Utility.GetParameter("txt_name");
                    model.Usertel = Utility.GetParameter("txt_tel");
                    model.Usertype = int.Parse(Utility.GetParameter("txt_ismobile"));
                    model.Roleid = Utility.GetIntParameter("txt_rolecode");
                    #endregion
                }
                model.Save();
                if (id == "0")
                    WriteLog("添加用户 登录名:" + model.Loginname);
                else
                    WriteLog("修改用户信息:用户id:" + id);
                Response.Redirect("/bussiness/users/userlist.aspx");
            }
        }

    }
}