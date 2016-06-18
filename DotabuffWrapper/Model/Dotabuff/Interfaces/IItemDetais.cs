using System.Collections.Generic;

namespace DotabuffWrapper.Model.Dotabuff.Interfaces
{
    public interface IItemDetais
    {
        /// <summary>
        /// Gets the cost.
        /// </summary>
        /// <value>
        /// The cost.
        /// </value>
        int Cost { get; }
        /// <summary>
        /// Gets the item stats.
        /// </summary>
        /// <value>
        /// The item stats.
        /// </value>
        IEnumerable<IItemStat> ItemStats { get; }
    }
}
