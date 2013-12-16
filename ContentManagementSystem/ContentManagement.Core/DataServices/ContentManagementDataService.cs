using ContentManagement.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using ContentManagement.Models;
using System.Text;
using ContentManagement.SqlIds;
using ContentManagement.Content;
using System.IO;

namespace ContentManagement.DataServices
{
    public class ContentManagementDataService
        : IContentManagementDataService
    {
        private IContentManagementRepository repository;

        #region IDisposable

        private bool disposed = false;

        ~ContentManagementDataService()
        {
            this.Dispose(false);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
            this.Dispose(true);
        }

        private void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    this.repository.Dispose();
                }

                this.disposed = false;
            }
        }
        #endregion IDisposable

        public void AddContentToCollection(int contentId, int parentId)
        {
            Models.Content child = this.repository.GetContents().FirstOrDefault(c => c.Id == contentId);
            Models.Content parent = this.repository.GetContents().FirstOrDefault(c => c.Id == parentId);

            if (child == null || parent == null)
                throw new InvalidOperationException("Both parent and child must exist in the database.");
        }

        public Models.Content CreateContent()
        {
            throw new NotImplementedException();
        }

        public Models.ContentMedata CreateContentMetadata(int publicationId)
        {
            throw new NotImplementedException();
        }

        public Models.ContentPublication CreatePublication(int contentId)
        {
            throw new NotImplementedException();
        }

        public Models.ContentSecurity CreateSecurity(int contentId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Content.IContent> GetChildContents(int parentContentId)
        {
            throw new NotImplementedException();
        }

        public Content.IContent GetGenericContent(int contentId)
        {
            throw new NotImplementedException();
        }

        public Content.IContent GetContent(string contentPath)
        {
            GenericContent result = null;
            string[] pathParts = contentPath.Split(new[] { Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar }, StringSplitOptions.RemoveEmptyEntries);
            Models.Content root = this.repository.GetContents().FirstOrDefault(con => con.Id == SqlIdProvider.Instance.CoreContent.MainCollection);
            foreach (var part in pathParts)
            {
                root = this.repository.GetContents()
                    .Join(this.repository.GetContentCollections()
                            .Where(col => col.ContentOwnerId == root.Id),
                        con => con.Id,
                        col => col.ContentId,
                        (con, col) => con)
                    .FirstOrDefault(con => con.Name == part);

                if (root == null)
                    break;
            }

            if (root != null)
            {
                Models.ContentPublication publication = this.repository.GetContentPublications().FirstOrDefault(pub => pub.ContentId == root.Id);

                IEnumerable<Models.ContentMedata> metadata = null;
                if (publication != null)
                    metadata = this.repository.GetContentMetadatas().Where(met => met.ContentPublicationId == publication.Id);

                result = new GenericContent(root, publication, metadata);
            }
            return result;
        }

        public Content.IContent GetContentCollection(string collectionName)
        {
            GenericContent result = null;
            string[] pathParts = collectionName.Split(new[] { Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar }, StringSplitOptions.RemoveEmptyEntries);
            Models.Content root = this.repository.GetContents().FirstOrDefault(con => con.Id == SqlIdProvider.Instance.CoreContent.MainCollection);
            foreach (var part in pathParts)
            {
                root = this.repository.GetContents()
                    .Join(this.repository.GetContentCollections()
                            .Where(col => col.ContentOwnerId == root.Id),
                        con => con.Id,
                        col => col.ContentId,
                        (con, col) => con)
                    .FirstOrDefault(con => con.Name == part);

                if (root == null)
                    break;
            }

            if (root != null)
            {
                Models.ContentPublication publication = this.repository.GetContentPublications().FirstOrDefault(pub => pub.ContentId == root.Id);

                IEnumerable<Models.ContentMedata> metadata = null;
                if (publication != null)
                    metadata = this.repository.GetContentMetadatas().Where(met => met.ContentPublicationId == publication.Id);

                result = new GenericContent(root, publication, metadata);
            }
            return result;
        }

        public IEnumerable<Content.IContent> GetContentCollections()
        {
            throw new NotImplementedException();
        }
        public IEnumerable<Models.ContentMedata> GetContentMetadata(int publicationId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Models.ContentPublication> GetContentPublications(int contentId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Models.ContentSecurity> GetContentSecurity(int contentId, bool includeParentPermissions)
        {
            throw new NotImplementedException();
        }

        public Content.TextContent GetTextContent(int contentId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Models.TextFragment> GetTextFragments(int publicationId)
        {
            throw new NotImplementedException();
        }

        Models.Content IContentManagementDataService.GetContent(int contentId)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<Models.TextFragment> PublishTextContent(int publicationId, string text)
        {
            throw new NotImplementedException();
        }
    }
}