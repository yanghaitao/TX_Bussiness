<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="classlist.aspx.cs" Inherits="TX_Bussiness.Web.bussiness.p_class.classlist" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title></title>
    <link rel="stylesheet" type="text/css" href="../Styles/bootstrap.min.css" />
    <link rel="stylesheet" type="text/css" href="../Styles/admin-all.css" />
    <link rel="stylesheet" type="text/css" href="../Styles/chur.css" />
    <script type="text/javascript" src="../Scripts/jquery-1.7.2.js"></script>
    <script type="text/javascript" src="../Scripts/jquery-ui-1.8.22.custom.min.js"></script>
    <link rel="stylesheet" type="text/css" href="../Styles/ui-lightness/jquery-ui-1.8.22.custom.css" />
    <script type="text/javascript" src="../Scripts/tip.js"></script>
    <script type="text/javascript" src="/js/json2.js"></script>
    <script src="/js/global.js" type="text/javascript"></script>
    <script type="text/javascript" src="../Scripts/ChurAlert.min.js?skin=blue"></script>
    <script type="text/javascript" src="../Scripts/chur-alert.1.0.js"></script>
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
    <div class="alert alert-info">
        当前位置<b class="tip"></b>查询界面<b class="tip"></b>类别列表 <span style="display: inline-block;
            float: right; position: relative; top: -5px;"><a href="/bussiness/p_class/classedit.aspx?action=add"
                class="btn btn-primary btn-small" id="primary">添加类别</a></span></div>
    <form action="/bussiness/p_class/classlist.aspx" method="get">
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
                <td>
                    类别名称
                </td>
                <td class="detail">
                    <input id="formid" name="txt_classname" value="<%=txt_classname %>" />
                </td>
                <td>
                    所属类别
                </td>
                <td>
                    <select size="1" name="txt_classcode" id="bumen">
                        <option value="0">全部</option>
                        <%foreach (var v in GetProjectClass(0))
                          {
                              if (v.Classname != "")
                              { %>
                        <option value="<%=v.Id %>" <%=v.Id.ToString()==txt_classcode?"selected='selected'":"" %>>
                            <%=v.Classname %></option>
                        <%}
                          }%>
                    </select>
                     <select size="1" name="txt_bigclass" id="Select1">
                     <option value="0">无</option>
                         <%=!string.IsNullOrEmpty(txt_bigclass)&&txt_bigclass != "0" ? "<option value='" + txt_bigclass + "'>"+GetClassName(txt_bigclass)+"</option>" : ""%>
                    </select>
                </td>
            </tr>
            <tr>
                <td colspan="5" align="right">
                    <input class="btn btn-inverse" id="find" type="submit" value="查询" />
                    <input class="btn btn-inverse" type="reset" value="清空" />
                </td>
            </tr>
        </tbody>
    </table>
    </form>
    <table class="table table-striped table-bordered table-condensed" id="list">
        <thead>
            <tr class="tr_detail">
                <td width="20%">
                    类别名称
                </td>
                <td width="70%">
                    所属类别
                </td>
                <td width="70%">
                    操作
                </td>
            </tr>
        </thead>
        <tbody>
            <%if (projectlist != null && projectlist.Count > 0)
              {
                  int i = 0;
                  foreach (var v in projectlist)
                  {%>
            <tr <%=i%2==0?"":"class='even'" %>>
                <td>
                    <%=v.Classname %>
                </td>
                <td>
                    <%=GetClassName(v.Parentid)%>
                </td>
                <td>
                    <a href="/bussiness/p_class/classedit.aspx?action=edit&id=<%=v.Id %>" class="btn btn-mini btn-danger">
                        修改</a> <a href="javascript:;" onclick="delemodel('<%=v.Id %>','projectclass')" class="btn btn-mini btn-danger">
                            删除</a>
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
