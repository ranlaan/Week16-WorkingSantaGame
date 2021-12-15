using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace santaGame
{
    public partial class Form1 : Form
    {
        int gravity = 10;
        int pipespeed = 6;
        int score = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            santa.Top += gravity;
            snowflake.Left -= pipespeed;
            tree.Left -= pipespeed;
            scorelabel.Text = $"score: {score}";

            if (snowflake.Left < -100)
            {
                snowflake.Left = 500;
                score++;
            }

            if (tree.Left < -100)
            {
                tree.Left = 600;
                score++;
            }

            if (santa.Top < -25)
            {
                gameOver();
            }

            if (santa.Bounds.IntersectsWith(snowflake.Bounds) || santa.Bounds.IntersectsWith(tree.Bounds) || santa.Bounds.IntersectsWith(ground.Bounds))
            {
                gameOver();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                gravity = -5;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                gravity = 5;
            }
        }

        private void santa_Click(object sender, EventArgs e)
        {

        }
        private void scorelabel_Click(object sender, EventArgs e)
        {

        }

        private void gameOver()
        {
            timer1.Stop();
            scorelabel.Text = $"Game Over";
            playagain.Visible = true;
        }

        private void playagain_Click(object sender, EventArgs e)
        {
            Form1 NewForm = new Form1();
            NewForm.Show();
            this.Dispose(false);
        }
    }    
}
