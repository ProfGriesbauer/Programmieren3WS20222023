using OOPGames;
using OOPGames.Interfaces.Gruppe_H;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OOPGames
{
    //########### MOVE #############//
    public class H_TicTacToeMove : I_H_TicTacToeMove
    {
        int _Row = 0;
        int _Column = 0;
        int _PlayerNumber = 0;

        public H_TicTacToeMove(int row, int column, int playerNumber)
        {
            _Row = row;
            _Column = column;
            _PlayerNumber = playerNumber;
        }

        public int Row { get { return _Row; } }
        public int Column { get { return _Column; } }
        public int PlayerNumber { get { return _PlayerNumber; } }
    }

    //############# FELD ##############//
    public class HFeld : IHFeld
    {
        //(Objekte für Schnecke/X/O sollen existieren ung bei Abfrage zurückgegeben werden.-->Falsch?)
        //Hier wird festgelegt, was der Painter zeichnen soll, es wird weg gegengen werden von dem Field mit 0/1/2 als Auswahl???
        int _player;
        Image _symbol;
        public int Player   // Auswertung welcher Player gerade den Move macht
        {
            get
            {
                return _player;
            }
            set
            {
                _player = value;
            }
        }
        public Image Symbol
        {
            get  
            {
                return _symbol;
            }
            set        
            {
                _symbol = value;
            }
        }
    }

    public class H_TicTacToeField : I_H_TicTacToe
    {
        IHFeld[,] _Feld = new IHFeld[3, 3];                     //Leitet von kommentar darüber ab erstellt ein 3x3 Feld, das in jedem Feld IH Feld haben muss????
        public H_TicTacToeField()                               //in jedes Feld des 3x3Spielfelds wird HFeld eingefügt, darin sind dann alle Symbole der Spieler enthalten.?
        {
            int r, c;
            for (r = 0; r < 3; r++)
            {
                for (c = 0; c < 3; c++)
                {
                    _Feld[r, c] = new HFeld();
                }
            }
        }

        public IHFeld this[int r, int c]
        {
            get
            {
                if (r >= 0 && r < 3 && c >= 0 && c < 3)
                {
                    return _Feld[r, c];
                }
                else
                {
                    return null;
                }
            }
            set
            {
                if (r >= 0 && r < 3 && c >= 0 && c > 3)
                {
                    _Feld[r, c] = value;
                }
            }
        }

        int I_H_TicTacToe.this[int r, int c]
        {
            get
            {
                if (r >= 0 && r < 3 && c >= 0 && c < 3)
                {
                    return _Feld[r, c].Player;
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                if (r >= 0 && r < 3 && c >= 0 && c > 3)
                {
                    _Feld[r, c].Player = value;
                }
            }
        }

        public bool CanBePaintedBy(IPaintGame painter)
        {
            return painter is I_H_PaintTicTacToe;
        }

        IHFeld I_H_TicTacToe.GetFeldAt(int r, int c)
        {
            return _Feld[r, c];
        }
    }
}