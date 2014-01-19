<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="rygl.aspx.cs" Inherits="TX_Bussiness.Web.newPage.yywh.rygl" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>header</title>
    <link rel="stylesheet" type="text/css" href="style/css/reset.css" />
    <link rel="stylesheet" type="text/css" href="style/css/index.css" />
    <script src="/js/jquery-1.8.0.min.js" type="text/javascript"></script>
    <script src="/js/global.js" type="text/javascript"></script>
    <script type="text/javascript" src="/bussiness/Scripts/ChurAlert.min.js?skin=blue"></script>
    <script type="text/javascript" src="/bussiness/Scripts/chur-alert.1.0.js"></script>
    <script src="/newpage/My97DatePicker/WdatePicker.js" type="text/javascript"></script>
    <script type="text/javascript">
        $("#info2").click(function () {
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
                <li class="cur"><a href="/newpage/yywh/rygl.aspx">人员管理</a></li><li><a href="/newpage/yywh/bmgl.aspx">
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
                    <div class="search_data">
                        <form action="/newpage/yywh/rygl.aspx" method="get" class="valifrom">
                        <div class="ip_list">
                            姓名：
                            <input id="formid" name="txt_username" value="<%=txt_username %>" />
                            用户类型
                            <select size="1" name="txt_usertype" id="Select2">
                                <option value="0">全部用户</option>
                                <option value="1" <%=txt_usertype=="1"?"selected='selected'":"" %>>普通用户</option>
                                <option value="2" <%=txt_usertype=="2"?"selected='selected'":"" %>>城管通用户</option>
                            </select>
                            所属部门
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
                            <input class="ip_btn" id="find" type="submit" value="查询" />
                            <input class="ip_btn" type="reset" id="reset" value="清空" />
                        </div>
                        </form>
                        <table width="100%" class="tb_a" border="0" cellpadding="0" cellspacing="0" style="border-top: 1px solid #d6d6d6;">
                            <tr class="w_bg">
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
                            <%if (userlist != null && userlist.Count > 0)
                              {
                                  int i = 0;
                                  foreach (var v in userlist)
                                  {%>
                            <tr <%=i%2==0?"":"class='w_bg'" %>>
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
                                    <a href="/newPage/yywh/ryedit.aspx?action=edit&id=<%=v.Id %>" class="btn btn-mini btn-danger">
                                        修改</a> <a href="javascript:;" onclick="delemodel('<%=v.Id %>','user')" class="btn btn-mini btn-danger">
                                            删除</a>
                                </td>
                            </tr>
                            <%i++;
                                  }
                              } %>
                            <tr class="tr_pagenumber">
                                <td colspan="8">
                                    <div id="PageContent" runat="server">
                                    </div>
                                </td>
                            </tr>
                        </table>
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
                    人员管理</div>
                <div class="menu_con">
                    <ul>
                        <li class="cur"><a href="/newpage/yywh/rygl.aspx">人员管理</a></li>
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
