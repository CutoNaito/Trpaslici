namespace Trpaslici.Movement
{
    public interface IMovementStrategy
    {
        string[] Move(string[] input, string direction, string[] position);
    }
}
