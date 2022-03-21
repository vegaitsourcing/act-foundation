using System.Collections.Generic;
using Umbraco.ModelsBuilder;
using Umbraco.Web;

namespace ACTFoundation.Models.Generated
{
    public partial class PartnerLogosItem
    {
		///<summary>
		/// Partner links
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.1.6")]
		[ImplementPropertyType("partnerLinks")]
		public IEnumerable<Umbraco.Web.Models.Link> PartnerLinks => this.Value<IEnumerable<Umbraco.Web.Models.Link>>("partnerLinks");
	}
}
