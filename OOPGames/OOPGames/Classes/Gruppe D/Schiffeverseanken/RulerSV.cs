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
                if (r < 8 && c < 8 && r >= 0 && c>=0 && w>0 && w<5)
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

        public int CheckIfPLayerWon()
        {
            throw new NotImplementedException();
        }

        public void ClearField()
        {
            
        }

        public void DoMove(IPlayMove move)
        {
            throw new NotImplementedException();
        }

        public void DoShipMove(IShipMove move)
        {
            throw new NotImplementedException();
        }

        public void StartedGameCall()
        {
            throw new NotImplementedException();
        }

        public void TickGameCall()
        {
            throw new NotImplementedException();
        }
    }
}
