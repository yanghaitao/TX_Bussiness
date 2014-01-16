<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Person_Detail.aspx.cs" Inherits="TX_Bussiness.Web.bussiness.Template.Person_Detail" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title></title>
    <link rel="stylesheet" type="text/css" href="../Styles/bootstrap.min.css" />
    <link rel="stylesheet" type="text/css" href="../Styles/admin-all.css" />
    <script type="text/javascript" src="../Scripts/jquery-1.7.2.js"></script>
    <script type="text/javascript" src="../Scripts/jquery-ui-1.8.22.custom.min.js"></script>
    <link rel="stylesheet" type="text/css" href="../Styles/ui-lightness/jquery-ui-1.8.22.custom.css" />
    <script type="text/javascript">
        $(function () {
            $("#tabs").tabs();
            $('.alert-danger').find('b').click(function () {
                $('.task').toggle();
            })
        })
    </script>
</head>
<body>
    <div class="alert alert-info tit">当前位置<b class="tip"></b>当日工作统计</div>
    <div id="tabs" class="hide">
        <ul>
            <li><a href="#tabs-1">关于艺谷</a></li>
            <li><a href="#tabs-2">艺谷愿景</a></li>
            <li><a href="#tabs-3">艺谷团队</a></li>
        </ul>
        <div id="tabs-1">
            <p>深圳艺谷成立于自选礼品方案服务业蓬勃发展的时期，由一群年轻的成员组成。这是一个各方势力云集，意欲在礼品方案市场中竞争角力、一争高下的时代。深圳艺谷的年轻团队，在艺谷集团众多艺术家设计师的教导与影响下，既保持了传统文化与学术的元素特征，也代表了新时期文化势力的热情。其作品沉稳大气，传统国学元素与现代文艺设计交相辉映，在为用户提供贴心定制服务的同时，更在鱼龙混杂的礼品册市场中，散发出特有的艺术芬芳，占据了领军之位，成为各大企事业单位提升企业文化内涵，塑造品牌形象的专属代言。</p>
        </div>
        <div id="tabs-2">
            <p>施者之福胜于受者。馈赠之道不仅仅是一种人与人的交往方式，更是情感交流与反馈的渠道。艺谷礼品册并非普通的商品，更包含了寄情于礼的情感升华。为此，深圳艺谷将致力于保持中国最具文化力量的创意礼品方案服务商定位，在喧嚣的社会洪流中，为您的客户关系维护、亲友情谊传递，以及员工团队慰问，提供一条清幽的捷径。</p>
        </div>
        <div id="tabs-3">
            <p>深圳艺谷是一群有理想的年轻人的乐土，天马行空的创意策划是我们的特长,贴心的服务理念,是我们最强大的武器。</p>
            <p>我们会面红耳赤地讨论，只为向您提供最棒的作品；我们有时也会犯错，但绝不会再犯同样的错。我们倾听您的每一条建议，优化每一个细节，只希望服务更体贴，最大程度给您带来便捷。年轻的头脑催生了无数光怪陆离但又令人惊羡的idea；文艺的熏陶造就了一丝与年龄不甚相符的沉稳气质，处处透着文艺范儿；对已有服务的不断优化与反思，更是我们责任心的体现。</p>
        </div>
    </div>

     <div class="alert alert-danger">
        <b><a href="javascript:void(0)">我的工作统计<i class="tip-up-red"></i></a></b>
        <div class="task">
            <p></p>
            <p><i class="tip-left"></i>区域统计：</p>
            <p>工作量：100</p>
            <p><i class="tip-left"></i>部门统计： </p>
            <p>工作量:100</p>
            <p><i class="tip-left"></i>类别统计： </p>
            <p>工作量：100</p>
        </div>
    </div>
   <table class="table table-striped table-bordered table-condensed hide" id="projlist">
        <thead>
            <tr class="tr_detail">
                <td>
                    勤务编号
                </td>
                <td>
                    上报人
                </td>
                <td>
                    区域
                </td>
                <td>
                    街道
                </td>
                <td>
                    社区
                </td>
                <td>
                    大类
                </td>
                <td>
                    小类
                </td>
                <td>
                    地址
                </td>
                <td>
                    案卷描述
                </td>
                <td>
                    上报时间
                </td>
                <td>
                    操作
                </td>
            </tr>
        </thead>
        <tbody>
            <%if (project_list != null && project_list.Count > 0)
              {
                  int i = 0;
                  foreach (var v in project_list)
                  {%>
            <tr <%=i%2==0?"":"class='even'" %> _projcode="<%=v.Projcode %>">
                <td>
                    <a href="javascript:;showdetail('<%=v.Projcode %>')">
                        <%=String.Format(GetAppSeeting("ProjectNameTemplate"),v.Projcode) %>
                    </a>
                </td>
                <td>
                    <%=v.Reportpersonname %>
                </td>
                <td>
                    <%= GetAreaName(v.Areacode) %>
                </td>
                <td>
                    <%= GetStreetName( v.Streetcode) %>
                </td>
                <td>
                    <%=GetCommName( v.Communitycode) %>
                </td>
                <td>
                    <%=v.Bigclassname %>
                </td>
                <td>
                    <%=v.Smallclassname %>
                </td>
                <td>
                    <%=v.Address %>
                </td>
                <td>
                    <%=v.Describe %>
                </td>
                <td>
                    <%=v.Adddate %>
                </td>
                <td>
                     <a href="javascript:;" class="preview btn btn-mini btn-primary add">
                   查看流程
                    </a>
                </td>
            </tr>
            <%}
              } %>
            <tr class="tr_pagenumber">
                <td colspan="100">
                    <div id="PageContent" runat="server">
                    </div>
                </td>
            </tr>
        </tbody>
    </table>
</body>
</html>
