using System;
using System.Collections.Generic;
using System.Web;
using ACTFoundation.Core.ViewModels.Shared;
using ACTFoundation.Models.Generated;
using Umbraco.Core.Models;

namespace ACTFoundation.Core.ViewModels.Partials.Layout
{
	public class FooterViewModel
	{
		public FooterViewModel(IFooter footer)
		{
			this.FooterCompanyLogo = new ImageViewModel(footer.FooterCompanyLogo);
			this.FooterCompanyName = footer.FooterCompanyName;
			this.FooterCompanyMoto = footer.FooterCompanyMoto;
			this.FooterCompanyDescription = footer.FooterCompanyDescription;
			this.FooterFindOutMoreButton = new LinkViewModel(footer.FooterFindOutMoreButton);
			this.ShowNewsletterBox = footer.ShowNewsletterBox;
			this.FooterPartnerLogos = footer.FooterPartnerLogos;
		}
		public ImageViewModel FooterCompanyLogo { get; }
		public string FooterCompanyName { get; }
		public string FooterCompanyMoto { get; }
		public IHtmlString FooterCompanyDescription { get; }
		public string CopyrightText { get; }
		public LinkViewModel FooterFindOutMoreButton { get; }
		public IEnumerable<MediaWithCrops> FooterPartnerLogos { get; }
		public bool ShowNewsletterBox { get; }

	}
}
