using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace OOPGames
{
    public class B_Rules_Pong : IPongRulesB
    {
        B_GameField_Pong _PongField = new B_GameField_Pong();
        public IPongFieldB PongField
        {
            get
            {
                return _PongField;
            }
        }

        public string Name { get { return "GruppeBPongRules"; } }

        public IGameField CurrentField { get { return PongField; } }

        public bool MovesPossible
        {
            get
            {
                if (_PongField.paddle1.paddleX > 50 && _PongField.paddle1.paddleX < 350 
                    && _PongField.paddle2.paddleX > 50 && _PongField.paddle2.paddleX < 350)
                {
                    return true;
                }
                return false;
            }
        }

        public int CheckIfPLayerWon() // Spieler 1 oben Spieler 2 unten
        {
            if (_PongField.ball.ballY <= 50 + _PongField.ball.radius)
            {
                return 2;
            }

            if (_PongField.ball.ballY >= 350 - _PongField.ball.radius)
            {
                return 1;
            }
            return -1;
        }

        public void ClearField()
        {
            _PongField = new B_GameField_Pong();
        }

        public void DoMove(IPlayMove move)
        {
            if (move is IPongMoveB)
            {
                DoPongMove((IPongMoveB)move);
            }
        }

        public void DoPongMove(IPongMoveB move)
        {
            if (move.PlayerNumber == 1)
            {
                _PongField.paddle1.stepsize = move.moveDirection;
                _PongField.paddle1.calculate();
                
            }
            if (move.PlayerNumber == 2)
            {
                _PongField.paddle2.stepsize = move.moveDirection;
                _PongField.paddle2.calculate();
                
            }
        }

        public void StartedGameCall()
        {

        }

        public void TickGameCall()
        {
            if (_PongField.ball.ballX - _PongField.ball.radius <= 50)
            {
                _PongField.ball.velocityX = _PongField.ball.velocityX * -1;
            }
            if (_PongField.ball.ballX + _PongField.ball.radius >= 350)
            {
                _PongField.ball.velocityX = _PongField.ball.velocityX * -1;
            }
            if (_PongField.ball.ballY - _PongField.ball.radius <= 80 && _PongField.ball.ballX == _PongField.paddle1.paddleX)
            {
                _PongField.ball.velocityY = _PongField.ball.velocityY * -1;
            }
            if (_PongField.ball.ballY + _PongField.ball.radius >= 520 && _PongField.ball.ballX == _PongField.paddle2.paddleX)
            {
                _PongField.ball.velocityY = -_PongField.ball.velocityY * -1;
            }

            _PongField.ball.calculate();
        }
    }
}

