<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Depart_Info.aspx.cs" Inherits="TX_Bussiness.Web.bussiness.Template.Depart_Info" %>

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
          
            $(".depart_info").click(function () {
                var id = $(this).attr("_id");
                if (id && id != "") {
                    $.dialog({
                        title: '案卷流程',
                        content: 'url:/bussiness/Template/depart_info_detail.aspx?startime=' + $("#startime").val() + '&endtime=' + $("#endtime").val() + '&id=' + id,
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
    </script>
</head>
<body>
    <div>
    </div>
    <div class="alert alert-info tit">
        当前位置<b class="tip"></b>统计界面<b class="tip"></b>区域统计</div>
    <form action="/bussiness/template/depart_info.aspx" method="get">
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
                    部门
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
                    <input class="btn btn-primary" id="find" type="submit" value="查询" />
                    <input class="btn btn-primary" type="reset" id="reset" value="清空" /> 
                    <a href="/bussiness/template/chartinfo/departchart.aspx" class="btn btn-primary">
                    图表查询
                    </a>
                    </div>
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
       
            <%if (departlist != null && departlist.Count > 0)
              {
                  int i = 0;
                  foreach (var v in departlist)
                  {%>
                 <tr <%=i%2==0?"":"class='even'" %> ">
                <td>
                    <a href="javascript:;">
                        <%=v.Departname%>
                    </a>
                </td>
                <td>
                    <%=GetDepartCount(v.Id)%>
                </td>
                 <td>
                     <a href="javascript:;" class="preview btn btn-mini btn-primary add depart_info" _id="<%=v.Id %>">
                   查看详细
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

