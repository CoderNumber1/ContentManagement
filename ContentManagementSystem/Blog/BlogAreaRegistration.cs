using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog
{
    public class BlogAreaRegistration
        : MvcContrib.PortableAreas.PortableAreaRegistration
    {
        public override string AreaName
        {
            get { return "Blog"; }
        }

        public override void RegisterArea(System.Web.Mvc.AreaRegistrationContext context)
        {
            context.MapRoute("Blog",
                                "Blog/{controller}/{action}/{id}",
                                new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                                new string[] { "Blog.Controllers" });

            base.RegisterArea(context);

        }
    }
}