using OOPGames.Classes.Gruppe_K;
using System;
using System.Collections.Generic;
//using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Ink;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace OOPGames.Classes.Gruppe_D.Schiffeverseanken
{
    internal class PainterSV : IPaintSV
    {
        public string Name { get { return "SiffeverseankenPainterD"; } }

        void FindPlacedShips(Canvas canvas, int Player, IFieldSV currentField) //Phase 1 und 2
        {
            
            for (int r = 0; r < 8; r++)
            {
                for (int c = 0; c < 8; c++)
                {
                    if (currentField[r, c, Player] > 1)
                    {
                        if (currentField[r-1, c, Player] > 1) //wenn links ein Feld belegt ist wurde das Schiff schon gezeichnet
                        {
                            //_stop = 1;
                            continue;
                        }
                        if (currentField[r , c-1, Player] > 1) //wenn links ein Feld belegt ist wurde das Schiff schon gezeichnet
                        {
                            //_stop = 1;
                            continue;
                        }
                        int _Ship = 0;
                        int _Rotation = 0;
                        if (currentField[r+1, c, Player] > 1) //liegt das Schiff horizental?
                        { 
                            _Ship = currentField[r, c, Player];
                            _Rotation = 1;

                        }
                        else 
                        {
                            _Ship = currentField[r, c, Player];
                            _Rotation = 2;
                        }
                        int y = (50 * r) + 50;
                        int x = (50 * c) + 20 ;
                        PaintShip(canvas, _Ship, x, y, _Rotation, 0);
                    }
                }
            }

        }
        void Versenkt(Canvas canvas, int shoot, int Placed, IFieldSV currentField)
        {

            for (int r = 0; r < 8; r++)
            {
                for (int c = 0; c < 8; c++)
                {
                    if (currentField[r, c, Placed] > 1)
                    {
                        if (currentField[r - 1, c, Placed] > 1) //wenn links ein Feld belegt ist wurde das Schiff schon gezeichnet
                        {
                            //_stop = 1;
                            continue;
                        }
                        if (currentField[r, c - 1, Placed] > 1) //wenn links ein Feld belegt ist wurde das Schiff schon gezeichnet
                        {
                            //_stop = 1;
                            continue;
                        }
                        int _Ship = 0;
                        int _Rotation = 0;
                        if (currentField[r + 1, c, shoot] == 2) //liegt das Schiff horizental?
                        {
                            for (int i = 0; i < 5; i++)
                            {
                                if (currentField[r + i, c, shoot] == 2)
                                {
                                    _Ship++;
                                    _Rotation = 1;
                                }
                                else
                                {
                                    i = 5;
                                }
                            }
                        }
                        else
                        {
                            for (int i = 0; i < 5; i++)
                            {
                                if (currentField[r, c + i, shoot] == 2)
                                {
                                    _Ship++;
                                    _Rotation = 2;
                                }
                                else
                                {
                                    i = 5;
                                }
                            }
                        }
                        if (currentField[r, c, Placed] == _Ship)
                        {
                            int y = (50 * r) + 50;
                            int x = (50 * c) + 20;
                            /*int length = canvas.Children.Count;
                            canvas.Children.RemoveRange(length - (_Ship*2) ,length); */
                            if (Placed == 2)
                            {
                                PaintShip(canvas, _Ship, x, y, _Rotation, 1);
                            }
                            else
                            {
                                PaintShip(canvas, _Ship, x + 430, y, _Rotation, 1);
                            }
                            
                        }
                    }
                }
            }
            
        }

        public void PaintGameField(Canvas canvas, IGameField currentField)
        {
            if (currentField is IFieldSV)
            {
                PaintShipField(canvas, (IFieldSV)currentField);
            }
        }

        void PaintShip(Canvas canvas, int Ship, int x, int y, int _HorVer, int destroyed)
        {
            Color lineColor = Color.FromRgb(0, 0, 255);
            if (destroyed == 1)
            {
                lineColor = Color.FromRgb(255, 165, 0);
            }
            Brush lineStroke = new SolidColorBrush(lineColor);
            int _x = x;

            if (_HorVer == 2)
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

            } else if (_HorVer == 1)
            {
                int _y = y;
                for (int i = 0; i < Ship; i += 1)
                {
                    Line l1 = new Line() { X1 = x, Y1 = _y, X2 = x, Y2 = _y + 50, Stroke = lineStroke, StrokeThickness = 3.0 };
                    Line l2 = new Line() { X1 = x, Y1 = _y, X2 = x + 50, Y2 = _y , Stroke = lineStroke, StrokeThickness = 3.0 };
                    Line l3 = new Line() { X1 = x + 50, Y1 = _y, X2 = x + 50, Y2 = _y + 50, Stroke = lineStroke, StrokeThickness = 3.0 };
                    Line l4 = new Line() { X1 = x , Y1 = _y + 50, X2 = x + 50, Y2 = _y + 50, Stroke = lineStroke, StrokeThickness = 3.0 };
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

                    _y = _y + 50;
                }

                Line l5 = new Line() { X1 = x + 25, Y1 = y , X2 = x , Y2 = y + 50, Stroke = lineStroke, StrokeThickness = 3.0 };
                Line l6 = new Line() { X1 = x + 25, Y1 = y, X2 = x + 50, Y2 = y + 50, Stroke = lineStroke, StrokeThickness = 3.0 };

                Line l7 = new Line() { X1 = x + 25, Y1 = y + (Ship * 50), X2 = x , Y2 = y + (Ship * 50) - 50, Stroke = lineStroke, StrokeThickness = 3.0 };
                Line l8 = new Line() { X1 = x + 25  , Y1 = y + (Ship * 50), X2 = x + 50 , Y2 = y + (Ship * 50) - 50, Stroke = lineStroke, StrokeThickness = 3.0 };
                canvas.Children.Add(l5);
                canvas.Children.Add(l6);
                canvas.Children.Add(l7);
                canvas.Children.Add(l8);

            }
        }

        public void PaintShipField(Canvas canvas, IFieldSV currentField)
        {
            int GamePhase = currentField.Phase;
            //int _Ship = currentField.Ships(2, 2);

             

            int _Rotation = currentField.HorVer;
            int _CurrentPlayer = 0;

            canvas.Children.Clear();
            Color bgColor = Color.FromRgb(255, 255, 255);
            canvas.Background = new SolidColorBrush(bgColor);
            Color lineColor = Color.FromRgb(0, 0, 0);
            Brush lineStroke = new SolidColorBrush(lineColor);
            Color redC = Color.FromRgb(255, 0, 0);
            Brush red = new SolidColorBrush(redC);
            Color blueC = Color.FromRgb(0, 0, 255);
            Brush blue = new SolidColorBrush(blueC);


            if (GamePhase == 1 || GamePhase == 2)
            {
                string _player = "";
                if(GamePhase == 2)
                {
                    _player = "P2";
                    _CurrentPlayer = 2;
                }
                else { _player = "P1"; _CurrentPlayer = 1; }

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

                PaintShip(canvas, currentField.Ships(2, _CurrentPlayer), 20, 505, _Rotation, 0);

                if (_Rotation == 1)
                {
                    Ellipse ellipse = new Ellipse() { Margin = new Thickness(40, 500, 0, 0), Width = 10, Height = 10, Stroke = new SolidColorBrush(Color.FromRgb(255, 0, 0)), StrokeThickness = 3.0 };
                    canvas.Children.Add(ellipse);
                }
                else
                {
                    Ellipse ellipse = new Ellipse() { Margin = new Thickness(15, 525, 0, 0), Width = 10, Height = 10, Stroke = new SolidColorBrush(Color.FromRgb(255, 0, 0)), StrokeThickness = 3.0 };
                    canvas.Children.Add(ellipse);
                }

                FindPlacedShips(canvas, _CurrentPlayer, currentField);
                
            }

            if (GamePhase == 3)
            {

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

                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        
                        if (currentField[i, j, 3] == 2) // 2-> getroffen->rot
                        {
                            Line X1 = new Line() { X1 = 20 + (j * 50), Y1 = 50 + (i * 50), X2 = 70 + (j * 50), Y2 = 100 + (i * 50), Stroke = red, StrokeThickness = 3.0 };
                            canvas.Children.Add(X1);
                            Line X2 = new Line() { X1 = 70 + (j * 50), Y1 = 50 + (i * 50), X2 = 20 + (j * 50), Y2 = 100 + (i * 50), Stroke = red, StrokeThickness = 3.0 };
                            canvas.Children.Add(X2);

                            
                        }
                        if (currentField[i, j, 3] == 1) //1->daneben->blau
                        {
                            Line X1 = new Line() { X1 = 20 + (j * 50), Y1 = 50 + (i * 50), X2 = 70 + (j * 50), Y2 = 100 + (i * 50), Stroke = blue, StrokeThickness = 3.0 };
                            canvas.Children.Add(X1);
                            Line X2 = new Line() { X1 = 70 + (j * 50), Y1 = 50 + (i * 50), X2 = 20 + (j * 50), Y2 = 100 + (i * 50), Stroke = blue, StrokeThickness = 3.0 };
                            canvas.Children.Add(X2);
                        }
                    }
                }
                Versenkt(canvas, 3, 2, currentField);

                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        
                        if (currentField[i, j, 4] == 2) // 2-> getroffen->rot
                        {
                            Line X1 = new Line() { X1 = 450 + (j * 50), Y1 = 50 + (i * 50), X2 = 500 + (j * 50), Y2 = 100 + (i * 50), Stroke = red, StrokeThickness = 3.0 };
                            canvas.Children.Add(X1);
                            Line X2 = new Line() { X1 = 500 + (j * 50), Y1 = 50 + (i * 50), X2 = 450 + (j * 50), Y2 = 100 + (i * 50), Stroke = red, StrokeThickness = 3.0 };
                            canvas.Children.Add(X2);
                        }
                        if (currentField[i, j, 4] == 1) //1->daneben->blau
                        {
                            Line X1 = new Line() { X1 = 450 + (j * 50), Y1 = 50 + (i * 50), X2 = 500 + (j * 50), Y2 = 100 + (i * 50), Stroke = blue, StrokeThickness = 3.0 };
                            canvas.Children.Add(X1);
                            Line X2 = new Line() { X1 = 500 + (j * 50), Y1 = 50 + (i * 50), X2 = 450 + (j * 50), Y2 = 100 + (i * 50), Stroke = blue, StrokeThickness = 3.0 };
                            canvas.Children.Add(X2);
                        }
                    }
                }
                Versenkt(canvas, 4, 1, currentField);
            }
        }
    }
}
