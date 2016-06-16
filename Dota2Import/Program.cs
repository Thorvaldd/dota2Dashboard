using System;
using System.Data.Entity;
using WebApiRepository;

namespace Dota2Import
{
    /// <summary>
    /// TODO currently not working because of removing blob from db. 
    /// TODO At first need save file localy, then upload to cloudinary.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Database.SetInitializer<ApplicationContext>(null);
                // ImportDota2Entities.ImportHeroes();
                //  ImportDota2Entities.ImportSmallHeroIcons();
              
                //  var img = new ImageConverting();
               // img.SaveSmallImagesToDirectory();
              //  img.UploadImagesToCloudinary();

              //  img.SaveUploadedImagesUrlToDb();

                ImportDota2Entities.ImportDotaItems();

                Console.ReadLine();
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
                Console.Read();
            }

        }
    }
}
