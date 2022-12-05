using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using System.Windows.Forms;

namespace OOPGames.Classes.Gruppe_K
{
    class K_RulesGameObject : IGameRules, IGameRules2
    {

        K_GameObjectManager _gameManager=new K_GameObjectManager();

        public string Name { get { return "K Rules tbd"; } }

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
            // INFO
            // Used as Testcase for K_PaintGameObject

            // testData List
            _gameManager = new K_GameObjectManager();

            // testField K_GameField object
            K_GameField testField1 = new K_GameField();

            // Create Palette
            List<Color> colorList = new List<Color>();
            colorList.Add(Colors.Transparent);
            colorList.Add(Colors.Aqua);
            colorList.Add(Colors.Beige);
            colorList.Add(Colors.Gray);
            testField1.Palette = new BitmapPalette(colorList);

            // Set drawIndex
            testField1.drawIndex = 1;
            // Fill testField with test values;
            double f6 = -2e-16;
            double f5 = 1e-12;
            double f4 = -5e-9;
            double f3 = 7e-6;
            double f2 = -3e-3;
            double f1 = 3e-1;
            double f0 = 200;


            for (int x = 0; x < testField1.Width; x++)
            {
                int yLimit = (int)(f6 * Math.Pow(x, 6) + f5 * Math.Pow(x, 5) + f4 * Math.Pow(x, 4) + f3 * Math.Pow(x, 3) + f2 * Math.Pow(x, 2) + f1 * x + f0);
                for (int y = 0; y < testField1.Height; y++)
                {
                    if (yLimit <= y)
                    {
                        testField1.setField(x, y, 2);
                    }
                    else
                    {
                        testField1.setField(x, y, 0);
                    }
                }
            }

            // Add Test Hole to Field
            int holeX = 500;
            int holeY = 220;
            int holeRX = 60;
            int holeRY = 30;
            for(int x = -holeRX; x < holeRX; x++)
            {
                for(int y = -holeRY; y < holeRY; y++)
                {
                    float x2 = (holeRY/(float)holeRX) *x * x;
                    float y2 = (holeRX / (float)holeRY) * y * y;
                    if ((x2 + y2) <= holeRX*holeRY)
                    {
                        testField1.setField(x + holeX, y + holeY, 0);
                    }
                }
            }


            // testField K_GameField object
            K_GameField testField2 = new K_GameField();

         
            testField2.Palette = new BitmapPalette(colorList);

            // Set drawIndex
            testField2.drawIndex = 0;


            Random random = new Random();
            int resPos = random.Next(200)+100;

            for (int x = 0; x < testField2.Width; x++)
            {
                for (int y = 0; y < testField2.Height; y++)
                {
                   if (x % resPos < (y-100))
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



            // testPlayer K_Player object
            K_Player testPlayer = new K_Player();
            K_DrawObject.DrawSetting drawSettingTank = new K_DrawObject.DrawSetting();
            K_DrawObject.DrawSetting drawSettingTankR = new K_DrawObject.DrawSetting();

            // Settings for testPlayer
            drawSettingTank.Scale = 2;
            drawSettingTank.xPos = 300;
            drawSettingTank.yPos = (int)(f6 * Math.Pow(drawSettingTank.xPos, 6) + f5 * Math.Pow(drawSettingTank.xPos, 5) + f4 * Math.Pow(drawSettingTank.xPos, 4) + f3 * Math.Pow(drawSettingTank.xPos, 3) + f2 * Math.Pow(drawSettingTank.xPos, 2) + f1 * drawSettingTank.xPos + f0);
            drawSettingTank.Rotation = 0;
            drawSettingTank.DrawIndex = 10;
            testPlayer.PositionData =drawSettingTank;

            // Add Tank image
            testPlayer.loadImage("Assets/K/Panzer.png", K_DrawObject.Position.CenterBottom);


            // Configure and add Barrel image to Tank
            drawSettingTankR.Scale = drawSettingTank.Scale/2;
            drawSettingTankR.DrawIndex=drawSettingTank.DrawIndex-1;
            drawSettingTankR.yPos -= (int)(15*drawSettingTankR.Scale);
            drawSettingTankR.ID = "gun";
            testPlayer.loadImage("Assets/K/PanzerR.png",drawSettingTankR, K_DrawObject.Position.LeftCenter);

            // ID to define Object affected by Angle property
            testPlayer.AngleID = drawSettingTankR.ID;




            // testProjectile K_Projectile object
            // TODO Write Test Parameters
            K_Projectile testProjectile = new K_Projectile();
            testProjectile.xPos = 100;
            testProjectile.yPos = 100;
            // testTarget K_Target object
            // TODO Write Test Parameters
            K_Target testTarget = new K_Target();
            testTarget.xPos = 200;
            testTarget.yPos = 300;



            // Add test data
            _gameManager.Objects.Add(testField1);
            _gameManager.Objects.Add(testField2);
            _gameManager.Objects.Add(testPlayer);
            _gameManager.Objects.Add(testProjectile);
            _gameManager.Objects.Add(testTarget);
        }


        // Test for rotation of hole Objekt and internal Image
        float dirBarrel = -1;
        float dirTank = 0.2f;
        public void TickGameCall()
        {
            ((K_GameField)_gameManager.Objects[0]).removeHoles();

            foreach(K_GameObject data in _gameManager.Objects)
            {
                if (data is K_Player)
                {
                    // Rotate Barrel
                    //((K_Player)data).AngleID = "gun";
                    ((K_Player)data).Angle += dirBarrel;
                    dirBarrel *= ((((K_Player)data).Angle > 0 && dirBarrel > 0) || (((K_Player)data).Angle < -180 && dirBarrel < 0)) ? -1 : 1;

                    // Rotate whole testPlayer1 Object
                    ((K_Player)data).Rotation +=dirTank;
                    dirTank *= ((((K_Player)data).Rotation > 20 && dirTank > 0) || (((K_Player)data).Rotation < -20 && dirTank < 0)) ? -1 : 1;

                }
            }
        }


    }
}
