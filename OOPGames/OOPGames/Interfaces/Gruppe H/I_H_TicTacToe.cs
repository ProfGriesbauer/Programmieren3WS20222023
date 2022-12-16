using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Drawing;
using System.Windows.Forms;
using System.Windows;
using System.Runtime.InteropServices;
using System.Windows.Controls;

namespace OOPGames.Interfaces.Gruppe_H
{

    public interface IHFeld
    {
        //Soll vorgeben, dass es ein Schnecken, ein X und ein O Objekt (Symbol/Grafik/etc.) geben soll. (und get/set können?)
        int Player { get; set; }
        Image Symbol { get; set; }

    }



    public interface I_H_TicTacToe : IGameField
    {

        IHFeld GetFeldAt(int r, int c);     //wenn davon abgeleitet wird, dann muss eine Funktion names GetCasketAt implementiert sein, die das Symbol von IHCasket an den entsprechen Koordinaten bekommt.
        int this[int r, int c] { get; set; }

    }


    public interface I_H_PaintTicTacToe : IPaintGame
    {
        void PaintTicTacToeField(Canvas canvas, I_H_TicTacToe currentField);
        int D { get; }
  
        

    }


    public interface I_H_TicTacToeRules : IGameRules
    { 
        I_H_TicTacToe TicTacToeField { get; }

        void DoTicTacToeMove(I_H_TicTacToeMove move);
        int abweichung(int koordinate, int abw);
        int RowAbweichung { get; }
        int ColumnAbweichung { get; }
        void firstMove(I_H_TicTacToeMove move);
        void secondMove(I_H_TicTacToeMove move);
    
        int D { set; }
  
    }

    public interface I_H_HumanTicTacToePlayer : IHumanGamePlayer
    {
        I_H_TicTacToeMove GetMove(IMoveSelection selection, I_H_TicTacToe field);

        int RowAbweichung { set; }
        int ColumnAbweichung { set; }
        
        int D { set; }
    


    }

    public interface I_H_TicTacToeMove : IRowMove, IColumnMove
    { 
    }

    public interface I_H_PlayMove
    {
        int PlayerNumber { get; }
    }


    
}



