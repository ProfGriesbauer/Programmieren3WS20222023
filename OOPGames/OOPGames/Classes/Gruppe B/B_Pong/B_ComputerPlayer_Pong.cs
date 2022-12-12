using OOPGames;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPGames
{

    public class B_ComputerPlayer_Pong : IComputerPongPlayerB
    {
        int _PlayerNumber = 0;

        public string Name { get { return "B_ComputerPlayer_Pong"; } }

        public int PlayerNumber { get { return _PlayerNumber; } }

        public bool CanBeRuledBy(IGameRules rules)
        {
            return rules is IPongRulesB;
        }


        public IPlayMove GetMove(IGameField field)
        {
            if (field is IPongFieldB)
            {
                return GetMove((IPongFieldB)field);
            }
            else
            {
                return null;
            }
        }

        public void SetPlayerNumber(int playerNumber)
        {
            _PlayerNumber = playerNumber;
        }

        public IGamePlayer Clone()
        {
            B_ComputerPlayer_Pong other = new B_ComputerPlayer_Pong();
            other.SetPlayerNumber(_PlayerNumber);
            return other;
        }

        public IPongMoveB GetMove(IPongFieldB field)
        {
            

            if (_PlayerNumber == 1)
            {
                if (field.ball.ballX > field.paddle1.paddleX + field.paddle1.lineWidth/2)
                {
                    return new B_Move_Pong(4, 1);
                }

                if (field.ball.ballX < field.paddle1.paddleX + field.paddle1.lineWidth / 2)
                {
                    return new B_Move_Pong(-4, 1);
                }

                else { return null; }
            }



            if (_PlayerNumber == 2)
            {
                if (field.ball.ballX > field.paddle2.paddleX + field.paddle2.lineWidth / 2)
                {
                    return new B_Move_Pong(4, 2);
                }

                if (field.ball.ballX < field.paddle2.paddleX + field.paddle2.lineWidth / 2)
                {
                    return new B_Move_Pong(-4, 2);
                }

                else { return null; }
            }

            else { return null; }
        }
    }
}




