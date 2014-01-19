<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="lbgl.aspx.cs" Inherits="TX_Bussiness.Web.newPage.yywh.lbgl" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="style/css/reset.css" />
    <link rel="stylesheet" type="text/css" href="style/css/index.css" />
    <script src="/js/jquery-1.8.0.min.js" type="text/javascript"></script>
    <script src="/js/global.js" type="text/javascript"></script>
    <script type="text/javascript" src="/bussiness/Scripts/ChurAlert.min.js?skin=blue"></script>
    <script type="text/javascript" src="/bussiness/Scripts/chur-alert.1.0.js"></script>
    <script src="/newpage/My97DatePicker/WdatePicker.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {

            //$('#list').hide();
            $('#find').click(function () {
                $('#list').show();
            })
            //            $('#formid').tooltip({ title: '单据号' });
            //            $('#formtype').tooltip({ title: '单据类型' });
            //            $('#bumen').tooltip({ title: '部门' });
            //            $('#startime').tooltip({ title: '起始日期' });
            //            $('#endtime').tooltip({ title: '结束日期' });
            //            $('#baoxiaoren').tooltip({ title: '报销人' });
            //            $('#xiangmu').tooltip({ title: '所属项目' });

        });

        function showbox(obj) {
            $.dialog({
                title: '我的浏览器',
                content: 'url:/bussiness/Template/ProjectEdit.aspx',
                lock: true,
                okVal: '关了',
                ok: true,
                width: 788,
                height: 550,
                cancelVal: '叉掉',
                button: [{
                    id: 'chur',
                    name: '再来个警告',
                    callback: function () {
                        $('body').alert({
                            type: 'success'
                        });

                    }
                }],
                cancel: true /*为true等价于function(){}*/
            });
        }
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
                    部门管理</a></li><li><a href="/newpage/yywh/jsgl.aspx">角色管理</a></li><li class="cur"><a
                        href="/newpage/yywh/lbgl.aspx">类别管理</a></li>
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
                        <form action="/newpage/yywh/lbgl.aspx" method="get" class="valifrom">
                        <div class="ip_list">
                            类别名称：
                            <input id="formid" name="txt_classname" value="<%=txt_classname %>" />
                            所属类型：
                            <select size="1" name="txt_classcode" id="bumen">
                                <option value="0">全部</option>
                                <%foreach (var v in GetProjectClass(0))
                                  {
                                      if (v.Classname != "")
                                      { %>
                                <option value="<%=v.Id %>" <%=v.Id.ToString()==txt_classcode?"selected='selected'":"" %>>
                                    <%=v.Classname %></option>
                                <%}
                          }%>
                            </select>
                            <select size="1" name="txt_bigclass" id="Select1">
                                <option value="0">无</option>
                                <%=!string.IsNullOrEmpty(txt_bigclass)&&txt_bigclass != "0" ? "<option value='" + txt_bigclass + "'>"+GetClassName(txt_bigclass)+"</option>" : ""%>
                            </select>
                            <a href="/newPage/yywh/lbedit.aspx?action=add" class="btn btn-primary btn-small"
                                id="primary">
                                <input type="button" class="ip_btn" value="添加" /></a>
                            <input class="ip_btn" id="find" type="submit" value="查询" />
                            <input class="ip_btn" type="reset" id="reset" value="清空" />
                        </div>
                        </form>
                        <table width="100%" class="tb_a" border="0" cellpadding="0" cellspacing="0" style="border-top: 1px solid #d6d6d6;">
                            <thead>
                                <tr class="w_bg">
                                    <td width="20%">
                                        类别名称
                                    </td>
                                    <td width="70%">
                                        所属类别
                                    </td>
                                    <td width="70%">
                                        操作
                                    </td>
                                </tr>
                            </thead>
                            <tbody>
                                <%if (projectlist != null && projectlist.Count > 0)
                                  {
                                      int i = 0;
                                      foreach (var v in projectlist)
                                      {%>
                                <tr <%=i%2==0?"":"class='w_bg'" %>>
                                    <td>
                                        <%=v.Classname %>
                                    </td>
                                    <td>
                                        <%=GetClassName(v.Parentid)%>
                                    </td>
                                    <td>
                                        <a href="/newPage/yywh/lbedit.aspx?action=edit&id=<%=v.Id %>" class="btn btn-mini btn-danger">
                                            修改</a> <a href="javascript:;" onclick="delemodel('<%=v.Id %>','projectclass')" class="btn btn-mini btn-danger">
                                                删除</a>
                                    </td>
                                </tr>
                                <%i++;
                  }
              } %>
                                <tr class="tr_pagenumber">
                                    <td colspan="3">
                                        <div id="PageContent" runat="server">
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
                    类别管理</div>
                <div class="menu_con">
                    <ul>
                        <li class="cur"><a href="/newpage/yywh/lbgl.aspx">类别管理</a></li>
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
