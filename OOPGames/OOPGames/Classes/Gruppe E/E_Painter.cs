using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace OOPGames.Classes.Gruppe_E
{
    public class Painter: IPaintTicTacToe    {
        public string Name { get; set; }

        public void PaintTicTacToeField(Canvas canvas, ITicTacToeField currentField)
        {
            throw new NotImplementedException();
        }

        public void PaintGameField(Canvas canvas, IGameField currentField)
        {//PaintTicTacToeField(canvas, ())
            throw new NotImplementedException();
        }

       // public 
    }
}
