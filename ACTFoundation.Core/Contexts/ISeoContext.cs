using ACTFoundation.Models.DocumentTypes;

namespace ACTFoundation.Core.Contexts
{
	public interface ISeoContext<out T> : ISiteContext where T : class, ISeo
	{
		T Seo { get; }
	}
}
