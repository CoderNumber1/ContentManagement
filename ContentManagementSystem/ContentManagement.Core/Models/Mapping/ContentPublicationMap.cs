using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ContentManagement.Models.Mapping
{
    public class ContentPublicationMap : EntityTypeConfiguration<ContentPublication>
    {
        public ContentPublicationMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("ContentPublication");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.ContentId).HasColumnName("ContentId");
            this.Property(t => t.ContentSourceId).HasColumnName("ContentSourceId");
            this.Property(t => t.PublicationDateTime).HasColumnName("PublicationDateTime");
            this.Property(t => t.CreateDateTime).HasColumnName("CreateDateTime");
            this.Property(t => t.Published).HasColumnName("Published");
            this.Property(t => t.Deleted).HasColumnName("Deleted");

            // Relationships
            this.HasRequired(t => t.Content)
                .WithMany(t => t.ContentPublications)
                .HasForeignKey(d => d.ContentId);
            this.HasRequired(t => t.ContentSource)
                .WithMany(t => t.ContentPublications)
                .HasForeignKey(d => d.ContentSourceId);

        }
    }
}
