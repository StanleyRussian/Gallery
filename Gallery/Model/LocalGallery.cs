using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gallery
{
    // Class for an object which actually store list of images in List of iGalleryImage objects
    class LocalGallery : iGallery
    {
        public List<iGalleryImage> Images
        { get; set; }

        public LocalGallery()
        {
            Images = new List<iGalleryImage>();
            Images.Add(new LocalImage(@"D:\Customization\Walls\night_sky_snow-wallpaper-1680x1050.jpg"));
            Images.Add(new LocalImage(@"D:\Customization\Walls\Geometric-Wallpaper-HD-27.jpg"));
            Images.Add(new LocalImage(@"D:\Customization\Walls\2560x1440_SoT.jpg"));
        }
    }
}
