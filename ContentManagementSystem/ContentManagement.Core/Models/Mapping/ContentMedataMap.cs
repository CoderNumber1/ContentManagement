using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ContentManagement.Models.Mapping
{
    public class ContentMedataMap : EntityTypeConfiguration<ContentMedata>
    {
        public ContentMedataMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Key)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Value)
                .HasMaxLength(500);

            // Table & Column Mappings
            this.ToTable("ContentMedata");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.ContentPublicationId).HasColumnName("ContentPublicationId");
            this.Property(t => t.Key).HasColumnName("Key");
            this.Property(t => t.Value).HasColumnName("Value");

            // Relationships
            this.HasRequired(t => t.ContentPublication)
                .WithMany(t => t.ContentMedatas)
                .HasForeignKey(d => d.ContentPublicationId);

        }
    }
}
