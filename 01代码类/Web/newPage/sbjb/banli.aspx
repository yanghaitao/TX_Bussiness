﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="banli.aspx.cs" Inherits="TX_Bussiness.Web.newPage.sbjb.banli" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>桐乡市城市管理行政执法局勤务信息平台--上报交办系统</title>
    <link rel="stylesheet" type="text/css" href="../style/css/reset.css" />
    <link rel="stylesheet" type="text/css" href="../style/css/index.css" />
    <link id="skin" rel="stylesheet" href="../style/Blue/jbox.css" />
    <script src="../js/jquery-1.6.1.js" type="text/javascript"></script>
    <script type="text/javascript" src="../../bussiness/Scripts/ChurAlert.min.js?skin=blue"></script>
    <script type="text/javascript" src="../../bussiness/Scripts/chur-alert.1.0.js"></script>
    <%-- <script type="text/javascript" src="../js/popup_layer.js"></script>
    <script type="text/javascript" src="../js/jquery.jBox.src.js"></script>--%>
    <script type="text/javascript" src="../js/public.js"></script>
    <script type="text/javascript" src="../../bussiness/Scripts/jquery-ui-1.8.22.custom.min.js"></script>
    <script src="../../js/Validform_v5.3.2.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            create_sbjbmenu("任务交办");
            $(".valifrom").Validform({
                tipSweep: true,
                tiptype: function (msg, o, cssctl) {
                    //msg：提示信息;
                    //o:{obj:*,type:*,curform:*}, obj指向的是当前验证的表单元素（或表单对象），type指示提示的状态，值为1、2、3、4， 1：正在检测/提交数据，2：通过验证，3：验证失败，4：提示ignore状态, curform为当前form对象;
                    //cssctl:内置的提示信息样式控制函数，该函数需传入两个参数：显示提示信息的对象 和 当前提示的状态（既形参o中的type）;
                    if (o.type == "3") {//验证表单元素时o.obj为该表单元素，全部验证通过提交表单时o.obj为该表单对象;
                        alert(msg);
                    }
                }
            });
        })
    </script>
