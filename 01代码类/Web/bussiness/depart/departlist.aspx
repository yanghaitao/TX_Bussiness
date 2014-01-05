<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="departlist.aspx.cs" Inherits="TX_Bussiness.Web.bussiness.depart.departlist" %>

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
        当前位置<b class="tip"></b>查询界面<b class="tip"></b>部门列表 <span style="display: inline-block;
            float: right; position: relative; top: -5px;"><a href="/bussiness/depart/departedit.aspx?action=add"
                class="btn btn-primary btn-small" id="primary">添加部门</a></span></div>
    <form action="/bussiness/depart/departlist.aspx" method="get">
    <table class="table table-striped table-bordered table-condensed">
        <thead>
            <tr>
                <td colspan="6" class="auto-style2">
                    &nbsp;请填写查询条件
                </td>
            </tr>
        </thead>
        <tbody>
            <tr>
                <td width="10%">
                    部门名称
                </td>
                <td class="detail">
                    <input id="formid" name="txt_departname" value="<%=txt_departname %>" />
                     <input class="btn btn-primary" id="find" type="submit" value="查询" />
                    <input class="btn btn-primary" type="reset" value="清空" />
                </td>
            </tr>
        </tbody>
    </table>
    </form>
    <table class="table table-striped table-bordered table-condensed" id="list">
        <thead>
            <tr class="tr_detail">
                <td>
                    部门名称
                </td>
                <td>
                    手机
                </td>
                <td>
                    电话
                </td>
                <td>
                    是否接受消息
                </td>
                <td>
                    所属部门
                </td>
                <td>
                    部门状态
                </td>
                <td>
                    添加时间
                </td>
                <td>
                    操作
                </td>
            </tr>
        </thead>
        <tbody>
            <%if (depart_list != null && depart_list.Count > 0)
              {
                  int i = 0;
                  foreach (var v in depart_list)
                  {%>
            <tr <%=i%2==0?"":"class='even'" %>>
                <td>
                    <%=v.Departname %>
                </td>
                <td>
                    <%=v.Departmobile %>
                </td>
                <td>
                    <%=v.Departtel %>
                </td>
                <td>
                    <%=v.Isacceptmessage==0?"不接受":"接受"%>
                </td>
                <td>
                    <%= GetDepartName(v.Parentcode)%>
                </td>
                <td>
                    <%=v.Departstate %>
                </td>
                <td>
                    <%=v.Adddate %>
                </td>
                <td>
                    <a href="/bussiness/depart/departedit.aspx?action=edit&id=<%=v.Id %>" class="btn btn-mini btn-danger">
                        修改</a> <a href="javascript:;" onclick="delemodel('<%=v.Id %>','depart')" class="btn btn-mini btn-danger">
                            删除</a>
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
