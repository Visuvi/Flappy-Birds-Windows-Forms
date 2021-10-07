using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Flappy_Birds
{
    public partial class Form1 : Form
    {

        int pipeSpeed = 7;
        int gravity = 10;
        int score = 0;
        int scoreSpeed = 3;
       
        



        public Form1()
        {
            InitializeComponent();
        }

        private void GameTimeEvent(object sender, EventArgs e)
        {
            flappyBird.Top += gravity;
            pipeBottom.Left -= pipeSpeed;
            pipeTop.Left -= pipeSpeed;
            scoreText.Text = "Score: " + score;

            if (pipeBottom.Left < -150)
            {
                pipeBottom.Left = 800;
                score++;
            }
            if (pipeTop.Left < -180)
            {
                pipeTop.Left = 950;
                score++;
            }
            if (flappyBird.Bounds.IntersectsWith(pipeBottom.Bounds) || 
                flappyBird.Bounds.IntersectsWith(pipeTop.Bounds) ||
                flappyBird.Bounds.IntersectsWith(ground.Bounds) || flappyBird.Top < -20
                )
            {
                EndGame(endGamePic);
            }

            if (score > scoreSpeed)
            {
                pipeSpeed = pipeSpeed + 7;
                scoreSpeed = scoreSpeed + 6;
            }
                
        }

        private void Gamekeyisdown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Space)
            {
                gravity = -10;
            }
            if (e.KeyCode == Keys.R)
            {
                Application.Restart();
               
            }
        } 

        private void Gamekeyisup(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                gravity = 10;
            }
        }
        private void EndGame(PictureBox pictureBox)
        {
            gameTimer.Stop();
            scoreText.Text += " Game Over!";
            pictureBox.Show();

        }


    }
}
