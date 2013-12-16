using System;
using System.Collections.Generic;

namespace ContentManagement.Models
{
    public partial class Content
    {
        public Content()
        {
            this.ContentCollections = new List<ContentCollection>();
            this.ContentCollections1 = new List<ContentCollection>();
            this.ContentPublications = new List<ContentPublication>();
            this.ContentSecurities = new List<ContentSecurity>();
            this.ContentSecurities1 = new List<ContentSecurity>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public System.DateTime CreateDateTime { get; set; }
        public int ContentTypeId { get; set; }
        public int ContentSubTypeId { get; set; }
        public virtual ContentType ContentType { get; set; }
        public virtual ICollection<ContentCollection> ContentCollections { get; set; }
        public virtual ICollection<ContentCollection> ContentCollections1 { get; set; }
        public virtual ICollection<ContentPublication> ContentPublications { get; set; }
        public virtual ICollection<ContentSecurity> ContentSecurities { get; set; }
        public virtual ICollection<ContentSecurity> ContentSecurities1 { get; set; }
    }
}
