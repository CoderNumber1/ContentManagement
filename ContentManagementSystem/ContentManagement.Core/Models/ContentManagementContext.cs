using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using ContentManagement.Models.Mapping;

namespace ContentManagement.Models
{
    public partial class ContentManagementContext : DbContext
    {
        static ContentManagementContext()
        {
            Database.SetInitializer<ContentManagementContext>(null);
        }

        public ContentManagementContext()
            : base("Name=ContentManagementContext")
        {
        }

        public DbSet<Content> Contents { get; set; }
        public DbSet<ContentCollection> ContentCollections { get; set; }
        public DbSet<ContentMedata> ContentMedatas { get; set; }
        public DbSet<ContentPublication> ContentPublications { get; set; }
        public DbSet<ContentSecurity> ContentSecurities { get; set; }
        public DbSet<ContentSource> ContentSources { get; set; }
        public DbSet<ContentType> ContentTypes { get; set; }
        public DbSet<SecurityType> SecurityTypes { get; set; }
        public DbSet<TextFragment> TextFragments { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ContentMap());
            modelBuilder.Configurations.Add(new ContentCollectionMap());
            modelBuilder.Configurations.Add(new ContentMedataMap());
            modelBuilder.Configurations.Add(new ContentPublicationMap());
            modelBuilder.Configurations.Add(new ContentSecurityMap());
            modelBuilder.Configurations.Add(new ContentSourceMap());
            modelBuilder.Configurations.Add(new ContentTypeMap());
            modelBuilder.Configurations.Add(new SecurityTypeMap());
            modelBuilder.Configurations.Add(new TextFragmentMap());
        }
    }
}
