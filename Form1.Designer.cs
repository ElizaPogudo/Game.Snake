namespace Game.Snake
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.gameFieldPictureBox = new System.Windows.Forms.PictureBox();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.snakeLength = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.score = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gameFieldPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // gameFieldPictureBox
            // 
            this.gameFieldPictureBox.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.gameFieldPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.gameFieldPictureBox.Location = new System.Drawing.Point(12, 12);
            this.gameFieldPictureBox.Name = "gameFieldPictureBox";
            this.gameFieldPictureBox.Size = new System.Drawing.Size(450, 450);
            this.gameFieldPictureBox.TabIndex = 0;
            this.gameFieldPictureBox.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(483, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Длина змейки:";
            // 
            // snakeLength
            // 
            this.snakeLength.AutoSize = true;
            this.snakeLength.Location = new System.Drawing.Point(573, 12);
            this.snakeLength.Name = "snakeLength";
            this.snakeLength.Size = new System.Drawing.Size(13, 13);
            this.snakeLength.TabIndex = 2;
            this.snakeLength.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(486, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Счёт:";
            // 
            // score
            // 
            this.score.AutoSize = true;
            this.score.Location = new System.Drawing.Point(526, 43);
            this.score.Name = "score";
            this.score.Size = new System.Drawing.Size(13, 13);
            this.score.TabIndex = 4;
            this.score.Text = "0";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(734, 542);
            this.Controls.Add(this.score);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.snakeLength);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gameFieldPictureBox);
            this.Name = "Form1";
            this.Text = "Игра \"Змейка\"";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnKeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.gameFieldPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox gameFieldPictureBox;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label snakeLength;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label score;
    }
}

