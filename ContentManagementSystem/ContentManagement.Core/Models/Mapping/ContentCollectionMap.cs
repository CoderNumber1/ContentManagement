using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ContentManagement.Models.Mapping
{
    public class ContentCollectionMap : EntityTypeConfiguration<ContentCollection>
    {
        public ContentCollectionMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("ContentCollection");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.ContentId).HasColumnName("ContentId");
            this.Property(t => t.ContentOwnerId).HasColumnName("ContentOwnerId");

            // Relationships
            this.HasRequired(t => t.Content)
                .WithMany(t => t.ContentCollections)
                .HasForeignKey(d => d.ContentId);
            this.HasRequired(t => t.Content1)
                .WithMany(t => t.ContentCollections1)
                .HasForeignKey(d => d.ContentOwnerId);

        }
    }
}
