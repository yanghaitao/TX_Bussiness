using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TX_Bussiness.Web.Comm
{
    public class Constant
    {
        /// <summary>
        /// 人员定位系统
        /// </summary>
        public static readonly string RYDW = "1";
        /// <summary>
        /// 勤务实时系统
        /// </summary>
        public static readonly string QWSS = "2";
        /// <summary>
        /// 上报交办系统
        /// </summary>
        public static readonly string SBJB = "3";
        /// <summary>
        /// 勤务数据系统
        /// </summary>
        public static readonly string QWSJ = "4";
        /// <summary>
        /// 应用维护系统
        /// </summary>
        public static readonly string YYWH = "5";
        /// <summary>
        /// 管理员角色编码
        /// </summary>
        public static readonly string RoleCode_GLY = "0001";
        /// <summary>
        /// 局领导角色编码
        /// </summary>
        public static readonly string RoleCode_JLD = "0002";
        /// <summary>
        /// 中队长角色编码
        /// </summary>
        public static readonly string RoleCode_ZDZ = "0003";
        /// <summary>
        /// 执法人员角色编码
        /// </summary>
        public static readonly string RoleCode_ZFRY = "0004";
        /// <summary>
        /// 用户信息
        /// </summary>
        public static readonly string  SESSION_USER_INFO="session_userinfo";
        public static readonly string COOKIE_USER_NAME_REMEMBER = "cookie_user_name";
        public static readonly string COOKIE_USER_PWD_REMEMBER = "cookie_user_pwd";
    }
}