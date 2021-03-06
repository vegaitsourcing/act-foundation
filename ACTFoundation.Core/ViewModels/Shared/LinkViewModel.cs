using Umbraco.Web;
using Umbraco.Web.Models;
using ACTFoundation.Models.Generated;

namespace ACTFoundation.Core.ViewModels.Shared
{
	public class LinkViewModel
	{
		public LinkViewModel(string url, string content, string target = null)
		{
			Url = url;
			Content = content;
			Target = target;
		}

		public LinkViewModel(Link link) : this(link.Url, link.Name, link.Target)
		{ }

		public LinkViewModel(IPage node, string target = null) : this(node.Url(), node.PageTitle, target)
		{ }

		public string Url { get; set; }
		public string Content { get; }
		public string Target { get; }
	}
}
