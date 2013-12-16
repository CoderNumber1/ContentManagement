using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ContentManagement.Models.Mapping
{
    public class ContentSecurityMap : EntityTypeConfiguration<ContentSecurity>
    {
        public ContentSecurityMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("ContentSecurity");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.ContentId).HasColumnName("ContentId");
            this.Property(t => t.ContentControllerId).HasColumnName("ContentControllerId");
            this.Property(t => t.SecurityTypeId).HasColumnName("SecurityTypeId");

            // Relationships
            this.HasRequired(t => t.Content)
                .WithMany(t => t.ContentSecurities)
                .HasForeignKey(d => d.ContentId);
            this.HasRequired(t => t.Content1)
                .WithMany(t => t.ContentSecurities1)
                .HasForeignKey(d => d.ContentControllerId);
            this.HasRequired(t => t.SecurityType)
                .WithMany(t => t.ContentSecurities)
                .HasForeignKey(d => d.SecurityTypeId);

        }
    }
}
