using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Ink;
using System.Windows.Media;
using System.Windows.Shapes;

namespace OOPGames.Classes.GruppeI
{
    public class PainterI : IPaintTicTacToe
    {
        public string Name { get { return "Painter Gruppe I"; } }


        public void PaintGameField(Canvas canvas, IGameField currentField)
        {
            if (currentField is IGameField)
            {
                PaintTicTacToeField(canvas, (ITicTacToeField)currentField);
            }
        }


        public void PaintTicTacToeField(Canvas canvas, ITicTacToeField currentField)
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
            //int StrokeThickness_P1 = 3;
            //int StrokeThickness_P2=3;
            //Einführen eines skalaren Faktors, um die Entwicklung zu vereinfachen (hiermit kann die Größe des Feldes inklusive aller Eingaben skaliert werden, somit können wir die Größe des Feldes für perfekte Anf)
            //int skalar=20;


            void paintLine (int X1, int Y1, int X2, int Y2, float thickness) //Funktion vereinfacht das Zeichnen von Linien
            {
                Line lx = new Line() { X1 = X1, Y1 = Y1, X2 = X2, Y2 = Y2, Stroke=lineStroke, StrokeThickness= thickness };
                canvas.Children.Add(lx);
            }

            //kleine Felder zeichnen
            //waagrechte Linien
            for (int i = 20; i <= 560; i += 60)
            {
                paintLine(20, i, 560, i, 2);
            }
            //senkrechte Linien
            for (int i = 20; i <= 560; i += 60)
            {
                paintLine(i, 20, i, 560, 2);
            }

            //Zeichne großes TTT-Feld
            paintLine(20,20,20,560,StrokeThickness_GrFe);
            paintLine(200,20,200,560,StrokeThickness_GrFe);
            paintLine(380,20,380,560,StrokeThickness_GrFe);
            paintLine(560,20,560,560,StrokeThickness_GrFe);

            paintLine(20,20,560,20, StrokeThickness_GrFe);
            paintLine(20,200,560,200, StrokeThickness_GrFe);
            paintLine(20,380,560,380, StrokeThickness_GrFe);
            paintLine(20,560,560,560, StrokeThickness_GrFe);

            //Kreuze und Kreise zeichnen                    //vllt noch andere Formen?
            IBigTicTacToeField bigfield = null;
            if (currentField is IBigTicTacToeField)
            {
                bigfield = (IBigTicTacToeField)currentField;
                for (int t = 0; t < 9; t++)
                { 
                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            if (bigfield.SubFields[t][i, j] == 1) //kleine Kreuze zeichnen
                            {
                                //using (var soundPlayer = new SoundPlayer("Assets\I\interface-1-126517.wav"))
                                //       {
                                //           soundPlayer.Play(); // can also use soundPlayer.PlaySync()
                                //       }
                                //using (var soundPlayer = new SoundPlayer("Assets\I\click-47609.wav"))
                                //       {
                                //           soundPlayer.Play(); // can also use soundPlayer.PlaySync()
                                //       }
                                //using (var soundPlayer = new SoundPlayer("Assets\I\notification-1-126509.wav"))
                                //       {
                                //           soundPlayer.Play(); // can also use soundPlayer.PlaySync()
                                //       }

                                Line X1 = new Line() { X1 = 20 + (60 * j), Y1 = 20 + (60 * i), X2 = 80 + (60 * j), Y2 = 80 + (60 * i), Stroke = XStroke, StrokeThickness = StrokeThickness_KlFe };
                                canvas.Children.Add(X1);
                                Line X2 = new Line() { X1 = 20 + (60 * j), Y1 = 80 + (60 * i), X2 = 80 + (60 * j), Y2 = 20 + (60 * i), Stroke = XStroke, StrokeThickness = StrokeThickness_KlFe };
                                canvas.Children.Add(X2);
                            }
                            else if (bigfield.SubFields[t][i, j] == 2) //kleine Rechtecke zeichnen 
                            {
                                Rectangle OE = new Rectangle() { Margin = new Thickness(25 + (60 * j), 25 + (60 * i), 0, 0), Width = 50, Height = 50, Stroke = OStroke, StrokeThickness = StrokeThickness_KlFe };
                                canvas.Children.Add(OE);
                            }
                            else if (bigfield.SubFields[t][i, j] == 3) //große Kreuze zeichnen
                            {
                                Line X1 = new Line() { X1 = 20 + (180 * j), Y1 = 20 + (180 * i), X2 = 200 + (180 * j), Y2 = 200 + (180 * i), Stroke = XStroke, StrokeThickness = StrokeThickness_GrX };
                                canvas.Children.Add(X1);
                                Line X2 = new Line() { X1 = 20 + (180 * j), Y1 = 200 + (180 * i), X2 = 200 + (180 * j), Y2 = 20 + (180 * i), Stroke = XStroke, StrokeThickness = StrokeThickness_GrX };
                                canvas.Children.Add(X2);
                            }
                            else if (bigfield.SubFields[t][i, j] == 4) //große Rechtecke zeichnen 
                            {
                                Rectangle OE = new Rectangle() { Margin = new Thickness(20 + (180 * j), 20 + (180 * i), 0, 0), Width = 180, Height = 180, Stroke = OStroke, StrokeThickness = StrokeThickness_GrO };
                                canvas.Children.Add(OE);
                            }
                            else if (bigfield.SubFields[t][i, j] == 5) //Unentschieden zeichnen 
                            {
                                Ellipse OE = new Ellipse() { Margin = new Thickness(20 + (180 * j), 20 + (180 * i), 0, 0), Width = 180, Height = 180, Stroke = UStroke, StrokeThickness = StrokeThickness_GrO };
                                canvas.Children.Add(OE);
                            }
                        }

                    }
                }
            }
        }

    }
}
