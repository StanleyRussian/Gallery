using System;

namespace Gallery
{
    // Interface for an object representing single gallery image
    // Gallery object adresses this interface
    interface iImageModel
    {
        string Fullpath { get; }
        long Size { get; }
        int Rating { get; set; }
        string Contributor { get; }
        DateTime Added { get; }
    }
}
