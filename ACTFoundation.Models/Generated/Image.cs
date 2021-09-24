using Umbraco.Core.Models.PublishedContent;
using Umbraco.ModelsBuilder;
using ACTFoundation.Models.MediaTypes;

namespace ACTFoundation.Models.Generated
{
	/// <summary>
	/// Image media type model.
	/// </summary>
	[RenamePropertyType("umbracoExtension", "Type")]
	[RenamePropertyType("umbracoFile", "Cropper")]
	[RenamePropertyType("umbracoHeight", "Height")]
	[RenamePropertyType("umbracoWidth", "Width")]
	[RenamePropertyType("umbracoBytes", "Size")]
	public partial class Image : PublishedContentModel, IMedia
	{
	}
}
