using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using OOPGames;



namespace OOPGames.Classes.Gruppe_K
{

    public class K_Computerplayer : IComputerTicTacToePlayer
    {
        int _PlayerNumber = 0;

        public string Name { get { return "K_ComputerTicTacToePlayer"; } }

        public int PlayerNumber { get { return _PlayerNumber; } }

        public bool CanBeRuledBy(IGameRules rules)
        {
            return rules is ITicTacToeRules;
        }
        public IGamePlayer Clone()
        {
            K_Computerplayer ttthp = new K_Computerplayer();
            ttthp.SetPlayerNumber(_PlayerNumber);
            return ttthp;
        }


        public ITicTacToeMove GetMove(ITicTacToeField field)
        {
            int _Gegner = 0;
            int _Selber = 0;

            if (_PlayerNumber == 1)
            {
                _Gegner = 2;
                _Selber = 1;
            }
            else
            {
                _Gegner = 1;
                _Selber = 2;
            }

            int l = 0;
            int s = 0;

            int eigencount = 0;
            int gegnercount = 0;

            int leerspalte = 0;

            //Versucht 3 in Zeilen vollzumachen

            for (l = 0; l <= 2; l++)
            {
                eigencount = 0;
                gegnercount = 0;
                leerspalte = 0;

                for (s = 0; s <= 2; s++)
                {
                    if (field[l, s] == _Selber)
                    {
                        eigencount++;
                    }
                    if (field[l, s] == _Gegner)
                    {
                        gegnercount++;
                    }
                    if (field[l, s] == 0)
                    {
                        leerspalte = s;
                    }
                }
                if (gegnercount == 0 && eigencount == 2)
                {
                    return new TicTacToeMove(l, leerspalte, _PlayerNumber);
                }
            }

            //Versucht 3 in Spalten vollzumachen

            int leerzeile = 0;

            for (s = 0; s <= 2; s++)
            {
                eigencount = 0;
                gegnercount = 0;
                leerzeile = 0;

                for (l = 0; l <= 2; l++)
                {
                    if (field[l, s] == _Selber)
                    {
                        eigencount++;
                    }
                    if (field[l, s] == _Gegner)
                    {
                        gegnercount++;
                    }
                    if (field[l, s] == 0)
                    {
                        leerzeile = l;
                    }
                }

                if (gegnercount == 0 && eigencount == 2)
                {
                    return new TicTacToeMove(leerzeile, s, _PlayerNumber);
                }
            }

            //Versucht 3 in Diagonale_1 vollzumachen (\)

            int w = 0;
            int leerwert = 0;
            eigencount = 0;
            gegnercount = 0;

            for (w = 0; w <= 2; w++)
            {
                if (field[w, w] == _Selber)
                {
                    eigencount++;
                }
                if (field[w, w] == _Gegner)
                {
                    gegnercount++;
                }
                if (field[w, w] == 0)
                {
                    leerwert = w;
                }
            }
            if (gegnercount == 0 && eigencount == 2)
            {
                return new TicTacToeMove(leerwert, leerwert, _PlayerNumber);
            }

            //Versucht 3 in Diagonale_2 vollzumachen (/)

            leerwert = 0;
            eigencount = 0;
            gegnercount = 0;

            for (w = 0; w <= 2; w++)
            {
                if (field[(2 - w), w] == _Selber)
                {
                    eigencount++;
                }
                if (field[(2 - w), w] == _Gegner)
                {
                    gegnercount++;
                }
                if (field[(2 - w), w] == 0)
                {
                    leerwert = w;
                }
            }
            if (gegnercount == 0 && eigencount == 2)
            {
                return new TicTacToeMove((2 - leerwert), leerwert, _PlayerNumber);
            }

            //Versucht 3 von Gegner in Zeile zu verhindern

            for (l = 0; l <= 2; l++)
            {
                eigencount = 0;
                gegnercount = 0;
                leerspalte = 0;

                for (s = 0; s <= 2; s++)
                {
                    if (field[l, s] == _Selber)
                    {
                        eigencount++;
                    }
                    if (field[l, s] == _Gegner)
                    {
                        gegnercount++;
                    }
                    if (field[l, s] == 0)
                    {
                        leerspalte = s;
                    }
                }
                if (gegnercount == 2 && eigencount == 0)
                {
                    return new TicTacToeMove(l, leerspalte, _PlayerNumber);
                }
            }

            //Versucht 3 von Gegner in Spalte zu verhindern

            for (s = 0; s <= 2; s++)
            {
                eigencount = 0;
                gegnercount = 0;
                leerzeile = 0;

                for (l = 0; l <= 2; l++)
                {
                    if (field[l, s] == _Selber)
                    {
                        eigencount++;
                    }
                    if (field[l, s] == _Gegner)
                    {
                        gegnercount++;
                    }
                    if (field[l, s] == 0)
                    {
                        leerzeile = l;
                    }
                }

                if (gegnercount == 2 && eigencount == 0)
                {
                    return new TicTacToeMove(leerzeile, s, _PlayerNumber);
                }
            }

            //Versucht 3 von Gegner in Diagonale_1 zu verhindern (\)

            leerwert = 0;
            eigencount = 0;
            gegnercount = 0;

            for (w = 0; w <= 2; w++)
            {
                if (field[w, w] == _Selber)
                {
                    eigencount++;
                }
                if (field[w, w] == _Gegner)
                {
                    gegnercount++;
                }
                if (field[w, w] == 0)
                {
                    leerwert = w;
                }
            }
            if (gegnercount == 2 && eigencount == 0)
            {
                return new TicTacToeMove(leerwert, leerwert, _PlayerNumber);
            }

            //Versucht 3 von Gegner in Diagonale_2 zu verhindern (/)

            leerwert = 0;
            eigencount = 0;
            gegnercount = 0;

            for (w = 0; w <= 2; w++)
            {
                if (field[(2 - w), w] == _Selber)
                {
                    eigencount++;
                }
                if (field[(2 - w), w] == _Gegner)
                {
                    gegnercount++;
                }
                if (field[(2 - w), w] == 0)
                {
                    leerwert = w;
                }
            }
            if (gegnercount == 2 && eigencount == 0)
            {
                return new TicTacToeMove((2 - leerwert), leerwert, _PlayerNumber);
            }


            if (field[1, 1] == 0)
            {
                return new TicTacToeMove(1, 1, _PlayerNumber);
            }


            //for (int i = 8; i >= 0; i--) 
            for (int i = 0; i < 9; i++)
            {
                int c = i % 3;
                int r = ((i - c) / 3) % 3;
                if (field[r, c] <= 0)
                {
                    return new TicTacToeMove(r, c, _PlayerNumber);
                }
            }

            return null;

        }

        public IPlayMove GetMove(IGameField field)
        {
            if (field is ITicTacToeField)
            {
                return GetMove((ITicTacToeField)field);
            }
            else
            {
                return null;
            }
        }

        public void SetPlayerNumber(int playerNumber)
        {
            _PlayerNumber = playerNumber;
        }

    }
}
