using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Results;
using ACTFoundation.Core.Models.Database;
using Umbraco.Core.Scoping;
using Umbraco.Web.WebApi;

namespace ACTFoundation.Core.Controllers.Surface
{
    public class NewsletterSubscriptionsController: UmbracoApiController
    {
        private readonly IScopeProvider _scopeProvider;

        public NewsletterSubscriptionsController(IScopeProvider scopeProvider)
        {
            _scopeProvider = scopeProvider;
        }

        [HttpGet]
        [Route("subscriptions/getall")]
        [UmbracoAuthorize]
        public JsonResult<IEnumerable<NewsletterSubscriptionDatabaseModel>> GetAll()
        {
            using (var scope = _scopeProvider.CreateScope())
            {
                var result = scope.Database.Query<NewsletterSubscriptionDatabaseModel>("SELECT * FROM NewsletterSubscription");
                return Json(result);
            }
        }

        [HttpPost]
        [Route("subscriptions/add")]
        public void Add(string email)
        {
            using (var scope = _scopeProvider.CreateScope())
            {
                scope.Database.Execute("INSERT INTO NewsletterSubscription(Email) VALUES (@0)", email);
                scope.Database.CompleteTransaction();
            }
        }

        [HttpPost]
        [Route("subscriptions/remove")]
        [UmbracoAuthorize]
        public void Remove(int id)
        {
            using (var scope = _scopeProvider.CreateScope())
            {
                scope.Database.Execute("DELETE FROM NewsletterSubscription WHERE Id = @0", id);
                scope.Database.CompleteTransaction();
            }
        }
    }
}
