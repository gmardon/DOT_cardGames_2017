﻿namespace Poker.Core.AI.Helpers
{
    public enum CardValuationType
    {
        Unplayable = 0,
        NotRecommended = 1000,
        Risky = 2000,
        Recommended = 3000
    }
}