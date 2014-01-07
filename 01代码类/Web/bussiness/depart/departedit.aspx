<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="departedit.aspx.cs" Inherits="TX_Bussiness.Web.bussiness.depart.departedit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title></title>
    <link rel="stylesheet" type="text/css" href="../Styles/bootstrap.min.css" />
    <link rel="stylesheet" type="text/css" href="../Styles/admin-all.css" />
    <script type="text/javascript" src="../Scripts/jquery-1.7.2.js"></script>
    <script type="text/javascript" src="../Scripts/jquery-ui-1.8.22.custom.min.js"></script>
    <link rel="stylesheet" type="text/css" href="../Styles/ui-lightness/jquery-ui-1.8.22.custom.css" />
     <script type="text/javascript" src="../Scripts/ChurAlert.min.js?skin=blue"></script>
    <script type="text/javascript" src="../Scripts/chur-alert.1.0.js"></script>
    <link rel="stylesheet" type="text/css" href="../Styles/chur.css" />    
    <script src="/js/json2.js" type="text/javascript"></script>
    <script src="/js/global.js" type="text/javascript"></script>
    <script src="/js/Validform_v5.3.2.js" type="text/javascript"></script>
</head>
<body>
    <form action="/bussiness/depart/departedit.aspx" method="post"  class="valifrom">
    <div class="alert alert-info tit">
        当前位置<b class="tip"></b>维护界面<b class="tip"></b>部门编辑</div>
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
                    部门名称<font color="FF0000">*</font>
                    <input type="hidden" value="<%=model.Id %>" name="id"/>
                </td>
                <td width="500">
                    <input name="txt_departname" value="<%=model.Departname %>" type="text" datatype="*" nullmsg="请填写部门名称！"/>
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
                    <input name="txt_departmobile" value="<%=model.Departmobile %>" type="text" datatype="m" nullmsg="请填写正确的手机号码！"/>
                </td>
                <td>
                    部门电话<font color="FF0000">*</font>
                </td>
                <td>
                    <input name="txt_departtel" value="<%=model.Departtel %>" type="text" datatype="*" nullmsg="请填写电话！"/>
                </td>
            </tr>
            <tr>
                <td>
                    是否接受消息<font color="FF0000">*</font>
                </td>
                <td>
                    <select name="isacceptmessage">
                    <option value="1"<%=model.Isacceptmessage==1?"selected='selected'":"" %>>接受</option>
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
                <td colspan="4">
                    <input class="btn btn-primary" onclick="return viladeExist('<%=model.Id %>','depart');" id="find" type="submit" value="保存" />
                    <input class="btn btn-primary" type="button" value="取消" onclick="window.history.go(-1)" />
                </td>
            </tr>
        </tfoot>
    </table>
    </form>
</body>
</html>

