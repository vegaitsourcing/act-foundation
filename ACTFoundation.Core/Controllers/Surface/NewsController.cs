using ACTFoundation.Core.Caching;
using ACTFoundation.Core.Models;
using ACTFoundation.Core.ViewModels.Blocks;
using ACTFoundation.Models.Generated;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Umbraco.Web;
using Umbraco.Web.Mvc;

namespace ACTFoundation.Core.Controllers.Surface
{
    public class NewsController : SurfaceController
    {
        private const int ItemsPerPage = 6;
        private const string CacheName = "articles-";
        public ActionResult GetNews(Guid blogId, int pageNumber = 1)
        {
            var articles = GetArticlesFromCache(blogId, pageNumber);
            var blogPage = Umbraco.Content(blogId) as Blog;

            var temp = new LoadNewsViewModel(new LoadmorePagination<ArticleCardViewModel>(blogId, pageNumber, ItemsPerPage, articles), new BlogViewModel(blogPage));
            return PartialView(temp);
        }

        public ActionResult GetMoreNews(Guid blogId, int pageNumber = 1)
        {
            var articles = GetArticlesFromCache(blogId, pageNumber);

            return PartialView(new LoadmorePagination<ArticleCardViewModel>(blogId, pageNumber, ItemsPerPage, articles));
        }

        private List<ArticleCardViewModel> GetArticlesFromCache(Guid blogId, int pageNumber)
        {
            var key = $"{CacheName}{blogId}-{pageNumber}";
            List<ArticleCardViewModel> articles = CacheHelper.Instance.TryRead(key) as List<ArticleCardViewModel>;

            if (articles == null)
            {
                var blogPage = Umbraco.Content(blogId) as Blog;
                articles = blogPage.DescendantsOfType(Article.ModelTypeAlias)
                    .OrderByDescending(x => x.UpdateDate)
                    .Select(x => new ArticleCardViewModel(x as Article))
                    .ToList();

                CacheHelper.Instance.Write(key, articles);
            }
            return articles;
        }
    }
}
