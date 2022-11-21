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

namespace OOPGames.Classes.GruppeI
{
    public class PainterI : BaseTicTacToePaint
    {
        public override string Name { get { return "Painter Gruppe I"; } }

        public override void PaintTicTacToeField(Canvas canvas, ITicTacToeField currentField)
        {
            canvas.Children.Clear();
            Color bgColor = Color.FromRgb(135, 206, 250);
            canvas.Background = new SolidColorBrush(bgColor);
            Color lineColor = Color.FromRgb(0, 0, 0);
            Brush lineStroke = new SolidColorBrush(lineColor);
            Color XColor = Color.FromRgb(0, 255, 0);
            Brush XStroke = new SolidColorBrush(XColor);
            Color OColor = Color.FromRgb(0, 0, 255);
            Brush OStroke = new SolidColorBrush(OColor);
            Color UColor = Color.FromRgb(133, 133, 133);
            Brush UStroke = new SolidColorBrush(UColor);

            //Liniendicken festlegen
            int StrokeThickness_GrX = 12;
            int StrokeThickness_GrO = 12;
            int StrokeThickness_GrFe = 6;
            int StrokeThickness_KlFe = 3;
            int StrokeThickness_P1 = 3;
            int StrokeThickness_P2=3;
            //Einführen eines skalaren Faktors, um die Entwicklung zu vereinfachen (hiermit kann die Größe des Feldes inklusive aller Eingaben skaliert werden, somit können wir die Größe des Feldes für perfekte Anf)
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
            paintLine(1,1,1,28,StrokeThickness_GrFe);
            paintLine(10,1,10,28,StrokeThickness_GrFe);
            paintLine(19,1,19,28,StrokeThickness_GrFe);
            paintLine(28,1,28,28,StrokeThickness_GrFe);

            paintLine(1,1,28,1, StrokeThickness_GrFe);
            paintLine(1,10,28,10, StrokeThickness_GrFe);
            paintLine(1,19,28,19, StrokeThickness_GrFe);
            paintLine(1,28,28,28, StrokeThickness_GrFe);

            //Kreuze und Kreise zeichnen                    //vllt noch andere Formen?

            for (int i = 0; i < 27; i++)
            {
                for (int j = 0; j < 27; j++)
                {
                    if (currentField[i, j] == 1) //Kreuze zeichnen
                    {
                        Line X1 = new Line() { X1 = skalar + (3*j * skalar), Y1 = skalar + (3*i * skalar), X2 = 4*skalar + (3*j * skalar), Y2 = 4*skalar + (3*i * skalar), Stroke = XStroke, StrokeThickness = StrokeThickness_KlFe };
                        canvas.Children.Add(X1);
                        Line X2 = new Line() { X1 = skalar + (3*j * skalar), Y1 = 4*skalar + (3*i * skalar), X2 = 4*skalar + (3*j * skalar), Y2 = skalar + (3*i * skalar), Stroke = XStroke, StrokeThickness = StrokeThickness_KlFe };
                        canvas.Children.Add(X2);
                    }
                    else if (currentField[i, j] == 2) //Rechtecke zeichnen 
                    {
                        Rectangle OE = new Rectangle() { Margin = new Thickness(25 + (3*j * skalar), 25 + (3*i * skalar), 0, 0), Width = 50, Height = 50, Stroke = OStroke, StrokeThickness = StrokeThickness_KlFe };
                        canvas.Children.Add(OE);
                    }
                    else if (currentField[i, j] == 3) //große Kreuze zeichnen
                    {
                        Line X1 = new Line() { X1 = skalar + (9 * j * skalar), Y1 = skalar + (9 * i * skalar), X2 = 10 * skalar + (9 * j * skalar), Y2 = 10 * skalar + (9 * i * skalar), Stroke = XStroke, StrokeThickness = StrokeThickness_GrX };
                        canvas.Children.Add(X1);
                        Line X2 = new Line() { X1 = skalar + (9 * j * skalar), Y1 = 10 * skalar + (9 * i * skalar), X2 = 10 * skalar + (9 * j * skalar), Y2 = skalar + (9 * i * skalar), Stroke = XStroke, StrokeThickness = StrokeThickness_GrX };
                        canvas.Children.Add(X2);
                    }
                    else if (currentField[i, j] == 4) //große Rechtecke zeichnen 
                    {
                        Rectangle OE = new Rectangle() { Margin = new Thickness(20 + (9 * j * skalar), 20 + (9 * i * skalar), 0, 0), Width = 180, Height = 180, Stroke = OStroke, StrokeThickness = StrokeThickness_GrO };
                        canvas.Children.Add(OE);
                    }
                    else if (currentField[i, j] == 5) //Unentschieden zeichnen 
                    {
                        Ellipse OE = new Ellipse() { Margin = new Thickness(20 + (9 * j * skalar), 20 + (9 * i * skalar), 0, 0), Width = 180, Height = 180, Stroke = UStroke, StrokeThickness = StrokeThickness_GrO };
                        canvas.Children.Add(OE);
                    }

                }
            }
        }

    }
}
