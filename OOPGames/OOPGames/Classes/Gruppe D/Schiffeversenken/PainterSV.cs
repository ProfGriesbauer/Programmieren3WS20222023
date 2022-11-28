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

        public void PaintShipField(Canvas canvas, IGameField currentField, int GamePhase)
        {
            if (GamePhase == 1 || GamePhase == 2)
            {
                canvas.Children.Clear();
                Color bgColor = Color.FromRgb(255, 255, 255);
                canvas.Background = new SolidColorBrush(bgColor);
                Color lineColor = Color.FromRgb(0, 0, 0);
                Brush lineStroke = new SolidColorBrush(lineColor);

                for (int x=10; x<=400; x=x+20)
                {
                    for (int y = 10; y <= 400; y = y + 20)
                    {
                        Line l = new Line() { X1 = x, Y1 = y, X2 = 120+x, Y2 = 320+y, Stroke = lineStroke, StrokeThickness = 3.0 };
                        canvas.Children.Add(l);
                    }

                }
                
            }
            
            if (GamePhase == 3) 
            { 

            }
        }
    }

}
