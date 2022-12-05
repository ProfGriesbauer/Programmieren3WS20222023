using Microsoft.Win32;
using OOPGames.Interfaces.Gruppe_E;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace OOPGames.Classes.Gruppe_E
{
    public class E_VierGewinnt_Painter : I_E_PaintVierGewinnt
    {
        public string Name { get { return "E_PaintVierGewinnt"; } }

        public void PaintGameField(Canvas canvas, IGameField currentField)
        {
            if (currentField is I_E_VierGewinntField)
            {
                PaintVierGewinntField(canvas, (I_E_VierGewinntField)currentField);
            }
        }

        public void PaintVierGewinntField(Canvas canvas, I_E_VierGewinntField currentField)
        {
            canvas.Children.Clear();
            Color bgColor = Color.FromRgb(0, 0, 0);
            canvas.Background = new SolidColorBrush(bgColor);
            Color lineColor = Color.FromRgb(255, 255, 255);
            Brush lineStroke = new SolidColorBrush(lineColor);
            Color XColor = Color.FromRgb(0, 191, 255);
            Brush XStroke = new SolidColorBrush(XColor);
            Color OColor = Color.FromRgb(255, 127, 0);
            Brush OStroke = new SolidColorBrush(OColor);

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

        public int CheckIfPLayerWon() // Regeln anpassen
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
}
 
    
