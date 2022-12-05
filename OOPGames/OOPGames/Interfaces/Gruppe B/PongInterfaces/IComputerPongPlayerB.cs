using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPGames
{
    public interface IComputerPongPlayerB : IComputerGamePlayer
    {
        IPongMoveB GetMove(IPongFieldB field);
    }
}
