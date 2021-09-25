using ACTFoundation.Core.Extensions;
using ACTFoundation.Core.ViewModels.Shared;
using ACTFoundation.Models.Generated;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Core;
using Umbraco.Web;

namespace ACTFoundation.Core.ViewModels.Pages
{
    public class ArticlePreviewViewModel
    {
        private const int ShortTextLength = 208;

        public ArticlePreviewViewModel(Article article)
        {
            Title = article.Title;
            TextPreview = GetTextPreview(article.Text.ToHtmlString().StripHtml());
            MainImage = article.MainImage.ToViewModel();
            Tags = article.Tags?.Select(tag => new TagViewModel(tag as TagItem));
            Link = article.Url();
        }

        public string PageTitle { get; }
        public string NavigationTitle { get; }
        public string Title { get; }
        public ImageViewModel MainImage { get; }
        public string Author { get; }
        public IEnumerable<TagViewModel> Tags { get; }
        public IHtmlString TextPreview { get; }
        public System.DateTime CreateDate { get; }
        public string Link { get; }

        private IHtmlString GetTextPreview(string text)
        {
            return text.Length < ShortTextLength ? new HtmlString(text) : new HtmlString(text.Substring(0, ShortTextLength) + "...");
        }
    }
}
