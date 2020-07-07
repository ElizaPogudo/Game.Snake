using System;

namespace Game.Snake
{
    public enum Direction
    {
        Left,
        Right,
        Up,
        Down
    }

    public static class DirectionExtensions
    {
        public static Direction ToOppositeDirection(this Direction direction)
        {
            switch (direction)
            {
                case Direction.Left: return Direction.Right;
                case Direction.Right: return Direction.Left;
                case Direction.Up: return Direction.Down;
                case Direction.Down: return Direction.Up;
                default: throw new ArgumentOutOfRangeException(nameof(direction), direction, null);
            }
        }
    }
}
