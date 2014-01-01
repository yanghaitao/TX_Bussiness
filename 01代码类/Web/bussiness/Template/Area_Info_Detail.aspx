﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Area_Info_Detail.aspx.cs" Inherits="TX_Bussiness.Web.bussiness.Template.Area_Info_Detail" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title></title>
    <link rel="stylesheet" type="text/css" href="../Styles/bootstrap.min.css" />
    <link rel="stylesheet" type="text/css" href="../Styles/admin-all.css" />
    <script type="text/javascript" src="../Scripts/jquery-1.7.2.js"></script>
    <script type="text/javascript" src="../Scripts/jquery-ui-1.8.22.custom.min.js"></script>
    <link rel="stylesheet" type="text/css" href="../Styles/ui-lightness/jquery-ui-1.8.22.custom.css" />
    <script type="text/javascript" src="../Scripts/tip.js"></script>
    <script type="text/javascript">
        $(function () {
            $(".datepicker").datepicker();

            $('#list').hide();
            $('#find').click(function () {
                $('#list').show();
            })
            $('#formid').tooltip({ title: '单据号' });
            $('#formtype').tooltip({ title: '单据类型' });
            $('#bumen').tooltip({ title: '部门' });
            $('#startime').tooltip({ title: '起始日期' });
            $('#endtime').tooltip({ title: '结束日期' });
            $('#baoxiaoren').tooltip({ title: '报销人' });
            $('#xiangmu').tooltip({ title: '所属项目' });
        })

    </script>
