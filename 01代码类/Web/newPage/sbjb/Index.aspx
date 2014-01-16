<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="TX_Bussiness.Web.newPage.sbjb.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link rel="stylesheet" type="text/css" href="../style/css/reset.css" />
    <link rel="stylesheet" type="text/css" href="../style/css/index.css" />
    <link id="skin" rel="stylesheet" href="../style/Blue/jbox.css" />
    <script src="../js/jquery-1.6.1.js" type="text/javascript"></script>
    <script src="../My97DatePicker/WdatePicker.js" type="text/javascript"></script>
    <script type="text/javascript" src="../js/popup_layer.js"></script>
    <script type="text/javascript" src="../js/jquery.jBox.src.js"></script>
    <script type="text/javascript" src="../js/public.js"></script>
    <script type="text/javascript">
        var _jBoxConfig = {};
        _jBoxConfig.defaults = {
            id: null, /* 在页面中的唯一ID，如果为null则自动为随机ID,一个ID只会显示一个jBox */
            top: '15%', /* 窗口离顶部的距离,可以是百分比或像素(如 '100px') */
            border: 5, /* 窗口的外边框像素大小,必须是0以上的整数 */
            opacity: 0.2, /* 窗口隔离层的透明度,如果设置为0,则不显示隔离层 */
            timeout: 0, /* 窗口显示多少毫秒后自动关闭,如果设置为0,则不自动关闭 */
            showType: 'fade', /* 窗口显示的类型,可选值有:show、fade、slide */
            showSpeed: 'fast', /* 窗口显示的速度,可选值有:'slow'、'fast'、表示毫秒的整数 */
            showIcon: true, /* 是否显示窗口标题的图标，true显示，false不显示，或自定义的CSS样式类名（以为图标为背景） */
            showClose: true, /* 是否显示窗口右上角的关闭按钮 */
            draggable: true, /* 是否可以拖动窗口 */
            dragLimit: true, /* 在可以拖动窗口的情况下，是否限制在可视范围 */
            dragClone: false, /* 在可以拖动窗口的情况下，鼠标按下时窗口是否克隆窗口 */
            persistent: true, /* 在显示隔离层的情况下，点击隔离层时，是否坚持窗口不关闭 */
            showScrolling: true, /* 是否显示浏览的滚动条 */
            ajaxData: {},  /* 在窗口内容使用post:前缀标识的情况下，ajax post的数据，例如：{ id: 1 } 或 "id=1" */
            iframeScrolling: 'auto', /* 在窗口内容使用iframe:前缀标识的情况下，iframe的scrolling属性值，可选值有：'auto'、'yes'、'no' */

            title: 'jBox', /* 窗口的标题 */
            width: 350, /* 窗口的宽度，值为'auto'或表示像素的整数 */
            height: 'auto', /* 窗口的高度，值为'auto'或表示像素的整数 */
            bottomText: '', /* 窗口的按钮左边的内容，当没有按钮时此设置无效 */
            buttons: { '确定': 'ok' }, /* 窗口的按钮 */
            buttonsFocus: 0, /* 表示第几个按钮为默认按钮，索引从0开始 */
            loaded: function (h) { }, /* 窗口加载完成后执行的函数，需要注意的是，如果是ajax或iframe也是要等加载完http请求才算窗口加载完成，参数h表示窗口内容的jQuery对象 */
            submit: function (v, h, f) { return true; }, /* 点击窗口按钮后的回调函数，返回true时表示关闭窗口，参数有三个，v表示所点的按钮的返回值，h表示窗口内容的jQuery对象，f表示窗口内容里的form表单键值 */
            closed: function () { } /* 窗口关闭后执行的函数 */
        };
        _jBoxConfig.stateDefaults = {
            content: '', /* 状态的内容，不支持前缀标识 */
            buttons: { '确定': 'ok' }, /* 状态的按钮 */
            buttonsFocus: 0, /* 表示第几个按钮为默认按钮，索引从0开始 */
            submit: function (v, h, f) { return true; } /* 点击状态按钮后的回调函数，返回true时表示关闭窗口，参数有三个，v表示所点的按钮的返回值，h表示窗口内容的jQuery对象，f表示窗口内容里的form表单键值 */
        };
        _jBoxConfig.tipDefaults = {
            content: '', /* 提示的内容，不支持前缀标识 */
            icon: 'info', /* 提示的图标，可选值有'info'、'success'、'warning'、'error' */
            top: '40%', /* 提示离顶部的距离,可以是百分比或像素(如 '100px') */
            width: 'auto', /* 提示的高度，值为'auto'或表示像素的整数 */
            height: 'auto', /* 提示的高度，值为'auto'或表示像素的整数 */
            opacity: 0, /* 窗口隔离层的透明度,如果设置为0,则不显示隔离层 */
            timeout: 2000, /* 提示显示多少毫秒后自动关闭,必须是大于0的整数 */
            closed: function () { } /* 提示关闭后执行的函数 */
        };
        _jBoxConfig.messagerDefaults = {
            content: '', /* 信息的内容，不支持前缀标识 */
            title: 'jBox', /* 信息的标题 */
            icon: 'none', /* 信息图标，值为'none'时为不显示图标，可选值有'none'、'info'、'question'、'success'、'warning'、'error' */
            width: 350, /* 信息的高度，值为'auto'或表示像素的整数 */
            height: 'auto', /* 信息的高度，值为'auto'或表示像素的整数 */
            timeout: 3000, /* 信息显示多少毫秒后自动关闭,如果设置为0,则不自动关闭 */
            showType: 'slide', /* 信息显示的类型,可选值有:show、fade、slide */
            showSpeed: 600, /* 信息显示的速度,可选值有:'slow'、'fast'、表示毫秒的整数 */
            border: 0, /* 信息的外边框像素大小,必须是0以上的整数 */
            buttons: {}, /* 信息的按钮 */
            buttonsFocus: 0, /* 表示第几个按钮为默认按钮，索引从0开始 */
            loaded: function (h) { }, /* 窗口加载完成后执行的函数，参数h表示窗口内容的jQuery对象 */
            submit: function (v, h, f) { return true; }, /* 点击信息按钮后的回调函数，返回true时表示关闭窗口，参数有三个，v表示所点的按钮的返回值，h表示窗口内容的jQuery对象，f表示窗口内容里的form表单键值 */
            closed: function () { } /* 信息关闭后执行的函数 */
        };
        _jBoxConfig.languageDefaults = {
            close: '关闭', /* 窗口右上角关闭按钮提示 */
            ok: '确定', /* $.jBox.prompt() 系列方法的“确定”按钮文字 */
            yes: '是', /* $.jBox.warning() 方法的“是”按钮文字 */
            no: '否', /* $.jBox.warning() 方法的“否”按钮文字 */
            cancel: '取消' /* $.jBox.confirm() 和 $.jBox.warning() 方法的“取消”按钮文字 */
        };

        $.jBox.setDefaults(_jBoxConfig);

        var t1 = new PopupLayer({
            trigger: "#ele",
            popupBlk: "#blk",
            closeBtn: "#close",
            useOverlay: true,
            useFx: true,
            offsets: {
                x: 0,
                y: -41
            }
        });
        t1.doEffects = function (way) {
            if (way == "open") {
                this.popupLayer.css({ opacity: 0.3 }).show(300, function () {
                    this.popupLayer.animate({
                        left: ($(document).width() - this.popupLayer.width()) / 2,
                        top: (document.documentElement.clientHeight - this.popupLayer.height()) / 2 + $(document).scrollTop(),
                        opacity: 0.8
                    }, 300, function () { this.popupLayer.css("opacity", 1) }.binding(this));
                }.binding(this));
            } else {
                this.popupLayer.animate({
                    left: this.trigger.offset().left,
                    top: this.trigger.offset().top,
                    opacity: 0.1
                }, {
                    duration: 200,
                    complete: function () {
                        this.popupLayer.css("opacity", 1);
                        this.popupLayer.hide()
                    }.binding(this)
                });
            }
        };
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <!--header start-->
            <div class="header">
                <div class="welcome"><a class="close" href="#">注销</a><a class="off" href="/bussiness/index.aspx?action=exit">退出</a></div>
                <div class="nav">
                    <ul class="left">
                        <li class="cur"><a href="index.html">首 页</a></li>
                        <li><a href="/newpage/sbjb/rwcl.aspx">任务处理</a></li>
                        <li ><a href="/newpage/sbjb/rwcx.aspx">任务查询</a></li>
                        <li><a href="xinfangyujing.html">知识库</a></li>
                        <li><a href="xinfangtongji.html">帮助</a></li>
                    </ul>
                </div>
            </div>
            <!--header end-->
            <div class="tip">当前位置：<a href="#">首页</a> ></div>
            <!--content start-->
            <div class="col_lh220">
                <div class=" title_col_l">
                    最新待办任务
                </div>
                <div class="text_con">
                    <ul>
                    <%foreach( var v in projectlist){ %>
                        <li><span>[<%=v.Adddate %>]</span><a href="/newpage/sbjb/banli.aspx?projcode=<%=v.Projcode %>" target="_blank"><%=String.Format(GetAppSeeting("ProjectNameTemplate"), v.Projcode)%></a></li>
                       <%} %>
                        
                    </ul>
                </div>
            </div>
            <div class="col_rh220">
                <div class=" title_col_r">
                    物价动态
                </div>
                <div class="text_con" style="padding: 0px">


                   <%--     <div name="pic" style="float: left; position: relative; overflow: hidden;">
                        <div>
                            <img width="100%" height="192" src="Chrysanthemum.jpg" alt="1" /></div>
                        <div>
                            <img width="100%" height="192" src="Desert.jpg" alt="2" /></div>
                        <div>
                            <img width="100%" height="192" src="Hydrangeas.jpg" alt="3" /></div>
                    </div>
                </div>--%>
                   <div id="ibanner">
                        <div id="pic">
                            <a class="img" href="#">
                                <img src="../images/vvszho8bgm9m.jpg" alt="杭州市物价局通报党组专题民主生活会情况" width="100%" height="192"  title="杨市长再次来我局指导调研群众路线教育实"/>
                                <span>杭州市物价局通报党组专题民主生活会情况</span></a>
                            <a class="img" href="#">
                                <img src="../images/kkdohne0mzgb.jpg" alt="杨市长再次来我局指导调研群众路线教育实" width="100%" height="192" />
                                <span>杨市长再次来我局指导调研群众路线教育实</span></a>
                            <a class="img" href="#">
                                <img src="../images/w3z9hne04073.jpg" alt="中国经贸导刊全国宣传工作会议在我市召开" width="100%"  height="192" />
                                <span>中国经贸导刊全国宣传工作会议在我市召开</span></a>
                            <a class="img" href="#">
                                <img src="../images/15dahmwucr9z.jpg" alt="市物价局召开全市“行政执法提升年”活动" width="100%"  height="192" />
                                <span>市物价局召开全市“行政执法提升年”活动</span></a>
                        </div>
                    </div>

                <div class="clear">
               
                </div>
            </div>
                </div>
            <div class="col_l h_420" style="padding: 0px">
                <div class=" title_col_l">
                    统计分析
                </div>
                <div class="text_con" style="overflow: hidden; padding: 0px; width: 100%">
                    <iframe src="QueryStatistics/QyChart1.aspx" frameborder="0" width="" style="width: 100%; height: 375px"
                        scrolling="no"></iframe>
                </div>
            </div>
            <div class="other">
                <div class="col_r h_202">
                    <div class=" title_col_r">
                        通知公告
                    </div>
                    <div class="text_con">
                        <ul>
                            <li><span>[08-15]</span><a href="#">2004-2013年政府定价药品最高零售价格临时公示</a></li>
                            <li><span>[08-15]</span><a href="#">浙江省物价局关于公布西咪替丁等集中采购药品零售价格的通知</a></li>
                            <li><span>[08-15]</span><a href="#">浙江省物价局 浙江省财政厅关于调整因公电子护照收费标准的复函</a></li>
                            <li><span>[08-15]</span><a href="#">浙江省物价局
                        浙江省财政厅关于核定大学生村官选聘考试收费标准的复函</a></li>
                            <li><span>[08-15]</span><a href="#">浙江省物价局关于调整呼吸解热镇痛和专科特殊用药等最高零售限价的通知</a></li>
                            <li><span>[08-15]</span><a href="#">浙江省物价局关于公布盐酸氨溴索注射液等集中采购药品零售价格的通知</a></li>
                        </ul>
                    </div>
                </div>
                <div class="col_r h_206">
                    <div class=" title_col_r">
                        法律法规
                    </div>
                    <div class="text_con">
                        <ul>
                            <li><span>[08-15]</span><a href="#">城镇燃气管理条例</a></li>
                            <li><span>[08-15]</span><a href="#">浙江省政府非税收入管理条例</a></li>
                            <li><span>[08-15]</span><a href="#">浙江省经济适用住房管理办法</a></li>
                            <li><span>[08-15]</span><a href="#">反价格垄断行政执法程序规定</a></li>
                            <li><span>[08-15]</span><a href="#">反价格垄断规定</a></li>
                            <li><span>[08-15]</span><a href="#">中华人民共和国电力法</a></li>
                        </ul>
                    </div>
                </div>
            </div>
            <div class="clear">
            </div>
    </form>


    <script type="text/javascript">
        var t;
        var speed = 3;//图片切换速度 
        var nowlan = 0;//图片开始时间 
        function changepic() {
            var imglen = $("div[id='pic']").find("a").length;
            $("div[id='pic']").find("a").fadeOut();
            $("div[id='pic']").find("a").eq(nowlan).fadeIn();
            nowlan = nowlan + 1 == imglen ? 0 : nowlan + 1;
            t = setTimeout("changepic()", speed * 1000);
        }
        onload = function () { changepic(); }
        $(document).ready(function () {
            //鼠标在图片上悬停让切换暂停 
            $("div[id='pic']").hover(function () { clearInterval(t); });
            //鼠标离开图片切换继续 
            $("div[id='pic']").mouseleave(function () { changepic(); });
        });

    </script>
</body>
</html>



