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
                    return MvcHtmlString.Create("danger");
                default:
                    return MvcHtmlString.Create("primary");
            }
        }
    }
}
