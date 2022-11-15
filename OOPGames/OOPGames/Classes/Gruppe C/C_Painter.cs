using OOPGames;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPGames.Classes.Gruppe_C
{


    public class C_TicTacToeHumanPlayer : BaseHumanTicTacToePlayer
    {
        int _Playernumber = 0;
        public override string Name { get { return "C_HumanTicTacToePlayer"; } }
        public override int PlayerNumber { get { return _Playernumber; } }
        public override IGamePlayer Clone()
        {
            TicTacToeHumanPlayer ttthp = new TicTacToeHumanPlayer();
            ttthp.SetPlayerNumber(_Playernumber);
            return ttthp;
        }
        public override ITicTacToeMove GetMove(IMoveSelection selection, ITicTacToeField field)
        {
            if (selection is IClickSelection)
            {
                IClickSelection sel = (IClickSelection)selection;
                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        if (sel.XClickPos > 20 + (j * 100) && sel.XClickPos < 120 + (j * 100) &&
                               sel.YClickPos > 20 + (i * 100) && sel.YClickPos < 120 + (i * 100) &&
                               field[i, j] <= 0)
                        {
                            return new TicTacToeMove(i, j, _Playernumber);
                        }
                    }
                }
            }
            return null;
        }
        public override void SetPlayerNumber(int playerNumber)
        {
            _Playernumber = playerNumber;
        }


    }
    public class GC_TicTacToeRules : BaseTicTacToeRules
    {
        GC_TicTacToeField _Field = new GC_TicTacToeField();

        public override ITicTacToeField TicTacToeField { get { return _Field; } }

        public override bool MovesPossible
        {
            get
            {
                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        if (_Field[i, j] == 0)
                        {
                            return true;
                        }
                    }
                }

                return false;
            }
        }

        public override string Name { get { return "GruppeCTicTacToeRules"; } }

        public override int CheckIfPLayerWon()
        {
            throw new NotImplementedException();
        }

        public override void ClearField()
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    _Field[i, j] = 0;
                }
            }
        }

        public override void DoTicTacToeMove(ITicTacToeMove move)
        {
            throw new NotImplementedException();
        }
    }

    public class GC_TicTacToeField : BaseTicTacToeField
    {
        int[,] _Field = new int[5, 5] { { 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0 } };

        public override int this[int r, int c]
        {
            get
            {
                if (r >= 0 && r < 5 && c >= 0 && c < 5)
                {
                    return _Field[r, c];
                }
                else
                {
                    return -1;
                }
            }
            set
            {
                if (r >= 0 && r < 5 && c >= 0 && c < 5)
                {
                    _Field[r, c] = value;
                }
            }
        }
    }
}