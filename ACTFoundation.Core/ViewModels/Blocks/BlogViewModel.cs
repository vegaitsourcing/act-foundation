using ACTFoundation.Models.Generated;

namespace ACTFoundation.Core.ViewModels.Blocks
{
	public class BlogViewModel
	{
		public BlogViewModel(Blog blog)
		{
			Title = blog.Name;
			Headline = blog.Headline;
		}

		public string Title { get; set; }
		public string Headline { get; set; }
	}
}
