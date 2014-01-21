<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="TX_Bussiness.Web.newPage.qwsj.index" %>

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
            $(".area_info").click(function () {
                var id = $(this).attr("_id");
                var areatype = $("select[name='txt_infotype']").val();
                if (id && id != "") {
                    $.dialog({
                        title: '案卷流程',
                        content: 'url:/bussiness/Template/area_info_detail.aspx?starttime=' + $("#startime").val() + '&endtime=' + $("#endtime").val() + '&id=' + id + "&areatype=" + areatype,
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
        })
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
                <li class="cur"><a href="/newpage/qwsj/index.aspx">首页</a></li><li><a href="/newpage/qwsj/area_info.aspx">
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
                        <form action="/newpage/qwsj/area_info.aspx" method="get" class="valifrom">
                        <div class="ip_list">
                            统计类型：
                            <select size="1" name="txt_infotype" id="Select4">
                                <option value="1" <%=txt_infotype=="1"?"selected=selected":"" %>>区域</option>
                                <option value="2" <%=txt_infotype=="2"?"selected=selected":"" %>>街道</option>
                                <option value="3" <%=txt_infotype=="3"?"selected=selected":"" %>>社区</option>
                            </select>
                            区域
                            <select size="1" name="txt_area" id="Select2">
                                <option value="0">全部</option>
                                <%foreach (var v in Arealist())
                                  {
                                      if (!string.IsNullOrEmpty(v.Areaname))
                                      { %>
                                <option value="<%=v.Areacode %>" <%=txt_area==v.Areacode.ToString()?"selected=selected":"" %>>
                                    <%=v.Areaname %></option>
                                <%}
                          }%>
                            </select>
                            街道
                            <select size="1" name="txt_street" id="Select3">
                                <option value="0">全部</option>
                                <%foreach (var v in Streettlist())
                                  {
                                      if (!string.IsNullOrEmpty(v.Streetname))
                                      { %>
                                <option value="<%=v.Streetcode %>" <%=txt_street==v.Streetcode.ToString()?"selected=selected":"" %>>
                                    <%=v.Streetname %></option>
                                <%}
                          }%>
                            </select>
                            社区
                            <select size="1" name="txt_commnuity" id="Select1">
                                <option value="0">全部</option>
                                <%foreach (var v in Communitylist())
                                  {
                                      if (!string.IsNullOrEmpty(v.Commname))
                                      { %>
                                <option value="<%=v.Commcode %>" <%=txt_commnuity==v.Commcode.ToString()?"selected=selected":"" %>>
                                    <%=v.Commname %></option>
                                <%}
                              }%>
                            </select>
                            录入日期起
                            <input onclick="WdatePicker()" class="span2 datepicker" size="16" type="text" id="startime"
                                name="txt_startdate" value="<%=txt_startdate %>" /><span class="add-on"><i class="icon-calendar"></i></span>至<input
                                    onclick="WdatePicker()" id="endtime" class="span2 datepicker" name="txt_enddate"
                                    size="16" type="text" value="<%=txt_enddate %>" /><span class="add-on"><i class="icon-calendar"></i></span>
                            <input class="ip_btn" type="submit" value="查询" />
                        </div>
                        </form>
                        <table width="100%" class="tb_a" border="0" cellpadding="0" cellspacing="0" style="border-top: 1px solid #d6d6d6;">
                            <tr>
                                <td>
                                    区域名称
                                </td>
                                <td>
                                    工作量
                                </td>
                                <td>
                                    操作
                                </td>
                            </tr>
                            <%if (txt_infotype == ((int)TX_Bussiness.Web.Comm.Enums.AreaCountType.Area).ToString())
                              { %>
                            <%if (arealist != null && arealist.Count > 0)
                              {
                                  int i = 0;
                                  foreach (var v in arealist)
                                  {%>
                            <tr <%=i%2==0?"":"class='w_bg'" %>>
                                <td>
                                    <a href="javascript:;">
                                        <%=v.Areaname%>
                                    </a>
                                </td>
                                <td>
                                    <%=GetAreacount(v.Areacode, TX_Bussiness.Web.Comm.Enums.AreaCountType.Area)%>
                                </td>
                                <td>
                                    <a href="javascript:;" class="preview btn btn-mini btn-primary add area_info" _id="<%=v.Areacode %>">
                                        查看详细 </a>
                                </td>
                            </tr>
                            <%i++;
                  }
              }
          } %>
                            <%if (txt_infotype == ((int)TX_Bussiness.Web.Comm.Enums.AreaCountType.Street).ToString())
                              { %>
                            <%if (streetlist != null && streetlist.Count > 0)
                              {
                                  int i = 0;
                                  foreach (var v in streetlist)
                                  {%>
                            <tr <%=i%2==0?"":"class='w_bg'" %>>
                                <td>
                                    <a href="javascript:;">
                                        <%=v.Streetname%>
                                    </a>
                                </td>
                                <td>
                                    <%=GetAreacount(v.Streetcode, TX_Bussiness.Web.Comm.Enums.AreaCountType.Street)%>
                                </td>
                                <td>
                                    <a href="javascript:;" class="preview btn btn-mini btn-primary add area_info" _id="<%=v.Streetcode %>">
                                        查看详细 </a>
                                </td>
                            </tr>
                            <%i++;
                  }
              }
                } %>
                            <%if (txt_infotype == ((int)TX_Bussiness.Web.Comm.Enums.AreaCountType.Commnuity).ToString())
                              { %>
                            <%if (commnuitylist != null && commnuitylist.Count > 0)
                              {
                                  int i = 0;
                                  foreach (var v in commnuitylist)
                                  {%>
                            <tr <%=i%2==0?"":"class='w_bg'" %>>
                                <td>
                                    <a href="javascript:;">
                                        <%=v.Commname%>
                                    </a>
                                </td>
                                <td>
                                    <%=GetAreacount(v.Commcode,TX_Bussiness.Web.Comm.Enums.AreaCountType.Commnuity)%>
                                </td>
                                <td>
                                    <a href="javascript:;" class="preview btn btn-mini btn-primary add area_info" _id="<%=v.Commcode %>">
                                        查看详细 </a>
                                </td>
                            </tr>
                            <%i++;
                  }
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
                        <li class="cur"><a href="/newpage/qwsj/area_info.aspx">区域统计</a></li>
                        <li><a href="/newpage/qwsj/collector_info.aspx">人员统计</a></li>
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
