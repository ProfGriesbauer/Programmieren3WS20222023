using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xaml;

namespace OOPGames.Classes.GruppeI
{
    public class Human_PlayerI: BaseHumanTicTacToePlayer
    {
        int _PlayerNumber = 0;

        public override string Name { get { return "Human_TTT-Player_I"; } }

        public override int PlayerNumber { get { return _PlayerNumber; } }

        public override IGamePlayer Clone()
        {
            TicTacToeHumanPlayer ttthp = new TicTacToeHumanPlayer();
            ttthp.SetPlayerNumber(_PlayerNumber);

            return ttthp;
        }

        public override ITicTacToeMove GetMove(IMoveSelection selection, ITicTacToeField field)
        {
            int f = 0;
            int px = 0;
            int py = 0;
            if (selection is IClickSelection)
            {
                IClickSelection sel = (IClickSelection)selection;
                
                if (sel.XClickPos > 20 && sel.XClickPos < 80 && sel.YClickPos > 20 && sel.YClickPos < 80) { f = 0; px = 0; py = 0; }
                if (sel.XClickPos > 80 && sel.XClickPos < 140 && sel.YClickPos > 20 && sel.YClickPos < 80) { f = 1; px = 60; py = 0; }
                if (sel.XClickPos > 140 && sel.XClickPos < 200 && sel.YClickPos > 20 && sel.YClickPos < 80) { f = 2; px = 120; py = 0; }
                if (sel.XClickPos > 20 && sel.XClickPos < 80 && sel.YClickPos > 80 && sel.YClickPos < 140) { f = 3; px = 0; py = 60; }
                if (sel.XClickPos > 80 && sel.XClickPos < 140 && sel.YClickPos > 80 && sel.YClickPos < 140) { f = 4; px = 60; py = 60; }
                if (sel.XClickPos > 140 && sel.XClickPos < 200 && sel.YClickPos > 80 && sel.YClickPos < 140) { f = 5; px = 120; py = 60; }
                if (sel.XClickPos > 20 && sel.XClickPos < 80 && sel.YClickPos > 140 && sel.YClickPos < 200) { f = 6; px = 0; py = 120; }
                if (sel.XClickPos > 80 && sel.XClickPos < 140 && sel.YClickPos > 140 && sel.YClickPos < 200) { f = 7; px = 60; py = 120; }
                if (sel.XClickPos > 140 && sel.XClickPos < 200 && sel.YClickPos > 140 && sel.YClickPos < 200) { f = 8; px = 120; py = 120; }

                for (int i = 0; i < 3; i++)                         
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (sel.XClickPos > 20+ px + (j * 60) && sel.XClickPos < 80+px + (j * 60) &&
                            sel.YClickPos > 20+py + (i * 60) && sel.YClickPos < 80+py + (i * 20) &&
                            field[i, j] <= 0)
                        {
                            return new TicTacToeMove_I(f,i, j, _PlayerNumber);
                        }
                    }
                }
            }

            return null;
            




        }

        public override void SetPlayerNumber(int playerNumber)
        {
            _PlayerNumber = playerNumber;
        }
    }
}
