using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xaml;

namespace OOPGames.Classes.GruppeI
{
    public class Human_PlayerI: IHumanTicTacToePlayer
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
                
                if (sel.XClickPos > 20 && sel.XClickPos < 200 && sel.YClickPos > 20 && sel.YClickPos < 200) { f = 0; px = 0; py = 0; }
                if (sel.XClickPos > 200 && sel.XClickPos < 380 && sel.YClickPos > 20 && sel.YClickPos < 200) { f = 1; px = 180; py = 0; }
                if (sel.XClickPos > 380 && sel.XClickPos < 560 && sel.YClickPos > 20 && sel.YClickPos < 200) { f = 2; px = 360; py = 0; }
                if (sel.XClickPos > 20 && sel.XClickPos < 200 && sel.YClickPos > 200 && sel.YClickPos < 380) { f = 3; px = 0; py = 180; }
                if (sel.XClickPos > 200 && sel.XClickPos < 380 && sel.YClickPos > 200 && sel.YClickPos < 380) { f = 4; px = 180; py = 180; }
                if (sel.XClickPos > 380 && sel.XClickPos < 560 && sel.YClickPos > 200 && sel.YClickPos < 380) { f = 5; px = 360; py = 180; }
                if (sel.XClickPos > 20 && sel.XClickPos < 200 && sel.YClickPos > 380 && sel.YClickPos < 560) { f = 6; px = 0; py = 360; }
                if (sel.XClickPos > 200 && sel.XClickPos < 380 && sel.YClickPos > 380 && sel.YClickPos < 560) { f = 7; px = 180; py = 360; }
                if (sel.XClickPos > 380 && sel.XClickPos < 560 && sel.YClickPos > 380 && sel.YClickPos < 560) { f = 8; px = 360; py = 360; }

                IBigTicTacToeField bigfield = null;
                if (field is IBigTicTacToeField)
                {
                    bigfield = (IBigTicTacToeField)field;
                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            if (sel.XClickPos > 20 + px + (j * 60) && sel.XClickPos < 80 + px + (j * 60) &&
                                sel.YClickPos > 20 + py + (i * 60) && sel.YClickPos < 80 + py + (i * 20) &&
                                bigfield.SubFields[f][i, j] <= 0)
                            {
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
