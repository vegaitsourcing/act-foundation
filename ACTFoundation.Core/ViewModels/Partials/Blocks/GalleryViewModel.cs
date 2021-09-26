using ACTFoundation.Models.Generated;
using System.Collections.Generic;
using System.Linq;

namespace ACTFoundation.Core.ViewModels.Partials.Blocks
{
    public class GalleryViewModel
    {
        public GalleryViewModel(Gallery gallery)
        {
            Title = gallery.Title;
            Subtitle = gallery.Subtitle;
            GalleryItems = gallery.GalleryItems.Select(galleryItem => new GalleryItemViewModel(galleryItem)).ToList();
        }

        public string Title { get; set; }

        public string Subtitle { get; set; }

        public List<GalleryItemViewModel> GalleryItems { get; set; }
    }
}