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
        



        public Form1()
        {
            InitializeComponent();
        }

        private void gameTimeEvent(object sender, EventArgs e)
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
                endGame();
            }

            if (score > 3)
            {
                pipeSpeed = 14;    
            }
            if (score > 9)
            {
                pipeSpeed = 21;
            }
            if (score > 15)
            {
                pipeSpeed = 28;
            }
            if (score > 22)
            {
                pipeSpeed = 35;
            }
            if (score > 29)
            {
                pipeSpeed = 42;
            }
            if (score > 36)
            {
                pipeSpeed = 49;
            }
            if (score > 43)
            {
                pipeSpeed = 56;
            }
            if (score > 55)
                pipeSpeed = 65;                  
        }

        private void gamekeyisdown(object sender, KeyEventArgs e)
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

        private void gamekeyisup(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                gravity = 10;
            }
        }
        private void endGame()
        {
            gameTimer.Stop();
            scoreText.Text += " Game Over!!!!!";
            
        }
    }
}
