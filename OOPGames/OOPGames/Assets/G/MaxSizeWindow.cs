using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq; 
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static OOPGames.TicTacToePaint_G;

namespace OOPGames.Assets.G
{
    public partial class MaxSizeWindow : Form
    {
        private bool flag = true;
        public MaxSizeWindow()
        {
            InitializeComponent();
        }

        private void MaxSize_Load(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            textBox1.Text = trackBar1.Value.ToString();
        }

        private void Apply_Click(object sender, EventArgs e)
        {
            MaxSize = Int32.Parse(textBox1.Text);
            this.Close();
            flag = false;
        }

        private void NoInputHelp(object sender, EventArgs e)
        {
            Delay(20, (o, a) => NoInput());

        }
        
        private void NoInput()
        {
            if (flag)
            {
                noinput noinput = new noinput();
                noinput.Show();
            }
        }

        static void Delay(int ms, EventHandler action)
        {
            var tmp = new Timer { Interval = ms };
            tmp.Tick += new EventHandler((o, e) => tmp.Enabled = false);
            tmp.Tick += action;
            tmp.Enabled = true;
        }

    }
}
