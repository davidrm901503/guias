using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace EventsManager.Web.Helpers
{
    public static class ClassExtensions
    {
        public static MvcHtmlString RenderClass(this HtmlHelper htmlHelper, string authType)
        {
            switch (authType)
            {
                case "google-plus":
                    return MvcHtmlString.Create("btn-danger");
                case "twitter":
                    return MvcHtmlString.Create("btn-info");
                default:
                    return MvcHtmlString.Create("btn-primary");
            }
        }
    }
}
