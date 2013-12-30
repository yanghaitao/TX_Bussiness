<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProjectAdd.aspx.cs" Inherits="TX_Bussiness.Web.bussiness.Template.ProjectAdd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title></title>
    <link rel="stylesheet" type="text/css" href="../Styles/bootstrap.min.css" />
    <link rel="stylesheet" type="text/css" href="../Styles/admin-all.css" />
    <link rel="stylesheet" type="text/css" href="/uploadify/uploadify.css" />
    <script type="text/javascript" src="../Scripts/jquery-1.7.2.js"></script>
    <script type="text/javascript" src="../Scripts/jquery-ui-1.8.22.custom.min.js"></script>
    <link rel="stylesheet" type="text/css" href="../Styles/ui-lightness/jquery-ui-1.8.22.custom.css" />
    <script type="text/javascript" src="/uploadify/jquery.uploadify.js"></script>
    <script src="/js/json2.js" type="text/javascript"></script>
    <script src="/js/global.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            var filename = "";
            $("#file_upload").uploadify({
                'swf': '/uploadify/uploadify.swf',
                'uploader': '/tools/AjaxHandler.ashx',
                'formData': { 'act': 'UploadFile' },
                'auto': false,
                'buttonText': '选择图片',
                'buttonClass': 'btn btn-primary',
                'fileTypeExts': '*.gif; *.jpg; *.png',
                'width': 50,
                'height': 20,
                'onUploadSuccess': function (file, data, response) {
                    filename += data+",";
                },
                'onQueueComplete' : function(queueData) {
                    alert(filename);
                  }
            });
           
        })
    </script>
</head>
<body>
    <form action="/bussiness/template/projectadd.aspx" method="post">
    <div class="alert alert-info">
        当前位置<b class="tip"></b>维护界面<b class="tip"></b>案卷登记</div>
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
                    上报人<font color="FF0000">*</font>
                </td>
                <td width="500">
                    <input name="txt_name" value="<%=user.Username %>" type="text" readonly="readonly" />
                </td>
                <td width="500">
                    坐标<font color="FF0000">*</font>
                </td>
                <td width="500">
                    <input name="txt_location" value="" type="text" />
                </td>
            </tr>
            <tr>
                <td>
                    所属区域<font color="FF0000">*</font>
                </td>
                <td>
                    <select name="txt_area">
                        <%foreach (var v in Arealist())
                          { %>
                        <option value="<%=v.Areacode %>">
                            <%=v.Areaname %>
                        </option>
                        <%} %>
                    </select>
                </td>
                <td>
                    所属街道<font color="FF0000">*</font>
                </td>
                <td>
                    <select name="txt_street">
                        <%foreach (var v in Streettlist())
                          { %>
                        <option value="<%=v.Streetcode %>">
                            <%=v.Streetname %>
                        </option>
                        <%} %>
                    </select>
                </td>
            </tr>
            <tr>
                <td>
                    所属社区<font color="FF0000">*</font>
                </td>
                <td>
                    <select name="txt_commnuity">
                        <%foreach (var v in Communitylist())
                          {
                              if (!string.IsNullOrEmpty(v.Commname))
                              {%>
                        <option value="<%=v.Commcode %>">
                            <%=v.Commname %>
                        </option>
                        <%}
                       }%>
                    </select>
                </td>
                <td>
                    大类<font color="FF0000">*</font>
                </td>
                <td>
                    <select name="txt_bigclass">
                        <option value="0">全部 </option>
                        <%foreach (var v in GetProjectClass())
                          { %>
                        <option value="<%=v.Id %>">
                            <%=v.Classname %>
                        </option>
                        <%} %>
                    </select>
                </td>
            </tr>
            <tr>
                <td>
                    案卷类型<font color="FF0000">*</font>
                </td>
                <td>
                    <select name="txt_projecttype">
                        <option value="1">一般 </option>
                        <option value="2">紧急 </option>
                    </select>
                </td>
                <td>
                    小类<font color="FF0000">*</font>
                </td>
                <td>
                    <select name="txt_smallclass">
                    </select>
                </td>
            </tr>
            <tr>
                <td width="15%">
                    事发位置
                </td>
                <td width="500" colspan="3" height="">
                    <textarea name="txt_address" style="width: 95%" rows="2" cols="5"></textarea>
                </td>
            </tr>
            <tr>
                <td width="15%">
                    情况描述
                </td>
                <td width="500" colspan="3" height="">
                    <textarea name="txt_describ" style="width: 95%" rows="4" cols="5"></textarea>
                </td>
            </tr>
            <tr>
                <td width="15%">
                    上传图片
                </td>
                <td width="500" colspan="3" height="">
                    <input type="file" name="file_upload" id="file_upload" />
                    <button type="button" onclick="$('#file_upload').uploadify('upload','*')" class="btn btn-primary">
                        上传</button>
                    <button type="button" onclick="$('#file_upload').uploadify('cancel', '*')" class="btn btn-primary">
                        取消</button>
                </td>
            </tr>
        </tbody>
        <tfoot>
            <tr>
                <td colspan="4">
                    <input class="btn btn-inverse" id="find" type="submit" value="保存" />
                    <input class="btn btn-inverse" type="button" value="取消" onclick="window.history.go(-1)" />
                </td>
            </tr>
        </tfoot>
    </table>
    </form>
</body>
</html>
