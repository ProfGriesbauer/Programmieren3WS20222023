using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPGames.Classes.GruppeI
{
    public class IHuman_Player: BaseHumanTicTacToePlayer
    {
        int _PlayerNumber = 0;

        public override string Name { get { return "GriesbauerHumanTicTacToePlayer"; } }

        public override int PlayerNumber { get { return _PlayerNumber; } }

        public override IGamePlayer Clone()
        {
            TicTacToeHumanPlayer ttthp = new TicTacToeHumanPlayer();
            ttthp.SetPlayerNumber(_PlayerNumber);

            return ttthp;
        }
        public override ITicTacToeMove GetMove(IMoveSelection selection, ITicTacToeField field) //field auch des richtige??
        {
            if (selection is IClickSelection)
            {
                IClickSelection sel = (IClickSelection)selection;
                for (int i = 0; i < 8; i++)
                {
                    for(int j = 0; j < 8; j++)
                    {
                        if (sel.XClickPos > 20 + (j*60) && sel.XClickPos < 80 + (j*60) &&
                            sel.YClickPos > 20 + (i*60) && sel.YClickPos < 80 + (i*60) &&
                            field[i,j] <= 0)
                        {
                            return new TicTacToeMove(i,j,_PlayerNumber);  //checken ob das dann noch mit dem Move passt
                        }

                    }
                }
            }
        }
    }
}