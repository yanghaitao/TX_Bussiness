﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="collector_info.aspx.cs"
    Inherits="TX_Bussiness.Web.newPage.qwsj.collector_info" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>桐乡市城市管理行政执法局勤务信息平台--勤务数据系统</title>
    <link rel="stylesheet" type="text/css" href="style/css/reset.css" />
    <link rel="stylesheet" type="text/css" href="style/css/index.css" />
    <script src="/js/jquery-1.8.0.min.js" type="text/javascript"></script>
    <script src="/js/global.js" type="text/javascript"></script>
    <script type="text/javascript" src="/bussiness/Scripts/ChurAlert.min.js?skin=blue"></script>
    <script type="text/javascript" src="/bussiness/Scripts/chur-alert.1.0.js"></script>
    <script src="/newpage/My97DatePicker/WdatePicker.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            $(".collector_info").click(function () {
                var id = $(this).attr("_id");
                if (id && id != "") {
                    $.dialog({
                        title: '案卷流程',
                        content: 'url:/bussiness/Template/collector_info_detail.aspx?starttime=' + $("#startime").val() + '&endtime=' + $("#endtime").val() + '&id=' + id,
                        lock: true,
                        okVal: '关闭',
                        ok: true,
                        width: 788,
                        height: 550,
                        //cancelVal: '叉掉',
                        cancel: true /*为true等价于function(){}*/
                    });
                }
            })
        });
    </script>
</head>
<body>
    <!--header start -->
    <div class="header" style="position: relative;">
        <div style="position: absolute; height: 41px; right: 100px; top: 23px; color: White;
            font-size: 18px;">
            欢迎您，<%=GetUserInfo().Loginname %>!
        </div>
        <div class="layout">
            <div class="logo">
                <h1 style="line-height: 67px; font-size: 30px; color: White; margin-left: 30px;">
                    勤务数据系统</h1>
            </div>
            <div class="top_menu">
                <a class="lock" href="/bussiness/index.aspx?action=exit" title="注销"></a><a class="close"
                    href="/bussiness/index.aspx?action=exit" title="退出"></a><a class="off" href="/main.aspx"
                        title="返回主界面"></a>
            </div>
        </div>
        <div class="nav">
            <ul class="left">
                <li class="cur"><a href="/newpage/qwsj/area_info.aspx">
                    勤务统计</a></li><li><a href="/newpage/qwsj/areachart.aspx">图表统计</a></li><li><a href="#">
                        知识库</a></li>
                <li><a href="#">帮助</a></li>
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
                        <form action="/newpage/qwsj/collector_info.aspx" method="get" class="valifrom">
                        <div class="ip_list">
                            部门：<select size="1" name="txt_depart" id="bumen">
                                <option value="0">全部</option>
                                <%foreach (var v in Departlist())
                                  {
                                      if (v.Departname != "")
                                      { %>
                                <option value="<%=v.Id %>" <%=txt_depart==v.Id.ToString()?"selected=selected":"" %>>
                                    <%=v.Departname %></option>
                                <%}
                          }%>
                            </select>
                            录入日期起
                            <input onclick="WdatePicker()" class="span2 datepicker" size="16" type="text" id="startime"
                                name="txt_startdate" value="<%=txt_startdate %>" /><span class="add-on"><i class="icon-calendar"></i></span>至<input
                                    id="endtime" class="span2 datepicker" onclick="WdatePicker()" name="txt_enddate"
                                    size="16" type="text" value="<%=txt_enddate %>" /><span class="add-on"><i class="icon-calendar"></i></span>
                            <input class="ip_btn" type="submit" value="查询" />
                        </div>
                        </form>
                        <table width="100%" class="tb_a" border="0" cellpadding="0" cellspacing="0" style="border-top: 1px solid #d6d6d6;">
                            <tr>
                                <td>
                                    姓名
                                </td>
                                <td>
                                    工作量
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
                                    <a href="javascript:;">
                                        <%=v.Username%>
                                    </a>
                                </td>
                                <td>
                                    <%=GetCollectorCount(v.Id)%>
                                </td>
                                <td>
                                    <a href="javascript:;" class="preview btn btn-mini btn-primary add collector_info"
                                        _id="<%=v.Id%>">查看详细 </a>
                                </td>
                            </tr>
                            <%i++;
                  }
              } %>
                        </table>
                    </div>
                    <!--page start-->
                    <div class="page">
                        <div id="PageContent" runat="server">
                        </div>
                    </div>
                    <!--page end-->
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
                    数据统计</div>
                <div class="menu_con">
                    <ul>
                        <li><a href="/newpage/qwsj/area_info.aspx">区域统计</a></li>
                        <li class="cur"><a href="/newpage/qwsj/collector_info.aspx">人员统计</a></li>
                        <li><a href="/newpage/qwsj/depart_info.aspx">部门统计</a></li>
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
