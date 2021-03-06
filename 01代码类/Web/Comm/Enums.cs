﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TX_Bussiness.Web.Comm
{
    public class Enums
    {
        /// <summary>
        /// 用户账户状态
        /// </summary>
        public enum AccountState:int
        {
            /// <summary>
            /// 正常
            /// </summary>
            Normal=1,
            /// <summary>
            /// 可用
            /// </summary>
            Enable,
            /// <summary>
            /// 不可用
            /// </summary>
            Disable,
            /// <summary>
            /// 删除
            /// </summary>
            Delete
           
        }
        /// <summary>
        /// 用户类型
        /// </summary>
        public enum UserType:int
        {
            /// <summary>
            /// 普通用户
            /// </summary>
            Normal=1,
            /// <summary>
            /// 城管通用户
            /// </summary>
            Mobile
        }
        /// <summary>
        /// 角色权限对应系统
        /// </summary>
        public enum RoleType:int
        {
            /// <summary>
            /// 人员定位系统
            /// </summary>
            Location=1,
            /// <summary>
            /// 勤务实时系统
            /// </summary>
            QWSS,
            /// <summary>
            /// 上报交办系统
            /// </summary>
            SBJB,
            /// <summary>
            /// 勤务市局系统
            /// </summary>
            QWSJ,
            /// <summary>
            /// 应用维护系统
            /// </summary>
            YYWH

        }
        /// <summary>
        /// 案卷图片类型
        /// </summary>
        public enum ProjectImgType : int 
        {
            /// <summary>
            /// 处理前
            /// </summary>
            Before=1,
            /// <summary>
            /// 处理后
            /// </summary>
            After
        }
        /// <summary>
        /// 案卷状态类型
        /// </summary>
        public enum ProjectType : int {
            /// <summary>
            /// 交办阶段
            /// </summary>
            JIAOBAN=1,
            /// <summary>
            /// 处理阶段
            /// </summary>
            CHULILI=2,
            /// <summary>
            /// 完成阶段
            /// </summary>
            WANCHENG=3
        }
        /// <summary>
        /// 区域统计类型
        /// </summary>
        public enum AreaCountType : int 
        { 
            /// <summary>
            /// 区域
            /// </summary>
            Area=1,
            /// <summary>
            /// 街道
            /// </summary>
            Street,
            /// <summary>
            /// 社区
            /// </summary>
            Commnuity
        }
    }
}