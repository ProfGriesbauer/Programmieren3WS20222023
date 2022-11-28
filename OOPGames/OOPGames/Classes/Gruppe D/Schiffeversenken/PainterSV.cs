using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace OOPGames.Classes.Gruppe_D.Schiffeverseanken
{
    internal class PainterSV : IPaintSV
    {
        public string Name { get { return "SiffeverseankenPainterD"; } }

        public void PaintGameField(Canvas canvas, IGameField currentField)
        {
            //???????
        }

        public void PaintShipField(Canvas canvas, IGameField currentField, int Phase)
        {
            if (Phase == 1 || Phase == 2)
            {
                canvas.Children.Clear();
                Color bgColor = Color.FromRgb(255, 255, 255);
                canvas.Background = new SolidColorBrush(bgColor);
                Color lineColor = Color.FromRgb(0, 0, 0);
                Brush lineStroke = new SolidColorBrush(lineColor);

                for (int i=100; i<=400; i=i+20)
                {
                    for (int k = 100; k <= 400; i = i + 20)
                    {
                        Line l1 = new Line() { X1 = 120, Y1 = 20, X2 = 120, Y2 = 320, Stroke = lineStroke, StrokeThickness = 3.0 };
                        canvas.Children.Add(l1);
                    }

                }
                
            }
            
            if (Phase == 3) 
            { 

            }
        }
    }

}
