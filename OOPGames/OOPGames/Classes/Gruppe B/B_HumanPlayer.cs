using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace OOPGames
{

    public class B_HumanPlayer : IHumanTicTacToePlayer
    {

        int _PlayerNumber = 0;

        public string Name { get { return "GruppeBHumanPlayer"; } }

        public int PlayerNumber { get { return _PlayerNumber; } }

        public bool CanBeRuledBy(IGameRules rules)
        {
            return rules is ITicTacToeRules; ;
        }
        public IGamePlayer Clone()
        {
            B_HumanPlayer ttthp = new B_HumanPlayer();
            ttthp.SetPlayerNumber(_PlayerNumber);
            return ttthp;
        }

        public ITicTacToeMove GetMove(IMoveSelection selection, ITicTacToeField field)
        {
            if (selection is IClickSelection)
            {
                IClickSelection sel = (IClickSelection)selection;
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (sel.XClickPos > 20 + (j * 100) && sel.XClickPos < 120 + (j * 100) &&
                            sel.YClickPos > 20 + (i * 100) && sel.YClickPos < 120 + (i * 100) &&
                            field[i, j] <= 0)
                        {
                            return new TicTacToeMove(i, j, _PlayerNumber);
                        }
                    }
                }
            }

            return null;
        }

        public IPlayMove GetMove(IMoveSelection selection, IGameField field)
        {
            if (field is ITicTacToeField)
            {
                return GetMove(selection, (ITicTacToeField)field);
            }
            else
            {
                return null;
            }
        }

        public void SetPlayerNumber(int playerNumber)
        {
            _PlayerNumber = playerNumber;
        }

    }
}
