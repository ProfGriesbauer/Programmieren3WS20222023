using System;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOPGames.Classes.Gruppe_D.Schiffeverseanken
{
    public class FieldSV : IFieldSV
    {
        int[,] _P1Ships = new int[8, 8] { { 0, 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0, 0 } };
        int[,] _P2Ships = new int[8, 8] { { 0, 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0, 0 } };

        int[,] _P1shoot = new int[8, 8] { { 0, 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0, 0 } };
        int[,] _P2shoot = new int[8, 8] { { 0, 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0, 0 } };

        int _GamePhase = 1;
        int _HorVer = 1; // 1: Schiffe vertikal, 2:Schiffe horizontal



        Stack<int> _SchiffeP1 = new Stack<int>(new int[] { 5, 4, 4, 3, 3, 3, 2, 2, 2, 2 }); // schifflänge 
        Stack<int> _SchiffeP2 = new Stack<int>(new int[] { 5, 4, 4, 3, 3, 3, 2, 2, 2, 2 });
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
                    if (w == 4) { _P2shoot[r, c] = value; }
                }
            }  
        }

        public int Phase
        { 
            get{ return _GamePhase; } 
                
            set { _GamePhase = value; }
        }

        public int HorVer 
        {
            get { return _HorVer; }

            set { _HorVer = value; }
        }

        public bool CanBePaintedBy(IPaintGame painter)
        {
            return painter is IPaintSV;
        }

        public int Ships(int w, int p)
        {
            if(w == 1)
            {
                if(p == 1)
                {
                    return _SchiffeP1.Pop();
                }
                else
                {
                    return _SchiffeP2.Pop();
                }
            }
            if (w == 2)
            {
                if(p == 1)
                {
                    return _SchiffeP1.Peek();
                }
                else
                {
                    return _SchiffeP2.Peek();
                }
            }
            return 0;
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
            _Shipfield.Phase = GamePhase;
        }

        public int CheckHit(int r, int c, int Playernumber)//Schussfunktion
        {
            if (Playernumber == 2)
            {
                if (_Shipfield[r, c, 1] > 1)
                {
                    return 2;
                }
            }
            if (Playernumber == 1) {
                if (_Shipfield[r, c, 2] > 1)
                {
                    return 2;
                }
            }
            return 1;
        }

        public int CheckIfPLayerWon()
        {
            if (ShipCounter == 0)
            {
                return -1;
            }
            int _hitsP1 = ShipCounter / 2; // Anzahl der Schifffelder gesamt , geteilt durch 2 --> kann angepasst werden in SetShip-Funktion
            int _hitsP2 = ShipCounter / 2;
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
            
            int ShipPlaceable(int r, int c, int ShipLength, int HorVer, int PlayerNumber)     //Schaut, ob in der Umgebung ein Schiff ist
            {
                if (HorVer == 1)    //vertikal
                {
                    for (int i = r; i < r + ShipLength; i++)
                    {
                        if (_Shipfield[i, c - 1, PlayerNumber] > 0)
                        {
                            return 1;//-> Schiff ist in Umgebung vorhanden
                        }
                        if (_Shipfield[i, c + 1, PlayerNumber] > 0)
                        {
                            return 1;
                        }
                        if (_Shipfield[c, r - 1, PlayerNumber] > 0)
                        {
                            return 1;
                        }
                        if (_Shipfield[c, r + ShipLength, PlayerNumber] > 0)
                        {
                            return 1;
                        }
                    }

                }
                else if (HorVer == 2)   //horizontal
                {
                    for (int i = c; i < c + ShipLength; i++)
                    {
                        if (_Shipfield[r - 1, i, PlayerNumber] > 0)
                        {
                            return 1;//-> Schiff ist in Umgebung vorhanden
                        }
                        if (_Shipfield[r + 1, i, PlayerNumber] > 0)
                        {
                            return 1;
                        }
                        if (_Shipfield[c - 1, r, PlayerNumber] > 0)
                        {
                            return 1;
                        }
                        if (_Shipfield[c + ShipLength, r, PlayerNumber] > 0)
                        {
                            return 1;
                        }
                    }
                }
                return 0;
            }


            if (GamePhase == 1 || GamePhase == 2)
            {
                if (move.Row >= 0 && move.Row < 8 && move.Column >= 0 && move.Column < 8 && move.PlayerNumber < 3)
                {
                    if (_Shipfield.HorVer == 1 && (move.Row + _Shipfield.Ships(2, move.PlayerNumber) < 8) && ShipPlaceable(move.Row, move.Column, _Shipfield.Ships(2, move.PlayerNumber), _Shipfield.HorVer, move.PlayerNumber) == 0)
                    {
                        for (int i = 0; i < _Shipfield.Ships(2, move.PlayerNumber); i++)
                        {
                            _Shipfield[move.Row + i, move.Column, move.PlayerNumber] = SetShip(move.Row + i, move.Column, move.PlayerNumber);
                        }
                    }
                    else if (_Shipfield.HorVer == 2 && (move.Column + _Shipfield.Ships(2, move.PlayerNumber) < 8) && ShipPlaceable(move.Row, move.Column, _Shipfield.Ships(2, move.PlayerNumber), _Shipfield.HorVer, move.PlayerNumber) == 0)
                    {
                        for (int i = 0; i < _Shipfield.Ships(2, move.PlayerNumber); i++)
                        {
                            _Shipfield[move.Row, move.Column + i, move.PlayerNumber] = SetShip(move.Row, move.Column + i, move.PlayerNumber);
                        }
                    }
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

        public void RotateShip()
        {
            if (_Shipfield.HorVer == 1 )
            {
                _Shipfield.HorVer = 2;
            }
            else
            {
                _Shipfield.HorVer = 1;
            }
        }

        public int SetShip(int r, int c, int Playernumber)
            {
                if (_Shipfield[r, c, Playernumber] == 0)
                {
                    ShipCounter = ShipCounter + _Shipfield.Ships(2, Playernumber);
                    if (ShipCounter == 30)
                    {
                        ChangePhase();
                    }
                    if (ShipCounter == 60)
                    {
                         ChangePhase();
                    }
                    //return _Shipfield.Ships(1, Playernumber);
                }

                return _Shipfield.Ships(1, Playernumber);
            }
        }
    }
