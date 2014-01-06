<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="projectdetail.aspx.cs"
    Inherits="TX_Bussiness.Web.bussiness.Template.projectdetail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title></title>
    <link rel="stylesheet" type="text/css" href="../Styles/bootstrap.min.css" />
    <link rel="stylesheet" type="text/css" href="../Styles/admin-all.css" />
    <link href="/bussiness/Styles/base.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../Scripts/jquery-1.7.2.js"></script>
    <script type="text/javascript" src="../Scripts/jquery-ui-1.8.22.custom.min.js"></script>
    <link rel="stylesheet" type="text/css" href="../Styles/ui-lightness/jquery-ui-1.8.22.custom.css" />
    <script type="text/javascript" src="../Scripts/ChurAlert.min.js?skin=blue"></script>
    <script type="text/javascript" src="../Scripts/chur-alert.1.0.js"></script>
    <script src="/bussiness/js/global.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            $('.modal').show();

        })
    </script>
</head>
<body>
    <form name="form1" action="/bussiness/template/projectedit.aspx" method="post">
    <div class="alert alert-info tit">
        当前位置<b class="tip"></b>维护界面<b class="tip"></b>案卷详情</div>
    <table class="table table-striped table-bordered table-condensed list">
        <thead>
            <tr>
                <td colspan="4">
                    <b>案卷基本信息</b>
                </td>
            </tr>
        </thead>
        <tbody>
            <tr>
                <td width="15%">
                    勤务编号<font color="FF0000">*</font>
                    <input type="hidden" name="projcode" value="<%=model.Projcode %>" />
                </td>
                <td width="500">
                    <%=string.Format(GetAppSeeting("ProjectNameTemplate"),model.Projcode)%>
                </td>
                <td>
                    处理部门<font color="FF0000">*</font>
                </td>
                <td>
                    <%=GetDepartName( model.Departcode)%>
                </td>
            </tr>
            <tr>
                <td>
                    区域<font color="FF0000">*</font>
                </td>
                <td>
                    <%=GetAreaName(model.Areacode) %>
                </td>
                <td>
                    街道<font color="FF0000">*</font>
                </td>
                <td>
                    <%=GetStreetName(model.Streetcode) %>
                </td>
            </tr>
            <tr>
                <td>
                    社区<font color="FF0000">*</font>
                </td>
                <td>
                    <%=GetCommName(model.Communitycode )%>
                </td>
                <td>
                    大类<font color="FF0000">*</font>
                </td>
                <td>
                    <%=model.Bigclassname %>
                </td>
            </tr>
            <tr>
                <td>
                    小类<font color="FF0000">*</font>
                </td>
                <td>
                    <%=model.Smallclassname %>
                </td>
                <td>
                    勤务员<font color="FF0000">*</font>
                </td>
                <td>
                    <%=model.Handlername %>
                </td>
            </tr>
            <tr>
                <td width="15%">
                    录入时间<font color="FF0000">*</font>
                </td>
                <td>
                    <%=model.Adddate %>
                </td>
                </td>
                <td width="500">
                    城管通号
                </td>
                <td width="500">
                   
                </td>
            </tr>
            <tr>
                <td width="15%">
                    事发地址
                </td>
                <td width="500" colspan="3" height="">
                    <%=model.Address %>
                </td>
            </tr>
            <tr>
                <td width="15%">
                    案卷描述
                </td>
                <td width="500" colspan="3" height="">
                    <%=model.Describe %>
                </td>
            </tr>
        </tbody>
        <tfoot>
            <tr>
                <td colspan="2">
                    处理前的信息
                </td>
                <td colspan="2">
                    处理后的信息
                </td>
            </tr>
            <tr>
                <td colspan="2" style="text-align: center;position:relative;">
                    <div class="projimg">
                    <%foreach (var v in imglist.FindAll(x => x.Imgtype == (int)TX_Bussiness.Web.Comm.Enums.ProjectImgType.Before))
                      {%>
                        <img src="<%=v.Imgurl %>" width="300px" height="300px" />
                        <%} %>
                        <span class="prev"></span>
                        <span class="next"></span>
                    </div>
                </td>
                <td colspan="2" style="">
                 <div class="projimg">
                       <%foreach (var v in imglist.FindAll(x => x.Imgtype == (int)TX_Bussiness.Web.Comm.Enums.ProjectImgType.After))
                      {%>
                        <img src="<%=v.Imgurl %>" width="300px" height="300px" />
                        <%} %>
                    </div>
                </td>
            </tr>
        </tfoot>
    </table>
    </form>
</body>
</html>
