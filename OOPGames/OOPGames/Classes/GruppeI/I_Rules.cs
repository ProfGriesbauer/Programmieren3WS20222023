using OOPGames;
using OOPGames.Classes.GruppeI;
using System.ComponentModel;
using System.Windows.Navigation;

public class I_TicTacToeRules : IGameRules
{
    public string Name { get { return "I_Rules"; } }

    IBigTicTacToeField _BigField = new IBigTicTacToeField();

    public IGameField CurrentField { get { return _BigField; } }


    public bool MovesPossible
    {
        get
        {
            for (int t = 0; t < 9; t++)
            {
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (_BigField.SubFields[t][i, j] == 0)
                        {
                            return true;
                        }
                    }
                }
            }


            return false;
        }
    }

    public int CheckIfPLayerWon() //für großes Feld -> brauchen wir auch noch für kleine Felder, aber als eigene Funktion
    {
        for (int i = 0; i < 3; i++)
        {
            if (_BigField[i, 0] > 0 && _BigField[i, 0] == _BigField[i, 1] && _BigField[i, 1] == _BigField[i, 2])
            {
                return _BigField[i, 0];
            }
            else if (_BigField[0, i] > 0 && _BigField[0, i] == _BigField[1, i] && _BigField[1, i] == _BigField[2, i])
            {
                return _BigField[0, i];
            }
        }

        if (_BigField[0, 0] > 0 && _BigField[0, 0] == _BigField[1, 1] && _BigField[1, 1] == _BigField[2, 2])
        {
            return _BigField[0, 0];
        }
        else if (_BigField[0, 2] > 0 && _BigField[0, 2] == _BigField[1, 1] && _BigField[1, 1] == _BigField[2, 0])
        {
            return _BigField[0, 2];
        }

        return -1;
    }

    public void ClearField() //leert ganzes Feld (BigField)

    {
        for (int t = 0; t < 9; t++)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    _BigField.SubFields[t][i, j] = 0;
                }
            }
        }
    }

    public void DoTTTMove(ITTTMove move)
    {

        if (move.Row >= 0 && move.Row < 3 && move.Column >= 0 && move.Column < 3 && move.Feld <= 8)
        {
            _BigField.SubFields[move.Feld][move.Row, move.Column] = move.PlayerNumber;
        }
    }

    public void DoMove(IPlayMove move)
    {
        if (move is ITTTMove)
        {
            DoTTTMove((ITTTMove)move);
        }
    }
}

    