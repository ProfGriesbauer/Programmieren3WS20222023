using OOPGames.Interfaces.Gruppe_K;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Common;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Shapes;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;
using Color = System.Windows.Media.Color;
using Image = System.Windows.Controls.Image;

namespace OOPGames.Classes.Gruppe_K
{
    class K_PaintGameObject : IK_PaintGameObject
    {
        K_Text fps = new K_Text();
        float dT = 0f;
        DateTime lastTime = DateTime.Now;
        public string Name { get { return "K Panzer Painter"; } }



        public void PaintGameField(Canvas canvas, List<K_GameObject> data)
        {
            if (dT > 0)
            {
                dT = (float)(System.DateTime.Now.Subtract(lastTime).TotalMilliseconds / 1000f);
            }
            else
            {
                dT = 40f / 1000f;
            }
            lastTime = System.DateTime.Now;


            canvas.Children.Clear();
            foreach (K_GameObject obj in data) {
                if (obj is K_GameField)
                {
                    PaintK_GameField(canvas, (K_GameField)obj);
                }
                else if(obj is K_DrawObject)
                {
                    if(obj is K_Player)
                    {
                        PaintK_Player(canvas, (K_Player)obj);
                    }
                    else if (obj is K_Projectile)
                    {
                        PaintK_Projectile(canvas, (K_Projectile)obj);
                    }
                    else if (obj is K_Target)
                    {
                        PaintK_Target(canvas, (K_Target)obj);
                    }
                    else if (obj is K_Text)
                    {
                        drawText((K_Text)obj, canvas);
                    }
                    else if (obj is K_Progressbar)
                    {
                        drawProgressbar(((K_Progressbar)obj), canvas);
                    }
                    else
                    {
                        drawImage(canvas, (K_DrawObject)obj);
                    }
                }
            }


            fps.xPos = (int)(canvas.ActualWidth - 100);
            fps.yPos = 10;
            fps.Text= "FPS: " + (int)(1 / dT);
            fps.FontSize = 20;
            fps.TextColor = Colors.Black;
            fps.BackgroundColor = Colors.White;

            drawText(fps, canvas);
        }


        private void PaintK_GameField(Canvas canvas, K_GameField obj)
        {
            WriteableBitmap bitmap = new WriteableBitmap(obj.Width, obj.Height, 96, 96, PixelFormats.Indexed8, obj.Palette);
            bitmap.WritePixels(new Int32Rect(0, 0, bitmap.PixelWidth, bitmap.PixelHeight), obj.getField(), bitmap.PixelWidth,0);
            Image img = new Image();
            img.Source = bitmap;
            canvas.Children.Add(img);
            Canvas.SetZIndex(img, obj.drawIndex);
        }

        private void PaintK_Player(Canvas canvas, K_Player obj)
        {
            drawImageAll(canvas, obj);
        }

        private void PaintK_Projectile(Canvas canvas, K_Projectile obj)
        {
            drawImageAll(canvas, obj);
        }

        private void PaintK_Target(Canvas canvas, K_Target obj)
        {
            drawImageAll(canvas, obj);
        }

        public void PaintGameField(Canvas canvas, IGameField currentField)
        {
           if(currentField is K_GameObjectManager)
            {
                PaintGameField(canvas, ((K_GameObjectManager)currentField).Objects);
            }
        }

        public void TickPaintGameField(Canvas canvas, IGameField currentField)
        {
            if (currentField is IK_GameField)
            {
                PaintGameField(canvas, ((K_GameObjectManager)currentField).Objects);
            } 
        }


        private void drawImage(Canvas canvas, K_DrawObject obj)
        {
            Canvas container = new Canvas();
            RotateTransform rot = new RotateTransform();
            rot.Angle = obj.Rotation;
            rot.CenterX = obj.xCenter;
            rot.CenterY = obj.yCenter;
            container.RenderTransform = rot;

            canvas.Children.Add(container);

            Canvas.SetZIndex(container, obj.drawIndex);
            Canvas.SetTop(container, obj.yPos);
            Canvas.SetLeft(container, obj.xPos);
            drawImage(container, obj, 0);
        }
        private void drawImage(Canvas canvas, K_DrawObject obj, int imageIndex)
        {
            drawImage(canvas, obj, imageIndex,obj.Image[imageIndex].Item2.xPos, obj.Image[imageIndex].Item2.yPos, obj.Image[imageIndex].Item2.xCenter, obj.Image[imageIndex].Item2.yCenter, obj.Image[imageIndex].Item2.Rotation, obj.Image[imageIndex].Item2.Scale, obj.Image[imageIndex].Item2.DrawIndex);
        }
        private void drawImageAll(Canvas canvas, K_DrawObject obj)
        {
            Canvas container=new Canvas();
            RotateTransform rot = new RotateTransform();
            rot.Angle = obj.Rotation;
            rot.CenterX = obj.xCenter;
            rot.CenterY = obj.yCenter;
            container.RenderTransform = rot;

            canvas.Children.Add(container);

            Canvas.SetZIndex(container, obj.drawIndex);
            Canvas.SetTop(container, obj.yPos);
            Canvas.SetLeft(container, obj.xPos);
            for (int i=0; i < obj.Image.Count; i++)
            {
                drawImage(container, obj, i);
            }
        }

