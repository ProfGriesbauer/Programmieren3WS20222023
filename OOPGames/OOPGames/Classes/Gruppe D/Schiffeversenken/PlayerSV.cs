using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
using OOPGames;
using OOPGames.Classes.Gruppe_D.Schiffeverseanken;

namespace OOPGames.Classes.Gruppe_D.Schiffeversenken
{
    public class PlayerSV : IHumanSV
    {
        int _PlayerNumber = 0;
        public string Name {  get { return "HumanPlayerSV"; } }

        public int PlayerNumber { get {  return _PlayerNumber; } }

        public bool CanBeRuledBy(IGameRules rules)
        {
            return rules is IRulerSV;
        }

        public IGamePlayer Clone()
        {
            PlayerSV ttthp = new PlayerSV();
            ttthp.SetPlayerNumber(_PlayerNumber);
            return ttthp;
        }

        public IPlayMove GetMove(IMoveSelection selection, IGameField field)
        {
            if (field is IFieldSV)
            {
                return GetMove(selection, (IFieldSV)field);
            }
            else
            {
                return null;
            }
        }

        public ISVMove GetMove(IMoveSelection selection, IFieldSV field)
        {
            if (selection is IClickSelection)
            {
                IClickSelection click = (IClickSelection)selection;

                for (int r = 0; r < 8; r++)
                {
                    for (int c = 0; c < 8; c++)
                    {
                        if (field.Phase == 1 || field.Phase == 2)
                        {
                            if (click.XClickPos > 20 + (c * 50) && click.XClickPos < 70 + (c * 50) &&
                            click.YClickPos > 50 + (r * 50) && click.YClickPos < 100 + (r * 50))
                            {
                                return new SVMove(r, c, _PlayerNumber);
                            }
                        }
                        
                        if (field.Phase == 3 && field.FirstClick == 1)
                        {
                            if (click.XClickPos > 20 + (c * 50) && click.XClickPos < 70 + (c * 50) &&
                            click.YClickPos > 50 + (r * 50) && click.YClickPos < 100 + (r * 50) && _PlayerNumber == 1)
                            {
                                return new SVMove(r, c, _PlayerNumber);
                            }

                            if (click.XClickPos > 450 + (c * 50) && click.XClickPos < 500 + (c * 50) &&
                                click.YClickPos > 50 + (r * 50) && click.YClickPos < 100 + (r * 50) && _PlayerNumber == 2)
                            {
                                return new SVMove(r, c, _PlayerNumber);
                            }
                        }  
                    }
                }
            }
            return null;
        }

        public void SetPlayerNumber(int playerNumber)
        {
            _PlayerNumber= playerNumber;
        }
    }
}
public class SVMove : ISVMove
{
    
    int _Row = 0;
    int _Column = 0;
    int _PlayerNumber = 0;

    public SVMove(int row, int column, int playerNumber)
    {
        _Row = row;
        _Column = column;
        _PlayerNumber = playerNumber;
    }

    public int Row { get { return _Row; } }

    public int Column { get { return _Column; } }

    public int PlayerNumber { get { return _PlayerNumber; } }
}