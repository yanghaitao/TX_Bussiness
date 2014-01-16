<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserEdit.aspx.cs" Inherits="TX_Bussiness.Web.bussiness.users.UserEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title></title>
    <link rel="stylesheet" type="text/css" href="/bussiness/Styles/bootstrap.min.css" />
    <link rel="stylesheet" type="text/css" href="/bussiness/Styles/admin-all.css" />
     <link rel="stylesheet" type="text/css" href="/uploadify/uploadify.css" />
    <script type="text/javascript" src="/bussiness/Scripts/jquery-1.7.2.js"></script>
    <script type="text/javascript" src="/bussiness/Scripts/jquery-ui-1.8.22.custom.min.js"></script>
    <link rel="stylesheet" type="text/css" href="/bussiness/Styles/ui-lightness/jquery-ui-1.8.22.custom.css" />
    <script src="/js/json2.js" type="text/javascript"></script>
    <script type="text/javascript" src="/bussiness/Scripts/ChurAlert.min.js?skin=blue"></script>
    <script type="text/javascript" src="/bussiness/Scripts/chur-alert.1.0.js"></script>
    <link rel="stylesheet" type="text/css" href="/bussiness/Styles/chur.css" />
    <script type="text/javascript" src="/uploadify/jquery.uploadify.js"></script>
    <script src="/js/global.js" type="text/javascript"></script> 
    <script src="/js/Validform_v5.3.2.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            var filename = "";
            $("#file_upload").uploadify({
                'swf': '/uploadify/uploadify.swf',
                'multi': false,
                'uploader': '/tools/AjaxHandler.ashx',
                'formData': { 'act': 'UploadPhoto' },
                'auto': true,
                'buttonText': '上传',
                'buttonClass': 'btn btn-primary',
                'fileTypeExts': '*.gif; *.jpg; *.png',
                'width': 30,
                'height': 15,
                'onUploadSuccess': function (file, data, response) {
                    $("#txt_photo").attr("src", data);
                    $("#fileimgs").val(data);
                }
            });
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

            $("select[name='txt_ismobile']").change(function () {
                if ($(this).val() == "2") {
                    $("select[name='txt_street']").attr("disabled", "disabled").attr("datatype", "");
                    $("select[name='txt_commnuity']").attr("disabled", "disabled").attr("datatype", "");
                } else {
                    $("select[name='txt_street']").attr("disabled", false).attr("datatype", "*");
                    $("select[name='txt_commnuity']").attr("disabled", false).attr("datatype", "*");
                }
            })
            var usertype = "<%=model.Usertype %>";
            if (usertype && usertype == 2) {
                $("select[name='txt_street']").attr("disabled", "disabled").attr("datatype", false);
                $("select[name='txt_commnuity']").attr("disabled", "disabled").attr("datatype", false);
            }
        })
    </script>
