using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ContentManagement.Content
{
    public class GenericContent
        : IContent
    {
        public GenericContent() { }
        public GenericContent(Models.Content content)
        {
            this.Id = content.Id;
            this.Name = content.Name;
            this.CreateDateTime = content.CreateDateTime;
            this.ContentTypeId = content.ContentTypeId;
            this.ContentSubTypeId = content.ContentSubTypeId;
        }
        public GenericContent(Models.Content content, Models.ContentPublication publication)
            : this(content)
        {
            if (publication != null)
            {
                this.ContentSourceTypeId = publication.ContentSourceId;
                this.PublishedDateTime = publication.PublicationDateTime;
                this.Published = publication.Published;
                this.Deleted = publication.Deleted;
            }
        }
        public GenericContent(Models.Content content, Models.ContentPublication publication, IEnumerable<Models.ContentMedata> metadata)
            : this(content, publication)
        {
            if (metadata != null)
                this.Metadata = metadata.ToDictionary(t => t.Key, t => t.Value);
            else
                this.Metadata = new Dictionary<string, string>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime CreateDateTime { get; set; }

        public int ContentTypeId { get; set; }

        public int ContentSubTypeId { get; set; }

        public int ContentSourceTypeId { get; set; }

        public DateTime? PublishedDateTime { get; set; }

        public bool Published { get; set; }

        public bool Deleted { get; set; }

        public Dictionary<string, string> Metadata { get; set; }
    }
}
