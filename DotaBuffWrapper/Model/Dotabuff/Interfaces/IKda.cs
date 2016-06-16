namespace DotaBuffWrapper.Model.Dotabuff.Interfaces
{
    public interface IKda
    {
        /// <summary>
        /// Gets the kills.
        /// </summary>
        /// <value>
        /// The kills.
        /// </value>
        int Kills { get; }
        /// <summary>
        /// Gets the deaths.
        /// </summary>
        /// <value>
        /// The deaths.
        /// </value>
        int Deaths { get; }
        /// <summary>
        /// Gets the assists.
        /// </summary>
        /// <value>
        /// The assists.
        /// </value>
        int Assists { get; }
    }
}
