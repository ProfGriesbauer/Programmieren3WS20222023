using System;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Ink;
using System.Windows.Media;
using System.Windows.Shapes;

namespace OOPGames.Classes.Gruppe_B
{
    public class B_Painter : IPaintTicTacToe
    {
        private byte c1r;
        private byte c1g;
        private byte c1b;
        private byte c2r;
        private byte c2g;
        private byte c2b;

        public B_Painter()
        {
            Random rnd = new Random();
            c1r = (byte)rnd.Next(60, 255);
            c1g = (byte)rnd.Next(60, 255);
            c1b = (byte)rnd.Next(60, 255);

            c2r = (byte)rnd.Next(60, 255);
            c2g = (byte)rnd.Next(60, 255);
            c2b = (byte)rnd.Next(60, 255);
        }

        public string Name { get { return "GruppeBTicTacToePaint"; } }

        public void PaintGameField(Canvas canvas, IGameField currentField)
        {
            if (currentField is ITicTacToeField)
            {
                PaintTicTacToeField(canvas, (ITicTacToeField)currentField);
            }
        }

        public void PaintTicTacToeField(Canvas canvas, ITicTacToeField currentField)
        {
            
            canvas.Children.Clear();
            Color bgColor = Color.FromRgb(0,0,0);
            canvas.Background = new SolidColorBrush(bgColor);
            Color lineColor = Color.FromRgb(255,255,255);
            Brush lineStroke = new SolidColorBrush(lineColor);
            Color p1Color = Color.FromRgb(c1r, c1g, c1b);
            Brush p1Stroke = new SolidColorBrush(p1Color);
            Color p2Color = Color.FromRgb(c2r, c2g, c2b);
            Brush p2Stroke = new SolidColorBrush(p2Color);


            Line l1 = new Line() { X1 = 120, Y1 = 20, X2 = 120, Y2 = 320, Stroke = lineStroke, StrokeThickness = 3.0 };
            canvas.Children.Add(l1);
            Line l2 = new Line() { X1 = 220, Y1 = 20, X2 = 220, Y2 = 320, Stroke = lineStroke, StrokeThickness = 3.0 };
            canvas.Children.Add(l2);
            Line l3 = new Line() { X1 = 20, Y1 = 120, X2 = 320, Y2 = 120, Stroke = lineStroke, StrokeThickness = 3.0 };
            canvas.Children.Add(l3);
            Line l4 = new Line() { X1 = 20, Y1 = 220, X2 = 320, Y2 = 220, Stroke = lineStroke, StrokeThickness = 3.0 };
            canvas.Children.Add(l4);

            for (int i = 0; i<3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (currentField[i,j] == 1)
                    {
                        
                        Line t1 = new Line() { X1 = 70 + j * 100 -40, X2 = 70 + j* 100 + 40, Y1 = 70 + i* 100 + 35, Y2 = 70 + i * 100 + 35, Stroke = p2Stroke, StrokeThickness = 3.0};
                        Line t2 = new Line() { X1 = 70 + j * 100 - 40, X2 = 70 + j * 100, Y1 = 70 + i * 100 + 35, Y2 = 70 + i * 100 - 35, Stroke = p2Stroke, StrokeThickness = 3.0 };
                        Line t3 = new Line() { X1 = 70 + j * 100 + 40, X2 = 70 + j * 100, Y1 = 70 + i * 100 + 35, Y2 = 70 + i * 100 - 35, Stroke = p2Stroke, StrokeThickness = 3.0 };
                        canvas.Children.Add(t1);
                        canvas.Children.Add(t2);
                        canvas.Children.Add(t3);
                    }
                    else if (currentField[i,j] == 2)
                    {
                        Rectangle OE = new Rectangle() { Margin = new Thickness(30 + (j * 100), 30+ (i * 100), 0, 0), Width = 80, Height = 80, Stroke = p1Stroke, StrokeThickness = 3.0 };
                        canvas.Children.Add(OE);
                    }
                }
            }
        }
    }
}
