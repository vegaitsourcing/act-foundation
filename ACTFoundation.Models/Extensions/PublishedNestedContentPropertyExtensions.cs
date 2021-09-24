using ACTFoundation.Common.Extensions;
using ACTFoundation.Models.Generated;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Umbraco.Core;
using Umbraco.Core.Models.PublishedContent;

namespace ACTFoundation.Models.Extensions
{
    /// <summary>
    /// <see cref="IPublishedElement"/> extension methods for nested content property access.
    /// </summary>
    public static class PublishedNestedContentPropertyExtensions
	{
		/// <summary>
		/// Returns value of the Nested Content property from the source.
		/// If property (Nested conten returns null if nothing is created) is null, returns empty enumeration.
		/// </summary>
		/// <typeparam name="TNestedContent">Type of the NestedContent model.</typeparam>
		/// <param name="source">The source.</param>
		/// <param name="propertyName">Name of the property.</param>
		/// <returns>Value of the NestedContent property. </returns>
		public static IEnumerable<TNestedContent> GetNestedContentPropertyValue<TNestedContent>(
			this IPublishedElement source, [CallerMemberName] string propertyName = null)
			where TNestedContent : IPublishedElement
				=> source.GetPropertyValue<IEnumerable<IPublishedElement>>(propertyName.ToFirstLower()).EmptyIfNull().OfType<TNestedContent>();

		public static IEnumerable<TNode> GetMultinodePropertyValue<TNode>(
			this IPublishedElement source, [CallerMemberName] string propertyName = null)
			where TNode : PublishedContentModel
				=> source.GetPropertyValue<IEnumerable<IPublishedElement>>(propertyName.ToFirstLower()).EmptyIfNull().OfType<TNode>();

		/// <summary>
		/// Returns value of the Nested Content property where maximum number of items is 1 but minimum number of items is not set.
		/// If returned property is null, returns null.
		/// NOTE: If you need to extract data from NC where max and min number of items are 1, use GetPropertyValue<T> instead.
		/// </summary>
		/// <typeparam name="TNestedContent">Type of the nested content model.</typeparam>
		/// <param name="source">The source.</param>
		/// <param name="propertyName">Name of the property.</param>
		/// <returns>Value of the single nested content property.</returns>
		public static TNestedContent GetNestedContentSinglePropertyValue<TNestedContent>(this IPublishedContent source, [CallerMemberName] string propertyName = null) where TNestedContent : class, IPublishedElement
			=> source.GetPropertyValue<IEnumerable<IPublishedElement>>(propertyName.ToFirstLower())?
				.FirstOrDefault(x => x is TNestedContent) as TNestedContent;
	}
}
