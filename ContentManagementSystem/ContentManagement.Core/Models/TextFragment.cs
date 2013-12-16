using System;
using System.Collections.Generic;

namespace ContentManagement.Models
{
    public partial class TextFragment
    {
        public int Id { get; set; }
        public int ContentPublicationId { get; set; }
        public string Context { get; set; }
        public virtual ContentPublication ContentPublication { get; set; }
    }
}
