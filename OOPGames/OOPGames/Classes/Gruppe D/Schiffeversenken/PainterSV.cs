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

namespace OOPGames.Classes.Gruppe_D.Schiffeverseanken
{
    internal class PainterSV : IPaintSV
    {
        public string Name { get { return "SiffeverseankenPainterD"; } }

        public void PaintGameField(Canvas canvas, IGameField currentField)
        {
            if (currentField is IFieldSV)
            {
                PaintShipField(canvas, (IFieldSV)currentField);
            }
        }

        public void PaintShip(Canvas canvas, int Ship, int x, int y, int HorVer)
        {
            Color lineColor = Color.FromRgb(0, 0, 0);
            Brush lineStroke = new SolidColorBrush(lineColor);
            int _x = x;
            int _HorVer = 0;
            if (_HorVer == 1)
            {
                for (int i = 0; i < Ship; i += 1)
                {
                    Line l1 = new Line() { X1 = _x, Y1 = y, X2 = _x + 50, Y2 = y, Stroke = lineStroke, StrokeThickness = 3.0 };
                    Line l2 = new Line() { X1 = _x, Y1 = y, X2 = _x, Y2 = y + 50, Stroke = lineStroke, StrokeThickness = 3.0 };
                    Line l3 = new Line() { X1 = _x, Y1 = y + 50, X2 = _x + 50, Y2 = y + 50, Stroke = lineStroke, StrokeThickness = 3.0 };
                    Line l4 = new Line() { X1 = _x + 50, Y1 = y, X2 = _x + 50, Y2 = y + 50, Stroke = lineStroke, StrokeThickness = 3.0 };
                    if (i == 0)
                    {
                        canvas.Children.Add(l4);
                    }
                    if (i == Ship - 1)
                    {
                        canvas.Children.Add(l2);
                    }
                    if (i != 0 && i != Ship - 1)
                    {
                        canvas.Children.Add(l1);
                        canvas.Children.Add(l2);
                        canvas.Children.Add(l3);
                        canvas.Children.Add(l4);
                    }

                    _x = _x + 50;
                }

                Line l5 = new Line() { X1 = x, Y1 = y + 25, X2 = x + 50, Y2 = y, Stroke = lineStroke, StrokeThickness = 3.0 };
                Line l6 = new Line() { X1 = x, Y1 = y + 25, X2 = x + 50, Y2 = y + 50, Stroke = lineStroke, StrokeThickness = 3.0 };

                Line l7 = new Line() { X1 = x + (Ship * 50), Y1 = y + 25, X2 = x + (Ship * 50) - 50, Y2 = y, Stroke = lineStroke, StrokeThickness = 3.0 };
                Line l8 = new Line() { X1 = x + (Ship * 50), Y1 = y + 25, X2 = x + (Ship * 50) - 50, Y2 = y + 50, Stroke = lineStroke, StrokeThickness = 3.0 };
                canvas.Children.Add(l5);
                canvas.Children.Add(l6);
                canvas.Children.Add(l7);
                canvas.Children.Add(l8);
            } else if (_HorVer ==2)
            {
                for (int i = 0; i < Ship; i += 1)
                {
                    Line l1 = new Line() { X1 = _x, Y1 = y, X2 = _x + 50, Y2 = y, Stroke = lineStroke, StrokeThickness = 3.0 };
                    Line l2 = new Line() { X1 = _x, Y1 = y, X2 = _x, Y2 = y + 50, Stroke = lineStroke, StrokeThickness = 3.0 };
                    Line l3 = new Line() { X1 = _x, Y1 = y + 50, X2 = _x + 50, Y2 = y + 50, Stroke = lineStroke, StrokeThickness = 3.0 };
                    Line l4 = new Line() { X1 = _x + 50, Y1 = y, X2 = _x + 50, Y2 = y + 50, Stroke = lineStroke, StrokeThickness = 3.0 };
                    if (i == 0)
                    {
                        canvas.Children.Add(l4);
                    }
                    if (i == Ship - 1)
                    {
                        canvas.Children.Add(l2);
                    }
                    if (i != 0 && i != Ship - 1)
                    {
                        canvas.Children.Add(l1);
                        canvas.Children.Add(l2);
                        canvas.Children.Add(l3);
                        canvas.Children.Add(l4);
                    }

                    _x = _x + 50;
                }

                Line l5 = new Line() { X1 = x, Y1 = y + 25, X2 = x + 50, Y2 = y, Stroke = lineStroke, StrokeThickness = 3.0 };
                Line l6 = new Line() { X1 = x, Y1 = y + 25, X2 = x + 50, Y2 = y + 50, Stroke = lineStroke, StrokeThickness = 3.0 };

                Line l7 = new Line() { X1 = x + (Ship * 50), Y1 = y + 25, X2 = x + (Ship * 50) - 50, Y2 = y, Stroke = lineStroke, StrokeThickness = 3.0 };
                Line l8 = new Line() { X1 = x + (Ship * 50), Y1 = y + 25, X2 = x + (Ship * 50) - 50, Y2 = y + 50, Stroke = lineStroke, StrokeThickness = 3.0 };
                canvas.Children.Add(l5);
                canvas.Children.Add(l6);
                canvas.Children.Add(l7);
                canvas.Children.Add(l8);

            }
        }

