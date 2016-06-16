using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web.Hosting;
using DotaBuffWrapper.Model.Dotabuff;
using DotaBuffWrapper.Model.Dotabuff.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WebApiRepository.Implementations.DotaBuffParser.JsonClasses;
using WebApiRepository.Implementations.DotaBuffParser.Results;
using WebApiRepository.Models;

namespace WebApiRepository.Implementations.DotaBuffParser
{
    public class DotaBuffParser
    {
        public IEnumerable<IMatchExtended> GetPlayerInfo(string playerId)
        {
            using (var d = new DotaBuffWrapper.Dataparser())
            {
                return d.GetPlayerMatchesPageData(playerId, new PlayerMatchesOptions());
            }
        }


        public void UpdateItemsEnum()
        {
            //using (var db = new ApplicationContext())
            //{

            //}
            var version = Assembly.GetExecutingAssembly().GetName().Version.ToString();
            var parsingWebsite = ParsingWebsites.Dotabuff;
            var enumPath = string.Format(@"Mapping\{0}\{1}\Enums.json", parsingWebsite, version);

            var fullEnumPath = Path.Combine(HostingEnvironment.MapPath("~/"), enumPath);

            var jsonString = File.ReadAllText(fullEnumPath);
            var joobj = JObject.Parse(jsonString);
            var items = (JObject)joobj["Enums"]["Items"];
            //var mapItems = items.Properties()
            //    .ToDictionary(p => p.Name, p => p.Value.ToObject<JsonClasses.Items>()).OrderBy(x=>x.Key).ToDictionary(x=>x.Key, x=>x.Value);

            var mapItems = new Dictionary<string, JsonClasses.Items>();


            using (var db = new ApplicationContext())
            {
                var allItems = db.GameItems.ToList();
                foreach (var newItem in allItems)
                {
                    var trimmed = newItem.LocalizedName.Replace("Recipe:","").Replace(" ", "");
                    if (!mapItems.ContainsKey(trimmed))
                    {
                        if (newItem.IsRecipe)
                        {
                            var removeRecipe = newItem.LocalizedName.Replace("Recipe:","").TrimStart();
                            mapItems.Add(removeRecipe, new JsonClasses.Items
                            {
                                DotaBuff = newItem.LocalizedName.Replace("Recipe:", "").Replace(" ", "-").ToLower(),
                                Parser = newItem.LocalizedName.Replace("Recipe:", "").Replace(" ", ""),
                                Name = newItem.LocalizedName.Replace("Recipe:","")
                            });
                        }
                        mapItems.Add(newItem.LocalizedName.Replace(" ", ""), new JsonClasses.Items
                        {
                            DotaBuff =  newItem.LocalizedName.Replace(" ", "-").ToLower(),
                            Parser =  newItem.LocalizedName.Replace(" ", ""),
                            Name = newItem.LocalizedName

                        });

                    }
                }
            }

            items.RemoveAll();

            foreach (var map in mapItems)
            {
                items.Add(map.Key, JsonConvert.SerializeObject(map.Value));
            }

            joobj["Enums"]["Items"].Parent.Remove();
            var newProperty = new JProperty("Items", items);
            joobj["Enums"].AddAfterSelf(newProperty.ToString());

            File.WriteAllText(fullEnumPath, joobj.ToString().Replace(@"\"," "));



        }
    }
}
