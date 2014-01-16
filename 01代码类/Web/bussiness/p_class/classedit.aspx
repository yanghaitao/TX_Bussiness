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
     <script type="text/javascript" src="../Scripts/ChurAlert.min.js?skin=blue"></script>
    <script type="text/javascript" src="../Scripts/chur-alert.1.0.js"></script>
    <link rel="stylesheet" type="text/css" href="../Styles/chur.css" />    
    <script src="/js/json2.js" type="text/javascript"></script>
    <script src="/js/global.js" type="text/javascript"></script>
     <script src="/js/Validform_v5.3.2.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
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
        })
    </script>
</head>
<body>
    <form action="/bussiness/p_class/classedit.aspx" method="post" class="valifrom">
    <div class="alert alert-info tit">
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
                    <select size="1" name="txt_classcode" id="bumen">
                        <option value="0">无</option>
                        <%foreach (var v in GetProjectClass(0))
                          {
                              if (v.Classname != "")
                              { %>
                        <option value="<%=v.Id %>" <%=v.Id.ToString()==model.Parentid?"selected='selected'":""%>>
                            <%=v.Classname%></option>
                        <%}
                          }%>
                    </select>
                    <select size="1" name="txt_bigclass" id="Select1">
                        <option value="0">无</option>
                    </select>
                </td>
            </tr>
            <tr>
                <td>
                    类别名称<font color="FF0000">*</font>
                </td>
                <td colspan="3">
                    <input name="txt_classname" value="<%=model.Classname %>" type="text" datatype="*" nullmsg="请填写类别名称！"/>
                </td>
            </tr>
        </tbody>
        <tfoot>
            <tr>
                <td colspan="4">
                    <input class="btn btn-primary" id="find" onclick="return initcheck();" type="submit"
                        value="保存" />
                    <input class="btn btn-primary" type="button" value="取消" onclick="window.history.go(-1)" />
                </td>
            </tr>
        </tfoot>
    </table>
    </form>
</body>
</html>
