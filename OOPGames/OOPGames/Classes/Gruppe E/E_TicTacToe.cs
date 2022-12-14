    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Cryptography.X509Certificates;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media;
    using System.Windows.Navigation;
    using System.Windows.Shapes;
using Microsoft.Win32;

namespace OOPGames
{ 
    public class E_Painter : IPaintTicTacToe
    {
        public string Name { get { return "E_TicTacToePainter"; } }

        public void PaintGameField(Canvas canvas, IGameField currentField)
        {
            if (currentField is ITicTacToeField)
            {
                PaintTicTacToeField(canvas, (ITicTacToeField)currentField);
            }
        }

        public void PaintTicTacToeField(Canvas canvas, ITicTacToeField currentField)
        {
            //Farben für Hintergrund, Spielfeld, Formen

            canvas.Children.Clear();
            Color bgColor = Color.FromRgb(0, 0, 0);
            canvas.Background = new SolidColorBrush(bgColor);
            Color lineColor = Color.FromRgb(255, 255, 255);
            Brush lineStroke = new SolidColorBrush(lineColor);
            Color XColor = Color.FromRgb(0, 191, 255);
            Brush XStroke = new SolidColorBrush(XColor);
            Color OColor = Color.FromRgb(255, 127, 0);
            Brush OStroke = new SolidColorBrush(OColor);

            //Zeichnen des Spielfelds

            Line l1 = new Line() { X1 = 120, Y1 = 20, X2 = 120, Y2 = 320, Stroke = lineStroke, StrokeThickness = 3.0 };
            canvas.Children.Add(l1);
            Line l2 = new Line() { X1 = 220, Y1 = 20, X2 = 220, Y2 = 320, Stroke = lineStroke, StrokeThickness = 3.0 };
            canvas.Children.Add(l2);
            Line l3 = new Line() { X1 = 20, Y1 = 120, X2 = 320, Y2 = 120, Stroke = lineStroke, StrokeThickness = 3.0 };
            canvas.Children.Add(l3);
            Line l4 = new Line() { X1 = 20, Y1 = 220, X2 = 320, Y2 = 220, Stroke = lineStroke, StrokeThickness = 3.0 };
            canvas.Children.Add(l4);
            Line l5 = new Line() { X1 = 20, Y1 = 320, X2 = 320, Y2 = 320, Stroke = lineStroke, StrokeThickness = 3.0 };
            canvas.Children.Add(l5);
            Line l6 = new Line() { X1 = 20, Y1 = 20, X2 = 320, Y2 = 20, Stroke = lineStroke, StrokeThickness = 3.0 };
            canvas.Children.Add(l6);
            Line l7 = new Line() { X1 = 20, Y1 = 320, X2 = 20, Y2 = 20, Stroke = lineStroke, StrokeThickness = 3.0 };
            canvas.Children.Add(l7);
            Line l8 = new Line() { X1 = 320, Y1 = 320, X2 = 320, Y2 = 20, Stroke = lineStroke, StrokeThickness = 3.0 };
            canvas.Children.Add(l8);

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (currentField[i, j] == 1)
                    {

                        //Form 1: Stern
                        Line X1 = new Line() { X1 = 40 + (j * 100), Y1 = 40 + (i * 100), X2 = 100 + (j * 100), Y2 = 100 + (i * 100), Stroke = XStroke, StrokeThickness = 3.0 };
                        canvas.Children.Add(X1);
                        Line X2 = new Line() { X1 = 40 + (j * 100), Y1 = 100 + (i * 100), X2 = 100 + (j * 100), Y2 = 40 + (i * 100), Stroke = XStroke, StrokeThickness = 3.0 };
                        canvas.Children.Add(X2);
                        Line X3 = new Line() { X1 = 30 + (j * 100), Y1 = 70 + (i * 100), X2 = 110 + (j * 100), Y2 = 70 + (i * 100), Stroke = XStroke, StrokeThickness = 3.0 };
                        canvas.Children.Add(X3);
                        Line X4 = new Line() { X1 = 70 + (j * 100), Y1 = 110 + (i * 100), X2 = 70 + (j * 100), Y2 = 30 + (i * 100), Stroke = XStroke, StrokeThickness = 3.0 };
                        canvas.Children.Add(X4);
                    }
                    else if (currentField[i, j] == 2)
                    {

                        //Form 2: Quadrat/Raute
                        Line X1 = new Line() { X1 = 70 + (j * 100), Y1 = 30 + (i * 100), X2 = 110 + (j * 100), Y2 = 70 + (i * 100), Stroke = OStroke, StrokeThickness = 3.0 };
                        canvas.Children.Add(X1);
                        Line X2 = new Line() { X1 = 110 + (j * 100), Y1 = 70 + (i * 100), X2 = 70 + (j * 100), Y2 = 110 + (i * 100), Stroke = OStroke, StrokeThickness = 3.0 };
                        canvas.Children.Add(X2);
                        Line X3 = new Line() { X1 = 70 + (j * 100), Y1 = 110 + (i * 100), X2 = 30 + (j * 100), Y2 = 70 + (i * 100), Stroke = OStroke, StrokeThickness = 3.0 };
                        canvas.Children.Add(X3);
                        Line X4 = new Line() { X1 = 30 + (j * 100), Y1 = 70 + (i * 100), X2 = 70 + (j * 100), Y2 = 30 + (i * 100), Stroke = OStroke, StrokeThickness = 3.0 };
                        canvas.Children.Add(X4);
                    }
                }
            }
        }
    }

    public class E_TicTacToeRules : ITicTacToeRules
    {
        E_TicTacToeField _Field = new E_TicTacToeField();

        public ITicTacToeField TicTacToeField { get { return _Field; } }
        public bool MovesPossible
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

        public string Name { get { return "E_TicTacToeRules"; } }

        public IGameField CurrentField { get { return E_TicTacToeField; } }

        public ITicTacToeField E_TicTacToeField { get { return _Field; } }


        public int CheckIfPLayerWon()
        {
            for (int i = 0; i < 3; i++)
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

            return -1;
        }

        public void ClearField()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    _Field[i, j] = 0;
                }
            }
        }

        public void DoMove(IPlayMove move)
        {
            if (move is ITicTacToeMove)
            {
                DoTicTacToeMove((ITicTacToeMove)move);
            }
        }

        public void DoTicTacToeMove(ITicTacToeMove move)
        {
            if (move.Row >= 0 && move.Row < 3 && move.Column >= 0 && move.Column < 3)
            {
                _Field[move.Row, move.Column] = move.PlayerNumber;
            }
        }
    }

    public class E_TicTacToeField : ITicTacToeField
    {
        int[,] _Field = new int[3, 3] { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } };

        public int this[int r, int c]
        {
            get
            {
                if (r >= 0 && r < 3 && c >= 0 && c < 3)
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
                if (r >= 0 && r < 3 && c >= 0 && c < 3)
                {
                    _Field[r, c] = value;
                }
            }
        }

        public bool CanBePaintedBy(IPaintGame painter)
        {
            return painter is IPaintTicTacToe;
        }
    }

    public class E_TicTacToeMove : ITicTacToeMove
    {
        int _Row = 0;
        int _Column = 0;
        int _PlayerNumber = 0;

        public E_TicTacToeMove(int row, int column, int playerNumber)
        {
            _Row = row;
            _Column = column;
            _PlayerNumber = playerNumber;
        }

        public int Row { get { return _Row; } }

        public int Column { get { return _Column; } }

        public int PlayerNumber { get { return _PlayerNumber; } }
    }

    public class E_TicTacToeHumanPlayer : IHumanTicTacToePlayer
    {
        int _PlayerNumber = 0;

        public string Name { get { return "E_HumanTicTacToePlayer"; } }

        public int PlayerNumber { get { return _PlayerNumber; } }

        public bool CanBeRuledBy(IGameRules rules)
        {
            return rules is ITicTacToeRules;
        }

        public IGamePlayer Clone()
        {
            E_TicTacToeHumanPlayer ttthp = new E_TicTacToeHumanPlayer();
            ttthp.SetPlayerNumber(_PlayerNumber);
            return ttthp;
        }

        public ITicTacToeMove GetMove(IMoveSelection selection, ITicTacToeField field)
        {
            if (selection is IClickSelection)
            {
                IClickSelection sel = (IClickSelection)selection;
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (sel.XClickPos > 20 + (j * 100) && sel.XClickPos < 120 + (j * 100) &&
                            sel.YClickPos > 20 + (i * 100) && sel.YClickPos < 120 + (i * 100) &&
                            field[i, j] <= 0)
                        {
                            return new E_TicTacToeMove(i, j, _PlayerNumber);
                        }
                    }
                }
            }

            return null;
        }

        public IPlayMove GetMove(IMoveSelection selection, IGameField field)
        {
            if (field is ITicTacToeField)
            {
                return GetMove(selection, (ITicTacToeField)field);
            }
            else
            {
                return null;
            }
        }

        public void SetPlayerNumber(int playerNumber)
        {
            _PlayerNumber = playerNumber;
        }
    }

    public class E_TicTacToeComputerPlayer_easy : IComputerTicTacToePlayer
    {
        int _PlayerNumber = 0;

        public string Name { get { return "E_ComputerTicTacToePlayer_easy"; } }

        public int PlayerNumber { get { return _PlayerNumber; } }

        public bool CanBeRuledBy(IGameRules rules)
        {
            return rules is ITicTacToeRules;
        }

        public IGamePlayer Clone()
        {
            E_TicTacToeComputerPlayer_easy ttthp = new E_TicTacToeComputerPlayer_easy();
            ttthp.SetPlayerNumber(_PlayerNumber);
            return ttthp;
        }

        public ITicTacToeMove GetMove(ITicTacToeField field)
        {
            Random rand = new Random();
            int f = rand.Next(0, 8);
            for (int i = 0; i < 9; i++)
            {
                int c = f % 3;
                int r = ((f - c) / 3) % 3;
                if (field[r, c] <= 0)
                {
                    return new E_TicTacToeMove(r, c, _PlayerNumber);
                }
                else
                {
                    f++;
                }
            }

            return null;
        }

        public IPlayMove GetMove(IGameField field)
        {
            if (field is ITicTacToeField)
            {
                return GetMove((ITicTacToeField)field);
            }
            else
            {
                return null;
            }
        }

        public void SetPlayerNumber(int playerNumber)
        {
            _PlayerNumber = playerNumber;
        }
    }

    public class E_TicTacToeComputerPlayer_hard : IComputerTicTacToePlayer
    {
        int _PlayerNumber = 0;

        public string Name { get { return "E_ComputerTicTacToePlayer_hard"; } }


        public int PlayerNumber { get { return _PlayerNumber; } }

        public bool CanBeRuledBy(IGameRules rules)
        {
            return rules is E_TicTacToeRules;
        }

        public IGamePlayer Clone()
        {

            E_TicTacToeComputerPlayer_hard ttthp = new E_TicTacToeComputerPlayer_hard();

            ttthp.SetPlayerNumber(_PlayerNumber);
            return ttthp;
        }

        public ITicTacToeMove GetMove(ITicTacToeField field)
        {

            
            int _Ecounterzero = 0;
            int _Espotsum = 0;
            int _Etempspotsum = 0;
            int _Erow = 1;
            int _Ecoloumn = 1;
            int c = 1;
            int r = 1;
            bool notloose = false;
            int notlooserow = 0;
            int notloosecoloumn = 0;

            //Anfangszug
            if (field[0,2]==0 )
            {
                return new TicTacToeMove(0, 2, _PlayerNumber);
            }
            else if (field[1, 1] == 0)
            {
               return new TicTacToeMove(1, 1, _PlayerNumber);
            }

            //zeilen
            for (r = 0; r < 3; r++)
            {
                for (c = 0; c < 3; c++)
                {
                    _Etempspotsum = field[r, c];
                    _Espotsum += _Etempspotsum;
                    if (_Etempspotsum == 0)
                    {
                        _Erow = r;
                        _Ecoloumn = c;
                        _Ecounterzero++;
                    }
                }
                if (_Ecounterzero == 1 && _Espotsum % 2 == 0)
                {
                    if (_Espotsum/2==_PlayerNumber )
                    {
                        return new E_TicTacToeMove(_Erow, _Ecoloumn, _PlayerNumber);
                    }
                    else
                    {
                        notloose = true;
                        notlooserow = _Erow;
                        notloosecoloumn = _Ecoloumn;
                    }
                }
                _Ecounterzero = 0;
                _Etempspotsum = 0;
            }

            //Spalten
            for (c = 0; c < 3; c++)
            {
                for (r = 0; r < 3; r++)
                {
                    _Etempspotsum = field[r, c];
                    _Espotsum += _Etempspotsum;
                    if (_Etempspotsum == 0)
                    {
                        _Erow = r;
                        _Ecoloumn = c;
                        _Ecounterzero++;
                    }
                }
                if (_Ecounterzero == 1 && _Espotsum % 2 == 0)
                {
                    if (_Espotsum / 2 == _PlayerNumber)
                    {
                        return new E_TicTacToeMove(_Erow, _Ecoloumn, _PlayerNumber);
                    }
                    else
                    {
                        notloose = true;
                        notlooserow = _Erow;
                        notloosecoloumn = _Ecoloumn;
                    }
                }
                _Ecounterzero = 0;
                _Etempspotsum = 0;
            }
            //rechts oben nach links unten
            int c1 = 0;
            for (r = 0; r < 3; r++)
            {
                _Etempspotsum = field[r, c1];
                _Espotsum += _Etempspotsum;
                if (_Etempspotsum == 0)
                {
                    _Erow = r;
                    _Ecoloumn = c1;
                    _Ecounterzero++;
                }
                c1++;
            }

            if (_Ecounterzero == 1 && _Espotsum % 2 == 0)
            {
                if (_Espotsum / 2 == _PlayerNumber)
                {
                    return new E_TicTacToeMove(_Erow, _Ecoloumn, _PlayerNumber);
                }
                else
                {
                    notloose = true;
                    notlooserow = _Erow;
                    notloosecoloumn = _Ecoloumn;
                }
            }
            _Ecounterzero = 0;
            _Etempspotsum = 0;

            //rechts nach links unten
            int c2 = 0;
            for (r = 0; r < 3; r++)
            {
                _Etempspotsum = field[r, c2];
                _Espotsum += _Etempspotsum;
                if (_Etempspotsum == 0)
                {
                    _Erow = r;
                    _Ecoloumn = c2;
                    _Ecounterzero++;
                }
                c2++;
            }

            if (_Ecounterzero == 1 && _Espotsum % 2 == 0)
            {
                if (_Espotsum / 2 == _PlayerNumber)
                {
                    return new E_TicTacToeMove(_Erow, _Ecoloumn, _PlayerNumber);
                }
                else
                {
                    notloose = true;
                    notlooserow = _Erow;
                    notloosecoloumn = _Ecoloumn;
                }
            }
            _Ecounterzero = 0;
            _Etempspotsum = 0;


            Random rand = new Random();
            int f = rand.Next(0, 8);
            for (int i = 0; i < 9; i++)
            {
                int _cRandom = f % 3;
                int _rRandom = ((f - _cRandom) / 3) % 3;
                if (field[_rRandom, _cRandom] <= 0)
                {
                    return new E_TicTacToeMove(_rRandom, _cRandom, _PlayerNumber);
                }
                else
                {
                    f++;
                }

            }
           

            return null;
        }

        public IPlayMove GetMove(IGameField field)
        {
            if (field is ITicTacToeField)
            {
                return GetMove((ITicTacToeField)field);
            }
            else
            {
                return null;
            }
        }
        public void SetPlayerNumber(int playerNumber)
        {
            _PlayerNumber = playerNumber;
        }
    }

}