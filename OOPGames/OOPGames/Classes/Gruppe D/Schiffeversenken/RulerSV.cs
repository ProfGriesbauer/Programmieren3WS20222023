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



        Stack<int> _SchiffeP1 = new Stack<int>(new int[] {2, 2, 2, 3, 3, 4, 4, 5 }); // schifflänge 
        Stack<int> _SchiffeP2 = new Stack<int>(new int[] {2, 2, 2, 3, 3, 4, 4, 5 });
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

        public void ResetShipStack()
        {
            _SchiffeP1 = new Stack<int>(new int[] {2, 2, 2, 3, 3, 4, 4, 5 });
            _SchiffeP2 = new Stack<int>(new int[] {2, 2, 2, 3, 3, 4, 4, 5 });
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
            _Shipfield.ResetShipStack();
            _Shipfield.Phase = 1;
        }

        public void DoMove(IPlayMove move)
        {
            if (move is ISVMove)
            {
                DoShipMove((ISVMove)move);

            }
        }
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
                    if (_Shipfield[i - 1, c, PlayerNumber] > 0)
                    {
                        return 1;
                    }
                    if (r + ShipLength >= 8)
                    {
                        return 0;
                    }
                    if (_Shipfield[r + ShipLength, c, PlayerNumber] > 0)
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
                    if (_Shipfield[r, c - 1, PlayerNumber] > 0)
                    {
                        return 1;
                    }
                    if (c + ShipLength >= 8)
                    {
                        return 0;
                    }
                    if (_Shipfield[r, c + ShipLength, PlayerNumber] > 0)
                    {
                        return 1;
                    }
                }
            }
            return 0;
        }
        public void DoShipMove(ISVMove move)
        {
            int _PlayerNumber = move.PlayerNumber;
            if (GamePhase == 1 || GamePhase == 2)
            {
                if (GamePhase == 1 )
                {
                    _PlayerNumber = 1;
                }
                else
                {
                    _PlayerNumber = 2;
                }
                
                if (move.Row >= 0 && move.Row < 8 && move.Column >= 0 && move.Column < 8 && _PlayerNumber < 3)
                {
                    if (_Shipfield.HorVer == 1 && (move.Row + _Shipfield.Ships(2, _PlayerNumber) < 8) && ShipPlaceable(move.Row, move.Column, _Shipfield.Ships(2, _PlayerNumber), _Shipfield.HorVer, _PlayerNumber) == 0)
                    {
                        int _Ship = SetShip(move.Row, move.Column, _PlayerNumber);
                        for (int i = 0; i < _Ship; i++)
                        {
                            _Shipfield[move.Row + i, move.Column, _PlayerNumber] = _Ship;
                        }
                    }
                    else if (_Shipfield.HorVer == 2 && (move.Column + _Shipfield.Ships(2, _PlayerNumber) < 8) && ShipPlaceable(move.Row, move.Column, _Shipfield.Ships(2, _PlayerNumber), _Shipfield.HorVer, _PlayerNumber) == 0)
                    {
                        int _Ship = SetShip(move.Row, move.Column, _PlayerNumber);
                        for (int i = 0; i < _Ship; i++)
                        {
                            _Shipfield[move.Row, move.Column + i, _PlayerNumber] = _Ship;
                        }
                    }
                }
        }

        if (GamePhase == 3)
        {
            if (_Shipfield[move.Row, move.Column, _PlayerNumber + 2] == 0)
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
                if (ShipCounter == 25)
                {
                    ChangePhase();
                    return 0;
                }
                if (ShipCounter == 50)
                {
                    ChangePhase();
                    return 0;
                }
                return _Shipfield.Ships(1, Playernumber);
            }
            return 0;
           }
        }
    }
