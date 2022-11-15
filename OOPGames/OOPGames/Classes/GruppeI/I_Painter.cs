using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace OOPGames.Classes.GruppeI
{
    public class PainterI : BaseTicTacToePaint
    {
        public override string Name { get { return "Painter Gruppe I"; } }

        public override void PaintTicTacToeField(Canvas canvas, ITicTacToeField currentField)
        {
            canvas.Children.Clear();
            Color bgColor = Color.FromRgb(255, 255, 255);
            canvas.Background = new SolidColorBrush(bgColor);
            Color lineColor = Color.FromRgb(0, 0, 0);
            Brush lineStroke = new SolidColorBrush(lineColor);
            Color XColor = Color.FromRgb(0, 255, 0);
            Brush XStroke = new SolidColorBrush(XColor);
            Color OColor = Color.FromRgb(0, 0, 255);
            Brush OStroke = new SolidColorBrush(OColor);
            int skalar=20;


            void paintLine (int X1, int Y1, int X2, int Y2, float thickness) //Funktion vereinfacht das Zeichnen von Linien
            {
                Line lx = new Line() { X1 = skalar*X1, Y1 = skalar*Y1, X2 = skalar*X2, Y2 = skalar*Y2, Stroke=lineStroke, StrokeThickness= thickness };
                canvas.Children.Add(lx);
            }

            //kleine Felder zeichnen
            //waagrechte Linien
            for (int i = 1; i <= 28; i += 3)
            {
                paintLine(1, i, 28, i, 3);
            }
            //senkrechte Linien
            for (int i = 1; i <= 28; i += 3)
            {
                paintLine(i, 1, i, 28, 3);
            }

            //Zeichne großes TTT-Feld
            paintLine(1,1,1,28,6);
            paintLine(10,1,10,28,6);
            paintLine(19,1,19,28,6);
            paintLine(28,1,28,28,6);

            paintLine(1,1,28,1,6);
            paintLine(1,10,28,10,6);
            paintLine(1,19,28,19,6);
            paintLine(1,28,28,28,6);

            //Kreuze und Kreise zeichnen

            for (int i = 0; i < 27; i++)
            {
                for (int j = 0; j < 27; j++)
                {
                    if (currentField[i, j] == 1)
                    {
                        Line X1 = new Line() { X1 = 20 + (3*j * skalar), Y1 = 20 + (3*i * skalar), X2 = 80 + (3*j * skalar), Y2 = 80 + (3*i * skalar), Stroke = XStroke, StrokeThickness = 3.0 };
                        canvas.Children.Add(X1);
                        Line X2 = new Line() { X1 = 20 + (3*j * skalar), Y1 = 80 + (3*i * skalar), X2 = 80 + (3*j * skalar), Y2 = 20 + (3*i * skalar), Stroke = XStroke, StrokeThickness = 3.0 };
                        canvas.Children.Add(X2);
                    }
                    else if (currentField[i, j] == 2)
                    {
                        Ellipse OE = new Ellipse() { Margin = new Thickness(25 + (3*j * skalar), 25 + (3*i * skalar), 0, 0), Width = 50, Height = 50, Stroke = OStroke, StrokeThickness = 3.0 };
                        canvas.Children.Add(OE);
                    }
                }
            }
        }



    }
}
