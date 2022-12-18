using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace OOPGames.Classes.Gruppe_C.Minesweeper
{
    public class C_MinesweeperField : C_IMinesweeperField
    {
        Segment[,] _Field = new Segment[16, 16];

        public C_MinesweeperField()
        {
            for (int i = 0; i < 16; i++)
                for (int j = 0; j < 16; j++)
                    _Field[i, j] = new Segment();
        }


        public Segment this[int r, int c]
        {
            get
            {
                if (r >= 0 && r < 16 && c >= 0 && c < 16)
                {
                    return _Field[r, c];
                }
                else
                {
                    return null;
                }
            }
            set
            {
                if (r >= 0 && r < 16 && c >= 0 && c < 16)
                {
                    _Field[r, c] = value;
                }
            }
        }



        public bool CanBePaintedBy(IPaintGame painter)
        {
            return painter is C_IPaintMinesweeper;

        }
    }


    public class Segment
    {
        public int Mine = 0;
        public int state = 0; //State 0 für zugedeckt /State 1 für Markiert /State 2 für aufgedeckt

        public int CheckMine()
        {
            if (Mine == 1)
            {
                return Mine;
            }
            else { return 0; }

        }
    }

    public class C_MPainter : C_IPaintMinesweeper
    {
        public string Name => throw new NotImplementedException();

        public void C_IPaintMinesweeper(Canvas canvas, C_IMinesweeperField currentField)
        {
            canvas.Children.Clear();
            Color bgColor = Color.FromRgb(255, 255, 255);
            canvas.Background = new SolidColorBrush(bgColor);
            Color lineColor = Color.FromRgb(0, 0, 0);
            Brush lineStroke = new SolidColorBrush(lineColor);

            int h = 30;

            for (int i = 0; i < 16; i++)
            {
                Line li = new Line() { X1 = 20, Y1 = 20 + i * h, X2 = 500, Y2 = 20 + i * h, Stroke = lineStroke, StrokeThickness = 1.0 };
                canvas.Children.Add(li);
                Line lb = new Line() { X1 = 20 + i * h, Y1 = 20, X2 = 20 + i * h, Y2 = 500, Stroke = lineStroke, StrokeThickness = 1.0 };
                canvas.Children.Add(lb);

            }
        }

        public void PaintGameField(Canvas canvas, IGameField currentField)
        {
            throw new NotImplementedException();
        }

        public void PaintMinesweeperField(Canvas canvas, C_IMinesweeperField currentField)
        {
            throw new NotImplementedException();
        }

        public void TickPaintGameField(Canvas canvas, C_IMinesweeperField currentField)
        {
            throw new NotImplementedException();
        }

        public void TickPaintGameField(Canvas canvas, IGameField currentField)
        {
            throw new NotImplementedException();
        }
    }
    public class C_MRules : C_IMinesweeperRules
    {
        C_MinesweeperField _Field = new C_MinesweeperField();
        public C_IMinesweeperField MinesweeperField { get { return _Field; } }

        public string Name { get; }

        public IGameField CurrentField { get { return _Field; } }

        public bool MovesPossible
        {
            get
            {
                for (int i = 0; i < 16; i++)
                {
                    for (int j = 0; j < 16; j++)
                    {
                        if (_Field[i, j].state == 0)
                        {
                            return true;
                        }
                    }
                }

                return false;
            }
        }
        public int CountMinesAround(int x, int y)
        {
            int count = 0;
            for (int r = 0; r < 3; r++)
            {
                for (int c = 0; c < 3; c++)
                {
                    if (_Field[x - 1 + r, y - 1 + c].CheckMine() == 1)
                    {
                        count++;
                    }
                }
            }
            return count;
        }

        public int CountMines()
        {
            int count = 0;
            for (int i = 0; i < 16; i++)
            {
                for (int j = 0; j < 16; j++)
                {
                    if (_Field[i, j].CheckMine() == 1)
                    {
                        count++;
                    }
                }
            }
            return count;
        }
        public int CheckIfPLayerWon()
        {
            if (!MovesPossible && CountMines() < 40)
            {
                return 1;
            }
            return -1;
        }

        public void ClearField()
        {
            for (int i = 0; i < 16; i++)
                for (int j = 0; j < 16; j++)
                    _Field[i, j] = new Segment();
        }

        public void DoMinesweeperMove(C_IMinesweeperMove move)
        {
            if (move.Row >= 0 && move.Row < 16 && move.Column >= 0 && move.Column < 16)
            {
                _Field[move.Row, move.Column].state = move.state;
            }
            Console.WriteLine("-------------------------------------");
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(_Field[i, 0] + " " + _Field[i, 1] + " " + _Field[i, 2] + " " + _Field[i, 3] + " " + _Field[i, 4] +
                    _Field[i, 5] + " " + _Field[i, 6] + " " + _Field[i, 7] + " " + _Field[i, 8] + " " + _Field[i, 9] +
                    _Field[i, 10] + " " + _Field[i, 11] + " " + _Field[i, 12] + " " + _Field[i, 13] + " " + _Field[i, 14] + " " + _Field[i, 15]);
            }
        }

        public void DoMove(IPlayMove move)
        {
            if (move is C_IMinesweeperMove)
            {
                DoMinesweeperMove((C_IMinesweeperMove)move);
            }
        }
    }
    public class MinesweeperMove : C_IMinesweeperMove
    {
        int _Row = 0;
        int _Column = 0;
        int _state = 0;
        int _PlayerNumber = 0;

        public MinesweeperMove(int row, int column, int state, int playerNumber)
        {
            _Row = row;
            _Column = column;
            _state = state;
            _PlayerNumber = playerNumber;
        }
        public int state { get { return _state; } }

        public int Row { get { return _Row; } }

        public int Column { get { return _Column; } }

        public int PlayerNumber { get { return _PlayerNumber; } }
    }
}
