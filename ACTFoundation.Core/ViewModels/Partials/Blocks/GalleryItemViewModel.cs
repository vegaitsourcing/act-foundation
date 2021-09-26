using ACTFoundation.Core.ViewModels.Shared;
using ACTFoundation.Models.Generated;
using System;
using System.Globalization;

namespace ACTFoundation.Core.ViewModels.Partials.Blocks
{
    public class GalleryItemViewModel
    {
        public GalleryItemViewModel(GalleryItem galleryItem)
        {
            GalleryImage = new ImageViewModel(galleryItem.GalleryImage);
            GalleryDescription = galleryItem.GalleryDescription;
            GalleryDate = galleryItem.GalleryDate.ToString("dd. MMMM yyyy", new CultureInfo("sr-Latn-CS"));
        }

        public ImageViewModel GalleryImage { get; set; }

        public string GalleryDescription { get; set; }

        public String GalleryDate { get; set; }
    }
}