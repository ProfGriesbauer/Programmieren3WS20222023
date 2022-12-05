using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
    public partial class K_InformationWindow : Window
    {

        public K_InformationWindow()
        {
            InitializeComponent();
        }

        public static void createInformationPopUp(String title, String text, bool blocksContext)
        {
            if (blocksContext)
            {

               internCreateInformationPopUp(title, text);
                
            } else
            {
                Thread informationPopUp = new Thread(() => internCreateInformationPopUp(title, text));
                informationPopUp.SetApartmentState(ApartmentState.STA);
                informationPopUp.Start();
   
            }
        }
      
        private static void internCreateInformationPopUp(String title, String text)
        {
            K_InformationWindow window = new K_InformationWindow();
            window.Title = title;
            window.label.Content = text;
            bool result= (bool)window.ShowDialog();
            while (result) ;
        }

    }
}
