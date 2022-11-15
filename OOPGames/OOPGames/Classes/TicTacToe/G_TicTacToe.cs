using System;
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
        int player { get; set; } // evtl IGamePlayer anstelle von int
        void paintFrame(Canvas canvas);
        void paintFill(Canvas canvas);
        Casket isMySpace(int x, int y);
    }

    // neues Interface: Erbt von ITicTacToeFeld, fügt aber noch die momentane Größe des Spielfelds hinzu...
    public interface ITicTacToeField_G : ITicTacToeField
    {
        void increaseField();
        List<Casket> Field { get; }
    }

    public class Casket : ICasket
    {
        int _x;
        public int x
        {
            get { return _x; }

            set { _x = value; }
        }

        int _y;
        public int y
        {
            get { return _y; }

            set { _y = value; }
        }

        int _size;
        public int size
        {
            get { return _size; }

            set { _size = value; }
        }

        int _player;
        public int player
        {
            get { return _player; }

            set { _player = value; }
        }
        public void paintFrame(Canvas canvas)
        {
            Color lineColor = Color.FromRgb(255, 0, 0);
            Brush lineStroke = new SolidColorBrush(lineColor);

            Line Up = new Line() { X1 = (_x - 1) * _size, Y1 = (_y - 1) * _size, X2 = _x * _size, Y2 = (_y - 1) * _size, Stroke = lineStroke, StrokeThickness = 3.0 };
            canvas.Children.Add(Up);
            Line Down = new Line() { X1 = (_x - 1) * _size, Y1 = _y * _size, X2 = _x * _size, Y2 = _y * _size, Stroke = lineStroke, StrokeThickness = 3.0 };
            canvas.Children.Add(Down);
            Line Left = new Line() { X1 = (_x - 1) * _size, Y1 = (_y - 1) * _size, X2 = (_x - 1) * _size, Y2 = _y * _size, Stroke = lineStroke, StrokeThickness = 3.0 };
            canvas.Children.Add(Left);
            Line Right = new Line() { X1 = _x * _size, Y1 = (_y - 1) * _size, X2 = _x * _size, Y2 = _y * _size, Stroke = lineStroke, StrokeThickness = 3.0 };
            canvas.Children.Add(Right);
        }
        public void paintFill(Canvas canvas)
        {
            Color XColor = Color.FromRgb(0, 255, 0);
            Brush XStroke = new SolidColorBrush(XColor);
            Color OColor = Color.FromRgb(0, 0, 255);
            Brush OStroke = new SolidColorBrush(OColor);

            if (_player == 1)
            {
                Line l1 = new Line() { X1 = (_x - 1) * _size, Y1 = (_y - 1) * _size, X2 = _x * _size, Y2 = _y * _size, Stroke = XStroke, StrokeThickness = 3.0 };
                Line l2 = new Line() { X1 = (_x - 1) * _size, Y1 = _y * _size, X2 = _x * _size, Y2 = (_y-1) * _size, Stroke = XStroke, StrokeThickness = 3.0 };
                canvas.Children.Add(l1);
                canvas.Children.Add(l2);
            }
            else if (_player == 2)
            {
                Ellipse OE = new Ellipse() { Margin = new Thickness((_x - 1) * _size, (_y - 1) * _size, 0, 0), Width = _size, Height = _size, Stroke = OStroke, StrokeThickness = 3.0 };
                canvas.Children.Add(OE);
            }
        }

        public Casket isMySpace(int x, int y)
        {
            throw new NotImplementedException();
        }
        
    }

    public class TicTacToePaint_G : BaseTicTacToePaint
    {

        public override string Name { get { return "GruppeGTicTacToePaint"; } }


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
                C.paintFill(canvas);
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
                        if (_Field[i, j] == 0)
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
          /*  for (int i = 0; i < 3; i++)
            {
                if (_Field[i, 0] > 0 && _Field[i, 0] == _Field[i, 1] && _Field[i, 1] == _Field[i, 2])
                {
                    return _Field[i, 0];
                }
                else if (_Field[0, i] > 0 && _Field[0, i] == _Field[1, i] && _Field[1, i] == _Field[2, i])
                {
                    return _Field[0, i];
                }
            }

            if (_Field[0, 0] > 0 && _Field[0, 0] == _Field[1, 1] && _Field[1, 1] == _Field[2, 2])
            {
                return _Field[0, 0];
            }
            else if (_Field[0, 2] > 0 && _Field[0, 2] == _Field[1, 1] && _Field[1, 1] == _Field[2, 0])
            {
                return _Field[0, 2];
            }
          */
            return -1;
        }

        public override void ClearField()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                  //  _Field[i, j] = 0;
                }
            }
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

        List<Casket> _Field = new List<Casket>();

        public List<Casket> Field
        {
            get { return _Field; }
        }

        // Initialisieren 3x3 Feld
        public TicTacToeField_G()
        {
            for (int i = 1; i <= 3; i++)
            {
                for (int j = 1; j <= 3; j++)
                {
                    Casket C = new Casket();
                    C.x = i;
                    C.y = j;
                    C.size = 400 / 3;
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
            int lastSize = (int)Math.Sqrt(_Field.Count);
            //Zeile hinzufügen
            for (int i = 1; i <= lastSize; i++)
            {
                Casket C = new Casket();
                C.x = i;
                C.y = lastSize + 1;
                C.size = 400 / lastSize;
                _Field.Add(C);
            }

            // Spalte hinzufügen
            for (int i = 1; i <= (lastSize + 1); i++)
            {
                Casket C = new Casket();
                C.x = lastSize + 1;
                C.y = i;
                C.size = 400 / lastSize;
                _Field.Add(C);
            }

            // Größe Kästchen neu skalieren
            foreach (Casket C in _Field)
            {
                C.size = 400 / (int)Math.Sqrt(_Field.Count);
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


    

    