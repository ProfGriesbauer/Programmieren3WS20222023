using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPGames.Classes.Gruppe_C.Minesweeper
{
    /*
    public class C_MinesweeperField : C_IMinesweeperField
    {
        Segment[,] _Field = new Segment[16, 16] { { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 } };
 

        public Segment this[int r, int c]
        {
            get
            {
                if (r >= 0 && r < 16 && c >= 0 && c < 16)
                {
                    return _Field[r, c];
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                if (r >= 0 && r < 16 && c >= 0 && c < 16)
                {
                    _Field[r, c] = value;
                }
            }
        }

        

        public bool CanBePaintedBy(IPaintGame painter)
        {
            return painter is C_IPaintMinesweeper;

        }
    }
    */
    
    public class Segment
    {
        int Mine = 0;
        int state = 0; //State 0 für zugedeckt /State 1 für Markiert /State 2 für aufgedeckt

        public int CheckMine()
        {
            if (Mine == 1)
            {
                return Mine;
            }
            else { return 0; }

        }
        /*
        public int CountMines(int x, int y)
        {
            int count = 0;
            for (int r = 0; r < 3; r++)
            {
                for (int c = 0; c < 3; c++)
                {
                    if (_Field[x - 1 + r, y - 1 + c].Segment.CheckMine() == 1)
                    {
                        count++;
                    }
                }
            }
            return count;
        }
        */
    }

}
    
