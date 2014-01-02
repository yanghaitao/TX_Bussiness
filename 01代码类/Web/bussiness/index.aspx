<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="TX_Bussiness.Web.bussiness.index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta charset="utf-8" />
    <title>后台管理系统</title>
    <link rel="stylesheet" type="text/css" href="Styles/admin-all.css" />
    <link rel="stylesheet" type="text/css" href="Styles/base.css" />
    <link rel="stylesheet" type="text/css" href="Styles/bootstrap.min.css" />
    <link rel="stylesheet" type="text/css" href="Styles/ui-lightness/jquery-ui-1.8.22.custom.css" />
    <script type="text/javascript" src="Scripts/jquery-1.7.2.js"></script>
    <script type="text/javascript" src="Scripts/jquery-ui-1.8.22.custom.min.js"></script>
    <script type="text/javascript" src="Scripts/index.js"></script>
    
</head>
<body>
    <div class="warp">
        <!--头部开始-->
        <div class="top_c">
            <div class="top-menu">
                <ul class="top-menu-nav">
                    <li><a href="#">首页</a></li>
                    <li><a href="#">案卷信息<i class="tip-up"></i></a>
                        <ul class="kidc">
                            <li><a target="Conframe" href="Template/find-form.html">表单样式</a></li>
                            <li><a target="Conframe" href="Template/find-alert.html">弹出窗口</a></li>
                            <li><a target="Conframe" href="Template/find-order.html">查询排序</a></li>
                            <li><a target="Conframe" href="Template/find-1.html">查询结果一</a></li>
                            <li><a target="Conframe" href="Template/find-2.html">查询结果二</a></li>
                        </ul>
                    </li>
                    <li><a href="#">应用维护<i class="tip-up"></i></a>
                        <ul class="kidc">
                            <li><b class="tip"></b><a target="Conframe" href="Template/Maintain-add.html">用户管理</a></li>
                            <li><b class="tip"></b><a target="Conframe" href="Template/Maintain-edit.html">部门管理</a></li>
                            <li><b class="tip"></b><a target="Conframe" href="Template/Maintain-del.html">角色管理</a></li>
                            <li><b class="tip"></b><a target="Conframe" href="Template/Maintain-del.html">类别管理</a></li>
                        </ul>
                    </li>
                    <li><a href="#">表单风格<i class="tip-up"></i></a>
                        <ul class="kidc">
                            <li><b class="tip"></b><a target="Conframe" href="Template/form-Master-slave.html">主从表单</a></li>
                            <li><b class="tip"></b><a target="Conframe" href="Template/form-collapse.html">折叠表单</a></li>
                            <li><b class="tip"></b><a target="Conframe" href="Template/form-tabs.html">标签式表单</a></li>
                            <li><b class="tip"></b><a target="Conframe" href="Template/form-tree.html">树+表单</a></li>
                            <li><b class="tip"></b><a target="Conframe" href="Template/form-guide.html">向导</a></li>
                            <li><b class="tip"></b><a target="Conframe" href="Template/form-tabs-list.html">标签页+列表</a></li>
                        </ul>
                    </li>
                    <li><a href="#">提示<i class="tip-up"></i></a>
                        <ul class="kidc">
                        <li><b class="tip"></b><a target="Conframe" href="Template/Alert.html">权限提示</a></li>
                        <li><b class="tip"></b><a target="Conframe" href="Template/Alert.html">出错提示</a></li>
                        <li><b class="tip"></b><a target="Conframe" href="Template/Alert.html">警告提示</a></li>
                        <li><b class="tip"></b><a target="Conframe" href="Template/Alert.html">询问提示</a></li>
                        <li><b class="tip"></b><a target="Conframe" href="Template/Alert.html">对话框一</a></li>
                        <li><b class="tip"></b><a target="Conframe" href="Template/Alert.html">对话框二</a></li>
                    </ul>
                    </li>
                    <li><a href="#">辅助信息<i class="tip-up"></i></a>
                        <ul class="kidc">
                        <li><b class="tip"></b><a target="Conframe" href="Template/formstyle.html">寻访记录</a></li>
                        <li><b class="tip"></b><a target="Conframe" href="Template/formstyle.html">数据说明</a></li>
                        <li><b class="tip"></b><a target="Conframe" href="Template/formstyle.html">操作记录</a></li>
                        <li><b class="tip"></b><a target="Conframe" href="Template/formstyle.html">提示</a></li>
                    </ul>
                    </li>
                </ul>
            </div>
            <div class="top-nav">上午好，欢迎您，<%=GetUserInfo().Username %>！&nbsp;&nbsp;<a href="/bussiness/template/userinfo.aspx" target="Conframe">修改密码</a> | <a href="/bussiness/index.aspx?action=exit">安全退出</a></div>
        </div>
        <!--头部结束-->
        <!--左边菜单开始-->
        <div class="left_c left">
            <h1>系统操作菜单</h1>
            <div class="acc">
                <div>
                <%if(CheckRole(GetUserInfo().Id,TX_Bussiness.Web.Comm.Constant.RoleCode_ZFRY)) {%>
                    <a class="one">勤务实时系统</a>
                    <%} else{%>
                      <a class="one">上报交办系统</a>
                    <%} %>
                    <ul class="kid">
                     <li><b class="tip"></b><a target="Conframe" href="Template/projectadd.aspx">案卷登记</a></li>
                     <li><b class="tip"></b><a target="Conframe" href="Template/projectlist.aspx">待办案卷</a></li>
                     <li><b class="tip"></b><a target="Conframe" href="Template/CompleteProject.aspx">已处理案卷</a></li>
                    </ul>
                </div>
                <%if (CheckRole(GetUserInfo().Id, TX_Bussiness.Web.Comm.Constant.RoleCode_JLD) || CheckRole(GetUserInfo().Id, TX_Bussiness.Web.Comm.Constant.RoleCode_ZDZ))
                  {%>
                 <div>
                    <a class="one">勤务数据系统</a>
                    <ul class="kid">
                       <li><b class="tip"></b><a target="Conframe" href="/bussiness/template/area_info.aspx">区域统计</a></li>
                            <li><b class="tip"></b><a target="Conframe" href="/bussiness/template/collector_info.aspx">执法人员统计</a></li>
                            <li><b class="tip"></b><a target="Conframe" href="/bussiness/role/rolelist.aspx">类别统计</a></li>
                            <li><b class="tip"></b><a target="Conframe" href="/bussiness/template/depart_info.aspx">部门统计</a></li>
                    </ul>
                </div>
                <%} %>
                <div>
                    <a class="one">应用维护</a>
                    <ul class="kid">
                       <li><b class="tip"></b><a target="Conframe" href="/bussiness/users/userlist.aspx">用户管理</a></li>
                            <li><b class="tip"></b><a target="Conframe" href="/bussiness/depart/departlist.aspx">部门管理</a></li>
                            <li><b class="tip"></b><a target="Conframe" href="/bussiness/role/rolelist.aspx">角色管理</a></li>
                            <li><b class="tip"></b><a target="Conframe" href="/bussiness/p_class/classlist.aspx">类别管理</a></li>
                    </ul>
                </div>
                <div>
                    <a class="one">表单风格</a>
                    <ul class="kid">
                        <li><b class="tip"></b><a target="Conframe" href="Template/form-Master-slave.html">主从表单</a></li>
                        <li><b class="tip"></b><a target="Conframe" href="Template/form-collapse.html">折叠表单</a></li>
                        <li><b class="tip"></b><a target="Conframe" href="Template/form-tabs.html">标签式表单</a></li>
                        <li><b class="tip"></b><a target="Conframe" href="Template/form-tree.html">树+表单</a></li>
                        <li><b class="tip"></b><a target="Conframe" href="Template/form-guide.html">向导</a></li>
                        <li><b class="tip"></b><a target="Conframe" href="Template/form-tabs-list.html">标签页+列表</a></li>
                    </ul>
                </div>
                <div>
                    <a class="one">提示</a>
                    <ul class="kid">
                        <li><b class="tip"></b><a target="Conframe" href="Template/Alert.html">权限提示</a></li>
                        <li><b class="tip"></b><a target="Conframe" href="Template/Alert.html">出错提示</a></li>
                        <li><b class="tip"></b><a target="Conframe" href="Template/Alert.html">警告提示</a></li>
                        <li><b class="tip"></b><a target="Conframe" href="Template/Alert.html">询问提示</a></li>
                        <li><b class="tip"></b><a target="Conframe" href="Template/Alert.html">对话框一</a></li>
                        <li><b class="tip"></b><a target="Conframe" href="Template/Alert.html">对话框二</a></li>
                    </ul>
                </div>
                <div>
                    <a class="one">辅助信息</a>
                    <ul class="kid">
                        <li><b class="tip"></b><a target="Conframe" href="Template/formstyle.html">寻访记录</a></li>
                        <li><b class="tip"></b><a target="Conframe" href="Template/formstyle.html">数据说明</a></li>
                        <li><b class="tip"></b><a target="Conframe" href="Template/formstyle.html">操作记录</a></li>
                        <li><b class="tip"></b><a target="Conframe" href="Template/formstyle.html">提示</a></li>
                    </ul>
                </div>
                <div id="datepicker"></div>
            </div>

        </div>
        <!--左边菜单结束-->
        <!--右边框架开始-->
        <div class="right_c">
            <div class="nav-tip" onclick="javascript:void(0)">&nbsp;</div>

        </div>
        <div class="Conframe">
            <iframe name="Conframe" id="Conframe"></iframe>
        </div>
        <!--右边框架结束-->

        <!--底部开始-->
        <div class="bottom_c">Copyright &copy;2005-2011  版权所有</div>
        <!--底部结束-->
    </div>
</body>
</html>
