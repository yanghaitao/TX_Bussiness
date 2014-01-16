<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="TX_Bussiness.Web.login1.login" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>数字城市化管理信息系统</title>
<link rel="stylesheet" type="text/css" href="css/css.css">
</head>
<style>body{background-color:#0D49A2;}</style>
<body>
<form action="login.aspx" method="post">
<div class="main">
    <div class="top">
    <div class="top_ziti">业主单位：桐乡市城市管理局</div>
    </div>
    <div class="zj">
 
         <div class="input">
              <ul>
                   <li><label >用户名:&nbsp;</label><input  type="text" name="username" id="uid"  /></li>
                   <li><label style="letter-spacing:3px;">密码:&nbsp;</label><input  type="password" name="password" id="pwd"  /></li>
              </ul>
         </div>
         <div class=" btn_dr">
         <input type="submit" value="" style="background: url(images/btn_dr.png) no-repeat;width: 100px;height: 26px;display: block; border:none;"/>
         </div>
    </div>
    <div class="wb">
         <div class="ziti">开发单位：XXX</div>
    </div>
</div>
</form>
</body>
</html>