</head>
<body>
    <form action="/bussiness/users/useredit.aspx" method="post" id="form1" class="valifrom">
    <div class="alert alert-info tit">
        当前位置<b class="tip"></b>维护界面<b class="tip"></b>用户编辑</div>
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
                    登录名<font color="FF0000">*</font>
                    <input type="hidden" value="<%=model.Id %>"  name="id" />
                </td>
                <td width="500">
                    <input name="txt_username" value="<%=model.Loginname %>" onblur="viladeExist(<%=model.Id %>,'user')" type="text" datatype="*" nullmsg="请填写登录名！"/>
                </td>
                <td width="500">
                    密码<font color="FF0000">*</font>
                </td>
                <td width="500">
                    <input name="txt_password" value="<%=model.Password %>" type="text" datatype="*" nullmsg="请填写密码！"/>
                </td>
            </tr>
            <tr>
                <td>
                    姓名<font color="FF0000">*</font>
                </td>
                <td>
                    <input name="txt_name" value="<%=model.Username %>" type="text" datatype="*" nullmsg="请填写姓名！"/>
                </td>
                <td>
                    手机<font color="FF0000">*</font>
                </td>
                <td>
                    <input name="txt_mobile" value="<%=model.Usermobile %>" type="text" datatype="*,m" nullmsg="请填写正确的手机号码！"/>
                </td>
            </tr>
            <tr>
                <td>
                    固话<font color="FF0000">*</font>
                </td>
                <td>
                    <input name="txt_tel" value="<%=model.Usertel %>" type="text" datatype="*" nullmsg="请填写电话号码！"/>
                </td>
                <td>
                    邮箱<font color="FF0000">*</font>
                </td>
                <td>
                    <input name="txt_email" value="<%=model.Useremail%>" type="text" datatype="e" nullmsg="请填写正确的邮箱！"/>
                </td>
            </tr>
            <tr>
            <td>
                    用户类型<font color="FF0000">*</font>
                </td>
                <td>
                    <select name="txt_ismobile" datatype="*" nullmsg="请填选择用户部门！">
                       <option value="1" <%=model.Usertype==1?"selected='selected'":"" %>>普通用户 </option>
                        <option value="2" <%=model.Usertype==2?"selected='selected'":"" %>>城管通用户 </option>
                    </select>
                </td>
                <td>
                    区域<font color="FF0000">*</font>
                </td>
                <td>
                    <select name="txt_area" datatype="*" nullmsg="请选择区域！">
                        <%foreach (var v in Arealist())
                          {
                              if (!string.IsNullOrEmpty(v.Areaname))
                              {%>
                        <option value="<%=v.Areacode %>" <%=model.Collectorareacode==v.Areacode.ToString()?"selected='selected'":"" %>>
                            <%=v.Areaname %>
                        </option>
                        <%}
                          }%>
                    </select>
                </td>
                
            </tr>
            <tr>
            <td>
                    街道<font color="FF0000">*</font>
                </td>
                <td>
                    <select name="txt_street" datatype="*" nullmsg="请填选择街道！">
                        <option value="">全部 </option>
                        <%foreach (var v in Streettlist())
                          {
                              if (v.Streetname != "")
                              {%>
                        <option value="<%=v.Streetcode %>" <%if(model.Streetcode==v.Streetcode.ToString()) {%>selected="selected"
                            <%} %>>
                            <%=v.Streetname%></option>
                        <%}
                          }%>
                    </select>
                </td>
                <td>
                    社区<font color="FF0000">*</font>
                </td>
                <td>
                    <select name="txt_commnuity" datatype="*" nullmsg="请选择社区！">
                        <option value="">全部 </option>
                        <%foreach (var v in Communitylist())
                          {
                              if (v.Commname != "")
                              {%>
                         <option value="<%=v.Commcode %>" <%if(model.Communitycode==v.Commcode.ToString()) {%>selected="selected"
                            <%} %>>
                            <%=v.Commname%></option>
                        <%}
                         }%>
                    </select>
                </td>
                
            </tr>
               <tr>
                <td>
                    部门<font color="FF0000">*</font>
                </td>
                <td>
                    <select name="txt_depart" datatype="*" nullmsg="请选择部门！">
                        <%foreach (var v in Departlist())
                          { %>
                        <option value="<%=v.Id %>" <%=v.Id==model.Departcode?"selected='selected'":"" %>">
                            <%=v.Departname%>
                        </option>
                        <%} %>
                    </select>
                </td>
               <td>
                    所属角色<font color="FF0000">*</font>
                </td>
                <td>
                   <select name="txt_rolecode" datatype="*" nullmsg="请选择用户所属角色！">
                        <%foreach (var v in GetRoleList())
                          {
                              if (!string.IsNullOrEmpty(v.Rolename))
                              {%>
                        <option value="<%=v.Id %>" <%=model.Roleid==v.Id?"selected='selected'":"" %>>
                            <%=v.Rolename %>
                        </option>
                        <%}
                          }%>
                    </select>
                </td>
            </tr>
             <tr>
                <td rowspan="2">
                    性别<font color="FF0000">*</font>
                </td>
                <td rowspan="2">
                <label> 
                    <input name="txt_sex" type="radio" value="1" checked="checked" /> 男&nbsp;&nbsp
                    <input type="radio" name="txt_sex" value="2" <%=model.Usersex=="2"?"checked=checked":"" %>/> 女
                </label>
                </td>
                <td rowspan="2">
                   照片
                    <input type="hidden" value="<%=model.Userphoto %>" name="fileimgs" id="fileimgs" />
                    <input type="file" name="file_upload" id="file_upload" />
                </td>
                <td rowspan="2">
                     <img src="<%=model.Userphoto %>" id="txt_photo" width="80px" height="100px"/>
                </td>
            </tr>
        </tbody>
        <tfoot>
            <tr>
                <td colspan="4">
                    <input class="btn btn-primary" id="find" type="submit" value="保存" />
                    <input class="btn btn-primary" type="button" value="取消" onclick="window.history.go(-1)" />
                </td>
            </tr>
        </tfoot>
    </table>
    </form>
</body>
</html>
