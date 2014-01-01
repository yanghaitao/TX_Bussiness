<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="projectlist.aspx.cs" Inherits="TX_Bussiness.Web.bussiness.Template.projectlist" %>

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
    <script type="text/javascript">
        $(function () {
            $(".datepicker").datepicker();
            //            $('#formid').tooltip({ title: '单据号' });
            //            $('#formtype').tooltip({ title: '单据类型' });
            //            $('#bumen').tooltip({ title: '部门' });
            //            $('#startime').tooltip({ title: '起始日期' });
            //            $('#endtime').tooltip({ title: '结束日期' });
            //            $('#baoxiaoren').tooltip({ title: '报销人' });
            //            $('#xiangmu').tooltip({ title: '所属项目' });
            $("#projlist").find("tr").tooltip({ title: '双击查看案卷流程' });
            $("#projlist").find("tr").dblclick(function () {
                var projcode = $(this).attr("_projcode");
                if (projcode && projcode != "") {
                    $.dialog({
                        title: '案卷流程',
                        content: 'url:/bussiness/Template/projectview.aspx?projcode=' + projcode,
                        lock: true,
                        okVal: '关闭',
                        ok: true,
                        width: 788,
                        height: 550,
                        //cancelVal: '叉掉',
                        cancel: true /*为true等价于function(){}*/
                    });
                }
            })
        });
        function showdetail(projectcode) {
            $.dialog({
                title: '案卷详情',
                content: 'url:/bussiness/Template/projectdetail.aspx?projcode=' + projectcode,
                lock: true,
                okVal: '关闭',
                ok: true,
                width: 788,
                height: 550,
                //cancelVal: '叉掉',
                cancel: true /*为true等价于function(){}*/
            });
        }
    </script>
</head>
<body>
    <div>
    </div>
    <div class="alert alert-info">
        当前位置<b class="tip"></b>查询界面<b class="tip"></b>案卷列表</div>
    <form action="projectlist.aspx" method="post">
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
                    案卷编号
                </td>
                <td class="detail">
                    <input id="formid" name="txt_projectcode" />
                </td>
                <td>
                    案卷类型
                </td>
                <td class="td_detail">
                    <input id="formtype" name="txt_projecttype" />
                </td>
                <td>
                    处理部门
                </td>
                <td>
                    <select size="1" name="txt_depart" id="bumen">
                        <option value="0">全部</option>
                        <%foreach (var v in Departlist())
                          {
                              if (v.Departname != "")
                              { %>
                        <option value="<%=v.Id %>">
                            <%=v.Departname %></option>
                        <%}
                          }%>
                    </select>
                </td>
            </tr>
            <tr>
                <td>
                    上报人
                </td>
                <td class="detail">
                    <input id="Text3" name="txt_dispatcher" />
                </td>
                <td>
                    处理人
                </td>
                <td class="td_detail">
                    <input id="Text4" name="txt_handler" />
                </td>
                <td>
                    案卷状态
                </td>
                <td>
                    <select size="1" name="txt_projectstate" id="Select2">
                        <option value="0">全部</option>
                    </select>
                </td>
            </tr>
            <tr>
                <td>
                    区域
                </td>
                <td class="detail">
                    <select size="1" name="txt_area" id="Select4">
                        <option value="0">全部</option>
                        <%foreach (var v in Arealist())
                          {
                              if (!string.IsNullOrEmpty(v.Areaname))
                              { %>
                        <option value="<%=v.Areacode %>">
                            <%=v.Areaname %></option>
                        <%}
                          }%>
                    </select>
                </td>
                <td>
                    街道
                </td>
                <td class="td_detail">
                    <select size="1" name="txt_street" id="Select3">
                        <option value="0">全部</option>
                        <%foreach (var v in Streettlist())
                          {
                              if (!string.IsNullOrEmpty(v.Streetname))
                              { %>
                        <option value="<%=v.Streetcode %>">
                            <%=v.Streetname %></option>
                        <%}
                          }%>
                    </select>
                    <td>
                        社区
                    </td>
                    <td>
                        <select size="1" name="txt_commnuity" id="Select1">
                            <option value="0">全部</option>
                            <%foreach (var v in Communitylist())
                              {
                                  if (!string.IsNullOrEmpty(v.Commname))
                                  { %>
                            <option value="<%=v.Commcode %>">
                                <%=v.Commname %></option>
                            <%}
                              }%>
                        </select>
                    </td>
            </tr>
            <tr>
                <td>
                    上报日期起
                </td>
                <td>
                    <div class="input-append">
                        <input class="span2 datepicker" size="16" type="text" id="startime" name="txt_startdate" /><span
                            class="add-on"><i class="icon-calendar"></i></span>至<input id="endtime" class="span2 datepicker"
                                name="txt_enddate" size="16" type="text" /><span class="add-on"><i class="icon-calendar"></i></span>
                    </div>
                </td>
                <td>
                    报销人
                </td>
                <td>
                    <select size="1" name="select2" id="baoxiaoren">
                        <option value="10401"></option>
                        <option value="10388">第二营销事业部</option>
                    </select>
                </td>
                <td>
                    所属项目
                </td>
                <td>
                    <select id="xiangmu" size="1" name="select3">
                        <option value="10401"></option>
                        <option value="10388">第二营销事业部</option>
                    </select>
                </td>
            </tr>
            <tr>
                <td colspan="6" align="right">
                    <input class="btn btn-inverse" id="find" type="submit" value="查询" />
                    <input class="btn btn-inverse" type="reset" value="清空" />
                </td>
            </tr>
        </tbody>
    </table>
    </form>
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
                    摘要
                </td>
                <td>
                    上报时间
                </td>
                <td>
                    操作
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
                    <a href="javascript:;showdetail('<%=v.Projcode %>')">
                        <%=String.Format(GetAppSeeting("ProjectNameTemplate"),v.Projcode) %>
                    </a>
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
                <td>
                    <%=v.Address %>
                </td>
                <td>
                    <%=v.Describe %>
                </td>
                <td>
                    <%=v.Adddate %>
                </td>
                <td>
                 <a href="/bussiness/template/projectedit.aspx?projcode=<%=v.Projcode %>">
                   办理
                    </a>
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
