using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace MVCDemo.Models
{
    public static class WebHtmlHelper
    {

        public static MvcHtmlString UlPaging(this HtmlHelper helper, IPageOfList list)
        {
            StringBuilder sb = new StringBuilder();

            if (list == null)
            {
                return new MvcHtmlString(sb.ToString());
            }

            sb.AppendLine("<div class=\"fenye\">" + string.Format("<span>共 {0} 条 记录，每页 {1} 条 &nbsp;</span>", list.RecordTotal, list.PageSize));

            //sb.AppendLine(" <ul class=\"pagination\">");
            System.Web.Routing.RouteValueDictionary route = new System.Web.Routing.RouteValueDictionary();
            foreach (var key in helper.ViewContext.RouteData.Values.Keys)
            {
                route[key] = helper.ViewContext.RouteData.Values[key];
            }

            foreach (string key in helper.ViewContext.RequestContext.HttpContext.Request.QueryString)
            {
                route[key] = helper.ViewContext.RequestContext.HttpContext.Request.QueryString[key];
            }

            if (list.PageIndex <= 0)
            {
                sb.AppendLine("<a class=\"backpage\" href=\"javascript:void(0);\">上一页</a>");
            }
            else
            {
                route["pageIndex"] = list.PageIndex - 1;
                //sb.AppendLine(" <li class=\"prev " + (list.PageIndex == 0 ? "disabled" : "") + "\">" + helper.ActionLink("← 上一页", route["action"].ToString(), route).ToHtmlString() + "</li>");
                //sb.AppendLine(helper.ActionLink("上一页", route["action"].ToString(), route).ToHtmlString());
            }

            if (list.PageIndex > 3)
            {
                route["pageIndex"] = 0;
                //sb.AppendLine(helper.ActionLink(@"<b>1</b>", route["action"].ToString(), route).ToHtmlString().Replace("&lt;", "<").Replace("&gt;", ">"));
                //sb.AppendLine(" <li>" + helper.ActionLink("1", route["action"].ToString(), route).ToHtmlString() + "</li>");
                if (list.PageIndex >= 5)
                {
                    sb.AppendLine("<a href='#'>..</a>");
                }
            }

            for (int i = list.PageIndex - 2; i <= list.PageIndex; i++)
            {
                if (i < 1)
                    continue;
                route["pageIndex"] = i - 1;
                //sb.AppendLine("<li" + (i == list.PageIndex + 1 ? " class=\"active\"" : "") + ">" + helper.ActionLink(i.ToString(), route["action"].ToString(), route).ToHtmlString() + "</li>");
                //sb.AppendLine(helper.ActionLink(@"<b>" + i.ToString() + @"</b>", route["action"].ToString(), route).ToHtmlString().Replace("&lt;", "<").Replace("&gt;", ">"));
            }

            sb.AppendLine(@"<a class='active' href='#'><b>" + (list.PageIndex + 1) + @"</b></a>");
            for (var i = list.PageIndex + 2; i <= list.PageIndex + 4; i++)
            {
                if (i > list.PageTotal)
                    continue;
                route["pageIndex"] = i - 1;
                //sb.AppendLine(helper.ActionLink(@"<b>" + i.ToString() + @"</b>", route["action"].ToString(), route).ToHtmlString().Replace("&lt;", "<").Replace("&gt;", ">"));
                //sb.AppendLine("<li" + (i == list.PageIndex + 1 ? " class=\"active\"" : "") + ">" + helper.ActionLink(i.ToString(), route["action"].ToString(), route).ToHtmlString() + "</li>");
            }

            if (list.PageIndex < list.PageTotal - 4)
            {
                if (list.PageIndex <= list.PageTotal - 6)
                {
                    sb.AppendLine("<a href='#'>..</a>");
                }
                route["pageIndex"] = list.PageTotal - 1;

                //sb.AppendLine(helper.ActionLink(@"<b>" + list.PageTotal.ToString() + "</b>", route["action"].ToString(), route).ToHtmlString().Replace("&lt;", "<").Replace("&gt;", ">"));
                //sb.AppendLine(" <li>" + helper.ActionLink(list.PageTotal.ToString(), route["action"].ToString(), route).ToHtmlString() + "</li>");
            }
            if (list.PageIndex < list.PageTotal - 1)
            {
                route["pageIndex"] = list.PageIndex + 1;
                //sb.AppendLine(helper.ActionLink("下一页", route["action"].ToString(), route).ToHtmlString());
                //sb.AppendLine("<li class=\"next\">" + helper.ActionLink("下一页 →", route["action"].ToString(), route).ToHtmlString() + "</li>");, new { @class = "nextpage" }
            }
            else
            {
                //sb.AppendLine("<a class=\"nextpage\" href=\"javascript:void(0);\">下一页</a>");
                sb.AppendLine("<li class=\"nextpage disabled\"><a href=\"javascript:void(0);\">下一页 →</a></li>");
            }
            sb.AppendLine("</div>");
            return new MvcHtmlString(sb.ToString());
        }
    }
}