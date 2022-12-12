using OOPGames;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPGames
{

    public class B_ComputerPlayer_Pong : IComputerGamePlayer
    {
        int _PlayerNumber = 0;

        public string Name { get { return "B_ComputerPlayer_Pong"; } }

        public int PlayerNumber { get { return _PlayerNumber; } }

        public bool CanBeRuledBy(IGameRules rules)
        {
            return rules is B_Rules_Pong;
        }


        public IPlayMove GetMove(IGameField field)
        {
            IPongFieldB pongfield = (IPongFieldB)field;

            if (_PlayerNumber == 1)
            {
                if (pongfield.ball.ballX > pongfield.paddle1.paddleX)
                {
                    return new B_Move_Pong(4, 1);
                }

                if (pongfield.ball.ballX < pongfield.paddle1.paddleX)
                {
                    return new B_Move_Pong(-4, 1);
                }

                else { return null; }
            }



            if (_PlayerNumber == 2)
            {
                if (pongfield.ball.ballX > pongfield.paddle2.paddleX)
                {
                    return new B_Move_Pong(4, 2);
                }

                if (pongfield.ball.ballX < pongfield.paddle2.paddleX)
                {
                    return new B_Move_Pong(-4, 2);
                }

                else { return null; }
            }

            else { return null; }
        }

        public void SetPlayerNumber(int playerNumber)
        {
            _PlayerNumber = playerNumber;
        }

        IGamePlayer IGamePlayer.Clone()
        {
            IGamePlayer other = new B_ComputerPlayer_Pong();
            other.SetPlayerNumber(_PlayerNumber);
            return other;
        }
    }
}



//velocity.ball abfragen
//velocity.Paddle definieren
//                übergeben