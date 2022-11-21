using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;

namespace OOPGames
{
    public class PlayerD { 

        public class TicTacToeHumanPlayerD : IHumanTicTacToePlayer
        {
            int _PlayerNumber = 0;
            public string Name { get { return "DerKrasseHumanTicTacToePlayer"; } }

            public int PlayerNumber { get { return _PlayerNumber; } }

            public bool CanBeRuledBy(IGameRules rules)
            {
                return rules is ITicTacToeRules;
            }

            public IGamePlayer Clone()
            {
                TicTacToeHumanPlayerD ttthp = new TicTacToeHumanPlayerD();
                ttthp.SetPlayerNumber(_PlayerNumber);
                return ttthp;
            }

            public ITicTacToeMove GetMove(IMoveSelection selection, ITicTacToeField field)
            {
                if (selection is IClickSelection)
                {
                   IClickSelection click = (IClickSelection) selection;
             
                    for (int r=0; r<3; r++)
                    {
                        for (int c=0; c<3; c++)
                        {
                            if (click.XClickPos > 50 + (r*100) && click.XClickPos < 150 + (r*100) &&
                                click.YClickPos > 50 + (c*100) && click.YClickPos < 150 + (c*100) &&
                                field[c, r] <= 0)
                            {
                                return new TicTacToeMove(c, r, _PlayerNumber);
                            }
                        }
                    }
                }
                return null;

            }

