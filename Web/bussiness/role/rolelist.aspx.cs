using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SubSonic;
using Yannis.DAO;
using Bussiness.Common;

namespace TX_Bussiness.Web.bussiness.role
{
    public partial class rolelist : Comm.BasePage
    {
        protected List<Role> role_list = new List<Role>();
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlQuery query = new Select().From(Role.Schema);
            query.Where("1=1");
            query.OrderDesc(Role.IdColumn.ColumnName);
            role_list = query.ExecuteTypedList<Role>();
        }
        protected string GetLimitName(string limitid)
        {
            string rolename = "";
            if (string.IsNullOrEmpty(limitid))
                return "";

            string [] limits=limitid.Split(',');
            for (int i = 0; i < limits.Length; i++)
            {
                if (limits[i] == Comm.Constant.QWSJ)
                    rolename += "勤务数据系统，";
                if (limits[i] == Comm.Constant.QWSS)
                    rolename += "勤务实时系统，";
                if (limits[i] == Comm.Constant.SBJB)
                    rolename += "上报交办系统，";
                if (limits[i] == Comm.Constant.YYWH)
                    rolename += "应用维护系统，";
                if (limits[i] == Comm.Constant.RYDW)
                    rolename += "人员定位系统，";
            }
            return rolename.TrimEnd('，');
        }
    }
}