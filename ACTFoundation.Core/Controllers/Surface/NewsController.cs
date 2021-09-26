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
		private const int ItemsPerPage = 6;
		public ActionResult GetNews(Guid blogId, int pageNumber = 1)
		{
			var blogPage = Umbraco.Content(blogId) as Blog;
			var articles = blogPage.DescendantsOfType(Article.ModelTypeAlias)
				.Select(x => new ArticleCardViewModel(x as Article))
				.ToList();

			var temp = new LoadNewsViewModel(new LoadmorePagination<ArticleCardViewModel>(blogId, pageNumber, ItemsPerPage, articles), new BlogViewModel(blogPage));
			return PartialView(temp);
		}

		public ActionResult GetMoreNews(Guid blogId, int pageNumber = 1)
		{
			var blogPage = Umbraco.Content(blogId) as Blog;
			var articles = blogPage.DescendantsOfType(Article.ModelTypeAlias)
				.Select(x => new ArticleCardViewModel(x as Article))
				.ToList();

			return PartialView(new LoadmorePagination<ArticleCardViewModel>(blogId, pageNumber, ItemsPerPage, articles));
		}
	}
}
