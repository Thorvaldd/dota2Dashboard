﻿using DotaBuffWrapper.Model.Yasp.Interfaces;

namespace DotaBuffWrapper.Model.Yasp
{
    internal class WordCloud : IWordCloud
    {
        public string Word { get; internal set; }

        public int Count { get; internal set; }

        public override string ToString()
        {
            return string.Format("{0}: {1}", Word, Count);
        }
    }
}
