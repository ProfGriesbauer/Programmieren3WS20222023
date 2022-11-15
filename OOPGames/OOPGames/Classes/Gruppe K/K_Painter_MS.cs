using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace OOPGames.Classes.Gruppe_K
{
    public interface IRotatingField
    {
        IClickSelection GetPosition(IClickSelection selection);
        void ISetRotationSpeed(float speed);
        void ISetSpeed(float xSpeed, float ySpeed);


    }
    class K_Painter_MS : IPaintTicTacToe, IPaintGame2, IRotatingField
    {
        float rot = 0f;
        float rotSpeed = 10f;
        int xOff = 50;
        int yOff = 50;
        public string Name { get { return "K Painter MS"; } }

        public IClickSelection GetPosition(IClickSelection selection)
        {
            throw new NotImplementedException();
        }

        public void ISetRotationSpeed(float speed)
        {
            throw new NotImplementedException();
        }

        public void ISetSpeed(float xSpeed, float ySpeed)
        {
            throw new NotImplementedException();
        }

        public void PaintGameField(Canvas canvas, IGameField currentField)
        {
            if (currentField is ITicTacToeField)
            {
                PaintTicTacToeField(canvas, (ITicTacToeField)currentField);
            }
        }

        public void PaintTicTacToeField(Canvas canvas, ITicTacToeField currentField)
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
            Line[] larr = new Line[8];
            larr[0] = new Line() { X1 = 120+xOff, Y1 = 20+yOff, X2 = 120+xOff, Y2 = 320+yOff, Stroke = lineStroke, StrokeThickness = 3.0 };
            canvas.Children.Add(larr[0]);
            larr[1] = new Line() { X1 = 220+xOff, Y1 = 20+yOff, X2 = 220+xOff, Y2 = 320+yOff, Stroke = lineStroke, StrokeThickness = 3.0 };
            canvas.Children.Add(larr[1]);
            larr[2] = new Line() { X1 = 20+xOff, Y1 = 120+yOff, X2 = 320+xOff, Y2 = 120+yOff, Stroke = lineStroke, StrokeThickness = 3.0 };
            canvas.Children.Add(larr[2]);
            larr[3] = new Line() { X1 = 20+xOff, Y1 = 220+yOff, X2 = 320+xOff, Y2 = 220+yOff, Stroke = lineStroke, StrokeThickness = 3.0 };
            canvas.Children.Add(larr[3]);
            larr[4] = new Line() { X1 = 20+xOff, Y1 = 320+yOff, X2 = 320+xOff, Y2 = 320+yOff, Stroke = lineStroke, StrokeThickness = 3.0 };
            canvas.Children.Add(larr[4]);
            larr[5] = new Line() { X1 = 20+xOff, Y1 = 20+yOff, X2 = 320+xOff, Y2 = 20+yOff, Stroke = lineStroke, StrokeThickness = 3.0 };
            canvas.Children.Add(larr[5]);
            larr[6] = new Line() { X1 = 20+xOff, Y1 = 320+yOff, X2 = 20+xOff, Y2 = 20+yOff, Stroke = lineStroke, StrokeThickness = 3.0 };
            canvas.Children.Add(larr[6]);
            larr[7] = new Line() { X1 = 320+xOff, Y1 = 320+yOff, X2 = 320+xOff, Y2 = 20+yOff, Stroke = lineStroke, StrokeThickness = 3.0 };
            canvas.Children.Add(larr[7]);
            RotateTransform rotateTransformObj =new RotateTransform(rot);
            rotateTransformObj.CenterX = 170+xOff;
            rotateTransformObj.CenterY = 170+yOff;

                for (int i = 0; i < larr.Length; i++)
            {
                larr[i].RenderTransform= rotateTransformObj;
            }

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (currentField[i, j] == 1)
                    {
                        Line X1 = new Line() { X1 = 20 + (j * 100)+xOff, Y1 = 20 + (i * 100)+yOff, X2 = 120 + (j * 100)+xOff, Y2 = 120 + (i * 100)+yOff, Stroke = XStroke, StrokeThickness = 3.0 };
                        canvas.Children.Add(X1);
                        Line X2 = new Line() { X1 = 20 + (j * 100)+xOff, Y1 = 120 + (i * 100)+yOff, X2 = 120 + (j * 100)+xOff, Y2 = 20 + (i * 100)+yOff, Stroke = XStroke, StrokeThickness = 3.0 };
                        canvas.Children.Add(X2);
                        X1.RenderTransform = rotateTransformObj;
                        X2.RenderTransform = rotateTransformObj;
                    }
                    else if (currentField[i, j] == 2)
                    {
                        Ellipse OE = new Ellipse() { Margin = new Thickness(20 + (j * 100)+xOff, 20 + (i * 100)+yOff, 0, 0), Width = 100, Height = 100, Stroke = OStroke, StrokeThickness = 3.0 };
                        Canvas wrap = new Canvas();
                        wrap.Children.Add(OE);
                        canvas.Children.Add(wrap);
                        wrap.RenderTransform = rotateTransformObj;
                    }
                }
            }
        }

        public void TickPaintGameField(Canvas canvas, IGameField currentField)
        {
            rot += rotSpeed*40f/1000f;
            rot = rot > 360 ? 0 : rot;
            PaintGameField(canvas, currentField);
        }
    }
}
