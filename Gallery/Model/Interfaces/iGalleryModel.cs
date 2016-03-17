using System.Collections.Generic;

namespace Gallery
{
    // Interface for an obect representing gallery of images
    // GalleryViewModel (GalleryVM) adresses this interface
    interface iGalleryModel
    {
        List<iImageModel> Images
        { get; }

        void Add(string argFullpath);
        void Remove(string argFullpath);
        void SaveGallery();
    }
}
