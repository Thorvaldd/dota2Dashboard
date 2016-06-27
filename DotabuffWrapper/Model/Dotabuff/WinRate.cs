﻿using DotaBuffWrapper.Model.Dotabuff.Interfaces;

namespace DotaBuffWrapper.Model.Dotabuff
{
    internal class WinRate : IWinRate
    {
        /// <summary>
        /// Gets the value of the win rate.
        /// </summary>
        /// <value>
        /// The value of the win rate.
        /// </value>
        public float Value { get; internal set; }

        internal WinRate(float value)
        {
            this.Value = value;
        }

        public override string ToString()
        {
            return Value + "%";
        }
    }
}
