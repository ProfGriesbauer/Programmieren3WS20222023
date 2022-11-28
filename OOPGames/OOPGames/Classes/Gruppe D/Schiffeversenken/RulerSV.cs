using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPGames.Classes.Gruppe_D.Schiffeverseanken
{
    public class FieldSV : IFieldSV
    {
        int[,] _P1Ships = new int[8, 8] { { 0, 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0, 0 } };
        int[,] _P2Ships = new int[8, 8] { { 0, 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0, 0 } };

        int[,] _P1shoot = new int[8, 8] { { 0, 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0, 0 } };
        int[,] _P2shoot = new int[8, 8] { { 0, 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0, 0 } };

        public int this[int r, int c, int w] 
        { 
            get  
            {
                if (r < 8 && c < 8 && r >= 0 && c>=0 && w>0 &&  w<5)
                {
                    if(w==1)
                    {
                        return _P1Ships[r, c];
                    }
                    if (w == 2)
                    {
                        return _P2Ships[r, c];
                    }
                    if (w == 3)
                    {
                        return _P1shoot[r, c];
                    }
                    if (w == 4)
                    {
                        return _P2shoot[r, c];
                    }
                   
                }
                return -1;
            } 
            set
            {
                if (r < 8 && c < 8 && r >= 0 && c >= 0 && w > 0 && w < 5)
                {
                    if (w == 1) { _P1Ships[r, c] = value; }
                    if (w == 2) { _P2Ships[r, c] = value; }
                    if (w == 3) { _P1shoot[r, c] = value; }
                    if (w == 4) { _P1shoot[r, c] = value; }
                }
            }  
        }

        public bool CanBePaintedBy(IPaintGame painter)
        {
            return painter is IPaintSV;
        }


    }

    public class RulerSV : IRulerSV
    {
        FieldSV _Shipfield = new FieldSV();
        int GamePhase = 1;
        int ShipCounter = 0;
        public string Name { get { return "SchiffeverseankenRuler"; } }

        public IGameField CurrentField { get { return _Shipfield; } }

        public bool MovesPossible
        {
            get
            {
                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        if (_Shipfield[i, j, 3] == 0)
                        {
                            return true;
                        }

                    }
                }
                return false;
            }
        }

        public void ChangePhase()
        {
            GamePhase++;
        }
     

       

        public int CheckHit(int r, int c, int Playernumber)             //Schussfunktion
        {
            if (Playernumber == 2)
            {
                if (_Shipfield[r, c, 1] == 1)
                {
                    return 2;
                }
            }
            if (Playernumber == 1) { 
                    if (_Shipfield[r, c, 2] == 1)
                    {
                    return 2; 
                    }    
            }
            return 1;
        }

        public int CheckIfPLayerWon()
        {
            int _hitsP1 = ShipCounter; // Anzahl der Schifffelder gesamt --> kann angepasst werden in SetShip-Funktion
            int _hitsP2 = ShipCounter;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (_Shipfield[i, j, 3] == 2)
                    {
                        _hitsP1--;
                    }
                    if (_Shipfield[i, j, 4] == 2)
                    {
                        _hitsP2--;
                    }

                }
            }
            if (_hitsP1 == 0)
            {
                return 1;
            }
            if (_hitsP2 == 0)
            {
                return 2;
            }
            return -1;

        }

        public void ClearField()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    for (int w = 1; w < 5; w++)
                    {
                        _Shipfield[i, j, w] = 0;
                    }
                }
            }
        }

        public void DoMove(IPlayMove move)
        {
            if (move is IShipMove)
            {
                DoShipMove((IShipMove)move);

            }
        }

        public void DoShipMove(IShipMove move)
        {
            if (GamePhase == 1 || GamePhase == 2)
            {
                if (move.Row >= 0 && move.Row < 8 && move.Column >= 0 && move.Column < 8 && move.PlayerNumber == 1)
                {
                    _Shipfield[move.Row, move.Column, 1] = SetShip(move.Row, move.Column, move.PlayerNumber);
                }

                if (move.Row >= 0 && move.Row < 8 && move.Column >= 0 && move.Column < 8 && move.PlayerNumber == 2)
                {
                    _Shipfield[move.Row, move.Column, 2] = SetShip(move.Row, move.Column, move.PlayerNumber);
                }
            }
            if (GamePhase == 3)
            {
                if (move.Row >= 0 && move.Row < 8 && move.Column >= 0 && move.Column < 8 && move.PlayerNumber == 1)
                {
                    _Shipfield[move.Row, move.Column, 3] = CheckHit(move.Row, move.Column, move.PlayerNumber);
                }
                if (move.Row >= 0 && move.Row < 8 && move.Column >= 0 && move.Column < 8 && move.PlayerNumber == 2)
                {
                    _Shipfield[move.Row, move.Column, 4] = CheckHit(move.Row, move.Column, move.PlayerNumber);
                }
            }
        }

        public int SetShip(int r, int c, int PLayernumber)
        {
            if (PLayernumber == 1 && _Shipfield[r, c, 1] ==0)
            {
                ShipCounter++;
                if (ShipCounter ==15)
                {
                    ChangePhase();
                }
                return 1;
            }
            if (PLayernumber == 2 && _Shipfield[r, c, 2] == 0)
            {
                ShipCounter++;
                if (ShipCounter == 15)
                {
                    ChangePhase();
                }
                return 1;
            }
            return 1;
        }
    }
}
