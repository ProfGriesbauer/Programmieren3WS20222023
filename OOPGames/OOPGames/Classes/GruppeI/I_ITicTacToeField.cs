using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPGames.Classes.GruppeI
{
    public interface I_ISubField : ITicTacToeField
    {

    }

    public class SubField : I_ISubField
    {
        int nummer, x, y, sx, sy;

        public SubField(int nummer, int x, int y, int sx, int sy)
        {
            this.nummer = nummer;
            this.x = x;
            this.y = y;
            this.sx = sx;
            this.sy = sy;
        }
    }

    public class I_NewTicTacToeField: ITicTacToeField
    {
        IList<I_ISubField> SubFields { get; }

        public int this[int r, int c] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public I_NewTicTacToeField()
        {
            SubFields.Add(new SubField(1,0,0,100,100));
        }

        public bool CanBePaintedBy(IPaintGame painter)
        {
            throw new NotImplementedException();
        }
    }
}
