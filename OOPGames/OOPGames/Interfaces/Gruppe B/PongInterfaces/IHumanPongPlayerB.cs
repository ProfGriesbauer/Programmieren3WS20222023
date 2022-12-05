using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPGames
{
    public interface IHumanPongPlayerB : IHumanGamePlayer
    {
        IPongMoveB GetMove(IMoveSelection selection, IPongFieldB field);
    }
}
