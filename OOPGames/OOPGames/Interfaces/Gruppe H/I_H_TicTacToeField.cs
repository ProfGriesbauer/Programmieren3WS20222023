using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPGames.Interfaces.Gruppe_H
{
    public interface IHCasket
    {
        //Soll vorgeben, dass es ein Schnecken, ein X und ein O Objekt (Symbol/Grafik/etc.) geben soll. (und get/set können?)
    }

    public class HCasket : IHCasket
    {
        //(Objekte für Schnecke/X/O sollen existieren ung bei Abfrage zurückgegeben werden.-->Falsch?)
        //Hier wird festgelegt, was der Painter zeichnen soll, es wird weg gegengen werden von dem Field mit 0/1/2 als Auswahl???
    }

    public interface I_H_TicTacToeField : ITicTacToeField
    {
        IHCasket GetCasketAt(int r, int c);     //wenn davon abgeleitet wird, dann muss eine Funktion names GetCasketAt implementiert sein, die das Symbol von IHCasket an den entsprechen Koordinaten bekommt.
    }

    public class H_TicTacToeField : I_H_TicTacToeField
    {
        IHCasket[,] _Field = new IHCasket[3, 3]; //Leitet von kommentar darüber ab erstellt ein 3x3 Feld, das in jedem Feld IHCaskethaben muss????

        public H_TicTacToeField()               //in jedes Feld des 3x3Spielfelds wird HCasket eingefügt, darin sind dann alle Symbole der Spieler enthalten.?
        {
            _Field[0, 0] = new HCasket();

            _Field[1, 1] = new HCasket();

        }

        public int this[int r, int c] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public bool CanBePaintedBy(IPaintGame painter)
        {
            throw new NotImplementedException();
        }

        public IHCasket GetCasketAt(int r, int c)
        {
            throw new NotImplementedException();
        }
    }
}
