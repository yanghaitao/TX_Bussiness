<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="TX_Bussiness.Web.login2.login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">
<html>
<head>
    <meta http-equiv="content-type" content="text/html; charset=utf-8" />
    <link rel="shortcut icon" type="image/ico" href="/images/favicon.ico" />
    <title>Login</title> 
    <link href="styles.css" type="text/css" media="screen" rel="stylesheet" />
    <link href="jquery-ui-1.8.16.custom.css" rel="stylesheet">
    <link rel="stylesheet" type="text/css" href="/bussiness/Styles/chur.css" />
    <script src="jquery-1.6.2.min.js"></script>
    <script src="jquery-ui-1.8.16.custom.min.js"></script>
    <script type="text/javascript" src="jquery.keyboard.extension-typing.js"></script>
    <link type="text/css" href="keyboard.css" rel="stylesheet" />
    <script type="text/javascript" src="jquery.keyboard.js"></script>
    <script type="text/javascript" src="/bussiness/Scripts/ChurAlert.min.js?skin=blue"></script>
    <script type="text/javascript" src="/bussiness/Scripts/chur-alert.1.0.js"></script>
    
</head>
<body id="login">
    <div id="wrappertop">
    </div>
    <div id="wrapper">
        <div id="content">
            <div id="header" style="line-height:50px;text-align:center; ">
                <h1 style="font:bold 20px helvetica, arial, sans-serif;">
                    桐乡市城市管理行政执法局
勤务信息平台
                </h1>
            </div>
            <div id="darkbanner" class="banner320">
                <h2>
                    登陆系统</h2>
            </div>
            <div id="darkbannerwrap">
            </div>
            <form name="form1" action="/login2/login.aspx" method="post">
            <fieldset class="form">
                <p>
                    <label class="loginlabel" for="user_name">
                        用户名:</label>
                    <input class="logininput ui-keyboard-input ui-widget-content ui-corner-all" name="username"
                        id="user_name" type="text" value="" />
                </p>
                <p>
                    <label class="loginlabel" for="user_password">
                        密码:</label>
                    <span>
                        <input class="logininput" name="password" id="user_password" type="password" /><img
                            id="passwd" class="tooltip" alt="Click to open the virtual keyboard" title="Click to open the virtual keyboard"
                            src="keyboard.png" /></span>
                </p>
                <button id="loginbtn" type="button" class="positive" name="Submit">
                    <img src="key.png" alt="Announcement" />登陆</button>
                <ul id="forgottenpassword">
                    <li class="boldtext">|</li>
                    <li>
                        <input id="remember" type="checkbox" name="remember" checked="checked" id="rememberMe"><label for="rememberMe">记住密码</label></li>
                </ul>
            </fieldset>
            </form>
        </div>
    </div>
    <div id="wrapperbottom_branding">
        <div id="wrapperbottom_branding_text">
            <%--  Language:<a href="#" style='text-decoration: none'>Japanese </a>| <a href="#" style='text-decoration: none'>
                English</a>--%></div>
    </div>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#user_password').keyboard({
                openOn: null,
                stayOpen: true,
                layout: 'qwerty'
            }).addTyping();
            $('#passwd').click(function () {
                $('#user_password').getkeyboard().reveal();
            })

            $(".logininput").blur(function () {
                if ($(this).val() == "") {
                    $(this).css("border-color", "red");
                }
                else
                    $(this).css("border-color", "#D9D6C4");
            })

            $("#loginbtn").click(function () {
                var username = $("#user_name").val();
                var password = $("#user_password").val();

                $.post("/tools/AjaxHandler.ashx", { act: "LoginIn", username: username, password: password }, function (data) {
                    if (data && data == "1") {
                        window.location.href = "/main.aspx";
                    }
                    else {
                        alert(data);
                        $("#loginbtn").html("<img src=\"key.png\" alt=\"Announcement\">登陆");
                        $("#loginbtn").attr("disabled", false);
                    }
                })
                var k = 0;
                var ajaxhtml = "";
                $(".logininput").each(function (i, obj) {
                    if ($(obj).val().trim() == "") {
                        k++;
                        $(this).css("border-color", "red");
                        $(this).focus();
                        return false;
                    }
                });
                if (k != 0) return;
                ajaxhtml = $("#loginbtn").html();
                $("#loginbtn").html("正在登陆....  <img src='loading.gif' alt='Announcement' /> ");
                $("#loginbtn").attr("disabled", "disabled");
            })
        });
        
    </script>
</body>
</html>