        public void PaintShipField(Canvas canvas, IFieldSV currentField)
        {
            int GamePhase = currentField.Phase;
            int _Ship = currentField.Ships(1, 2);
            int _CurrenPlayer = 0;

            if (GamePhase == 1 || GamePhase == 2)
            {
                string _player = "";
                if(GamePhase == 2)
                {
                    _player = "P2";
                    _CurrenPlayer = 2;
                }
                else { _player = "P1"; _CurrenPlayer = 1; }

                canvas.Children.Clear();
                Color bgColor = Color.FromRgb(255, 255, 255);
                canvas.Background = new SolidColorBrush(bgColor);
                Color lineColor = Color.FromRgb(0, 0, 0);
                Brush lineStroke = new SolidColorBrush(lineColor);

                TextBlock textP1 = new TextBlock();
                textP1.Text = _player;
                textP1.Foreground = new SolidColorBrush(lineColor);
                textP1.FontSize = 40;
                Canvas.SetLeft(textP1, 200);
                Canvas.SetTop(textP1, 0);
                canvas.Children.Add(textP1);

                for (int x = 20; x <= 420; x = x + 50)
                {
                    Line l = new Line() { X1 = x, Y1 = 50, X2 = x, Y2 = 450, Stroke = lineStroke, StrokeThickness = 3.0 };
                    canvas.Children.Add(l);
                }
                for (int y = 50; y <= 450; y = y + 50)
                {
                    Line l = new Line() { X1 = 20, Y1 = y, X2 = 420, Y2 = y , Stroke = lineStroke, StrokeThickness = 3.0 };
                    canvas.Children.Add(l);
                }

                TextBlock text = new TextBlock();
                text.Text = "current Ship";
                text.Foreground = new SolidColorBrush(lineColor);
                text.FontSize = 30;
                Canvas.SetLeft(text, 20);
                Canvas.SetTop(text, 455);
                canvas.Children.Add(text);

                PaintShip(canvas, currentField.Ships(2, _CurrenPlayer) , 20, 505, 2
                    );
                
            }

            if (GamePhase == 3)
            {
                canvas.Children.Clear();
                Color bgColor = Color.FromRgb(255, 255, 255);
                canvas.Background = new SolidColorBrush(bgColor);
                Color lineColor = Color.FromRgb(0, 0, 0);
                Brush lineStroke = new SolidColorBrush(lineColor);
                Color redC = Color.FromRgb(255, 0, 0);
                Brush red = new SolidColorBrush(redC);
                Color blueC = Color.FromRgb(0, 0, 255);
                Brush blue = new SolidColorBrush(blueC);    


                TextBlock textP1 = new TextBlock();
                textP1.Text = "P1 ";
                textP1.Foreground = new SolidColorBrush(lineColor);
                textP1.FontSize = 40;
                Canvas.SetLeft(textP1, 200);
                Canvas.SetTop(textP1, 0);
                canvas.Children.Add(textP1);

                TextBlock textP2 = new TextBlock();
                textP2.Text = "P2 ";
                textP2.Foreground = new SolidColorBrush(lineColor);
                textP2.FontSize = 40;
                Canvas.SetLeft(textP2, 630);
                Canvas.SetTop(textP2, 0);
                canvas.Children.Add(textP2);


                for (int x = 20; x <= 420; x = x + 50)
                {
                    Line l = new Line() { X1 = x, Y1 = 50, X2 = x, Y2 = 450, Stroke = lineStroke, StrokeThickness = 3.0 };
                    canvas.Children.Add(l);
                }
                for (int y = 50; y <= 450; y = y + 50)
                {
                    Line l = new Line() { X1 = 20, Y1 = y, X2 = 420, Y2 = y, Stroke = lineStroke, StrokeThickness = 3.0 };
                    canvas.Children.Add(l);
                }

                for (int x = 450; x <= 850; x = x + 50)
                {
                    Line l = new Line() { X1 = x, Y1 = 50, X2 = x, Y2 = 450, Stroke = lineStroke, StrokeThickness = 3.0 };
                    canvas.Children.Add(l);
                }
                for (int y = 50; y <= 450; y = y + 50)
                {
                    Line l = new Line() { X1 = 450, Y1 = y, X2 = 850, Y2 = y, Stroke = lineStroke, StrokeThickness = 3.0 };
                    canvas.Children.Add(l);
                }
                /* for Painting Test
                currentField[1, 1, 4] = 1;
                currentField[5, 7, 4] = 2;

                currentField[7, 3, 3] = 1;
                currentField[3, 7, 3] = 2;
                */
                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        if (currentField[i, j, 3] == 1)
                        {
                            Line X1 = new Line() { X1 = 20 + (j * 50), Y1 = 50 + (i * 50), X2 = 70 + (j * 50), Y2 = 100 + (i * 50), Stroke = red, StrokeThickness = 3.0 };
                            canvas.Children.Add(X1);
                            Line X2 = new Line() { X1 = 70 + (j * 50), Y1 = 50 + (i * 50), X2 = 20 + (j * 50), Y2 = 100 + (i * 50), Stroke = red, StrokeThickness = 3.0 };
                            canvas.Children.Add(X2);
                        }
                        if (currentField[i, j, 3] == 2)
                        {
                            Line X1 = new Line() { X1 = 20 + (j * 50), Y1 = 50 + (i * 50), X2 = 70 + (j * 50), Y2 = 100 + (i * 50), Stroke = blue, StrokeThickness = 3.0 };
                            canvas.Children.Add(X1);
                            Line X2 = new Line() { X1 = 70 + (j * 50), Y1 = 50 + (i * 50), X2 = 20 + (j * 50), Y2 = 100 + (i * 50), Stroke = blue, StrokeThickness = 3.0 };
                            canvas.Children.Add(X2);
                        }
                    }
                }
                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        if (currentField[i, j, 4] == 1)
                        {
                            Line X1 = new Line() { X1 = 450 + (j * 50), Y1 = 50 + (i * 50), X2 = 500 + (j * 50), Y2 = 100 + (i * 50), Stroke = red, StrokeThickness = 3.0 };
                            canvas.Children.Add(X1);
                            Line X2 = new Line() { X1 = 500 + (j * 50), Y1 = 50 + (i * 50), X2 = 450 + (j * 50), Y2 = 100 + (i * 50), Stroke = red, StrokeThickness = 3.0 };
                            canvas.Children.Add(X2);
                        }
                        if (currentField[i, j, 4] == 2)
                        {
                            Line X1 = new Line() { X1 = 450 + (j * 50), Y1 = 50 + (i * 50), X2 = 500 + (j * 50), Y2 = 100 + (i * 50), Stroke = blue, StrokeThickness = 3.0 };
                            canvas.Children.Add(X1);
                            Line X2 = new Line() { X1 = 500 + (j * 50), Y1 = 50 + (i * 50), X2 = 450 + (j * 50), Y2 = 100 + (i * 50), Stroke = blue, StrokeThickness = 3.0 };
                            canvas.Children.Add(X2);
                        }
                    }
                }
            }
        }
    }
}
