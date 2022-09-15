using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ResortManagerSoftware.Models
{
    public static class ImageHelper
    {
        public static MvcHtmlString Image(this HtmlHelper helper , string src , 
            string alText, string height)
        {
            var builer = new TagBuilder("img");
            builer.MergeAttribute("src", src);
            builer.MergeAttribute("alt", alText);
            builer.MergeAttribute("height", height);
            return MvcHtmlString.Create(builer.ToString(TagRenderMode.SelfClosing));
        }
    }
}