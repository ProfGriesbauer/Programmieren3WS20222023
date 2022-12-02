using OOPGames;

public class TicTacToeRules : BaseTicTacToeRules
{
    TicTacToeField _Field = new TicTacToeField();

    public override ITicTacToeField TicTacToeField { get { return _Field; } }

    public override bool MovesPossible
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

    public override string Name { get { return "GriesbauerTicTacToeRules"; } }

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

    public override void ClearField()
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                _Field[i, j] = 0;
            }
        }
    }

    public override void DoTicTacToeMove(ITicTacToeMove move)
    {
        if (move.Row >= 0 && move.Row < 3 && move.Column >= 0 && move.Column < 3)
        {
            _Field[move.Row, move.Column] = move.PlayerNumber;
        }
    }
}