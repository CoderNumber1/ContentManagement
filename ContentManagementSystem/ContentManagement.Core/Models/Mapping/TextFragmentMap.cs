using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ContentManagement.Models.Mapping
{
    public class TextFragmentMap : EntityTypeConfiguration<TextFragment>
    {
        public TextFragmentMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Context)
                .IsRequired()
                .HasMaxLength(1000);

            // Table & Column Mappings
            this.ToTable("TextFragment");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.ContentPublicationId).HasColumnName("ContentPublicationId");
            this.Property(t => t.Context).HasColumnName("Context");

            // Relationships
            this.HasRequired(t => t.ContentPublication)
                .WithMany(t => t.TextFragments)
                .HasForeignKey(d => d.ContentPublicationId);

        }
    }
}
