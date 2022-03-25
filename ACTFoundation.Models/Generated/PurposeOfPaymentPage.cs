using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.ModelsBuilder;
using Umbraco.ModelsBuilder.Umbraco;
using Umbraco.Web;

namespace ACTFoundation.Models.Generated
{
    /// <summary>PurposeOfPaymentPage</summary>
    [PublishedModel("purposeOfPaymentPage")]
    public partial class PurposeOfPaymentPage : PublishedContentModel
    {
		//helpers
#pragma warning disable 0109 // new is redundant
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.1.6")]
		public new const string ModelTypeAlias = "purposeOfPaymentPage";
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.1.6")]
		public new const PublishedItemType ModelItemType = PublishedItemType.Content;
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.1.6")]
		public new static IPublishedContentType GetModelContentType()
			=> PublishedModelUtility.GetModelContentType(ModelItemType, ModelTypeAlias);
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.1.6")]
		public static IPublishedPropertyType GetModelPropertyType<TValue>(Expression<Func<PurposeOfPaymentPage, TValue>> selector)
			=> PublishedModelUtility.GetModelPropertyType(GetModelContentType(), selector);
#pragma warning restore 0109

		// ctor
		public PurposeOfPaymentPage(IPublishedContent content)
			: base(content)
		{ }


		///<summary>
		/// PurposeOfPaymentPage Content
		/// </summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.1.6")]
		[ImplementPropertyType("purposesOfPayment")]
		public IEnumerable<PurposeOfPayment> PurposesOfPayment => this.Value<IEnumerable<PurposeOfPayment>>("purposesOfPayment");

	}
}
