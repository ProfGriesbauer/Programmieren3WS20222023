using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace OOPGames
{
    
    public class FTicTacToeField : ITicTacToeField, IFTicTacToeField
    {
        int[,] _Field = new int[3, 3] { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } };
        int _CurrentWinner;
        int _StrokeThickness;
        int _Color;

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

        public int CurrentWinner {
            get
            {
                return _CurrentWinner;
            }
            set
            {
                _CurrentWinner = value;

            }
        }

        public int Thickness
        { get { return _StrokeThickness;
            } 
            set { _StrokeThickness = value;
            }
        }

        public int LooseColor
        {
            get
            {
                return _Color;
            }
            set
            {
                _Color = value;
            }
        }

        public bool CanBePaintedBy(IPaintGame painter)
        {
            return painter is TTTPaint;
        }
    }
    public class TTTRulesF : BaseTicTacToeRules, IGameRulesF//,IFieldSum
    {
        int timerCounter;
        int FieldSumOld;
        int FieldSum;
        int CurrentPlayer;
        int StrokeThickness;

        FTicTacToeField _Field = new FTicTacToeField();
        public override ITicTacToeField TicTacToeField { get { return _Field; } }

        public override bool MovesPossible {
            get {
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
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

        public override string Name { get { return "GruppeFTTTRules"; } }

        public int? checkFieldSum { get
            {
               
                for (int r=0; r>=2; r++)
                {
                    for (int c=0; c>=2; c++)
                    {
                        FieldSum += _Field[r, c];
                    }

                }

                if (FieldSum != FieldSumOld)
                {
                    timerCounter = 0;
                    return 1;
                }
                FieldSumOld = FieldSum;
                return 0;
            }
        }

        public int Thickness { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override int CheckIfPLayerWon()
        {
            for (int i = 0; i < 3; i++)
            {
                if (_Field[i, 0] > 0 && _Field[i, 0] == _Field[i, 1] && _Field[i, 1] == _Field[i, 2])
                {
                    return _Field[i, 0];
                }
                else if (_Field[0, i] > 0 && _Field[0, i] == _Field[1, i] && _Field[1, i] == _Field[2, i])
                {
                    return _Field[0, i];
                }
            }

            if (_Field[0, 0] > 0 && _Field[0, 0] == _Field[1, 1] && _Field[1, 1] == _Field[2, 2])
            {
                return _Field[0, 0];
            }
            else if (_Field[0, 2] > 0 && _Field[0, 2] == _Field[1, 1] && _Field[1, 1] == _Field[2, 0])
            {
                return _Field[0, 2];
            }
            
            return -1;
           
        }
        public void CheckIfPlayerWonTime()
        {
            if (timerCounter > 2000 && checkFieldSum  == 0)
            {
                if(CurrentPlayer==1)
                {
                    _Field.CurrentWinner = 2;
                    _Field.Thickness = 60;
                }
                else {
                    _Field.CurrentWinner = 1;
                    _Field.Thickness = 120;
                }
                
            }
        }

        public override void ClearField()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    _Field[i, j] = 0;
                }
            }
            _Field.Thickness = 0;
            timerCounter = 0;
        }

        public override void DoTicTacToeMove(ITicTacToeMove move)
        {
            if (move.Row >= 0 && move.Row < 3 && move.Column >= 0 && move.Column < 3)
            {
                _Field[move.Row, move.Column] = move.PlayerNumber;
            }
        }

        public void StartedGameCall()
        {
           
        }

        public void TickGameCall()
        {
            
            timerCounter+=40;
            CheckIfPlayerWonTime();
          
        }

        public void TickGameCall(IGamePlayer currentPlayer)
        {
            CurrentPlayer = currentPlayer.PlayerNumber;
        }
    }
}
