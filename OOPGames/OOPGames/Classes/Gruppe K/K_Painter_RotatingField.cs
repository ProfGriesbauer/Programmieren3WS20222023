using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;


namespace OOPGames.Classes.Gruppe_K
{
    public abstract class RotatingField
    {

        protected float _rot = 0f;
        protected float _rotSpeed = 40f;
        
        protected float _xSpeed = 100f, _ySpeed = 150f;
        protected float _xPos = 0, _yPos = 0;
        
        protected float _scale = 1f;
        protected float _scaleMin=0.3f;
        protected float _scaleMax = 1.2f;
        protected float _scaleSpeed = 0.25f;


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

        // Getter/Setter Call:
        // RotatingField.Scale;
        // Result:
        // Access to Scale of current Painter
        public static float Scale
        {
            get
            {
                if (activeRotatingFieldIndex >= 0 && activeRotatingFieldIndex < _objects.Count)
                {
                    return (int)_objects[activeRotatingFieldIndex]._scale;
                }
                return 0;
            }
            set
            {
                if (activeRotatingFieldIndex >= 0 && activeRotatingFieldIndex < _objects.Count)
                {
                    _objects[activeRotatingFieldIndex]._scale = value;
                }
            }
        }

        // Getter/Setter Call:
        // RotatingField.ScaleMin;
        // Result:
        // Access to Scale Minimum of current Painter
        public static float ScaleMin
        {
            get
            {
                if (activeRotatingFieldIndex >= 0 && activeRotatingFieldIndex < _objects.Count)
                {
                    return (int)_objects[activeRotatingFieldIndex]._scaleMin;
                }
                return 0;
            }
            set
            {
                if (activeRotatingFieldIndex >= 0 && activeRotatingFieldIndex < _objects.Count)
                {
                    _objects[activeRotatingFieldIndex]._scaleMin = value;
                }
            }
        }

        // Getter/Setter Call:
        // RotatingField.ScaleMax;
        // Result:
        // Access to Scale Maximum of current Painter
        public static float ScaleMax
        {
            get
            {
                if (activeRotatingFieldIndex >= 0 && activeRotatingFieldIndex < _objects.Count)
                {
                    return (int)_objects[activeRotatingFieldIndex]._scaleMax;
                }
                return 0;
            }
            set
            {
                if (activeRotatingFieldIndex >= 0 && activeRotatingFieldIndex < _objects.Count)
                {
                    _objects[activeRotatingFieldIndex]._scaleMax = value;
                }
            }
        }

