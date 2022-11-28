using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using static System.Windows.Application;


namespace OOPGames.Classes.GruppeJ
{
    public class Dino_Game
    {
        public static void StartDinoGame()
        {
            //Dino_Form test = new Dino_Form(); 
            //test.ShowDialog();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //startet die Form
            Application.Run(new Dino_Form());
            
        }
    }   
}
