using System;
using System.Collections.Generic;

namespace ContentManagement.Models
{
    public partial class ContentSecurity
    {
        public int Id { get; set; }
        public int ContentId { get; set; }
        public int ContentControllerId { get; set; }
        public int SecurityTypeId { get; set; }
        public virtual Content Content { get; set; }
        public virtual Content Content1 { get; set; }
        public virtual SecurityType SecurityType { get; set; }
    }
}
