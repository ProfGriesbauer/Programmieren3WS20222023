using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using OOPGames;

namespace OOPGames
{
    public class B_HumanPlayer_Pong : IHumanPongPlayerB
    {

        int _PlayerNumber = 0;
        public string Name { get { return "GruppeBPongHumanPlayer"; } }

        public int PlayerNumber { get { return _PlayerNumber; } }

        public bool CanBeRuledBy(IGameRules rules)
        {
            return rules is IPongRulesB; ;
        }

        public IGamePlayer Clone()
        {
            B_HumanPlayer_Pong ttthp = new B_HumanPlayer_Pong();
            ttthp.SetPlayerNumber(_PlayerNumber);
            return ttthp;
        }

        public IPongMoveB GetMove(IMoveSelection selection, IPongFieldB field)
        {
            if (selection is IKeySelection)
            {
                IKeySelection sel = (IKeySelection)selection;

                if (sel.Key is Key.A)
                {
                    return new B_Move_Pong(-4, 2);
                }
                if (sel.Key == Key.D)
                {
                    return new B_Move_Pong(4, 2);
                }
                if (sel.Key is Key.J)
                {
                    return new B_Move_Pong(-4, 1);
                }
                if (sel.Key == Key.L)
                {
                    return new B_Move_Pong(4, 1);
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
            
        }

        public IPlayMove GetMove(IMoveSelection selection, IGameField field)
        {
            if (field is IPongFieldB)
            {
                return GetMove(selection, (IPongFieldB)field);
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
    }

    public class B_GameField_Pong : IPongFieldB
    {
        B_Ball _ball = new B_Ball(10, 3, 3);
        B_Paddle _paddle1 = new B_Paddle(1, false);
        B_Paddle _paddle2 = new B_Paddle(2, true);
        public B_Ball ball { get { return _ball; } set { _ball = value; } }
        public B_Paddle paddle1 { get { return _paddle1; } set { _paddle1 = value; } }
        public B_Paddle paddle2 { get { return _paddle2; } set { _paddle2 = value; } }

        public bool CanBePaintedBy(IPaintGame painter)
        {
            return painter is B_Pong_Painter;
        }
    }


    public class B_Move_Pong : IPongMoveB
    {
        int _moveDirection = 0;
        int _PlayerNumber = 0;

        public B_Move_Pong(int moveDirection, int playerNumber)
        {
            _moveDirection = moveDirection;
            _PlayerNumber = playerNumber;
        }
    

        public int moveDirection { get { return _moveDirection; } }

        public int PlayerNumber { get { return _PlayerNumber; } }
    }
}

