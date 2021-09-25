using ACTFoundation.Core.Contexts;
using ACTFoundation.Core.Extensions;
using ACTFoundation.Core.ViewModels.Partials.Testimonials;
using ACTFoundation.Core.ViewModels.Shared;
using ACTFoundation.Models.Generated;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Core.Models.PublishedContent;

namespace ACTFoundation.Core.ViewModels.Pages
{
    public class ArticleViewModel: PageViewModel
	{
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
        }

        public string PageTitle { get; }
        public string NavigationTitle { get; }
        public string Title { get; }
        public ImageViewModel MainImage { get; }
        public string Author { get; }
        public IEnumerable<TagViewModel> Tags { get; }
        public IHtmlString Text { get; }
        public System.DateTime CreateDate { get; }
    }
}
