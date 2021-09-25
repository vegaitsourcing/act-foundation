using System.Web.Mvc;
using ACTFoundation.Core.ViewModels.Pages;
using ACTFoundation.Models.Generated;

namespace ACTFoundation.Core.Controllers.RenderMvc
{
	public class ArticleController : BasePageController<Article>
	{
		public ActionResult Index(Article model) 
			=> CurrentTemplate(new ArticleViewModel(CreatePageContext(model)));
	}
}
