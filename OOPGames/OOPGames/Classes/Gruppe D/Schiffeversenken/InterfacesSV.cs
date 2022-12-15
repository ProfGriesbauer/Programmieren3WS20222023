using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using OOPGames;

namespace OOPGames.Classes.Gruppe_D.Schiffeverseanken
{
    public interface IPaintSV : IPaintGame
    {
        void PaintShipField(Canvas canvas, IFieldSV currentField);
        void PaintShip(Canvas canvas, int Ship, int x, int y, int HorVer, int des);
    }
    public interface IFieldSV : IGameField
    {
        int this[int r, int c, int w] { get; set; } // w = which tabel he shoud use 1=P1location 2=p2location 3=p1shoot 4= p2shoot
        //p_location stores location of Ships with 1
        //p_shoot can return 0 for nothing; 1 for shot but nothing; 2 hit ship ; 
        int Phase { get; set; } //gibt Spielphase an; 1: P1 setzt, 2: P2 setzt, 3: beide Spieler schießen abwechselnd
        int FirstClick { get; set; }    //verhindert automatischen Klick bei Phasenwechsel
        int HorVer { get; set; } //gibt Zustand der Schiffe an: 1: Schiffe vertikal, 2:Schiffe horizontal

        int Ships(int w, int p); //w 1= Pop 2=peek
                                 //p 1= Player1 2= Player2
       
        void ResetShipStack();
       
    }
    public interface IRulerSV : IGameRules
    {
        void DoShipMove(ISVMove move);
        void RotateShip();
    }


  public interface IHumanSV : IHumanGamePlayer
    {
        ISVMove GetMove(IMoveSelection selection, IFieldSV field);
    }

    public interface ISVMove : IRowMove, IColumnMove
    {

    }



}





