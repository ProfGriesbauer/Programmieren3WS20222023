using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPGames.Classes.GruppeI
{
    public interface I_ISubField : ITicTacToeField
    {
        //kommt vlllt noch was
    }

    public class ISubField : I_ISubField
    {
        int nummer, x, y, sx, sy;

        public ISubField(int nummer, int x, int y, int sx, int sy)
        {
            this.nummer = nummer;
            this.x = x;
            this.y = y;
            this.sx = sx;
            this.sy = sy;
        }

        public int this[int r, int c] {
            get
            {
                if (r >= 0 && r < 3 && c >= 0 && c < 3)
                {
                    return this[r, c];
                }
                else
                {
                    return -1;
                }
            }
            set
            {
                if (r >= 0 && r < 3 && c >= 0 && c < 3)
                {
                    this.[r, c] = value;
                }
            }
        }

        public bool CanBePaintedBy(IPaintGame painter)
        {
            return painter is IPaintTicTacToe;
        }
    }

    public class IBigTicTacToeField: ITicTacToeField
    {
        IList<I_ISubField> SubFields { get; }

        public int this[int r, int c]       //nur oberes linkes Feld für dieses Interface (ITicTacToeField) zurückgeben (hoffe dann besteht Kompatibilität)
        {
            get
            {
                
                if (r >= 0 && r < 3 && c >= 0 && c < 3)
                {
                    return SubFields[0][r, c];
                }
                else
                {
                    return -1;
                }
            }
            set
            {
                if (r >= 0 && r < 3 && c >= 0 && c < 3)
                {
                    SubFields[0][r, c] = value;
                }
            }        
        }

        public IBigTicTacToeField()
        {
            SubFields.Add(new ISubField(0,20,20,180,180));
            SubFields.Add(new ISubField(1,200,20,180,180));
            SubFields.Add(new ISubField(2,380,20,180,180));
            SubFields.Add(new ISubField(3,20,200,180,180));
            SubFields.Add(new ISubField(4,200,200,180,180));
            SubFields.Add(new ISubField(5,380,200,180,180));
            SubFields.Add(new ISubField(6,20,380,180,180));
            SubFields.Add(new ISubField(7,200,380,180,180));
            SubFields.Add(new ISubField(8,380,380,180,180));
        }

        public bool CanBePaintedBy(IPaintGame painter)
        {
            return painter is IPaintTicTacToe;
        }
    }
}