            public IPlayMove GetMove(IMoveSelection selection, IGameField field)
            {
                if (field is ITicTacToeField)
                {
                    return GetMove(selection, (ITicTacToeField)field);
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

    public class TicTacToeComputerPlayerD : IComputerTicTacToePlayer
        {
            int _PlayerNumber = 0;
            public string Name { get { return "DerKrasseComputerTicTacToePlayer"; } }

            public int PlayerNumber { get { return _PlayerNumber; } }

            public bool CanBeRuledBy(IGameRules rules)
            {
                return rules is ITicTacToeRules;
            }

            public IGamePlayer Clone()
            {
                TicTacToeComputerPlayerD ttthp = new TicTacToeComputerPlayerD();
                ttthp.SetPlayerNumber(_PlayerNumber);
                return ttthp;
            }

            public ITicTacToeMove GetMove(ITicTacToeField field)        //Wird diese Methode beim Klicken aufgerufen? Ja
            {

                int A = 0;//verindern
                int B = 0;//selber 3 voll machen

                if (_PlayerNumber == 1)
                {
                    A = 2;
                    B = 1;
                }
                else
                {
                    A = 1;
                    B = 2;
                }

                //Zeile
                for (int r=0; r<=2; r++)
                {
                    int c=0;
                    
                    if (field[r, c] == A && field[r, c+1] == A && field[r, c+2] == 0)
                    {
                        return new TicTacToeMove(r, 2, _PlayerNumber);    
                    }
                    if (field[r, c] == A && field[r, c + 2] == A && field[r, c + 1] == 0)
                    {
                        return new TicTacToeMove(r, 1, _PlayerNumber);
                    }
                    if (field[r, c] == 0 && field[r, c + 1] == A && field[r, c + 2] == A)
                    {
                        return new TicTacToeMove(r, 0, _PlayerNumber);     
                    }
                }

                //Spalte
                for (int c = 0; c <= 2; c++)
                {
                    int r = 0;
                    
                    if (field[r, c] == A && field[r+1, c] == A && field[r+2, c] == 0)
                    {
                        return new TicTacToeMove(2, c, _PlayerNumber);
                    }
                    if (field[r, c] == A && field[r+2, c] == A && field[r+1, c] == 0)
                    {
                        return new TicTacToeMove(1, c, _PlayerNumber);
                    }
                    if (field[r, c] == 0 && field[r+1, c] == A && field[r+2, c] == A)
                    {
                        return new TicTacToeMove(0, c, _PlayerNumber);
                    }
                }

                //diagonal

                for (int rc = 0; rc <= 2; rc++)
                {
                    if (field[rc, rc] == A && field[rc+1, rc+1] == A && field[rc+2, rc+2] == 0)
                    {
                        return new TicTacToeMove(rc+2, rc+2, _PlayerNumber);
                    }
                    if (field[rc, rc] == A && field[rc+2, rc+2] == A && field[rc+1, rc+1] == 0)
                    {
                        return new TicTacToeMove(rc+1, rc+1, _PlayerNumber);
                    }
                    if (field[rc, rc] == 0 && field[rc+1, rc+1] == A && field[rc+2, rc+2] == A)
                    {
                        return new TicTacToeMove(rc, rc, _PlayerNumber);
                    }
                }

                for (int r=0; r<=2; r++)
                {
                    for (int c=2; c>=0; c--)
                    {
                        if (field[r, c] == A && field[r+1, c - 1] == A && field[r + 2, c - 2] == 0)
                        {
                            return new TicTacToeMove(2, 0, _PlayerNumber);
                        }
                        if (field[r, c] == A && field[r + 2, c - 2] == A && field[r + 1, c - 1] == 0)
                        {
                            return new TicTacToeMove(r + 1, c - 1, _PlayerNumber);
                        }
                        if (field[r, c] == 0 && field[r + 1, c - 1] == A && field[r + 2, c - 2] == A)
                        {
                            return new TicTacToeMove(r, c, _PlayerNumber);
                        }
                    }
                }

                // selber reihe voll machen
                for (int r=0; r<=2; r++)
                {
                    int c = 0;

                    if (field[r, c] == B && field[r + 1, c] == B && field[r + 2, c] == 0)
                    {
                        return new TicTacToeMove(2, c, _PlayerNumber);
                    }
                    if (field[r, c] == B && field[r + 2, c] == B && field[r + 1, c] == 0)
                    {
                        return new TicTacToeMove(1, c, _PlayerNumber);
                    }
                    if (field[r, c] == 0 && field[r + 1, c] == B && field[r + 2, c] == B)
                    {
                        return new TicTacToeMove(0, c, _PlayerNumber);
                    }
                }

                for (int c = 0; c <= 2; c++)
                {
                    int r = 0;

                    if (field[r, c] == B && field[r + 1, c] == B && field[r + 2, c] == 0)
                    {
                        return new TicTacToeMove(2, c, _PlayerNumber);
                    }
                    if (field[r, c] == B && field[r + 2, c] == B && field[r + 1, c] == 0)
                    {
                        return new TicTacToeMove(1, c, _PlayerNumber);
                    }
                    if (field[r, c] == 0 && field[r + 1, c] == B && field[r + 2, c] == B)
                    {
                        return new TicTacToeMove(0, c, _PlayerNumber);
                    }
                }

                for (int rc = 0; rc <= 2; rc++)
                {
                    if (field[rc, rc] == B && field[rc + 1, rc + 1] == B && field[rc + 2, rc + 2] == 0)
                    {
                        return new TicTacToeMove(rc + 2, rc + 2, _PlayerNumber);
                    }
                    if (field[rc, rc] == B && field[rc + 2, rc + 2] == B && field[rc + 1, rc + 1] == 0)
                    {
                        return new TicTacToeMove(rc + 1, rc + 1, _PlayerNumber);
                    }
                    if (field[rc, rc] == 0 && field[rc + 1, rc + 1] == B && field[rc + 2, rc + 2] == B)
                    {
                        return new TicTacToeMove(rc, rc, _PlayerNumber);
                    }
                }

                for (int r = 0; r <= 2; r++)
                {
                    for (int c = 2; c >= 0; c--)
                    {
                        if (field[r, c] == B && field[r + 1, c - 1] == B && field[r + 2, c - 2] == 0)
                        {
                            return new TicTacToeMove(2, 0, _PlayerNumber);
                        }
                        if (field[r, c] == B && field[r + 2, c - 2] == B && field[r + 1, c - 1] == 0)
                        {
                            return new TicTacToeMove(r + 1, c - 1, _PlayerNumber);
                        }
                        if (field[r, c] == 0 && field[r + 1, c - 1] == B && field[r + 2, c - 2] == B)
                        {
                            return new TicTacToeMove(r, c, _PlayerNumber);
                        }
                    }
                }

                Random rand = new Random();
                int f = rand.Next(0, 8);
                for (int i = 0; i < 9; i++)                             
                {
                    int c = f % 3;                                     
                    int r = ((f - c) / 3) % 3;                            
                    if (field[r, c] <= 0)
                    {
                        return new TicTacToeMove(r, c, _PlayerNumber);      
                    }
                    else
                    {
                        f++;                                                   
                    }
                }

                return null; //???????????????????? 

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
}


//Versuch

/*
if ((field[0, 1] + field[1, 1] + field[2, 1]) == Anzahl && field[0, 1] > 0 && field[1, 1] > 0)
{
    for (int r = 0; r <= 2; r++)
    {
        if (field[r, 1] <= 0)
        {
            return new TicTacToeMove(r, 1, _PlayerNumber);
        }

    }
}

if ((field[0, 0] + field[1, 0] + field[2, 0]) == Anzahl)
{
    for (int r = 0; r <= 2; r++)
    {
        if (field[r, 0] <= 0)
        {
            return new TicTacToeMove(r, 0, _PlayerNumber);

        }

    }
}

if ((field[0, 2] + field[1, 2] + field[2, 2]) == Anzahl)
{
    for (int r = 0; r <= 2; r++)
    {
        if (field[r, 2] <= 0)
        {
            return new TicTacToeMove(r, 2, _PlayerNumber);
        }

    }
}


//Reihen

if ((field[1, 0] + field[1, 1] + field[1, 2]) == Anzahl)
{
    for (int c = 0; c <= 2; c++)
    {
        if (field[1, c] <= 0)
        {
            return new TicTacToeMove(1, c, _PlayerNumber);
        }

    }
}

if ((field[0, 0] + field[0, 1] + field[0, 2]) == Anzahl)
{
    for (int c = 0; c <= 2; c++)
    {
        if (field[0, c] <= 0)
        {
            return new TicTacToeMove(0, c, _PlayerNumber);
        }

    }
}



if ((field[2, 0] + field[2, 1] + field[2, 2]) == Anzahl)
{
    for (int c = 0; c <= 2; c++)
    {
        if (field[2, c] <= 0)
        {
            return new TicTacToeMove(2, c, _PlayerNumber);
        }

    }
}

//diagonal

if ((field[0, 0] + field[1, 1] + field[2, 2]) == Anzahl)
{
    for (int rc = 0; rc <= 2; rc++)
    {
        if (field[rc, rc] <= 0)
        {
            return new TicTacToeMove(rc, rc, _PlayerNumber);
        }

    }
}

if ((field[0, 2] + field[1, 1] + field[2, 0]) == Anzahl)
{
    if (field[0, 2] <= 0)
    {
        return new TicTacToeMove(0, 2, _PlayerNumber);
    }
    if (field[1, 1] <= 0) 
    {
        return new TicTacToeMove(1, 1, _PlayerNumber);
    }
    if (field[2, 0] <= 0)
    {
        return new TicTacToeMove(2, 0, _PlayerNumber);
    }

}

else
{
    Random rand = new Random();
    int f = rand.Next(0, 8);
    for (int i = 0; i < 9; i++)                             //9 Felder durchitterieren
    {
        int c = f % 3;                                      //umrechnen der Zahlen 1:9 auf Spalten c
        int r = ((f - c) / 3) % 3;                             //Reihe voll dann nächste Reihe
        if (field[r, c] <= 0)
        {
            return new TicTacToeMove(r, c, _PlayerNumber);       //Wenn Feld noch frei ist
        }
        else
        {
            f++;                                                   //sonst f nur um 1 erhöhen und nochmal probieren
        }
    }
}
return null;
*/ 
