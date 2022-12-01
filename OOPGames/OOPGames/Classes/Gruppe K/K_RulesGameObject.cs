using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Media;

namespace OOPGames.Classes.Gruppe_K
{
    class K_RulesGameObject : IGameRules, IGameRules2
    {

        K_GameObjectManager _gameManager;


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
            _gameManager.Objects = new List<K_GameObject>();

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
            testPlayer.loadImage("Assets/K/Panzer.png");
            int x1 = 300;
            testPlayer.Scale = 2;
            testPlayer.xCenter = (int)(testPlayer.Scale * testPlayer.Image[0].PixelWidth) / 2;
            testPlayer.yCenter = (int)(testPlayer.Scale * testPlayer.Image[0].PixelHeight);
            testPlayer.Rotation = 0f;
            testPlayer.xPos = x1;
            testPlayer.yPos = (int)(f6 * Math.Pow(x1, 6) + f5 * Math.Pow(x1, 5) + f4 * Math.Pow(x1, 4) + f3 * Math.Pow(x1, 3) + f2 * Math.Pow(x1, 2) + f1 * x1 + f0);
            testPlayer.yPos -= (int)(10 * testPlayer.Scale);
            

            // testProjectile K_Projectile object
            // TODO Write Test Parameters
            K_Projectile testProjectile = new K_Projectile();
            testProjectile.xPos = 100;
            testProjectile.yPos = 100;
            // testTarget K_Target object
            // TODO Write Test Parameters
            K_Target testTarget = new K_Target();



            // Add test data
            _gameManager.Objects.Add(testField1);
            _gameManager.Objects.Add(testField2);
            _gameManager.Objects.Add(testPlayer);
            _gameManager.Objects.Add(testProjectile);
            _gameManager.Objects.Add(testTarget);
        }

        public void TickGameCall()
        {

        }


    }
}
