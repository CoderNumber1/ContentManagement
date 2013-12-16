using System;
using System.Collections.Generic;

namespace ContentManagement.Models
{
    public partial class ContentMedata
    {
        public int Id { get; set; }
        public int ContentPublicationId { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
        public virtual ContentPublication ContentPublication { get; set; }
    }
}
