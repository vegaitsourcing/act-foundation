using ACTFoundation.Core.Models;
using ACTFoundation.Core.ViewModels.Blocks;
using ACTFoundation.Models.Generated;
using System;
using System.Linq;
using System.Web.Mvc;
using Umbraco.Web;
using Umbraco.Web.Mvc;

namespace ACTFoundation.Core.Controllers.Surface
{
	public class NewsController : SurfaceController
	{
		public ActionResult GetMoreNews(Guid blogId, int pageNumber = 1)
		{
			var blogPage = Umbraco.Content(blogId) as Blog;
			var articles = blogPage.DescendantsOfType(Article.ModelTypeAlias)
				.Select(x => new ArticleCardViewModel(x as Article))
				.ToList();

			return PartialView(new LoadmorePagination<ArticleCardViewModel>(blogId, pageNumber, 6, articles));
		}
	}
}
