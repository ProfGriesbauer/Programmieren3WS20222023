﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace OOPGames.Classes.Gruppe_D.Schiffeverseanken
{
    public interface IPaintSV : IPaintGame
    {
        void PaintShipField(Canvas canvas, IGameField currentField, int GamePhase); 
    }
    public interface IFieldSV : IGameField
    {
        int this[int r, int c, int w] { get; set; } // w = which tabel he shoud use 1=P1location 2=p2location 3=p1shoot 4= p2shoot
        //p_location stores location of Ships with 1
        //p_shoot can return 0 for nothing; 1 for shot but nothing; 2 hit ship ; 

    }
    public interface IRulerSV : IGameRules
    {
        void DoShipMove(IShipMove move);
        void ChangePhase();
    }

    public interface IShipMove : IRowMove, IColumnMove
    {

    }
}


