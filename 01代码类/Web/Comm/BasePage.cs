using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Yannis.DAO;
using SubSonic;
using Bussiness.Common;
using System.Configuration;

namespace TX_Bussiness.Web.Comm
{
    public partial class BasePage : System.Web.UI.Page
    {
        protected override void OnInit(EventArgs e)
        {
            if (!IsUserLogin())
                Response.Redirect("/login.aspx");
            base.OnInit(e);
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
        }
        /// <summary>
        /// 判断用户是否登录
        /// </summary>
        /// <returns></returns>
        public bool IsUserLogin()
        {
            //如果Session为Null
            if (HttpContext.Current.Session[Comm.Constant.SESSION_USER_INFO] != null)
            {
                return true;
            }
            else
            {
                //检查Cookies
                string username = Utility.GetCookie(Comm.Constant.COOKIE_USER_NAME_REMEMBER, "TX_SZCG"); //解密用户名
                string password = Utility.GetCookie(Comm.Constant.COOKIE_USER_PWD_REMEMBER, "TX_SZCG");
                if (username != "" && password != "")
                {
                    Yannis.DAO.User model = new Select().From(Yannis.DAO.User.Schema).Where(Yannis.DAO.User.LoginnameColumn)
                        .IsEqualTo(username).And(Yannis.DAO.User.PasswordColumn).IsEqualTo(password).ExecuteSingle<Yannis.DAO.User>();
                    if (model != null)
                    {
                        HttpContext.Current.Session[Comm.Constant.SESSION_USER_INFO] = model;
                        return true;
                    }
                }
            }
            return false;
        }
        /// <summary>
        /// 取得用户信息
        /// </summary>
        /// <returns></returns>
        public Yannis.DAO.User GetUserInfo()
        {
            if (IsUserLogin())
            {
                Yannis.DAO.User model = HttpContext.Current.Session[Comm.Constant.SESSION_USER_INFO] as Yannis.DAO.User;
                if (model != null)
                {
                    //为了能查询到最新的用户信息，必须查询最新的用户资料
                    model = Yannis.DAO.User.FetchByID(model.Id);
                    return model;
                }
            }
            return null;
        }
        /// <summary>
        /// 获取子部门列表
        /// </summary>
        /// <param name="parentcode"></param>
        /// <returns></returns>
        public string GetChildDepart(object parentcode)
        {
            string option = "";
            List<Depart> childdepart = new Select().From(Depart.Schema).Where(Depart.ParentcodeColumn).IsEqualTo(parentcode).ExecuteTypedList<Depart>();
            if (childdepart.Count > 0)
            {
                for (int i = 0; i < childdepart.Count; i++)
                {
                    option += "<option valyue='" + childdepart[i].Departcode + "'>└" + childdepart[i].Departname + "</option>";
                    GetChildDepart(childdepart[i].Departcode);
                }
            }
            else
            {
                return option;
            }
            return option;
        }
        /// <summary>
        /// 获取大类分类列表
        /// </summary>
        /// <returns></returns>
        public List<Projectclass> GetProjectClass()
        {
            return new Select().From(Projectclass.Schema).Where(Projectclass.ClasstypeColumn).IsEqualTo(1).ExecuteTypedList<Projectclass>();
        }
        /// <summary>
        /// 判断用户是否有权限
        /// </summary>
        /// <param name="limitid">用户权限id</param>
        /// <param name="limits"></param>
        /// <returns></returns>
        public bool HasLimit(string limitid, string limits)
        {
            if (!string.IsNullOrEmpty(limits))
            {
                string[] limitarr = limits.Split(',');
                for (int i = 0; i < limitarr.Length; i++)
                {
                    if (limitarr[i] == limitid)
                        return true;
                }
            }
            return false;
        }
        /// <summary>
        /// 获取部门列表
        /// </summary>
        /// <returns></returns>
        public List<Depart> Departlist()
        {
            SqlQuery query = new Select().From(Depart.Schema);
            query.Where("1=1");
            query.And(Depart.IsdelColumn).IsNotEqualTo(true);
            List<Depart> list = query.ExecuteTypedList<Depart>();
            if (list != null && list.Count > 0) return list;
            else return new List<Depart>();
        }
        /// <summary>
        /// 获取区域列表
        /// </summary>
        /// <returns></returns>
        public List<SArea> Arealist()
        {
            SqlQuery query = new Select().From(SArea.Schema);
            query.Where("1=1");
            List<SArea> list = query.ExecuteTypedList<SArea>();
            if (list != null && list.Count > 0) return list;
            else return new List<SArea>();
        }
        /// <summary>
        /// 获取街道列表
        /// </summary>
        /// <returns></returns>
        public List<SStreet> Streettlist()
        {
            SqlQuery query = new Select().From(SStreet.Schema);
            query.Where("1=1");
            List<SStreet> list = query.ExecuteTypedList<SStreet>();
            if (list != null && list.Count > 0) return list;
            else return new List<SStreet>();
        }
        /// <summary>
        /// 获取街道列表
        /// </summary>
        /// <param name="areacode">区域编码</param>
        /// <returns></returns>
        public List<SStreet> Streettlist(object areacode)
        {
            SqlQuery query = new Select().From(SStreet.Schema);
            query.Where("1=1");
            query.Where(SStreet.AreacodeColumn).IsEqualTo(areacode);
            List<SStreet> list = query.ExecuteTypedList<SStreet>();
            if (list != null && list.Count > 0) return list;
            else return new List<SStreet>();
        }
        /// <summary>
        /// 获取社区列表
        /// </summary>
        /// <returns></returns>
        public List<SCommunity> Communitylist()
        {
            SqlQuery query = new Select().From(SCommunity.Schema);
            query.Where("1=1");
            List<SCommunity> list = query.ExecuteTypedList<SCommunity>();
            if (list != null && list.Count > 0) return list;
            else return new List<SCommunity>();
        }
        /// <summary>
        /// 获取社区列表
        /// </summary>
        /// <param name="streetcode">街道编码</param>
        /// <returns></returns>
        public List<SCommunity> Communitylist(object streetcode)
        {
            SqlQuery query = new Select().From(SCommunity.Schema);
            query.Where("1=1");
            query.Where(SCommunity.StreetcodeColumn).IsEqualTo(streetcode);
            List<SCommunity> list = query.ExecuteTypedList<SCommunity>();
            if (list != null && list.Count > 0) return list;
            else return new List<SCommunity>();
        }
        /// <summary>
        /// 判断用户权限
        /// </summary>
        /// <param name="user">用户实体</param>
        /// <param name="limitid">权限编码</param>
        /// <returns></returns>
        public bool CheckLimit(string userid, string limitid)
        {
            //SqlQuery query = new Select(Role.LimitidColumn).From(Yannis.DAO.User.Schema).LeftOuterJoin(Role.IdColumn, Yannis.DAO.User.RoleidColumn)
            //  .And(Yannis.DAO.User.IdColumn).IsEqualTo(userid);
            Yannis.DAO.User user = Yannis.DAO.User.FetchByID(userid);
            Depart depart = Depart.FetchByID(user.Departcode);
            SqlQuery query = new Select().From(Role.Schema).Where(Role.RolecodeColumn).IsEqualTo(depart.Rolecode);
            Role role = query.ExecuteSingle<Role>();
            if (role != null)
            {
                string[] limitids = role.Limitid.ToString().Split(',');
                for (int i = 0; i < limitids.Length; i++)
                {
                    if (limitids[i] == limitid)
                        return true;
                }
            }
            return false;
        }
        /// <summary>
        /// 获取区域名称
        /// </summary>
        /// <param name="areacode">区域id</param>
        /// <returns></returns>
        public string GetAreaName(string areacode)
        {
            object o = new Select(SArea.AreanameColumn).From(SArea.Schema).Where(SArea.AreacodeColumn).IsEqualTo(areacode).ExecuteScalar();
            if (o != null)
                return o.ToString();
            return string.Empty;
        }
        /// <summary>
        /// 获取街道名称
        /// </summary>
        /// <param name="streetcode">街道id</param>
        /// <returns></returns>
        public string GetStreetName(string streetcode)
        {
            object o = new Select(SStreet.StreetnameColumn).From(SStreet.Schema).Where(SStreet.StreetcodeColumn).IsEqualTo(streetcode).ExecuteScalar();
            if (o != null)
                return o.ToString();
            return string.Empty;
        }
        /// <summary>
        /// 获取社区名称
        /// </summary>
        /// <param name="commcode">社区id</param>
        /// <returns></returns>
        public string GetCommName(string commcode)
        {
            object o = new Select(SCommunity.CommnameColumn).From(SCommunity.Schema).Where(SCommunity.CommcodeColumn).IsEqualTo(commcode).ExecuteScalar();
            if (o != null)
                return o.ToString();
            return string.Empty;
        }
        /// <summary>
        /// 获取类别名称
        /// </summary>
        /// <param name="classcode">类别id</param>
        /// <returns></returns>
        public string GetClassName(string classcode)
        {
            object o = new Select(Projectclass.ClassnameColumn).From(Projectclass.Schema).Where(Projectclass.IdColumn).IsEqualTo(classcode).ExecuteScalar();
            if (o != null)
                return o.ToString();
            return string.Empty;
        }
        /// <summary>
        /// 获取用户名称
        /// </summary>
        /// <param name="userid">用户id</param>
        /// <returns></returns>
        public string GetUserName(string userid)
        {
            SqlQuery query = new Select().From(Yannis.DAO.User.Schema).Where(Yannis.DAO.User.IdColumn).IsEqualTo(userid);
            object o = query.ExecuteScalar();
            if (o != null)
                return o.ToString();
            return string.Empty;
        }
        /// <summary>
        /// 获取部门名称
        /// </summary>
        /// <param name="departid">部门id</param>
        /// <returns></returns>
        public string GetDepartName(string departid)
        {
            if (string.IsNullOrEmpty(departid))
                return "";
            SqlQuery query = new Select(Depart.DepartnameColumn).From(Depart.Schema).Where(Depart.IdColumn).IsEqualTo(departid);
            object o = query.ExecuteScalar();
            if (o != null)
                return o.ToString();
            return string.Empty;
        }
        /// <summary>
        /// 根据类型获取大小类（1：大类  2：小类）
        /// </summary>
        /// <param name="projecttype">类别</param>
        /// <returns></returns>
        public List<Projectclass> GetProjectClass(object parentcode)
        {
            SqlQuery query = new Select().From(Projectclass.Schema);
            query.Where("1=1");
            query.And(Projectclass.IsdelColumn).IsNotEqualTo(true);
            query.And(Projectclass.ParentidColumn).IsEqualTo(parentcode);
            List<Projectclass> list = query.ExecuteTypedList<Projectclass>();
            if (list != null && list.Count > 0)
                return list;
            return new List<Projectclass>();
        }
        /// <summary>
        /// 获取webconfig中AppSeeting值
        /// </summary>
        /// <param name="setname"></param>
        /// <returns></returns>
        public string GetAppSeeting(string setname)
        {
            string str = ConfigurationManager.AppSettings[setname];
            if (!string.IsNullOrEmpty(str))
                return str;
            return string.Empty;
        }
        /// <summary>
        /// 根据部门编号获取该部门下所有人员
        /// </summary>
        /// <param name="departid">部门id</param>
        /// <returns></returns>
        public List<Yannis.DAO.User> GetUserList(string departid)
        {
            SqlQuery query = new Select().From(Yannis.DAO.User.Schema).Where(Yannis.DAO.User.DepartcodeColumn).IsEqualTo(departid);
            query.And(Yannis.DAO.User.IsdelColumn).IsNotEqualTo(true);
            List<Yannis.DAO.User> list = query.ExecuteTypedList<Yannis.DAO.User>();
            if (list != null && list.Count > 0)
                return list;
            return new List<User>();
        }
        /// <summary>
        /// 获取该部门下的人员
        /// </summary>
        /// <param name="departid">部门id</param>
        /// <param name="iszfy">是否只获取执法人员</param>
        /// <returns></returns>
        public List<Yannis.DAO.User> GetUserList(string departid, bool iszfy)
        {
            SqlQuery query = new Select().From(Yannis.DAO.User.Schema).Where(Yannis.DAO.User.DepartcodeColumn).IsEqualTo(departid);
            query.And(Yannis.DAO.User.IsdelColumn).IsNotEqualTo(true);
            List<Yannis.DAO.User> list = query.ExecuteTypedList<Yannis.DAO.User>();
            List<Yannis.DAO.User> userlist = new List<User>();
            if (iszfy)
            {
                foreach (var v in list)
                {
                    if (CheckRole(v.Id, Comm.Constant.RoleCode_ZFRY))
                    {
                        userlist.Add(v);
                    }
                }
            }
            return userlist;
        }
        /// <summary>
        /// 检查用户角色
        /// </summary>
        /// <param name="userid">用户id</param>
        /// <param name="rolecode">角色编码</param>
        /// <returns></returns>
        public bool CheckRole(int userid, string rolecode)
        {
            //SqlQuery query = new Select(Yannis.DAO.User.DepartcodeColumn).From(Yannis.DAO.User.Schema).Where(Yannis.DAO.User.IdColumn).IsEqualTo(userid);
            //object departid = query.ExecuteScalar();
            //SqlQuery querystr = new Select(Depart.RolecodeColumn).From(Depart.Schema).Where(Depart.RolecodeColumn).IsEqualTo(departid);
            //object departrolecode = querystr.ExecuteScalar();
            //if (departrolecode != null && departrolecode.ToString() == rolecode)
            //    return true;
            //return false;


            SqlQuery query = new Select(Role.RolecodeColumn).From(Yannis.DAO.User.Schema).LeftOuterJoin(Role.IdColumn, Yannis.DAO.User.RoleidColumn).Where(Yannis.DAO.User.IdColumn).IsEqualTo(userid);
            object o = query.ExecuteScalar();
            if (o != null && o.ToString() == rolecode)
                return true;
            return false;
        }
        /// <summary>
        /// 获取角色列表
        /// </summary>
        /// <returns></returns>
        public List<Role> GetRoleList()
        {
            SqlQuery query = new Select().From(Role.Schema);
            query.Where("1=1");
            return query.ExecuteTypedList<Role>();
        }
        /// <summary>
        /// 记录操作日志
        /// </summary>
        /// <param name="actionname">当前操作名称</param>
        public void WriteLog(string actionname)
        {
            Yannis.DAO.User user = GetUserInfo();
            new SysLog()
            {
                Actionname = actionname,
                CuDate = DateTime.Now,
                Ip = Utility.GetIP(),
                Loginname = user.Loginname,
                Userid = user.Id
            }.Save();
        }
    }
}