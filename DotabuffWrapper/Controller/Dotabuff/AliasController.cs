using System;
using System.Collections.Generic;
using System.Linq;
using DotabuffWrapper.Model.Dotabuff;
using HtmlAgilityPack;

namespace DotabuffWrapper.Controller.Dotabuff
{
    internal class AliasController
    {
        private MainController mainController;

        private dynamic PlayerPath { get { return mainController.DotabuffMappingController.PlayerPath; } }

        internal AliasController(MainController mainController)
        {
            this.mainController = mainController;
        }

        internal List<Alias> FetchAliases(string playerId)
        {
            HtmlNode root = mainController.HtmlDocumentController.GetDotabuffPlayerRoot(playerId);

            HtmlNode aliasesTable = root.SelectSingleNode(PlayerPath.Aliases.Value);

            var query = from table in aliasesTable.ChildNodes
                        from row in table.SelectNodes(MainController.HTML_TABLE_TR).Cast<HtmlNode>()
                        select row;

            return query.Skip(1).Select(row => new Alias() { Name = row.ChildNodes[0].InnerText, LastUsed = DateTime.Parse(row.ChildNodes[1].InnerText) }).ToList();
        }
    }
}
