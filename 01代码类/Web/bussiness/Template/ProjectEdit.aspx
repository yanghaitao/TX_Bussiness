<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProjectEdit.aspx.cs" Inherits="TX_Bussiness.Web.bussiness.Template.ProjectEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title></title>
    <link rel="stylesheet" type="text/css" href="../Styles/bootstrap.min.css" />
    <link rel="stylesheet" type="text/css" href="../Styles/admin-all.css" />
    <link rel="stylesheet" type="text/css" href="/bussiness/Styles/chur.css" />
    <script type="text/javascript" src="../Scripts/jquery-1.7.2.js"></script>
    <script type="text/javascript" src="../Scripts/jquery-ui-1.8.22.custom.min.js"></script>
    <link rel="stylesheet" type="text/css" href="../Styles/ui-lightness/jquery-ui-1.8.22.custom.css" />
    <script type="text/javascript" src="../Scripts/ChurAlert.min.js?skin=blue"></script>
    <script type="text/javascript" src="../Scripts/chur-alert.1.0.js"></script>
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
    <form name="form1" action="/bussiness/template/projectedit.aspx" method="post" class="valifrom">
    <div class="alert alert-info tit">
        当前位置<b class="tip"></b>维护界面<b class="tip"></b>案卷办理</div>
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
                    勤务编号<font color="FF0000">*</font>
                    <input type="hidden" name="projcode" value="<%=model.Projcode %>" />
                </td>
                <td width="500">
                    <input name="Name" value="<%=string.Format(GetAppSeeting("ProjectNameTemplate"),model.Projcode)%>"
                        type="text" readonly="readonly" />
                </td>
                <td width="500">
                    上报人<font color="FF0000">*</font>
                </td>
                <td width="500">
                    <input name="Name" value="<%=model.Reportpersonname %>" type="text" readonly="readonly" />
                </td>
            </tr>
            <tr>
                <td>
                    区域<font color="FF0000">*</font>
                </td>
                <td>
                    <input name="Name" value="<%=GetAreaName(model.Areacode) %>" type="text" readonly="readonly" />
                </td>
                <td>
                    街道<font color="FF0000">*</font>
                </td>
                <td>
                    <input name="Name" value="<%=GetStreetName(model.Streetcode) %>" type="text" readonly="readonly" />
                </td>
            </tr>
            <tr>
                <td>
                    社区<font color="FF0000">*</font>
                </td>
                <td>
                    <input name="Name" value="<%=GetCommName(model.Communitycode )%>" type="text" readonly="readonly" />
                </td>
                <td>
                    大类<font color="FF0000">*</font>
                </td>
                <td>
                    <input name="Name" value="<%=model.Bigclassname %>" type="text" readonly="readonly" />
                </td>
            </tr>
            <tr>
                <td>
                    小类<font color="FF0000">*</font>
                </td>
                <td>
                    <input name="Name0" value="<%=model.Smallclassname %>" type="text" readonly="readonly" />
                </td>
                <td>
                    所属地区<font color="FF0000">*</font>
                </td>
                <td>
                    <input name="Name" value="" type="text" readonly="readonly" />
                </td>
            </tr>
            <tr>
                <td width="15%">
                    上报时间<font color="FF0000">*</font>
                </td>
                <td>
                    <input name="Name" value="<%=model.Adddate %>" type="text" readonly="readonly" />
                </td>
                </td>
                <td width="500">
                    是否短信通知
                </td>
                <td width="500">
                    <input name="ismessage" type="radio" value="V1" checked="checked" />
                    需要
                    <input type="radio" name="ismessage" value="V1" />
                    不需要
                </td>
            </tr>
            <%if (!CheckRole(GetUserInfo().Id, TX_Bussiness.Web.Comm.Constant.RoleCode_JLD) && model.Reportpersonid != GetUserInfo().Id)
              {%>
            <tr>
                <td width="15%">
                    上级部门<font color="FF0000">*</font>
                </td>
                <td>
                    <input name="txt_operatordepart" value="<%=GetDepartName(tracemodel.Operatordepart.ToString()) %>"
                        type="text" readonly="readonly" />
                </td>
                <td width="500">
                    批转人
                </td>
                <td width="500">
                    <input name="txt_operator" type="text" value="<%=tracemodel.Operatorname %>" readonly="readonly" />
                </td>
            </tr>
            <%} %>
            <tr>
                <%if (CheckRole(GetUserInfo().Id, TX_Bussiness.Web.Comm.Constant.RoleCode_JLD))
                  { %>
                <td>
                    处理部门<font color="FF0000">*</font>
                </td>
                <td>
                    <select name="txt_depart" datatype="*" nullmsg="请选择派遣部门！">
                        <%foreach (var v in delartlist)
                          { %>
                        <option value="<%=v.Id %>">
                            <%=v.Departname%>
                        </option>
                        <%} %>
                    </select>
                </td>
                <%}
                  else if (CheckRole(GetUserInfo().Id, TX_Bussiness.Web.Comm.Constant.RoleCode_ZDZ))
                  {%>
                <td>
                    处理人<font color="FF0000">*</font>
                </td>
                <td>
                    <select name="txt_handler" datatype="*" nullmsg="请选择处理人员！">
                        <%foreach (var v in GetUserList(GetUserInfo().Departcode.ToString(), true))
                          { %>
                        <option value="<%=v.Id %>">
                            <%=v.Username%>
                        </option>
                        <%} %>
                    </select>
                </td>
                <%} %>
            </tr>
            <tr>
                <td width="15%">
                    事发地址
                </td>
                <td width="500" colspan="3" height="">
                    <textarea name="txt_address" style="width: 95%" rows="2" cols="5" readonly="readonly"><%=model.Address %></textarea>
                </td>
            </tr>
            <tr>
                <td width="15%">
                    案卷描述
                </td>
                <td width="500" colspan="3" height="">
                    <textarea name="txt_describe" style="width: 95%" rows="4" cols="5" readonly="readonly"><%=model.Describe %></textarea>
                </td>
            </tr>
            <tr>
                <td width="15%">
                    局领导派遣意见
                </td>
                <td width="500" colspan="3" height="">
                    <textarea name="txt_leadmessage" style="width: 95%" rows="4" cols="5" <%if(CheckRole(GetUserInfo().Id, TX_Bussiness.Web.Comm.Constant.RoleCode_JLD)){ %> datatype="s1-200" nullmsg="请填写派遣意见！"<%} %>><%=model.Leadmessage %></textarea>
                </td>
            </tr>
            <tr>
                <td width="15%">
                    中队长派遣意见
                </td>
                <td width="500" colspan="3" height="">
                    <textarea name="txt_message" style="width: 95%" rows="4" cols="5" <%if(CheckRole(GetUserInfo().Id, TX_Bussiness.Web.Comm.Constant.RoleCode_ZDZ)){ %> datatype="s1-200" nullmsg="请填写派遣意见！"<%} %>><%=model.Message %></textarea>
                </td>
            </tr>
            <tr>
                <td width="15%">
                    执法人员处置结果
                </td>
                <td width="500" colspan="3" height="">
                    <textarea name="txt_handlemessage" style="width: 95%" rows="4" cols="5" <%if(CheckRole(GetUserInfo().Id, TX_Bussiness.Web.Comm.Constant.RoleCode_ZFRY)){ %> datatype="s1-200" nullmsg="请填写派遣意见！"<%} %>><%=model.Handlermessge %></textarea>
                </td>
            </tr>
        </tbody>
        <tfoot>
            <tr>
                <td colspan="4">
                    <input class="btn btn-primary" id="saveproject" type="submit" value="保存" />
                    <input class="btn btn-primary" type="button" value="取消" onclick="window.history.go(-1);" />
                </td>
            </tr>
        </tfoot>
    </table>
    </form>
</body>
</html>
