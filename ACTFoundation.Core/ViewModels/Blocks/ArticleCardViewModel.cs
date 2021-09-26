using ACTFoundation.Core.ViewModels.Shared;
using ACTFoundation.Models.Generated;
using System.Collections.Generic;
using System.Web;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;
using Umbraco.Core;

namespace ACTFoundation.Core.ViewModels.Blocks
{
	public class ArticleCardViewModel
    {

		private const int ShortTextLength = 208;

		public ArticleCardViewModel(Article article)
		{
			PageTitle = article.PageTitle;
			NavigationTitle = article.NavigationTitle;
			Title = article.Title;
			Author = article.Author;
			MainImage = new ImageViewModel(article.MainImage);
			Tags = article.Tags;
			Text = GetTextPreview(article.Text.ToHtmlString().StripHtml());
			Url = article.Url();
		}

		public string PageTitle { get; set; }
		public string NavigationTitle { get; set; }
		public string Title { get; set; }
		public string Author { get; set; }
		public ImageViewModel MainImage { get; }
		public IEnumerable<IPublishedContent> Tags { get; set; } //UPDATE
		public IHtmlString Text { get; set; }
		public string Url { get; set; }

		private IHtmlString GetTextPreview(string text)
		{
			return text.Length < ShortTextLength ? new HtmlString(text) : new HtmlString(text.Substring(0, ShortTextLength) + "...");
		}
	}
}
