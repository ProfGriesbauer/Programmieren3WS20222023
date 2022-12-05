using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace OOPGames.Interfaces.Gruppe_E
{
    public interface I_E_PaintVierGewinnt : IPaintGame
    {
        void PaintVierGewinntField(Canvas canvas, I_E_VierGewinntField currentField);
    }
    public interface I_E_VierGewinntField : IGameField
    {
        int this[int r, int c] { get; set; }

    }

    public interface I_E_VierGewinntRules : IGameRules
    {
        I_E_VierGewinntField VierGewinntField { get; }
        void DoVierGewinntMove(I_E_VierGewinntMove move);
    }
    
    
    public interface I_E_VierGewinntMove : IRowMove, IColumnMove
    {

    }
}
