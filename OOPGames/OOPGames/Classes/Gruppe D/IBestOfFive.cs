using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPGames.Classes.Gruppe_D
{
    public interface ITicTacToeBOFRules : ITicTacToeRules
    {
        int ICountWin(int winner);
        void ClearOnlyField();
    }


    public class BOFField : ITicTacToeField
    {
        int[,] _Field = new int[3, 3] { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } };

        int _P1 = 0;
        int _P2 = 0;

        public int this[int r, int c]
        {
            get
            {
                if (r >= 0 && r < 3 && c >= 0 && c < 3)
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
                if (r >= 0 && r < 3 && c >= 0 && c < 3)
                {
                    _Field[r, c] = value;
                }
            }
        }

        public bool CanBePaintedBy(IPaintGame painter)
        {
            return painter is IPaintTicTacToe;
        }

        public void clearScore()
        {
            _P1 = 0;
            _P2 = 0;
        }

        public int player1wins
        {
            get { return _P1; }
            set { _P1++; }
        }
        public int player2wins
        {
            get { return _P2; }
            set { _P2++; }
        }
    }


    public class BestOfFiveRulesD : ITicTacToeBOFRules
    {

        BOFField _KrassesFeldBOF = new BOFField();
        public string Name { get { return "DieKrassenRegelnBOF"; } }

        public IGameField CurrentField { get { return _KrassesFeldBOF; } }

        public bool MovesPossible
        {
            get
            {
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (_KrassesFeldBOF[i, j] == 0)
                        {
                            return true;
                        }



                    }
                }
                return false;
            }
        }


        public ITicTacToeField TicTacToeField { get { return _KrassesFeldBOF; } }

        public int CheckIfPLayerWon()
        {
            for (int i = 0; i < 3; i++)
            {
                if (_KrassesFeldBOF[i, 0] == 1 && _KrassesFeldBOF[i, 1] == 1 && _KrassesFeldBOF[i, 2] == 1) { return ICountWin(1); }
                if (_KrassesFeldBOF[0, i] == 1 && _KrassesFeldBOF[1, i] == 1 && _KrassesFeldBOF[2, i] == 1) { return ICountWin(1); }
                if (_KrassesFeldBOF[i, 0] == 2 && _KrassesFeldBOF[i, 1] == 2 && _KrassesFeldBOF[i, 2] == 2) { return ICountWin(2); }
                if (_KrassesFeldBOF[0, i] == 2 && _KrassesFeldBOF[1, i] == 2 && _KrassesFeldBOF[2, i] == 2) { return ICountWin(2); }


            }
            if (_KrassesFeldBOF[0, 0] == 1 && _KrassesFeldBOF[1, 1] == 1 && _KrassesFeldBOF[2, 2] == 1) { return ICountWin(1); }
            if (_KrassesFeldBOF[2, 0] == 1 && _KrassesFeldBOF[1, 1] == 1 && _KrassesFeldBOF[0, 2] == 1) { return ICountWin(1); }
            if (_KrassesFeldBOF[0, 0] == 2 && _KrassesFeldBOF[1, 1] == 2 && _KrassesFeldBOF[2, 2] == 2) { return ICountWin(2); }
            if (_KrassesFeldBOF[2, 0] == 2 && _KrassesFeldBOF[1, 1] == 2 && _KrassesFeldBOF[0, 2] == 2) { return ICountWin(2); }
            if (!MovesPossible) { return ICountWin(-1); }
            return -1;
        }

        public void ClearField() //for MainWindow do not change Name
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    _KrassesFeldBOF[i, j] = 0;
                }
            }
            _KrassesFeldBOF.clearScore();
        }

        public void ClearOnlyField()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    _KrassesFeldBOF[i, j] = 0;
                }
            }
        }

        public void DoMove(IPlayMove move)
        {
            if (move is ITicTacToeMove)
            {
                DoTicTacToeMove((ITicTacToeMove)move);
            }

        }

        public void DoTicTacToeMove(ITicTacToeMove move)
        {
            if (move.Row >= 0 && move.Row < 3 && move.Column >= 0 && move.Column < 3)
            {
                _KrassesFeldBOF[move.Row, move.Column] = move.PlayerNumber;
            }
        }

        public int ICountWin(int winner)
        {
            if (_KrassesFeldBOF.player1wins < 3 && _KrassesFeldBOF.player2wins < 3 || winner == -1)
            {

                if (winner == 1)
                {
                    _KrassesFeldBOF.player1wins = 0;
                }
                if (winner == 2)
                {
                    _KrassesFeldBOF.player2wins = 0;
                }

                ClearOnlyField();

                return 0;
            }
            else
            {
                if (_KrassesFeldBOF.player1wins == 3) { return 1; }
                else { return 2; }
            }
        }
    }
}
