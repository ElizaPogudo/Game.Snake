namespace Game.Snake
{
    public enum Direction : byte
    {
        Left = 1,
        Right,
        Up,
        Down
    }

    public static class DirectionExtensions
    {
        public static bool IsOppositeDirection(this Direction curDirection, Direction nextDirection)
        {
            return (curDirection == Direction.Left & nextDirection == Direction.Right) ||
                (curDirection == Direction.Right & nextDirection == Direction.Left) ||
                (curDirection == Direction.Up & nextDirection == Direction.Down) ||
                (curDirection == Direction.Down & nextDirection == Direction.Up);
        }
    }
}
