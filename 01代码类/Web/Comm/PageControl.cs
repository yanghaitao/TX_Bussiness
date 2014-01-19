using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;

namespace TX_Bussiness.Web.Comm
{
    public class PageControl
    {
        #region 显示分页
        /// <summary>
        /// 返回分页页码
        /// </summary>
        /// <param name="pageSize">页面大小</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="totalCount">总记录数</param>
        /// <param name="linkUrl">链接地址，__id__代表页码</param>
        /// <param name="centSize">中间页码数量</param>
        /// <returns></returns>
        public static string OutPageList(int pageSize, int pageIndex, int totalCount, string linkUrl, int centSize)
        {
            //计算页数
            if (totalCount < 1 || pageSize < 1)
            {
                return "";
            }
            int pageCount = totalCount / pageSize;
            if (pageCount < 1)
            {
                return "";
            }
            if (totalCount % pageSize > 0)
            {
                pageCount += 1;
            }
            if (pageCount <= 1)
            {
                return "";
            }
            StringBuilder pageStr = new StringBuilder();
            string pageId = "__id__";
            string firstBtn = " 当前第" + pageIndex + "页/共" + pageCount + "页  共"+totalCount+"条记录  <a class=\"badge badge-inverse\" href=\"" + ReplaceStr(linkUrl, pageId, (pageIndex - 1).ToString()) + "\">«上一页</a>";
            string lastBtn = " <a class=\"badge badge-inverse\" href=\"" + ReplaceStr(linkUrl, pageId, (pageIndex + 1).ToString()) + "\">下一页»</a>";
            string firstStr = " <a class=\"badge badge-inverse\" href=\"" + ReplaceStr(linkUrl, pageId, "1") + "\">1</a>";
            string lastStr = " <a class=\"badge badge-inverse\" href=\"" + ReplaceStr(linkUrl, pageId, pageCount.ToString()) + "\">" + pageCount.ToString() + "</a>";

            if (pageIndex <= 1)
            {
                firstBtn = "  当前第" + pageIndex + "页/共" + pageCount + "页  共" + totalCount + "条记录  <a class=\"badge badge-inverse\">«上一页</a>";
            }
            if (pageIndex >= pageCount)
            {
                lastBtn = " <a class=\"badge badge-inverse\">下一页»</a>";
            }
            if (pageIndex == 1)
            {
                firstStr = " <a class=\"badge badge-warning cur\">1</a>";
            }
            if (pageIndex == pageCount)
            {
                lastStr = " <a class=\"badge badge-warning cur\">" + pageCount.ToString() + "</a>";
            }
            int firstNum = pageIndex - (centSize / 2); //中间开始的页码
            if (pageIndex < centSize)
                firstNum = 2;
            int lastNum = pageIndex + centSize - ((centSize / 2) + 1); //中间结束的页码
            if (lastNum >= pageCount)
                lastNum = pageCount - 1;
            pageStr.Append(firstBtn + firstStr);
            if (pageIndex >= centSize)
            {
                pageStr.Append(" <a class=\"badge badge-inverse\">...</a>\n");
            }
            for (int i = firstNum; i <= lastNum; i++)
            {
                if (i == pageIndex)
                {
                    pageStr.Append(" <a class=\"badge badge-warning cur\">" + i + "</a>");
                }
                else
                {
                    pageStr.Append(" <a class=\"badge badge-inverse\" href=\"" + ReplaceStr(linkUrl, pageId, i.ToString()) + "\">" + i + "</a>");
                }
            }
            if (pageCount - pageIndex > centSize - ((centSize / 2)))
            {
                pageStr.Append(" <a class=\"badge badge-inverse\">...</a>");
            }
            pageStr.Append(lastStr + lastBtn);
            return pageStr.ToString();
        }
        #endregion
        #region 替换指定的字符串
        /// <summary>
        /// 替换指定的字符串
        /// </summary>
        /// <param name="originalStr">原字符串</param>
        /// <param name="oldStr">旧字符串</param>
        /// <param name="newStr">新字符串</param>
        /// <returns></returns>
        public static string ReplaceStr(string originalStr, string oldStr, string newStr)
        {
            if (string.IsNullOrEmpty(oldStr))
            {
                return "";
            }
            return originalStr.Replace(oldStr, newStr);
        }
        #endregion
    }
}