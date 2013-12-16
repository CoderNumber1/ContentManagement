using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ContentManagement.Models.Mapping
{
    public class ContentMap : EntityTypeConfiguration<Content>
    {
        public ContentMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("Content");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.CreateDateTime).HasColumnName("CreateDateTime");
            this.Property(t => t.ContentTypeId).HasColumnName("ContentTypeId");
            this.Property(t => t.ContentSubTypeId).HasColumnName("ContentSubTypeId");

            // Relationships
            this.HasRequired(t => t.ContentType)
                .WithMany(t => t.Contents)
                .HasForeignKey(d => d.ContentTypeId);

        }
    }
}
