using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace Game.Snake
{
    public partial class Form1 : Form
    {
        private const int CellSize = 30;
        private const int GameFieldSize = 450;
        private const int GameFieldSizeInCells = 15;
        private readonly Random random = new Random();

        private readonly List<Rectangle> snake = new List<Rectangle>();
        private Direction direction;
        private Rectangle food;
        public Form1()
        {
            InitializeComponent();
            Restart();
            gameFieldPictureBox.Paint += GameFieldPictureBoxOnPaint;
        }

        //Установка начальных параметров игры
        private void Restart()
        {
            direction = Direction.Right;
            if (snake.Count > 1) snake.Clear();
            snake.Add(GetRandomEmptyCell());
            food = GetRandomEmptyCell();
        }

        //Отрисовка игрового поля
        private void GameFieldPictureBoxOnPaint(object sender, PaintEventArgs paintEventArgs)
        {
            var exeDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var imgDir = Path.Combine(exeDir, "Images");

            Graphics graphics = paintEventArgs.Graphics;

            //Рисуем клетки
            for (int i = CellSize; i < GameFieldSize; i += CellSize)
            {
                graphics.DrawLine(Pens.Gray, 0, i, GameFieldSize, i);
                graphics.DrawLine(Pens.Gray, i, 0, i, GameFieldSize);
            }

            //Рисуем змейку
            for (int i = 0; i < snake.Count; i++)
            {
                if(snake.Count == 1)
                {
                    Image snakeImage = Image.FromFile(Path.Combine(imgDir, "snake_right.png"));
                    TextureBrush tBrushSnake = new TextureBrush(snakeImage);
                    tBrushSnake.Transform = new Matrix(
                    30.0f / 225.0f,
                    0.0f,
                    0.0f,
                    30.0f / 225.0f,
                    0.0f,
                    0.0f);
                    graphics.FillRectangle(tBrushSnake, GetRandomEmptyCell());
                }
                else { graphics.FillRectangle(Brushes.DarkGreen, snake[i]); }
                
            }

            //Рисуем еду 
            Image foodImage = Image.FromFile(Path.Combine(imgDir, "apple.jpg"));
            TextureBrush tBrush = new TextureBrush(foodImage);
            tBrush.Transform = new Matrix(
            30.0f / 211.0f,
            0.0f,
            0.0f,
            30.0f / 239.0f,
            0.0f,
            0.0f);
            graphics.FillRectangle(tBrush, GetRandomEmptyCell());
        }

        //Возвращает случайную клетку поля
        Rectangle GetRandomEmptyCell()
        {
            List<Rectangle> emptyCells = new List<Rectangle>();
            for (int i = 0; i < GameFieldSizeInCells; i++)
            {
                for (int j = 0; j < GameFieldSizeInCells; j++)
                {
                    Rectangle emptyCell = new Rectangle(i*CellSize, j*CellSize, CellSize, CellSize);
                    if (!snake.Contains(emptyCell))
                        emptyCells.Add(emptyCell);
                }
            }
            return emptyCells[random.Next(0,emptyCells.Count - 1)];
        }
    }
}
