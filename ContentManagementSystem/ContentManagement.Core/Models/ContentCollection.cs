using System;
using System.Collections.Generic;

namespace ContentManagement.Models
{
    public partial class ContentCollection
    {
        public int Id { get; set; }
        public int ContentId { get; set; }
        public int ContentOwnerId { get; set; }
        public virtual Content Content { get; set; }
        public virtual Content Content1 { get; set; }
    }
}
