<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="classedit.aspx.cs" Inherits="TX_Bussiness.Web.bussiness.p_class.classedit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title></title>
    <link rel="stylesheet" type="text/css" href="../Styles/bootstrap.min.css" />
    <link rel="stylesheet" type="text/css" href="../Styles/admin-all.css" />
    <script type="text/javascript" src="../Scripts/jquery-1.7.2.js"></script>
    <script type="text/javascript" src="../Scripts/jquery-ui-1.8.22.custom.min.js"></script>
    <link rel="stylesheet" type="text/css" href="../Styles/ui-lightness/jquery-ui-1.8.22.custom.css" />
    <script src="/js/json2.js" type="text/javascript"></script>
    <script src="/js/global.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            $('.modal').show();
        })
    </script>
</head>
<body>
    <form action="/bussiness/p_class/classedit.aspx" method="post">
    <div class="alert alert-info">
        当前位置<b class="tip"></b>维护界面<b class="tip"></b>类别编辑</div>
    <table class="table table-striped table-bordered table-condensed list">
        <thead>
            <tr>
                <td colspan="4">
                    类别<b>信息</b>
                </td>
            </tr>
        </thead>
        <tbody>
            <tr>
                <td width="15%">
                    所属类别<font color="FF0000">*</font>
                    <input type="hidden" value="<%=model.Id %>" name="id" />
                </td>
                <td width="500" colspan="3">
                <%if (model.Classtype != 1)
                  {%>
                     <select size="1" name="txt_parentid" id="bumen" >
                     <option value="0">无</option>
                        <%foreach (var v in GetProjectClass(1))
                          {
                              if (v.Classname != "")
                              { %>
                        <option value="<%=v.Id %>" <%=v.Id.ToString()==model.Parentid?"selected='selected'":""%>>
                            <%=v.Classname%></option>
                        <%}
                          }%>
                    </select>
                    <%}
                  else
                  { %>
                   <input name="" value="<%=GetClassName(model.Id.ToString()) %>" type="text" readonly="readonly"/>
                    <%}%>
                </td>
            </tr>
            <tr>
                <td>
                    类别名称<font color="FF0000">*</font> 
                </td>
                <td colspan="3">
                     <input name="txt_classname" value="<%=model.Classname %>" type="text" />
                </td>
              
            </tr>
        
        </tbody>
        <tfoot>
            <tr>
                <td colspan="4">
                    <input class="btn btn-inverse" id="find" onclick="return initcheck();" type="submit" value="保存" />
                    <input class="btn btn-inverse" type="button" value="取消" onclick="window.history.go(-1)" />
                </td>
            </tr>
        </tfoot>
    </table>
    </form>
</body>
</html>


