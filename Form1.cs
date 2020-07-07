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
            game.Defeat += Game_Defeat;

            timer.Interval = 300; // ms
            timer.Start();
            timer.Tick += TimerOnTick;
        }

        private void TimerOnTick(object sender, EventArgs eventArgs)
        {
            game.Move();
            snakeLength.Text = game.SnakeLength.ToString();
            score.Text = (game.SnakeLength - 1).ToString();
            gameFieldPictureBox.Refresh();
        }

        private void GameFieldPictureBoxOnPaint(object sender, PaintEventArgs paintEventArgs)
        {
            game.Draw(paintEventArgs.Graphics);
        }

        private void OnKeyDown(object sender, KeyEventArgs keyEventArgs)
        {
            switch (keyEventArgs.KeyCode)
            {
                case Keys.Up:
                    game.ChangeDirection(Direction.Up);
                    break;
                case Keys.Down:
                    game.ChangeDirection(Direction.Down);
                    break;
                case Keys.Left:
                    game.ChangeDirection(Direction.Left);
                    break;
                case Keys.Right:
                    game.ChangeDirection(Direction.Right);
                    break;
            }
        }
        private void Game_Defeat()
        {
            timer.Stop();
            MessageBox.Show($"Игра закончена!\nДлина змейки равна {game.SnakeLength}");
            game.Restart();
            timer.Start();
        }
    }
}