</head>
<body>
    <div></div>
    <div class="alert alert-info tit">当前位置<b class="tip"></b>查询界面<b class="tip"></b>查询结果一</div>
    <table class="table table-striped table-bordered table-condensed c_table">
        <thead>
            <tr>
                <td colspan="6" class="auto-style2">&nbsp;请填写查询条件 </td>
            </tr>
        </thead>
        <tbody>
            <tr>
                <td>单据号</td>
                <td class="detail">
                    <input id="formid" />
                </td>
                <td>单据类型</td>
                <td class="td_detail">
                    <input id="formtype" /></td>
                <td>部门 </td>
                <td>
                    <select size="1" name="ENTPdept" id="bumen">
                        <option value="10401"></option>
                        <option value="10388">第二营销事业部</option>
                        <option
                            value="10389">第三营销事业部</option>
                        <option
                            value="10390">第一营销事业部</option>
                        <option
                            value="10391">康讯公司</option>
                        <option
                            value="10392">网络事业部</option>
                        <option
                            value="10393">移动事业部</option>
                        <option
                            value="10394">手机事业部</option>
                        <option
                            value="10395">中兴通讯（香港）有限公司</option>
                        <option
                            value="10396">人事中心</option>
                        <option
                            value="10399">财务中心</option>
                        <option
                            value="10400">市场中心</option>
                        <option
                            value="10401">质企中心</option>
                        <option
                            value="10402">技术中心</option>
                        <option
                            value="10386">CDMA事业部</option>
                        <option
                            value="10387">本部事业部</option>
                        <option
                            value="10006">技术中心IC所</option>
                        <option
                            value="11005">中兴通讯学院</option>
                        <option
                            value="11015">第四营销事业部</option>
                        <option
                            value="11153">第五营销事业部</option>
                        <option
                            value="11158">数据事业部</option>
                        <option
                            value="11159">IT中心</option>
                        <option
                            value="11160">ZTE全球售后服务中心</option>
                    </select>
                </td>
            </tr>
            <tr>
                <td>提交日期起 </td>
                <td>
                    <div class="input-append">
                        <input class="span2 datepicker" size="16" type="text" id="startime" /><span class="add-on"><i class="icon-calendar"></i></span>至<input id="endtime" class="span2 datepicker" size="16" type="text" /><span class="add-on"><i class="icon-calendar"></i></span>
                    </div>
                </td>
                <td>报销人 </td>
                <td>
                    <select size="1" name="select2" id="baoxiaoren">
                        <option value="10401"></option>
                        <option value="10388">第二营销事业部</option>
                        <option
                            value="10389">第三营销事业部</option>
                        <option
                            value="10390">第一营销事业部</option>
                        <option
                            value="10391">康讯公司</option>
                        <option
                            value="10392">网络事业部</option>
                        <option
                            value="10393">移动事业部</option>
                        <option
                            value="10394">手机事业部</option>
                        <option
                            value="10395">中兴通讯（香港）有限公司</option>
                        <option
                            value="10396">人事中心</option>
                        <option
                            value="10399">财务中心</option>
                        <option
                            value="10400">市场中心</option>
                        <option
                            value="10401">质企中心</option>
                        <option
                            value="10402">技术中心</option>
                        <option
                            value="10386">CDMA事业部</option>
                        <option
                            value="10387">本部事业部</option>
                        <option
                            value="10006">技术中心IC所</option>
                        <option
                            value="11005">中兴通讯学院</option>
                        <option
                            value="11015">第四营销事业部</option>
                        <option
                            value="11153">第五营销事业部</option>
                        <option
                            value="11158">数据事业部</option>
                        <option
                            value="11159">IT中心</option>
                        <option
                            value="11160">ZTE全球售后服务中心</option>
                    </select></td>
                <td>所属项目</td>
                <td>
                    <select id="xiangmu" size="1" name="select3">
                        <option value="10401"></option>
                        <option value="10388">第二营销事业部</option>
                        <option
                            value="10389">第三营销事业部</option>
                        <option
                            value="10390">第一营销事业部</option>
                        <option
                            value="10391">康讯公司</option>
                        <option
                            value="10392">网络事业部</option>
                        <option
                            value="10393">移动事业部</option>
                        <option
                            value="10394">手机事业部</option>
                        <option
                            value="10395">中兴通讯（香港）有限公司</option>
                        <option
                            value="10396">人事中心</option>
                        <option
                            value="10399">财务中心</option>
                        <option
                            value="10400">市场中心</option>
                        <option
                            value="10401">质企中心</option>
                        <option
                            value="10402">技术中心</option>
                        <option
                            value="10386">CDMA事业部</option>
                        <option
                            value="10387">本部事业部</option>
                        <option
                            value="10006">技术中心IC所</option>
                        <option
                            value="11005">中兴通讯学院</option>
                        <option
                            value="11015">第四营销事业部</option>
                        <option
                            value="11153">第五营销事业部</option>
                        <option
                            value="11158">数据事业部</option>
                        <option
                            value="11159">IT中心</option>
                        <option
                            value="11160">ZTE全球售后服务中心</option>
                    </select></td>
            </tr>

            <tr>
                <td colspan="6" align="right">
                    <input class="btn btn-inverse" id="find" type="button" value="查询" />
                    <input class="btn btn-inverse" type="button" value="清空" /></td>
            </tr>
        </tbody>
    </table>


    <table class="table table-striped table-bordered table-condensed" id="list">
        <thead>
            <tr class="tr_detail">
                <td>单据号 </td>
                <td>报销人部门</td>
                <td>报销人</td>
                <td>申请金额</td>
                <td>审核金额 </td>
                <td>所属项目 </td>
                <td>申请人 </td>
                <td>提交日期 </td>
                <td>单据类型 </td>
                <td>审批状态 </td>
                <td>摘要 </td>
            </tr>
        </thead>
        <tbody>
            <tr>
                <td><a>HS301-2005000020 </a></td>
                <td>现金</td>
                <td>票据 </td>
                <td>负责人 </td>
                <td>3009.40</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>产品国内差旅费单据 </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr class="even">
                <td><a>HS301-2005000020 </a></td>
                <td>现金</td>
                <td>票据 </td>
                <td>负责人 </td>
                <td>0.00</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>产品国内差旅费单据 </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td><a>HS301-2005000020 </a></td>
                <td>CDMA-国内市场部 </td>
                <td>现金 </td>
                <td>负责人 </td>
                <td>0.00</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr class="even">
                <td><a>HS301-2005000020 </a></td>
                <td>银行承兑汇票</td>
                <td>谭晓松 </td>
                <td>负责人 </td>
                <td>0.00</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td><a>HS301-2005000020 </a></td>
                <td>银行存款</td>
                <td>谭晓松 </td>
                <td>任务成员 </td>
                <td>0.00</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr class="even">
                <td><a>HS301-2005000020 </a></td>
                <td>1209NewPro</td>
                <td>谭晓松 </td>
                <td>任务成员 </td>
                <td>0.00</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td><a>HS301-2005000020 </a></td>
                <td>testqzw</td>
                <td>谭晓松 </td>
                <td>负责人 </td>
                <td>0.00</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr class="even">
                <td><a>HS301-2005000020 </a></td>
                <td>银行存款</td>
                <td>执行中 </td>
                <td>负责人 </td>
                <td>0.00</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td><a>HS301-2005000020 </a></td>
                <td>testqzw</td>
                <td>指派中 </td>
                <td></td>
                <td>0.00</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr class="even">
                <td><a>HS301-2005000020 </a></td>
                <td>银行承兑汇票</td>
                <td>谭晓松 </td>
                <td>负责人 </td>
                <td>0.00</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td><a>HS301-2005000020 </a></td>
                <td>银行承兑汇票</td>
                <td>谭晓松 </td>
                <td>负责人 </td>
                <td>0.00</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>产品国内差旅费单据 </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr class="even">
                <td><a>HS301-2005000020 </a></td>
                <td>银行承兑汇票</td>
                <td>上级取消 </td>
                <td>负责人 </td>
                <td>0.00</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td><a>HS301-2005000020 </a></td>
                <td>银行承兑汇票</td>
                <td>谭晓松 </td>
                <td>负责人 </td>
                <td>0.00</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr class="even">
                <td><a>HS301-2005000020 </a></td>
                <td>银行承兑汇票</td>
                <td>执行中 </td>
                <td>负责人 </td>
                <td>0.00</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td><a>HS301-2005000020 </a></td>
                <td>测试产品项目p</td>
                <td>上级取消 </td>
                <td>负责人 </td>
                <td>0.00</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr class="tr_pagenumber">
                <td colspan="100"><div>当前第5页/共55页&nbsp;&nbsp;共650条记录&nbsp;&nbsp;<a class="badge badge-inverse">首页</a>&nbsp;<a class="badge badge-inverse">下一页</a>&nbsp;
                    <a class="badge badge-inverse">1</a>&nbsp;<a class="badge badge-inverse">2</a>&nbsp;<a class="badge badge-inverse">3</a>&nbsp;<a class="badge badge-inverse">4</a>&nbsp;
                    <a class="badge badge-warning">5</a>&nbsp;<a class="badge badge-inverse">...</a>&nbsp;<a class="badge badge-inverse">55</a>&nbsp;<a class="badge badge-inverse">上一页</a>&nbsp;<a class="badge badge-inverse">尾页</a></div></td>
            </tr>
        </tbody>
    </table>
</body>
</html>
