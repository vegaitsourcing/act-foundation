//------------------------------------------------------------------------------
// <auto-generated>
//   This code was generated by a tool.
//
//    Umbraco.ModelsBuilder v8.1.6
//
//   Changes to this file will be lost if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Web;
using Umbraco.Core.Models;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;
using Umbraco.ModelsBuilder;
using Umbraco.ModelsBuilder.Umbraco;

namespace ACTFoundation.Models.Generated
{
	/// <summary>Account information</summary>
	[PublishedModel("accountInformation")]
	public partial class AccountInformation : PublishedElementModel
	{
		// helpers
#pragma warning disable 0109 // new is redundant
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.1.6")]
		public new const string ModelTypeAlias = "accountInformation";
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.1.6")]
		public new const PublishedItemType ModelItemType = PublishedItemType.Content;
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.1.6")]
		public new static IPublishedContentType GetModelContentType()
			=> PublishedModelUtility.GetModelContentType(ModelItemType, ModelTypeAlias);
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.1.6")]
		public static IPublishedPropertyType GetModelPropertyType<TValue>(Expression<Func<AccountInformation, TValue>> selector)
			=> PublishedModelUtility.GetModelPropertyType(GetModelContentType(), selector);
#pragma warning restore 0109

		// ctor
		public AccountInformation(IPublishedElement content)
			: base(content)
		{ }

		// properties

		///<summary>
		/// Account: Racun
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.1.6")]
		[ImplementPropertyType("account")]
		public string Account => this.Value<string>("account");

		///<summary>
		/// Calling Model: Model
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.1.6")]
		[ImplementPropertyType("callingModel")]
		public string CallingModel => this.Value<string>("callingModel");

		///<summary>
		/// Call number: Poziv na broj
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.1.6")]
		[ImplementPropertyType("callNumber")]
		public string CallNumber => this.Value<string>("callNumber");

		///<summary>
		/// Recepient: Primalac
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.1.6")]
		[ImplementPropertyType("recepient")]
		public string Recepient => this.Value<string>("recepient");
	}
}