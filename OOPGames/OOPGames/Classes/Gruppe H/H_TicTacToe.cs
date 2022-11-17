using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OOPGames
{
    // 1. KLassen anlegen 
    // Feld malen 
    // BaseTicTacToe anlegen
    //public interface IPaintTicTacToe:

    //TicTacToe Painter selbst implementiert
    public class H_TicTacToePaint : IPaintTicTacToe                                      //HTicTacToe leitet von der Interface Klasse IPaintTicTacToe ab
    {
        public string Name { get { return "H Painter TicTacToe"; } }                    //die öffentliche Variable Name beinhaltet den Name des Painters. Bei einer get-Anfrage wird der Name zurückgegeben.
        public void PaintGameField(Canvas canvas, IGameField currentField)              //PaintGameField wird aufgerufen wenn das Spielfeld (neu) gezeichent werden soll. Wenn es sich bei dem zu zeichneneden Feld um eine Datei handelt, die auch das TicTacToe interface enthält (also tatsächlich ein TicTacToe Spiel ist) wird "PaintTicTacToeField" aufgerufen.
        {
            if (currentField is ITicTacToeField)
            {
                PaintTicTacToeField(canvas, (ITicTacToeField)currentField);
            }
        }

        //Field zeichnen wurde von Griesbauer kopiert (farben "angepasst" :P)
        public void PaintTicTacToeField(Canvas canvas, ITicTacToeField currentField)    //zeichnet dann tatsächlich das Spielfeld.
        {
            canvas.Children.Clear();
            Color bgColor = Color.FromRgb(9, 0, 196);                               //Hintergrundfarbe
            canvas.Background = new SolidColorBrush(bgColor);
            Color lineColor = Color.FromRgb(255, 255, 255);                         //Linienfarbe Spielfeld
            Brush lineStroke = new SolidColorBrush(lineColor);
            Color XColor = Color.FromRgb(0, 0, 0);                                  //Farbe X Spieler
            Brush XStroke = new SolidColorBrush(XColor);
            Color OColor = Color.FromRgb(255, 0, 0);                                //Farbe O Spieler
            Brush OStroke = new SolidColorBrush(OColor);

            Line l1 = new Line() { X1 = 120, Y1 = 20, X2 = 120, Y2 = 320, Stroke = lineStroke, StrokeThickness = 3.0 };
            canvas.Children.Add(l1);
            Line l2 = new Line() { X1 = 220, Y1 = 20, X2 = 220, Y2 = 320, Stroke = lineStroke, StrokeThickness = 3.0 };
            canvas.Children.Add(l2);
            Line l3 = new Line() { X1 = 20, Y1 = 120, X2 = 320, Y2 = 120, Stroke = lineStroke, StrokeThickness = 3.0 };
            canvas.Children.Add(l3);
            Line l4 = new Line() { X1 = 20, Y1 = 220, X2 = 320, Y2 = 220, Stroke = lineStroke, StrokeThickness = 3.0 };
            canvas.Children.Add(l4);
            Line l5 = new Line() { X1 = 20, Y1 = 320, X2 = 320, Y2 = 320, Stroke = lineStroke, StrokeThickness = 3.0 };
            canvas.Children.Add(l5);
            Line l6 = new Line() { X1 = 20, Y1 = 20, X2 = 320, Y2 = 20, Stroke = lineStroke, StrokeThickness = 3.0 };
            canvas.Children.Add(l6);
            Line l7 = new Line() { X1 = 20, Y1 = 320, X2 = 20, Y2 = 20, Stroke = lineStroke, StrokeThickness = 3.0 };
            canvas.Children.Add(l7);
            Line l8 = new Line() { X1 = 320, Y1 = 320, X2 = 320, Y2 = 20, Stroke = lineStroke, StrokeThickness = 3.0 };
            canvas.Children.Add(l8);

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (currentField[i, j] == 1)
                    {
                        Line X1 = new Line() { X1 = 20 + (j * 100), Y1 = 20 + (i * 100), X2 = 120 + (j * 100), Y2 = 120 + (i * 100), Stroke = XStroke, StrokeThickness = 3.0 };
                        canvas.Children.Add(X1);
                        Line X2 = new Line() { X1 = 20 + (j * 100), Y1 = 120 + (i * 100), X2 = 120 + (j * 100), Y2 = 20 + (i * 100), Stroke = XStroke, StrokeThickness = 3.0 };
                        canvas.Children.Add(X2);
                    }
                    else if (currentField[i, j] == 2)
                    {
                        Ellipse OE = new Ellipse() { Margin = new Thickness(20 + (j * 100), 20 + (i * 100), 0, 0), Width = 100, Height = 100, Stroke = OStroke, StrokeThickness = 3.0 };
                        canvas.Children.Add(OE);
                    }
                }
            }
        }
    }


    //Hier kommen unsere Fancy Regeln hin :D
    /*public class H_TicTacToeRules : ITicTacToeRules
    {

    }*/

    /* Allg. Infos zu Rules:
     * in den Feldern werden Spielernummern hinterlegt: Spielernummer 0= Feld frei, 1 oder 2 = der jeweilige Spieler hat dort ein X oder O.
     * 
     * Spielfeld AUfbau: oben links ist 0,0; unten rechts 2,2; unten links ist 2,0; oben rechts ist 0,2; der rest sollte sich erklären wenn man es aufzeichnet.
     */


    //Moritz Vorschlag:
    /*Probleme:
     * Gleichstand wird noch nicht erkannt.
     * Spezialregel wird erst beim 2.Spiel angewendet, vermutlich weil da zum ersten mal 'specialRuleMoveDone = false' gemacht wird --> Problem hat sich gerade von selbst behoben??
     * auf ein belegtes feld kann nicht geklickt werden, auch wenn die Spezialregel auf ein freies setzen würde. 
     * --> Im Player wird überprüft ob das Feld frei ist, es muss ein Player erzeugt werden, der diesbezüglich angepasst ist.
     * --> Aktuell kann ein bestehendes Feld mit der spezialregel überschrieben werden.
    */
    public class H_TicTacToeRules : ITicTacToeRules
    {
        //ein neues Spielfeld wird erstellt, bzw. eine Instanz der Spielfeldklasse erzeugt. Das neue Spielfeld nennt sich "_Spielfeld".
        TicTacToeField _Spielfeld = new TicTacToeField();
        bool specialRuleMoveDone = false;                                       //Variable die erfasst ob der erste Zug bereits gemacht wurde.
        int rowAbweichung;                                                      //Variabeln die die Abweichung für die Spezialregeln erfassen.
        int columnAbweichung;
        public ITicTacToeField TicTacToeField { get { return _Spielfeld; } }    //gibt beim Aufruf das aktuelle (erstellte) Spielfeld zurück. Wurde im gegensatz zum Griesbauer Beispiel _Spielfeld statt _Field genannt.


        //Es wird überprüft, ob der Spieler innerhalb des Spielfeldes (3 breit, 3 hoch) geklickt hat, wenn Ja wird dem _Spielfeld der die Feldnummern und die Spielernummer übergeben
        public void DoTicTacToeMove(ITicTacToeMove spielerZug) //move wird übergeben, hier SpielerZug genannt für besseres verständnis
        {
            if (spielerZug.Column <= 3 && spielerZug.Column >= 0 && spielerZug.Row <= 3 && spielerZug.Row >= 0)
            {
                _Spielfeld[spielerZug.Row, spielerZug.Column] = spielerZug.PlayerNumber;
            }
        }


        //Leert beim Aufruf das aktuelle Spielfeld.
        //Alle Spielfelder werden nacheinander aufgerufen und der Wert 0 als Spielernummer (PlayerNumber) eingetragen.
        public void ClearField()
        {
            for(int row = 0; row <= 2; row++)
            {
                for(int column = 0; column <= 2; column++)
                {
                    _Spielfeld[row, column] = 0;
                    specialRuleMoveDone = false;                //zähler für erste Bewegung wird auf null gesetzt
                }
            }
        }


        //Funktion wird aufgerufen um zu prüfen, ob jemand gewonnen hat. --> Tippfehler in IGameRules PLayer wenn Player geschrieben wird, wird Implementierung nicht erkannt.
        public int CheckIfPLayerWon()
        {
            for (int i = 0; i <= 2; i++)                                                                                                            //Überprüfung ob im ersten Feld der 3 Reihen ein Spieler gesetzt hat (Spieler > 0) und ob immer derselbe Spieler in eine der drei Reihen gesetzt hat. Gibt ggf. den Spieler zurück.
            {
                if (_Spielfeld[0, i] > 0 && _Spielfeld[0, i] == _Spielfeld[1, i] && _Spielfeld[0, i] == _Spielfeld[2, i]) { return (_Spielfeld[0, i]); }
            }
            for (int i = 0; i <= 2; i++)                                                                                                            //Überprüfung der drei Spalten, ggf. Rückgabe des Spielers.
            {
                if (_Spielfeld[i, 0] > 0 && _Spielfeld[i, 0] == _Spielfeld[i, 1] && _Spielfeld[i, 0] == _Spielfeld[i, 2]) { return (_Spielfeld[i, 0]); }
            }
            if (_Spielfeld[0, 0] > 0 && _Spielfeld[0, 0] == _Spielfeld[1, 1] && _Spielfeld[0, 0] == _Spielfeld[2, 2]) { return (_Spielfeld[0, 0]); }     //Überprüfung der beiden Diagonalen, ggf. Rückgabe des Spielers.
            if (_Spielfeld[0, 2] > 0 && _Spielfeld[0, 2] == _Spielfeld[1, 1] && _Spielfeld[0, 2] == _Spielfeld[2, 0]) { return (_Spielfeld[0, 2]); }

            return (-1);                                                                                                                           //Wenn bis hierher kein Return genutzt wurde, hat noch keiner gewonnen. Es wird -1 übergeben. (Siehe Interface, kein gewinner = -1)
        }
        

        //erstellt die öffentliche Variable Name, diese wird (mit etwas Glück) vom Programmfenster ausgelesen und angezeigt
        public string Name { get { return "H_TicTacToe_Rules_M"; } }


        //Übergibt das aktuelle Spielfeld (Klasse TicTacToe Field) an IGameField.
        //Was das dann macht und wie das genau funktioniert: ???  ; Implemntierung in Griesbauer BaseTicTacToe und TicTacToe abgeguckt und zwischenschritt in Basisklasse rausgekürzt oder so ?
        public IGameField CurrentField { get { return _Spielfeld; } }


        //Soll prüfen, ob noch Bewegungen möglich sind
        //überprüft alle Felder ob eines noch den Spielerwert 0 hat, wenn ja kann dort noch gesetzt werden --> true wird zurückgegeben. Wenn keines leer ist, false.
        public bool MovesPossible
        {
            get                                                         //get, weil in den IGameRules von denen abgeleitet wird, ist das als get deffiniert --> soll nur gelesen werden können? Außerdem das Programm schimpft sont???
            {
                for (int r = 0; r <= 2; r++)
                {
                    for (int c = 0; c <= 2; c++)
                    {
                        if (_Spielfeld[r, c] == 0) { return true; }
                    }
                }
                return false;
            }
        }


        public void DoMove(IPlayMove move)                              //so gibts keine Fehlermeldung mehr nur ist das jetzt richtig und was genau habe ich gemacht???
        {
            if (move is ITicTacToeMove)                                                         //überprüft ob auch wirklich ein TicTacToe Move gemacht wurde und ITicTacToe Move implementiert (aus Griesbauer BaseTicTacToe)
            {
                if (specialRuleMoveDone == false)
                {
                    specialRuleMoveDone = true;                                                 //Erster Move wurde gemacht, Variable wird auf true gesetzt
                    firstMove((ITicTacToeMove) move);                                           //ruft Objekt first Move auf, Klammer Inhalt ven Griesbauer, was tut er genau??? --> scheint die Werte das aktuellen moves (angekliktes Feld?) zu übergeben??
                }
                else                                                                            //specialRuleMoveDone ist true, bedeutet das ist der zweite Move und die spezial regeln gelten.
                {
                    newRuleMove((ITicTacToeMove)move);                                          //ruft Objekt newRuleMove auf
                }
            }
        }

        //der erste Spielzug, es wird zufällig ein Feld gewählt
        public void firstMove(ITicTacToeMove move)
        {
            if (move.Row >= 0 && move.Row < 3 && move.Column >= 0 && move.Column < 3)   //erste Zeile von Griesbauer
            {
                Random rnd = new Random();                                              //Random Objekt namens rnd wird erstellt, die Funktion gibts vom System :D
                int rowRnd = rnd.Next(0, 3);                                            //mit dem .Next ding lässt sich festlegen in welchem Bereich die Zahlen sin bewegen sollen (hier von =0 bis <3). --> die zufallszahlen werden als Koordinaten an das Spielfeld übergeben.
                int columnRnd = rnd.Next(0, 3);
                _Spielfeld[rowRnd, columnRnd] = move.PlayerNumber;

                rowAbweichung = rowRnd - move.Row;                                      //soll die Abweichung berechnen und an die Abweichungs Variablen übergeben.
                columnAbweichung = columnRnd - move.Column;
            }
        }

        //ab dem zweiten Spielzug, es sollte die Regel vom ersten erfasst und übernommen werden.
        public void newRuleMove(ITicTacToeMove move)
        {
            if (move.Row >= 0 && move.Row < 3 && move.Column >= 0 && move.Column < 3)   //erste Zeile von Griesbauer
            {
                int rowNew = move.Row + rowAbweichung;                                  //soll abweichung addieren
                int columnNew = move.Column + columnAbweichung;
                
                if(rowNew < 0) { rowNew = rowNew + 3; }                                 //stellt fest, ob das neue Feld außerhalb vom Spielfeld ist und passt an, damit das Kreuz auf der anderen Seite entsteht.
                if(rowNew > 2) { rowNew = rowNew - 3; }
                if(columnNew < 0) { columnNew = columnNew + 3; }
                if(columnNew > 2) { columnNew = columnNew - 3; }

                _Spielfeld[rowNew, columnNew] = move.PlayerNumber;                      //übergibt die an die Regeln angepassten Koordinaten an das Spielfeld, zusammen mit der Spieler Nummer.
            }
        }


    }//*/
}
