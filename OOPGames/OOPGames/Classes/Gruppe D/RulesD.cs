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
                        } else { return false; }
                        
                            
                        
                    }
                }
            }
        }
                    
                
            

        public ITicTacToeField TicTacToeField => throw new NotImplementedException();

        public int CheckIfPLayerWon()
        {
            for (int i = 0; i <= 3; i++)
            {
                if (_KrassesFeld[i, 0] == 1 && _KrassesFeld[i, 1] == 1 && _KrassesFeld[i, 2] == 1) { return 1; }
                if (_KrassesFeld[0, i] == 1 && _KrassesFeld[1, i] == 1 && _KrassesFeld[2, i] == 1) { return 1; }
                
            }
            
        }

        public void ClearField()
        {
            throw new NotImplementedException();
        }

        public void DoMove(IPlayMove move)
        {
            throw new NotImplementedException();
        }

        public void DoTicTacToeMove(ITicTacToeMove move)
        {
            throw new NotImplementedException();
        }
    }
}
