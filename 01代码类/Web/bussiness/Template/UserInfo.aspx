<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserInfo.aspx.cs" Inherits="TX_Bussiness.Web.bussiness.Template.UserInfo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title></title>
    <link rel="stylesheet" type="text/css" href="../Styles/bootstrap.min.css" />
    <link rel="stylesheet" type="text/css" href="../Styles/admin-all.css" />
    <script type="text/javascript" src="../Scripts/jquery-1.7.2.js"></script>
    <script type="text/javascript" src="../Scripts/jquery-ui-1.8.22.custom.min.js"></script>
    <link rel="stylesheet" type="text/css" href="../Styles/ui-lightness/jquery-ui-1.8.22.custom.css" />
    <script src="/js/json2.js" type="text/javascript"></script>
    <script src="/js/global.js" type="text/javascript"></script>
       <script type="text/javascript" src="../Scripts/ChurAlert.min.js?skin=blue"></script>
    <script type="text/javascript" src="../Scripts/chur-alert.1.0.js"></script>
    <link rel="stylesheet" type="text/css" href="../Styles/chur.css" />
    <script type="text/javascript">
        $(function () {
            $("#submit").click(function () {
                var userid = "<%=GetUserInfo().Id %>";
                var oldpwd = $("input[name='txt_oldpwd']").val();
                var newpwd = $("input[name='txt_newpwd']").val();
                $.post("/tools/AjaxHandler.ashx", { act: "ChangePassword", uid: userid, oldpwd: oldpwd, newpwd: newpwd }, function (data) {
                    if (data == "1") {
                        $("bordy").alert({
                            type: "success",
                            content: "密码修改成功！"
                        })
                    } else {
                        $("bordy").alert({
                            type: "danger",
                            content: data
                        })
                    }
                })
            })
        })
    </script>
</head>
<body>
    <form>
    <div class="alert alert-info">
        当前位置<b class="tip"></b>维护界面<b class="tip"></b>修改密码</div>
    <table class="table table-striped table-bordered table-condensed list">
        <thead>
            <tr>
                <td colspan="2">
                    <b>案卷基本信息</b>
                </td>
            </tr>
        </thead>
        <tbody>
            <tr>
                <td width="15%">
                    旧密码<font color="FF0000">*</font>
                </td>
                <td width="500">
                    <input name="txt_oldpwd" value="" type="password" />
                </td>
            </tr>
            <tr>
                <td width="15%">
                    新密码<font color="FF0000">*</font>
                </td>
                <td width="500">
                    <input name="txt_newpwd" value="" type="password" />
                </td>
            </tr>
        </tbody>
        <tfoot>
            <tr>
                <td colspan="2">
                    <input class="btn btn-inverse" id="submit" type="button" value="保存" />
                    <input class="btn btn-inverse" type="button" value="取消" onclick="window.history.go(-1)" />
                </td>
            </tr>
        </tfoot>
    </table>
    </form>
</body>
</html>
