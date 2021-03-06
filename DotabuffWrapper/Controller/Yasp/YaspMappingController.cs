﻿using System.Collections.Generic;
using DotaBuffWrapper.Model;

namespace DotaBuffWrapper.Controller.Yasp
{
    internal class YaspMappingController : MappingController
    {
        private dynamic dotabuffUrls;

        internal dynamic UrlPath { get { return dotabuffUrls.URL; } }

        internal YaspMappingController(JsonPaths jsonPaths)
        {
            JsonController jsonReader = new JsonController();

            dotabuffUrls = jsonReader.ReadFromFile(jsonPaths.UrlsUri);
        }

        internal Dictionary<string, string> GetAllUrlsAsDictionary()
        {
            return GetMappingAsDictionary(UrlPath);
        }
    }
}
