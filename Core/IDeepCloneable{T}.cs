namespace Poker.Core
{
    public interface IDeepCloneable<out T>
    {
        T DeepClone();
    }
}
