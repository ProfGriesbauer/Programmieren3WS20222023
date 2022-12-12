using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Ink;
using System.Windows.Media;
using System.Windows.Shapes;

namespace OOPGames
{
    public class B_Pong_Painter : IPaintPongGameB
    {
       
        
        public string Name { get { return "GruppeBPongPainter"; } }
        public void PaintGameField(Canvas canvas, IGameField currentField)
        {

            B_GameField_Pong gameField = (B_GameField_Pong)currentField;
            int paddle1X = gameField.paddle1.paddleX;
            int paddle2X = gameField.paddle2.paddleX; ;
            double ballX = gameField.ball.ballX;
            double ballY = gameField.ball.ballY;
            int ballR = gameField.ball.radius;
            int paddleLength = gameField.paddle1.lineWidth;
            int paddleHeight = gameField.paddle1.lineThickness;

            canvas.Children.Clear();
            Color bgColor = Color.FromRgb(0, 0, 0);
            canvas.Background = new SolidColorBrush(bgColor);
            Color ballColor = Color.FromRgb(255, 255, 255);
            Brush ballStroke = new SolidColorBrush(ballColor);
            Color paddleColor = Color.FromRgb(0, 0, 255);
            Brush paddleStroke = new SolidColorBrush(paddleColor);
            Color borderColor = Color.FromRgb(255, 255, 255);
            Brush borderStroke = new SolidColorBrush(borderColor);


            Line l1 = new Line() { X1 = 50, Y1 = 50, X2 = 350, Y2 = 50, Stroke = borderStroke, StrokeThickness = 4.0 };
            Line l2 = new Line() { X1 = 50, Y1 = 50, X2 = 50, Y2 = 550, Stroke = borderStroke, StrokeThickness = 4.0 };
            Line l3 = new Line() { X1 = 350, Y1 = 50, X2 = 350, Y2 = 550, Stroke = borderStroke, StrokeThickness = 4.0 };
            Line l4 = new Line() { X1 = 50, Y1 = 550, X2 = 350, Y2 = 550, Stroke = borderStroke, StrokeThickness = 4.0 };

            Ellipse ball = new Ellipse() { Margin = new Thickness(ballX - ballR, ballY- ballR,0,0), Width = ballR * 2, Height = ballR * 2, StrokeThickness = 3.0, Fill= ballStroke };

            Line paddle1 = new Line() { X1 = paddle1X, Y1 = 80, X2 = paddle1X + paddleLength, Y2 = 80, Stroke = paddleStroke, StrokeThickness = paddleHeight};
            Line paddle2 = new Line() { X1 = paddle2X, Y1 = 520, X2 = paddle2X + paddleLength, Y2 = 520, Stroke = paddleStroke, StrokeThickness = paddleHeight};

            canvas.Children.Add(ball);

            canvas.Children.Add(paddle1);   
            canvas.Children.Add(paddle2);

            canvas.Children.Add(l1);
            canvas.Children.Add(l2);
            canvas.Children.Add(l3);
            canvas.Children.Add(l4);
        }


        public void TickPaintGameField(Canvas canvas, IGameField currentField)
        {
            PaintGameField(canvas, currentField);
        }
    }
}
