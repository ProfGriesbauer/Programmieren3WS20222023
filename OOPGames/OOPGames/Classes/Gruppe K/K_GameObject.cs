using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

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
            if (x < _width && y < _height)
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
    }
    abstract class K_DrawObject: K_GameObject
    {
        int _xPos=0;
        int _yPos=0;
        float _xSpeed = 0;
        float _ySpeed = 0;
        int _drawIndex=10;
        float _rotation=0f;
        int _xCenter = 0;
        int _yCenter = 0;
        float _scale=1f;
        List<BitmapImage> _image = new List<BitmapImage>();

       

        public void loadImage(String uri)
        {
            _image.Add(new BitmapImage(new Uri(@uri, UriKind.Relative)));
        }

        public int xPos
        {
            get { return _xPos; }
            set { _xPos = value; }
        }
        public int yPos
        {
            get { return _yPos; }
            set { _yPos = value; }
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
            get { return _drawIndex; }
            set { _drawIndex = value; }
        }
        public float Rotation
        {
            get { return _rotation; }
            set { _rotation = value; }
        }
        public int xCenter
        {
            get { return _xCenter; }
            set { _xCenter = value; }
        }
        public int yCenter
        {
            get{ return _yCenter; }
            set { _yCenter = value; }
        }

        public List<BitmapImage> Image
        {
            get 
            {
                if (_image.Count == 0)
                {
                    List<BitmapImage> list = new List<BitmapImage>();
                    list.Add(new BitmapImage(new Uri(@"Assets/K/notFound.png", UriKind.Relative)));
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
            get { return _scale; }
            set { _scale = value; }
        }


    }

    class K_Player: K_DrawObject
    {
        float _DriveRange;
        float _ShootAngle;
        float _ShootForce;
        float _Health;
    }

    class K_Projectile: K_DrawObject
    {
        float _xSpeed;
        float _ySpeed;
        float _Damage;
        float _DamageRadius;
        int _DamageType;
    }

    class K_Target: K_DrawObject
    {
        float _Radius;
    }

    class K_Object: K_DrawObject
    {
    }

}
