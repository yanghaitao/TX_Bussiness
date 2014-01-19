
//var jsonStr = '[{"stuName":[{"name":"Tom"},{"name":"Jack"},{"name":"jony"}]},{"className":[{"class":"基础日语"},{"class":"中级日语"},{"class":"Java SE"}]}]';
//var jsonO = eval("("+jsonStr+")");  
//alert(jsonO[0].stuName[0].name);
//alert(jsonO[0].stuName[1].name);
//alert(jsonO[1].className[0].class);


//system
//model
//action

//    <div class="nav">
    //  <ul class="left">
    //    <li><a href="index.html">首 页</a></li>
    //    <li><a href="xinfangchengpi1.html">信访录入</a></li>
    //    <li class="cur"><a href="xinfangguanlian.html">信访关联</a></li>
    //    <li><a href="xinfangyujing.html">信访预警</a></li>
    //    <li><a href="xinfangtongji.html">信访统计</a></li>
    //  </ul>
    //</div>

function create_sbjbmenu(cur){
var sbjb = new Array("首 页", "任务处理", "任务查询", "知识库", "帮助");
var sbjb_url = new Array("Index", "rwcl", "ryQuery", "zsk", "bz");
var createsrc = "<ul class=\"left\">";
for (var i = 0; i < sbjb.length; i++) {
    if (sbjb[i] == cur) {
        createsrc = createsrc + "<li class=\"cur\"><a href=\"" + sbjb_url[i] + ".aspx\">" + sbjb[i] + "</a></li>";
     }
    else {
        createsrc = createsrc + "<li><a href=\"" + sbjb_url[i] + ".aspx\">" + sbjb[i] + "</a></li>";
    }
    if (i == sbjb.length - 1)
    {
        createsrc = createsrc + "</ul>";
    }
}
$("#menu").html(createsrc);
}


function create_qwsjbmenu(cur) {
    var sbjb = new Array("首 页", "勤务统计", "勤务统计(图表)", "知识库", "帮助");
    var sbjb_url = new Array("index", "area_info","areachart", "zsk", "bz");
    var createsrc = "<ul class=\"left\">";
    for (var i = 0; i < sbjb.length; i++) {
        if (sbjb[i] == cur) {
            createsrc = createsrc + "<li class=\"cur\"><a href=\"" + sbjb_url[i] + ".aspx\">" + sbjb[i] + "</a></li>";
        }
        else {
            createsrc = createsrc + "<li><a href=\"" + sbjb_url[i] + ".aspx\">" + sbjb[i] + "</a></li>";
        }
        if (i == sbjb.length - 1) {
            createsrc = createsrc + "</ul>";
        }
    }
$("#menu").html(createsrc);
}