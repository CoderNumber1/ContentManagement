using ContentManagement.Content;
using ContentManagement.DataServices;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace ContentManagementMvc.Controllers
{
    public class ResourceController
        : Controller
    {
        public ActionResult GetResource(string collectionName, string resourceType/*, string resourceName*/, string resourcePath = null, string contentType = null)
        {
            using (IContentManagementDataService contentService = new ContentManagementDataService())
            {
                string collectionPath = Path.GetDirectoryName(resourcePath);
                string resourceName = Path.GetFileNameWithoutExtension(resourcePath);

                IContent contentItem = contentService.GetContent(resourcePath);
                if (contentItem != null)
                {
                    var permissions = contentService.GetContentSecurity(contentItem.Id, false);
                }
            }

            return null;
        }

        //public abstract string RootNamespace { get; }

        //public virtual ActionResult GetResource(string resourceType, string resourceName)
        //{
        //    var contentType = this.GetContentType(resourceName);
        //    var ResourceAssembly = this.GetResourceAssembly();

        //    var resourceStream = ResourceAssembly.GetManifestResourceStream(string.Format("{0}.{1}.{2}", this.RootNamespace, resourceType, resourceName.Replace("/", ".")));

        //    if (resourceStream != null)
        //        return this.File(resourceStream, contentType, resourceName);
        //    else
        //        return null;
        //}

        //protected virtual Assembly GetResourceAssembly()
        //{
        //    return Assembly.GetAssembly(this.GetType());
        //}

        protected virtual string GetContentType(string resourceName)
        {
            switch (Path.GetExtension(resourceName))
            {
                case ".js":
                    return "text/javascript";
                case ".css":
                    return "text/css";
                case ".png":
                    return "image/png";
                case ".jpg":
                    return "image/jpeg";
                default:
                    return "text/html";
            }
        }
    }
}
