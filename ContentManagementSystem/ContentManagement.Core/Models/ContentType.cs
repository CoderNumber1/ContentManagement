using System;
using System.Collections.Generic;

namespace ContentManagement.Models
{
    public partial class ContentType
    {
        public ContentType()
        {
            this.Contents = new List<Content>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Content> Contents { get; set; }
    }
}
