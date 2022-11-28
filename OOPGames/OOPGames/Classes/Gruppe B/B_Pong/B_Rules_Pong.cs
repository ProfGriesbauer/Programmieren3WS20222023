using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPGames
{
    public class B_Rules_Pong : IPongRulesB
    {
        public IPongFieldB PongField => throw new NotImplementedException();

        public string Name => throw new NotImplementedException();

        public IGameField CurrentField => throw new NotImplementedException();

        public bool MovesPossible => throw new NotImplementedException();

        public int CheckIfPLayerWon()
        {
            throw new NotImplementedException();
        }

        public void ClearField()
        {
            throw new NotImplementedException();
        }

        public void DoMove(IPlayMove move)
        {
            throw new NotImplementedException();
        }

        public void DoPongMove(IPongMoveB move)
        {
            throw new NotImplementedException();
        }

        public void StartedGameCall()
        {
            throw new NotImplementedException();
        }

        public void TickGameCall()
        {
            throw new NotImplementedException();
        }
    }
}
