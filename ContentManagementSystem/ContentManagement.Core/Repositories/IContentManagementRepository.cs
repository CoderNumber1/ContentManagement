using ContentManagement.Models;
using System;
using System.Linq;

namespace ContentManagement.Repositories
{
    public interface IContentManagementRepository
        : IDisposable
    {
        #region Get

        IQueryable<ContentCollection> GetContentCollections();

        IQueryable<ContentMedata> GetContentMetadatas();

        IQueryable<ContentPublication> GetContentPublications();

        IQueryable<Models.Content> GetContents();

        IQueryable<ContentSecurity> GetContentSecurities();

        IQueryable<ContentSource> GetContentSources();

        IQueryable<ContentType> GetContentTypes();

        IQueryable<SecurityType> GetSecurityTypes();

        IQueryable<TextFragment> GetTextFragments();

        #endregion Get

        #region Create

        Models.Content CreateContent();

        ContentCollection CreateContentCollection();

        ContentMedata CreateContentMetadata();

        ContentPublication CreateContentPublication();

        ContentSecurity CreateContentSecurity();

        ContentSource CreateContentSource();

        ContentType CreateContentType();

        SecurityType CreateSecurityType();

        TextFragment CreateTextFragment();

        #endregion Create

        #region General

        void Attach(object entity);

        void Delete(object entity);

        void Save(object entity);

        #endregion General
    }
}