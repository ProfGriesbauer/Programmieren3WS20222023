using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows;

namespace OOPGames
{
    public class TTTPaint : BaseTicTacToePaint
    {
        public override string Name { get { return "TTTPainter Gruppe F"; } }

        public override void PaintTicTacToeField(Canvas canvas, ITicTacToeField currentField)
        {
           
            canvas.Children.Clear();
            Color bgColor = Color.FromRgb(0, 0, 0);
            canvas.Background = new SolidColorBrush(bgColor);
            Color lineColor = Color.FromRgb(0, 255, 255);
            Brush lineStroke = new SolidColorBrush(lineColor);
            Color XColor = Color.FromRgb(255, 255, 0);
            Brush XStroke = new SolidColorBrush(XColor);
            Color OColor = Color.FromRgb(255, 102, 255);
            Brush OStroke = new SolidColorBrush(OColor);
            Color LooseColor = Color.FromRgb(255, 0, 0);
            Brush LooseStroke = new SolidColorBrush(LooseColor);
            Line l1 = new Line() { X1 = 120, Y1 = 10, X2 = 120, Y2 = 330, Stroke = lineStroke, StrokeThickness = 8.0 };
            canvas.Children.Add(l1);
            Line l2 = new Line() { X1 = 220, Y1 = 10, X2 = 220, Y2 = 330, Stroke = lineStroke, StrokeThickness = 8.0 };
            canvas.Children.Add(l2);
            Line l3 = new Line() { X1 = 10, Y1 = 120, X2 = 330, Y2 = 120, Stroke = lineStroke, StrokeThickness = 8.0 };
            canvas.Children.Add(l3);
            Line l4 = new Line() { X1 = 10, Y1 = 220, X2 = 330, Y2 = 220, Stroke = lineStroke, StrokeThickness = 8.0 };
            canvas.Children.Add(l4);
            
            /*if (currentField is IFTicTacToeField)
            {
                if (((IFTicTacToeField)currentField).CurrentWinner == 1)
                {
                    
                    Line l0 = new Line() { X1 = 10, Y1 = 170, X2 = 330, Y2 = 170, Stroke = LooseStroke, StrokeThickness = ((IFTicTacToeField)currentField).Thickness };
                    canvas.Children.Add(l0);
                }
                else if (((IFTicTacToeField)currentField).CurrentWinner == 2){
                    Line l0 = new Line() { X1 = 10, Y1 = 170, X2 = 330, Y2 = 170, Stroke = lineStroke, StrokeThickness = ((IFTicTacToeField)currentField).Thickness };
                    canvas.Children.Add(l0);
                }
                
            }
            */
            

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (currentField[i, j] == 1)
                    {
                       
                        Line X1 = new Line() { X1 = 30 + (j * 100), Y1 = 30 + (i * 100), X2 = 110 + (j * 100), Y2 = 110 + (i * 100), Stroke = XStroke, StrokeThickness = 3.0 };
                        canvas.Children.Add(X1);
                        Line X2 = new Line() { X1 = 30 + (j * 100), Y1 = 110 + (i * 100), X2 = 110 + (j * 100), Y2 = 30 + (i * 100), Stroke = XStroke, StrokeThickness = 3.0 };
                        canvas.Children.Add(X2);
                    }
                    else if (currentField[i, j] == 2)
                    {
                        Ellipse OE = new Ellipse() { Margin = new Thickness(30 + (j * 100), 30 + (i * 100), 0, 0), Width = 80, Height = 80, Stroke = OStroke, StrokeThickness = 3.0 };
                        canvas.Children.Add(OE);
                    }
                }
            }
        }
    }
}
