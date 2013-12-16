using System;
using System.Collections.Generic;

namespace ContentManagement.Models
{
    public partial class ContentSource
    {
        public ContentSource()
        {
            this.ContentPublications = new List<ContentPublication>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<ContentPublication> ContentPublications { get; set; }
    }
}
