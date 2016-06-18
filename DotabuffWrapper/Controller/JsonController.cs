using System.Web.Caching;
using Newtonsoft.Json;

namespace DotabuffWrapper.Controller
{
    internal class JsonController
    {
        internal dynamic ReadFromFile(string filePath)
        {
            string jsonString = System.IO.File.ReadAllText(filePath);

            return ReadFromString(jsonString);
        }

        internal dynamic ReadFromString(string jsonString)
        {
            dynamic dynamicObject = JsonConvert.DeserializeObject(jsonString);

            return dynamicObject;
        }
    }
}
