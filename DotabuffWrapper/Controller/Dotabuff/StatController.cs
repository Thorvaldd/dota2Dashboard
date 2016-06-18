using DotabuffWrapper.Model.Dotabuff;
using HtmlAgilityPack;

namespace DotabuffWrapper.Controller.Dotabuff
{
    internal class StatController
    {
        private MainController mainController;

        private dynamic PlayerPath { get { return mainController.DotabuffMappingController.PlayerPath; } }

        internal StatController(MainController mainController)
        {
            this.mainController = mainController;
        }

        internal Stat MapHtmlNode(HtmlNode root, int currentCount)
        {
            string matchesPlayed = root.SelectSingleNode(string.Format(PlayerPath.MostPlayedHeroes.MatchesPlayed.Value, currentCount)).InnerText;
            string winRate = root.SelectSingleNode(string.Format(PlayerPath.MostPlayedHeroes.Winrate.Value, currentCount)).InnerText;
            string kdaRatio = root.SelectSingleNode(string.Format(PlayerPath.MostPlayedHeroes.Kda.Value, currentCount)).InnerText;

            return new Stat(matchesPlayed.Replace(",", ""), winRate, kdaRatio.Replace(".", ","));
        }
    }
}
