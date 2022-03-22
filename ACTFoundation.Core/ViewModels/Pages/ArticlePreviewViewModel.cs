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
            TextPreview = new HtmlString(article.Text.ToHtmlString().StripHtml().GetTextPreview(ShortTextLength));
            MainImage = article.MainImage.ToViewModel();
            Tags = article.Tags?.Select(tag => new TagViewModel(tag as TagItem));
            Link = article.Url();
        }

        public string Title { get; }
        public ImageViewModel MainImage { get; }
        public IEnumerable<TagViewModel> Tags { get; }
        public IHtmlString TextPreview { get; }
        public string Link { get; }

        //The method has been moved to ACTFoundation.Core.Extensions/StringExtensions to avoid code duplication
        private IHtmlString GetTextPreview(string text)
        {
            return text.Length < ShortTextLength ? new HtmlString(text) : new HtmlString(text.Substring(0, ShortTextLength) + "...");
        }
    }
}
