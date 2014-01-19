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
    public partial class bmedit : Comm.BasePage
    {
        protected Depart model = new Depart();
        protected void Page_Load(object sender, EventArgs e)
        {
            string id = Utility.GetParameter("id");
            string action = Utility.GetParameter("action");
            if (action == "edit")
            {
                model = Depart.FetchByID(id);
            }
            if (!IsPostBack && Request.HttpMethod == "POST")
            {
                if (id == "0")
                {
                    #region [ 新增 ]
                    model = new Depart();
                    model.IsNew = true;
                    model.Adddate = DateTime.Now;
                    model.Areacode = Utility.GetIntParameter("txt_departarea");
                    model.Departmobile = Utility.GetParameter("txt_departmobile");
                    model.Departname = Utility.GetParameter("txt_departname");
                    model.Departstate = Utility.GetIntParameter("txt_departstate");
                    model.Departtel = Utility.GetParameter("txt_departtel");
                    model.Isacceptmessage = Utility.GetIntParameter("isacceptmessage");
                    model.Mark = Utility.GetParameter("txt_message");
                    model.Parentcode = Utility.GetParameter("txt_parentdepart");
                    model.Rolecode = Utility.GetParameter("txt_rolecode");
                    model.Isdel = false;
                    #endregion
                }
                else
                {
                    #region [ 修改 ]
                    model = Depart.FetchByID(id);
                    model.IsNew = false;
                    model.Areacode = Utility.GetIntParameter("txt_departarea");
                    model.Departmobile = Utility.GetParameter("txt_departmobile");
                    model.Departname = Utility.GetParameter("txt_departname");
                    model.Departstate = Utility.GetIntParameter("txt_departstate");
                    model.Departtel = Utility.GetParameter("txt_departtel");
                    model.Isacceptmessage = Utility.GetIntParameter("isacceptmessage");
                    model.Mark = Utility.GetParameter("txt_message");
                    model.Parentcode = Utility.GetParameter("txt_parentdepart");
                    model.Rolecode = Utility.GetParameter("txt_rolecode");
                    #endregion
                }
                model.Save();
                if (id == "0")
                    WriteLog("添加部门信息:部门名称:" + model.Departname);
                else
                    WriteLog("修改部门信息:部门id:" + id);
                Response.Redirect("/newPage/yywh/bmgl.aspx");
            }
        }


    }
}