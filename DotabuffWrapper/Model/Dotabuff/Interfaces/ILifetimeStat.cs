namespace DotabuffWrapper.Model.Dotabuff.Interfaces
{
    /// <summary>
    /// This class holds the information for one Lifetime Stat
    /// </summary>
    public interface ILifetimeStat
    {
        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        string Name { get; }
        /// <summary>
        /// Gets the stat.
        /// </summary>
        /// <value>
        /// The stat.
        /// </value>
        IStat Stat { get; }
    }
}
