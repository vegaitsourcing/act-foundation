using Umbraco.Web;
using Umbraco.Web.Models;
using ACTFoundation.Models.Generated;

namespace ACTFoundation.Core.ViewModels.Shared
{
	public class TagViewModel
	{
		public TagViewModel(string name, string color)
		{
			Name = name;
			Color = color;
		}

		public TagViewModel(TagItem tagItem)
		{
			Name = tagItem.Name;
			Color = tagItem.TagColor;
		}

		public string Name { get; }
		public string Color { get; }
	}
}
