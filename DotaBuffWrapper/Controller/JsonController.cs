using System;
using System.IO;
using System.Web.Hosting;
using Newtonsoft.Json;

namespace DotaBuffWrapper.Controller
{
    internal class JsonController
    {
        internal dynamic ReadFromFile(string filePath)
        {
            var path = Path.Combine(HostingEnvironment.MapPath("~/"), filePath);
            string jsonString = File.ReadAllText(path);

            return ReadFromString(jsonString);
        }

        internal dynamic ReadFromString(string jsonString)
        {
            dynamic dynamicObject = JsonConvert.DeserializeObject(jsonString);

            return dynamicObject;
        }

        internal dynamic ReadFromGithub(string filePath)
        {
            dynamic dynamicObject = "";

            return dynamicObject;
        }
    }
}
