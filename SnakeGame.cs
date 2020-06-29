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
        private Image snakeImg;
        private Image snakeImgRight = Image.FromFile("Images/snake_right.png");
        private Image snakeImgUp = Image.FromFile("Images/snake_up.png");
        private Image snakeImgLeft = Image.FromFile("Images/snake_left.png");
        private Image snakeImgDown = Image.FromFile("Images/snake_down.png");
        private readonly Random random = new Random();

        private readonly List<Rectangle> snake = new List<Rectangle>();
        private Direction direction;
        private Rectangle food;
        private bool isPause;

        //Установка начальных параметров игры
        public void Restart()
        {
            direction = Direction.Right;
            snakeImg = snakeImgRight;
            snake.Clear();
            snake.Add(GetRandomEmptyCell());
            food = GetRandomEmptyCell();
            isPause = true;
        }

        //Отрисовка игрового поля
        public void Draw(Graphics graphics)
        {
            //Рисуем клетки
            for (int i = CellSize; i < GameFieldSize; i += CellSize)
            {
                graphics.DrawLine(Pens.Gray, 0, i, GameFieldSize, i);
                graphics.DrawLine(Pens.Gray, i, 0, i, GameFieldSize);
            }

            //Рисуем змейку
            graphics.DrawImage(snakeImg, snake[0]);
            for (int i = 1; i < snake.Count; i++)
            {
                graphics.FillRectangle(Brushes.Chartreuse, snake[i]);
            }

            //Рисуем еду 
            graphics.DrawImage(foodImg, food);
        }

        //Изменение направления движения змейки
        public void ChangeDirection(Keys key)
        {
            switch(key)
            {
                case Keys.Left:
                    if (snake.Count == 1 || direction != Direction.Right)
                    {
                        direction = Direction.Left;
                        snakeImg = snakeImgLeft;
                    }
                    break;
                case Keys.Up:
                    if (snake.Count == 1 || direction != Direction.Down)
                    {
                        direction = Direction.Up;
                        snakeImg = snakeImgUp;
                    }
                    break;
                case Keys.Right:
                    if (snake.Count == 1 || direction != Direction.Left)
                    {
                        direction = Direction.Right;
                        snakeImg = snakeImgRight;
                    }
                    break;
                case Keys.Down:
                    if (snake.Count == 1 || direction != Direction.Up)
                    {
                        direction = Direction.Down;
                        snakeImg = snakeImgDown;
                    }
                    break;
            }

            if (isPause)
            {
                isPause = false;
            }
        }

        //Движение змейки
        public void Move(out int snakeLength, out bool gameOver)
        {
            snakeLength = 1;
            gameOver = false;
            if (isPause)
                return;

            int snakeDeltaX = 0;
            int snakeDeltaY = 0;

            switch (direction)
            {
                case Direction.Right:
                    snakeDeltaX = CellSize;
                    snakeDeltaY = 0;
                    break;
                case Direction.Up:
                    snakeDeltaX = 0;
                    snakeDeltaY = -CellSize;
                    break;
                case Direction.Left:
                    snakeDeltaX = -CellSize;
                    snakeDeltaY = 0;
                    break;
                case Direction.Down:
                    snakeDeltaX = 0;
                    snakeDeltaY = CellSize;
                    break;
            }

            Rectangle nextHeadPosition = new Rectangle(
                snake[0].X + snakeDeltaX,
                snake[0].Y + snakeDeltaY,
                CellSize, CellSize);

            // Голова змейки всегда возникает на следующей клетке
            snake.Insert(0, nextHeadPosition);
            if (nextHeadPosition != food)
                snake.RemoveAt(snake.Count - 1);
            else food = GetRandomEmptyCell();

            if (GetOutOfTheField(snake[0].X, snake[0].Y) || EatMyself(snake[0].X, snake[0].Y))
            {
                isPause = true;
                gameOver = true;
            }
            snakeLength = snake.Count;
        }

        //Возвращает случайную клетку поля
        Rectangle GetRandomEmptyCell()
        {
            List<Rectangle> emptyCells = new List<Rectangle>();
            for (int i = 0; i < GameFieldSizeInCells; i++)
            {
                for (int j = 0; j < GameFieldSizeInCells; j++)
                {
                    Rectangle emptyCell = new Rectangle(i * CellSize, j * CellSize, CellSize, CellSize);
                    if (!snake.Contains(emptyCell))
                        emptyCells.Add(emptyCell);
                }
            }
            return emptyCells[random.Next(0, emptyCells.Count - 1)];
        }

        #region Проверки
        //Выход за границы поля
        bool GetOutOfTheField(int x, int y)
        {
            if (x > GameFieldSize - CellSize || y > GameFieldSize - CellSize || y < 0 || x < 0)
                return true;

            return false;
        }

        //Самосъедение
        bool EatMyself(int x, int y)
        {
            int count = snake.Count(snakeSegment => snakeSegment == snake[0]);
            return count > 1 && food != snake[0];
        }
        #endregion

    }
}
