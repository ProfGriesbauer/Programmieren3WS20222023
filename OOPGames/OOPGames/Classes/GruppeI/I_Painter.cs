using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace OOPGames.Classes.GruppeI
{
    public class PainterI : BaseTicTacToePaint
    {
        public override string Name { get { return "Painter Gruppe I"; } }

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
            int skalar=20;


            void paintLine (int X1, int Y1, int X2, int Y2, float thickness) //Funktion vereinfacht das Zeichnen von Linien
            {
                Line lx = new Line() { X1 = skalar*X1, Y1 = skalar*Y1, X2 = skalar*X2, Y2 = skalar*Y2, Stroke=lineStroke, StrokeThickness= thickness };
                canvas.Children.Add(lx);
            }


            //Zeichne groﬂes TTT-Feld
            paintLine(1,1,1,28,6);
            paintLine(10,1,10,28,6);
            paintLine(19,1,19,28,6);
            paintLine(28,1,28,28,6);

            paintLine(1,1,28,1,6);
            paintLine(1,10,28,10,6);
            paintLine(1,19,28,19,6);
            paintLine(1,28,28,28,6);
        }

    }
}