        // Getter/Setter Call:
        // RotatingField.ScaleSpeed;
        // Result:
        // Access to Scale Speed of current Painter
        public static float ScaleSpeed
        {
            get
            {
                if (activeRotatingFieldIndex >= 0 && activeRotatingFieldIndex < _objects.Count)
                {
                    return (int)_objects[activeRotatingFieldIndex]._scaleSpeed;
                }
                return 0;
            }
            set
            {
                if (activeRotatingFieldIndex >= 0 && activeRotatingFieldIndex < _objects.Count)
                {
                    _objects[activeRotatingFieldIndex]._scaleSpeed = value;
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
                tmpX =(int)(tmpX/ _objects[activeRotatingFieldIndex]._scale);
                tmpY = (int)(tmpY / _objects[activeRotatingFieldIndex]._scale);
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
                        while (obj.watchdogTimeout<20)
                        {
                            Thread.Sleep(100);
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

        float dT=0f;
        DateTime lastTime = DateTime.Now;
        float colorStep = 0f;
        float colorDir = 1;
        
        RenderTargetBitmap[] rtb;
        int rtbCnt = 0;
        const int rtbMaxSize = 150;
        float rtbOpacity = 0.1f;

        RotateTransform rotateTransformObj = new RotateTransform();

        Color bgColor;
        Color lineColor;
        Brush lineStroke;
        Color XColor;
        Brush XStroke;
        Color OColor;
        Brush OStroke;
        Line[] larrField;
        Line[] larrX;
        Canvas[] larrWrap;
        Ellipse[] larrEllipse;


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
           

            initVariables(canvas);

            canvas.Children.Clear();

            drawBackground(canvas);

            rotateTransformObj.Angle = _rot;
            rotateTransformObj.CenterX = _xCenter + _xPos;
            rotateTransformObj.CenterY = _yCenter + _yPos;

            setLinePosition();
            for (int i = 0; i < larrField.Length; i++)
            {
                canvas.Children.Add(larrField[i]);
                larrField[i].RenderTransform = rotateTransformObj;
            }


            int iX = 0;
            int iE = 0;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (currentField[i, j] == 1)
                    {
                        larrX[iX].X1 = (j * 100 * _scale) + _xPos;
                        larrX[iX].Y1 = (i * 100 * _scale) + _yPos;
                        larrX[iX].X2 = 100 * _scale + (j * 100 * _scale) + _xPos;
                        larrX[iX].Y2 = 100 * _scale + (i * 100 * _scale) + _yPos;
                        larrX[iX].Stroke = XStroke;
                        larrX[iX].StrokeThickness = 3.0;
                        canvas.Children.Add(larrX[iX]);
                        larrX[iX].RenderTransform = rotateTransformObj;
                        iX++;
                        
                        larrX[iX].X1 = (j * 100 * _scale) + _xPos;
                        larrX[iX].Y1 = 100 * _scale + (i * 100 * _scale) + _yPos;
                        larrX[iX].X2 = 100 * _scale + (j * 100 * _scale) + _xPos;
                        larrX[iX].Y2 = (i * 100 * _scale) + _yPos;
                        larrX[iX].Stroke = XStroke;
                        larrX[iX].StrokeThickness = 3.0;
                        canvas.Children.Add(larrX[iX]);
                        larrX[iX].RenderTransform = rotateTransformObj;
                        iX++;
                    }
                    else if (currentField[i, j] == 2)
                    {
                        larrEllipse[iE].Margin = new Thickness((j * 100 * _scale) + _xPos,(i * 100 * _scale) + _yPos, 0, 0);
                        larrEllipse[iE].Width = 100 * _scale;
                        larrEllipse[iE].Height = 100 * _scale;
                        larrEllipse[iE].Stroke = OStroke;
                        larrEllipse[iE].StrokeThickness = 3.0;

                        if (!larrWrap[iE].Children.Contains(larrEllipse[iE]))
                        {
                            larrWrap[iE].Children.Add(larrEllipse[iE]);
                        }
                        canvas.Children.Add(larrWrap[iE]);
                        larrWrap[iE].RenderTransform = rotateTransformObj;
                        iE++;
                    }
                }
            }
        }

        public void TickPaintGameField(Canvas canvas, IGameField currentField)
        {
            if (dT > 0)
            {
                dT = (float)(System.DateTime.Now.Subtract(lastTime).TotalMilliseconds / 1000f);
            } else
            {
                dT = 40f / 1000f;
            }
            lastTime = System.DateTime.Now;


            updatePhysic(canvas);
            updateColor();
            PaintGameField(canvas, currentField);

            updateScreenshot(canvas);
            Text(canvas.ActualWidth-100, 10, "FPS: " + (int)(1 / dT), 20, lineColor, canvas);
        }


        private void initVariables(Canvas canvas)
        {
            if (larrField==null)
            {
                bgColor = Color.FromRgb(0, 0, 0);
                lineColor = Color.FromRgb(255, 255, 255);
                lineStroke = new SolidColorBrush(lineColor);
                XColor = Color.FromRgb(255, 255, 255);
                XStroke = new SolidColorBrush(XColor);
                OColor = Color.FromRgb(255, 255, 255);
                OStroke = new SolidColorBrush(OColor);
                
                larrField = new Line[8];
                for(int i = 0; i < 8; i++)
                {
                    larrField[i] = new Line();
                }
                
              
                larrX = new Line[10];
                for(int i = 0; i < 10; i++) 
                { 
                    larrX[i] = new Line(); 
                }

                larrWrap=new Canvas[5];
                for(int i = 0; i < 5; i++)
                {
                    larrWrap[i] = new Canvas();
                }

                larrEllipse=new Ellipse[5];
                for(int i=0; i < 5; i++) 
                { 
                    larrEllipse[i] = new Ellipse();
                }

                rtb = new RenderTargetBitmap[rtbMaxSize];
              

            }
        }

        private void drawBackground(Canvas canvas)
        {
            Label labelC = new Label();
            labelC.Width = canvas.ActualWidth;
            labelC.Height = canvas.ActualHeight;
            labelC.Background = new SolidColorBrush(bgColor);
            canvas.Children.Add(labelC);
            for (int i = rtbCnt; i < rtb.Length+rtbCnt; i++)
            {
                int tmpi = i % rtb.Length;
                if (rtb[tmpi] != null)
                {
                    ImageBrush image = new ImageBrush(rtb[tmpi]);
                    image.Opacity = rtbOpacity * (((i - rtbCnt) % rtb.Length) / (float)rtb.Length);

                    Label label = new Label();
                    label.Width = canvas.ActualWidth;
                    label.Height = canvas.ActualHeight;
                    label.Background = image;
                    canvas.Children.Add(label);
                }
            }
        }
        private void setLinePosition()
        {
            _xCenter = (int)(150*_scale);
            _yCenter = (int)(150*_scale);

            lineStroke = new SolidColorBrush(lineColor);
            XStroke = new SolidColorBrush(XColor);
            OStroke = new SolidColorBrush(OColor);

            for (int i = 0; i < 4; i++)
            {
                larrField[i].X1 = _xPos;
                larrField[i].Y1 = _yPos+i*100*_scale;
                larrField[i].X2 = 300*_scale + _xPos;
                larrField[i].Y2 = _yPos+i*100*_scale;
                larrField[i].Stroke = lineStroke;
                larrField[i].StrokeThickness = 3.0;
            }
           
            for (int i = 4; i < 8; i++)
            {
                larrField[i].X1 = _xPos + (i-4) * 100*_scale;
                larrField[i].Y1 = _yPos;
                larrField[i].X2 = _xPos + (i-4) * 100*_scale;
                larrField[i].Y2 = 300*_scale + _yPos;
                larrField[i].Stroke = lineStroke;
                larrField[i].StrokeThickness = 3.0;
            }
          
        }

        private void updatePhysic(Canvas canvas)
        {
            _rot += _rotSpeed * dT;
            _rot = _rotSpeed > 360 ? 0 : _rot;

            _xPos += _xSpeed * dT;

            float width = _xCenter * 2;//(float)(Math.Abs(300 * _scale * Math.Cos(_rot * (Math.PI / 180))) + Math.Abs(300 * _scale * Math.Sin(_rot * (Math.PI / 180))));

            if (((_xPos + width) > canvas.ActualWidth && _xSpeed > 0) || ((_xPos) < 20 && _xSpeed < 0))
            {
                _xSpeed = -_xSpeed;
                _rotSpeed *= -1;
            }

            _yPos += _ySpeed * dT;
            if (((_yPos + width) > canvas.ActualHeight && _ySpeed > 0) || ((_yPos) < 20 && _ySpeed < 0))
            {
                _ySpeed = -_ySpeed;
                _rotSpeed *= -1;
            }

            _scale += _scaleSpeed * dT;
            if ((_scale < _scaleMin && _scaleSpeed < 0) || (_scale > _scaleMax && _scaleSpeed > 0))
            {
                _scaleSpeed = -_scaleSpeed;
            }
        }

        private void updateColor()
        {
            colorStep += dT * 10 * colorDir;
            if ((colorStep >= 20 && colorDir > 0) || (colorStep <= 0 && colorDir < 0))
            {
                colorDir = -colorDir;
            }
            colorStep = colorStep < 0 ? 0 : colorStep;

            bgColor.R = (byte)(colorStep);
            bgColor.G = (byte)(colorStep);
            bgColor.B = (byte)(colorStep);

            lineColor.R = (byte)(255 - bgColor.R);
            lineColor.G = (byte)(255 - bgColor.G);
            lineColor.B = (byte)(255 - bgColor.B);

            XColor.R = (byte)(255 - bgColor.B);
            XColor.G = (byte)(255 - bgColor.B);
            XColor.B = (byte)(255 - bgColor.B);

            OColor.R = (byte)(255 - bgColor.B);
            OColor.G = (byte)(255 - bgColor.B);
            OColor.B = (byte)(255 - bgColor.B);
        }

        void updateScreenshot(Canvas canvas)
        {
            if (rtbMaxSize > 0)
            {
                rtb[rtbCnt] = new RenderTargetBitmap((int)canvas.ActualWidth, (int)canvas.ActualHeight, 96d, 96d, PixelFormats.Default);
                rtb[rtbCnt].Render(canvas);
                rtbCnt++;
                rtbCnt %= rtb.Length;
            }
        }

    private void Text(double x, double y, string text, int size, Color colorText, Canvas canvas)
        {
            TextBlock textBlock = new TextBlock();
            textBlock.Text = text;
            textBlock.Foreground = new SolidColorBrush(colorText);
            textBlock.FontSize = size;
            Canvas.SetLeft(textBlock, x);
            Canvas.SetTop(textBlock, y);
            canvas.Children.Add(textBlock);
        }


    }
}
