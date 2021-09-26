using ACTFoundation.Core.Models;

namespace ACTFoundation.Core.ViewModels.Blocks
{
    public class LoadNewsViewModel
    {
        public LoadNewsViewModel(LoadmorePagination<ArticleCardViewModel> loadPaginationItems, BlogViewModel blog)
        {
            LoadPaginationItems = loadPaginationItems;
            Blog = blog;
        }

        public LoadmorePagination<ArticleCardViewModel> LoadPaginationItems { get; set; }
        public BlogViewModel Blog { get; set; }
    }
}
