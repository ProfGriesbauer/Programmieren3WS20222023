using OOPGames.Interfaces.Gruppe_K;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Shapes;
using Color = System.Windows.Media.Color;
using Image = System.Windows.Controls.Image;

namespace OOPGames.Classes.Gruppe_K
{
    internal class K_PaintGameObject : IK_PaintGameObject
    {
        public string Name { get { return "K Painter tbd"; } }



        public void PaintGameField(Canvas canvas, List<K_GameObject> data)
        {
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
                    else
                    {
                        drawImage(canvas, (K_DrawObject)obj);
                    }
                }
            }
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
            // TODO Finish Canon implementation
            drawImage(canvas, obj);
            
        }

        private void PaintK_Projectile(Canvas canvas, K_Projectile obj)
        {
            // TODO Implement PaintK_Projectile
        }

        private void PaintK_Target(Canvas canvas, K_Target obj)
        {
            // TODO Implement PaintK_Target
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
            if (currentField is K_GameObjectManager)
            {
                PaintGameField(canvas, ((K_GameObjectManager)currentField).Objects);
            }
        }



        private void drawImage(Canvas canvas, K_DrawObject obj)
        {
            ImageBrush img=new ImageBrush();
            img.ImageSource = obj.Image;
            Label container = new Label();
            RenderOptions.SetBitmapScalingMode(container, BitmapScalingMode.NearestNeighbor);
            container.Width = obj.Image.PixelWidth * obj.Scale;
            container.Height = obj.Image.PixelHeight * obj.Scale;
            container.Background = img;
            RotateTransform rot=new RotateTransform();
            rot.Angle = obj.Rotation;
            rot.CenterX = obj.xCenter;
            rot.CenterY = obj.yCenter;
            container.RenderTransform = rot;

            canvas.Children.Add(container);

            Canvas.SetZIndex(container, obj.drawIndex);
            Canvas.SetTop(container, obj.yPos);
            Canvas.SetLeft(container, obj.xPos);
        }
        private void drawText(double x, double y, string text, int size, Color colorText, Color colorBackground, Canvas canvas)
        {
            TextBlock textBlock = new TextBlock();
            textBlock.Text = text;
            textBlock.Foreground = new SolidColorBrush(colorText);
            textBlock.Background = new SolidColorBrush(colorBackground);
            textBlock.FontSize = size;
            Canvas.SetLeft(textBlock, x);
            Canvas.SetTop(textBlock, y);
            canvas.Children.Add(textBlock);
        }


    }
}
