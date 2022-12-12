using Microsoft.Win32;
using OOPGames.Classes.Gruppe_C;
using OOPGames.Interfaces.Gruppe_E;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace OOPGames.Classes.Gruppe_E
{
    public class E_VierGewinnt_Painter : I_E_PaintVierGewinnt
    {
        public string Name { get { return "E_VierGewinntPainter"; } }

        public void PaintGameField(Canvas canvas, IGameField currentField)
        {
            if (currentField is I_E_VierGewinntField)
            {
                PaintVierGewinntField(canvas, (I_E_VierGewinntField)currentField);
            }
        }

        // Festlegung Farben und Zeichnen Spielfeld
        public void PaintVierGewinntField(Canvas canvas, I_E_VierGewinntField currentField)
        {
            canvas.Children.Clear();
            Color bgColor = Color.FromRgb(0, 0, 0);
            canvas.Background = new SolidColorBrush(bgColor);
            Color lineColor = Color.FromRgb(255, 255, 255);
            Brush lineStroke = new SolidColorBrush(lineColor);
            Color ColorOne = Color.FromRgb(0, 191, 255);
            Brush StrokeOne = new SolidColorBrush(ColorOne);
            Color ColorTwo = Color.FromRgb(255, 127, 0);
            Brush StrokeTwo = new SolidColorBrush(ColorTwo);

            int X1 = 0;
            int X2 = 0;
            int Y1 = 0;
            int Y2 = 0;

            for (int i = 20; i <= 615; i += 85)
            {
                Line l1 = new Line() { X1 = i, Y1 = 20, X2 = i, Y2 = 530, Stroke = lineStroke, StrokeThickness = 3.0 };
                canvas.Children.Add(l1);
            }
            for (int j = 20; j <= 530; j += 85)
            {
                Line l2 = new Line() { X1 = 20, Y1 = j, X2 = 615, Y2 = j, Stroke = lineStroke, StrokeThickness = 3.0 };
                canvas.Children.Add(l2);
            }

            // Formen zeichnen
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    if (currentField[i, j] == 1)
                    {
                        //Rectangle ROne = new Rectangle() { Margin = new Thickness(21.5 + (j * 85), 21.5 + (i * 85), 0, 0), Width = 82, Height = 82, Stroke = StrokeOne, StrokeThickness = 45 };
                        //canvas.Children.Add(ROne);
                        Ellipse EOne = new Ellipse() { Margin = new Thickness(21.5 + (j * 85), 21.5 + (i * 85), 0, 0), Width = 82, Height = 82, Stroke = StrokeOne, StrokeThickness = 45.0 };
                        canvas.Children.Add(EOne);
                    }
                    else if (currentField[i, j] == 2)
                    {

                        Ellipse ETwo = new Ellipse() { Margin = new Thickness(21.5 + (j * 85), 21.5 + (i * 85), 0, 0), Width = 82, Height = 82, Stroke = StrokeTwo, StrokeThickness = 45.0 };
                        canvas.Children.Add(ETwo);
                    }
                }
            }
        }
    }
    public class E_VierGewinntRules : I_E_VierGewinntRules
    {
        E_VierGewinntField _Field = new E_VierGewinntField();
        public I_E_VierGewinntField VierGewinntField { get { return _Field; } }

        public string Name { get { return "E_VierGewinntRules"; } }

        public IGameField CurrentField { get { return E_VierGewinntField; } }
        public I_E_VierGewinntField E_VierGewinntField { get { return _Field; } }

        public bool MovesPossible
        {
            get
            {
                for (int i = 0; i < 6; i++)
                {
                    for (int j = 0; j < 7; j++)
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

        public int CheckIfPLayerWon()
        {
            //Abfrage: 4 in einer Zeile
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (_Field[i, j] > 0 && _Field[i, j] == _Field[i, j + 1] && _Field[i, j] == _Field[i, j + 2] && _Field[i, j] == _Field[i, j + 3])
                    {
                        return _Field[i, j];
                    }
                }
            }

            //Abfrage: 4 in einer Spalte
            for (int j = 0; j < 7; j++)
            {
                for (int i = 0; i < 3; i++)
                {
                    if (_Field[i, j] > 0 && _Field[i, j] == _Field[i + 1, j] && _Field[i, j] == _Field[i + 2, j] && _Field[i, j] == _Field[i + 3, j])
                    {
                        return _Field[i, j];
                    }
                }
            }

            //Abfrage: 4 Diagonal
            //Immer die ersten 4 Felder einer Zeile nacheinander als Start für eine Diagonale
            //Oben links nach unten rechts
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (_Field[i, j] > 0 && _Field[i, j] == _Field[i + 1, j + 1] && _Field[i, j] == _Field[i + 2, j + 2] && _Field[i, j] == _Field[i + 3, j + 3])
                    {
                        return _Field[i, j];
                    }
                }
            }

            //Unten links nach oben rechts
            for (int i = 5; i > 2; i--)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (_Field[i, j] > 0 && _Field[i, j] == _Field[i - 1, j + 1] && _Field[i, j] == _Field[i - 2, j + 2] && _Field[i, j] == _Field[i - 3, j + 3])
                    {
                        return _Field[i, j];
                    }
                }
            }

            return -1;
        }

        public void ClearField()
        {
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    _Field[i, j] = 0;
                }
            }
        }

        public void DoMove(IPlayMove move)
        {
            if (move is I_E_VierGewinntMove)
            {
                DoVierGewinntMove((I_E_VierGewinntMove)move);
            }
        }

        public void DoVierGewinntMove(I_E_VierGewinntMove move)
        {
            if (move.Row >= 0 && move.Row < 6 && move.Column >= 0 && move.Column < 7)
            {
                _Field[move.Row, move.Column] = move.PlayerNumber;
            }
        }
    }
    public class E_VierGewinntHumanPlayer : I_E_VierGewinntHumanPlayer
    {
        int _PlayerNumber = 0;
        public string Name { get { return "E_HumanVierGewinntPlayer"; } }

        public int PlayerNumber { get { return _PlayerNumber; } }

        public bool CanBeRuledBy(IGameRules rules)
        {
            return rules is I_E_VierGewinntRules;
        }

        public IGamePlayer Clone()
        {
            E_VierGewinntHumanPlayer vghp = new E_VierGewinntHumanPlayer();
            vghp.SetPlayerNumber(_PlayerNumber);
            return vghp;
        }

        public I_E_VierGewinntMove GetMove(IMoveSelection selection, I_E_VierGewinntField field)
        {
            if (selection is IClickSelection)
            {
                IClickSelection sel = (IClickSelection)selection;
                for (int i = 0; i < 6; i++)
                {
                    for (int j = 0; j < 7; j++)
                    {
                        if (sel.XClickPos > 20 + (j * 85) && sel.XClickPos < 105 + (j * 85) &&
                            sel.YClickPos > 20 + (i * 85) && sel.YClickPos < 105 + (i * 85) &&
                            field[i, j] <= 0
                            )
                        {
                            for (int y = 0; y < 6; y++)
                            {
                                if (field[y, j] > 0)
                                {
                                    return new E_VierGewinntMove(y - 1, j, _PlayerNumber);
                                }
                                else if (field[5, j] <= 0)
                                {
                                    return new E_VierGewinntMove(5, j, _PlayerNumber);
                                }
                            }
                        }
                    }
                }
            }

            return null;
        }

        public IPlayMove GetMove(IMoveSelection selection, IGameField field)
        {
            if (field is I_E_VierGewinntField)
            {
                return GetMove(selection, (I_E_VierGewinntField)field);
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
    public class E_VierGewinntComputerPlayer_Random : I_E_VierGewinntComputerPlayer
    {
        int _PlayerNumber = 0;
        public string Name { get { return "E_VierGewinntComputerPlayer"; } }

        public int PlayerNumber { get { return _PlayerNumber; } }

        public bool CanBeRuledBy(IGameRules rules)
        {
            return rules is I_E_VierGewinntRules;
        }

        public IGamePlayer Clone()
        {
            E_VierGewinntComputerPlayer_Random vgcp = new E_VierGewinntComputerPlayer_Random();
            vgcp.SetPlayerNumber(_PlayerNumber);
            return vgcp;
        }

        public I_E_VierGewinntMove GetMove(I_E_VierGewinntField field)
        {
            Random rand = new Random();

            for (int z = 0; z < 100; z++)
            {
                int c = rand.Next(0, 7);
                if (field[5, c] <= 0)
                {
                    z = 100;
                    return new E_VierGewinntMove(5, c, _PlayerNumber);
                }
                else
                {
                    for (int r = 0; r < 6; r++)
                    {
                        if (field[r, c] > 0 && r != 0)
                        {
                            z = 100;
                            return new E_VierGewinntMove(r - 1, c, _PlayerNumber);
                        }
                        else if (field[r, c] > 0 && r == 0)
                        {
                            r = 6;
                        }
                    }
                }
                //    for (int r = 0; r < 6; r++)
                //    {
                //        if (field[r, c] > 0)
                //        {
                //            z = 1000;
                //            return new E_VierGewinntMove(r - 1, c, _PlayerNumber);
                //        }
                //        else if (field[5, c] <= 0)
                //        {
                //            z = 1000;
                //            return new E_VierGewinntMove(5, c, _PlayerNumber);
                //        }
                //    }
            }

            /*int f = rand.Next(0, 41);
            for (int i=0;i<42;i++)
            {
                int c = f % 7;
                int r = ((f - c) / 7) % 7;
                if (field[r,c] <= 0)
                {
                    for (int y = 0; y < 6; y++)
                    {
                        if (field[y, c] > 0)
                        {
                            return new E_VierGewinntMove(y - 1, c, _PlayerNumber);
                        }
                        else if (field[5, c] <= 0)
                        {
                            return new E_VierGewinntMove(5, c, _PlayerNumber);
                        }
                    }
                }
                else
                {
                    f++;
                }
            }*/
            return null;
        }

        public IPlayMove GetMove(IGameField field)
        {
            if (field is I_E_VierGewinntField)
            {
                return GetMove((I_E_VierGewinntField)field);
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
    public class E_VierGewinntField : I_E_VierGewinntField
    {
        int[,] _Field = new int[6, 7] { { 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0 } };
        public int this[int r, int c]
        {
            get
            {
                if (r >= 0 && r < 6 && c >= 0 && c < 7)
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
                if (r >= 0 && r < 6 && c >= 0 && c < 7)
                {
                    _Field[r, c] = value;
                }
            }
        }

        public bool CanBePaintedBy(IPaintGame painter)
        {
            return painter is I_E_PaintVierGewinnt;
        }
    }
    public class E_VierGewinntMove : I_E_VierGewinntMove
    {
        int _Row = 0;
        int _Column = 0;
        int _PlayerNumber = 0;

        public E_VierGewinntMove(int row, int column, int playerNumber)
        {
            _Row = row;
            _Column = column;
            _PlayerNumber = playerNumber;
        }

        public int Row { get { return _Row; } }
        public int Column { get { return _Column; } }
        public int PlayerNumber { get { return _PlayerNumber; } }
    }
}


