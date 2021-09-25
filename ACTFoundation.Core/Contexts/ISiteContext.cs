using ACTFoundation.Models.Generated;

namespace ACTFoundation.Core.Contexts
{
	public interface ISiteContext
	{
		IPage CurrentPage { get; }
		Home Home { get; }
	}
}
