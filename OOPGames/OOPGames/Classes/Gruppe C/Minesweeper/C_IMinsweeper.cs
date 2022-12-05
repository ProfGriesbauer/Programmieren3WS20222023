using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace OOPGames.Classes.Gruppe_C.Minesweeper
{
    public interface C_IPaintMinesweeper : IPaintGame2
    {
        void PaintMinesweeperField(Canvas canvas, C_IMinesweeperField currentField);
        void TickPaintGameField(Canvas canvas, C_IMinesweeperField currentField);
    }

    public interface C_IMinesweeperField : IGameField
    {
        Segment this[Segment r,Segment c] { get; set; }
    }
    public interface C_IMinesweeperRules  : IGameRules
    {
        C_IMinesweeperField MinesweeperField { get; }

        void DoMinesweeperMove(C_IMinesweeperMove move);
    }
    public interface C_IMinesweeperMove: IRowMove, IColumnMove
    {

    }
    public interface C_IHumanMinesweeperPlayer : IHumanGamePlayer 
    {
        C_IMinesweeperField GetMove(IMoveSelection selection, C_IMinesweeperField field);
    }
    public interface C_IClickselection2 : IClickSelection
    {
        bool RightClick { get; set; }
        bool LeftClick { get; set; }
    }
    public class C_ClickSelection : ClickSelection, C_IClickselection2
    {
        public C_ClickSelection (int clickX, int clickY, bool butt) : base(clickX, clickY)
        {

        }
        public bool RightClick { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool LeftClick { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
