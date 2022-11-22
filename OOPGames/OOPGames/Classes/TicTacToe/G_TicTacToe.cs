﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace OOPGames
{
    public interface ICasket
    {
        int x { get; set; }
        int y { get; set; }
        int size { get; set; }
        bool flag { get; set; }
        int player { get; set; } // evtl IGamePlayer anstelle von int
        void paintFrame(Canvas canvas);
        void paintFill(Canvas canvas, Color? X_Color, Color? O_Color);
        Casket isMySpace(int x, int y);
    }

    // neues Interface: Erbt von ITicTacToeFeld, fügt aber noch die momentane Größe des Spielfelds hinzu...
    public interface ITicTacToeField_G : ITicTacToeField
    {
        int Fieldsize { get; set; }
        List<Casket> Field { get; }
        void increaseField();
        
    }

    public class Casket : ICasket 
    {
        int _x;
        int _y;
        int _size;
        bool _flag;
        int _player;
        public int x
        {
            get { return _x; }

            set { _x = value; }
        }
        public int y
        {
            get { return _y; }

            set { _y = value; }
        }
        public int size
        {
            get { return _size; }

            set { _size = value; }
        }
        public bool flag 
        {
            get { return _flag; }
            set { flag = value; }
        }
        public int player
        {
            get { return _player; }

            set { _player = value; }
        }
        public void paintFrame(Canvas canvas)
        {
            Color lineColor = Color.FromRgb(255, 0, 0);
            Brush lineStroke = new SolidColorBrush(lineColor);

            //Obere Linie
            Line Up = new Line() { X1 = (_x) * _size, Y1 = (_y) * _size, X2 = (_x + 1) * _size, Y2 = (_y) * _size, Stroke = lineStroke, StrokeThickness = 3.0 };
            canvas.Children.Add(Up);

            //Untere Linie
            Line Down = new Line() { X1 = (_x) * _size, Y1 = (_y + 1 ) * _size, X2 = (_x + 1 ) * _size, Y2 = (_y + 1) * _size, Stroke = lineStroke, StrokeThickness = 3.0 };
            canvas.Children.Add(Down);
            
            //Linke Linie
            Line Left = new Line() { X1 = (_x) * _size, Y1 = (_y) * _size, X2 = (_x) * _size, Y2 = (_y + 1) * _size, Stroke = lineStroke, StrokeThickness = 3.0 };
            canvas.Children.Add(Left);

            //Rechte Linie
            Line Right = new Line() { X1 = (_x + 1) * _size, Y1 = (_y) * _size, X2 = (_x + 1) * _size, Y2 = (_y + 1) * _size, Stroke = lineStroke, StrokeThickness = 3.0 };
            canvas.Children.Add(Right);
        }
        public void paintFill(Canvas canvas, Color? X_Color, Color? O_Color)
        {
            Color XColor = X_Color ?? Color.FromRgb(0, 255, 0);
            Brush XStroke = new SolidColorBrush(XColor);
            Color OColor = O_Color ?? Color.FromRgb(0, 0, 255);
            Brush OStroke = new SolidColorBrush(OColor);

            if (_player == 1)
            {
                Line l1 = new Line() { X1 = (_x) * _size, Y1 = (_y) * _size, X2 = (_x + 1) * _size, Y2 = (_y + 1) * _size, Stroke = XStroke, StrokeThickness = 3.0 };
                Line l2 = new Line() { X1 = (_x) * _size, Y1 = (_y + 1) * _size, X2 = (_x) * _size, Y2 = (_y + 1) * _size, Stroke = XStroke, StrokeThickness = 3.0 };
                canvas.Children.Add(l1);
                canvas.Children.Add(l2);
            }
            else if (_player == 2)
            {
                Ellipse OE = new Ellipse() { Margin = new Thickness((_x) * _size, (_y) * _size, 0, 0), Width = _size, Height = _size, Stroke = OStroke, StrokeThickness = 3.0 };
                canvas.Children.Add(OE);
            }
        }

        public Casket isMySpace(int x, int y)
        {
            if ((_x*_size) <= x && (_x * _size) + _size >= x)
            {
                if ((_y * _size) <= y && (_y * _size) + _size >= y)
                {
                    return this;
                }
            }
            return null;
        }

    }

    public class TicTacToePaint_G : J_BaseTicTacToePaint
    {
        public override string Name { get { return "GruppeGTicTacToePaint"; } }

        public override Color X_Color
        {
            get
            {
                return X_Color;
            }

            set
            {
                X_Color = value;
            }
        }
        public override Color O_Color
        {
            get
            {
                return O_Color;
            }

            set
            {
                O_Color = value;
            }
        }


        // Überschreibt abstract Methode aus BaseTicTacToePaint, prüft ob ein Spielfeld Gruppe G vorhanden ist und konvertiert dann das Spielfeld
        public override void PaintTicTacToeField(Canvas canvas, ITicTacToeField currentField)
        {
            if (currentField is ITicTacToeField_G)
            {
                PaintTicTacToeField_G(canvas, (ITicTacToeField_G)currentField);
            }
        }

        public void PaintTicTacToeField_G(Canvas canvas, ITicTacToeField_G currentField)
        {
            ITicTacToeField_G field_G = currentField;
            canvas.Children.Clear();
            Color bgColor = Color.FromRgb(255, 255, 255);
            canvas.Background = new SolidColorBrush(bgColor);
            foreach (Casket C in currentField.Field)
            {
                C.paintFrame(canvas);
            }


        }
    }
    public class TicTacToeRules_G : BaseTicTacToeRules
    {
        TicTacToeField_G _Field = new TicTacToeField_G();


        public override ITicTacToeField TicTacToeField { get { return _Field; } }

        public override bool MovesPossible
        {
            get
            {
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (_Field[i, j] == 0)  //Liste implementieren
                        {
                            return true;
                        }
                    }
                }

                return false;
            }
        }

        public override string Name { get { return "GruppeGTicTacToeRules"; } }

        public override int CheckIfPLayerWon()
        {
            int countplayer1 = 0;
            int countplayer2 = 0;
            int NAME = threeinarow();

            // Switch Case evtl
            // default return -1
            // break nicht vergessen

            if(NAME>0)
              {
                  _Field.increaseField();
                  if(NAME==1)
                  {
                      countplayer1++;
                  }
                  else
                  {
                      countplayer2++;
                  }
              }

            if (MovesPossible==false)
              {
                  if(countplayer1>countplayer2)
                  {
                      return countplayer1;
                  }
                  else
                  {
                      return countplayer2;
                  }
              }
            return -1;
        }

        public override void ClearField()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    _Field[i, j] = 0;
                }
            }
        }


        public int threeinarow() //überprüft, ob sich drei in einer Reihe befinden
        {
            foreach (Casket C in _Field.Field)
            {

            }
            return 0;

        }

        public override void DoTicTacToeMove(ITicTacToeMove move)
        {
            if (move.Row >= 0 && move.Row < 3 && move.Column >= 0 && move.Column < 3)
            {
                //  _Field[move.Row, move.Column] = move.PlayerNumber;
                _Field.increaseField();  // nur zu Test-Zwecken
            }
        }
    }


    public class TicTacToeField_G : ITicTacToeField_G
    {
        int _Fieldsize = 400;
        List<Casket> _Field = new List<Casket>();

        public int Fieldsize
        {
            get { return _Fieldsize; }
            set { _Fieldsize = value; }
        }

        public List<Casket> Field
        {
            get { return _Field; }
        }
        

        // Initialisieren 3x3 Feld
        public TicTacToeField_G()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Casket C = new Casket();
                    C.x = i;
                    C.y = j;
                    C.size = _Fieldsize / 3;
                    _Field.Add(C);
                }
            }
        }


        int ITicTacToeField.this[int r, int c]
        {
            get
            {
                foreach (Casket C in _Field)
                {
                    if (C.x == c && C.y == r)
                    {
                        return C.player;
                    }
                }
                return -1;
            }

            set
            {
                foreach (Casket C in _Field)
                {
                    if (C.x == c && C.y == r)
                    {
                        C.player = value;
                    }
                }
            }

        }

        public void increaseField()
        {
            //berechnet die Länge der Liste in x - Richtung
            int lastSize = (int)Math.Sqrt(_Field.Count);

            //Zeile hinzufügen
            for (int i = 0; i < lastSize; i++)
            {
                Casket C = new Casket();
                C.x = i;
                C.y = lastSize + 1;
                C.size = _Fieldsize / lastSize;
                _Field.Add(C);
            }

            // Spalte hinzufügen
            for (int i = 0; i < (lastSize + 1); i++)
            {
                Casket C = new Casket();
                C.x = lastSize + 1;
                C.y = i;
                C.size = _Fieldsize / lastSize;
                _Field.Add(C);
            }

            // Größe Kästchen neu skalieren
            foreach (Casket C in _Field)
            {
                C.size = _Fieldsize / (int)Math.Sqrt(_Field.Count);
            }
        }

        public int this[int r, int c]
        {
            get
            {
                foreach (Casket i in _Field)
                {
                    if (i.x == r && i.y == c)
                    {
                        return i.player;
                    }
                }
                return -1;
            }

            set
            {
                foreach (Casket i in _Field)
                {
                    if (i.x == r && i.y == c)
                    {
                        i.player = value;
                    }
                }
            }
        }

        public bool CanBePaintedBy(IPaintGame painter)
        {
            return painter is IPaintTicTacToe;
        }
    }




}




