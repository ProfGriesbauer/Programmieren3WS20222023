using OOPGames.Classes.Gruppe_K;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace OOPGames.Interfaces.Gruppe_K
{
    internal interface IK_PaintGameObject: IPaintGame, IPaintGame2
    {
        void PaintGameField(Canvas canvas, List<K_GameObject> data);
    }

}
