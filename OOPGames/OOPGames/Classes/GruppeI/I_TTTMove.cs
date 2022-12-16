using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPGames.Classes.GruppeI
{

    public interface ITTTMove : ITicTacToeMove
    {
        int Feld { get; }
    }

    public class TicTacToeMove_I : ITTTMove
    {
        int _Feld = 0;
        int _Row = 0;
        int _Column = 0;
        int _PlayerNumber = 0;

        public TicTacToeMove_I(int Feld, int row, int column, int playerNumber)
        {
            _Feld = Feld;
            _Row = row;
            _Column = column;
            _PlayerNumber = playerNumber;
        }

        public int Feld { get { return _Feld; } }

        public int Row { get { return _Row; } }

        public int Column { get { return _Column; } }

        public int PlayerNumber { get { return _PlayerNumber; } }
    }
}
