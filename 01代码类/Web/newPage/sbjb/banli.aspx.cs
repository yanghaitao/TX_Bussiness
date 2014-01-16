using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Yannis.DAO;
using SubSonic;
using Bussiness.Common;
using System.Transactions;
using TX_Bussiness.Web.Comm;

namespace TX_Bussiness.Web.newPage.sbjb
{
    public partial class banli : Comm.BasePage
    {
        string projectcode;
        protected Project model = new Project();
        Yannis.DAO.User user = new User();
        protected List<Depart> delartlist = new List<Depart>();
        protected ProjectTrace tracemodel = new ProjectTrace();
        protected void Page_Load(object sender, EventArgs e)
        {
            user = GetUserInfo();
            projectcode = Utility.GetParameter("projcode");
            if (!IsPostBack && Request.HttpMethod == "POST")
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    using (SharedDbConnectionScope scope = new SharedDbConnectionScope())
                    {
                        Project proj = Project.FetchByID(projectcode);
                        ProjectTrace protrace = new ProjectTrace();
                        #region [ 局领导操作 ]
                        if (CheckRole(user.Id, Comm.Constant.RoleCode_JLD))//局领导
                        {
                            proj.Leadmessage = Utility.GetParameter("txt_leadmessage");
                            proj.Departcode = Utility.GetParameter("txt_depart");
                            proj.Nodeid = 2;//中队长办理栏 
                            proj.Dispatcherid = user.Id;
                            proj.Dispatchername = user.Username;

                            protrace.Actionname = GetAppSeeting("LeaderActionName");//局领导操作步骤名称
                            protrace.Currentnodeid = 2;//当前节点
                            protrace.Operatordate = DateTime.Now;//操作时间
                            protrace.Operatorid = user.Id;//操作人id
                            protrace.Operatorname = user.Username;//操作人姓名
                            protrace.Operatordepart = user.Departcode;//操作人部门
                            protrace.Prenodeid = 1;//前一节点
                            protrace.Opinion = Utility.GetParameter("txt_message");//意见
                            protrace.Acceptdate = GetAcceptTime(projectcode, proj.Nodeid - 1);//受理时间
                            protrace.Projcode = proj.Projcode.ToString();//案卷编号

                        }
                        #endregion
                        #region [ 中队长操作 ]
                        else if (CheckRole(user.Id, Comm.Constant.RoleCode_ZDZ))
                        {
                            proj.Handlerid = Utility.GetIntParameter("txt_handler");
                            proj.Handlername = GetUserName(proj.Handlerid.ToString());
                            proj.Message = Utility.GetParameter("txt_message");
                            proj.Nodeid = 3;
                            proj.Projectstate = (int)Enums.ProjectType.CHULILI;

                            protrace.Actionname = GetAppSeeting("CaptainActionName");//中队长操作步骤名称
                            protrace.Currentnodeid = 3;//当前节点
                            protrace.Operatordate = DateTime.Now;//操作时间
                            protrace.Operatorid = user.Id;//操作人id
                            protrace.Operatorname = user.Username;//操作人姓名
                            protrace.Operatordepart = user.Departcode;//操作人部门
                            protrace.Prenodeid = 2;//前一节点
                            protrace.Opinion = Utility.GetParameter("txt_message");//意见
                            protrace.Acceptdate = GetAcceptTime(projectcode, proj.Nodeid - 1);//受理时间
                            protrace.Projcode = proj.Projcode.ToString();//案卷编号

                        }
                        #endregion
                        #region [ 执法人员操作 ]
                        else if (CheckRole(user.Id, Comm.Constant.RoleCode_ZFRY))
                        {
                            proj.Handlermessge = Utility.GetParameter("txt_handlemessage");
                            proj.Nodeid = 4;
                            proj.Handlerid = user.Id;
                            proj.Handlername = user.Username;
                            proj.Projectstate = (int)Enums.ProjectType.WANCHENG;

                            protrace.Actionname = GetAppSeeting("HanlderActionName");//执法人员操作步骤名称
                            protrace.Currentnodeid = 4;//当前节点
                            protrace.Operatordate = DateTime.Now;//操作时间
                            protrace.Operatorid = user.Id;//操作人id
                            protrace.Operatorname = user.Username;//操作人姓名
                            protrace.Operatordepart = user.Departcode;//操作人部门
                            protrace.Prenodeid = 3;//前一节点
                            protrace.Opinion = Utility.GetParameter("txt_message");//意见
                            protrace.Acceptdate = GetAcceptTime(projectcode, proj.Nodeid - 1);//受理时间
                            protrace.Projcode = proj.Projcode.ToString();//案卷编号
                        }
                        #endregion
                        proj.Save();
                        protrace.Save();
                        WriteLog("案卷批转 案卷编号：" + projectcode);

                        ts.Complete();
                    }
                }
                Response.Redirect("/newPage/sbjb/rwcl.aspx");
            }

            SqlQuery query = new Select().From(Project.Schema).Where(Project.ProjcodeColumn).IsEqualTo(projectcode);
            model = query.ExecuteSingle<Project>();
            tracemodel = new Select().From(ProjectTrace.Schema).Where(ProjectTrace.ProjcodeColumn).IsEqualTo(model.Projcode)
                .And(ProjectTrace.CurrentnodeidColumn).IsEqualTo(model.Nodeid).ExecuteSingle<ProjectTrace>();
            Departlist();
        }
        /// <summary>
        /// 获取可以派遣的部门
        /// </summary>
        protected new void Departlist()
        {
            if (CheckRole(user.Id, Comm.Constant.RoleCode_JLD))//局领导
            {
                delartlist = new Select().From(Depart.Schema).Where(Depart.ParentcodeColumn).IsEqualTo(user.Departcode)
                    .And(Depart.IsdelColumn).IsNotEqualTo(true).ExecuteTypedList<Depart>();
            }
        }
        /// <summary>
        /// 获取案卷流程的受理时间（即：上一步批转的时间）
        /// </summary>
        /// <param name="projcode"></param>
        /// <param name="nodeid"></param>
        /// <returns></returns>
        protected DateTime GetAcceptTime(object projcode, object nodeid)
        {
            DateTime time = new Select(ProjectTrace.OperatordateColumn).From(ProjectTrace.Schema).Where(ProjectTrace.ProjcodeColumn)
                                 .IsEqualTo(projcode).And(ProjectTrace.CurrentnodeidColumn).IsEqualTo(nodeid).ExecuteScalar<DateTime>();
            if (time != null)
                return time;
            else
                return new DateTime();
        }

    }
}