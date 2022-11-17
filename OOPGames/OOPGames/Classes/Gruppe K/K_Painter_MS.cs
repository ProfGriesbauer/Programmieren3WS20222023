using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.TextFormatting;
using System.Windows.Shapes;

namespace OOPGames.Classes.Gruppe_K
{
    public abstract class RotatingField
    {
        protected float _rot = 0f;
        protected float _rotSpeed = 20f;
        protected float _xSpeed = 80f, _ySpeed = 80f;
        protected float _xPos = 0, _yPos = 0;
        protected int _xCenter = 0, _yCenter = 0;
        protected Canvas _canvas;

        private Task watchdog;
        private int watchdogTimeout = 0;

        private static int activeRotatingFieldIndex = -1;
        private static List<RotatingField> _objects = new List<RotatingField>();


        // Getter/Setter Call:
        // RotatingField.Rot;
        // Result:
        // Access to Rotation of current Painter
        public static float Rot
        {
            get
            {
                if (activeRotatingFieldIndex >= 0 && activeRotatingFieldIndex < _objects.Count)
                {
                    return _objects[activeRotatingFieldIndex]._rot;
                }
                return 0;
            }
            set
            {
                if (activeRotatingFieldIndex >= 0 && activeRotatingFieldIndex < _objects.Count)
                {
                    _objects[activeRotatingFieldIndex]._rot = value;
                }
            }
        }

        // Getter/Setter Call:
        // RotatingField.RotSpeed;
        // Result:
        // Access to Rotation Speed of current Painter
        public static float RotSpeed
        {
            get
            {
                if (activeRotatingFieldIndex >= 0 && activeRotatingFieldIndex < _objects.Count)
                {
                    return _objects[activeRotatingFieldIndex]._rotSpeed;
                }
                return 0;
            }
            set
            {
                if (activeRotatingFieldIndex >= 0 && activeRotatingFieldIndex < _objects.Count)
                {
                    _objects[activeRotatingFieldIndex]._rotSpeed = value;
                }
            }
        }

        // Getter/Setter Call:
        // RotatingField.xSpeed;
        // Result:
        // Access to x-Speed of current Painter
        public static float xSpeed
        {
            get
            {
                if (activeRotatingFieldIndex >= 0 && activeRotatingFieldIndex < _objects.Count)
                {
                    return _objects[activeRotatingFieldIndex]._xSpeed;
                }
                return 0;
            }
            set
            {
                if (activeRotatingFieldIndex >= 0 && activeRotatingFieldIndex < _objects.Count)
                {
                    _objects[activeRotatingFieldIndex]._xSpeed = value;
                }
            }
        }

        // Getter/Setter Call:
        // RotatingField.ySpeed;
        // Result:
        // Access to y-Speed of current Painter
        public static float ySpeed
        {
            get
            {
                if (activeRotatingFieldIndex >= 0 && activeRotatingFieldIndex < _objects.Count)
                {
                    return _objects[activeRotatingFieldIndex]._ySpeed;
                }
                return 0;
            }
            set
            {
                if (activeRotatingFieldIndex >= 0 && activeRotatingFieldIndex < _objects.Count)
                {
                    _objects[activeRotatingFieldIndex]._ySpeed = value;
                }
            }
        }

        // Getter/Setter Call:
        // RotatingField.xPos;
        // Result:
        // Access to x-Position of current Painter
        public static int xPos
        {
            get
            {
                if (activeRotatingFieldIndex >= 0 && activeRotatingFieldIndex < _objects.Count)
                {
                    return (int)_objects[activeRotatingFieldIndex]._xPos;
                }
                return 0;
            }
            set
            {
                if (activeRotatingFieldIndex >= 0 && activeRotatingFieldIndex < _objects.Count)
                {
                    _objects[activeRotatingFieldIndex]._xPos = value;
                }
            }
        }

