using System.Collections.Generic;
using System.Linq;

namespace ACTFoundation.Common.Extensions
{
    /// <summary>
    /// <see cref="IEnumerable{T}"/>  extension methods.
    /// </summary>
    public static class IEnumerableExtensions
	{
		/// <summary>
		/// Returns empty enumerable sequence if <paramref name="source"/> is null.
		/// </summary>
		/// <typeparam name="T">Sequence elements type.</typeparam>
		/// <param name="source">The source sequence.</param>
		/// <returns>Empty sequence if <paramref name="source"/> is null, otherwise <paramref name="source"/> sequence.</returns>
		public static IEnumerable<T> EmptyIfNull<T>(this IEnumerable<T> source)
			=> source ?? Enumerable.Empty<T>();
	}
}
