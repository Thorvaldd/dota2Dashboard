using System;

namespace Dota2Import
{
    public static class Settings
    {
        public static string UploadSmallImageDirectory
        {
            get { return AppDomain.CurrentDomain.BaseDirectory + "small_hero_images\\"; }
        } 
    }
}
