<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="TX_Bussiness.Web.login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>后台管理系统</title>
    <link rel="stylesheet" type="text/css" href="/bussiness/Styles/base.css" />
    <link rel="stylesheet" type="text/css" href="/bussiness/Styles/admin-all.css" />
    <link rel="stylesheet" type="text/css" href="/bussiness/Styles/bootstrap.min.css" />
    <script type="text/javascript" src="/bussiness/Scripts/jquery-1.7.2.js"></script>
    <script type="text/javascript" src="/bussiness/Scripts/jquery.spritely-0.6.js"></script>
    <script type="text/javascript" src="/bussiness/Scripts/chur.min.js"></script>
     <script type="text/javascript" src="/bussiness/Scripts/ChurAlert.min.js?skin=blue"></script>
    <script type="text/javascript" src="/bussiness/Scripts/chur-alert.1.0.js"></script>
     <link rel="stylesheet" type="text/css" href="/bussiness/Styles/chur.css" />
    <link rel="stylesheet" type="text/css" href="/bussiness/Styles/login.css" />
</head>
<body>
<form action="login.aspx" method="post">
    <div id="clouds" class="stage"></div>
    <div class="loginmain">
    </div>

    <div class="row-fluid">
        <h1>后台管理系统</h1>
        <p>
            <label>帐&nbsp;&nbsp;&nbsp;号：<input type="text" name="username" id="uid" /></label>
        </p>
        <p>
            <label>密&nbsp;&nbsp;&nbsp;码：<input type="password" name="password" id="pwd" /></label>
        </p>
        <p class="pcode">
            <label>效验码：<input type="text" id="code" maxlength="5" class="code" value="e5g88" /><img src="/bussiness/img/code.gif" alt="" class="imgcode" /><a href="#">下一张</a></label>
        </p>
        <p class="tip">&nbsp;</p>
        <hr />
        <input type="submit" value=" 登 录 " class="btn btn-primary btn-large login" />
        &nbsp;&nbsp;&nbsp;<input type="reset" value=" 取 消 " class="btn btn-large" />
    </div>
    </form>
</body>
</html>