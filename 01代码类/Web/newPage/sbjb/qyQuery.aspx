<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="qyQuery.aspx.cs" Inherits="TX_Bussiness.Web.newPage.sbjb.qyQuery" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link rel="stylesheet" type="text/css" href="../style/css/reset.css" />
    <link rel="stylesheet" type="text/css" href="../style/css/index.css" />
    <link id="skin" rel="stylesheet" href="../style/Blue/jbox.css" />
    <script src="../js/jquery-1.6.1.js" type="text/javascript"></script>
    <script type="text/javascript" src="../../bussiness/Scripts/ChurAlert.min.js?skin=blue"></script>
    <script type="text/javascript" src="../../bussiness/Scripts/chur-alert.1.0.js"></script>
    <%-- <script type="text/javascript" src="../js/popup_layer.js"></script>
    <script type="text/javascript" src="../js/jquery.jBox.src.js"></script>--%>
    <script type="text/javascript" src="../js/public.js"></script>
    <script src="../../js/global.js" type="text/javascript"></script>
    <script type="text/javascript" src="../../bussiness/Scripts/jquery-ui-1.8.22.custom.min.js"></script>
    <script src="../../js/Validform_v5.3.2.js" type="text/javascript"></script>
    <script src="/newpage/My97DatePicker/WdatePicker.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            create_sbjbmenu("任务查询");
            $(".preview").click(function () {
                var projcode = $(this).closest("tr").attr("_projcode");
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
            $(".valifrom").Validform({
                tipSweep: true,
                tiptype: function (msg, o, cssctl) {
                    //msg：提示信息;
                    //o:{obj:*,type:*,curform:*}, obj指向的是当前验证的表单元素（或表单对象），type指示提示的状态，值为1、2、3、4， 1：正在检测/提交数据，2：通过验证，3：验证失败，4：提示ignore状态, curform为当前form对象;
                    //cssctl:内置的提示信息样式控制函数，该函数需传入两个参数：显示提示信息的对象 和 当前提示的状态（既形参o中的type）;
                    if (o.type == "3") {//验证表单元素时o.obj为该表单元素，全部验证通过提交表单时o.obj为该表单对象;
                        $('body').alert({
                            type: "出错提示",
                            content: msg
                        })
                    }
                }
            });
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
    <div class="container">
        <!--header start-->
        <div class="header">
            <div class="welcome">
                <a class="close" href="#">注销</a><a class="off" href="/bussiness/index.aspx?action=exit">退出</a></div>
            <div class="nav" id="menu">
            </div>
        </div>
        <!--header end-->
        <div class="tip">
            当前位置：<a href="#">上报交办系统</a> > <a href="ryQuery.aspx">任务查询</a> > 区域查询</div>
        <!--content start-->
        <div class="content noborder layout">
            <!--右边内容 start-->
            <div class="col-main">
                <!--main-wrap start-->
                <div class="main-wrap">
                    <!--search_con start-->
                    <div class="search_con noborder">
                        <div class="search_data">
                            <form action="/newpage/sbjb/qyQuery.aspx" method="get">
                            <div class="ip_list">
                                区域：
                                <select size="1" name="txt_area" id="Select4">
                                    <option value="0">全部</option>
                                    <%foreach (var v in Arealist())
                                      {
                                          if (!string.IsNullOrEmpty(v.Areaname))
                                          { %>
                                    <option value="<%=v.Areacode %>" <%=txt_area==v.Areacode.ToString()?"selected=selected":"" %>>
                                        <%=v.Areaname %></option>
                                    <%}
                                      }%>
                                </select>
                                街道：
                                <select size="1" name="txt_street" id="Select3">
                                    <option value="0">全部</option>
                                    <%foreach (var v in Streettlist())
                                      {
                                          if (!string.IsNullOrEmpty(v.Streetname))
                                          { %>
                                    <option value="<%=v.Streetcode %>" <%=txt_street==v.Streetcode.ToString()?"selected=selected":"" %>>
                                        <%=v.Streetname %></option>
                                    <%}
                                      }%>
                                </select>
                                社区：
                                <select size="1" name="txt_commnuity" id="Select1">
                                    <option value="0">全部</option>
                                    <%foreach (var v in Communitylist())
                                      {
                                          if (!string.IsNullOrEmpty(v.Commname))
                                          { %>
                                    <option value="<%=v.Commcode %>" <%=txt_commnuity==v.Commcode.ToString()?"selected=selected":"" %>>
                                        <%=v.Commname %></option>
                                    <%}
                                      }%>
                                </select>
                                录入日期起：
                                <input onclick="WdatePicker()" class="span2 datepicker" size="16" type="text" id="startime"
                                    name="txt_startdate" value="<%=txt_startdate %>" /><span class="add-on"><i class="icon-calendar"></i></span>至<input
                                        onclick="WdatePicker()" id="endtime" class="span2 datepicker" name="txt_enddate"
                                        size="16" type="text" value="<%=txt_enddate %>" /><span class="add-on"><i class="icon-calendar"></i></span>
                                <input class="ip_btn" id="find" type="submit" value="查询" />
                            </div>
                            </form>
                            <div class="search_data">
                                <table width="100%" border="0" cellpadding="0" id="projlist" cellspacing="0" style="border-top: 1px solid #d6d6d6;">
                                    <tr>
                                        <th>
                                            勤务编号
                                        </th>
                                        <th>
                                            上报人
                                        </th>
                                        <th>
                                            区域
                                        </th>
                                        <th>
                                            街道
                                        </th>
                                        <th>
                                            社区
                                        </th>
                                        <th>
                                            大类
                                        </th>
                                        <th>
                                            小类
                                        </th>
                                        <th>
                                            地址
                                        </th>
                                        <th>
                                            案卷描述
                                        </th>
                                        <th>
                                            上报时间
                                        </th>
                                        <th>
                                            操作
                                        </th>
                                    </tr>
                                    <%if (project_list != null && project_list.Count > 0)
                                      {
                                          int i = 0;
                                          foreach (var v in project_list)
                                          {%>
                                    <tr <%=i%2==0?"":"class='w_bg'" %> _projcode="<%=v.Projcode %>">
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
                                        <td title="<%=v.Address %>">
                                            <%=Bussiness.Common.Utility.CheckStringLength(v.Address,10)%>
                                        </td>
                                        <td title="<%=v.Describe %>">
                                            <%=Bussiness.Common.Utility.CheckStringLength(v.Describe, 10)%>
                                        </td>
                                        <td>
                                            <%=v.Adddate %>
                                        </td>
                                        <td>
                                            <%--<a href="banli.aspx?projcode=<%=v.Projcode %>" class="btn btn-mini btn-primary add">
                                                办理 </a>--%>
                                            <a href="javascript:;" class="preview btn btn-mini btn-primary add">查看流程 </a>
                                        </td>
                                    </tr>
                                    <%i++;
                                          }
                                      } %>
                                    <tr class="tr_pagenumber">
                                        <td colspan="100">
                                            <div id="PageContent" runat="server" class="page">
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                    </div>
                    <!--search_con end-->
                </div>
                <!--main-wrap end-->
            </div>
            <!--右边内容 end-->
            <!--左侧栏 start-->
            <div class="col-sub">
                <div class="tree_menu pt20">
                    <div class="time">
                        <h2>
                            任务查询</h2>
                        <dl class="message" style="padding-top: 10px">
                            <dd>
                                <a href="/newpage/sbjb/ryQuery.aspx">人员查询</a>
                            </dd>
                            <dd>
                                <a href="qyQuery.aspx">区域查询</a></dd>
                            <dd>
                                <a href="lbQuery.aspx">类别查询</a></dd>
                        </dl>
                    </div>
                </div>
            </div>
            <!--左侧栏 end-->
        </div>
        <!--content end-->
    </div>
</body>
</html>
