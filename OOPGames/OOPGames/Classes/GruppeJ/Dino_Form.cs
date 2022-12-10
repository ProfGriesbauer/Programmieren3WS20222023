using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOPGames.Classes.GruppeJ
{
    public partial class Dino_Form : Form
    {
        bool jumping = false;
        int jumpSpeed;
        int force = 12;
        int GameScore=0;
        int obstacleSpeed = 10;
        Random rand =new Random();
        int position;
        bool isGameOver = false;

        public  Dino_Form()
        {
            InitializeComponent();

            Reset();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void TimerEvent(object sender, EventArgs e)
        {
            Dino.Top+= jumpSpeed;

            txtScore.Text = "Score: " + GameScore;
            if (jumping == true && force < 0)
            {
                jumping = false;   
            }
            if(jumping == true)
            {
                jumpSpeed = -12;
                force -= 1;
            }
            else
            {
                jumpSpeed = 12;
            }
             if(Dino.Top > 364 && jumping == false)
            {
                force = 12;
                Dino.Top = 365;
                jumpSpeed = 0;
            }
             foreach(Control x in this.Controls)
            {
                if(x is PictureBox && (string)x.Tag == "Kaktus")
                {
                    x.Left -= obstacleSpeed;
                    if(x.Left<100)
                    {
                        x.Left = this.ClientSize.Width + rand.Next(200, 500) + (x.Width * 25);
                        GameScore++;
                    }
                    if (Dino.Bounds.IntersectsWith(x.Bounds))
                    {
                        timer.Stop();
                        Dino.Image = Properties.Resources.dead;
                        txtScore.Text += "\nPress R to restart the game!";
                        isGameOver = true;  

                    }
                }
            }
             if(GameScore > 10)
            {
                obstacleSpeed++;
            }

        }

        private void keyisdown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space && jumping== false)
            {
                jumping = true;
            }
        }
        private void keyisup(object sender, KeyEventArgs e)
        {
            if (jumping == true)
            {
                jumping = false;
            }
            if (e.KeyCode == Keys.R && isGameOver == true)
            {
                Reset();
            }
        }
        private void Reset()
        {
            timer.Start();
            force = 12;
            jumpSpeed = 0;
            jumping = false;
            GameScore = 0;
            obstacleSpeed = 10;
            txtScore.Text = "Score: " + GameScore;
            Dino.Image = Properties.Resources.running;
            isGameOver = false;
            Dino.Top = 365;

            foreach(Control x in this.Controls)
            {
                if (x is PictureBox && (string)x.Tag == "Kaktus")
                {
                    position = this.ClientSize.Width + rand.Next(500, 800) + (x.Width * 10);
                    x.Left = position;
                }
            }
        }

        private void txtScore_Click(object sender, EventArgs e)
        {

        }

        private void Dino_Form_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }
    }
}
