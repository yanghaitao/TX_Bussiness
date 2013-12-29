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
    <script type="text/javascript" src="../Scripts/jquery.easyui.min.js"></script>
    <link rel="stylesheet" type="text/css" href="../Styles/ui-all/tree.css" />
    <script type="text/javascript">
       
    </script>
</head>
<body>
    <div class="alert alert-info">当前位置<b class="tip"></b>表单风格<b class="tip"></b>树+表单</div>
    <div class="container-fluid" style=" position:relative;">
        <div class="row-fluid">
            <div  style=" overflow:auto;">
                <ul id="tt" class="easyui-tree">
                <%foreach(var area in Arealist()) {%>
                    <li>
                        <span><%=area.Areaname %></span>
                        <ul>
                        <%foreach(var street in Streettlist(area.Areacode)) {%>
                            <li>
                                <span><%=street.Streetname %></span>
                                <ul>
                                <%foreach(var community in Communitylist(street.Streetcode)){ %>
                                    <li>
                                        <span><a href="#"><%=community.Commname %></a></span>
                                    </li>
                                    <%} %>
                                   <%-- <li>
                                        <span>财务部</span>
                                    </li>
                                    <li>
                                        <span>商务信息部</span>
                                    </li>
                                    <li>
                                        <span>人力资源部</span>
                                    </li>
                                    <li>
                                        <span>行政部</span>
                                    </li>--%>
                                </ul>
                            </li>
                            <%} %>
                           <%-- <li>
                                <span>上海运营总部</span>
                            </li>
                            <li>
                                <span>南昌</span>
                            </li>
                            <li>
                                <span>深圳艺谷</span>
                                <ul>
                                    <li>
                                        <span><a href="#">总裁办</a></span>
                                    </li>
                                    <li>
                                        <span>财务部</span>
                                    </li>
                                    <li>
                                        <span>商务信息部</span>
                                    </li>
                                    <li>
                                        <span>IT部</span>
                                        <ul>
                                            <li>
                                                <span><a href="#">李恒</a></span>
                                            </li>
                                            <li>
                                                <span><a>邱致武</a></span>
                                            </li>
                                            <li>
                                                <span><a>叶委</a></span>
                                            </li>
                                            <li>
                                                <span>黄林洁</span>
                                            </li>
                                            <li>
                                                <span>赵号</span>
                                            </li>
                                            <li>
                                                <span>游源</span>
                                            </li>
                                        </ul>
                                    </li>
                                    <li>
                                        <span>行政部</span>
                                    </li>
                                </ul>
                            </li>--%>
                        </ul>
                    </li>
                    <%} %>
                   <%-- <li>
                        <span>打酱油的</span>
                        <ul><li>孙悟苍井空</li></ul>
                    </li>--%>
                </ul>
            </div>
            <%--<div class="span10"> 
                <iframe frameborder="0" width="100%" height="90%" src="/bussiness/template/area_info_detail.aspx"></iframe>                
            </div>--%>
        </div>
    </div>

</body>
</html>