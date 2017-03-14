using aspnet_mvc5_sample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace aspnet_mvc5_sample.Helpers
{
    public static class NavigationMenuHelper
    {
        public static IHtmlString NavigationListFor(this HtmlHelper helper, IEnumerable<NavigationLink> menu)
        {
            var sb = new StringBuilder();
            foreach (var item in menu)
            {
                var li = new TagBuilder("li");
                li.InnerHtml = helper.ActionLink(item.LinkText, item.ActionName, item.ControllerName).ToString();
                sb.Append(li);
            }
            return MvcHtmlString.Create(sb.ToString());
        }
        /// <summary>
        ///  サブメニュー作成
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="submenu"></param>
        /// <returns></returns>
        public static IHtmlString NavigationSubMenuListFor(this HtmlHelper helper, IEnumerable<NavigationLink> submenu)
        {
            var sb = new StringBuilder();
            foreach (var item in submenu)
            {
                if (item.ChildMenu == null)
                {
                    var li = new TagBuilder("li");
                    li.InnerHtml = helper.ActionLink(item.LinkText, item.ActionName, item.ControllerName).ToString();
                    sb.Append(li.ToString(TagRenderMode.Normal));
                }
                else
                {
                    sb.Append(CreateSubMenu(helper, item.CategoryName, item.ChildMenu));
                }
            }

            return MvcHtmlString.Create(sb.ToString());
        }

        /// <summary>
        ///  再帰的にサブメニューを作成する
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="categoryName"></param>
        /// <param name="subMenu"></param>
        /// <returns></returns>
        private static string CreateSubMenu(HtmlHelper helper, string categoryName, IEnumerable<NavigationLink> subMenu)
        {
            var a = new TagBuilder("a");
            var attributes = new Dictionary<string, string>
            {
                ["tableindex"] = "-1",
                ["href"] = "#",
            };
            a.MergeAttributes(attributes);
            a.InnerHtml = categoryName;

            var top_li = new TagBuilder("li");
            top_li.MergeAttribute("class", "dropdown-submenu");
            top_li.InnerHtml = a.ToString();

            var ul = new TagBuilder("ul");
            ul.MergeAttribute("class", "dropdown-menu");

            foreach (var item in subMenu)
            {
                if(item.ChildMenu == null)
                {
                    var li = new TagBuilder("li");
                    li.InnerHtml = helper.ActionLink(item.LinkText, item.ActionName, item.ControllerName).ToString();
                    ul.InnerHtml += li.ToString();
                }
                else
                {
                    ul.InnerHtml += CreateSubMenu(helper, item.CategoryName, item.ChildMenu);
                }
            }

            top_li.InnerHtml += ul.ToString();
            return top_li.ToString();
        }

        [Obsolete]
        public static IHtmlString NavigationMenu(this HtmlHelper helper, IEnumerable<NavigationLink> menu)
        {
            var top_ul = new TagBuilder("ul");
            top_ul.MergeAttribute("class", "nav navbar-nav");

            foreach (var item in menu)
            {
                if (item.ChildMenu == null)
                {
                    var li = new TagBuilder("li");
                    li.InnerHtml = helper.ActionLink(item.LinkText, item.ActionName, item.ControllerName).ToString();
                    top_ul.InnerHtml += li.ToString();
                }
                else
                {
                    top_ul.InnerHtml += CreateChildMenu(helper, item.CategoryName, item.ChildMenu);
                }
            }

            return MvcHtmlString.Create(top_ul.ToString());
        }
        [Obsolete]
        private static string CreateChildMenu(HtmlHelper helper, string categoryName, IEnumerable<NavigationLink> childMenu)
        {
            var a = new TagBuilder("a");
            var attributes = new Dictionary<string, string>
            {
                ["class"] = "dropdown-toggle",
                ["data-toggle"] = "dropdown",
                ["href"] = "#",
                ["role"] = "button",
                ["aria-expanded"] = "false"
            };
            a.MergeAttributes(attributes);
            a.InnerHtml = categoryName;

            var span = new TagBuilder("span");
            span.MergeAttribute("class", "caret");
            a.InnerHtml += span.ToString();

            var top_li = new TagBuilder("li");
            top_li.MergeAttribute("class", "dropdown");
            top_li.InnerHtml = a.ToString();

            var top_ul = new TagBuilder("ul");
            top_ul.MergeAttribute("class", "dropdown-menu");
            top_ul.MergeAttribute("role", "menu");

            foreach (var item in childMenu)
            {
                var li = new TagBuilder("li");
                li.InnerHtml = helper.ActionLink(item.LinkText, item.ActionName, item.ControllerName).ToString();
                top_ul.InnerHtml += li.ToString();
            }

            top_li.InnerHtml += top_ul.ToString();
            return top_li.ToString();
        }
    }
}