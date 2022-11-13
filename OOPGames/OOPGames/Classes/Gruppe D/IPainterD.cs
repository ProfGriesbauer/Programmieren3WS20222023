using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Ink;
using System.Windows.Media;
using System.Windows.Shapes;

namespace OOPGames.Classes.Gruppe_D
{
    public class PainterD : IPaintTicTacToe
    {
        public string Name { get { return "DerKrasseMaler"; } }

        public void PaintGameField(Canvas canvas, IGameField currentField)
        {
            throw new NotImplementedException();
        }

        public void PaintTicTacToeField(Canvas canvas, ITicTacToeField currentField)
        {
            canvas.Children.Clear();

            Color Black = Color.FromRgb(255, 255, 255);
            Brush lineColor = new SolidColorBrush(Black);

            Color P1 = Color.FromRgb(0, 0, 255);
            Brush P1Color = new SolidColorBrush(P1);

            Color P2 = Color.FromRgb(255, 0, 0);
            Brush P2Color = new SolidColorBrush(P2);

            Line l1 = new Line() { X1 = 120, Y1 = 20, X2 = 120, Y2 = 320, Stroke = lineColor, StrokeThickness = 3.0 };
            canvas.Children.Add(l1);

            Line l2 = new Line() { X1 = 170, Y1 = 20, X2 = 170, Y2 = 320, Stroke = lineColor, StrokeThickness = 3.0 };
            canvas.Children.Add(l2);

            Line l3 = new Line() { X1 = 120, Y1 = 70, X2 = 170, Y2 = 70, Stroke = lineColor, StrokeThickness = 3.0 };
            canvas.Children.Add(l3);

            Line l4 = new Line() { X1 = 120, Y1 = 90, X2 = 170, Y2 = 90, Stroke = lineColor, StrokeThickness = 3.0 };
            canvas.Children.Add(l4);

            for (int i = 0; i < 3; i++ )
            {
                for (int j = 0; j < 3; j++)
                {
                    if (currentField[i, j] == 1)
                    {
                        Ellipse ellipse = new Ellipse() { Margin = new Thickness(20 + (j * 100), 20 + (i * 100), 0, 0), Width = 100, Height = 100, Stroke = P1Color, StrokeThickness = 3.0 };
                        canvas.Children.Add(ellipse);
                    }
                    if (currentField[i, j] == 2)
                    {
                        Line X1 = new Line() { X1 = 20 + (j * 100), Y1 = 20 + (i * 100), X2 = 120 + (j * 100), Y2 = 120 + (i * 100), Stroke = P2Color, StrokeThickness = 3.0 };
                        canvas.Children.Add(X1);
                        Line X2 = new Line() { X1 = 20 + (j * 100), Y1 = 120 + (i * 100), X2 = 120 + (j * 100), Y2 = 20 + (i * 100), Stroke = P2Color, StrokeThickness = 3.0 };
                        canvas.Children.Add(X2);
                    }
                }
            }
        }
    }
}
