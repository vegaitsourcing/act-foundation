using ACTFoundation.Core.Contexts;
using ACTFoundation.Core.Extensions;
using ACTFoundation.Core.ViewModels.Shared;
using ACTFoundation.Models.Generated;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Core.Models.PublishedContent;

namespace ACTFoundation.Core.ViewModels.Pages
{
    public class ArticleViewModel : PageViewModel
    {
        private const int RelatedArticlesToDisplay = 4;

        public ArticleViewModel(IPageContext<Article> context) : base(context)
        {
            PageTitle = context.Page.PageTitle;
            NavigationTitle = context.Page.NavigationTitle;
            Title = context.Page.Title;
            MainImage = context.Page.MainImage.ToViewModel();
            Author = context.Page.Author;
            Text = context.Page.Text;
            CreateDate = context.Page.CreateDate;
            Tags = context.Page.Tags?.Select(tag => new TagViewModel(tag as TagItem));
            ArticleId = context.Page.Id;
            RelatedArticles = GetRelatedArticles(context.Page.Parent.Children);
        }

        public string PageTitle { get; }
        public string NavigationTitle { get; }
        public string Title { get; }
        public ImageViewModel MainImage { get; }
        public string Author { get; }
        public IEnumerable<TagViewModel> Tags { get; }
        public IHtmlString Text { get; }
        public System.DateTime CreateDate { get; }
        public IEnumerable<ArticlePreviewViewModel> RelatedArticles { get; }

        private int ArticleId { get; }

        private IEnumerable<ArticlePreviewViewModel> GetRelatedArticles(IEnumerable<IPublishedContent> contentItems)
        {
            var relatedArticles = contentItems
                .Select(article => article as Article)
                .Where(article => article.Id != ArticleId && article.Tags != null && Tags != null && article.Tags.Any(tag => MatchingProvidedTags(tag as TagItem, Tags)))
                .Take(RelatedArticlesToDisplay)
                .Select(article => new ArticlePreviewViewModel(article))
                .ToArray();

            if (relatedArticles == null || relatedArticles.Length == 0)
            {
                return GetNewestArticles(contentItems, RelatedArticlesToDisplay);
            }
            return relatedArticles;
        }

        private IEnumerable<ArticlePreviewViewModel> GetNewestArticles(IEnumerable<IPublishedContent> contentItems, int count)
        {
            return contentItems
                .Select(article => article as Article)
                .Where(article => article.Id != ArticleId)
                .OrderByDescending(article => article.CreateDate)
                .Take(count)
                .Select(article => new ArticlePreviewViewModel(article))
                .ToArray();
        }
        
        private bool MatchingProvidedTags(TagItem tag, IEnumerable<TagViewModel> tags)
            => tags.Any(t => t.Name == tag.Name);

        private class MatchingArticles
        {
            public MatchingArticles(ArticlePreviewViewModel matchingArticle, int matchingArticleNumber)
            {
                MatchingArticle = matchingArticle;
                MatchingArticleNumber = matchingArticleNumber;
            }

            private ArticlePreviewViewModel MatchingArticle { get; }
            private int MatchingArticleNumber { get; }
        }
    }
}
