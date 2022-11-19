using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOPGames.Classes.GruppeJ
{
    public partial class Form1 : Form
    {
        public  int i=0;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "Player2,\r\nwähle deine Farbe!";
            i++;
            if (i>1) { this.Hide(); i = 0; }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "Player2,\r\nwähle deine Farbe!";
            i++;
            if (i > 1) { this.Hide(); i = 0; }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = "Player2,\r\nwähle deine Farbe!";
            i++;
            if (i > 1) { this.Hide(); i = 0; }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = "Player2,\r\nwähle deine Farbe!";
            i++;
            if (i > 1) { this.Hide(); i = 0; }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text = "Player2,\r\nwähle deine Farbe!";
            i++;
            if (i > 1) { this.Hide(); i = 0; }
        }
        private void button6_Click(object sender, EventArgs e)
        {
            textBox1.Text = "Player2,\r\nwähle deine Farbe!";
            i++;
            if (i > 1) { this.Hide(); i = 0; }
        }
    }
}
