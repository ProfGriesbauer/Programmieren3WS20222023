using OOPGames.Classes.Gruppe_D;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Ink;
using System.Windows.Media;
using System.Windows.Shapes;

namespace OOPGames
{
    public class PainterD : IPaintTicTacToe
    {
        public string Name { get { return "DerKrasseMaler"; } }

        public void PaintGameField(Canvas canvas, IGameField currentField)
        {

            if (currentField is BOFField)
            {
                BOFPaintTicTacToeField(canvas, (BOFField)currentField);
            }
            else if (currentField is ITicTacToeField)
            {
                PaintTicTacToeField(canvas, (ITicTacToeField)currentField);
            }
            
        }

        public void PaintTicTacToeField(Canvas canvas, ITicTacToeField currentField)
        {
            canvas.Children.Clear();

            Color Black = Color.FromRgb(0, 0, 0);
            canvas.Background = new SolidColorBrush(Black);

            Color white = Color.FromRgb(255, 255, 255);
            Brush lineColor = new SolidColorBrush(white);

            Color P1 = Color.FromRgb(0, 0, 255);
            Brush P1Color = new SolidColorBrush(P1);

            Color P2 = Color.FromRgb(255, 0, 0);
            Brush P2Color = new SolidColorBrush(P2);

            Line l1 = new Line() { X1 = 150, Y1 = 50, X2 = 150, Y2 = 350, Stroke = lineColor, StrokeThickness = 3.0 }; // y-Strich
            canvas.Children.Add(l1);

            Line l2 = new Line() { X1 = 250, Y1 = 50, X2 = 250, Y2 = 350, Stroke = lineColor, StrokeThickness = 3.0 }; // y-Strich
            canvas.Children.Add(l2);

            Line l3 = new Line() { X1 = 50, Y1 = 150, X2 = 350, Y2 = 150, Stroke = lineColor, StrokeThickness = 3.0 }; //x-Strich
            canvas.Children.Add(l3);

            Line l4 = new Line() { X1 = 50, Y1 = 250, X2 = 350, Y2 = 250, Stroke = lineColor, StrokeThickness = 3.0 }; //x-Strich
            canvas.Children.Add(l4);

            for (int i = 0; i < 3; i++ )
            {
                for (int j = 0; j < 3; j++)
                {
                    if (currentField[i, j] == 1)
                    {
                        Ellipse ellipse = new Ellipse() { Margin = new Thickness(55 + (j * 100), 55 + (i * 100), 0, 0), Width = 90, Height = 90, Stroke = P1Color, StrokeThickness = 3.0 };
                        canvas.Children.Add(ellipse);
                    }
                    if (currentField[i, j] == 2)
                    {
                        Line X1 = new Line() { X1 = 55 + (j * 100), Y1 = 55 + (i * 100), X2 = 145 + (j * 100), Y2 = 145 + (i * 100), Stroke = P2Color, StrokeThickness = 3.0 };
                        canvas.Children.Add(X1);
                        Line X2 = new Line() { X1 = 145 + (j * 100), Y1 = 55 + (i * 100), X2 = 55 + (j * 100), Y2 = 145 + (i * 100), Stroke = P2Color, StrokeThickness = 3.0 };
                        canvas.Children.Add(X2);
                    }
                }
            }
        }
        public void BOFPaintTicTacToeField(Canvas canvas, BOFField currentField)
        {
            canvas.Children.Clear();

            Color Black = Color.FromRgb(0, 0, 0); //geändert
            canvas.Background = new SolidColorBrush(Black);

            Color white = Color.FromRgb(255, 255, 255);
            Brush lineColor = new SolidColorBrush(white);

            Color P1 = Color.FromRgb(0, 0, 255);
            Brush P1Color = new SolidColorBrush(P1);

            Color P2 = Color.FromRgb(255, 0, 0);
            Brush P2Color = new SolidColorBrush(P2);

            Line l1 = new Line() { X1 = 150, Y1 = 50, X2 = 150, Y2 = 350, Stroke = lineColor, StrokeThickness = 3.0 }; // y-Strich
            canvas.Children.Add(l1);

            Line l2 = new Line() { X1 = 250, Y1 = 50, X2 = 250, Y2 = 350, Stroke = lineColor, StrokeThickness = 3.0 }; // y-Strich
            canvas.Children.Add(l2);

            Line l3 = new Line() { X1 = 50, Y1 = 150, X2 = 350, Y2 = 150, Stroke = lineColor, StrokeThickness = 3.0 }; //x-Strich
            canvas.Children.Add(l3);

            Line l4 = new Line() { X1 = 50, Y1 = 250, X2 = 350, Y2 = 250, Stroke = lineColor, StrokeThickness = 3.0 }; //x-Strich
            canvas.Children.Add(l4);

            TextBlock textP1 = new TextBlock();
            textP1.Text = "P1 " + currentField.player1wins;
            textP1.Foreground = new SolidColorBrush(white);
            textP1.FontSize = 50;
            Canvas.SetLeft(textP1, 400);
            Canvas.SetTop(textP1, 50);
            canvas.Children.Add(textP1);

            TextBlock textP2 = new TextBlock();
            textP2.Text = "P2 " + currentField.player2wins;
            textP2.Foreground = new SolidColorBrush(white);
            textP2.FontSize = 50;
            Canvas.SetLeft(textP2, 400);
            Canvas.SetTop(textP2, 150);
            canvas.Children.Add(textP2);

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (currentField[i, j] == 1)
                    {
                        Ellipse ellipse = new Ellipse() { Margin = new Thickness(55 + (j * 100), 55 + (i * 100), 0, 0), Width = 90, Height = 90, Stroke = P1Color, StrokeThickness = 3.0 };
                        canvas.Children.Add(ellipse);
                    }
                    if (currentField[i, j] == 2)
                    {
                        Line X1 = new Line() { X1 = 55 + (j * 100), Y1 = 55 + (i * 100), X2 = 145 + (j * 100), Y2 = 145 + (i * 100), Stroke = P2Color, StrokeThickness = 3.0 };
                        canvas.Children.Add(X1);
                        Line X2 = new Line() { X1 = 145 + (j * 100), Y1 = 55 + (i * 100), X2 = 55 + (j * 100), Y2 = 145 + (i * 100), Stroke = P2Color, StrokeThickness = 3.0 };
                        canvas.Children.Add(X2);
                    }
                }
            }
        }
    }
}
