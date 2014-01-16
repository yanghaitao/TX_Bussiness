using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SubSonic;
using Yannis.DAO;
using Bussiness.Common;
using System.Transactions;
using TX_Bussiness.Web.Comm;

namespace TX_Bussiness.Web.bussiness.Template
{
    public partial class ProjectAdd : Comm.BasePage
    {
        protected Yannis.DAO.User user;
        protected string projectcode;
        protected void Page_Load(object sender, EventArgs e)
        {
            user = GetUserInfo();
            if (!IsPostBack && Request.HttpMethod == "POST")
            {
                #region[ 获取参数列表 ]
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
                string projectimgs = Utility.GetParameter("fileimgs");
                int txt_baseclass = Utility.GetIntParameter("txt_baseclass");
                #endregion
                using (TransactionScope ts = new TransactionScope())
                {
                    using (SharedDbConnectionScope scope = new SharedDbConnectionScope())
                    {
                        #region [ 保存案卷详细 ]
                        Project project = new Project();
                        project.Adddate = DateTime.Now;
                        project.Address = txt_addrss;
                        project.Areacode = txt_area;
                        project.Baseclassid = txt_baseclass;
                        project.Baseclassname = GetClassName(txt_baseclass.ToString());
                        project.Bigclassid = txt_bigclass;
                        project.Bigclassname = GetClassName(txt_bigclass.ToString());
                        project.Communitycode = txt_commnuity;
                        project.Describe = txt_describ;
                        project.Loacation = txt_location;
                        if (CheckRole(user.Id, Comm.Constant.RoleCode_JLD))
                        {
                            project.Nodeid = 1;
                            project.Projectstate = (int)Enums.ProjectType.JIAOBAN;
                        }
                        else if (CheckRole(user.Id, Comm.Constant.RoleCode_ZDZ))
                        {
                            project.Nodeid = 2;
                            project.Departcode = user.Departcode.ToString();
                            project.Projectstate = (int)Enums.ProjectType.JIAOBAN;
                        }
                        else if (CheckRole(user.Id, Comm.Constant.RoleCode_ZFRY))
                        {
                            project.Nodeid = 3;
                            project.Handlerid = user.Id;
                            project.Handlername = user.Username;
                            project.Projectstate = (int)Enums.ProjectType.CHULILI;
                        }
                        project.Reportpersonid = user.Id;
                        project.Reportpersonname = user.Username;
                        project.ProjectType = txt_projecttype;
                        project.Reportpersonname = txt_name;
                        project.Smallclassid = txt_smallclass;
                        project.Smallclassname = GetClassName(txt_smallclass.ToString());
                        project.Streetcode = txt_street;
                        project.Isdel = false;
                        project.Save();
                        projectcode = project.GetPrimaryKeyValue().ToString();
                        #endregion
                        #region [ 保存案卷流程 ]
                        ProjectTrace projtrace = new ProjectTrace();
                        if (CheckRole(user.Id, Comm.Constant.RoleCode_JLD))
                        {
                            projtrace.Actionname = "局领导案卷登记";
                            projtrace.Currentnodeid = 1;
                            projtrace.Prenodeid = 0;
                        }
                        else if (CheckRole(user.Id, Comm.Constant.RoleCode_ZDZ))
                        {
                            projtrace.Actionname = "中队长案卷登记";
                            projtrace.Currentnodeid = 2;
                            projtrace.Prenodeid = 0;
                        }
                        else if (CheckRole(user.Id, Comm.Constant.RoleCode_ZFRY))
                        {
                            projtrace.Actionname = "执法人员案卷登记";
                            projtrace.Currentnodeid = 3;
                            projtrace.Prenodeid = 0;
                        }
                        projtrace.Operatordate = DateTime.Now;
                        projtrace.Operatordepart = user.Departcode;
                        projtrace.Operatorid = user.Id;
                        projtrace.Operatorname = user.Username;
                        projtrace.Acceptdate = DateTime.Now;
                        projtrace.Projcode = projectcode;
                        projtrace.Save();
                        #endregion
                        #region[ 记录统计信息 ]
                        new InfoArea
                         {
                             Adddate = DateTime.Now,
                             Areacode = txt_area,
                             Areaname = GetAreaName(txt_area),
                             Commnuitycode = txt_commnuity,
                             Commnuityname = GetCommName(txt_commnuity),
                             Projcode = projectcode,
                             Streetcode = txt_street,
                             Streetname = GetStreetName(txt_street)
                         }.Save();

                        new InfoCollector
                       {
                           Adddate = DateTime.Now,
                           Departcode = user.Departcode,
                           Collectorid = user.Id,
                           Collectorname = user.Username,
                           Projcode = projectcode
                       }.Save();

                        new InfoDepart
                       {
                           Adddate = DateTime.Now,
                           Departcode = user.Departcode.ToString(),
                           Projcode = projectcode,
                           Departname = GetDepartName(user.Departcode.ToString())
                       }.Save();

                        new InfoClass
                        {
                            Adddate = DateTime.Now,
                            Bigclasscode = txt_bigclass.ToString(),
                            Bigclassname = GetClassName(txt_bigclass.ToString()),
                            Projectcode = projectcode,
                            Smallclassanme = GetClassName(txt_smallclass.ToString()),
                            Smallclasscode = txt_smallclass.ToString(),
                            Baseclasscode = txt_baseclass.ToString(),
                            Baseclassname = GetClassName(txt_baseclass.ToString())
                        }.Save();

                        #endregion
                        #region [ 上传图片 ]
                        if (!string.IsNullOrEmpty(projectimgs))
                        {
                            string[] imgs = projectimgs.TrimEnd(',').Split(',');
                            for (int i = 0; i < imgs.Length; i++)
                            {
                                Projectimg pimg = new Projectimg
                                {
                                    Imgtype = (int)TX_Bussiness.Web.Comm.Enums.ProjectImgType.Before,
                                    Imgurl = imgs[i],
                                    Projcode = projectcode,
                                    Adddate = DateTime.Now
                                };
                                pimg.Save();
                            }
                        }
                        #endregion
                        ts.Complete();
                    }
                }
                WriteLog("上报案卷:案卷编号:" + projectcode);
                Response.Redirect("/bussiness/template/projectlist.aspx");
            }
        }
    }
}