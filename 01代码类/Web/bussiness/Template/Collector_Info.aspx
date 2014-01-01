<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Collector_Info.aspx.cs" Inherits="TX_Bussiness.Web.bussiness.Template.Collector_Info" %>

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
    <div class="alert alert-info tit">
        当前位置<b class="tip"></b>统计界面<b class="tip"></b>区域统计</div>
    <form action="/bussiness/template/collector_info.aspx" method="get">
    <table class="table table-striped table-bordered table-condensed c_table">
        <thead>
            <tr>
                <td colspan="6" class="auto-style2">
                    &nbsp;请填写查询条件
                </td>
            </tr>
        </thead>
        <tbody>
           
            <tr>
             <td class="t_label">
                    区域
                </td>
                <td class="detail">
                    <select size="1" name="txt_depart" id="bumen">
                        <option value="0">全部</option>
                        <%foreach (var v in Departlist())
                          {
                              if (v.Departname != "")
                              { %>
                        <option value="<%=v.Id %>" <%=txt_depart==v.Id.ToString()?"selected=selected":"" %>>
                            <%=v.Departname %></option>
                        <%}
                          }%>
                    </select>
                </td>
                <td class="t_label">
                    录入日期起
                </td>
                <td colspan="3">
                    <div class="input-append">
                        <input class="span2 datepicker" size="16" type="text" id="startime" name="txt_startdate"  value="<%=txt_startdate %>"/><span
                            class="add-on"><i class="icon-calendar"></i></span>至<input id="endtime" class="span2 datepicker"
                                name="txt_enddate" size="16" type="text" value="<%=txt_enddate %>"/><span class="add-on"><i class="icon-calendar"></i></span>
                    <input class="btn btn-inverse" id="find" type="submit" value="查询" />
                    <input class="btn btn-inverse" type="reset" id="reset" value="清空" /> </div>
                </td>
            </tr>
        </tbody>
    </table>
    </form>
    <table class="table table-striped table-bordered table-condensed" id="projlist">
        <thead>
            <tr class="tr_detail">
                <td>
                    姓名
                </td>
                <td>
                   工作量
                </td>
                
                <td>
                    操作
                </td>
            </tr>
        </thead>
        <tbody>
       
            <%if (userlist != null && userlist.Count > 0)
              {
                  int i = 0;
                  foreach (var v in userlist)
                  {%>
                 <tr <%=i%2==0?"":"class='even'" %> ">
                <td>
                    <a href="javascript:;">
                        <%=v.Username%>
                    </a>
                </td>
                <td>
                    <%=GetCollectorCount(v.Id)%>
                </td>
                <td>
                 <a href="/bussiness/template/projectedit.aspx?projcode=" class="btn btn-mini btn-primary add">
                   办理
                    </a>
                     <a href="javascript:;" class="preview btn btn-mini btn-primary add">
                   查看流程
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
