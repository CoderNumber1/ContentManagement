using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ContentManagementMvc
{
    public class ContentManagementAreaRegistration
        : MvcContrib.PortableAreas.PortableAreaRegistration
    {
        public override string AreaName
        {
            get { return "ContentManagementTools"; }
        }

        public override void RegisterArea(System.Web.Mvc.AreaRegistrationContext context)
        {
            context.MapRoute("ContentManagementResources",
                                "ContentMangementTools/Resources/{collectionName}/{resourceType}/{resourceName}",
                                new { controller = "ResourceController", action = "GetResource" },
                                new string[] { "ContentMangementMvc.Controllers" });

            base.RegisterArea(context);
        }
    }
}
