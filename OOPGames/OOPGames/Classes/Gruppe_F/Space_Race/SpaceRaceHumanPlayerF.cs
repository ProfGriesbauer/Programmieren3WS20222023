using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using OOPGames.Classes.Gruppe_F.Space_Race;

namespace OOPGames
{
    internal class SpaceRaceHumanPlayerF : ISpaceRaceHumanPlayerF
    {
        int _PlayerNumber = 0;
        int _PlayerScore = 0;

        int _xPos = 450;
        int _yPos = 850;
        int _width = 15;
        int _height = 40;
        int _ySpeed = 20;
        bool _hasShield = false;

        public string Name { get { return "SpaceRaceHumanPlayerF"; } }

        public int PlayerNumber { get { return _PlayerNumber; } }

        public int PlayerScore { get { return _PlayerScore; } set { _PlayerScore = value; } }

        public int xPos {  get { return _xPos; } set { _xPos = value; } }
        public int yPos { get { return _yPos; } set { _yPos = value; } }
        public int width { get { return _width ; } set { _width = value; } }
        public int height { get { return _height; } set { _height = value; } }
        public int ySpeed { get { return _ySpeed; } set { _ySpeed = value; } }
        public bool hasShield { get { return _hasShield; } set { _hasShield = value; } }

       

        public bool CanBeRuledBy(IGameRules rules)
        {
            return rules is SpaceRaceRulesF;
        }

        public bool checkCollision(int xPosm, int yPosm, int radm)
        {
            if (xPosm + 2*radm > _xPos - _width/2 && xPosm < _xPos + _width/2 && yPosm + 2*radm > _yPos && yPosm < _yPos + height) {
                if (_hasShield)
                {
                    _hasShield = false;
                    return true;
                }
                else
                {
                    respawn();
                    return true;
                }
            }
            return false; 
        }

        public IGamePlayer Clone()
        {
            SpaceRaceHumanPlayerF SRhp = new SpaceRaceHumanPlayerF();
            SRhp.SetPlayerNumber(PlayerNumber);

            return SRhp;
        }


        public void move() 
        {
            if (Keyboard.IsKeyDown(Key.W))
            {
                _yPos -= _ySpeed;
            }
            else if (Keyboard.IsKeyDown(Key.S))
            {
                _yPos += _ySpeed;
            }

            //yPos -= ySpeed;
        }

        public void respawn()
        {
            _xPos = 450;
            _yPos = 850;
        }

        public void SetPlayerNumber(int playerNumber)
        {
            _PlayerNumber = playerNumber;
        }

        public void update()
        {
            if (yPos <= 0)
            {
                _PlayerScore++;
                respawn();
            }
        }
    }
}
