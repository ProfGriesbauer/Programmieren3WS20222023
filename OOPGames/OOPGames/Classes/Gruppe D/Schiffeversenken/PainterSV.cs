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

        void FindPlacedShips(Canvas canvas, int Player, IFieldSV currentField) //Phase 1 und 2
        {
            
            for (int r = 0; r < 8; r++)
            {
                for (int c = 0; c < 8; c++)
                {
                    if (currentField[r, c, Player] == 1)
                    {
                        if (currentField[r-1, c, Player] == 1) //wenn links ein Feld belegt ist wurde das Schiff schon gezeichnet
                        {
                            //_stop = 1;
                            continue;
                        }
                        if (currentField[r , c-1, Player] == 1) //wenn links ein Feld belegt ist wurde das Schiff schon gezeichnet
                        {
                            //_stop = 1;
                            continue;
                        }
                        int _Ship = 0;
                        int _Rotation = 0;
                        if (currentField[r+1, c, Player] == 1) //liegt das Schiff horizental?
                        { 
                            for (int i=0; i<5; i++)
                            {
                                if (currentField[r + i, c, Player] == 1)
                                {
                                    _Ship++;
                                    _Rotation = 2;
                                }
                                else
                                {
                                    i=5;
                                }
                            }
                        }
                        else 
                        {
                            for (int i = 0; i < 5; i++)
                            {
                                if (currentField[r, c + i, Player] == 1)
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
                        int y = (50 * r) + 50;
                        int x = (50 * c) + 20 ;
                        PaintShip(canvas, _Ship, x, y, _Rotation, 0);
                    }
                }
            }

        }
        public int LastHit(int i, int j, int Ship, IFieldSV currentField, int w, int p)
        {
            int _Ship = Ship;
            if (currentField[i, j, w] == 2 && currentField[i, j, p] > 0) //aktuelles Feld
            {
                _Ship--;
            }
            for (int o = 1; j + o <=8 && currentField[i, j + o , p] > 0;o++) //Check oben
            {
                if (currentField[i, j + o, w] == 2) { _Ship--; }
            }
            for (int u = 1; j - u >= 0 && currentField[i, j - u, p] > 0; u++) //Check unten
            {
                if (currentField[i, j - u, w] == 2) { _Ship--; }
            }
            for (int r = 1; i + r <= 8 && currentField[i+r, j, p] > 0; r++) //Check rechts
            {
                if (currentField[i + r, j, w] == 2) { _Ship--; }
            }
            for (int l = 1; i - l >= 0 && currentField[i-l, j, p] > 0; l++) //Check links
            {
                if (currentField[i - l, j, w] == 2) { _Ship--; }
            }

            if (_Ship>0)
            {
                return 0; //Schiff noch da
            }
            return 1; //Schiff versenkt
        }

        public void PaintGameField(Canvas canvas, IGameField currentField)
        {
            if (currentField is IFieldSV)
            {
                PaintShipField(canvas, (IFieldSV)currentField);
            }
        }

        public void PaintShip(Canvas canvas, int Ship, int x, int y, int _HorVer, int destroid)
        {
            Color lineColor = Color.FromRgb(0, 0, 255);
            if (destroid == 1)
            {
                lineColor = Color.FromRgb(255, 0, 0);
            }
            Brush lineStroke = new SolidColorBrush(lineColor);
            int _x = x;

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
            } else if (_HorVer == 2)
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
            int _Ship = currentField.Ships(2, 2);

            currentField.HorVer = 2; //tests

            int _Rotation = currentField.HorVer;
            int _CurrentPlayer = 0;

            if (GamePhase == 1 || GamePhase == 2)
            {
                string _player = "";
                if(GamePhase == 2)
                {
                    _player = "P2";
                    _CurrentPlayer = 2;
                }
                else { _player = "P1"; _CurrentPlayer = 1; }

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

                currentField[0, 1, 1] = 1; //testet die FindShip function
                currentField[0, 2, 1] = 1;

                currentField[0, 4, 1] = 1;
                currentField[0, 5, 1] = 1;
                currentField[0, 6, 1] = 1;

                currentField[5, 5, 1] = 1;
                currentField[6, 5, 1] = 1;

                currentField[4, 7, 1] = 1;
                currentField[5, 7, 1] = 1;
                currentField[6, 7, 1] = 1;
                currentField[7, 7, 1] = 1;

                PaintShip(canvas, currentField.Ships(2, _CurrentPlayer), 20, 505, _Rotation, 0);

                FindPlacedShips(canvas, _CurrentPlayer, currentField);
                
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
                        if (currentField[i, j, 3]==2 && LastHit(i, j, currentField[i, j, 2], currentField, 3, 2) == 1) {
                            PaintShip(canvas, currentField.Ships(2, _CurrentPlayer), 20, 505, 2, 1); //POS noch anpassen
                        }
                        else if (currentField[i, j, 3] == 2) // 2-> getroffen->rot
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
                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        if (currentField[i, j, 4] == 2 && LastHit(i, j, currentField[i, j, 2], currentField, 4, 1) == 1)
                        {
                            PaintShip(canvas, currentField.Ships(2, _CurrentPlayer), 20, 505, 2, 1); //POS noch anpassen
                        }
                        else if (currentField[i, j, 4] == 2) // 2-> getroffen->rot
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
            }
        }
    }
}
