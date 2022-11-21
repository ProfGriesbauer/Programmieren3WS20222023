using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace OOPGames
{
    public class B_Rules : IGameRulesB
    {
        TicTacToeField _Field = new TicTacToeField();
        Timer _aTimer = new Timer(2000);
       
        
        public event EventHandler<EventArgs> TimeEvent;
        
        public B_Rules()
        {
            _aTimer.Elapsed += OnTimeEvent;
            _aTimer.AutoReset = false;
        }

        public ITicTacToeField TicTacToeField
        {
            get
            {
                
                return _Field;
            }
        }

        public bool MovesPossible
        {
            get
            {
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

        public string Name { get { return "GruppeBTicTacToeRules"; } }

        public IGameField CurrentField { get { return TicTacToeField; } }

        

        public int CheckIfPLayerWon()
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

        public void ClearField()
        {
            {
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        _Field[i, j] = 0;
                    }
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
                _Field[move.Row, move.Column] = move.PlayerNumber;
            }
        }

        public void OnPlayerChange(object source, RulesEventArgs e)
        {
            if (e.gameRules is B_Rules)
            {
                _aTimer.Stop();
                _aTimer.Start();
            }
            
        }

     

        private void OnTimeEvent(Object source, ElapsedEventArgs e)
        {
            OnTimerEnded();
        }

        protected virtual void OnTimerEnded()
        {
           if(TimeEvent != null)
                TimeEvent(this, EventArgs.Empty);
        }
    }
}


