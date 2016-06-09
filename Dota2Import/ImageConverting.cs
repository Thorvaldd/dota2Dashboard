using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using WebApiRepository;

namespace Dota2Import
{
    public class ImageConverting
    {
        private readonly string _cloudName = ConfigurationManager.AppSettings["cloudname"];
        private readonly string _apiKey = ConfigurationManager.AppSettings["apikey"];
        private readonly string _apiSecret = ConfigurationManager.AppSettings["apisecret"];
        private Cloudinary _cloudinary;

        public ImageConverting()
        {
            var account = new Account(
                _cloudName,
                _apiKey,
                _apiSecret
                );

            _cloudinary = new Cloudinary(account);
        }



        public void SaveSmallImagesToDirectory()
        {
            var appdomain = Settings.UploadSmallImageDirectory;
            if (!Directory.Exists(appdomain))
            {
                Directory.CreateDirectory(appdomain);
            }
            using (var db = new SqlLiteContext())
            {
                var heroAndImages = db.Heroes.Include(x => x.HeroImage).ToList();
                foreach (var image in heroAndImages)
                {
                    using (var img = Image.FromStream(new MemoryStream(image.HeroImage.Blob)))
                    {
                        img.Save(appdomain + image.ValveHeroName + ".png", ImageFormat.Png);
                    }
                }
            }
        }

        public void UploadImagesToCloudinary()
        {
            var d = new DirectoryInfo(Settings.UploadSmallImageDirectory);

            FileInfo[] files = d.GetFiles("*.png");

            foreach (var file in files)
            {
                var uploadParams = new ImageUploadParams
                {
                    File = new FileDescription(file.FullName),
                    Folder = "SmallHeroIcons",
                    PublicId = file.Name.Split('.')[0]
                };
                var uploadResult = _cloudinary.Upload(uploadParams);

                Console.WriteLine("Uploaded -> {0}, with such URI ->{1}", file.Name, uploadResult.Uri.AbsoluteUri);
            }
            Console.ReadLine();
        }

        public void SaveUploadedImagesUrlToDb()
        {
            using (var db = new SqlLiteContext())
            {
                var imgDB = db.Heroes.Include(x => x.HeroImage).ToList();

                foreach (var img in imgDB)
                {
                    var cloudinaryUrl = _cloudinary.GetResource("SmallHeroIcons/" + img.ValveHeroName);
                    img.HeroImage.SmaillImageCloudinaryUrl = cloudinaryUrl.Url;
                    db.SaveChanges();
                }
            }
        }

    }
}
