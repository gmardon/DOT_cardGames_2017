namespace Poker.Core.GameMechanics
{
    using Poker.Core.Players;

    public interface ITexasHoldemGame
    {
        int HandsPlayed { get; }

        IPlayer Start();
    }
}
