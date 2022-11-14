using OOPGames;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPGames.Classes.Gruppe_C
{
    internal class C_Painter
    {
    }
}
public class  C_TicTacToeHumanPlayer : BaseHumanTicTacToePlayer
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
            for (int i =0; i<5; i++)
            {
                for (int j=0; j<5; j++)
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