using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xaml;

namespace OOPGames.Classes.GruppeI
{
    public class Human_PlayerI : IHumanTicTacToePlayer
    {
        int _PlayerNumber = 0;

        public string Name { get { return "Human_TTT-Player_I"; } }

        public int PlayerNumber { get { return _PlayerNumber; } }

        public IGamePlayer Clone()
        {
            Human_PlayerI ttthp = new Human_PlayerI();
            ttthp.SetPlayerNumber(_PlayerNumber);

            return ttthp;
        }


        public ITicTacToeMove GetMove(IMoveSelection selection, ITicTacToeField field)
        {
            int f = 0;
            int px = 0;
            int py = 0;
            if (selection is IClickSelection)
            {
                IClickSelection sel = (IClickSelection)selection;

                IBigTicTacToeField bigfield = null;
                if (field is IBigTicTacToeField)
                {
                    bigfield = (IBigTicTacToeField)field;

                    if (sel.XClickPos > bigfield.SubFields[0].X && sel.XClickPos < (bigfield.SubFields[0].X + bigfield.SubFields[0].SX) && sel.YClickPos > bigfield.SubFields[0].Y && sel.YClickPos < (bigfield.SubFields[0].Y + bigfield.SubFields[0].SY)) { f = 0; px = 0; py = 0; }
                    if (sel.XClickPos > bigfield.SubFields[1].X && sel.XClickPos < (bigfield.SubFields[1].X + bigfield.SubFields[1].SX) && sel.YClickPos > bigfield.SubFields[1].Y && sel.YClickPos < (bigfield.SubFields[1].Y + bigfield.SubFields[1].SY)) { f = 1; px = 180; py = 0; }
                    if (sel.XClickPos > bigfield.SubFields[2].X && sel.XClickPos < (bigfield.SubFields[2].X + bigfield.SubFields[2].SX) && sel.YClickPos > bigfield.SubFields[2].Y && sel.YClickPos < (bigfield.SubFields[2].Y + bigfield.SubFields[2].SY)) { f = 2; px = 360; py = 0; }
                    if (sel.XClickPos > bigfield.SubFields[3].X && sel.XClickPos < (bigfield.SubFields[3].X + bigfield.SubFields[3].SX) && sel.YClickPos > bigfield.SubFields[3].Y && sel.YClickPos < (bigfield.SubFields[3].Y + bigfield.SubFields[3].SY)) { f = 3; px = 0; py = 180; }
                    if (sel.XClickPos > bigfield.SubFields[4].X && sel.XClickPos < (bigfield.SubFields[4].X + bigfield.SubFields[4].SX) && sel.YClickPos > bigfield.SubFields[4].Y && sel.YClickPos < (bigfield.SubFields[4].Y + bigfield.SubFields[4].SY)) { f = 4; px = 180; py = 180; }
                    if (sel.XClickPos > bigfield.SubFields[5].X && sel.XClickPos < (bigfield.SubFields[5].X + bigfield.SubFields[5].SX) && sel.YClickPos > bigfield.SubFields[5].Y && sel.YClickPos < (bigfield.SubFields[5].Y + bigfield.SubFields[5].SY)) { f = 5; px = 360; py = 180; }
                    if (sel.XClickPos > bigfield.SubFields[6].X && sel.XClickPos < (bigfield.SubFields[6].X + bigfield.SubFields[6].SX) && sel.YClickPos > bigfield.SubFields[6].Y && sel.YClickPos < (bigfield.SubFields[6].Y + bigfield.SubFields[6].SY)) { f = 6; px = 0; py = 360; }
                    if (sel.XClickPos > bigfield.SubFields[7].X && sel.XClickPos < (bigfield.SubFields[7].X + bigfield.SubFields[7].SX) && sel.YClickPos > bigfield.SubFields[7].Y && sel.YClickPos < (bigfield.SubFields[7].Y + bigfield.SubFields[7].SY)) { f = 7; px = 180; py = 360; }
                    if (sel.XClickPos > bigfield.SubFields[8].X && sel.XClickPos < (bigfield.SubFields[8].X + bigfield.SubFields[8].SX) && sel.YClickPos > bigfield.SubFields[8].Y && sel.YClickPos < (bigfield.SubFields[8].Y + bigfield.SubFields[8].SY)) { f = 8; px = 360; py = 360; }

                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            if (sel.XClickPos > 20 + px + (j * 60) && sel.XClickPos < 80 + px + (j * 60) &&
                                sel.YClickPos > 20 + py + (i * 60) && sel.YClickPos < 80 + py + (i * 60) &&
                                bigfield.SubFields[f][i, j] <= 0 &&
                                bigfield.SubFields[f].WonByPlayer == 0 && bigfield.SubFields[f].Active == true)
                            {
                                for (int a = 0; a < 9; a++)
                                {
                                    bigfield.SubFields[a].Active = false;
                                }
                                bigfield.SubFields[f].Active = true;

                                return new TicTacToeMove_I(f, i, j, _PlayerNumber);
                            }
                        }
                    }
                }



            }

            return null;





        }

        public void SetPlayerNumber(int playerNumber)
        {
            _PlayerNumber = playerNumber;
        }

        public bool CanBeRuledBy(IGameRules rules)
        {
            return rules is IGameRules; //Umgeschrieben
        }

        IPlayMove IHumanGamePlayer.GetMove(IMoveSelection selection, IGameField field)
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
    }
}
