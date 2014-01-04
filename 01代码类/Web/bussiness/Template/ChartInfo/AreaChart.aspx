﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AreaChart.aspx.cs" Inherits="TX_Bussiness.Web.bussiness.Template.ChartInfo.AreaChart" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="/bussiness/Styles/bootstrap.min.css" />
    <link rel="stylesheet" type="text/css" href="/bussiness/Styles/admin-all.css" />
    <script type="text/javascript" src="/bussiness/Scripts/jquery-1.7.2.js"></script>
    <script type="text/javascript" src="/bussiness/Scripts/jquery-ui-1.8.22.custom.min.js"></script>
    <link rel="stylesheet" type="text/css" href="/bussiness/Styles/ui-lightness/jquery-ui-1.8.22.custom.css" />
    <script type="text/javascript" src="/bussiness/Scripts/tip.js"></script>
    <script type="text/javascript" src="/js/json2.js"></script>
    <script src="/js/global.js" type="text/javascript"></script>
    <script type="text/javascript" src="/bussiness/Scripts/ChurAlert.min.js?skin=blue"></script>
    <script type="text/javascript" src="/bussiness/Scripts/chur-alert.1.0.js"></script>
    <script src="/Charts/FusionCharts.js" type="text/javascript"></script>
    <script src="/Charts/FusionChartsExportComponent.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            $(".datepicker").datepicker();
        })
    </script>
</head>
<body>
    <div>
    </div>
    <div class="alert alert-info tit">
        当前位置<b class="tip"></b>统计界面<b class="tip"></b>区域统计</div>
    <form action="/bussiness/template/chartinfo/areachart.aspx" method="get">
    <table class="table table-striped table-bordered table-condensed c_table">
        <thead>
            <tr>
                <td colspan="12" class="auto-style2">
                    &nbsp;请填写查询条件
                </td>
            </tr>
        </thead>
        <tbody>
            <tr>
                <td class="t_label">
                    统计类型
                </td>
                <td class="detail">
                    <select size="1" name="txt_infotype" id="Select4">
                        <option value="1" <%=txt_infotype=="1"?"selected=selected":"" %>>区域</option>
                        <option value="2" <%=txt_infotype=="2"?"selected=selected":"" %>>街道</option>
                        <option value="3" <%=txt_infotype=="3"?"selected=selected":"" %>>社区</option>
                    </select>
                </td>
                <td class="t_label">
                    区域
                </td>
                <td class="detail">
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
                </td>
                <td class="t_label">
                    街道
                </td>
                <td class="td_detail">
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
                </td>
                <td class="t_label">
                    社区
                </td>
                <td>
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
                </td>
                <td class="t_label">
                    录入日期起
                </td>
                <td colspan="3">
                    <div class="input-append">
                        <input class="span2 datepicker" size="16" type="text" id="startime" name="txt_startdate"
                            value="<%=txt_startdate %>" /><span class="add-on"><i class="icon-calendar"></i></span>至<input
                                id="endtime" class="span2 datepicker" name="txt_enddate" size="16" type="text"
                                value="<%=txt_enddate %>" /><span class="add-on"><i class="icon-calendar"></i></span>
                    </div>
                </td>
            </tr>
            <tr>
                <td class="t_label">
                    图表类型
                </td>
                <td>
                    <select size="1" name="txt_charttype" id="Select5">
                        <option value="1" <%=txt_charttype=="1"?"selected=selected":"" %>>线形图</option>
                        <option value="2" <%=txt_charttype=="2"?"selected=selected":"" %>>柱状图</option>
                        <option value="3" <%=txt_charttype=="3"?"selected=selected":"" %>>饼状图</option>
                    </select>
                </td>
                <td class="t_label">
                    图表样式
                </td>
                <td>
                    <select size="1" name="txt_chartstyle" id="Select6">
                        <option value="1" <%=txt_chartstyle=="1"?"selected=selected":"" %>>2D</option>
                        <option value="2" <%=txt_chartstyle=="2"?"selected=selected":"" %>>3D</option>
                    </select>
                </td>
                <td colspan="9" align="right">
                    <input class="btn btn-inverse" id="find" type="submit" value="查询" />
                    <input class="btn btn-inverse" type="reset" id="reset" value="清空" />
                </td>
            </tr>
        </tbody>
    </table>
    </form>
    <div style="position:relative;">
        <div style="position: absolute; width: 200px; height: 30px; background-color: white; top:0; left:0;" id="exproterDiv">
        </div>
    <div id="chartdiv" align="center">
        Chart will load here</div>
        </div>
    <script type="text/javascript">
        var chart = new FusionCharts("<%=chartpath %>", "ChartId_flash", "100%", "400", "0", "1");
        chart.setDataURL("<%=chartdatapath%>");
        chart.render("chartdiv");
         <script type="text/javascript">
            var chart = new FusionCharts("<%=chartpath %>", "ChartId_flash", "100%", "400", "0", "1");
            chart.setDataURL("<%=chartdatapath%>");
            chart.render("chartdiv");

            var myExportComponent = new FusionChartsExportObject("fcExporter1", "/charts/chart/FCExporter.swf"); //参数1：为处理程序标识，参数二为：上文中提到的导出需要用到的swf文件
            myExportComponent.componentAttributes.btnColor = 'EAF4FD';
            myExportComponent.componentAttributes.btnBorderColor = '0372AB';
            myExportComponent.componentAttributes.btnFontFace = 'Verdana';
            myExportComponent.componentAttributes.btnFontColor = '0372AB';
            myExportComponent.componentAttributes.btnFontSize = '12';
            //Title of button
            myExportComponent.componentAttributes.btnsavetitle = '另存为'
            myExportComponent.componentAttributes.btndisabledtitle = '右键生成图片';
            myExportComponent.Render("exproterDiv");
    </script>
</body>
</html>
