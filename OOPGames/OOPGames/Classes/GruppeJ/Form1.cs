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
        public Color p1Color;
        public Color p2Color;
        public Form1()
        {
            this.DialogResult = DialogResult.Cancel;
            p1Color = Color.FromArgb(255, 255, 255);
            p2Color = Color.FromArgb(255, 255, 255);
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void buttonBlack_Click(object sender, EventArgs e)
        {
            i++;
            buttonSetsColor(Color.Black, i);
        }
        private void buttonRed_Click(object sender, EventArgs e)
        {
            i++;
            buttonSetsColor(Color.Red, i);
        }
        private void buttonBlue_Click(object sender, EventArgs e)
        {
            i++;
            buttonSetsColor(Color.Blue, i);
        }
        private void buttonYellow_Click(object sender, EventArgs e)
        {
            i++;
            buttonSetsColor(Color.Yellow, i);
        }
        private void buttonLime_Click(object sender, EventArgs e)
        {
            i++;
            buttonSetsColor(Color.Lime, i);
        }
        private void buttonFuchsia_Click(object sender, EventArgs e)
        {
            i++;
            buttonSetsColor(Color.Fuchsia, i);
        }
        private void buttonSetsColor(Color c, int player)
        {
            textBox1.Text = "Player2,\r\nwähle deine Farbe!";
            if (player == 1)
            {
                p1Color = c;
            }
            else
            {
                p2Color = c;
                this.DialogResult = DialogResult.OK;
                this.Hide();
                i = 0;
            }
        }
    }
}
