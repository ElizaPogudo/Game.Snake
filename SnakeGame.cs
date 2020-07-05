using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Game.Snake
{
    public class SnakeGame
    {
        private const int CellSize = 30;
        private const int GameFieldSize = 450;
        private const int GameFieldSizeInCells = 15;
        private Image foodImg = Image.FromFile("Images/apple.png");
        private Image snakeImgRight = Image.FromFile("Images/snake_right.png");
        private Image snakeImgUp = Image.FromFile("Images/snake_up.png");
        private Image snakeImgLeft = Image.FromFile("Images/snake_left.png");
        private Image snakeImgDown = Image.FromFile("Images/snake_down.png");
        private readonly Random random = new Random();

        private readonly List<Point> snake = new List<Point>();
        private Point snakeHead => snake[0];
        private Direction direction;
        private Point food;
        private bool isPause;

        public int SnakeLength => snake.Count;

        public void Restart()
        {
            direction = Direction.Right;
            snake.Clear();
            snake.Add(GetRandomEmptyCell());
            food = GetRandomEmptyCell();
            isPause = true;
        }

        public void Draw(Graphics graphics)
        {
            for (int i = 0; i < GameFieldSizeInCells; i++)
            {
                graphics.DrawLine(Pens.Gray, 0, i * CellSize, GameFieldSize, i * CellSize);
                graphics.DrawLine(Pens.Gray, i * CellSize, 0, i * CellSize, GameFieldSize);
            }

            graphics.DrawImage(GetSnakeImg(), new Rectangle(snakeHead.X * CellSize, snakeHead.Y * CellSize, CellSize, CellSize));

            for (int i = 1; i < snake.Count; i++)
            {
                graphics.FillRectangle(Brushes.Chartreuse, new Rectangle(snake[i].X * CellSize, snake[i].Y * CellSize, CellSize, CellSize));
            }

            graphics.DrawImage(foodImg, new Rectangle(food.X * CellSize, food.Y * CellSize, CellSize, CellSize));
        }

        public void ChangeDirection(Keys key)
        {
            switch(key)
            {
                case Keys.Left:
                    if (snake.Count == 1 || !direction.IsOppositeDirection(Direction.Left))
                        direction = Direction.Left;
                    break;
                case Keys.Up:
                    if (snake.Count == 1 || !direction.IsOppositeDirection(Direction.Up))
                        direction = Direction.Up;
                    break;
                case Keys.Right:
                    if (snake.Count == 1 || !direction.IsOppositeDirection(Direction.Right))
                        direction = Direction.Right;
                    break;
                case Keys.Down:
                    if (snake.Count == 1 || !direction.IsOppositeDirection(Direction.Down))
                        direction = Direction.Down;
                    break;
            }

            if (isPause)
            {
                isPause = false;
            }
        }

        public void Move(out bool gameOver)
        {
            gameOver = false;
            if (isPause)
                return;

            int snakeDeltaX = 0;
            int snakeDeltaY = 0;

            switch (direction)
            {
                case Direction.Right:
                    snakeDeltaX = 1;
                    snakeDeltaY = 0;
                    break;
                case Direction.Up:
                    snakeDeltaX = 0;
                    snakeDeltaY = -1;
                    break;
                case Direction.Left:
                    snakeDeltaX = -1;
                    snakeDeltaY = 0;
                    break;
                case Direction.Down:
                    snakeDeltaX = 0;
                    snakeDeltaY = 1;
                    break;
            }

            Point nextHeadPosition = new Point(snakeHead.X + snakeDeltaX, snakeHead.Y + snakeDeltaY);

            // Голова змейки всегда возникает на следующей клетке
            snake.Insert(0, nextHeadPosition);
            if (nextHeadPosition != food)
                snake.RemoveAt(snake.Count - 1);
            else food = GetRandomEmptyCell();

            if (IsPointOutsideField(snakeHead.X, snakeHead.Y) || IsSnakeEatItself())
            {
                isPause = true;
                gameOver = true;
            }
        }

        private Point GetRandomEmptyCell()
        {
            List<Point> emptyCells = new List<Point>();
            for (int i = 0; i < GameFieldSizeInCells; i++)
            {
                for (int j = 0; j < GameFieldSizeInCells; j++)
                {
                    Point emptyCell = new Point(i , j);
                    if (!snake.Contains(emptyCell))
                        emptyCells.Add(emptyCell);
                }
            }
            return emptyCells[random.Next(0, emptyCells.Count - 1)];
        }

        private Image GetSnakeImg()
        {
            switch (direction)
            {
                case Direction.Left:
                    return snakeImgLeft;
                case Direction.Up:
                    return snakeImgUp;
                case Direction.Down:
                    return snakeImgDown;
                default:
                    return snakeImgRight;
            }
        }

        #region Проверки
        private bool IsPointOutsideField(int x, int y)
        {
            return x > GameFieldSizeInCells - 1 || y > GameFieldSizeInCells - 1 || y < 0 || x < 0;
        }

        private bool IsSnakeEatItself()
        {
            return snake.Skip(1).Contains(snakeHead);
        }
        #endregion

    }
}
