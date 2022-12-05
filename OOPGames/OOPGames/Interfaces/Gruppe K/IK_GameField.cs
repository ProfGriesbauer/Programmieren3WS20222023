using OOPGames.Classes.Gruppe_K;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPGames.Interfaces.Gruppe_K
{
    interface IK_GameField : IGameField
    {
        List<K_GameObject> Objects { get; set;}
        bool CanBePaintedBy(IPaintGame painter);
    }
}
