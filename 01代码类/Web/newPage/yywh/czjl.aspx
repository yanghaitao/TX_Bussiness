<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="czjl.aspx.cs" Inherits="TX_Bussiness.Web.newPage.yywh.czjl" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>桐乡市城市管理行政执法局勤务信息平台--应用维护系统</title>
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
                <li><a href="/newpage/yywh/rygl.aspx">人员管理</a></li><li><a href="/newpage/yywh/bmgl.aspx">
                    部门管理</a></li><li><a href="/newpage/yywh/jsgl.aspx">角色管理</a></li><li><a href="/newpage/yywh/lbgl.aspx">
                        类别管理</a></li>
                <li class="cur"><a href="/newpage/yywh/czjl.aspx">操作记录</a></li>
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
                        <table width="100%" class="tb_a" border="0" cellpadding="0" cellspacing="0" style="border-top: 1px solid #d6d6d6;">
                            <thead>
                                <tr class="w_bg">
                                    <td>
                                        日志编号
                                    </td>
                                    <td>
                                        登录名
                                    </td>
                                    <td>
                                        操作说明
                                    </td>
                                    <td>
                                        IP
                                    </td>
                                    <td>
                                        时间
                                    </td>
                                </tr>
                            </thead>
                            <tbody>
                                <%if (loglist != null && loglist.Count > 0)
                                  {
                                      int i = 0;
                                      foreach (var v in loglist)
                                      {%>
                                <tr <%=i%2==0?"":"class='w_bg'" %>>
                                    <td>
                                        <%=v.Id %>
                                    </td>
                                    <td>
                                        <%=v.Loginname %>
                                    </td>
                                    <td>
                                        <%=v.Actionname %>
                                    </td>
                                    <td>
                                        <%=v.Ip%>
                                    </td>
                                    <td>
                                        <%=v.CuDate%>
                                    </td>
                                </tr>
                                <%i++;
                  }
              } %>
                                <tr class="tr_pagenumber">
                                    <td colspan="8">
                                        <div id="PageContent" runat="server" class="page">
                                        </div>
                                    </td>
                                </tr>
                            </tbody>
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
                    操作记录</div>
                <div class="menu_con">
                    <ul>
                        <li class="cur"><a href="/newpage/yywh/czjl.aspx">操作记录</a></li>
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
