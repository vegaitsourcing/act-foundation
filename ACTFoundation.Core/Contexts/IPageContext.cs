using ACTFoundation.Models.Generated;

namespace ACTFoundation.Core.Contexts
{
	public interface IPageContext<out T> : ISiteContext where T : class, IPage
	{
		T Page { get; }
	}
}
