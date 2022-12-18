using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows;
using System.Windows.Media.Animation;


namespace OOPGames.Classes.Gruppe_F.Space_Race
{
    public class SpaceRacePainterF : ISpaceRacePainterF
    {
        public string Name { get {return "SpaceRacePainterF";} }

        Brush MeteorStroke = new SolidColorBrush(Color.FromRgb(160, 160, 160)); 
        Brush ShieldStroke = new SolidColorBrush(Color.FromRgb(0, 255, 255));


        public void PaintGameField(Canvas canvas, IGameField currentField) //unbenutzt
        {
            Color bgColor = Color.FromRgb(0, 0, 0);
            canvas.Background = new SolidColorBrush(bgColor);
        }

        public void TickPaintGameField(Canvas canvas, IGameField currentField)
        {
            Color bgColor = Color.FromRgb(0, 0, 0);
            canvas.Background = new SolidColorBrush(bgColor);
        }

        public void paintMeteor(Canvas canvas, int xPos, int yPos, int rad)
        {
            Ellipse Meteor = new Ellipse() { Margin = new Thickness(xPos, yPos, 0, 0), Width = rad*2, Height = rad*2, Stroke = MeteorStroke, StrokeThickness = 20.0 };
            canvas.Children.Add(Meteor);
        }

        public void clearCanvas(Canvas canvas)
        {
            canvas.Children.Clear();
        }

        public void paintTimeBar(Canvas canvas, float gametimer, float barheight)
        {
            int maxlength = 940;
            Color lineColor;
            float barlength = maxlength*gametimer/30000;

            if (barlength >= maxlength*2/3)
            {
                lineColor = Color.FromRgb(0, 204, 0);
            }
            else if (barlength < maxlength*2/3 && barlength >= maxlength*1/3)
            {
                lineColor = Color.FromRgb(255, 255, 0);
            }
            else
            {
                lineColor = Color.FromRgb(255, 0, 0);
            }
            Brush lineStroke = new SolidColorBrush(lineColor);
            Line TimeBar = new Line() { X1 = 0, Y1 = 920, X2 = barlength, Y2 = 920, Stroke = lineStroke, StrokeThickness = barheight };
            canvas.Children.Add(TimeBar);
        }

        public void paintShip(Canvas canvas, int xPos, int yPos, int width, int height, bool hasShield)
        {
            if (hasShield)
            {
                Ellipse Meteor = new Ellipse() { Margin = new Thickness(xPos-30, yPos-10, 0, 0), Width = 60, Height = 60, Stroke = ShieldStroke, StrokeThickness = 3.0 };
                canvas.Children.Add(Meteor);
            }

            Color ShipColor = Color.FromRgb(255, 255, 255);
            Brush lineStroke = new SolidColorBrush(ShipColor);
            Line Ship = new Line() { X1 = xPos, Y1 = yPos, X2 = xPos, Y2 = yPos+height, Stroke = lineStroke, StrokeThickness = width };
            canvas.Children.Add(Ship);

        }

        public void paintShield(Canvas canvas, int xPos, int yPos, int rad)
        {
            Ellipse Shield = new Ellipse() { Margin = new Thickness(xPos, yPos, 0, 0), Width = rad * 2, Height = rad * 2, Stroke = ShieldStroke, StrokeThickness = 3.0 };
            canvas.Children.Add(Shield);
        }
    }
}
