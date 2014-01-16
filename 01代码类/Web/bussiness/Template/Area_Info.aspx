<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Area_Info.aspx.cs" Inherits="TX_Bussiness.Web.bussiness.Template.Area_Info" %>

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
            $(".area_info").click(function () {
                var id = $(this).attr("_id");
                var areatype = $("select[name='txt_infotype']").val();
                if (id && id != "") {
                    $.dialog({
                        title: '案卷流程',
                        content: 'url:/bussiness/Template/area_info_detail.aspx?starttime=' + $("#startime").val() + '&endtime=' + $("#endtime").val()+ '&id=' + id + "&areatype=" + areatype,
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

            $(".chart").click(function () {
                var areatype = $("select[name='txt_infotype']").val();
                if (areatype && areatype != "") {
                    $.dialog({
                        title: '案卷流程',
                        content: 'url:/bussiness/Template/chartinfo/areachart.aspx?areatype=' + areatype,
                        lock: true,
                        okVal: '关闭',
                        ok: true,
                        width: 788,
                        height: 550,
                        //cancelVal: '叉掉',
                        cancel: true /*为true等价于function(){}*/
                    });
                }
            });
        });
    </script>
</head>
<body>
    <div>
    </div>
    <div class="alert alert-info tit">
        当前位置<b class="tip"></b>统计界面<b class="tip"></b>区域统计
    </div>
    <form action="/bussiness/template/area_info.aspx" method="get">
    <table class="table table-striped table-bordered table-condensed c_table">
        <thead>
            <tr>
                <td colspan="12" class="auto-style2">
                    &nbsp;请填写查询条件
                </td>
            </tr>
        </thead>
        <tbody>
            <tr>
                <td class="t_label">
                    统计类型
                </td>
                <td class="detail">
                    <select size="1" name="txt_infotype" id="Select4">
                       <option value="1" <%=txt_infotype=="1"?"selected=selected":"" %>>区域</option>
                         <option value="2" <%=txt_infotype=="2"?"selected=selected":"" %>>街道</option>
                           <option value="3" <%=txt_infotype=="3"?"selected=selected":"" %>>社区</option>
                    </select>
                </td>
                <td class="t_label">
                    区域
                </td>
                <td class="detail">
                    <select size="1" name="txt_area" id="Select2">
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
                </td>
                <td class="t_label">
                    街道
                </td>
                <td class="td_detail">
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
                    </td>
                <td class="t_label">
                        社区
                    </td>
                <td>
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
                    </td>
                     <td class="t_label">
                    录入日期起
                </td>
                <td colspan="3">
                    <div class="input-append">
                        <input class="span2 datepicker" size="16" type="text" id="startime" name="txt_startdate"  value="<%=txt_startdate %>"/><span
                            class="add-on"><i class="icon-calendar"></i></span>至<input id="endtime" class="span2 datepicker"
                                name="txt_enddate" size="16" type="text" value="<%=txt_enddate %>"/><span class="add-on"><i class="icon-calendar"></i></span>
                    </div>
                </td>
                 
            </tr>
            <tr>
                <td colspan="9" align="right">
                    <input class="btn btn-primary" id="find" type="submit" value="查询" />
                    <input class="btn btn-primary" type="reset" id="reset" value="清空" />
                    <a href="/bussiness/template/chartinfo/areachart.aspx" class="btn btn-primary">
                    图表查询
                    </a>
                </td>
               
            </tr>
        </tbody>
    </table>
    </form>
    <table class="table table-striped table-bordered table-condensed" id="projlist">
        <thead>
            <tr class="tr_detail">
                <td>
                    区域名称
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
        <%if (txt_infotype == ((int)TX_Bussiness.Web.Comm.Enums.AreaCountType.Area).ToString())
          { %>
            <%if (arealist != null && arealist.Count > 0)
              {
                  int i = 0;
                  foreach (var v in arealist)
                  {%>
            <tr <%=i%2==0?"":"class='even'" %>>
                <td>
                    <a href="javascript:;">
                        <%=v.Areaname%>
                    </a>
                </td>
                <td>
                    <%=GetAreacount(v.Areacode, TX_Bussiness.Web.Comm.Enums.AreaCountType.Area)%>
                </td>
                <td>
                     <a href="javascript:;" class="preview btn btn-mini btn-primary add area_info"  _id="<%=v.Areacode %>">
                   查看详细
                    </a>
                </td>
            </tr>
            
            <%}
              }
              } %>
              <%if (txt_infotype == ((int)TX_Bussiness.Web.Comm.Enums.AreaCountType.Street).ToString())
                { %>
            <%if (streetlist != null && streetlist.Count > 0)
              {
                  int i = 0;
                  foreach (var v in streetlist)
                  {%>
            <tr <%=i%2==0?"":"class='even'" %> ">
                <td>
                    <a href="javascript:;">
                        <%=v.Streetname%>
                    </a>
                </td>
                <td>
                    <%=GetAreacount(v.Streetcode, TX_Bussiness.Web.Comm.Enums.AreaCountType.Street)%>
                </td>
                <td>
                     <a href="javascript:;" class="preview btn btn-mini btn-primary add area_info" _id="<%=v.Streetcode %>">
                   查看详细
                    </a>
                </td>
            </tr>
            
            <%}
              }
              } %>
              <%if (txt_infotype == ((int)TX_Bussiness.Web.Comm.Enums.AreaCountType.Commnuity).ToString())
                { %>
            <%if (commnuitylist != null && commnuitylist.Count > 0)
              {
                  int i = 0;
                  foreach (var v in commnuitylist)
                  {%>
            <tr <%=i%2==0?"":"class='even'" %> ">
                <td>
                    <a href="javascript:;">
                        <%=v.Commname%>
                    </a>
                </td>
                <td>
                    <%=GetAreacount(v.Commcode,TX_Bussiness.Web.Comm.Enums.AreaCountType.Commnuity)%>
                </td>
                 <td>
                     <a href="javascript:;" class="preview btn btn-mini btn-primary add area_info"  _id="<%=v.Commcode %>">
                   查看详细
                    </a>
                </td>
            </tr>
            
            <%}
              }
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
