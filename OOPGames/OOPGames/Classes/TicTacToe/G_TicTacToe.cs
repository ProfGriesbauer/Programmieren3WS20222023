//Abfrage in HumanPlayer _size == 0 => 3 um Kompartibilität zu gewährleisten
//ClickEvent abhängig von Anzahl der Feldergröße


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows;
using OOPGames;

namespace OOPGames
{
    public class G_TicTacToePaint : BaseTicTacToePaint
    {
        public override string Name { get { return "G_TicTacToePaint"; } }

        public override void PaintTicTacToeField(Canvas canvas, ITicTacToeField currentField)
        {
            canvas.Children.Clear();
            Color bgColor = Color.FromRgb(0, 0, 0);
            canvas.Background = new SolidColorBrush(bgColor);
            Color lineColor = Color.FromRgb(255, 0, 0);
            Brush lineStroke = new SolidColorBrush(lineColor);
            Color XColor = Color.FromRgb(0, 255, 0);
            Brush XStroke = new SolidColorBrush(XColor);
            Color OColor = Color.FromRgb(0, 0, 255);
            Brush OStroke = new SolidColorBrush(OColor);

            //Feldgröße Gruppe G: 400x400px
            // Schleife zur skalierung der Linien
            Line l1 = new Line() { X1 = 120, Y1 = 0, X2 = 120, Y2 = 428, Stroke = lineStroke, StrokeThickness = 3.0 };
            canvas.Children.Add(l1);
            
            // Variable Schleifenlänge je nach Größe des Feldes
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
    public class G_TicTacToeField : BaseTicTacToeField
    {
        static int _size = 3;

        public int Size { get { return _size; } }

        int[,] _Field = new int[_size, _size];

        public override int this[int r, int c]
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
    }
}


public class G_TicTacToeRules : BaseTicTacToeRules
{
    G_TicTacToeField _Field = new G_TicTacToeField();

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

    public override string Name { get { return "GriesbauerTicTacToeRules"; } }

    public override int CheckIfPLayerWon()
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

    public override void DoTicTacToeMove(ITicTacToeMove move)
    {
        if (move.Row >= 0 && move.Row < 3 && move.Column >= 0 && move.Column < 3)
        {
            _Field[move.Row, move.Column] = move.PlayerNumber;
        }
    }
}



