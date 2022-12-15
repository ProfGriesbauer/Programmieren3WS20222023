using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;

namespace OOPGames.Classes.GruppeI
{
    public interface I_ISubField : ITicTacToeField
    {
        int Nummer { get; }
        int X { get; }
        int Y { get; }
        int SX { get; }
        int SY { get; }
        bool Active { get; set; }
        int WonByPlayer { get; set; }
    }

    public class ISubField : I_ISubField
    {
        int[,] _SubField = new int[3, 3] { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } };

        int nummer, x, y, sx, sy, wonByPlayer;
        bool active;                //wird Feld gerade gespielt oder nicht

        public ISubField(int nummer, int x, int y, int sx, int sy, bool active)
        {
            this.nummer = nummer;
            this.x = x;
            this.y = y;
            this.sx = sx;
            this.sy = sy;
            this.active = active;
            this.wonByPlayer = 0;
        }

        public int Nummer { get { return nummer; } }
        public int X { get { return x; } }
        public int Y { get { return y; } }
        public int SX { get { return sx; } }
        public int SY { get { return sy; } }
        public bool Active
        {
            get { return active; }
            set { active = value; }
        }
        public int WonByPlayer
        {
            get { return wonByPlayer; }
            set { wonByPlayer = value; }
        }

        public int this[int r, int c]
        {
            get
            {
                if (r >= 0 && r < 3 && c >= 0 && c < 3) //ist das überhaupt möglich-Abfrage
                {
                    return _SubField[r, c];
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
                    _SubField[r, c] = value;
                }
            }
        }

        public bool CanBePaintedBy(IPaintGame painter)
        {
            return painter is IPaintTicTacToe;
        }
    }

    public class IBigTicTacToeField : ITicTacToeField
    {
        IList<I_ISubField> _SubField = new List<I_ISubField>();
        public IList<I_ISubField> SubFields { get { return _SubField; } }

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
            SubFields.Add(new ISubField(0, 20, 20, 180, 180, true));
            SubFields.Add(new ISubField(1, 200, 20, 180, 180, true));
            SubFields.Add(new ISubField(2, 380, 20, 180, 180, true));
            SubFields.Add(new ISubField(3, 20, 200, 180, 180, true));
            SubFields.Add(new ISubField(4, 200, 200, 180, 180, true));
            SubFields.Add(new ISubField(5, 380, 200, 180, 180, true));
            SubFields.Add(new ISubField(6, 20, 380, 180, 180, true));
            SubFields.Add(new ISubField(7, 200, 380, 180, 180, true));
            SubFields.Add(new ISubField(8, 380, 380, 180, 180, true));
            //SubFields.Add(new ISubField(9, 20, 20, 540, 540, false));  //subfield, das quasi unser Bigfield darstellt
        }

        public bool CanBePaintedBy(IPaintGame painter)
        {
            return painter is IPaintTicTacToe;
        }
    }
}