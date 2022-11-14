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

        public bool MovesPossible => throw new NotImplementedException();

        public ITicTacToeField TicTacToeField => throw new NotImplementedException();

        public int CheckIfPLayerWon()
        {
            throw new NotImplementedException();
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
