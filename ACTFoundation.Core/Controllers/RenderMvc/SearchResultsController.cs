using System.Web.Mvc;
using ACTFoundation.Core.Extensions;
using ACTFoundation.Core.ViewModels.Pages;
using ACTFoundation.Models.Generated;

namespace ACTFoundation.Core.Controllers.RenderMvc
{
	public class SearchResultsController : BasePageController<SearchResults>
	{
		public ActionResult Index(SearchResults model)
			=> CurrentTemplate(
				new SearchResultsViewModel(CreatePageContext(model), 
				Request.GetQueryParameter(),
				Request.GetPageParameter()));
	}
}
