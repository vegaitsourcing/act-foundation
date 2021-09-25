using ACTFoundation.Models.Generated;
using System;
using System.Linq;

namespace ACTFoundation.Core.ViewModels.Blocks
{
    public class NewsViewModel
    {
        public NewsViewModel(News news)
        {
            BlogId = news.Blog.FirstOrDefault()?.Key;
        }

        public Guid? BlogId { get; }
    }
}
