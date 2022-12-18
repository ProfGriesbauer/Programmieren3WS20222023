using OOPGames;
using OOPGames.Classes.GruppeI;
using System.ComponentModel;
using System.Windows.Navigation;

public class I_TicTacToeRules : IGameRules
{
    public string Name { get { return "I_Rules"; } }

    IBigTicTacToeField _BigField = new IBigTicTacToeField();

    public IGameField CurrentField { get { return _BigField; } }


    public bool MovesPossible //Fehler/Ausbessern  !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
    {
        get
        {
            for (int t = 0; t < 81; t++)
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



    public int CheckIfPLayerWon() //für großes Feld -> brauchen wir auch noch f�r kleine Felder, aber als eigene Funktion
    {
        CheckIfSmallField_IsWon();
        //waagrecht
        if (_BigField.SubFields[0].WonByPlayer == _BigField.SubFields[1].WonByPlayer && _BigField.SubFields[1].WonByPlayer == _BigField.SubFields[2].WonByPlayer)
        {
            return _BigField.SubFields[0].WonByPlayer;
        }
        else if (_BigField.SubFields[3].WonByPlayer == _BigField.SubFields[4].WonByPlayer && _BigField.SubFields[4].WonByPlayer == _BigField.SubFields[5].WonByPlayer)
        {
            return _BigField.SubFields[3].WonByPlayer;
        }
        else if (_BigField.SubFields[6].WonByPlayer == _BigField.SubFields[7].WonByPlayer && _BigField.SubFields[7].WonByPlayer == _BigField.SubFields[8].WonByPlayer)
        {
            return _BigField.SubFields[6].WonByPlayer;
        }
        //senkrecht
        else if (_BigField.SubFields[0].WonByPlayer == _BigField.SubFields[3].WonByPlayer && _BigField.SubFields[3].WonByPlayer == _BigField.SubFields[6].WonByPlayer)
        {
            return _BigField.SubFields[0].WonByPlayer;
        }
        else if (_BigField.SubFields[1].WonByPlayer == _BigField.SubFields[4].WonByPlayer && _BigField.SubFields[4].WonByPlayer == _BigField.SubFields[7].WonByPlayer)
        {
            return _BigField.SubFields[1].WonByPlayer;
        }
        else if (_BigField.SubFields[2].WonByPlayer == _BigField.SubFields[5].WonByPlayer && _BigField.SubFields[5].WonByPlayer == _BigField.SubFields[8].WonByPlayer)
        {
            return _BigField.SubFields[2].WonByPlayer;
        }
        //diagonal
        else if (_BigField.SubFields[0].WonByPlayer == _BigField.SubFields[4].WonByPlayer && _BigField.SubFields[4].WonByPlayer == _BigField.SubFields[8].WonByPlayer)
        {
            return _BigField.SubFields[0].WonByPlayer;
        }
        else if (_BigField.SubFields[2].WonByPlayer == _BigField.SubFields[4].WonByPlayer && _BigField.SubFields[4].WonByPlayer == _BigField.SubFields[6].WonByPlayer)
        {
            return _BigField.SubFields[2].WonByPlayer;
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

    //ab hier kommen nur noch Game-speziefische Rules

    //aktionsradius auf ein Subfield begrenzen
    //check if player won für subfield -> unentscheiden = zufallsentscheid -> win = playernumber + 2 -> nach Entscheidung Subfield wieder inactive setzen 
    public void CheckIfSmallField_IsWon()
    {
        for (int t = 0; t < 9; t++)
        {

            for (int i = 0; i < 3; i++)
            {
                if (_BigField.SubFields[t][i, 0] >= 0 && _BigField.SubFields[t][i, 0] == _BigField.SubFields[t][i, 1] && _BigField.SubFields[t][i, 1] == _BigField.SubFields[t][i, 2])
                {
                    _BigField.SubFields[t].WonByPlayer = _BigField.SubFields[t][i,0];
                    break;
                }
                else if (_BigField.SubFields[t][0, i] >= 0 && _BigField.SubFields[t][0, i] == _BigField.SubFields[t][1, i] && _BigField.SubFields[t][1, i] == _BigField.SubFields[t][2, i])
                {
                    _BigField.SubFields[t].WonByPlayer = _BigField.SubFields[t][0, i];
                    break;
                }
            }

            if (_BigField.SubFields[t][0, 0] > 0 && _BigField.SubFields[t][0, 0] == _BigField.SubFields[t][1, 1] && _BigField.SubFields[t][1, 1] == _BigField.SubFields[t][2, 2])
            {
                _BigField.SubFields[t].WonByPlayer = _BigField.SubFields[t][0, 0];
                break;
            }
            else if (_BigField.SubFields[t][0, 2] > 0 && _BigField.SubFields[t][0, 2] == _BigField.SubFields[t][1, 1] && _BigField.SubFields[t][1, 1] == _BigField.SubFields[t][2, 0])
            {
                _BigField.SubFields[t].WonByPlayer = _BigField.SubFields[t][0, 2];
                break;
            }

        }
    }
    
}

