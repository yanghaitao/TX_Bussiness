using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Yannis.DAO;
using SubSonic;
using Bussiness.Common;

namespace TX_Bussiness.Web.newPage.yywh
{
    public partial class jsedit : Comm.BasePage
    {
        protected Role model = new Role();
        protected void Page_Load(object sender, EventArgs e)
        {
            string id = Utility.GetParameter("id");
            string action = Utility.GetParameter("action");
            if (action == "edit")
            {
                model = Role.FetchByID(id);
            }
            if (!IsPostBack && Request.HttpMethod == "POST")
            {
                if (id == "0")
                {
                    model = new Role();
                    model.IsNew = true;
                    model.Limitid = Utility.GetParameter("limitids").Trim(',');
                    model.Rolename = Utility.GetParameter("txt_rolename");

                }
                else
                {
                    model = Role.FetchByID(id);
                    model.IsNew = false;
                    model.Rolename = Utility.GetParameter("txt_rolename");
                    model.Limitid = Utility.GetParameter("limitids").Trim(',');

                }
                model.Save();
                if (id == "0")
                    WriteLog("添加角色信息:角色名称:" + model.Rolename);
                else
                    WriteLog("修改部门信息:部门id:" + id);
                Response.Redirect("/newPage/yywh/jsgl.aspx");
            }
        }
    }
}