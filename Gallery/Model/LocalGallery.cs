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
        readonly private string _savepath;
        private User loggedUser;
        public List<iImageModel> Images
        { get; set; }

        public LocalGallery(User argLoggedUser)
        {
            _savepath = "gallery";
            loggedUser = argLoggedUser;
            Images = new List<iImageModel>();
                LoadGallery();
        }

        public void Add(string argFullpath)
        {
            Images.Add(new LocalImage(argFullpath, loggedUser.Login));
        }

        public void SaveGallery()
        {
            FileStream stream = new FileStream(_savepath, FileMode.Create);
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, Images);
            stream.Close();
        }

        private void LoadGallery()
        {
            if (!File.Exists(_savepath))
                return;
            FileStream stream = new FileStream(_savepath, FileMode.Open);
            if (stream.Length == 0)
                return;
            BinaryFormatter formatter = new BinaryFormatter();
            Images = (List<iImageModel>)formatter.Deserialize(stream);
            stream.Close();
        }

        public void Remove(string argFullpath)
        {
            Images.Remove(Images.Find(x => x.Fullpath == argFullpath));
        }
    }
}
