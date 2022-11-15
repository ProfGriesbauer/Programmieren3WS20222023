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

    public class C_Painter : BaseTicTacToePaint
    {
        public override string Name { get { return "C Painter"; } }

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

            Line l1 = new Line() { X1 = 20, Y1 = 20, X2 = 20, Y2 = 20, Stroke = lineStroke, StrokeThickness = 3.0 };
            canvas.Children.Add(l1);
            Line l2 = new Line() { X1 = 120, Y1 = 20, X2 = 120, Y2 = 20, Stroke = lineStroke, StrokeThickness = 3.0 };
            canvas.Children.Add(l2);
            Line l3 = new Line() { X1 = 220, Y1 = 20, X2 = 220, Y2 = 20, Stroke = lineStroke, StrokeThickness = 3.0 };
            canvas.Children.Add(l3);
            Line l4 = new Line() { X1 = 320, Y1 = 20, X2 = 320, Y2 = 20, Stroke = lineStroke, StrokeThickness = 3.0 };
            canvas.Children.Add(l4);
            Line l5 = new Line() { X1 = 420, Y1 = 20, X2 = 420, Y2 = 20, Stroke = lineStroke, StrokeThickness = 3.0 };
            canvas.Children.Add(l5);
            Line l6 = new Line() { X1 = 520, Y1 = 20, X2 = 520, Y2 = 20, Stroke = lineStroke, StrokeThickness = 3.0 };
            canvas.Children.Add(l6);
            Line l7 = new Line() { X1 = 20, Y1 = 20, X2 = 520, Y2 = 20, Stroke = lineStroke, StrokeThickness = 3.0 };
            canvas.Children.Add(l7);
            Line l8 = new Line() { X1 = 20, Y1 = 120, X2 = 520, Y2 = 120, Stroke = lineStroke, StrokeThickness = 3.0 };
            canvas.Children.Add(l8);
            Line l9 = new Line() { X1 = 20, Y1 = 220, X2 = 520, Y2 = 220, Stroke = lineStroke, StrokeThickness = 3.0 };
            canvas.Children.Add(l9);
            Line l10 = new Line() { X1 = 20, Y1 = 320, X2 = 520, Y2 = 320, Stroke = lineStroke, StrokeThickness = 3.0 };
            canvas.Children.Add(l10);
            Line l11 = new Line() { X1 = 20, Y1 = 420, X2 = 520, Y2 = 420, Stroke = lineStroke, StrokeThickness = 3.0 };
            canvas.Children.Add(l11);
            Line l12 = new Line() { X1 = 20, Y1 = 520, X2 = 520, Y2 = 520, Stroke = lineStroke, StrokeThickness = 3.0 };
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
        }
    }


    public class C_TicTacToeHumanPlayer : BaseHumanTicTacToePlayer
    {
        int _Playernumber = 0;
        public override string Name { get { return "C_HumanTicTacToePlayer"; } }
        public override int PlayerNumber { get { return _Playernumber; } }
        public override IGamePlayer Clone()
        {
            TicTacToeHumanPlayer ttthp = new TicTacToeHumanPlayer();
            ttthp.SetPlayerNumber(_Playernumber);
            return ttthp;
        }
        public override ITicTacToeMove GetMove(IMoveSelection selection, ITicTacToeField field)
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
        public override void SetPlayerNumber(int playerNumber)
        {
            _Playernumber = playerNumber;
        }


    }
    public class GC_TicTacToeRules : BaseTicTacToeRules
    {
        GC_TicTacToeField _Field = new GC_TicTacToeField();

        public override ITicTacToeField TicTacToeField { get { return _Field; } }

        public override bool MovesPossible
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

        public override string Name { get { return "GruppeCTicTacToeRules"; } }

        public override int CheckIfPLayerWon()
        {
            throw new NotImplementedException();
        }

        public override void ClearField()
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    _Field[i, j] = 0;
                }
            }
        }

        public override void DoTicTacToeMove(ITicTacToeMove move)
        {
            throw new NotImplementedException();
        }
    }

    public class GC_TicTacToeField : BaseTicTacToeField
    {
        int[,] _Field = new int[5, 5] { { 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0 } };

        public override int this[int r, int c]
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
    }
}