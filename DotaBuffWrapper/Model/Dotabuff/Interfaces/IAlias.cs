using System;

namespace DotaBuffWrapper.Model.Dotabuff.Interfaces
{
    public interface IAlias
    {
        /// <summary>
        /// Gets the name of the alias.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        string Name { get; }
        /// <summary>
        /// Gets the date the alias was last used.
        /// </summary>
        /// <value>
        /// The last used date.
        /// </value>
        DateTime LastUsed { get; }
    }
}
