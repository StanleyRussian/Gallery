using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Xml;

namespace Gallery
{
    // Class for an object which actually store list of images in List of iGalleryImage objects
    class LocalGallery : iGalleryModel
    {
        public List<iImageModel> Images
        { get; set; }

        public LocalGallery()
        {
            Images = new List<iImageModel>();
            if (File.Exists("data"))
                LoadGallery();
        }

        public void Add(string argFullpath)
        {
            Images.Add(new LocalImage(argFullpath));
        }

        public void SaveGallery()
        {
            FileStream stream = new FileStream("data", FileMode.Create);
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, Images);
            stream.Close();
        }

        private void LoadGallery()
        {
            FileStream stream = new FileStream("data", FileMode.Open);
            if (stream.Length == 0)
                return;
            BinaryFormatter formatter = new BinaryFormatter();
            Images = (List<iImageModel>)formatter.Deserialize(stream);
            stream.Close();
        }
    }
}
