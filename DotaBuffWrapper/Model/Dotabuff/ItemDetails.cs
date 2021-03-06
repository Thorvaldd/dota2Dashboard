﻿using System.Collections.Generic;
using DotaBuffWrapper.Model.Dotabuff.Interfaces;

namespace DotaBuffWrapper.Model.Dotabuff
{
    internal class ItemDetails : IItemDetais
    {
        /// <summary>
        /// Gets the cost.
        /// </summary>
        /// <value>
        /// The cost.
        /// </value>
        public int Cost { get; internal set; }
        /// <summary>
        /// Gets the item stats.
        /// </summary>
        /// <value>
        /// The item stats.
        /// </value>
        public IEnumerable<IItemStat> ItemStats { get; internal set; }

        public override string ToString()
        {
            string itemDetailsString = string.Format("Cost: {0}", Cost);

            foreach (ItemStat itemStat in ItemStats)
            {
                itemDetailsString += string.Format("\r\nCost: {0}", ItemStats);
            }

            return string.Format("{0}, {1}");
        }
    }
}
