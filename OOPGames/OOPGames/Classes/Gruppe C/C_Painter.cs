 using OOPGames;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows;

namespace OOPGames.Classes.Gruppe_C
{
    public class C_Painter : C_IPaintTicTacToe
    {
        public void PaintGameField(Canvas canvas, IGameField currentField)
        {
            if (currentField is C_ITicTacToeField)
            {
                PaintTicTacToeField(canvas, (C_ITicTacToeField)currentField);
            }
        }
        public string Name { get { return "C Painter"; } }


        public void PaintTicTacToeField(Canvas canvas, C_ITicTacToeField currentField)
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

            Line l1 = new Line() { X1 = 20, Y1 = 20, X2 = 20, Y2 = 520, Stroke = lineStroke, StrokeThickness = 3.0 }; //senkrecht
            canvas.Children.Add(l1);
            Line l2 = new Line() { X1 = 120, Y1 = 20, X2 = 120, Y2 = 520, Stroke = lineStroke, StrokeThickness = 3.0 }; //senkrecht
            canvas.Children.Add(l2);
            Line l3 = new Line() { X1 = 220, Y1 = 20, X2 = 220, Y2 = 520, Stroke = lineStroke, StrokeThickness = 3.0 }; //senkrecht
            canvas.Children.Add(l3);
            Line l4 = new Line() { X1 = 320, Y1 = 20, X2 = 320, Y2 = 520, Stroke = lineStroke, StrokeThickness = 3.0 }; //senkrecht
            canvas.Children.Add(l4);
            Line l5 = new Line() { X1 = 420, Y1 = 20, X2 = 420, Y2 = 520, Stroke = lineStroke, StrokeThickness = 3.0 }; //senkrecht
            canvas.Children.Add(l5);
            Line l6 = new Line() { X1 = 520, Y1 = 20, X2 = 520, Y2 = 520, Stroke = lineStroke, StrokeThickness = 3.0 }; //senkrecht
            canvas.Children.Add(l6);
            Line l7 = new Line() { X1 = 20, Y1 = 20, X2 = 520, Y2 = 20, Stroke = lineStroke, StrokeThickness = 3.0 }; //waagrecht
            canvas.Children.Add(l7);
            Line l8 = new Line() { X1 = 20, Y1 = 120, X2 = 520, Y2 = 120, Stroke = lineStroke, StrokeThickness = 3.0 }; //waagrecht
            canvas.Children.Add(l8);
            Line l9 = new Line() { X1 = 20, Y1 = 220, X2 = 520, Y2 = 220, Stroke = lineStroke, StrokeThickness = 3.0 }; //waagrecht
            canvas.Children.Add(l9);
            Line l10 = new Line() { X1 = 20, Y1 = 320, X2 = 520, Y2 = 320, Stroke = lineStroke, StrokeThickness = 3.0 }; //waagrecht
            canvas.Children.Add(l10);
            Line l11 = new Line() { X1 = 20, Y1 = 420, X2 = 520, Y2 = 420, Stroke = lineStroke, StrokeThickness = 3.0 }; //waagrecht
            canvas.Children.Add(l11);
            Line l12 = new Line() { X1 = 20, Y1 = 520, X2 = 520, Y2 = 520, Stroke = lineStroke, StrokeThickness = 3.0 }; //waagrecht
            canvas.Children.Add(l12);


            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
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
            TextBlock textBlock = new TextBlock();
            textBlock.Text = "Player 1: " + currentField.PointsPlayer1 + System.Environment.NewLine + "Player 2: " + currentField.PointsPlayer2;
            textBlock.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));
            Canvas.SetLeft(textBlock, 20);
            Canvas.SetTop(textBlock, 540);
            canvas.Children.Add(textBlock);
        }
    }



    public class C_TicTacToeHumanPlayer : C_IHumanTicTacToePlayer
    {
        int _Playernumber = 0;
        public string Name { get { return "C_HumanTicTacToePlayer"; } }
        public int PlayerNumber { get { return _Playernumber; } }
        public IGamePlayer Clone()
        {
            C_TicTacToeHumanPlayer ttthp = new C_TicTacToeHumanPlayer();
            ttthp.SetPlayerNumber(_Playernumber);
            return ttthp;
        }
        public ITicTacToeMove GetMove(IMoveSelection selection, C_ITicTacToeField field)
        {
            if (selection is IClickSelection)
            {
                IClickSelection sel = (IClickSelection)selection;
                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        if (sel.XClickPos > 20 + (j * 100) && sel.XClickPos < 120 + (j * 100) &&
                               sel.YClickPos > 20 + (i * 100) && sel.YClickPos < 120 + (i * 100) &&
                               field[i, j] <= 0)
                        {
                            return new TicTacToeMove(i, j, _Playernumber);
                        }
                    }
                }
            }
            return null;
        }
        public void SetPlayerNumber(int playerNumber)
        {
            _Playernumber = playerNumber;
        }

        public bool CanBeRuledBy(IGameRules rules)
        {
            return rules is C_ITicTacToeRules;
        }

        public IPlayMove GetMove(IMoveSelection selection, IGameField field)
        {
            if (field is C_ITicTacToeField)
            {
                return GetMove(selection, (C_ITicTacToeField)field);
            }
            else
            {
                return null;
            }


        }
        public class C_TicTacToeComputerPlayer : C_IComputerTicTacToePlayer
        {
            int _PlayerNumber = 0;
            public  string Name { get { return "C_TicTacToeComputerPlayer"; } }
            public  int PlayerNumber { get { return _PlayerNumber; } }

            public bool CanBeRuledBy(IGameRules rules)
            {
                throw new NotImplementedException();
            }

            public  IGamePlayer Clone()
            {
                C_TicTacToeComputerPlayer ttthp = new C_TicTacToeComputerPlayer();
                ttthp.SetPlayerNumber(_PlayerNumber);
                return ttthp;
            }
            public  ITicTacToeMove GetMove(C_ITicTacToeField field)
            {
                Random rand = new Random();
                int f = rand.Next(0, 25);
                for (int i = 0; i < 1000; i++)
                {
                    int c = f % 5;
                    int r = ((f - c) / 5) % 5;
                    if (field[r, c] <= 0)
                    {
                        return new TicTacToeMove(r, c, _PlayerNumber);
                    }
                    else
                    {
                        f = rand.Next(0, 25);
                    }
                }
                return null;
            }

            public IPlayMove GetMove(IGameField field)
            {
                if (field is C_ITicTacToeField)
                {
                    return GetMove((C_ITicTacToeField)field);
                }
                else
                {
                    return null;
                }
            }

            public  void SetPlayerNumber(int playerNumber)
            {
                _PlayerNumber = playerNumber;
            }

        }


        public class GC_TicTacToeRules : C_ITicTacToeRules
        {
            GC_TicTacToeField _Field = new GC_TicTacToeField();



            public C_ITicTacToeField FieldandPoints { get { return _Field; } }

            public bool MovesPossible
            {
                get
                {
                    for (int i = 0; i < 5; i++)
                    {
                        for (int j = 0; j < 5; j++)
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

            public string Name { get { return "GruppeCTicTacToeRules"; } }

            public IGameField CurrentField { get { return FieldandPoints; } }

            public void CountPoints()
            {
                int points1 = 0;
                int points2 = 0;
                for (int i = 1; i < 4; i++)
                {
                    for (int j = 1; j < 4; j++)
                    {
                        if (_Field[i, j] > 0 && _Field[i, j] == _Field[i - 1, j] && _Field[i, j] == _Field[i + 1, j])
                        {
                            if (_Field[i, j] == 1) { points1++; }
                            if (_Field[i, j] == 2) { points2++; }
                        }
                        if (_Field[i, j] > 0 && _Field[i, j] == _Field[i - 1, j - 1] && _Field[i, j] == _Field[i + 1, j + 1])
                        {
                            if (_Field[i, j] == 1) { points1++; }
                            if (_Field[i, j] == 2) { points2++; }
                        }
                        if (_Field[i, j] > 0 && _Field[i, j] == _Field[i, j - 1] && _Field[i, j] == _Field[i, j + 1])
                        {
                            if (_Field[i, j] == 1) { points1++; }
                            if (_Field[i, j] == 2) { points2++; }
                        }
                        if (_Field[i, j] > 0 && _Field[i, j] == _Field[i - 1, j + 1] && _Field[i, j] == _Field[i + 1, j - 1])
                        {
                            if (_Field[i, j] == 1) { points1++; }
                            if (_Field[i, j] == 2) { points2++; }
                        }
                    }

                }
                for (int k = 1; k < 4; k++)
                {
                    if (_Field[k, 0] > 0 && _Field[k, 0] == _Field[k - 1, 0] && _Field[k, 0] == _Field[k + 1, 0])
                    {
                        if (_Field[k, 0] == 1) { points1++; }
                        if (_Field[k, 0] == 2) { points2++; }
                    }
                    if (_Field[k, 4] > 0 && _Field[k, 4] == _Field[k - 1, 4] && _Field[k, 4] == _Field[k + 1, 4])
                    {
                        if (_Field[k, 4] == 1) { points1++; }
                        if (_Field[k, 4] == 2) { points2++; }
                    }
                    if (_Field[0, k] > 0 && _Field[0, k] == _Field[0, k - 1] && _Field[0, k] == _Field[0, k + 1])
                    {
                        if (_Field[0, k] == 1) { points1++; }
                        if (_Field[0, k] == 2) { points2++; }
                    }
                    if (_Field[4, k] > 0 && _Field[4, k] == _Field[4, k - 1] && _Field[4, k] == _Field[4, k + 1])
                    {
                        if (_Field[4, k] == 1) { points1++; }
                        if (_Field[4, k] == 2) { points2++; }
                    }
                }
                _Field.PointsPlayer1 = points1;
                _Field.PointsPlayer2 = points2;
                Console.WriteLine("-----------------------------------");
                Console.WriteLine("Player 1 has " + points1 + " Points");
                Console.WriteLine("Player 2 has " + points2 + " Points");
            }

            public int CheckIfPLayerWon()
            {
                CountPoints();
                for (int i = 0; i < 5; i++)
                {
                    if (_Field[i, 0] > 0 && _Field[i, 0] == _Field[i, 1] && _Field[i, 0] == _Field[i, 2] && _Field[i, 0] == _Field[i, 3] && _Field[i, 0] == _Field[i, 4])
                    {
                        return _Field[i, 0];
                    }
                    if (_Field[0, i] > 0 && _Field[0, i] == _Field[1, i] && _Field[0, i] == _Field[2, i] && _Field[0, i] == _Field[3, i] && _Field[0, i] == _Field[4, i])
                    {
                        return _Field[0, i];
                    }
                }
                if (_Field[0, 0] > 0 && _Field[0, 0] == _Field[1, 1] && _Field[0, 0] == _Field[2, 2] && _Field[0, 0] == _Field[3, 3] && _Field[0, 0] == _Field[4, 4])
                {
                    return _Field[0, 0];
                }
                if (_Field[0, 4] > 0 && _Field[0, 4] == _Field[1, 3] && _Field[0, 4] == _Field[2, 2] && _Field[0, 4] == _Field[3, 1] && _Field[0, 4] == _Field[4, 0])
                {
                    return _Field[0, 4];
                }
                return -1;
            }

            public void ClearField()
            {
                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        _Field[i, j] = 0;
                    }
                }
            }

            public void DoTicTacToeMove(ITicTacToeMove move)
            {
                if (move.Row >= 0 && move.Row < 5 && move.Column >= 0 && move.Column < 5)
                {
                    _Field[move.Row, move.Column] = move.PlayerNumber;
                }

                Console.WriteLine("-------------------------------------");
                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine(_Field[i, 0] + " " + _Field[i, 1] + " " + _Field[i, 2] + " " + _Field[i, 3] + " " + _Field[i, 4]);
                }

            }

            public void DoMove(IPlayMove move)
            {
                if (move is ITicTacToeMove)
                {
                    DoTicTacToeMove((ITicTacToeMove)move);
                }
            }
        }

        public class GC_TicTacToeField : C_ITicTacToeField
        {
            int[,] _Field = new int[5, 5] { { 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0 } };
            int _PointsPlayer1;
            int _PointsPlayer2;

            public int this[int r, int c]
            {
                get
                {
                    if (r >= 0 && r < 5 && c >= 0 && c < 5)
                    {
                        return _Field[r, c];
                    }
                    else
                    {
                        return -1;
                    }
                }
                set
                {
                    if (r >= 0 && r < 5 && c >= 0 && c < 5)
                    {
                        _Field[r, c] = value;
                    }
                }
            }

            public int PointsPlayer1 { get { return _PointsPlayer1; } set { _PointsPlayer1 = value; } }
            public int PointsPlayer2 { get { return _PointsPlayer2; } set { _PointsPlayer2 = value; } }

            public bool CanBePaintedBy(IPaintGame painter)
            {
                return painter is C_IPaintTicTacToe;

            }
        }
    }
}