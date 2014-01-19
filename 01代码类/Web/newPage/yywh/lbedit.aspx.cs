using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SubSonic;
using Yannis.DAO;
using Bussiness.Common;

namespace TX_Bussiness.Web.newPage.yywh
{
    public partial class lbedit : Comm.BasePage
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
                    #region [ 修改 ]
                    model = Projectclass.FetchByID(id);
                    model.IsNew = false;
                    model.Classname = Utility.GetParameter("txt_classname");
                    if (Utility.GetParameter("txt_classcode") == "0")
                    {
                        model.Parentid = "0";
                        model.Classtype = 0;
                    }
                    else
                    {
                        if (Utility.GetParameter("txt_bigclass") == "0")
                        {
                            model.Parentid = Utility.GetParameter("txt_classcode");
                            model.Classtype = 1;
                        }
                        else
                        {
                            model.Parentid = Utility.GetParameter("txt_bigclass");
                            model.Classtype = 2;
                        }
                    }
                    #endregion
                }
                else
                {
                    #region [ 新增 ]
                    model = new Projectclass();
                    model.IsNew = true;
                    model.Classname = Utility.GetParameter("txt_classname");
                    if (Utility.GetParameter("txt_classcode") == "0")
                    {
                        model.Parentid = "0";
                        model.Classtype = 0;
                    }
                    else
                    {
                        if (Utility.GetParameter("txt_bigclass") == "0")
                        {
                            model.Parentid = Utility.GetParameter("txt_classcode");
                            model.Classtype = 1;
                        }
                        else
                        {
                            model.Parentid = Utility.GetParameter("txt_bigclass");
                            model.Classtype = 2;
                        }
                    }
                    model.Isdel = false;
                    #endregion
                }
                model.Save();
                if (id > 0)
                    WriteLog("修改类别信息:类别id:" + id);
                else
                    WriteLog("添加部门信息:部门名称:" + model.Classname);
                Response.Redirect("/newPage/yywh/lbgl.aspx");
            }
        }
    }
}