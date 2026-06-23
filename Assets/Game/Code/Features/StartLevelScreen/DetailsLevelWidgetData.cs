using System;
using System.Collections.Generic;

namespace Features.StartLevelScreen
{
    public class DetailsLevelWidgetData
    {
        public readonly IReadOnlyList<string> Tiers;
        public readonly int DefaultTier;
        
        public DetailsLevelWidgetData(int defaultIndex, params string[] tiers)
        {
            DefaultTier = defaultIndex;
            if (tiers.Length == 0 || defaultIndex < 0 || defaultIndex >= tiers.Length)
                throw new ArgumentOutOfRangeException(nameof(defaultIndex));
            Tiers = tiers;
        }
    }
}