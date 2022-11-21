using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPGames
{
    public class RulesD : ITicTacToeRules

    {
        TicTacToeField _KrassesFeld = new TicTacToeField();
        public string Name { get { return "DieKrassenRegeln"; } }

        public IGameField CurrentField { get { return _KrassesFeld; } }

        public bool MovesPossible
        {
            get
            {
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (_KrassesFeld[i, j] == 0)
                        {
                            return true;
                        }



                    }
                }
                return false;
            }
        }




        public ITicTacToeField TicTacToeField { get { return _KrassesFeld;} }

        public int CheckIfPLayerWon()
        {
            for (int i = 0; i < 3; i++)
            {
                if (_KrassesFeld[i, 0] == 1 && _KrassesFeld[i, 1] == 1 && _KrassesFeld[i, 2] == 1) { return 1; }
                if (_KrassesFeld[0, i] == 1 && _KrassesFeld[1, i] == 1 && _KrassesFeld[2, i] == 1) { return 1; }
                if (_KrassesFeld[i, 0] == 2 && _KrassesFeld[i, 1] == 2 && _KrassesFeld[i, 2] == 2) { return 2; }
                if (_KrassesFeld[0, i] == 2 && _KrassesFeld[1, i] == 2 && _KrassesFeld[2, i] == 2) { return 2; }


            }
            if (_KrassesFeld[0, 0] == 1 && _KrassesFeld[1, 1] == 1 && _KrassesFeld[2, 2] == 1) { return 1; }
            if (_KrassesFeld[2, 0] == 1 && _KrassesFeld[1, 1] == 1 && _KrassesFeld[0, 2] == 1) { return 1; }
            if (_KrassesFeld[0, 0] == 2 && _KrassesFeld[1, 1] == 2 && _KrassesFeld[2, 2] == 2) { return 2; }
            if (_KrassesFeld[2, 0] == 2 && _KrassesFeld[1, 1] == 2 && _KrassesFeld[0, 2] == 2) { return 2; }
            return -1;
        }

        public void ClearField()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    _KrassesFeld[i, j] = 0;
                }
            }
        }

        public void DoMove(IPlayMove move)
        {
            if (move is ITicTacToeMove)
            {
                DoTicTacToeMove((ITicTacToeMove) move);
            }

        }

        public void DoTicTacToeMove(ITicTacToeMove move)
        {
            if (move.Row >= 0 && move.Row < 3 && move.Column >= 0 && move.Column < 3)
            {
                _KrassesFeld[move.Row, move.Column] = move.PlayerNumber;
            }
        }
    }
}
