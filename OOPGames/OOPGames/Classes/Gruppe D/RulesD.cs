using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOPGames.Classes.Gruppe_D;

namespace OOPGames
{
    public class RulesD : ITicTacToeRules //Konkrete Klassen

    {
        TicTacToeField _KrassesFeld = new TicTacToeField();
        public string Name { get { return "DieKrassenRegeln"; } }

        public IGameField CurrentField { get { return _KrassesFeld; } }

        public bool MovesPossible
        {
            get
            {
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (_KrassesFeld[i, j] == 0)
                        {
                            return true;
                        }
                    }
                }
                return false;
            }
        }
        public ITicTacToeField TicTacToeField { get { return _KrassesFeld; } }

        public int CheckIfPLayerWon()
        {
            for (int i = 0; i < 3; i++)
            {
                if (_KrassesFeld[i, 0] == 1 && _KrassesFeld[i, 1] == 1 && _KrassesFeld[i, 2] == 1) { return 1; }
                if (_KrassesFeld[0, i] == 1 && _KrassesFeld[1, i] == 1 && _KrassesFeld[2, i] == 1) { return 1; }
                if (_KrassesFeld[i, 0] == 2 && _KrassesFeld[i, 1] == 2 && _KrassesFeld[i, 2] == 2) { return 2; }
                if (_KrassesFeld[0, i] == 2 && _KrassesFeld[1, i] == 2 && _KrassesFeld[2, i] == 2) { return 2; }
            }
            if (_KrassesFeld[0, 0] == 1 && _KrassesFeld[1, 1] == 1 && _KrassesFeld[2, 2] == 1) { return 1; }
            if (_KrassesFeld[2, 0] == 1 && _KrassesFeld[1, 1] == 1 && _KrassesFeld[0, 2] == 1) { return 1; }
            if (_KrassesFeld[0, 0] == 2 && _KrassesFeld[1, 1] == 2 && _KrassesFeld[2, 2] == 2) { return 2; }
            if (_KrassesFeld[2, 0] == 2 && _KrassesFeld[1, 1] == 2 && _KrassesFeld[0, 2] == 2) { return 2; }
            return -1;
        }
        public void ClearField()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    _KrassesFeld[i, j] = 0;
                }
            }
        }
        public void DoMove(IPlayMove move)
        {
            if (move is ITicTacToeMove)
            {
                DoTicTacToeMove((ITicTacToeMove)move);
            }

        }
        public void DoTicTacToeMove(ITicTacToeMove move)
        {
            if (move.Row >= 0 && move.Row < 3 && move.Column >= 0 && move.Column < 3)
            {
                _KrassesFeld[move.Row, move.Column] = move.PlayerNumber;
            }
        }
    }
}
/*
 * SCRUM
 * Eigenschaften
 * Empirisch:       Ausgehend von gemachten Erfahrungen wird der bestehende Prozess angepasst, adaptiert und geplant.
 * Inkrementell:    Die Entwicklung verläuft aufeinander aufbauend in abgeschlossenenTeilschritten.
 * Iterativ:        Durch das ständige Abarbeiten kleiner iterativer Schritte, die empirisch an die momentanen Gegebenheiten angepasst werden
 * 
 * Sprints
 * Transparenz; Überprüfung; 
 * Anpassung: anforderungen werden kontinuierlich angepasst
 * 
 * Versionsverwaltung
 * -Version: Stand einer Applikation zu einem bestimmten Zeitpunkt (x.x.x.x)
 * -Branch: Verzweigung in der Versionslinie
 * -Trunk: Hauptversionslinie -->bei Git Master
 * -Tag: ein bestimmter gekenzeichneter Versionsstand "für den Endkunden" --> Alles ergibt ein Respository
 *  
 * Git --> Verteilte Versionsverwaltung: 
 * Es gibt offiziell keine zentrale Stelle, die eine komplette Versionierung enthält
 * Lock Modify Write --> Beim Bearbeiten wird die Datei gesperrt
 * 
 * SVN --> Zentrale Versionsverwaltung: An einer zentralen Stelle, einem Server, wird die komplette Versionierung hinterlegt
 * Copy Modify Merge --> Mehre Benutzer können bearbeiten --> wird Lokal bearbeitet und dann gepusht
 * _______________________________________________________________________________________________________
 * Grundprinzipien von OOP
 * Einzigen Verantwortung --> Jedes Objekt hat seine eingen Aufgaben und geht nur dieser nach --> Painter(Zeichnet) Ruler(Regelt)
 * Trennung von Anliegen --> einer Zeichnet einer Speichert einer Regelt
 * Wiederholungen vermeiden
 * Open Closed Principle --> Für Erwiterunge offen aber nur so das das Objekt immer noch ohne änderungen Funktionsfähig ist
 * Trennung Schnittstelle Implementierung
 * Umkehr der Abhängigkeiten --> defeniere welchen Imput die Methode haben kann
 * Umkehr des Kontrollflusses --> Ruler ruft nicht Framwork mouseClick sonder mouseClick ruft ruler auf
 * Testbarkeit
 * 
 * Datenkapselung --> Daten sollen nicht direkt änderbar sein sonder nur durch Methoden
 * Polymorphie --> Objekte können vielseitige verwendet werden: Andere Hersteller selbe Fassung --> Implementierung
 * Vererbung(oben) --> verwenden von Interfaces / Schnittstellen 
 * _______________________________________________________________________________________________________
 * Objekte
 * Vorbedingungen: Aufrufer muss dafür sorgen das dass richtige kommt
 * Nachbedingung: das Objekt ist für das einhalten verantwortlich
 * 
 * Aggregation: Ein Objekt kann Teil von mehreren zusammengesetzten Objektensein.
 * Komposition: Ein Objekt kann nur Teil in genau einem zusammengesetzten Objektsein.
 * _______________________________________________________________________________________________________
 * Abstakte Klasse: Implementiert einen Teil der Methoden aber nicht alle
 * Demter-Prinzip: Sprich nur mit deinen Freunden --> Objekte rufen nur Methoden auf wenn die Objekte mit einander verbunden sind (erstellt, abgeleitet)
 *                                                    oder nur Parameterwerte übergeben werden sollen                           
 *_______________________________________________________________________________________________________
 *Singleton: Klassen, die sicherstellen, dass in jeder Anwendung höchstens eine Instanz dieser Klasse existieren kann und diese über eine
 *           statische Methode nach außen anbieten.
 */


