using ContentManagement.Models;
using System;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace ContentManagement.Repositories
{
    public class ContentManagementRepository
        : IContentManagementRepository
    {
        private ContentManagementContext context;

        public ContentManagementRepository()
        {
            this.context = new ContentManagementContext();
        }

        #region IDisposable

        private bool disposed = false;

        private void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    this.context.Dispose();
                }

                this.disposed = true;
            }
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~ContentManagementRepository()
        {
            this.Dispose(true);
        }

        #endregion IDisposable

        public IQueryable<Models.ContentCollection> GetContentCollections()
        {
            return this.context.ContentCollections.AsNoTracking();
        }

        public IQueryable<Models.ContentMedata> GetContentMetadatas()
        {
            return this.context.ContentMedatas.AsNoTracking();
        }

        public IQueryable<Models.ContentPublication> GetContentPublications()
        {
            return this.context.ContentPublications.AsNoTracking();
        }

        public IQueryable<Models.Content> GetContents()
        {
            return this.context.Contents.AsNoTracking();
        }

        public IQueryable<Models.ContentSecurity> GetContentSecurities()
        {
            return this.context.ContentSecurities.AsNoTracking();
        }

        public IQueryable<Models.ContentSource> GetContentSources()
        {
            return this.context.ContentSources.AsNoTracking();
        }

        public IQueryable<Models.ContentType> GetContentTypes()
        {
            return this.context.ContentTypes.AsNoTracking();
        }

        public IQueryable<Models.SecurityType> GetSecurityTypes()
        {
            return this.context.SecurityTypes.AsNoTracking();
        }

        public IQueryable<Models.TextFragment> GetTextFragments()
        {
            return this.context.TextFragments.AsNoTracking();
        }

        public Models.Content CreateContent()
        {
            var result = new Models.Content();
            this.context.Entry(result).State = System.Data.Entity.EntityState.Added;
            return result;
        }

        public Models.ContentCollection CreateContentCollection()
        {
            var result = new ContentCollection();
            this.context.Entry(result).State = System.Data.Entity.EntityState.Added;
            return result;
        }

        public Models.ContentMedata CreateContentMetadata()
        {
            var result = new ContentMedata();
            this.context.Entry(result).State = System.Data.Entity.EntityState.Added;
            return result;
        }

        public Models.ContentPublication CreateContentPublication()
        {
            var result = new ContentPublication();
            this.context.Entry(result).State = System.Data.Entity.EntityState.Added;
            return result;
        }

        public Models.ContentSecurity CreateContentSecurity()
        {
            var result = new ContentSecurity();
            this.context.Entry(result).State = System.Data.Entity.EntityState.Added;
            return result;
        }

        public Models.ContentSource CreateContentSource()
        {
            var result = new ContentSource();
            this.context.Entry(result).State = System.Data.Entity.EntityState.Added;
            return result;
        }

        public Models.ContentType CreateContentType()
        {
            var result = new ContentType();
            this.context.Entry(result).State = System.Data.Entity.EntityState.Added;
            return result;
        }

        public Models.SecurityType CreateSecurityType()
        {
            var result = new SecurityType();
            this.context.Entry(result).State = System.Data.Entity.EntityState.Added;
            return result;
        }

        public Models.TextFragment CreateTextFragment()
        {
            var result = new TextFragment();
            this.context.Entry(result).State = System.Data.Entity.EntityState.Added;
            return result;
        }

        public void Attach(object entity)
        {
            bool attached = false;
            ObjectStateManager stateManager = (this.context as IObjectContextAdapter).ObjectContext.ObjectStateManager;
            ObjectStateEntry stateEntry = null;

            if (stateManager.TryGetObjectStateEntry(entity, out stateEntry))
            {
                attached = stateEntry.State != System.Data.Entity.EntityState.Detached;
            }

            if (!attached)
                this.context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
        }

        public void Delete(object entity)
        {
            this.context.Entry(entity).State = System.Data.Entity.EntityState.Deleted;
        }

        public void Save(object entity)
        {
            this.context.SaveChanges();
        }
    }
}