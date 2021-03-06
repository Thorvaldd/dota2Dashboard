﻿using System;
using System.IO;
using System.Web.Hosting;
using Newtonsoft.Json;

namespace DotaBuffWrapper.Controller
{
    internal class JsonController
    {
        internal dynamic ReadFromFile(string filePath)
        {
            var gist = new GistClient();
            gist.GetGist("ebaba232180a83083cd1d9a2d7db65da");
            var path = Path.Combine(HostingEnvironment.MapPath("~/"), filePath);
            string jsonString = File.ReadAllText(path);

            return ReadFromString(jsonString);
        }

        internal dynamic ReadFromString(string jsonString)
        {

            dynamic dynamicObject = JsonConvert.DeserializeObject(jsonString);

            return dynamicObject;
        }


    }
}
