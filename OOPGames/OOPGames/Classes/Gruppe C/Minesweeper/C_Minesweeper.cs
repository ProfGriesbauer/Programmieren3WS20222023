using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

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

    public class C_MPainter : C_IPaintMinesweeper

        public void C_IPaintMinesweeper(Canvas canvas, C_MinesweeperField currentField)
    {
        canvas.Children.Clear();
        Color bgColor = Color.FromRgb(255, 255, 255);
        canvas.Background = new SolidColorBrush(bgColor);
        Color lineColor = Color.FromRgb(0, 0, 0);
        Brush lineStroke = new SolidColorBrush(lineColor);

        int h = 30;

        for (int i = 0; i < 16; i++)
        {
            Line li = new Line() { X1 = 20, Y1 = 20 + i * h, X2 = 500, Y2 = 20 + i * h, Stroke = lineStroke, StrokeThickness = 1.0 };
            Canvas.Children.Add(l i);
            Line lb = new Line() { X1 = 20 + i * h, Y1 = 20, X2 = 20 + i * h, Y2 = 500, Stroke = lineStroke, StrokeThickness = 1.0 };
            Canvas.Children.Add(l 16 + i);

        }
    }

}
<<<<<<< HEAD
    
=======
 
>>>>>>> 3c7d154ae5c7da0c47acdf7d4d7d3a183ac57a4e
