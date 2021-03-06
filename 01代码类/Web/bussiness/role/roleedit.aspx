﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="roleedit.aspx.cs" Inherits="TX_Bussiness.Web.bussiness.role.roleedit" %>

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
        $(".valifrom").Validform({
            tiptype: function (msg, o, cssctl) {
              tipSweep: true,
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
    </script>
</head>
<body>
    <form action="/bussiness/role/roleedit.aspx" method="post" class="valifrom">
    <div class="alert alert-info tit">
        当前位置<b class="tip"></b>维护界面<b class="tip"></b>修改</div>
    <table class="table table-striped table-bordered table-condensed list">
        <thead>
            <tr>
                <td colspan="4">
                    <b>案卷基本信息</b>
                </td>
            </tr>
        </thead>
        <tbody>
            <tr>
                <td width="15%">
                    角色名称<font color="FF0000">*</font>
                    <input type="hidden" value="<%=model.Id %>" name="id" />
                </td>
                <td width="500" colspan="3">
                    <input name="txt_rolename" value="<%=model.Rolename %>" type="text" datatype="*" nullmsg="请填写角色名称！"/>
                </td>
            </tr>
            <tr>
                <td>
                    所有权限<font color="FF0000">*</font>  <input type="hidden" name="limitids" value=""/>
                </td>
                <td colspan="3">
                    <label class="c_role"><input type="checkbox"  name="limitid" value="<%=TX_Bussiness.Web.Comm.Constant.RYDW %>"<%=HasLimit(TX_Bussiness.Web.Comm.Constant.RYDW,model.Limitid)?"checked='checked'":"" %>/>人员定位系统</label>
                    <label class="c_role"><input type="checkbox" name="limitid" value="<%=TX_Bussiness.Web.Comm.Constant.QWSS %>" <%=HasLimit(TX_Bussiness.Web.Comm.Constant.QWSS,model.Limitid)?"checked='checked'":"" %>/>勤务实时系统</label>  
                    <label class="c_role"><input type="checkbox" name="limitid" value="<%=TX_Bussiness.Web.Comm.Constant.SBJB %>" <%=HasLimit(TX_Bussiness.Web.Comm.Constant.SBJB,model.Limitid)?"checked='checked'":"" %>/>上报交办系统</label>  
                    <label class="c_role"><input type="checkbox" name="limitid"  value="<%=TX_Bussiness.Web.Comm.Constant.QWSJ %>" <%=HasLimit(TX_Bussiness.Web.Comm.Constant.QWSJ,model.Limitid)?"checked='checked'":"" %>/>勤务数据系统</label>   
                    <label class="c_role"><input type="checkbox" name="limitid" value="<%=TX_Bussiness.Web.Comm.Constant.YYWH%>" <%=HasLimit(TX_Bussiness.Web.Comm.Constant.YYWH,model.Limitid)?"checked='checked'":"" %>/>应用维护系统</label>      
                </td>
              
            </tr>
        
        </tbody>
        <tfoot>
            <tr>
                <td colspan="4">
                    <input class="btn btn-primary" id="find" onclick="return initcheck();" type="submit" value="保存" />
                    <input class="btn btn-primary" type="button" value="取消" onclick="window.history.go(-1)" />
                </td>
            </tr>
        </tfoot>
    </table>
    </form>
</body>
</html>


