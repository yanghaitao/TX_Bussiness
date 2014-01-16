<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="rydw.aspx.cs" Inherits="TX_Bussiness.Web.bussiness.Template.rydw" %>

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
   
        function rydw() {
            var img = Map.XGIS.ImgSrc.personMark;
            var p = new Array; //[102.67505470898345, 25.04697684429611];
            var pa =  new Array;//["张三", '男', 23]
            <%if (user_list != null && user_list.Count > 0)
              {
                  int i = 0;
                  foreach (var v in user_list)
                  {%>
                    pa[0]=<%="'"+v.Username+"'"%>
                    pa[1]=<%="'"+GetDepartName(v.Departcode.ToString())+"'"%>
                    //<%= v.Location%>
                    p[0]="102.67505470898345";
                    p[1]=" 25.04697684429611";
                    pa[2]=<%="'"+v.Localtionupdate+"'"%>
                    Map.IF.positionOrientation(p, img, qwert, pa, true);
                <%}
                 } 
              %>

           
        }
        function qwert(pa) {

            return '姓名：' + pa[0] + '</br>性别：' + pa[1] + '</br>年龄:' + pa[2];
        }
       
       </script>
</head>
<body>
    <div>
    </div>
    <div class="alert alert-info tit">
        当前位置<b class="tip"></b>查询界面<b class="tip"></b>人员实时定位</div>
    <form action="/bussiness/template/rydw.aspx" method="get" runat="server">
    <table class="table table-striped table-bordered table-condensed ">
        <thead>
            <tr>
                <td colspan="7" class="auto-style2">
                    &nbsp;请填写查询条件
                </td>
            </tr>
        </thead>
        <tbody>
            <tr>
                <td class="t_label">
                    人员编号
                </td>
                <td class="detail">
                    <input id="ryid" name="txt_usercode"  value="<%=txt_usercode %>"/>
                </td>
                <td>
                    人员姓名</td>
                <td>
                     <input id="ryname" name="txt_username"  value="<%=txt_username %>"/>
                </td>
                 <td>
                    中队
                </td>
                <td>
                    <select size="1" name="txt_departId" id="departid">
                        <option value="0">全部</option>
                        <%foreach (var v in Departlist())
                          {
                              if (v.Departname != "")
                              { %>
                        <option value="<%=v.Id %>" <%=txt_departId==v.Id.ToString()?"selected=selected":"" %>>
                            <%=v.Departname %></option>
                        <%}
                          }%>
                    </select>
                </td>
                <td>
                    <input class="btn btn-primary" id="find" type="submit"  value="查询" />
                    <input class="btn btn-primary" type="button" onclick="rydw()" value="定位" />
                    </td>
            </tr>
        </tbody>
    </table>
    </form>
     <iframe id="Map" name="Map" src="../MapBrowser/index.html" frameborder="0" width="100%" height="808"></iframe>
  <!--  <table class="table table-striped table-bordered table-condensed" id="userlist">
        <thead>
            <tr class="tr_detail">
                <td>
                    人员编号
                </td>
                <td>
                    人员姓名</td>
                <td>
                    部门</td>
                <td>
                    GPS坐标</td>
                <td>
                    GPS时间</td>
            </tr>
        </thead>
        <tbody>
           
            <tr class="tr_pagenumber">
                <td colspan="5">
                    <div id="PageContent" runat="server">
                    </div>
                </td>
            </tr>
        </tbody>
    </table>-->
</body>
</html>