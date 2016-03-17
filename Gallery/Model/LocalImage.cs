using System;

namespace Gallery
{
    // Implementation of iGalleryImage for local images
    [Serializable]
    class LocalImage : iImageModel
    {
        public string Fullpath { get; private set; }
        public long Size { get; private set; }
        public string Contributor { get; private set; }
        public DateTime Added { get; private set; }

        public int Rating { get; set; }

        public LocalImage(string argPath, string argContributor)
        {
            Fullpath = argPath;
            Added = new DateTime();
            Added = DateTime.Now;
            Size = new System.IO.FileInfo(argPath).Length;
            Rating = 0;
            Contributor = argContributor;
        }
    }
}
