using ACTFoundation.Core.Caching;
using System.Linq;
using Umbraco.Core.Composing;
using Umbraco.Core.Events;
using Umbraco.Core.Services;
using Umbraco.Core.Services.Implement;

namespace ACTFoundation.Core.Components
{
    public class HandlePublishedComponent : IComponent
    {
        public void Initialize()
        {
            ContentService.Published += ContentService_Published;
        }

        public void Terminate()
        {
            ContentService.Published -= ContentService_Published;
        }

        private void ContentService_Published(IContentService sender, ContentPublishedEventArgs e)
        {
            foreach (var content in e.PublishedEntities)
            {
                var cacheKeys = CacheHelper.Instance.GetAllKeys().Where(x => x.StartsWith(content.ContentType.Alias)).ToList();

                foreach (var cacheKey in cacheKeys)
                {
                    CacheHelper.Instance.Invalidate(cacheKey);
                }
            }
        }
    }
}