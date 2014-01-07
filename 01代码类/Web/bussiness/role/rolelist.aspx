<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="rolelist.aspx.cs" Inherits="TX_Bussiness.Web.bussiness.role.rolelist" %>

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
        <script src="/js/Validform_v5.3.2.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            $(".datepicker").datepicker();

            //$('#list').hide();
            $('#find').click(function () {
                $('#list').show();
            })
            //            $('#formid').tooltip({ title: '单据号' });
            //            $('#formtype').tooltip({ title: '单据类型' });
            //            $('#bumen').tooltip({ title: '部门' });
            //            $('#startime').tooltip({ title: '起始日期' });
            //            $('#endtime').tooltip({ title: '结束日期' });
            //            $('#baoxiaoren').tooltip({ title: '报销人' });
            //            $('#xiangmu').tooltip({ title: '所属项目' });

        });

        function showbox(obj) {
            $.dialog({
                title: '我的浏览器',
                content: 'url:/bussiness/Template/ProjectEdit.aspx',
                lock: true,
                okVal: '关了',
                ok: true,
                width: 788,
                height: 550,
                cancelVal: '叉掉',
                button: [{
                    id: 'chur',
                    name: '再来个警告',
                    callback: function () {
                        $('body').alert({
                            type: 'success'
                        });

                    }
                }],
                cancel: true /*为true等价于function(){}*/
            });
        }
    </script>
</head>
<body>
    <div>
    </div>
    <div class="alert alert-info tit">
        当前位置<b class="tip"></b>查询界面<b class="tip"></b>查询结果一 <span style="display: inline-block;
            float: right; position: relative; top: -5px;"><a href="/bussiness/role/roleedit.aspx?action=add"
                class="btn btn-primary btn-small" id="primary">添加角色</a></span></div>
    <table class="table table-striped table-bordered table-condensed" id="list">
        <thead>
            <tr class="tr_detail">
                <td width="20%">
                    角色名称
                </td>
                <td width="70%">
                    所有权限
                </td>
                <td width="70%">
                    操作
                </td>
            </tr>
        </thead>
        <tbody>
            <%if (role_list != null && role_list.Count > 0)
              {
                  int i = 0;
                  foreach (var v in role_list)
                  {%>
            <tr <%=i%2==0?"":"class='even'" %>>
                <td>
                    <%=v.Rolename %>
                </td>
                <td>
                    <%=GetLimitName(v.Limitid)%>
                </td>
                <td>
                    <a href="/bussiness/role/roleedit.aspx?action=edit&id=<%=v.Id %>" class="btn btn-mini btn-danger">
                        修改</a>
                </td>
            </tr>
            <%}
              } %>
            <tr class="tr_pagenumber">
                <td colspan="3">
                    <div id="PageContent" runat="server">
                    </div>
                </td>
            </tr>
        </tbody>
    </table>
</body>
</html>
