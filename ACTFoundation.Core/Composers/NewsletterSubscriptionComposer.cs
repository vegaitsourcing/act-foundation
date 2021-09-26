using ACTFoundation.Core.Components;
using Umbraco.Core;
using Umbraco.Core.Composing;

namespace ACTFoundation.Core.Composers
{
    public class NewsletterSubscriptionComposer: IUserComposer
    {
        public void Compose(Composition composition)
        {
            composition.Components().Append<NewsletterSubscriptionComponent>();
        }
    }
}
