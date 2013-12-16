using System;
using System.Collections.Generic;

namespace ContentManagement.Models
{
    public partial class ContentPublication
    {
        public ContentPublication()
        {
            this.ContentMedatas = new List<ContentMedata>();
            this.TextFragments = new List<TextFragment>();
        }

        public int Id { get; set; }
        public int ContentId { get; set; }
        public int ContentSourceId { get; set; }
        public Nullable<System.DateTime> PublicationDateTime { get; set; }
        public System.DateTime CreateDateTime { get; set; }
        public bool Published { get; set; }
        public bool Deleted { get; set; }
        public virtual Content Content { get; set; }
        public virtual ICollection<ContentMedata> ContentMedatas { get; set; }
        public virtual ContentSource ContentSource { get; set; }
        public virtual ICollection<TextFragment> TextFragments { get; set; }
    }
}
