﻿using DotaBuffWrapper.Model.Dotabuff.Interfaces;

namespace DotaBuffWrapper.Model.Dotabuff
{
    internal class Popularity : IPopularity
    {
        /// <summary>
        /// Gets the poularity value.
        /// </summary>
        /// <value>
        /// The poularity value.
        /// </value>
        public int Value { get; internal set; }

        internal Popularity(int value)
        {
            this.Value = value;
        }

        public override string ToString()
        {
            switch (Value)
            {
                case 1: return Value + "st";
                case 2: return Value + "nd";
                case 3: return Value + "rd";
                default: return Value + "th";
            }
        }
    }
}
