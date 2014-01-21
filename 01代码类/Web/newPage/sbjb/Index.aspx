<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="TX_Bussiness.Web.newPage.sbjb.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>桐乡市城市管理行政执法局勤务信息平台--上报交办系统</title>
    <link rel="stylesheet" type="text/css" href="../style/css/reset.css" />
    <link rel="stylesheet" type="text/css" href="../style/css/index.css" />
    <link id="skin" rel="stylesheet" href="../style/Blue/jbox.css" />
    <script src="../js/jquery-1.6.1.js" type="text/javascript"></script>
    <script src="../My97DatePicker/WdatePicker.js" type="text/javascript"></script>
    <script type="text/javascript" src="../js/popup_layer.js"></script>
    <script type="text/javascript" src="../js/jquery.jBox.src.js"></script>
     <script src="/Charts/FusionCharts.js" type="text/javascript"></script>
      <script src="/Charts/FusionChartsExportComponent.js" type="text/javascript"></script>
    <script type="text/javascript" src="../js/public.js"></script>
     <script src="/newpage/My97DatePicker/WdatePicker.js" type="text/javascript"></script>
 <script type="text/javascript">
     $(function () {
         create_sbjbmenu("首 页");
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
         $("#exprot").click(function () {
             var form = $("form");
             $("#expportexcel").val("1");
             $("form").submit();
             $("#expportexcel").val("0");
         });
     })
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <!--header start-->
            <%if (CheckRole(GetUserInfo().Id, TX_Bussiness.Web.Comm.Constant.RoleCode_JLD))
          {%>
        <div class="header"style="background: rgb(62, 120, 186) url(/newpage/style/img/header.png) no-repeat left 0;">
        <%}
          else
          { %>
            <div class="header"style="background: rgb(62, 120, 186) url(/newpage/style/img/header_qwss.png) no-repeat left 0;">
        <%} %>
        <div class="loginname">欢迎您：<font><%=GetUserInfo().Loginname %></font></div>
               <div class="welcome">
                 <a class="close" href="/main.aspx">返回</a><a class="off" href="/bussiness/index.aspx?action=exit">退出</a></div>
                <div class="nav" id="menu">
                    <ul class="left">
                        <li class="cur"><a href="/newPage/sbjb/Index.aspx">首 页</a></li>
                        <li><a href="/newpage/sbjb/rwcl.aspx">任务处理</a></li>
                        <li ><a href="/newpage/sbjb/rwcx.aspx">任务查询</a></li>
                        <li><a href="#">知识库</a></li>
                        <li><a href="#">帮助</a></li>
                    </ul>
                </div>
            </div>
            <!--header end-->
            <div class="tip">当前位置：<a href="#">首页</a> ></div>
            <!--content start-->
            <div class="col_lh220">
                <div class=" title_col_l">
                    最新待办任务
                </div>
                <div class="text_con">
                    <ul>
                    <%foreach( var v in projectlist){ %>
                        <li><span>[<%=v.Adddate %>]</span><a href="/newpage/sbjb/banli.aspx?projcode=<%=v.Projcode %>" target="_blank"><%=String.Format(GetAppSeeting("ProjectNameTemplate"), v.Projcode)%></a></li>
                       <%} %>
                        
                    </ul>
                </div>
            </div>
            <div class="col_rh220">
                <div class=" title_col_r">
                    城管动态
                </div>
                <div class="text_con" style="padding: 0px">


                   <%--     <div name="pic" style="float: left; position: relative; overflow: hidden;">
                        <div>
                            <img width="100%" height="192" src="Chrysanthemum.jpg" alt="1" /></div>
                        <div>
                            <img width="100%" height="192" src="Desert.jpg" alt="2" /></div>
                        <div>
                            <img width="100%" height="192" src="Hydrangeas.jpg" alt="3" /></div>
                    </div>
                </div>--%>
                   <div id="ibanner">
                        <div id="pic">
                            <a class="img" href="#">
                                <img src="/tximage/ShowImage.jpg" alt="杭州市物价局通报党组专题民主生活会情况" width="100%" height="192" />
                               <!-- <span>杭州市物价局通报党组专题民主生活会情况</span></a> -->
                            <a class="img" href="#">
                                <img src="/tximage/ShowImage1.jpg" alt="杨市长再次来我局指导调研群众路线教育实" width="100%" height="192" />
                                <!--  <span>杨市长再次来我局指导调研群众路线教育实</span></a>-->
                            <a class="img" href="#">
                                <img src="/tximage/ShowImage2.jpg" alt="中国经贸导刊全国宣传工作会议在我市召开" width="100%"  height="192" />
                               <!--   <span>中国经贸导刊全国宣传工作会议在我市召开</span></a>-->
                            <a class="img" href="#">
                                <img src="/tximage/ShowImage4.jpg" alt="市物价局召开全市“行政执法提升年”活动" width="100%"  height="192" />
                               <!--   <span>市物价局召开全市“行政执法提升年”活动</span></a> -->
                        </div>
                    </div>

                <div class="clear">
               
                </div>
            </div>
                </div>
            <div class="col_l h_420" style="padding: 0px">
                <div class=" title_col_l">
                    统计分析
                </div>
                <div class="text_con" style="overflow: hidden; padding: 0px; width: 100%">
                    <%--<iframe src="QueryStatistics/QyChart1.aspx" frameborder="0" width="" style="width: 100%; height: 375px"
                        scrolling="no"></iframe>--%>
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
                     图表类型
                                <select size="1" name="txt_charttype" id="Select5">
                                    <option value="1" <%=txt_charttype=="1"?"selected=selected":"" %>>线形图</option>
                                    <option value="2" <%=txt_charttype=="2"?"selected=selected":"" %>>柱状图</option>
                                    <option value="3" <%=txt_charttype=="3"?"selected=selected":"" %>>饼状图</option>
                                </select>
                                图表样式
                                <select size="1" name="txt_chartstyle" id="Select6">
                                    <option value="1" <%=txt_chartstyle=="1"?"selected=selected":"" %>>2D</option>
                                    <option value="2" <%=txt_chartstyle=="2"?"selected=selected":"" %>>3D</option>
                                </select>
                          录入日期起
                            <input class="span2 datepicker"  onclick="WdatePicker()" size="16" type="text" id="startime" name="txt_startdate"  value="<%=txt_startdate %>"/><span
                            class="add-on"><i class="icon-calendar"></i></span>至<input  onclick="WdatePicker()" id="endtime" class="span2 datepicker"
                                name="txt_enddate" size="16" type="text" value="<%=txt_enddate %>"/><span class="add-on"><i class="icon-calendar"></i></span>
                  <input class="ip_btn" type="submit" value="查询" />
                    <a class="btn btn-primary" href="javascript:;" id="exprot">导出Excel</a>
                          <div style="position: relative;">
                                <div style="position: absolute; width: 200px; height: 30px; background-color: white;
                                    top: 0; left: 0;" id="exproterDiv">
                                </div>
                                <div id="chartdiv" align="center">
                                    Chart will load here</div>
                            </div>
               <script type="text/javascript">
                   var chart = new FusionCharts("<%=chartpath %>", "ChartId_flash", "100%", "400", "0", "1");
                   chart.setDataURL("<%=chartdatapath%>");
                   chart.render("chartdiv");
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
              </div>
                </div>
            </div>
            <div class="other">
                <div class="col_r h_202">
                    <div class=" title_col_r">
                        执法动态
                    </div>
                    <div class="text_con">
                        <ul>
                            <li><span>[01-14]</span><a href="#">城管执法动态2014年第5期(总第560期)</a></li>
                            <li><span>[01-14]</span><a href="#">城管执法动态2014年第4期(总第559期)</a></li>
                            <li><span>[01-14]</span><a href="#">城管执法动态2014年第3期(总第558期)</a></li>
                            <li><span>[01-08]</span><a href="#">城管执法动态2014年第2期(总第557期)</a></li>
                            <li><span>[01-08]</span><a href="#">城管执法动态2014年第1期(总第556期)</a></li>
                            <li><span>[12-26]</span><a href="#">城管执法动态2013年第64期(总第555期)</a></li>
                        </ul>
                    </div>
                </div>
                <div class="col_r h_206">
                    <div class=" title_col_r">
                        法律法规
                    </div>
                    <div class="text_con">
                        <ul>
                            <li><span>[05-17]</span><a href="#">嘉兴市区城市管理行政执法程序规定</a></li>
                            <li><span>[04-04]</span><a href="#">关于深化规范化（星级）中队评创工作实施意见的通知</a></li>
                            <li><span>[11-15]</span><a href="#">关于印发嘉兴市城市管理行政执法局规范行政处罚裁量权实施办法的通知</a></li>
                            <li><span>[09-01]</span><a href="#">关于印发推广说理式行政处罚决定书实施意见的通知</a></li>
                            <li><span>[08-02]</span><a href="#">关于印发嘉兴市城市管理行政执法案卷评查标准和办案能手评选办法的通知</a></li>
                            <li><span>[06-21]</span><a href="#">关于印发行政处罚自由裁量权案件集体讨论等三个制度的通知</a></li>
                        </ul>
                    </div>
                </div>
            </div>
            <div class="clear">
            </div>
    </form>


    <script type="text/javascript">
        var t;
        var speed = 3;//图片切换速度 
        var nowlan = 0;//图片开始时间 
        function changepic() {
            var imglen = $("div[id='pic']").find("a").length;
            $("div[id='pic']").find("a").fadeOut();
            $("div[id='pic']").find("a").eq(nowlan).fadeIn();
            nowlan = nowlan + 1 == imglen ? 0 : nowlan + 1;
            t = setTimeout("changepic()", speed * 1000);
        }
        onload = function () { changepic(); }
        $(document).ready(function () {
            //鼠标在图片上悬停让切换暂停 
            $("div[id='pic']").hover(function () { clearInterval(t); });
            //鼠标离开图片切换继续 
            $("div[id='pic']").mouseleave(function () { changepic(); });
        });

    </script>
</body>
</html>