        // Getter/Setter Call:
        // RotatingField.yPos;
        // Result:
        // Access to y-Position of current Painter
        public static int yPos
        {
            get
            {
                if (activeRotatingFieldIndex >= 0 && activeRotatingFieldIndex < _objects.Count)
                {
                    return (int)_objects[activeRotatingFieldIndex]._yPos;
                }
                return 0;
            }
            set
            {
                if (activeRotatingFieldIndex >= 0 && activeRotatingFieldIndex < _objects.Count)
                {
                    _objects[activeRotatingFieldIndex]._yPos = value;
                }
            }
        }

        // Call:
        //  RotatingField.GetPosition(selection);
        // Return:
        // Transformed Coordinates of current Painter
        public static IClickSelection GetPosition(IClickSelection selection)
        {
            if (activeRotatingFieldIndex >= 0 && activeRotatingFieldIndex < _objects.Count)
            {
                double angleInRadians = -_objects[activeRotatingFieldIndex]._rot * (Math.PI / 180);
                int tmpXCanvas = (int)_objects[activeRotatingFieldIndex]._xPos + _objects[activeRotatingFieldIndex]._xCenter;
                int tmpYCanvas = (int)_objects[activeRotatingFieldIndex]._yPos + _objects[activeRotatingFieldIndex]._yCenter;

                int tmpX = (int)(Math.Cos(angleInRadians) * (selection.XClickPos - tmpXCanvas) - Math.Sin(angleInRadians) * (selection.YClickPos - tmpYCanvas) + tmpXCanvas) - (int)_objects[activeRotatingFieldIndex]._xPos;
                int tmpY = (int)(Math.Sin(angleInRadians) * (selection.XClickPos - tmpXCanvas) + Math.Cos(angleInRadians) * (selection.YClickPos - tmpYCanvas) + tmpYCanvas) - (int)_objects[activeRotatingFieldIndex]._yPos;

                return new ClickSelection(tmpX, tmpY);
            }
            return selection;
        }


        protected static void updateRotatingField(RotatingField obj, Canvas canvas)
        {
            if (obj!=null) 
            {
                if (!_objects.Contains(obj))
                {
                    _objects.Add(obj);
                    obj._canvas = canvas;
                    activeRotatingFieldIndex = _objects.IndexOf(obj);

                    Action<object> action = (object tsk) =>
                    {
                        Console.WriteLine("Rotating Field: Added Object");
                        while (obj.watchdogTimeout<50)
                        {
                            Thread.Sleep(10);
                            obj.watchdogTimeout++;
                        }
                        
                        _objects.Remove(obj);
                        activeRotatingFieldIndex = -1;
                        Console.WriteLine("Rotating Field: Removed Object");
                    };
                    obj.watchdogTimeout = 0;
                    obj.watchdog = new Task(action,"watchdog");
                    obj.watchdog.Start();
                } else
                {
                    obj._canvas = canvas;
                    activeRotatingFieldIndex = _objects.IndexOf(obj);
                    obj.watchdogTimeout = 0;
                }
            }
        }
    }
    class K_Painter_Rotating : RotatingField, IPaintTicTacToe, IPaintGame2
    {

        RotateTransform rotateTransformObj = new RotateTransform();
        public string Name { get { return "K Painter Rotating"; } }




        public void PaintGameField(Canvas canvas, IGameField currentField)
        {
            updateRotatingField(this, canvas);
            if (currentField is ITicTacToeField)
            {
                PaintTicTacToeField(canvas, (ITicTacToeField)currentField);
            }
        }

