<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserList.aspx.cs" Inherits="TX_Bussiness.Web.bussiness.users.UserList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title></title>
    <link rel="stylesheet" type="text/css" href="../Styles/bootstrap.min.css" />
    <link rel="stylesheet" type="text/css" href="../Styles/admin-all.css" />
    <script type="text/javascript" src="../Scripts/jquery-1.7.2.js"></script>
    <script type="text/javascript" src="../Scripts/jquery-ui-1.8.22.custom.min.js"></script>
    <link rel="stylesheet" type="text/css" href="../Styles/ui-lightness/jquery-ui-1.8.22.custom.css" />
    <script type="text/javascript" src="../Scripts/tip.js"></script>
    <script type="text/javascript" src="/js/json2.js"></script>
    <script src="/js/global.js" type="text/javascript"></script>
    <script type="text/javascript" src="../Scripts/ChurAlert.min.js?skin=blue"></script>
    <script type="text/javascript" src="../Scripts/chur-alert.1.0.js"></script>
    <link rel="stylesheet" type="text/css" href="../Styles/chur.css" />
    <script type="text/javascript">
        $("#info2").click(function () {
            alert(1)
            $('body').alert({
                type: 'info',
                buttons: [{
                    id: 'yes',
                    name: '确定',
                    callback: function () {
                        alert('确定')
                    }
                }, {
                    id: 'no',
                    name: '取消',
                    callback: function () {
                        alert('取消')
                    }
                }]
            })
        })
    </script>
</head>
<body>
    <div>
    </div>
    <div class="alert alert-info tit">
        当前位置<b class="tip"></b>查询界面<b class="tip"></b>用户列表 <span style="display: inline-block;
            float: right; position: relative; top: -5px;"><a href="/bussiness/users/UserEdit.aspx?action=add"
                class="btn btn-primary btn-small" id="primary">添加用户</a></span></div>
    <form action="/bussiness/users/userlist.aspx" method="get">
    <table class="table table-striped table-bordered table-condensed c_table">
        <thead>
            <tr>
                <td colspan="8" class="auto-style2">
                    &nbsp;请填写查询条件
                </td>
            </tr>
        </thead>
        <tbody>
            <tr>
                <td class="t_label">
                    姓名
                </td>
                <td class="detail">
                    <input id="formid" name="txt_username" value="<%=txt_username %>" />
                </td>
                <td class="t_label">
                    用户类型
                </td>
                <td class="td_detail">
                    <select size="1" name="txt_usertype" id="Select1">
                      <option value="0">全部用户</option>
                        <option value="1" <%=txt_usertype=="1"?"selected='selected'":"" %>>普通用户</option>
                        <option value="2" <%=txt_usertype=="2"?"selected='selected'":"" %>>城管通用户</option>
                    </select>
                </td>
                <td class="t_label">
                    所属部门
                </td>
                <td>
                    <select size="1" name="txt_depart" id="bumen">
                        <option value="0">全部</option>
                        <%foreach (var v in Departlist())
                          {
                              if (v.Departname != "")
                              { %>
                        <option value="<%=v.Id %>" <%=v.Id.ToString()==txt_depart?"selected=selected":"" %>>
                            <%=v.Departname %></option>
                        <%}
                          }%>
                    </select>
                </td>
                <td>
                <input class="btn btn-primary" id="find" type="submit" value="查询" />
                    <input class="btn btn-primary" type="reset" id="reset" value="清空" />
                </td>
            </tr>
        </tbody>
    </table>
    </form>
    <table class="table table-striped table-bordered table-condensed" id="list">
        <thead>
            <tr class="tr_detail">
                <td>
                    登录名
                </td>
                <td>
                    手机
                </td>
                <td>
                    用户姓名
                </td>
                <td>
                    用户类型
                </td>
                <td>
                    用户状态
                </td>
                <td>
                    所属部门
                </td>
                <td>
                    添加时间
                </td>
                <td>
                    操作
                </td>
            </tr>
        </thead>
        <tbody>
            <%if (userlist != null && userlist.Count > 0)
              {
                  int i = 0;
                  foreach (var v in userlist)
                  {%>
            <tr <%=i%2==0?"":"class='even'" %>>
                <td>
                    <%=v.Loginname %>
                </td>
                <td>
                    <%=v.Usermobile %>
                </td>
                <td>
                    <%=v.Username %>
                </td>
                <td>
                    <%=GetUserType(v.Usertype)%>
                </td>
                <td>
                    <%=GetUserState(v.Accountdtate)%>
                </td>
                <td>
                    <%=GetDepartName(v.Departcode.ToString()) %>
                </td>
                <td>
                    <%=v.Adddate %>
                </td>
                <td>
                    <a href="/bussiness/users/useredit.aspx?action=edit&id=<%=v.Id %>" class="btn btn-mini btn-danger">
                        修改</a> <a href="javascript:;" onclick="delemodel('<%=v.Id %>','user')" class="btn btn-mini btn-danger">
                            删除</a>
                </td>
            </tr>
            <%}
              } %>
            <tr class="tr_pagenumber">
                <td colspan="8">
                    <div id="PageContent" runat="server">
                    </div>
                </td>
            </tr>
        </tbody>
    </table>
</body>
</html>
