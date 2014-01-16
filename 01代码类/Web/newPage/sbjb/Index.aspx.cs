using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Yannis.DAO;
using  SubSonic;

namespace TX_Bussiness.Web.newPage.sbjb
{
    public partial class Index : Comm.BasePage
    {
        protected List<Project> projectlist = new List<Project>();
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlQuery query = new Select().Top("6").From(Project.Schema);
            query.Where("1=1");
            if (CheckRole(GetUserInfo().Id, Comm.Constant.RoleCode_JLD))
            {
                query.And(Project.NodeidColumn).IsEqualTo(1);
                query.And(Project.ReportpersonidColumn).IsEqualTo(GetUserInfo().Id);
            }
            else if (CheckRole(GetUserInfo().Id, Comm.Constant.RoleCode_ZDZ))
            {
                query.And(Project.NodeidColumn).IsEqualTo(2);
                query.And(Project.DepartcodeColumn).IsEqualTo(GetUserInfo().Departcode);
            }
            else if (CheckRole(GetUserInfo().Id, Comm.Constant.RoleCode_ZFRY))
            {
                query.And(Project.NodeidColumn).IsEqualTo(3);
                query.And(Project.HandleridColumn).IsEqualTo(GetUserInfo().Id);
            }
            query.OrderDesc(Project.Columns.Adddate);
            projectlist = query.ExecuteTypedList<Project>();
        }
    }
}