<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserEdit.aspx.cs" Inherits="TX_Bussiness.Web.bussiness.users.UserEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title></title>
    <link rel="stylesheet" type="text/css" href="../Styles/bootstrap.min.css" />
    <link rel="stylesheet" type="text/css" href="../Styles/admin-all.css" />
    <script type="text/javascript" src="../Scripts/jquery-1.7.2.js"></script>
    <script type="text/javascript" src="../Scripts/jquery-ui-1.8.22.custom.min.js"></script>
    <link rel="stylesheet" type="text/css" href="../Styles/ui-lightness/jquery-ui-1.8.22.custom.css" />
    <script src="/js/json2.js" type="text/javascript"></script>
    <script src="/js/global.js" type="text/javascript"></script>
         <script type="text/javascript" src="../Scripts/ChurAlert.min.js?skin=blue"></script>
      <script type="text/javascript" src="../Scripts/chur-alert.1.0.js"></script>
      <link rel="stylesheet" type="text/css" href="../Styles/chur.css" />
    <script type="text/javascript">
        $(function () {
            $('.modal').show();
        })
    </script>
</head>
<body>
    <form action="/bussiness/users/useredit.aspx" method="post" id="form1">
    <div class="alert alert-info">
        当前位置<b class="tip"></b>维护界面<b class="tip"></b>用户编辑</div>
    <table class="table table-striped table-bordered table-condensed list">
        <thead>
            <tr>
                <td colspan="4">
                    <b>案卷基本信息</b>
                </td>
            </tr>
        </thead>
        <tbody>
            <tr>
                <td width="15%">
                    登录名<font color="FF0000">*</font>
                    <input type="hidden" value="<%=model.Id %>" name="id"/>
                </td>
                <td width="500">
                    <input name="txt_username" value="<%=model.Loginname %>" type="text" />
                </td>
                <td width="500">
                    密码<font color="FF0000">*</font>
                </td>
                <td width="500">
                    <input name="txt_password" value="<%=model.Password %>" type="text" />
                </td>
            </tr>
            <tr>
                <td>
                    姓名<font color="FF0000">*</font>
                </td>
                <td>
                    <input name="txt_name" value="<%=model.Username %>" type="text" />
                </td>
                <td>
                    手机<font color="FF0000">*</font>
                </td>
                <td>
                    <input name="txt_mobile" value="<%=model.Usermobile %>" type="text" />
                </td>
            </tr>
            <tr>
                <td>
                    固话<font color="FF0000">*</font>
                </td>
                <td>
                    <input name="txt_tel" value="<%=model.Usertel %>" type="text" />
                </td>
                <td>
                    邮箱<font color="FF0000">*</font>
                </td>
                <td>
                    <input name="txt_email" value="<%=model.Useremail%>" type="text" />
                </td>
            </tr>
            <tr>
                <td>
                    区域<font color="FF0000">*</font>
                </td>
                <td>
                    <select name="txt_area">
                        <%foreach (var v in Arealist())
                          {
                              if (!string.IsNullOrEmpty(v.Areaname))
                              {%>
                        <option value="<%=v.Areacode %>" <%=model.Collectorareacode==v.Areacode.ToString()?"selected='selected'":"" %>>
                            <%=v.Areaname %>
                        </option>
                        <%}
                          }%>
                    </select>
                </td>
                <td>
                    街道<font color="FF0000">*</font>
                </td>
                <td>
                    <select name="txt_street">
                        <option value="0">全部 </option>
                        <%foreach (var v in Streettlist())
                          {
                              if (v.Streetname != "")
                              {%>
                        <option value="<%=v.Streetcode %>" <%if(model.Streetcode==v.Streetcode.ToString()) {%>selected="selected"
                            <%} %>>
                            <%=v.Streetname%></option>
                        <%}
                          }%>
                    </select>
                </td>
            </tr>
            <tr>
                <td>
                    社区<font color="FF0000">*</font>
                </td>
                <td>
                    <select name="txt_commnuity">
                        <option value="0">全部 </option>
                        <%foreach (var v in Communitylist())
                          {
                              if (v.Commname != "")
                              {%>
                         <option value="<%=v.Commcode %>" <%if(model.Communitycode==v.Commcode.ToString()) {%>selected="selected"
                            <%} %>>
                            <%=v.Commname%></option>
                        <%}
                         }%>
                    </select>
                </td>
                <td>
                    部门<font color="FF0000">*</font>
                </td>
                <td>
                    <select name="txt_depart">
                        <%foreach (var v in Departlist())
                          { %>
                        <option value="<%=v.Id %>" <%=v.Id==model.Departcode?"selected='selected'":"" %>">
                            <%=v.Departname%>
                        </option>
                        <%} %>
                    </select>
                </td>
            </tr>
               <tr>
                <td>
                    用户类型<font color="FF0000">*</font>
                </td>
                <td>
                    <select name="txt_ismobile">
                       <option value="1" <%=model.Usertype==1?"selected='selected'":"" %>>普通用户 </option>
                        <option value="2" <%=model.Usertype==2?"selected='selected'":"" %>>城管通用户 </option>
                    </select>
                </td>
               <td>
                    所属角色<font color="FF0000">*</font>
                </td>
                <td>
                   <select name="txt_rolecode">
                        <%foreach (var v in GetRoleList())
                          {
                              if (!string.IsNullOrEmpty(v.Rolename))
                              {%>
                        <option value="<%=v.Id %>" <%=model.Roleid==v.Id?"selected='selected'":"" %>>
                            <%=v.Rolename %>
                        </option>
                        <%}
                          }%>
                    </select>
                </td>
            </tr>
        </tbody>
        <tfoot>
            <tr>
                <td colspan="4">
                    <input class="btn btn-inverse" onclick="return viladeExist('<%=model.Id %>','user');" id="find" type="button" value="保存" />
                    <input class="btn btn-inverse" type="button" value="取消" onclick="window.history.go(-1)" />
                </td>
            </tr>
        </tfoot>
    </table>
    </form>
</body>
</html>
