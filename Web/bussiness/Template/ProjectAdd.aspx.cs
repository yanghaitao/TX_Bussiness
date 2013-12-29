﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SubSonic;
using Yannis.DAO;
using Bussiness.Common;

namespace TX_Bussiness.Web.bussiness.Template
{
    public partial class ProjectAdd : Comm.BasePage
    {
        protected Yannis.DAO.User user;
        protected void Page_Load(object sender, EventArgs e)
        {
            user = GetUserInfo();
            if (!IsPostBack && Request.HttpMethod == "POST")
            {
                string txt_name = Utility.GetParameter("txt_name");
                string txt_area = Utility.GetParameter("txt_area");
                string txt_street = Utility.GetParameter("txt_street");
                string txt_commnuity = Utility.GetParameter("txt_commnuity");
                string txt_location = Utility.GetParameter("txt_location");
                int txt_bigclass = Utility.GetIntParameter("txt_bigclass");
                int txt_smallclass = Utility.GetIntParameter("txt_smallclass");
                int txt_projecttype = Utility.GetIntParameter("txt_projecttype");
                string txt_describ = Utility.GetParameter("txt_describ");
                string txt_addrss = Utility.GetParameter("txt_address");
                Project project = new Project();
                project.Adddate = DateTime.Now;
                project.Address = txt_addrss;
                project.Areacode = txt_area;
                project.Bigclassid = txt_bigclass;
                project.Bigclassname = GetClassName(txt_bigclass.ToString());
                project.Communitycode = txt_commnuity;
                project.Describe = txt_describ;
                project.Loacation = txt_location;
                if (CheckRole(user.Id, Comm.Constant.RoleCode_JLD))
                    project.Nodeid = 1;
                else if (CheckRole(user.Id, Comm.Constant.RoleCode_ZDZ))
                    project.Nodeid = 2;
                else if (CheckRole(user.Id, Comm.Constant.RoleCode_ZFRY))
                    project.Nodeid = 3;

                project.Reportpersonid = user.Id;
                project.Reportpersonname = user.Username;
                //project.Projectname =
                project.Projectstate = 1;
                project.ProjectType = txt_projecttype;
                project.Reportpersonname = txt_name;
                project.Smallclassid = txt_smallclass;
                project.Smallclassname = GetClassName(txt_smallclass.ToString());
                project.Streetcode = txt_street;
                project.Isdel = false;
                project.Save();

                ProjectTrace projtrace = new ProjectTrace();
                if (CheckRole(user.Id, Comm.Constant.RoleCode_JLD))
                { projtrace.Actionname = "局领导案卷登记";
                  projtrace.Currentnodeid = 1;
                  projtrace.Prenodeid = 0;
                }
                else if (CheckRole(user.Id, Comm.Constant.RoleCode_ZDZ))
                { projtrace.Actionname = "中队长案卷登记";
                  projtrace.Currentnodeid = 2;
                  projtrace.Prenodeid = 0;
                }
                else if (CheckRole(user.Id, Comm.Constant.RoleCode_ZFRY))
                { projtrace.Actionname = "执法人员案卷登记";
                  projtrace.Currentnodeid = 3;
                  projtrace.Prenodeid = 0;
                }
                projtrace.Operatordate = DateTime.Now;
                projtrace.Operatordepart = user.Departcode;
                projtrace.Operatorid = user.Id;
                projtrace.Operatorname = user.Username;
                projtrace.Acceptdate = DateTime.Now;
                projtrace.Projcode = project.GetPrimaryKeyValue().ToString();
                projtrace.Save();
                WriteLog("上报案卷:案卷编号:" + project.GetPrimaryKeyValue());
                Response.Redirect("/bussiness/template/projectlist.aspx");
            }
        }
    }
}