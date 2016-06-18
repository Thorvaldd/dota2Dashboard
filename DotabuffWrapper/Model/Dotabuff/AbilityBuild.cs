using System.Collections.Generic;
using System.Linq;
using DotabuffWrapper.Model.Dotabuff.Interfaces;

namespace DotabuffWrapper.Model.Dotabuff
{
    public class AbilityBuild
    {
        /// <summary>
        /// Gets the ability.
        /// </summary>
        /// <value>
        /// The ability.
        /// </value>
        public IAbility Ability { get; internal set; }
        /// <summary>
        /// Gets the level build.
        /// </summary>
        /// <value>
        /// The level build.
        /// </value>
        public IEnumerable<int> LevelBuild { get; internal set; }

        public override string ToString()
        {
            string levelBuildString = Ability.ToString() + ": ";
            foreach (int level in LevelBuild)
            {
                levelBuildString += level + ", ";
            }

            return levelBuildString.Remove(levelBuildString.Count() - 2, 2);
        }
    }
}
