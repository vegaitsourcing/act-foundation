using System;
using System.Linq;
using Umbraco.Web;
using ACTFoundation.Core.Extensions;
using ACTFoundation.Core.ViewModels.Shared;
using ACTFoundation.Models.Generated;
using System.Collections.Generic;

namespace ACTFoundation.Core.ViewModels.Partials.Layout
{
	public class HeaderViewModel
	{
		public HeaderViewModel(IHeader header)
		{
			if (header == null) throw new ArgumentNullException(nameof(header));

			Logo = header.Logo.ToViewModel();
			LogoUrl = header.AncestorOrSelf<Home>().Url();
			MainNavigationButton = new LinkViewModel(header.MainNavigationButton);
			MainNavigationLinks = header.MainNavigationLinks.Select(link => new LinkViewModel(link));
		}

		public ImageViewModel Logo { get; }

		public LinkViewModel MainNavigationButton { get; }

		public IEnumerable<LinkViewModel> MainNavigationLinks { get; }

		public string LogoUrl { get; }
	}
}
