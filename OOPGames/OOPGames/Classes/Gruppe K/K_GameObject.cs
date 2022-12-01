using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using static OOPGames.Classes.Gruppe_K.K_DrawObject;

namespace OOPGames.Classes.Gruppe_K
{
    class K_GameObjectManager : IGameField
    {
        List<K_GameObject> _objects;

        public List<K_GameObject> Objects
        {
            get { return _objects; }
            set { _objects = value; }
        }
        public bool CanBePaintedBy(IPaintGame painter)
        {
            if (painter is K_PaintGameObject)
            {
                return true;
            }
            return false;
        }
    }

    interface K_GameObject
    {
    }

    class K_Status:K_GameObject
    {
        double _GameTime;
        int _Score;
        int _TurnCounter;
        K_GameObject _ActivePlayer;
    }

    class K_GameField : K_GameObject
    {
        const int _width = 800;
        const int _height = 400;
        byte[] _field = new byte[_width * _height];
        BitmapPalette _palette = BitmapPalettes.Halftone256Transparent;
        int _drawIndex = 0;

        public byte[] getField()
        {
            return _field;
        }
        public byte getField(int x, int y)
        {
            return _field[x + y * _width];
        }
        public void setField(int x, int y, byte value)
        {
            if (x < _width && x>=0 && y < _height && y>=0)
            {
                _field[x + y * _width] = value;
            }
        }
        public int Width
        {
            get { return _width; }
        }
        public int Height
        {
            get { return _height; }
        }
        public BitmapPalette Palette
        {
            get { return _palette; }
            set { _palette = value; }

        }
        public int drawIndex
        {
            get { return _drawIndex; }
            set { _drawIndex = value; }
        }

        public void removeHoles()
        {
            for(int y=0; y < _height; y++)
            {
                for(int x=0; x< _width; x++)
                {
                    if(getField(x,y)==0 &&y>0)
                    {
                        if (getField(x, y - 1) != 0)
                        {
                            setField(x,y,getField(x,y-1));
                            setField(x,y-1,0);
                        }
                    }
                }
            }
        }
    }
    abstract class K_DrawObject: K_GameObject
    {
        DrawSetting _drawSetting = new DrawSetting(10, 0, 0, 0, 0, 0, 1);
        float _xSpeed = 0;
        float _ySpeed = 0;
      

        List<Tuple<BitmapImage,DrawSetting>> _image = new List<Tuple<BitmapImage, DrawSetting>>();

        public class DrawSetting
        {
            private String _ID = "";
            private int _drawIndex=0;
            private int _xPos=0;
            private int _yPos=0;
            private float _rotation=0;
            private int _xCenter=0;
            private int _yCenter=0;
            private float _scale=1f;
            private BitmapImage _image;
            private Position _position=new Position();

            public String ID { get { return _ID; } set { _ID = value; } }
            public int DrawIndex { get { return _drawIndex; } set { _drawIndex = value; } }
            public int xPos { get { return _xPos; } set { _xPos = value;} }
            public int yPos { get { return _yPos; } set { _yPos = value;} }
            public float Rotation { get { return _rotation; } set { _rotation = value; } }
            public int xCenter { get { return _xCenter; } set { _xCenter = value; } }
            public int yCenter { get { return _yCenter; } set { _xCenter = value; } }
            public float Scale { get { return _scale; } set { _scale = value; } }
            public BitmapImage Image { get { return _image; } set { _image = value; } }

            public Position Position { get { return _position; } set { _position = value; } }

            public DrawSetting()
            {
                this.DrawIndex = 10;
                this.xPos = 0;
                this.yPos = 0;
                this.Rotation = 0f;
                this.xCenter = 0;
                this.yCenter = 0;
                this.Scale = 1;
            }
            public DrawSetting(int DrawIndex, int xPos, int yPos, float Rotation, int xCenter, int yCenter, float Scale)
            {
                this.DrawIndex=DrawIndex;
                this.xPos = xPos;
                this.yPos = yPos;
                this.Rotation =Rotation;
                this.xCenter = xCenter;
                this.yCenter = yCenter;
                this.Scale = Scale;
            }
            public DrawSetting(DrawSetting setting)
            {
                this.DrawIndex = setting.DrawIndex;
                this.xPos = setting.xPos;
                this.yPos = setting.yPos;
                this.Rotation = setting.Rotation;
                this.xCenter = setting.xCenter;
                this.yCenter = setting.yCenter;
                this.Scale = setting.Scale;
            }
            public void updatePosition()
            {
                updatePosition(_position);
            }
            public void updatePosition( Position pos)
            {
                if(Image==null) return;

                _position = pos;

                switch (pos)
                {
                    case Position.LeftCenter:
                        _xCenter = 0;
                        _yCenter = (int)(_scale * (_image.PixelHeight / 2));
                        break;
                    case Position.LeftTop:
                        _xCenter = 0;
                        _yCenter = 0;
                        break;
                    case Position.LeftBottom:
                        _xCenter = 0;
                        _yCenter = (int)(_scale * _image.PixelHeight);
                        break;
                    case Position.Center:
                        _xCenter = (int)(_scale * (_image.PixelWidth / 2));
                        _yCenter = (int)(_scale * (_image.PixelHeight / 2));
                        break;
                    case Position.CenterTop:
                        _xCenter = (int)(_scale * (_image.PixelWidth / 2));
                        _yCenter = 0;
                        break;
                    case Position.CenterBottom:
                        _xCenter = (int)(_scale * (_image.PixelWidth / 2));
                        _yCenter = (int)(_scale * (_image.PixelHeight)); ;
                        break;
                    case Position.RightCenter:
                        _xCenter = (int)(_scale * _image.PixelWidth);
                        _yCenter = (int)(_scale * (_image.PixelHeight / 2));
                        break;
                    case Position.RightTop:
                        _xCenter = (int)(_scale * _image.PixelWidth);
                        _yCenter = 0;
                        break;
                    case Position.RightBottom:
                        _xCenter = (int)(_scale * _image.PixelWidth); ;
                        _yCenter = (int)(_scale * _image.PixelHeight);
                        break;

                }
                _xPos -= (_xCenter);
                _yPos -= (_yCenter);
            }

        }
        public enum Position
        {
            LeftCenter,LeftTop,LeftBottom, RightCenter, RightTop,RightBottom, Center, CenterTop,CenterBottom
        }


