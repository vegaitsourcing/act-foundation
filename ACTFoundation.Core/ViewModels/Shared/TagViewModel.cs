using ACTFoundation.Models.Generated;
using Umbraco.Web.Composing;

namespace ACTFoundation.Core.ViewModels.Shared
{
	public class TagViewModel
	{
		public TagViewModel(string name, string color, string url)
		{
			Name = name;
			Color = color;
			Url = url;
		}

		public TagViewModel(TagItem tagItem)
		{
			Name = tagItem.Name;
			Color = tagItem.TagColor;
			Url = Current.UmbracoContext.UrlProvider.GetUrl(tagItem.Id);
		}

		public string Name { get; }
		public string Color { get; }
		public string Url { get; }
	}
}
