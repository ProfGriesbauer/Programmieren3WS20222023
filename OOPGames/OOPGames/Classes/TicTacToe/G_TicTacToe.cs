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
        void paintFill();
        Casket isMySpace(int x, int y);
    }

    // neues Interface: Erbt von ITicTacToeFeld, fügt aber noch die momentane Größe des Spielfelds hinzu
    public interface ITicTacToeField_G : ITicTacToeField
    {
        void increaseField();
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
        void paintFrame(Canvas canvas)
        {

        }
        void paintFill()
        {

        }

        void ICasket.paintFrame(Canvas canvas)
        {
            throw new NotImplementedException();
        }

        void ICasket.paintFill()
        {
            throw new NotImplementedException();
        }

        public Casket isMySpace(int x, int y)
        {
            throw new NotImplementedException();
        }
        /*Casket isMySpace(int x, int y)
{
   //foreach (Cascet ret in _Field) ;
   for (int i = 0; i < _List.Count; i++)
   {
       for (int j = 0; j < _List[i].Count; j++)
       {
           if (x > _List[i][j].xPos && x < _List[i][j].xPos + _List[i][j].size)
           {
               if (y > _List[i][j].yPos && y < _List[i][j].yPos + _List[i][j].size)
               {
                   return this;
               }
           }
       }
   }
}*/
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
            Color lineColor = Color.FromRgb(255, 0, 0);
            Brush lineStroke = new SolidColorBrush(lineColor);
            Color XColor = Color.FromRgb(0, 255, 0);
            Brush XStroke = new SolidColorBrush(XColor);
            Color OColor = Color.FromRgb(0, 0, 255);
            Brush OStroke = new SolidColorBrush(OColor);

            //Line[] horizontals = new Line[currentField.CurrentSize - 1];
            //Line[] verticals = new Line[currentField.CurrentSize - 1];

            /*for (int i = 0; i < currentField.CurrentSize - 1; i++)
            {
                int X = (400 / currentField.CurrentSize) * (i + 1);
                horizontals[i] = new Line() { X1 = X, Y1 = 0, X2 = X, Y2 = 420, Stroke = lineStroke, StrokeThickness = 3.0 };
                canvas.Children.Add(horizontals[i]);

                int Y = (400 / currentField.CurrentSize) * (i + 1);
                verticals[i] = new Line() { X1 = 0, Y1 = Y, X2 = 400, Y2 = Y, Stroke = lineStroke, StrokeThickness = 3.0 };
                canvas.Children.Add(verticals[i]);
            }*/



            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (currentField[i, j] == 1)
                    {
                        Line X1 = new Line() { X1 = 20 + (j * 100), Y1 = 20 + (i * 100), X2 = 120 + (j * 100), Y2 = 120 + (i * 100), Stroke = XStroke, StrokeThickness = 3.0 };
                        canvas.Children.Add(X1);
                        Line X2 = new Line() { X1 = 20 + (j * 100), Y1 = 120 + (i * 100), X2 = 120 + (j * 100), Y2 = 20 + (i * 100), Stroke = XStroke, StrokeThickness = 3.0 };
                        canvas.Children.Add(X2);
                    }
                    else if (currentField[i, j] == 2)
                    {
                        Ellipse OE = new Ellipse() { Margin = new Thickness(20 + (j * 100), 20 + (i * 100), 0, 0), Width = 100, Height = 100, Stroke = OStroke, StrokeThickness = 3.0 };
                        canvas.Children.Add(OE);
                    }
                }
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

        int ITicTacToeField.this[int r, int c] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void increaseField()
        {
           
        }

        public int this[int r, int c]
        {
            get
            {
                if (r >= 0 && r < 3 && c >= 0 && c < 3)
                {
                    return 0;// _Field[r, c];
                }
                else
                {
                    return -1;
                }
            }

            set
            {
                if (r >= 0 && r < 3 && c >= 0 && c < 3)
                {
                    //_Field[r, c] = value;
                }
            }
        }

        public bool CanBePaintedBy(IPaintGame painter)
        {
            return painter is IPaintTicTacToe;
        }
    }




}


    

    