        public DrawSetting loadImage(String uri)
        {
            DrawSetting setting = new DrawSetting(_drawSetting);
            setting.xPos = 0;
            setting.yPos = 0;
            setting.Rotation = 0;
            return loadImage(uri, setting);
        }

        public DrawSetting loadImage(String uri, Position pos)
        {
            DrawSetting setting = new DrawSetting(_drawSetting);
            setting.xPos = 0;
            setting.yPos = 0;
            setting.Rotation = 0;
            return loadImage(uri, setting, pos);
        }
        public DrawSetting loadImage(String uri, DrawSetting imageSetting, Position pos)
        {
            try
            {
                BitmapImage tmpImage;
                
                tmpImage = new BitmapImage(new Uri(@uri, UriKind.Relative));
                imageSetting.Image = tmpImage;
                imageSetting.updatePosition(pos);

                _image.Add(new Tuple<BitmapImage, DrawSetting>(tmpImage, imageSetting));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return imageSetting;
        }
        public DrawSetting loadImage(String uri, DrawSetting imageSetting)
        {
            try
            {
                Tuple < BitmapImage, DrawSetting > tmpTuple=new Tuple<BitmapImage, DrawSetting>(new BitmapImage(new Uri(@uri, UriKind.Relative)), imageSetting);
                _image.Add(tmpTuple);
                imageSetting.Image=tmpTuple.Item1;
            
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return imageSetting;
        }

        public DrawSetting PositionData
        {
            get { return _drawSetting; }
            set { _drawSetting = value; }
        }
        public int xPos
        {
            get { return _drawSetting.xPos; }
            set { _drawSetting.xPos = value; }
        }
        public int yPos
        {
            get { return _drawSetting.yPos; }
            set { _drawSetting.yPos = value; }
        }
        public float xSpeed
        {
            get { return _xSpeed; }
            set { _xSpeed = value; }
        }
        public float ySpeed
        {
            get { return _ySpeed; }
            set { _ySpeed = value; }
        }
        public int drawIndex
        {
            get { return _drawSetting.DrawIndex; }
            set { _drawSetting.DrawIndex = value; }
        }
        public float Rotation
        {
            get { return _drawSetting.Rotation; }
            set { _drawSetting.Rotation = value; }
        }
        public int xCenter
        {
            get { return _drawSetting.xCenter; }
            set { _drawSetting.xCenter = value; }
        }
        public int yCenter
        {
            get{ return _drawSetting.yCenter; }
            set { _drawSetting.yCenter = value; }
        }

        public List<Tuple<BitmapImage, DrawSetting>> Image
        {
            get 
            {
                if (_image.Count == 0)
                {
                    List<Tuple<BitmapImage, DrawSetting>> list = new List<Tuple<BitmapImage, DrawSetting>> ();
                    list.Add(new Tuple<BitmapImage,DrawSetting>(new BitmapImage(new Uri(@"Assets/K/notFound.png", UriKind.Relative)), new DrawSetting(100,0,0,0,0,0,2)));
                    return list;
                }
                return _image; 
            }
            set
            {
                _image = value;
            }
        }
        public float Scale
        {
            get { return _drawSetting.Scale; }
            set { _drawSetting.Scale = value; }
        }
    }

    class K_Player: K_DrawObject
    {
        String _AngleID;
        float _DriveRange;
        float _ShootForce;
        float _Health;

  
        public String AngleID
        {
            get { return _AngleID; }
            set { _AngleID = value; }
        }
        public float Angle
        {
            get { return getAngle(); }
            set { setAngle(value); }
        }

        float getAngle()
        {
            foreach (Tuple<BitmapImage, DrawSetting> data in Image)
            {
                if (data.Item2.ID.Equals(_AngleID))
                {
                    return data.Item2.Rotation;
                }
            }
            return 0;
        }
        void setAngle(float angle)
        {
            foreach (Tuple<BitmapImage, DrawSetting> data in Image)
            {
                if (data.Item2.ID.Equals(_AngleID))
                {
                    data.Item2.Rotation = angle;
                }
            }
        }
    }

    class K_Projectile: K_DrawObject
    {
        float _xSpeed;
        float _ySpeed;
        float _Damage;
        float _DamageRadius;
        int _DamageType;

  
    }

    class K_Target : K_DrawObject
    {
        float _Radius;

    }

    class K_Object : K_DrawObject
    {
    
    }

}
