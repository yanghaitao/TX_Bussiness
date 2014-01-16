<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Collector_Info_Detail.aspx.cs" Inherits="TX_Bussiness.Web.bussiness.Template.Collector_Info_Detail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title></title>
    <link rel="stylesheet" type="text/css" href="../Styles/bootstrap.min.css" />
    <link rel="stylesheet" type="text/css" href="../Styles/admin-all.css" />
    <script type="text/javascript" src="../Scripts/jquery-1.7.2.js"></script>
    <script type="text/javascript" src="../Scripts/jquery-ui-1.8.22.custom.min.js"></script>
    <link rel="stylesheet" type="text/css" href="../Styles/ui-lightness/jquery-ui-1.8.22.custom.css" />
    <script type="text/javascript" src="../Scripts/tip.js"></script>
   
</head>
<body>
    <div>
    </div>
    <div class="alert alert-info tit">
        当前位置<b class="tip"></b>查询界面<b class="tip"></b>查询结果一</div>
    <table class="table table-striped table-bordered table-condensed" id="projlist">
        <thead>
            <tr class="tr_detail">
                <td>
                    勤务编号
                </td>
                <td>
                    上报人
                </td>
                <td>
                    区域
                </td>
                <td>
                    街道
                </td>
                <td>
                    社区
                </td>
                <td>
                    大类
                </td>
                <td>
                    小类
                </td>
                <td>
                    地址
                </td>
                <td>
                    案卷描述
                </td>
                <td>
                    上报时间
                </td>
            </tr>
        </thead>
        <tbody>
            <%if (project_list != null && project_list.Count > 0)
              {
                  int i = 0;
                  foreach (var v in project_list)
                  {%>
            <tr <%=i%2==0?"":"class='even'" %> _projcode="<%=v.Projcode %>">
                <td>
                    <%=String.Format(GetAppSeeting("ProjectNameTemplate"),v.Projcode) %>
                </td>
                <td>
                    <%=v.Reportpersonname %>
                </td>
                <td>
                    <%= GetAreaName(v.Areacode) %>
                </td>
                <td>
                    <%= GetStreetName( v.Streetcode) %>
                </td>
                <td>
                    <%=GetCommName( v.Communitycode) %>
                </td>
                <td>
                    <%=v.Bigclassname %>
                </td>
                <td>
                    <%=v.Smallclassname %>
                </td>
                 <td title="<%=v.Address %>">
                    <%=Bussiness.Common.Utility.CheckStringLength(v.Address,10)%>
                </td>
                <td title="<%=v.Describe %>">
                    <%=Bussiness.Common.Utility.CheckStringLength(v.Describe, 10)%>
                </td>
                <td>
                    <%=v.Adddate %>
                </td>
            </tr>
            <%}
              } %>
            <tr class="tr_pagenumber">
                <td colspan="100">
                    <div id="PageContent" runat="server">
                    </div>
                </td>
            </tr>
        </tbody>
    </table>
</body>
</html>

