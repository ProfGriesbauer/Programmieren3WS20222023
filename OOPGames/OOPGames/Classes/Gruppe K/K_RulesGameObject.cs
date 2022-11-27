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


        public string Name { get { return "K Rules tpd"; } }

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
            K_GameField testField = new K_GameField();
            // Fill testField with test values;

            double f6 = -2e-16;
            double f5 = 1e-12;
            double f4 = -5e-9;
            double f3 = 7e-6;
            double f2 = -3e-3;
            double f1 = 3e-1;
            double f0 = 200;

            for (int x = 0; x < testField.Width; x++)
            {
                int yLimit = (int)(f6 * Math.Pow(x, 6) + f5 * Math.Pow(x, 5) + f4 * Math.Pow(x, 4) + f3 * Math.Pow(x, 3) + f2 * Math.Pow(x, 2) + f1 * x + f0);
                for (int y = 0; y < testField.Height; y++)
                {
                    if (yLimit <= y)
                    {
                        testField.setField(x, y, 1);
                    }
                    else
                    {
                        testField.setField(x, y, 0);
                    }
                }
            }

            // testPlayer K_Player object
            K_Player testPlayer = new K_Player();
            testPlayer.Image = new BitmapImage(new Uri(@"Assets\K\Panzer.png", UriKind.Relative));
            int x1 = 300;
            testPlayer.Scale = 2;
            testPlayer.Rotation = 0f;
            testPlayer.xPos = x1;
            testPlayer.yPos = (int)(f6 * Math.Pow(x1, 6) + f5 * Math.Pow(x1, 5) + f4 * Math.Pow(x1, 4) + f3 * Math.Pow(x1, 3) + f2 * Math.Pow(x1, 2) + f1 * x1 + f0);
            testPlayer.yPos -= (int)(10 * testPlayer.Scale);


            // testProjectile K_Projectile object
            // TODO Write Test Parameters
            K_Projectile testProjectile = new K_Projectile();

            // testTarget K_Target object
            // TODO Write Test Parameters
            K_Target testTarget = new K_Target();



            // Add test data
            _gameManager.Objects.Add(testField);
            _gameManager.Objects.Add(testPlayer);
            _gameManager.Objects.Add(testProjectile);
            _gameManager.Objects.Add(testTarget);
        }

        public void TickGameCall()
        {

        }


    }
}
