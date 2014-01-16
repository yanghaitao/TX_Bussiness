<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="operation.aspx.cs" Inherits="TX_Bussiness.Web.bussiness.loginfo.operation" %>

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
    <script type="text/javascript" src="/js/json2.js"></script>
    <script src="/js/global.js" type="text/javascript"></script>
    <script type="text/javascript" src="../Scripts/ChurAlert.min.js?skin=blue"></script>
    <script type="text/javascript" src="../Scripts/chur-alert.1.0.js"></script>
    <link rel="stylesheet" type="text/css" href="../Styles/chur.css" />
     <script src="/js/Validform_v5.3.2.js" type="text/javascript"></script>
    <script type="text/javascript">
        $("#info2").click(function () {
            $('body').alert({
                type: 'info',
                buttons: [{
                    id: 'yes',
                    name: '确定',
                    callback: function () {
                        alert('确定')
                    }
                }, {
                    id: 'no',
                    name: '取消',
                    callback: function () {
                        alert('取消')
                    }
                }]
            })
        })
    </script>
</head>
<body>
    <div>
    </div>
    <div class="alert alert-info tit">
        当前位置<b class="tip"></b>查询界面<b class="tip"></b>日志列表 <span style="display: inline-block;
            float: right; position: relative; top: -5px;"></span></div>
    <table class="table table-striped table-bordered table-condensed" id="list">
        <thead>
            <tr class="tr_detail">
                <td>
                    日志编号
                </td>
                <td>
                    登录名
                </td>
                <td>
                    操作说明
                </td>
                <td>
                    IP
                </td>
                <td>
                    时间
                </td>
                
            </tr>
        </thead>
        <tbody>
            <%if (loglist != null && loglist.Count > 0)
              {
                  int i = 0;
                  foreach (var v in loglist)
                  {%>
            <tr <%=i%2==0?"":"class='even'" %>>
                <td>
                    <%=v.Id %>
                </td>
                <td>
                    <%=v.Loginname %>
                </td>
                <td>
                    <%=v.Actionname %>
                </td>
                <td>
                    <%=v.Ip%>
                </td>
                <td>
                    <%=v.CuDate%>
                </td>
            </tr>
            <%}
              } %>
            <tr class="tr_pagenumber">
                <td colspan="8">
                    <div id="PageContent" runat="server">
                    </div>
                </td>
            </tr>
        </tbody>
    </table>
</body>
</html>