        public void PaintTicTacToeField(Canvas canvas, ITicTacToeField currentField)
        {
            _xCenter = 170;
            _yCenter = 170;
         

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
            larr[0] = new Line() { X1 = 120+_xPos, Y1 = 20+_yPos, X2 = 120+_xPos, Y2 = 320+_yPos, Stroke = lineStroke, StrokeThickness = 3.0 };
            canvas.Children.Add(larr[0]);
            larr[1] = new Line() { X1 = 220+_xPos, Y1 = 20+_yPos, X2 = 220+_xPos, Y2 = 320+_yPos, Stroke = lineStroke, StrokeThickness = 3.0 };
            canvas.Children.Add(larr[1]);
            larr[2] = new Line() { X1 = 20+_xPos, Y1 = 120+_yPos, X2 = 320+_xPos, Y2 = 120+_yPos, Stroke = lineStroke, StrokeThickness = 3.0 };
            canvas.Children.Add(larr[2]);
            larr[3] = new Line() { X1 = 20+_xPos, Y1 = 220+_yPos, X2 = 320+_xPos, Y2 = 220+_yPos, Stroke = lineStroke, StrokeThickness = 3.0 };
            canvas.Children.Add(larr[3]);
            larr[4] = new Line() { X1 = 20+_xPos, Y1 = 320+_yPos, X2 = 320+_xPos, Y2 = 320+_yPos, Stroke = lineStroke, StrokeThickness = 3.0 };
            canvas.Children.Add(larr[4]);
            larr[5] = new Line() { X1 = 20+_xPos, Y1 = 20+_yPos, X2 = 320+_xPos, Y2 = 20+_yPos, Stroke = lineStroke, StrokeThickness = 3.0 };
            canvas.Children.Add(larr[5]);
            larr[6] = new Line() { X1 = 20+_xPos, Y1 = 320+_yPos, X2 = 20+_xPos, Y2 = 20+_yPos, Stroke = lineStroke, StrokeThickness = 3.0 };
            canvas.Children.Add(larr[6]);
            larr[7] = new Line() { X1 = 320+_xPos, Y1 = 320+_yPos, X2 = 320+_xPos, Y2 = 20+_yPos, Stroke = lineStroke, StrokeThickness = 3.0 };
            canvas.Children.Add(larr[7]);
            rotateTransformObj.Angle = _rot;
            rotateTransformObj.CenterX =_xCenter+ _xPos;
            rotateTransformObj.CenterY =_yCenter+ _yPos;

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
                        Line X1 = new Line() { X1 = 20 + (j * 100)+_xPos, Y1 = 20 + (i * 100)+_yPos, X2 = 120 + (j * 100)+_xPos, Y2 = 120 + (i * 100)+_yPos, Stroke = XStroke, StrokeThickness = 3.0 };
                        canvas.Children.Add(X1);
                        Line X2 = new Line() { X1 = 20 + (j * 100)+_xPos, Y1 = 120 + (i * 100)+_yPos, X2 = 120 + (j * 100)+_xPos, Y2 = 20 + (i * 100)+_yPos, Stroke = XStroke, StrokeThickness = 3.0 };
                        canvas.Children.Add(X2);
                        X1.RenderTransform = rotateTransformObj;
                        X2.RenderTransform = rotateTransformObj;
                    }
                    else if (currentField[i, j] == 2)
                    {
                        Ellipse OE = new Ellipse() { Margin = new Thickness(20 + (j * 100)+_xPos, 20 + (i * 100)+_yPos, 0, 0), Width = 100, Height = 100, Stroke = OStroke, StrokeThickness = 3.0 };
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
            float dT = 40f / 1000f;
            _rot += _rotSpeed*dT;
            _rot = _rotSpeed > 360 ? 0 : _rot;
            
            _xPos += (_xSpeed * dT);
            if ((_xPos + _xCenter / 2) > 450 || (_xPos + _xCenter / 2)<50)
            {
                _xSpeed = -_xSpeed;
                _rotSpeed *= -1;
            }

            _yPos += (_ySpeed * dT);
            if ((_yPos + _yCenter / 2) > 600 || (_yPos + _yCenter / 2) < 50)
            {
                _ySpeed = -_ySpeed;
                _rotSpeed *= -1;
            }

            PaintGameField(canvas, currentField);
        }
    }
}
