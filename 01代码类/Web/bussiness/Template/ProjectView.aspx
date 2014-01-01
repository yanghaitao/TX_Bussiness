<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProjectView.aspx.cs" Inherits="TX_Bussiness.Web.bussiness.Template.ProjectView" %>

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
    <script type="text/javascript">
        $(function () {
            $('.modal').show();
        })
    </script>
</head>
<body>
    <div>
    </div>
    <div class="alert alert-info">
        勤务编号:<div style="margin: 0px 20px; display: inline-block;"><%=string.Format(GetAppSeeting("ProjectNameTemplate"), projcode)%>
        </div>
        局属部门:<div style="margin: 0px 20px; display: inline-block;"><%=GetDepart(Convert.ToInt32(model.Reportpersonid))%>
        </div>
        当前阶段:<div style="margin: 0px 20px; display: inline-block;"><%=GetStepName(Convert.ToInt32(model.Projectstate)) %></div>
        </div>
    <table class="table table-striped table-bordered table-condensed" id="projlist">
        <thead>
            <tr class="tr_detail">
                <td>
                    经办人
                </td>
                <td>
                    受理部门
                </td>
                <td>
                    当前操作
                </td>
                <td>
                    意见
                </td>
                <td>
                    受理时间
                </td>
                <td>
                    办理时间
                </td>
            </tr>
        </thead>
        <tbody>
            <%if (tracelist != null && tracelist.Count > 0)
              {
                  int i = 0;
                  foreach (var v in tracelist)
                  {%>
            <tr <%=i%2==0?"":"class='even'" %>>
                <td>
                    <%= v.Operatorname %>
                </td>
                <td>
                    <%= GetDepartName(v.Operatordepart.ToString()) %>
                </td>
                <td>
                    <%=v.Actionname %>
                </td>
                <td>
                    <%= v.Opinion %>
                </td>
                <td>
                    <%= v.Acceptdate %>
                </td>
                <td>
                    <%=v.Operatordate %>
                </td>
            </tr>
            <%}
              } %>
            <tr class="tr_pagenumber">
                <td colspan="6">
                    <div id="PageContent" runat="server">
                    </div>
                </td>
            </tr>
        </tbody>
    </table>
</body>
</html>
