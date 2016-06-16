namespace DotaBuffWrapper.Model.Dotabuff.Interfaces
{
    public interface IDamage
    {
        /// <summary>
        /// Gets the minimum damage output.
        /// </summary>
        /// <value>
        /// The minimum damage output.
        /// </value>
        int Minimum { get; }
        /// <summary>
        /// Gets the maximum damage output.
        /// </summary>
        /// <value>
        /// The maximum damage output.
        /// </value>
        int Maximum { get; }
    }
}
