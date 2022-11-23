using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPGames
{
    public interface IPongRulesB : IGameRules2
    {
        IPongFieldB PongField { get; }

        void DoPongMove(IPongMoveB move);
    }
    public interface IPongMoveB
    {

    }
}