</head>
<body>
    <form id="form1" action="/newpage/sbjb/banli.aspx" method="post" class="valifrom">
    <div class="container">
        <!--header start-->
         <%if (CheckRole(GetUserInfo().Id, TX_Bussiness.Web.Comm.Constant.RoleCode_JLD))
          {%>
        <div class="header"style="background: rgb(62, 120, 186) url(/newpage/style/img/header.png) no-repeat left 0;">
        <%}
          else
          { %>
            <div class="header"style="background: rgb(62, 120, 186) url(/newpage/style/img/header_qwss.png) no-repeat left 0;">
        <%} %>  <div class="loginname">欢迎您：<font><%=GetUserInfo().Loginname %></font></div>
            <div class="welcome">
                 <a class="close" href="/main.aspx">返回</a><a class="off" href="/bussiness/index.aspx?action=exit">退出</a></div>
            <div class="nav" id="menu">
            </div>
        </div>
        <!--header end-->
        <div class="tip">
            当前位置：<a href="#">上报交办系统</a> > <a href="rwcl.aspx">任务交办</a> > 待办任务</div>
        <!--content start-->
        <form name="form1" action="/newpage/sbjb/banli.aspx" method="post">
        <div class="content noborder layout">
            <!--右边内容 start-->
            <div class="col-main">
                <!--main-wrap start-->
                <div class="main-wrap">
                    <!--search_con start-->
                    <div class="search_con noborder">
                        <div class="search_data">
                            <div style="clear: both">
                            </div>
                            <div class="box">
                                <div class="box_tit" style="padding-bottom: 0px; clear: both">
                                    任务交办</div>
                                <div class="box_con" style="padding-top: 0px; clear: both">
                                    <table style="padding-top: 0px; clear: both; margin-top: 0px">
                                        <thead>
                                            <tr>
                                                <td colspan="4">
                                                    <font style="font-size: 18px">勤务单</font>
                                                </td>
                                            </tr>
                                        </thead>
                                        <tr>
                                            <td width="15%">
                                                勤务编号<font color="FF0000">*</font>
                                                <input type="hidden" name="projcode" value="<%=model.Projcode %>" />
                                            </td>
                                            <td width="500">
                                                <input name="Name" value="<%=string.Format(GetAppSeeting("ProjectNameTemplate"),model.Projcode)%>"
                                                    type="text" readonly="readonly" />
                                            </td>
                                            <td width="500">
                                                上报人<font color="FF0000">*</font>
                                            </td>
                                            <td width="500">
                                                <input name="Name" value="<%=model.Reportpersonname %>" type="text" readonly="readonly" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                区域<font color="FF0000">*</font>
                                            </td>
                                            <td>
                                                <input name="Name" value="<%=GetAreaName(model.Areacode) %>" type="text" readonly="readonly" />
                                            </td>
                                            <td>
                                                街道<font color="FF0000">*</font>
                                            </td>
                                            <td>
                                                <input name="Name" value="<%=GetStreetName(model.Streetcode) %>" type="text" readonly="readonly" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                社区<font color="FF0000">*</font>
                                            </td>
                                            <td>
                                                <input name="Name" value="<%=GetCommName(model.Communitycode )%>" type="text" readonly="readonly" />
                                            </td>
                                            <td>
                                                大类<font color="FF0000">*</font>
                                            </td>
                                            <td>
                                                <input name="Name" value="<%=model.Bigclassname %>" type="text" readonly="readonly" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                小类<font color="FF0000">*</font>
                                            </td>
                                            <td>
                                                <input name="Name0" value="<%=model.Smallclassname %>" type="text" readonly="readonly" />
                                            </td>
                                            <td>
                                                所属地区<font color="FF0000">*</font>
                                            </td>
                                            <td>
                                                <input name="Name" value="" type="text" readonly="readonly" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="15%">
                                                上报时间<font color="FF0000">*</font>
                                            </td>
                                            <td>
                                                <input name="Name" value="<%=model.Adddate %>" type="text" readonly="readonly" />
                                            </td>
                                            <td width="500">
                                                是否短信通知
                                            </td>
                                            <td width="500">
                                                <input name="ismessage" type="radio" value="V1" checked="checked" />
                                                需要
                                                <input type="radio" name="ismessage" value="V1" />
                                                不需要
                                            </td>
                                        </tr>
                                        <%if (!CheckRole(GetUserInfo().Id, TX_Bussiness.Web.Comm.Constant.RoleCode_JLD) && model.Reportpersonid != GetUserInfo().Id)
                                          {%>
                                        <tr>
                                            <td width="15%">
                                                上级部门<font color="FF0000">*</font>
                                            </td>
                                            <td>
                                                <input name="txt_operatordepart" value="<%=GetDepartName(tracemodel.Operatordepart.ToString()) %>"
                                                    type="text" readonly="readonly" />
                                            </td>
                                            <td width="500">
                                                批转人
                                            </td>
                                            <td width="500">
                                                <input name="txt_operator" type="text" value="<%=tracemodel.Operatorname %>" readonly="readonly" />
                                            </td>
                                        </tr>
                                        <%} %>
                                        <tr>
                                            <%if (CheckRole(GetUserInfo().Id, TX_Bussiness.Web.Comm.Constant.RoleCode_JLD))
                                              { %>
                                            <td>
                                                处理部门<font color="FF0000">*</font>
                                            </td>
                                            <td>
                                                <select name="txt_depart" class="ipw130" datatype="*" nullmsg="请选择派遣部门！">
                                                    <%foreach (var v in delartlist)
                                                      { %>
                                                    <option value="<%=v.Id %>">
                                                        <%=v.Departname%>
                                                    </option>
                                                    <%} %>
                                                </select>
                                            </td>
                                            <%}
                                              else if (CheckRole(GetUserInfo().Id, TX_Bussiness.Web.Comm.Constant.RoleCode_ZDZ))
                                              {%>
                                            <td>
                                                处理人<font color="FF0000">*</font>
                                            </td>
                                            <td>
                                                <select name="txt_handler" datatype="*" class="ipw130" nullmsg="请选择处理人员！">
                                                    <%foreach (var v in GetUserList(GetUserInfo().Departcode.ToString(), true))
                                                      { %>
                                                    <option value="<%=v.Id %>">
                                                        <%=v.Username%>
                                                    </option>
                                                    <%} %>
                                                </select>
                                            </td>
                                            <%} %>
                                        </tr>
                                        <tr>
                                            <td width="15%">
                                                事发地址
                                            </td>
                                            <td width="500" colspan="3" height="">
                                                <textarea name="txt_address" style="width: 95%" rows="2" cols="5" readonly="readonly"><%=model.Address %></textarea>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="15%">
                                                案卷描述
                                            </td>
                                            <td width="500" colspan="3" height="">
                                                <textarea name="txt_describe" style="width: 95%" rows="4" cols="5" readonly="readonly"><%=model.Describe %></textarea>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="15%">
                                                局领导派遣意见
                                            </td>
                                            <td width="500" colspan="3" height="">
                                                <textarea name="txt_leadmessage" style="width: 95%" rows="4" cols="5" <%if(CheckRole(GetUserInfo().Id, TX_Bussiness.Web.Comm.Constant.RoleCode_JLD)){ %>
                                                    datatype="s1-200" nullmsg="请填写派遣意见！" <%} %>><%=model.Leadmessage %></textarea>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="15%">
                                                中队长派遣意见
                                            </td>
                                            <td width="500" colspan="3" height="">
                                                <textarea name="txt_message" style="width: 95%" rows="4" cols="5" <%if(CheckRole(GetUserInfo().Id, TX_Bussiness.Web.Comm.Constant.RoleCode_ZDZ)){ %>
                                                    datatype="s1-200" nullmsg="请填写派遣意见！" <%} %>><%=model.Message %></textarea>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="15%">
                                                执法人员处置结果
                                            </td>
                                            <td width="500" colspan="3" height="">
                                                <textarea name="txt_handlemessage" style="width: 95%" rows="4" cols="5" <%if(CheckRole(GetUserInfo().Id, TX_Bussiness.Web.Comm.Constant.RoleCode_ZFRY)){ %>
                                                    datatype="s1-200" nullmsg="请填写派遣意见！" <%} %>><%=model.Handlermessge %></textarea>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4">
                                                <input class="button" id="saveproject" type="submit" value="保存" />
                                                <input class="button" type="button" value="取消" onclick="window.history.go(-1);" />
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </div>
                        </div>
                    </div>
                    <!--search_con end-->
                </div>
                <!--main-wrap end-->
            </div>
            <!--右边内容 end-->
            <!--左侧栏 start-->
            <div class="col-sub">
                <div class="tree_menu pt20">
                    <div class="time">
                        <h2>
                            任务交办</h2>
                        <dl class="message" style="padding-top: 10px">
                            <dd>
                                <a href="/newpage/sbjb/ajsb.aspx">勤务登记</a>
                            </dd>
                            <dd>
                                <a href="rwcl.aspx">待办任务</a></dd>
                            <dd>
                                <a href="ywcrw.aspx">已完成任务</a></dd>
                        </dl>
                    </div>
                </div>
            </div>
            <!--左侧栏 end-->
        </div>
        </form>
        <!--content end-->
    </div>
    </form>
</body>
</html>
