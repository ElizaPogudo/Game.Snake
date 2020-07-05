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

            gameFieldPictureBox.Paint += GameFieldPictureBoxOnPaint;
            KeyDown += OnKeyDown;

            timer.Interval = 300; // ms
            timer.Start();
            timer.Tick += TimerOnTick;
        }

        private void TimerOnTick(object sender, EventArgs eventArgs)
        {
            game.Move(out bool gameOver);
            if (!gameOver)
            {
                snakeLength.Text = game.SnakeLength.ToString();
                score.Text = (game.SnakeLength - 1).ToString();
                gameFieldPictureBox.Refresh();
            }
            else
            {
                timer.Stop();
                MessageBox.Show($"Игра закончена!\nДлина змейки равна {game.SnakeLength}");
                game.Restart();
                timer.Start();
            }
            
        }

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