        private void drawImage(Canvas canvas, K_DrawObject obj, int imageIndex, int xPos, int yPos, int xCenter, int yCenter, float rotation, float scale, int drawIndex)
        {
            try
            {
                if (imageIndex >= 0 && obj.Image.Count > imageIndex)
                {
                    ImageBrush img = new ImageBrush();
                    img.ImageSource = obj.Image[imageIndex].Item1;
                    Label container = new Label();
                    RenderOptions.SetBitmapScalingMode(container, BitmapScalingMode.NearestNeighbor);
                    container.Width = obj.Image[imageIndex].Item1.PixelWidth * scale;
                    container.Height = obj.Image[imageIndex].Item1.PixelHeight * scale;
                    container.Background = img;
                    RotateTransform rot = new RotateTransform();
                    rot.Angle = rotation;
                    rot.CenterX = xCenter;
                    rot.CenterY = yCenter;
                    container.RenderTransform = rot;

                    canvas.Children.Add(container);

                    Canvas.SetZIndex(container, drawIndex);
                    Canvas.SetTop(container, yPos);
                    Canvas.SetLeft(container, xPos);
                }
            } catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void drawText(K_Text obj, Canvas canvas)
        {
            Canvas container = new Canvas();
            RotateTransform rot = new RotateTransform();
            rot.Angle = obj.Rotation;
            rot.CenterX = obj.xCenter;
            rot.CenterY = obj.yCenter;
            container.RenderTransform = rot;

            TextBlock textBlock = new TextBlock();
            textBlock.Text = obj.Text;
            textBlock.Foreground = new SolidColorBrush(obj.TextColor);
            textBlock.Background = new SolidColorBrush(obj.BackgroundColor);
            textBlock.FontSize = obj.FontSize*obj.Scale;
            container.Children.Add(textBlock);

            Canvas.SetZIndex(container, obj.drawIndex);
            Canvas.SetLeft(container, obj.xPos);
            Canvas.SetTop(container, obj.yPos);
            canvas.Children.Add(container);
        }

        private void drawProgressbar(K_Progressbar obj, Canvas canvas)
        {
            Canvas container = new Canvas();
            RotateTransform rot = new RotateTransform();
            rot.Angle = obj.Rotation;
            rot.CenterX = obj.xCenter;
            rot.CenterY = obj.yCenter;
            container.RenderTransform = rot;

            //draw outer line and fill with innerColor1
            System.Windows.Shapes.Rectangle rect1;
            rect1 = new System.Windows.Shapes.Rectangle();
            rect1.StrokeThickness = obj.StrokeThickness;
            rect1.Stroke = new SolidColorBrush(obj.OuterColor);
            rect1.Fill = new SolidColorBrush(obj.InnerColor1);
            rect1.Width = obj.Width*obj.Scale;
            rect1.Height = obj.Height*obj.Scale;
            Canvas.SetZIndex(rect1, 0);
            container.Children.Add(rect1);

            //draw inner rectangle with innerColor2 and 
            System.Windows.Shapes.Rectangle rect2;
            rect2 = new System.Windows.Shapes.Rectangle();
            rect2.Fill = new SolidColorBrush(obj.InnerColor2);
            double width = (obj.Width * (obj.Progress > 1 ? 1 : obj.Progress)) - 2 * obj.StrokeThickness;
            rect2.Width = width >=0 ? width : 0*obj.Scale;
            rect2.Height = obj.Height - (2 * obj.StrokeThickness)*obj.Scale;
            Canvas.SetZIndex(rect2, 1);
            Canvas.SetLeft(rect2, obj.StrokeThickness*obj.Scale);
            Canvas.SetTop(rect2, obj.StrokeThickness*obj.Scale);
            container.Children.Add(rect2);


            Canvas.SetZIndex(container, obj.drawIndex);
            Canvas.SetLeft(container, obj.xPos);
            Canvas.SetTop(container, obj.yPos);
            canvas.Children.Add(container);


        }


    }
}
