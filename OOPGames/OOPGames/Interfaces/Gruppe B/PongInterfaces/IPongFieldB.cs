using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPGames
{
    public interface IPongFieldB : IGameField
    {
        B_Ball ball { get; set; }
        B_Paddle paddle1 { get; set; }
        B_Paddle paddle2 { get; set; }

        void freezeField();
        
    }
}
