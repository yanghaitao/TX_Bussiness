using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SubSonic;
using Yannis.DAO;
using Bussiness.Common;

namespace TX_Bussiness.Web.bussiness.p_class
{
    public partial class classedit : Comm.BasePage
    {
        protected Projectclass model = new Projectclass();
        protected void Page_Load(object sender, EventArgs e)
        {
            int id = Utility.GetIntParameter("id");
            string action = Utility.GetParameter("action");
            if (action == "edit")
            {
                model = Projectclass.FetchByID(id);
            }
            if (!IsPostBack && Request.HttpMethod == "POST")
            {
                if (id > 0)
                {
                    model = Projectclass.FetchByID(id);
                    model.IsNew = false;
                    model.Classname = Utility.GetParameter("txt_classname");
                    model.Parentid = string.IsNullOrEmpty(Utility.GetParameter("txt_parentid")) ? "0" : Utility.GetParameter("txt_parentid");
                    model.Classtype = Utility.GetParameter("txt_parentid") == "0" ? 1 : 0;

                }
                else
                {
                    model = new Projectclass();
                    model.IsNew = true;
                    model.Classname = Utility.GetParameter("txt_classname");
                    model.Parentid = string.IsNullOrEmpty(Utility.GetParameter("txt_parentid")) ? "0" : Utility.GetParameter("txt_parentid");
                    model.Classtype = Utility.GetParameter("txt_parentid") == "0" ? 1 : 0;
                    model.Isdel = false;
                }
                model.Save();
                if (id > 0)
                    WriteLog("修改类别信息:类别id:" + id);
                else
                    WriteLog("添加部门信息:部门名称:" + model.Classname);
                Response.Redirect("/bussiness/p_class/classlist.aspx");
            }
        }
    }
}