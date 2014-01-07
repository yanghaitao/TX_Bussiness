$(function () {
    function comm() {
        this.checkall = function (checkname, outvalname) {
            $("input[name='" + checkname + "']").attr("checked", true);
            var arrChk = $("input[name='" + checkname + "']:checked");
            var ids = "";
            //遍历得到每个checkbox的value值
            for (var i = 0; i < arrChk.length; i++) {
                ids += arrChk[i].value + ",";
            }
            $("input[name='" + outvalname + "']").val(ids);
        }
        this.uncheckall = function (checkname, outvalname) {
            $("input[name='" + checkname + "']").attr("checked", false);
            $("input[name='" + outvalname + "']").val("");
        }
    }

    var com = new comm();
    $("#checkall").click(function () {
        if ($(this).attr("checked") == "checked") {
            com.checkall("txt_check", "id_list");
        }
        else {
            com.uncheckall("txt_check", "id_list");
        }
    })

    var showbox = function (_type, _content) {
        $('body').alert({
            type: _type,
            content: _content
        })
        return false;
    }
})

function getallCheck(checkname) {
    var arrChk = $("input[name='" + checkname + "']:checked");
    var ids = "";
    //遍历得到每个checkbox的value值
    for (var i = 0; i < arrChk.length; i++) {
        ids += arrChk[i].value + ",";
    }
    return ids;
}

function deleuser(id) {
    if (window.confirm("确认要删除吗?")) {
        $.post("/tools/AjaxHandler.ashx", { act: "DeleteUser", id: id }, function (data) {
            if (data == "1")
                window.location.reload();
            else
                alert("删除失败！");
        })
    }
}

function deledepart(id) {
    if (window.confirm("确定要删除吗？")) {
        $.post("/tools/AjaxHandler.ashx", { act: "DeleteDepart", id: id }, function (data) {
            if (data == "1")
                window.location.reload();
            else
                alert("删除失败！");
        })
    }
}

function delerol(id) {
    if (window.confirm("确定要删除吗?"))
        $.post("/tools/AjaxHandler.ashx", { act: "DeleteRole", id: id }, function (data) {
            if (data == "1") window.location.reload();
            else alert("删除失败！");
        })
}

function deleclass(id) {
    if (window.confirm("确定要删除吗?"))
        $.post("/tools/AjaxHandler.ashx", { act: "DeleteClass", id: id }, function (data) {
            if (data == "1") window.location.reload();
            else alert("删除失败！");
        })
}
function initcheck() {
    var arrChk = $("input[name='limitid']:checked");
    var ids = "";
    //遍历得到每个checkbox的value值
    for (var i = 0; i < arrChk.length; i++) {
        ids += arrChk[i].value + ",";
    }
    $("input[name='limitids']").val(ids);
    return true;
}

function deleall(checkname, table) {
    if (window.confirm("确定要删除吗?")) {
        var ids = getallCheck(checkname);
        if (ids.length == 0) {
            alert("您未选择删除项！");
            return;
        }
        $.post("/tools/AjaxHandler.ashx", { act: "DeleteAll", model: table, ids: ids }, function (data) {
            if (data == "1") window.location.reload();
            else alert("删除失败！");
        })
    }
}

$(function () {
    $("select[name='txt_area']").change(function () {
        var value = $(this).val();
        if (value != "0") {
            $.post("/tools/AjaxHandler.ashx", { act: "GetStreetList", areacode: value }, function (data) {
                if (data != "" && data.length > 0) {
                    var jsondata = JSON.parse(data);
                    var options = "<option value=''>全部</option>";
                    $.each(jsondata, function (i, item) {
                        options += "<option value='" + item.Streetcode + "'>" + item.Streetname + "</option>";
                    })
                    $("select[name='txt_street']").html(options);
                } else { $("select[name='txt_street']").html("<option value=''>全部</option>"); }
            })
        }
    });

    $("select[name='txt_street']").change(function () {
        var value = $(this).val();
        if (value != "0") {
            $.post("/tools/AjaxHandler.ashx", { act: "GetCommunityList", streetcode: value }, function (data) {
                if (data != "" && data.length > 0) {
                    var jsondata = JSON.parse(data);
                    var options = "<option value=''>全部</option>";
                    $.each(jsondata, function (i, item) {
                        options += "<option value='" + item.Commcode + "'>" + item.Commname + "</option>";
                    })
                    $("select[name='txt_commnuity']").html(options);
                } else { $("select[name='txt_commnuity']").html("<option value=''>全部</option>"); }
            })
        }
    })

    $("select[name='txt_bigclass']").change(function () {
        var value = $(this).val();
        $.post("/tools/AjaxHandler.ashx", { act: "GetSmallClass", bigclasscode: value }, function (data) {
            if (data != "" && data.length > 0) {
                var jsondata = JSON.parse(data);
                var options = "";
                $.each(jsondata, function (i, item) {
                    options += "<option value='" + item.Id + "'>" + item.Classname + "</option>";
                })
                $("select[name='txt_smallclass']").html(options);
            } else
            { $("select[name='txt_smallclass']").html(""); }
        })
    })

    $("select[name='txt_classcode']").change(function () {
        var classcode = $(this).val();
        if (classcode != "0") {
            $.post("/tools/AjaxHandler.ashx", { act: "GetProjessClassJson", parentcode: classcode }, function (data) {
                if (data != "" && data.length > 0) {
                    var jsondata = JSON.parse(data);
                    var options = "<option value=''>无</option>";
                    $.each(jsondata, function (i, item) {
                        options += "<option value='" + item.Id + "'>" + item.Classname + "</option>";
                    })
                    $("select[name='txt_bigclass']").html(options);
                }
            })
        }
        else {
            $("select[name='txt_bigclass']").html("<option value=''>无</option>");
        }
    });

    $(".valifrom").Validform({
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
function Refstate() {
    window.location.reload();
}

function delemodel(id, table) {
    if (window.confirm("确定要删除吗？")) {
        $.post("/tools/AjaxHandler.ashx", { act: "DeleModel", model: table, id: id }, function (data) {
            if (data == "1") {
                $("bordy").alert({
                    type: "success"
                })
                window.setTimeout("Refstate();", 500)
            }
            else {
                $("bordy").alert({
                    type: "danger"
                })
            }
        })
    }
}

function viladeExist(obj, tablename) {
    var action = "";
    var val = "";
    var errormsg = "";
    if (tablename == "depart") {
        action = "DepartIsExist";
        val = $("input[name='txt_departname']").val();
        errormsg = "该部门已存在！"
    }
    if (tablename == "user") {
        action = "UserIsExist";
        val = $("input[name='txt_username']").val();
        errormsg = "该用户名已存在！";
    }
    if (obj == "0") {
        $.post("/tools/AjaxHandler.ashx", { act: action, name: val }, function (data) {
            if (data == "1") {
                $("body").alert({
                    type: "warning",
                    content: errormsg
                });
                return false;
            } else {
                $("#form1").submit();
            }
        })
    } else {
        $("#form1").submit();
    }
}

function NoLimit() {
    $('body').alert({
        type: "primary"
    });
    return false;
}