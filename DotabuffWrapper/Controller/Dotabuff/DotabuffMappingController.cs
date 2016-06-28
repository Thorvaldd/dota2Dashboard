using System.Collections.Generic;
using System.Linq;
using DotaBuffWrapper.Model;
using EasyGitHub.Entities;

namespace DotaBuffWrapper.Controller.Dotabuff
{
    internal class DotabuffMappingController : MappingController
    {
        private dynamic dotabuffXPaths;
        private dynamic dotabuffQueryStrings;
        private dynamic dotabuffEnums;
        private dynamic dotabuffSelectors;
        private dynamic dotabuffHtmlAttributes;
        private dynamic dotabuffUrls;

        internal dynamic PlayersPath { get { return dotabuffXPaths.Players; } }
        internal dynamic PlayerPath { get { return dotabuffXPaths.Players.Player; } }
        internal dynamic PlayerMatchesPath { get { return dotabuffXPaths.Matches; } }

        internal dynamic HeroesPath { get { return dotabuffXPaths.Heroes; } }
        internal dynamic HeroPath { get { return dotabuffXPaths.Heroes.Hero; } }
        internal dynamic HeroAbilitiesPath { get { return dotabuffXPaths.Abilities; } }

        internal dynamic ItemsPath { get { return dotabuffXPaths.Items; } }
        internal dynamic ItemPath { get { return dotabuffXPaths.Items.Item; } }

        internal dynamic HtmlAttributes { get { return dotabuffHtmlAttributes.Attributes; } }
        internal dynamic Selector { get { return dotabuffSelectors.Selector; } }
        internal dynamic QueryString { get { return dotabuffQueryStrings.QueryStringMapping; } }
        internal dynamic EnumMapping { get { return dotabuffEnums.Enums; } }
        internal dynamic UrlPath { get { return dotabuffUrls.URL; } }

        internal DotabuffMappingController(JsonPaths jsonPaths)
        {
            JsonController jsonReader = new JsonController();
            GistClient gistClient = new GistClient();


            var gistFiles = gistClient.GetGist("ebaba232180a83083cd1d9a2d7db65da");

            //dotabuffXPaths = jsonReader.ReadFromFile(jsonPaths.XPathsUri);
            dotabuffXPaths = jsonReader.ReadFromString(gistFiles["XPaths"].Content);
            
            
            //dotabuffQueryStrings = jsonReader.ReadFromFile(jsonPaths.QueryStringsUri);
            dotabuffQueryStrings = jsonReader.ReadFromString(gistFiles["QueryStrings"].Content);

            //dotabuffEnums = jsonReader.ReadFromFile(jsonPaths.EnumsUri);
            dotabuffEnums = jsonReader.ReadFromString(gistFiles["Enums"].Content);

            //dotabuffSelectors = jsonReader.ReadFromFile(jsonPaths.SelectorsUri);
            dotabuffSelectors = jsonReader.ReadFromString(gistFiles["Selectors"].Content);

            //dotabuffHtmlAttributes = jsonReader.ReadFromFile(jsonPaths.HtmlAttributesUri);
            dotabuffHtmlAttributes = jsonReader.ReadFromString(gistFiles["HtmlAttributes"].Content);

            //dotabuffUrls = jsonReader.ReadFromFile(jsonPaths.UrlsUri);
            dotabuffUrls = jsonReader.ReadFromString(gistFiles["Urls"].Content);
        }

        internal Dictionary<string, string> GetPlayerPathsAsDictionary()
        {
            return GetXPathsAsDictionary(PlayerPath);
        }

        internal Dictionary<string, string> GetHeroPathsAsDictionary()
        {
            return GetXPathsAsDictionary(HeroPath);
        }

        internal Dictionary<string, string> GetItemPathsAsDictionary()
        {
            return GetXPathsAsDictionary(ItemPath);
        }
    }
}
