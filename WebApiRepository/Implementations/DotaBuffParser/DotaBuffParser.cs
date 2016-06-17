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
            var version = Assembly.GetExecutingAssembly().GetName().Version.ToString();
            var parsingWebsite = ParsingWebsites.Dotabuff;
            var enumPath = string.Format(@"Mapping\{0}\{1}\Enums.json", parsingWebsite, version);

            var fullEnumPath = Path.Combine(HostingEnvironment.MapPath("~/"), enumPath);

            var jsonString = File.ReadAllText(fullEnumPath);
            var joobj = JObject.Parse(jsonString);
            var items = (JObject)joobj["Enums"]["Items"];

            var mapItems = new Dictionary<string, JsonClasses.Items>();


            using (var db = new ApplicationContext())
            {
                var allItems = db.GameItems.ToList();

               // if(allItems.Count > items.Count)

                foreach (var newItem in allItems)
                {
                    var trimmed = newItem.LocalizedName.Replace(" ", "").Replace("Recipe:","");
                    if (!mapItems.ContainsKey(trimmed))
                    {
                        if (newItem.IsRecipe)
                        {
                            var removeRecipe = newItem.LocalizedName.Replace(":","").Replace(" ","");
                            mapItems.Add(removeRecipe, new JsonClasses.Items
                            {
                                DotaBuff = newItem.LocalizedName.Replace(":","").Replace(' ', '-').ToLower(),
                                Parser = newItem.LocalizedName.Replace(":", "").Replace(" ", ""),
                                Name = newItem.LocalizedName.Replace(":"," ").TrimStart()
                            });
                        }
                        mapItems.Add(newItem.LocalizedName.Replace(" ", "").Replace("Recipe:",""), new JsonClasses.Items
                        {
                            DotaBuff =  newItem.LocalizedName.Replace("Recipe:","").TrimStart().Replace(" ", "-").ToLower(),
                            Parser =  newItem.LocalizedName.Replace("Recipe:", "").TrimStart().Replace(" ", ""),
                            Name = newItem.LocalizedName.Replace("Recipe:", "").TrimStart()

                        });

                    }

                   
                }
                if (mapItems.ContainsKey("Necronomicon"))
                {
                    for (int i = 2; i > 0; i--)
                    {
                        mapItems.Add("NecronomiconLevel" + (i + 1), new JsonClasses.Items
                        {
                            DotaBuff = "necronomicon-level-" + (i + 1),
                            Parser = "NecronomiconLevel" + (i + 1),
                            Name = "Necronomicon (level " + (i + 1) + " )"
                        });
                    }
                }
            }

            items.RemoveAll();

            foreach (var map in mapItems)
            {
                var jToken = JToken.FromObject(map.Value);
                items.Add(map.Key, jToken);
            }

            File.WriteAllText(fullEnumPath, joobj.ToString());



        }
    }
}
