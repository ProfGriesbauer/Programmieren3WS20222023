using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace OOPGames.Classes.Gruppe_C.Minesweeper
{
    public interface C_IPaintMinesweeper:IPaintGame
    {
        void PaintMinesweeperField(Canvas canvas, C_IMinesweeperField currentField);
    }
}
