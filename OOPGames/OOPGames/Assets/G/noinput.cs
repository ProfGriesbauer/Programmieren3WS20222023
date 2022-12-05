using System;
using System.Collections.Generic; 
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOPGames.Assets.G
{
    public partial class noinput : Form
    {
        public noinput()
        {
            InitializeComponent();
        }

        private void validated(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
