using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace OOPGames.Classes.Gruppe_F.Space_Race
{
    public class SpaceRaceRulesF : ISpaceRaceRulesF
    {
        public float gametimer = 0;
        int CurrentPlayer;

        SpaceRaceFieldF _Field = new SpaceRaceFieldF();
        public string Name { get { return "SpaceRaceRulesF"; } }

        public IGameField CurrentField { get { return _Field; } }

        bool IGameRules.MovesPossible { get { return true; } }



        public cMeteor[] Meteors = new cMeteor[20];

        public cTimeBar TimeBar = new cTimeBar();

        public cShield Shield = new cShield();


        public int getArrayValueX(int i)
        {
            return Meteors[i].xPos;
        }

        public int getArrayValueY(int i)
        {
            return Meteors[i].yPos;
        }

        public int getArrayValueRAD(int i)
        {
            return Meteors[i].rad;
        }


        public int CheckIfPLayerWon()
        {
            if (gametimer <= 0)
            {
                return 1;
            }
            return -1; //Zeit noch nicht abgelaufen
        }

        public void ClearField() //unbenutzt
        {

        }

        public void DoMove(IPlayMove move) //unbenutzt
        {

        }

        public void StartedGameCall() //called when game is started
        {

            Random rnd = new Random();

            for (int i = 0; i < Meteors.Length; i++)
            {
                gametimer = 30000;
                Meteors[i] = new cMeteor();
                Meteors[i].create(rnd.Next(-50, 1000), rnd.Next(100, 800), rnd.Next(10, 30), 20);

            }

            Shield.create(-50, rnd.Next(100, 800), 30, 15); 
        }


        public void TickGameCall() // called every 40ms
        {
            gametimer -= 40;
        }



        public class SpaceRaceFieldF : ISpaceRaceFieldF
        {
            public bool CanBePaintedBy(IPaintGame painter)
            {
                return painter is ISpaceRacePainterF;
            }
        }



        public class cMeteor : IMeteor
        {
            int _xPos;
            int _yPos;
            int _xSpeed;
            int _rad;
            public int xPos { get { return _xPos; } set { _xPos = value; } }
            public int yPos { get { return _yPos; } set { _yPos = value; } }
            public int xSpeed { get { return _xSpeed; } set { _xSpeed = value; } }
            public int rad { get { return _rad; } set { _rad = value; } }

            public void create(int xPosI, int yPosI, int xSpeedI, int radI)
            {
                _xPos = xPosI;
                _yPos = yPosI;
                _xSpeed = xSpeedI;
                _rad = radI;
            }

            public void move()
            {
                _xPos += _xSpeed;
            }

            public void respawn()
            {
                Random rng = new Random();
                _xPos = -50;
                _yPos = rng.Next(100, 800);
                _xSpeed = rng.Next(10, 30);
            }

            public void update()
            {
                if (_xPos > 900)
                {
                    respawn();
                }
            }
            
        }

        public class cTimeBar : ITimeBar
        {
            float _barlength=500;
            float _barheight=25;
            public float barlength { get { return _barlength; } set { _barlength = value; } }
            public float barheight { get { return _barheight; } set { _barheight = value; } }

        }

        public class cShield : IShield
        {
            int _xPos;
            int _yPos;
            int _xSpeed;
            int _rad;

            public int xPos { get { return _xPos; } set { _xPos = value; } }
            public int yPos { get { return _yPos; } set { _yPos = value; } }
            public int xSpeed { get { return _xSpeed; } set { _xSpeed = value; } }
            public int rad { get { return _rad; } set { _rad = value; } }

            public bool checkCollision(int xPosS, int yPosS, int widthS, int heightS)
            {
                if (_xPos + 2*rad > xPosS - widthS/2 && _xPos < xPosS + widthS/2 && _yPos + 2*_rad > yPosS && _yPos < yPosS + heightS)
                {
                    respawn();
                    return true;
                }
                return false;
            }

            public void create(int xPosI, int yPosI, int xSpeedI, int radI)
            {
                _xPos = xPosI;
                _yPos = yPosI;
                _xSpeed = xSpeedI;
                _rad = radI;
            }

            public void move()
            {
                _xPos += _xSpeed;
            }

            public void respawn()
            {
                Random rng = new Random();
                _xPos = -50;
                _yPos = rng.Next(100, 800);
            }

            public void update()
            {
                if (_xPos > 900)
                {
                    respawn();
                }
            }
        }
    }
}


