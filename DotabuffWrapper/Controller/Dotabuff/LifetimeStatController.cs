﻿using System.Collections.Generic;
using System.Linq;
using DotaBuffWrapper.Model.Dotabuff;
using DotaBuffWrapper.Model.Dotabuff.Interfaces;
using HtmlAgilityPack;

namespace DotaBuffWrapper.Controller.Dotabuff
{
    internal class LifetimeStatController
    {
        private MainController mainController;

        private dynamic PlayerPath { get { return mainController.DotabuffMappingController.PlayerPath; } }

        internal LifetimeStatController(MainController mainController)
        {
            this.mainController = mainController;
        }

        internal Dictionary<string, List<ILifetimeStat>> FetchLifetimeStats(string playerId)
        {
            HtmlNode root = mainController.HtmlDocumentController.GetDotabuffPlayerRoot(playerId);

            HtmlNode lifetimeStatsTable = root.SelectSingleNode(PlayerPath.LifetimeStats.Value);

            var query = from table in lifetimeStatsTable.ChildNodes
                        from row in table.SelectNodes(MainController.HTML_TABLE_TR).Cast<HtmlNode>()
                        select row;

            Dictionary<string, List<ILifetimeStat>> lifetimeStats = new Dictionary<string, List<ILifetimeStat>>();

            string possibleKey = string.Empty;

            foreach (HtmlNode row in query)
            {
                if (row.ChildNodes[0].Name == MainController.HTML_TABLE_TH)
                    possibleKey = row.ChildNodes[0].InnerText;

                if (!lifetimeStats.ContainsKey(possibleKey))
                {
                    lifetimeStats.Add(possibleKey, new List<ILifetimeStat>());
                }
                else
                {
                    lifetimeStats[possibleKey].Add(MapHtmlNode(row));
                }
            }

            return lifetimeStats;
        }

        private LifetimeStat MapHtmlNode(HtmlNode tableRow)
        {
            return new LifetimeStat(tableRow.ChildNodes[0].InnerText, tableRow.ChildNodes[1].InnerText.Replace(",", ""), tableRow.ChildNodes[2].InnerText);
        }
    }
}
