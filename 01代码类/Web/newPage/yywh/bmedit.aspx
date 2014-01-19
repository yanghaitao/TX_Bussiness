<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="bmedit.aspx.cs" Inherits="TX_Bussiness.Web.newPage.yywh.bmedit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="style/css/reset.css" />
    <link rel="stylesheet" type="text/css" href="style/css/index.css" />
    <script type="text/javascript" src="/bussiness/Scripts/jquery-1.7.2.js"></script>
    <script type="text/javascript" src="/bussiness/Scripts/jquery-ui-1.8.22.custom.min.js"></script>
    <script src="/js/jquery-1.8.0.min.js" type="text/javascript"></script>
    <script src="/js/global.js" type="text/javascript"></script>
    <script type="text/javascript" src="/bussiness/Scripts/ChurAlert.min.js?skin=blue"></script>
    <script type="text/javascript" src="/bussiness/Scripts/chur-alert.1.0.js"></script>
    <script src="/newpage/My97DatePicker/WdatePicker.js" type="text/javascript"></script>
    <script src="/js/Validform_v5.3.2.js" type="text/javascript"></script>
    <script type="text/javascript" src="/uploadify/jquery.uploadify.js"></script>
    <script type="text/javascript">
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
    </script>
</head>
<body>
    <div class="header" style="position: relative;">
        <div style="position: absolute; height: 41px; right: 100px; top: 23px; color: White;
            font-size: 18px;">
            欢迎您，<%=GetUserInfo().Loginname %>!
        </div>
        <div class="layout">
            <div class="logo">
                <h1 style="line-height: 67px; font-size: 30px; color: White; margin-left: 30px;">
                    应用维护系统</h1>
            </div>
            <div class="top_menu">
                <a class="lock" href="/bussiness/index.aspx?action=exit" title="注销"></a><a class="close"
                    href="/bussiness/index.aspx?action=exit" title="退出"></a><a class="off" href="/bussiness/index.aspx?action=exit"
                        title="注销"></a>
            </div>
        </div>
        <div class="nav">
            <ul class="left">
                <li><a href="/newpage/yywh/rygl.aspx">人员管理</a></li><li class="cur"><a href="/newpage/yywh/bmgl.aspx">
                    部门管理</a></li><li><a href="/newpage/yywh/jsgl.aspx">角色管理</a></li><li><a href="/newpage/yywh/lbgl.aspx">
                        类别管理</a></li>
                <li><a href="/newpage/yywh/czjl.aspx">操作记录</a></li>
            </ul>
        </div>
    </div>
    <!--header end -->
    <!--main start -->
    <div class="main layout">
        <!--右边内容 start-->
        <div class="col-main">
            <!--main-wrap start-->
            <div class="main-wrap">
                <!--content start-->
                <div class="content">
                    <div class="box">
                        <div class="box_tit">
                            部门管理</div>
                        <div class="box_con">
                            <form action="/newPage/yywh/bmedit.aspx" method="post" class="valifrom" id="form1">
                            <table width="100%" class="tb_a" border="0" cellpadding="0" cellspacing="0" style="margin-top: 0px">
                                <thead>
                                    <tr>
                                        <td colspan="4">
                                            <b>基本信息</b>
                                        </td>
                                    </tr>
                                </thead>
                                <tbody>
                                    <tr>
                                        <td width="15%">
                                            部门名称<font color="FF0000">*</font>
                                            <input type="hidden" value="<%=model.Id %>" name="id" />
                                        </td>
                                        <td width="500">
                                            <input name="txt_departname" value="<%=model.Departname %>" type="text" datatype="*"
                                                onblur="viladeExist(<%=model.Id %>,'depart')" nullmsg="请填写部门名称！" />
                                        </td>
                                        <td width="500">
                                            上级部门<font color="FF0000">*</font>
                                        </td>
                                        <td width="500">
                                            <select name="txt_parentdepart">
                                                <option value="">无</option>
                                                <%foreach (var v in Departlist())
                                                  {
                                                      if (!string.IsNullOrEmpty(v.Departname))
                                                      {%>
                                                <option value="<%=v.Id %>" <%=model.Parentcode==v.Id.ToString()?"selected='selected'":"" %>>
                                                    <%=v.Departname %>
                                                </option>
                                                <%}
                                                  }%>
                                            </select>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            部门手机<font color="FF0000">*</font>
                                        </td>
                                        <td>
                                            <input name="txt_departmobile" value="<%=model.Departmobile %>" type="text" datatype="m"
                                                nullmsg="请填写正确的手机号码！" />
                                        </td>
                                        <td>
                                            部门电话<font color="FF0000">*</font>
                                        </td>
                                        <td>
                                            <input name="txt_departtel" value="<%=model.Departtel %>" type="text" datatype="*"
                                                nullmsg="请填写电话！" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            是否接受消息<font color="FF0000">*</font>
                                        </td>
                                        <td>
                                            <select name="isacceptmessage">
                                                <option value="1" <%=model.Isacceptmessage==1?"selected='selected'":"" %>>接受</option>
                                                <option value="0" <%=model.Isacceptmessage==0?"selected='selected'":"" %>>不接受</option>
                                            </select>
                                        </td>
                                        <td>
                                            部门状态<font color="FF0000">*</font>
                                        </td>
                                        <td>
                                            <input name="txt_departstate" value="<%=model.Departstate%>" type="text" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            区域<font color="FF0000">*</font>
                                        </td>
                                        <td>
                                            <select name="txt_departarea" datatype="*" nullmsg="请选择部门！">
                                                <%foreach (var v in Arealist())
                                                  {
                                                      if (!string.IsNullOrEmpty(v.Areaname))
                                                      {%>
                                                <option value="<%=v.Areacode %>" <%=model.Areacode==v.Areacode?"selected='selected'":"" %>>
                                                    <%=v.Areaname %>
                                                </option>
                                                <%}
                                                  }%>
                                            </select>
                                        </td>
                                        <%--<td>
                    所属角色<font color="FF0000">*</font>
                </td>
                <td>
                  <select name="txt_rolecode">
                        <%foreach (var v in GetRoleList())
                          {
                              if (!string.IsNullOrEmpty(v.Rolename))
                              {%>
                        <option value="<%=v.Rolecode %>" <%=model.Rolecode==v.Rolecode?"selected='selected'":"" %>>
                            <%=v.Rolename %>
                        </option>
                        <%}
                          }%>
                    </select>
                </td>--%>
                                    </tr>
                                </tbody>
                                <tfoot>
                                    <tr>
                                        <td colspan="4" style="padding-left: 240px">
                                            <input class="button" id="find" type="submit" value="保存" />
                                            <input class="button" type="button" value="取消" onclick="window.history.go(-1)" />
                                        </td>
                                    </tr>
                                </tfoot>
                            </table>
                            </form>
                        </div>
                    </div>
                </div>
                <!--content end-->
            </div>
            <!--main-wrap end-->
        </div>
        <!--右边内容 end-->
        <!--左侧栏 start-->
        <div class="col-sub">
            <!--menu start -->
            <div class="menu">
                <div class="menu_tit">
                    部门管理</div>
                <div class="menu_con">
                    <ul>
                        <li class="cur"><a href="/newPage/yywh/bmgl.aspx">部门管理</a></li>
                    </ul>
                </div>
            </div>
            <!--menu end -->
        </div>
        <!--左侧栏 end-->
    </div>
    <!--main end -->
</body>
</html>
