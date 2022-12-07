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
using System.Windows.Markup;

namespace OOPGames.Classes.Gruppe_K
{
    internal class K_RulesZielschiessen : IGameRules2
    {
        OOPGamesManager _OOPmanager= OOPGamesManager.Singleton;
        K_GameObjectManager _KgameManager=new K_GameObjectManager();

        List<K_Player> Panzerplayer = new List<K_Player>();
        K_GameField randomeSpielfeld = new K_GameField();
       

        public string Name { get { return "K Rules Zielschießen"; } }

        public bool MovesPossible { get { return true; } }

        IGameField IGameRules.CurrentField { get { return _KgameManager; } }

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
            _KgameManager = new K_GameObjectManager();
            _KgameManager.Status = new K_Status();
            Panzerplayer = new List<K_Player>();
            randomeSpielfeld = new K_GameField();

            

            //Panzerspieler erstellen
            if (_OOPmanager.activePlayers.Count() > 0 && _OOPmanager.activePlayers.ElementAt(0) is K_Player) {
                IGamePlayer player1 = _OOPmanager.activePlayers.ElementAt(0);
                Panzerplayer.Add((K_Player)player1);

                K_DrawObject.DrawSetting drawSettingTank = new K_DrawObject.DrawSetting();
                K_DrawObject.DrawSetting drawSettingTankR = new K_DrawObject.DrawSetting();
                drawSettingTank.Scale = 2;
                drawSettingTank.xPos = 100;
                drawSettingTank.yPos = 100;
                drawSettingTank.Rotation = 0;
                drawSettingTank.DrawIndex = 10;
                Panzerplayer.Last<K_Player>().PositionData = drawSettingTank;
                Panzerplayer.Last<K_Player>().loadImage("Assets/K/Panzer.png", K_DrawObject.Position.CenterBottom);
                drawSettingTankR.Scale = drawSettingTank.Scale / 2;
                drawSettingTankR.DrawIndex = drawSettingTank.DrawIndex - 1;
                drawSettingTankR.yPos -= (int)(15 * drawSettingTankR.Scale);
                drawSettingTankR.ID = "gun";
                Panzerplayer.Last<K_Player>().loadImage("Assets/K/PanzerR.png", drawSettingTankR, K_DrawObject.Position.LeftCenter);
                Panzerplayer.Last<K_Player>().AngleID = drawSettingTankR.ID;

                Panzerplayer.Last<K_Player>().Status=new K_Status();
                Panzerplayer.Last<K_Player>().Status.State = 0;
            }
            if (_OOPmanager.activePlayers.Count() > 1 && _OOPmanager.activePlayers.ElementAt(1) is K_Player)
            {
                IGamePlayer player2 = _OOPmanager.activePlayers.ElementAt(1);

                //Panzerspieler erstellen
             

                    Panzerplayer.Add((K_Player)player2);

                    K_DrawObject.DrawSetting drawSettingTank = new K_DrawObject.DrawSetting();
                    K_DrawObject.DrawSetting drawSettingTankR = new K_DrawObject.DrawSetting();
                    drawSettingTank.Scale = 2;
                    drawSettingTank.xPos = 700;
                    drawSettingTank.yPos = 100;
                    drawSettingTank.Rotation = 0;
                    drawSettingTank.DrawIndex = 10;
                    Panzerplayer.Last<K_Player>().PositionData = drawSettingTank;
                    Panzerplayer.Last<K_Player>().loadImage("Assets/K/Panzer.png", K_DrawObject.Position.CenterBottom);
                    drawSettingTankR.Scale = drawSettingTank.Scale / 2;
                    drawSettingTankR.DrawIndex = drawSettingTank.DrawIndex - 1;
                    drawSettingTankR.yPos -= (int)(15 * drawSettingTankR.Scale);
                    drawSettingTankR.ID = "gun";
                    Panzerplayer.Last<K_Player>().loadImage("Assets/K/PanzerR.png", drawSettingTankR, K_DrawObject.Position.LeftCenter);
                    Panzerplayer.Last<K_Player>().AngleID = drawSettingTankR.ID;
                    Panzerplayer.Last<K_Player>().Angle = 180;

                    Panzerplayer.Last<K_Player>().Status = new K_Status();
                    Panzerplayer.Last<K_Player>().Status.State = 0;
                
            }


            //Spielfeld erstellen

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

            // Add Test Hole to Field
            int holeX = 50;
            int holeY = 350;
            int holeRX = 60;
            int holeRY = 30;
            for (int x = -holeRX; x < holeRX; x++)
            {
                for (int y = -holeRY; y < holeRY; y++)
                {
                    float x2 = (holeRY / (float)holeRX) * x * x;
                    float y2 = (holeRX / (float)holeRY) * y * y;
                    if ((x2 + y2) <= holeRX * holeRY)
                    {
                        randomeSpielfeld.setField(x + holeX, y + holeY, 0);
                    }
                }
            }


            // testField K_GameField object
            K_GameField testField2 = new K_GameField();


            testField2.Palette = new BitmapPalette(colorList);

            // Set drawIndex
            testField2.drawIndex = 0;


            Random random = new Random();
            int resPos = random.Next(200) + 100;

            for (int x = 0; x < testField2.Width; x++)
            {
                for (int y = 0; y < testField2.Height; y++)
                {
                    if (x % resPos < (y - 100))
                    {
                        testField2.setField(x, y, 3);
                    }
                    else
                    {
                        testField2.setField(x, y, 1);
                    }
                }
                if (x % 300 >= 299)
                {
                    resPos = random.Next(200) + 100;
                }
            }

            _KgameManager.GameField = randomeSpielfeld;
            
            _KgameManager.Objects.Add(randomeSpielfeld);
            _KgameManager.Objects.Add(testField2);

           foreach (K_Player data in Panzerplayer)
            {
                _KgameManager.Objects.Add(data);
            }
           

        }

        public void TickGameCall()
        {
            randomeSpielfeld.removeHoles();

            foreach(K_Player player in Panzerplayer)
            {
                player.updatePosition(randomeSpielfeld);
            }
           
        }
    }
}