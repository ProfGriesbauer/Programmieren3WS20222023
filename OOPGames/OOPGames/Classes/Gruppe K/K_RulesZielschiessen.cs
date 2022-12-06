using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using static System.Net.Mime.MediaTypeNames;
using System.Windows.Controls;

namespace OOPGames.Classes.Gruppe_K
{
    internal class K_RulesZielschiessen : IGameRules2
    {
        K_GameObjectManager _gameManager;
        int _gameState = 0;
        int _playerxpos = 50;
        int _playerypos = 0;
        float _playerrot = 0;
        float _playerangle = 0;

        public string Name { get { return "K Rules Zielschießen"; } }

        public bool MovesPossible { get { return true; } }

        IGameField IGameRules.CurrentField { get { return _gameManager; } }

        public int CheckIfPLayerWon()
        {
            return 0;
        }

        public void ClearField()
        {

        }

        public void DoMove(IPlayMove move)
        {

        }
        public void StartedGameCall()
        {
            _gameManager = new K_GameObjectManager();
            _gameState = 0;

            //Panzerspieler erstellen
            K_Player Panzerplayer = new K_Player();
            K_DrawObject.DrawSetting drawSettingTank = new K_DrawObject.DrawSetting();
            K_DrawObject.DrawSetting drawSettingTankR = new K_DrawObject.DrawSetting();
            drawSettingTank.Scale = 2;
            drawSettingTank.xPos = _playerxpos;
            drawSettingTank.yPos = _playerypos;
            drawSettingTank.Rotation = _playerrot;
            drawSettingTank.DrawIndex = 10;
            Panzerplayer.PositionData = drawSettingTank;
            Panzerplayer.loadImage("Assets/K/Panzer.png", K_DrawObject.Position.CenterBottom);
            drawSettingTankR.Scale = drawSettingTank.Scale / 2;
            drawSettingTankR.DrawIndex = drawSettingTank.DrawIndex - 1;
            drawSettingTankR.yPos -= (int)(15 * drawSettingTankR.Scale);
            drawSettingTankR.ID = "gun";
            Panzerplayer.loadImage("Assets/K/PanzerR.png", drawSettingTankR, K_DrawObject.Position.LeftCenter);
            Panzerplayer.AngleID = drawSettingTankR.ID;



            //Spielfeld erstellen
            K_GameField randomeSpielfeld = new K_GameField();

            List<Color> colorList = new List<Color>();
            colorList.Add(Colors.Transparent);
            colorList.Add(Colors.Aqua);
            colorList.Add(Colors.Brown);
            colorList.Add(Colors.Gray);
            randomeSpielfeld.Palette = new BitmapPalette(colorList);

            randomeSpielfeld.drawIndex = 1;

            Random rand = new Random();


            double f3 = rand.Next(7, 10) * 1e-7;
            double f2 = rand.Next(1, 2) * -1e-3;
            double f1 = rand.Next(1, 3) * 1e-1;
            double f0 = rand.Next(0, 50) + 280;

            //Testwerte für steilen Hang
            /*
            double f3 = 1e-7;
            double f2 = -1e-3;
            double f1 = -20e-1;
            double f0 = 280;
            */

            for (int x = 0; x < randomeSpielfeld.Width; x++)
            {
                int yLimit = (int)(f3 * Math.Pow(x, 3) + f2 * Math.Pow(x, 2) + f1 * x + f0);
                for (int y = 0; y < randomeSpielfeld.Height; y++)
                {
                    if (yLimit <= y)
                    {
                        randomeSpielfeld.setField(x, y, 2);
                    }
                    else
                    {
                        randomeSpielfeld.setField(x, y, 0);
                    }
                }
            }

            _gameManager.Objects.Add(Panzerplayer);
            _gameManager.Objects.Add(randomeSpielfeld);

        }

        public void TickGameCall()
        {

            if (_gameState == 0)
            {

                foreach (K_GameObject data in _gameManager.Objects)
                {

                    if (data is K_GameField)
                    {
                        int y = 0;
                        int ry = 0;
                        int ly = 0;

                        while (((K_GameField)data).getField(_playerxpos, y) == 0)
                        {
                            y++;
                        }
                        _playerypos = y;

                        y = 0;
                        while (((K_GameField)data).getField(_playerxpos + 10, y) == 0)
                        {
                            y++;
                        }
                        ry = y;

                        y = 0;
                        while (((K_GameField)data).getField(_playerxpos - 10, y) == 0)
                        {
                            y++;
                        }
                        ly = y;

                        _playerrot = (float)(Math.Atan(((float)ry - (float)ly) / 20));
                    }

                    if (data is K_Player)
                    {
                        ((K_Player)data).yPos = _playerypos;
                        ((K_Player)data).Rotation = ((float)180 / (float)Math.PI) * _playerrot;

                        //Fahren
                        if (Keyboard.IsKeyDown(Key.A) && ((K_Player)data).xPos > 25 && _playerrot < 1.04)
                        {
                            ((K_Player)data).xPos -= (int)(((double)3 * Math.Cos(_playerrot)) + 1);
                        }

                        if (Keyboard.IsKeyDown(Key.D) && ((K_Player)data).xPos < 775 && _playerrot > -1.04)
                        {
                            ((K_Player)data).xPos += (int)(((double)3 * Math.Cos(_playerrot)) + 1);
                        }

                        //Rohr drehen
                        if (Keyboard.IsKeyDown(Key.W))
                        {
                            ((K_Player)data).Angle += 3;
                        }

                        if (Keyboard.IsKeyDown(Key.S))
                        {
                            ((K_Player)data).Angle -= 3;
                        }

                        _playerxpos = ((K_Player)data).xPos;
                    }

                    //Schuss
                    if (Keyboard.IsKeyDown(Key.L))
                    {
                        _gameState = 1;
                    }

                }
                if (_gameState == 1)
                {
                    if (Keyboard.IsKeyDown(Key.Z))
                    {
                        _gameState = 0;
                    }
                }

            }
        }
    }
}