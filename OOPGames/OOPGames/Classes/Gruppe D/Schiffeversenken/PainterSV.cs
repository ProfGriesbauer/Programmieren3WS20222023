using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace OOPGames.Classes.Gruppe_D.Schiffeverseanken
{
    internal class PainterSV : IPaintSV
    {
        public string Name { get { return "SiffeverseankenPainterD"; } }

        public void PaintGameField(Canvas canvas, IGameField currentField)
        {
            if (currentField is IFieldSV)
            {
                PaintShipField(canvas, (IFieldSV)currentField);
            }
        }

        public void PaintShipField(Canvas canvas, IFieldSV currentField)
        {
            int GamePhase = currentField.Phase;

            if (GamePhase == 1 || GamePhase == 2)
            {
                string _player = "";
                if(GamePhase == 2)
                {
                    _player = "P2";
                }
                else { _player = "P1"; }

                canvas.Children.Clear();
                Color bgColor = Color.FromRgb(255, 255, 255);
                canvas.Background = new SolidColorBrush(bgColor);
                Color lineColor = Color.FromRgb(0, 0, 0);
                Brush lineStroke = new SolidColorBrush(lineColor);

                TextBlock textP1 = new TextBlock();
                textP1.Text = _player;
                textP1.Foreground = new SolidColorBrush(lineColor);
                textP1.FontSize = 40;
                Canvas.SetLeft(textP1, 200);
                Canvas.SetTop(textP1, 0);
                canvas.Children.Add(textP1);

                for (int x = 20; x <= 420; x = x + 50)
                {
                    Line l = new Line() { X1 = x, Y1 = 50, X2 = x, Y2 = 450, Stroke = lineStroke, StrokeThickness = 3.0 };
                    canvas.Children.Add(l);
                }
                for (int y = 50; y <= 450; y = y + 50)
                {
                    Line l = new Line() { X1 = 20, Y1 = y, X2 = 420, Y2 = y , Stroke = lineStroke, StrokeThickness = 3.0 };
                    canvas.Children.Add(l);
                }
            }
            
            if (GamePhase == 3) 
            {
                canvas.Children.Clear();
                Color bgColor = Color.FromRgb(255, 255, 255);
                canvas.Background = new SolidColorBrush(bgColor);
                Color lineColor = Color.FromRgb(0, 0, 0);
                Brush lineStroke = new SolidColorBrush(lineColor);

                TextBlock textP1 = new TextBlock();
                textP1.Text = "P1 ";
                textP1.Foreground = new SolidColorBrush(lineColor);
                textP1.FontSize = 40;
                Canvas.SetLeft(textP1, 200);
                Canvas.SetTop(textP1, 0);
                canvas.Children.Add(textP1);

                TextBlock textP2 = new TextBlock();
                textP2.Text = "P2 ";
                textP2.Foreground = new SolidColorBrush(lineColor);
                textP2.FontSize = 40;
                Canvas.SetLeft(textP2, 630);
                Canvas.SetTop(textP2, 0);
                canvas.Children.Add(textP2);


                for (int x = 20; x <= 420; x = x + 50)
                {
                    Line l = new Line() { X1 = x, Y1 = 50, X2 = x, Y2 = 450, Stroke = lineStroke, StrokeThickness = 3.0 };
                    canvas.Children.Add(l);
                }
                for (int y = 50; y <= 450; y = y + 50)
                {
                    Line l = new Line() { X1 = 20, Y1 = y, X2 = 420, Y2 = y, Stroke = lineStroke, StrokeThickness = 3.0 };
                    canvas.Children.Add(l);
                }

                for (int x = 450; x <= 850; x = x + 50)
                {
                    Line l = new Line() { X1 = x, Y1 = 50, X2 = x, Y2 = 450, Stroke = lineStroke, StrokeThickness = 3.0 };
                    canvas.Children.Add(l);
                }
                for (int y = 50; y <= 450; y = y + 50)
                {
                    Line l = new Line() { X1 = 450, Y1 = y, X2 = 850, Y2 = y, Stroke = lineStroke, StrokeThickness = 3.0 };
                    canvas.Children.Add(l);
                }
            }
        }
    }

}
