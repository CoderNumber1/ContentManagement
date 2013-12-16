using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ContentManagement.Content
{
    public interface IContent
    {
        int Id { get; set; }
        string Name { get; set; }
        DateTime CreateDateTime { get; set; }
        int ContentTypeId { get; set; }
        int ContentSubTypeId { get; set; }
        int ContentSourceTypeId { get; set; }
        DateTime? PublishedDateTime { get; set; }
        bool Published { get; set; }
        bool Deleted { get; set; }
        Dictionary<string, string> Metadata { get; set; }
    }
}
