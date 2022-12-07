using OOPGames.Interfaces.Gruppe_K;
using System;
using System.Collections.Generic;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using static OOPGames.Classes.Gruppe_K.K_DrawObject;

namespace OOPGames.Classes.Gruppe_K
{
    class K_GameObjectManager : IK_GameField
    {
            List<K_GameObject> _objects = new List<K_GameObject>();
            K_GameField _gameField;
            K_Status _status;

        public List<K_GameObject> Objects
        {
            get { return _objects; }
            set { _objects = value; }
        }

        public K_Status Status
        {
            get { return _status;}
            set { _status = value; }
        }

        public K_GameField GameField
        {
            get { return _gameField;}
            set { _gameField = value; }
        }

        public bool CanBePaintedBy(IPaintGame painter)
        {
            if (painter is IK_PaintGameObject)
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
        int _state;

        public int State { get { return _state; } set { _state = value; } }
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
            if (x >= 0 && x < Width && y >= 0 && y < Height)
            {
                return _field[x + y * _width];
            }
            return 0;
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

    abstract class K_Player: K_DrawObject, IK_HumanPlayer
    {
        String _AngleID;
        float _DriveRange;
        float _ShootForce;
        float _Health;
        K_Status _Status=new K_Status();
  
        public String AngleID
        {
            get { return _AngleID; }
            set { _AngleID = value; }
        }

        public float Angle { get => getAngle(); set => setAngle(value); }
        public abstract string Name { get; }
        public abstract int PlayerNumber { get; }

        public bool CanBeRuledBy(IGameRules rules)
        {
            if (rules is K_RulesZielschiessen)
            {
                return true;
            }
            return false;
        }
        public abstract IGamePlayer Clone();

        public float getAngle()
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

        public K_Status Status{ get { return _Status; } set { _Status = value; } }

        public abstract IPlayMove GetMove(IMoveSelection selection, IGameField field);

        public void setAngle(float angle)
        {
            foreach (Tuple<BitmapImage, DrawSetting> data in Image)
            {
                if (data.Item2.ID.Equals(_AngleID))
                {
                    data.Item2.Rotation = angle;
                }
            }
        }

        public abstract void SetPlayerNumber(int playerNumber);

        public float getAngleField(K_GameField gameField)
        {
            int y = 0;
            int ry = 0;
            int ly = 0;

            while (gameField.getField(xPos, y) == 0 && y < gameField.Height)
            {
                y++;
            }

            y = 0;
            while (gameField.getField(xPos + 10, y) == 0 && y < gameField.Height)
            {
                y++;
            }
            ry = y;

            y = 0;
            while (gameField.getField(xPos - 10, y) == 0 && y < gameField.Height)
            {
                y++;
            }
            ly = y;
            return (float)(Math.Atan(((float)ry - (float)ly) / 20));

        }
        public void updatePosition(K_GameField gameField)
        {
            int y = 0;
            int ry = 0;
            int ly = 0;
            float rot = 0f;

            while (gameField.getField(xPos, y) == 0 && y<gameField.Height)
            {
                y++;
            }

            y = 0;
            while (gameField.getField(xPos + 10, y) == 0 && y < gameField.Height)
            {
                y++;
            }
            ry = y;

            y = 0;
            while (gameField.getField(xPos - 10, y) == 0 && y < gameField.Height)
            {
                y++;
            }
            ly = y;

            yPos = y;
            rot = (float)(Math.Atan(((float)ry - (float)ly) / 20));

        
            Rotation = ((float)180 / (float)Math.PI) * rot;
        }
    }

    class K_Move : IPlayMove
    {
        DrawSetting _position;
        int _playerNumber;
        public int PlayerNumber { get { return _playerNumber; } set { _playerNumber = value; } }
        public DrawSetting Position { get { return _position; } set { _position = value; } }
        
    }

    class K_HumanPlayer1 : K_Player
    {
        private int _PlayerNumber;
        public override string Name { get { return "K Human Player Keyboard Input"; } }

        public override int PlayerNumber { get { return _PlayerNumber; } }

        public override IGamePlayer Clone()
        {
            K_HumanPlayer1 ttthp = new K_HumanPlayer1();
            ttthp.SetPlayerNumber(_PlayerNumber);
            return ttthp;
        }

        public override IPlayMove GetMove(IMoveSelection selection, IGameField field)
        {
            K_Move move = new K_Move();
            move.Position = PositionData;
            
            if (selection is K_KeySelectionTick && field is K_GameObjectManager)
            {
                K_KeySelectionTick inputData = (K_KeySelectionTick)selection;
                K_GameField gameField = ((K_GameObjectManager)field).GameField;
                if (Status.State== 0)
                {
                    float rot=getAngleField(gameField);
                    
                    //Fahren
                    if (inputData.Keys.Contains(Key.A) && xPos > 25 && rot < 1.04)
                    {
                        xPos -= (int)(((double)3 * Math.Cos(rot)) + 1);
                    }

                    if (inputData.Keys.Contains(Key.D) && xPos < 775 && rot > -1.04)
                    {
                        xPos += (int)(((double)3 * Math.Cos(rot)) + 1);
                    }

                    //Rohr drehen
                    if (inputData.Keys.Contains(Key.W))
                    {
                        Angle += 3;
                    }

                    if (inputData.Keys.Contains(Key.S))
                    {
                        Angle -= 3;
                    }

                    //Schuss
                    if (inputData.Keys.Contains(Key.E))
                    {
                        Status.State = 1;
                    }
                 
                }
                if (Status.State == 1)
                {
                    if (inputData.Keys.Contains(Key.R))
                    {
                        Status.State = 0;
                    }
                }
            }
            return move;
        }

        public override void SetPlayerNumber(int playerNumber)
        {
            _PlayerNumber = playerNumber;
        }
    }

    class K_HumanPlayer2 : K_Player
    {
        private int _PlayerNumber;
        public override string Name { get { return "K Human Player Keyboard+Mouse Input"; } }

        public override int PlayerNumber { get { return _PlayerNumber; } }


        public override IGamePlayer Clone()
        {
            K_HumanPlayer2 ttthp = new K_HumanPlayer2();
            ttthp.SetPlayerNumber(_PlayerNumber);
            return ttthp;
        }

        public override IPlayMove GetMove(IMoveSelection selection, IGameField field)
        {
            K_Move move = new K_Move();
            move.Position = PositionData;

            if (selection is K_KeySelectionTick && field is K_GameObjectManager)
            {
                K_KeySelectionTick inputData = (K_KeySelectionTick)selection;
                K_GameField gameField = ((K_GameObjectManager)field).GameField;
                if (Status.State == 0)
                {
                    float rot = getAngleField(gameField);

                    //Fahren
                    if (inputData.Keys.Contains(Key.Left) && xPos > 25 && rot < 1.04)
                    {
                        xPos -= (int)(((double)3 * Math.Cos(rot)) + 1);
                    }

                    if (inputData.Keys.Contains(Key.Right) && xPos < 775 && rot > -1.04)
                    {
                        xPos += (int)(((double)3 * Math.Cos(rot)) + 1);
                    }

                }
            }

            if (selection is ClickSelection)
            {
                    //Schuss
                if (Status.State == 0)
                {
                   Status.State = 1;
                }
                else
                {
                  Status.State = 0;
                }
            }

            if(selection is K_MouseSelectionTick)
            {
                K_MouseSelectionTick inputData = (K_MouseSelectionTick)selection;
                //Rohr drehen
                if (Image.Count >= 2)
                {
                    Angle = (float)((180 / Math.PI) * Math.Atan2(inputData.YPos - (yPos + (Image[1].Item2.yPos - Image[1].Item2.yCenter)), inputData.XPos - (xPos + (Image[1].Item2.xPos - Image[1].Item2.xCenter)))) - Rotation;
                }
            }
            return move;
        }

        public override void SetPlayerNumber(int playerNumber)
        {
            _PlayerNumber = playerNumber;
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

    public class K_MouseSelectionTick : IClickSelection
    {
       
        int _PositionX=0;
        int _PositionY=0;

        public K_MouseSelectionTick( int positionX, int positionY)
        {
            
            _PositionX = positionX;
            _PositionY = positionY;
        
        }

        public int YPos { get { return _PositionY; } }
        public int XPos { get { return _PositionX; } }

        public MoveType MoveType { get { return MoveType.click; } }

        public int XClickPos => 0;

        public int YClickPos => 0;
    }

    public class K_KeySelectionTick : IKeySelection
    {
        Key _Key;
        int _ClickX = 0;
        int _ClickY = 0;
        static List<Key> _Keys=new List<Key>();
       
        public static void addKey(Key key)
        {
            if (!_Keys.Contains(key))
            {
                _Keys.Add(key);
            }
        }

        public static void removeKey(Key key)
        {
            if (_Keys.Contains(key))
            {
                _Keys.Remove(key);
            }
        }


        public Key Key { get { return _Key; } }

        public List<Key> Keys { get { return _Keys; } }

        public MoveType MoveType { get { return MoveType.key; } }
    }

}
