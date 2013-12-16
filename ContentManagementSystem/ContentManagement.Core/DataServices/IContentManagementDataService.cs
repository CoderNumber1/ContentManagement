using ContentManagement.Content;
using ContentManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ContentManagement.DataServices
{
    public interface IContentManagementDataService
        : IDisposable
    {
        IContent GetContent(string contentPath);
        IContent GetContentCollection(string collectionName);
        IEnumerable<IContent> GetContentCollections();

        IEnumerable<IContent> GetChildContents(int parentContentId);

        IContent GetGenericContent(int contentId);
        TextContent GetTextContent(int contentId);

        Models.Content GetContent(int contentId);
        IEnumerable<ContentSecurity> GetContentSecurity(int contentId, bool includeParentPermissions);
        IEnumerable<ContentPublication> GetContentPublications(int contentId);
        IEnumerable<TextFragment> GetTextFragments(int publicationId);
        IEnumerable<ContentMedata> GetContentMetadata(int publicationId);

        Models.Content CreateContent();
        ContentSecurity CreateSecurity(int contentId);
        ContentPublication CreatePublication(int contentId);
        IEnumerable<TextFragment> PublishTextContent(int publicationId, string text);
        ContentMedata CreateContentMetadata(int publicationId);
        void AddContentToCollection(int contentId, int parentId);
    }
}
