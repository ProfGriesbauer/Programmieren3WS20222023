using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace OOPGames.Classes.Gruppe_K
{
    internal class K_Painter_JG : IPaintTicTacToe
    {
        public string Name { get { return "K Painter JG"; } }

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

            Color bgColor = Color.FromRgb(0, 0, 0);
            canvas.Background = new SolidColorBrush(bgColor);
            Color lineColor = Color.FromRgb(0, 255, 0);
            Brush lineStroke = new SolidColorBrush(lineColor);

            Color player1Color = Color.FromRgb(0, 255, 2);
            Brush player1Stroke = new SolidColorBrush(player1Color);
            Color player2Color = Color.FromRgb(0, 255, 0);
            Brush player2Stroke = new SolidColorBrush(player2Color);

            Line l1 = new Line() { X1 = 120, Y1 = 20, X2 = 120, Y2 = 320, Stroke = lineStroke, StrokeThickness = 10.0 };
            canvas.Children.Add(l1);
            Line l2 = new Line() { X1 = 220, Y1 = 20, X2 = 220, Y2 = 320, Stroke = lineStroke, StrokeThickness = 10.0 };
            canvas.Children.Add(l2);
            Line l3 = new Line() { X1 = 20, Y1 = 120, X2 = 320, Y2 = 120, Stroke = lineStroke, StrokeThickness = 10.0 };
            canvas.Children.Add(l3);
            Line l4 = new Line() { X1 = 20, Y1 = 220, X2 = 320, Y2 = 220, Stroke = lineStroke, StrokeThickness = 10.0 };
            canvas.Children.Add(l4);


            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (currentField[i, j] == 1)
                    {
                        Line t1 = new Line() { X1 = 50 + j * 100, X2 = 90 + j * 100, Y1 = 95 + i * 100, Y2 = 95 + i * 100, Stroke = player2Stroke, StrokeThickness = 10.0 };
                        Line t2 = new Line() { X1 = 50 + j * 100, X2 = 90 + j * 100, Y1 = 45 + i * 100, Y2 = 45 + i * 100, Stroke = player2Stroke, StrokeThickness = 10.0 };
                        Line t3 = new Line() { X1 = 45 + j * 100, X2 = 45 + j * 100, Y1 = 50 + i * 100, Y2 = 90 + i * 100, Stroke = player2Stroke, StrokeThickness = 10.0 };
                        Line t4 = new Line() { X1 = 95 + j * 100, X2 = 95 + j * 100, Y1 = 50 + i * 100, Y2 = 90 + i * 100, Stroke = player2Stroke, StrokeThickness = 10.0 };

                        canvas.Children.Add(t1);
                        canvas.Children.Add(t2);
                        canvas.Children.Add(t3);
                        canvas.Children.Add(t4);

                    }
                    else if (currentField[i, j] == 2)
                    {

                        Line t5 = new Line() { X1 = 70 + j * 100, X2 = 70 + j * 100, Y1 = 40 + i * 100, Y2 = 100 + i * 100, Stroke = player2Stroke, StrokeThickness = 10.0 };
                        Line t6 = new Line() { X1 = 40 + j * 100, X2 = 100 + j * 100, Y1 = 70 + i * 100, Y2 = 70 + i * 100, Stroke = player2Stroke, StrokeThickness = 10.0 };

                        canvas.Children.Add(t5);
                        canvas.Children.Add(t6);

                    }
                }
            }
        }
    }
}
