using Umbraco.Core.Composing;
using Umbraco.Web;

namespace ACTFoundation.Core
{
	public static class UmbracoDictionary
	{
		public static UmbracoHelper UmbracoHelper => (UmbracoHelper) Current.Factory.GetInstance(typeof(UmbracoHelper));
	}
}
