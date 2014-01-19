<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="main.aspx.cs" Inherits="TX_Bussiness.Web.main" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>G.net综合信息服务管理平台</title>
    <link rel="stylesheet" href="/css/global.css" type="text/css" />
    <link rel="stylesheet" href="/css/index.css" type="text/css" />
    <link rel="stylesheet" href="/css/menu.css" type="text/css" />
    <link rel="stylesheet" type="text/css" href="/bussiness/Styles/bootstrap.min.css" />
    <script type="text/javascript" src="/js/jquery-1.8.0.min.js"></script>
    <script src="/js/cfcoda.js" language="javascript"></script>
    <script src="/js/time.js" language="javascript"></script>
    <script type="text/javascript" src="/bussiness/Scripts/ChurAlert.min.js?skin=blue"></script>
    <script type="text/javascript" src="/bussiness/Scripts/chur-alert.1.0.js"></script>
    <link rel="stylesheet" type="text/css" href="/bussiness/Styles/chur.css" />
    <!--[if lt IE 7]>       
 <script src="js/fixPNG.js"></script>         
 <script>
 DD_belatedPNG.fix('img,.nav ul li a,.nav ul li a:hover');
 </script>     
<![endif]-->
    <link href="/css/lanrenzhijia.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        function CheckLimit(userid, sysname) {
            $.post("/tools/AjaxHandler.ashx", { act: "CheckLimit", userid: userid, system: sysname }, function (data) {
                if (data == "1") {
                    if (sysname == "sbjb" || sysname == "qwss") {
                        window.parent.location.href = "/newpage/sbjb/index.aspx";
                    }
                    if (sysname == "qwsj") {
                        window.parent.location.href = "/newpage/qwsj/area_info.aspx";
                    }
                    if (sysname == "yywh") {
                        window.parent.location.href = "/newpage/yywh/rygl.aspx";
                    }
                } else {
                    $('body').alert({
                        type: "primary"
                    })
                }
            })

        }
    </script>
</head>
<body>
    <!-- content -->
    <div style="position: relative;">
        <div id="frame">
            <div id="scroller">
                <div id="content">
                    <div class="section" id="pane-0">
                        <div class="page1">
                            <div class="content">
                                <div class="first_screen">
                                    <div class="date" id="currentime">
                                    </div>
                                    <div class="welcome_wz">
                                        <img src="images/top.png" /></div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="clear">
            </div>
            <!-- -->
            <div class="main_desktop">
                <ul class="desktop_wrap">
                    <li>
                        <p>
                            上报交办系统</p>
                        <a href="#" onclick="CheckLimit('<%=model.Id %>','sbjb')">
                            <img src="images/icon_15.png" width="64" height="62" /></a></li>
                    <li>
                        <p>
                            勤务实时系统</p>
                        <a href="#" onclick="CheckLimit('<%=model.Id %>','qwss')">
                            <img src="images/icon_6.png" width="64" height="57" /></a></li>
                    <li>
                        <p>
                            勤务数据系统</p>
                        <a href="#" onclick="CheckLimit('<%=model.Id %>','qwsj')">
                            <img src="images/icon_3.png" width="60" height="58" /></a></li>
                    <li>
                        <p>
                            人员定位系统</p>
                        <a href="#" onclick="CheckLimit('<%=model.Id %>','rydw')">
                            <img src="images/icon_4.png" width="56" height="58" /></a></li>
                    <li>
                        <p>
                            应用维护系统</p>
                        <a href="#" onclick="CheckLimit('<%=model.Id %>','yywh')">
                            <img src="images/icon_10.png" width="61" height="63" /></a></li>
                </ul>
            </div>
        </div>
    </div>
</body>
</html>
