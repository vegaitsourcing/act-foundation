using System.Web.Mvc;
using ACTFoundation.Core.ViewModels.Pages;
using ACTFoundation.Models.Generated;

namespace ACTFoundation.Core.Controllers.RenderMvc
{
	public class HomeController : BasePageController<Home>
	{
		public ActionResult Index(Home model) 
			=> CurrentTemplate(new HomeViewModel(CreatePageContext(model)));
	}
}
