using System.Collections.Generic;
using Poker.Core.Cards;

namespace Poker.Core.Players
{
    public interface IEndHandContext
    {
        Dictionary<string, ICollection<Card>> ShowdownCards { get; }
    }
}