using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlappyBird
{
    public partial class Form1 : Form
    {
        int gravity = 10;
        int pipeSpeed = 6;
        int score = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Bird.Top += gravity;
            pipeTop.Left -= pipeSpeed;
            pipeBottom.Left -= pipeSpeed;
            Score.Text = $"Score: {score}"; 

            if(pipeTop.Left < -110)
            {
                pipeTop.Left = 500;
                score++;
            }

            if (pipeBottom.Left < -110)
            {
                pipeBottom.Left = 600;
                score++;
            }

            if (Bird.Top < -25)
            {
                gameOver();
            }

            if (Bird.Bounds.IntersectsWith(pipeTop.Bounds) || Bird.Bounds.IntersectsWith(pipeBottom.Bounds) || Bird.Bounds.IntersectsWith(ground.Bounds))
            {
                gameOver();
            }

           


        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Space)
            {
                gravity = -5;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Space)
            {
                gravity = 5;
            }
        }

        private void Bird_Click(object sender, EventArgs e)
        {

        }
        private void gameOver()
        {
            timer1.Stop();
            Score.Text = $"Game Over!";
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
