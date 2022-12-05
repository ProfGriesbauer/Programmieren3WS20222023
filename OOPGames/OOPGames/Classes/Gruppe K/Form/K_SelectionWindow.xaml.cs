using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace OOPGames.Classes.Gruppe_K.Form
{
    /// <summary>
    /// Interaktionslogik für K_SelectionWindow.xaml
    /// </summary>
    public partial class K_SelectionWindow : Window
    {
        bool _selectionPerformed = false;
        public bool selectionPerformed { get { return _selectionPerformed; }}
        public K_SelectionWindow()
        {
            InitializeComponent();
        }

        private void GK_Selection(object sender, RoutedEventArgs e)
        {
            _selectionPerformed = true;
            this.Close();

        }

    }
}
