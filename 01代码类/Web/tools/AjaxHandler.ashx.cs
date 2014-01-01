using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections.Specialized;
using System.Data;
using TX_Bussiness.Web.Comm;
using SubSonic;
using Yannis.DAO;
using LitJson;
using System.Web.Script.Serialization;
using Bussiness.Common;
using System.IO;
using System.Configuration;

namespace TX_Bussiness.Web.tools
{
    /// <summary>
    /// AjaxHandler 的摘要说明
    /// </summary>
    public class AjaxHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            // context.Response.Write("Hello World");

            NameValueCollection dictionarySource =
                       (context.Request.RequestType.ToUpper().Equals("GET"))
                       ? context.Request.QueryString : context.Request.Form;
            NameValueCollection dict = new NameValueCollection(dictionarySource);
            string acts = dict["act"];
            switch (dict["act"])
            {

                case "DeleteUser"://删除用户（暂不使用）
                    context.Response.Write(DeleteUser(dict["id"]));
                    break;

                case "DeleteRole"://删除部门（暂不使用）
                    context.Response.Write(DeleteRole(dict["id"]));
                    break;
                case "DeleteAll"://删除多选项（暂不使用）
                    context.Response.Write(DeleteAll(dict["ids"], dict["model"]));
                    break;
                case "DeleteClass"://删除分类（暂不使用）
                    context.Response.Write(DeleteClass(dict["id"]));
                    break;
                case "GetStreetList"://获取街道列表
                    context.Response.Write(GetStreetList(dict["areacode"]));
                    break;
                case "GetCommunityList"://获取社区列表
                    context.Response.Write(GetCommunityList(dict["streetcode"]));
                    break;
                case "GetSmallClass"://获取小类列表
                    context.Response.Write(GetSmallClass(dict["bigclasscode"]));
                    break;
                case "CheckLimit"://检查用户权限
                    context.Response.Write(CheckLimit(dict["userid"], dict["system"]));
                    break;
                case "DeleModel"://删除实体（逻辑删除）
                    context.Response.Write(DeleModel(dict["model"], dict["id"]));
                    break;
                case "UserIsExist"://判断用户名是否已存在
                    context.Response.Write(UserIsExist(dict["name"]));
                    break;
                case "DepartIsExist"://判断部门名是否已存在
                    context.Response.Write(DepartIsExist(dict["name"]));
                    break;
                case "ChangePassword"://修改用户密码
                    context.Response.Write(ChangePassword(dict["uid"], dict["oldpwd"], dict["newpwd"]));
                    break;
                case "UploadFile":
                    context.Response.Write(FileUpload(context));
                    break;
                case "GetProjessClassJson":
                    context.Response.Write(GetProjessClassJson(dict["parentcode"]));
                    break;
            }
        }

        private string FileUpload(HttpContext context)
        {
            string filepath = string.Format(ConfigurationManager.AppSettings["ImgUploadPath"]+"{0}/{1}/{2}/",DateTime.Now.Year,DateTime.Now.Month,DateTime.Now.Day);
            HttpPostedFile file = context.Request.Files["Filedata"];
            string uploadPath =
                HttpContext.Current.Server.MapPath(filepath);

            if (file != null)
            {
                if (!Directory.Exists(uploadPath))
                {
                    Directory.CreateDirectory(uploadPath);
                }
                file.SaveAs(uploadPath + file.FileName);
                //下面这句代码缺少的话，上传成功后上传队列的显示不会自动消失  
                return filepath+file.FileName;
            }
            else
            {
                return "0";
            }

            //throw new NotImplementedException();
        }
        private string ChangePassword(string uid, string oldpwd, string newpwd)
        {
            Yannis.DAO.User model = new Select().From(Yannis.DAO.User.Schema).Where(Yannis.DAO.User.IdColumn).IsEqualTo(uid)
                .And(Yannis.DAO.User.PasswordColumn).IsEqualTo(oldpwd).ExecuteSingle<Yannis.DAO.User>();
            if (model == null)
                return "旧密码错误！";
            model.Password = newpwd;
            model.Save();
            new SysLog()
            {
                Actionname = "修改用户密码，旧密码：" + oldpwd + " 新密码：" + newpwd,
                CuDate = DateTime.Now,
                Ip = Utility.GetIP(),
                Loginname = model.Loginname,
                Userid = model.Id
            }.Save();
            return "1";
            // throw new NotImplementedException();
        }

        private string DepartIsExist(string departname)
        {
            SqlQuery query = new Select().From(Yannis.DAO.Depart.Schema);
            query.Where("1=1");
            query.And(Yannis.DAO.Depart.DepartnameColumn).IsEqualTo(departname);
            query.And(Yannis.DAO.Depart.IsdelColumn).IsNotEqualTo(true);
            Yannis.DAO.Depart model = query.ExecuteSingle<Yannis.DAO.Depart>();
            if (model != null)
                return "1";
            return "0";
            //throw new NotImplementedException();
        }

        private string UserIsExist(string loginname)
        {
            SqlQuery query = new Select().From(Yannis.DAO.User.Schema);
            query.Where("1=1");
            query.And(Yannis.DAO.User.LoginnameColumn).IsEqualTo(loginname);
            query.And(Yannis.DAO.User.IsdelColumn).IsNotEqualTo(true);
            Yannis.DAO.User model = query.ExecuteSingle<Yannis.DAO.User>();
            if (model != null)
                return "1";
            return "0";
            //throw new NotImplementedException();
        }

        private string DeleModel(string tablename, string id)
        {
            if (tablename == "user")
            {
                Yannis.DAO.User user = User.FetchByID(id);
                user.Isdel = true;
                user.Save();
                //WriteLog("删除用户 用户id:"+user.Id+" 登录名："+user.Loginname);
                return "1";
            }
            if (tablename == "depart")
            {
                Depart depart = Depart.FetchByID(id);
                depart.Isdel = true;
                depart.Save();
                //WriteLog("删除部门 部门id:" + depart.Id + " 登录名：" + depart.Departname);
                return "1";
            }
            if (tablename == "projectclass")
            {
                Projectclass pclass = Projectclass.FetchByID(id);
                pclass.Isdel = true;
                pclass.Save();
                // WriteLog("删除分类 分类id:" + pclass.Id + " 类别名称：" + pclass.Classname);
                return "1";
            }
            return "0";
            // throw new NotImplementedException();
        }

        private string CheckLimit(string userid, string systemname)
        {
            string limitid = "";
            if (systemname == "rydw")
                limitid = Comm.Constant.RYDW;
            if (systemname == "qwss")
                limitid = Comm.Constant.QWSS;
            if (systemname == "sbjb")
                limitid = Comm.Constant.SBJB;
            if (systemname == "qwsj")
                limitid = Comm.Constant.QWSJ;
            if (systemname == "yywh")
                limitid = Comm.Constant.YYWH;
            Yannis.DAO.User user = Yannis.DAO.User.FetchByID(userid);
            SqlQuery query = new Select().From(Role.Schema).Where(Role.IdColumn).IsEqualTo(user.Roleid);
            Role role = query.ExecuteSingle<Role>();
            if (role != null)
            {
                string[] limitids = role.Limitid.ToString().Split(',');
                for (int i = 0; i < limitids.Length; i++)
                {
                    if (limitids[i] == limitid)
                        return "1";
                }
            }
            return "0";
            // throw new NotImplementedException();
        }

        private string GetSmallClass(string bigclasscode)
        {
            SqlQuery query = new Select().From(Projectclass.Schema);
            query.Where("1=1");
            if (bigclasscode != "0")
            {
                query.And(Projectclass.ParentidColumn).IsEqualTo(bigclasscode);
                List<Projectclass> list = query.ExecuteTypedList<Projectclass>();
                if (list != null && list.Count > 0)
                    return new JavaScriptSerializer().Serialize(list);
            }
            return string.Empty;
            //throw new NotImplementedException();
        }

        private string GetCommunityList(string streetcode)
        {
            SqlQuery query = new Select(SCommunity.CommcodeColumn, SCommunity.CommnameColumn).From(SCommunity.Schema);
            query.Where("1=1");
            if (streetcode != "0")
            {
                query.And(SCommunity.StreetcodeColumn).IsEqualTo(streetcode);
                List<SCommunity> list = query.ExecuteTypedList<SCommunity>();
                if (list != null && list.Count > 0)
                    return new JavaScriptSerializer().Serialize(list);
            }
            return string.Empty;
            // throw new NotImplementedException();
        }

        private string GetStreetList(string areacode)
        {
            SqlQuery query = new Select(SStreet.StreetcodeColumn, SStreet.StreetnameColumn).From(SStreet.Schema);
            query.Where("1=1");
            if (areacode != "0")
            {
                query.And(SStreet.AreacodeColumn).IsEqualTo(areacode);
                List<SStreet> list = query.ExecuteTypedList<SStreet>();
                if (list != null && list.Count > 0)
                    return new JavaScriptSerializer().Serialize(list);
            }
            return string.Empty;
            //throw new NotImplementedException();
        }

        private string DeleteClass(string id)
        {
            if (Projectclass.Delete(id) > 0)
                return "1";
            else return "0";
            //throw new NotImplementedException();
        }

        private string DeleteAll(string ids, string model)
        {

            for (int i = 0; i < ids.Split(',').Length; i++)
            {
                if (!string.IsNullOrEmpty(ids.Split(',')[i]))
                {
                    if (model == "users") { User.Delete(ids.Split(',')[i]); }
                    if (model == "depart") { Depart.Delete(ids.Split(',')[i]); }
                    if (model == "role") { Role.Delete(ids.Split(',')[i]); }
                    if (model == "class") { Projectclass.Delete(ids.Split(',')[i]); }
                }
            }
            return "1";
            //throw new NotImplementedException();
        }

        private string DeleteUser(string id)
        {
            int i = new Delete().From(User.Schema).Where(User.IdColumn).IsEqualTo(id).Execute();
            if (i > 0) return "1";
            else return "0";
            // throw new NotImplementedException();
        }

        private string DeleteRole(string id)
        {
            int i = new Delete().From(Role.Schema).Where(Role.IdColumn).IsEqualTo(id).Execute();
            if (i > 0) return "1";
            else return "0";
            // throw new NotImplementedException();
        }
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
        public bool IsReusable
        {
            get
            {
                return false;
            }
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

        /// <summary>
        /// 获取子类别列表
        /// </summary>
        /// <param name="parentcode"></param>
        /// <returns></returns>
        public string GetProjessClassJson(object parentcode)
        {
            SqlQuery query = new Select().From(Projectclass.Schema).Where(Projectclass.ParentidColumn).IsEqualTo(parentcode);
            query.Where("1=1");
            query.And(Projectclass.IsdelColumn).IsNotEqualTo(true);
            List<Projectclass> list = query.ExecuteTypedList<Projectclass>();
            return new JavaScriptSerializer().Serialize(list);
        }
    }
}