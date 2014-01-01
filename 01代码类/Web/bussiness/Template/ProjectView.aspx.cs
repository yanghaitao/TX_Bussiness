using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Yannis.DAO;
using SubSonic;
using Bussiness.Common;

namespace TX_Bussiness.Web.bussiness.Template
{
    public partial class ProjectView : Comm.BasePage
    {
        protected string projcode;
        protected List<ProjectTrace> tracelist;
        protected Project model;
        protected void Page_Load(object sender, EventArgs e)
        {
            projcode = Utility.GetParameter("projcode");
            model = new Select().From(Project.Schema).Where(Project.ProjcodeColumn).IsEqualTo(projcode).ExecuteSingle<Project>();
            SqlQuery query = new Select().From(ProjectTrace.Schema);
            query.Where("1=1");
            query.Where(ProjectTrace.ProjcodeColumn).IsEqualTo(projcode);
            tracelist = query.ExecuteTypedList<ProjectTrace>();
        }
        /// <summary>
        /// 获取当前操作阶段名称
        /// </summary>
        /// <param name="nodeid"></param>
        /// <returns></returns>
        protected string GetStepName(int projectstate)
        {
            if (projectstate ==1)
                return "交办阶段";
            if (projectstate ==2)
                return "处理阶段";
            if (projectstate ==3)
                return "完成阶段";
            return string.Empty;
        }

        /// <summary>
        /// 获取局属部门
        /// </summary>
        /// <param name="reportid">案卷上报人id</param>
        /// <returns></returns>
        protected string GetDepart(int reportid)
        {
            SqlQuery query = new Select(Depart.DepartnameColumn).From(Depart.Schema).LeftOuterJoin(Yannis.DAO.User.DepartcodeColumn, Depart.IdColumn);
            query.Where(Yannis.DAO.User.IdColumn).IsEqualTo(reportid);
            string departname = query.ExecuteScalar<string>();
            return departname;
        }
    }
}