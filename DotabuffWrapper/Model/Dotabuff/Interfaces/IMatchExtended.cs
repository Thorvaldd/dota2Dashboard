using System.Collections.Generic;

namespace DotabuffWrapper.Model.Dotabuff.Interfaces
{
    /// <summary>
    /// Extends the match class with the items used in this match
    /// </summary>
    /// <seealso cref="IMatch" />
    public interface IMatchExtended : IMatch
    {
        /// <summary>
        /// Gets the items.
        /// </summary>
        /// <value>
        /// The items.
        /// </value>
        IEnumerable<IItem> Items { get; } 
    }
}
