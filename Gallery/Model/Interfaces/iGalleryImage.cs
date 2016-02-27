using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gallery
{
    // Interface for an object representing single gallery image
    // Gallery object adresses this interface
    interface iGalleryImage
    {
        string Path { get; }
        int Size { get; }
        int Mark { get; }
        string Contributor { get; }
        DateTime Added { get; }
    }
}
