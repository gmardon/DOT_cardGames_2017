using Poker.Core.Players;

namespace Poker.Core.GameMechanics
{
    public interface ITexasHoldemGame
    {
        int HandsPlayed { get; }

        IPlayer Start();
    }
}
