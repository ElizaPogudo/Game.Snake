using System;
using System.Windows.Forms;

namespace Game.Snake
{
    public partial class Form1 : Form
    {
        private SnakeGame game = new SnakeGame();

        public Form1()
        {
            InitializeComponent();
            game.Restart();

            // Подписываемся на отрисовку
            gameFieldPictureBox.Paint += GameFieldPictureBoxOnPaint;

            // Подписываемся на нажатия клавиш
            KeyDown += OnKeyDown;

            // Настраиваем таймер
            timer.Interval = 300; // ms
            timer.Start();
            timer.Tick += TimerOnTick;
        }

        private void TimerOnTick(object sender, EventArgs eventArgs)
        {
            game.Move(out int snakeLengthVal, out bool gameOver);
            if (!gameOver)
            {
                snakeLength.Text = snakeLengthVal.ToString();
                score.Text = (snakeLengthVal - 1).ToString();
                gameFieldPictureBox.Refresh();
            }
            else
            {
                timer.Stop();
                MessageBox.Show(string.Format("Игра закончена!\nДлина змейки равна {0}", snakeLengthVal));
                game.Restart();
                timer.Start();
            }
            
        }

        //Отрисовка игрового поля
        private void GameFieldPictureBoxOnPaint(object sender, PaintEventArgs paintEventArgs)
        {
            game.Draw(paintEventArgs.Graphics);
        }

        private void OnKeyDown(object sender, KeyEventArgs keyEventArgs)
        {
            game.ChangeDirection(keyEventArgs.KeyCode);
        }
    }
}
