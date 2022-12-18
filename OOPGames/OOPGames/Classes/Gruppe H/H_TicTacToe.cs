using OOPGames;
using OOPGames.Interfaces.Gruppe_H;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OOPGames
{
    //########### PAINT #############//
    public class H_TicTacToePaint : I_H_PaintTicTacToe
    {
        public string Name { get { return "H Painter TicTacToe"; } }                        //die öffentliche Variable Name beinhaltet den Name des Painters. Bei einer get-Anfrage wird der Name zurückgegeben.

        bool ersterAufruf = false;                                                          //für die Farbmuster Auswahl, speichert ob schon einmal aufgerufen wurde
        int farbmuster;                                                                     //das zufällig ausgewählte Farbmuster wird gespeichert
        int d;

        public int D { get { return d; } }

        public void PaintGameField(Canvas canvas, IGameField currentField)                  //PaintGameField wird aufgerufen wenn das Spielfeld (neu) gezeichent werden soll. Wenn es sich bei dem zu zeichneneden Feld um eine Datei handelt, die auch das TicTacToe interface enthält (also tatsächlich ein TicTacToe Spiel ist) wird "PaintTicTacToeField" aufgerufen.
        {
            if (currentField is I_H_TicTacToe)
            {
                PaintTicTacToeField(canvas, (I_H_TicTacToe)currentField);
            }
        }

        //Feld zeichnen wurde von Griesbauer kopiert (farben "angepasst" :P)
        public void PaintTicTacToeField(Canvas canvas, I_H_TicTacToe currentField)        //zeichnet das Spielfeld.
        {
            canvas.Children.Clear();
            Color bgColor = Color.FromRgb(255, 255, 255);                                   //Variable Hintergrundfarbe
            Color lineColor = Color.FromRgb(0, 0, 0);                                       //Variable Linienfarbe Spielfeld
            Color XColor = Color.FromRgb(0, 255, 0);                                        //Variable Farbe X Spieler
            Color OColor = Color.FromRgb(0, 0, 255);                                        //Variable Farbe O Spieler                                                                                                                             

            //Zufällig auswählen von einem von vier Farbschemen. Jedes Mitglied der Gruppe legt ein eigenes Farbschema fest
            if (ersterAufruf == false)
            {
                Random zufall = new Random();                                               //Random Objekt namens zufall wird erstellt, die Funktion gibts vom System :D
                farbmuster = zufall.Next(1, 5);                                             //es wird zufällig ein Farbmuster festgelegt
                ersterAufruf = true;                                                        //Erster Aufruf ist erfolgt
            }

            switch (farbmuster)
            {
                case 1: //Farbschema Annalena                                               //Farbschema Annalena
                    bgColor = Color.FromRgb(177, 18, 37);                                   //Hintergrundfarbe
                    lineColor = Color.FromRgb(242, 211, 193);                               //Linienfarbe Spielfeld
                    XColor = Color.FromRgb(134, 113, 130);                                  //Farbe X Spieler
                    OColor = Color.FromRgb(211, 109, 61);                                   //Farbe O Spieler
                    break;

                case 2: //Farbschema Jan                                                    //Farbschema Jan
                    bgColor = Color.FromRgb(225, 255, 225);                                 //Hintergrundfarbe
                    lineColor = Color.FromRgb(0, 0, 0);                                     //Linienfarbe Spielfeld
                    XColor = Color.FromRgb(0, 255, 0);                                      //Farbe X Spieler
                    OColor = Color.FromRgb(0, 0, 255);                                      //Farbe O Spieler
                    break;

                case 3: //Farbschema Samuel                                                 //Farbschema Samuel
                    bgColor = Color.FromRgb(125, 30, 100);                                //Hintergrundfarbe
                    lineColor = Color.FromRgb(255, 100, 50);                                //Linienfarbe Spielfeld
                    XColor = Color.FromRgb(100, 255, 15);                                  //Farbe X Spieler
                    OColor = Color.FromRgb(255, 3, 150);                                    //Farbe O Spieler
                    break;

                case 4: //Farbschema Moritz                                                 //Farbschema Moritz
                    bgColor = Color.FromRgb(9, 0, 196);                                     //Hintergrundfarbe
                    lineColor = Color.FromRgb(255, 255, 255);                               //Linienfarbe Spielfeld
                    XColor = Color.FromRgb(0, 0, 0);                                        //Farbe X Spieler
                    OColor = Color.FromRgb(255, 0, 0);                                      //Farbe O Spieler
                    break;
            }

            canvas.Background = new SolidColorBrush(bgColor);
            Brush lineStroke = new SolidColorBrush(lineColor);
            Brush XStroke = new SolidColorBrush(XColor);
            Brush OStroke = new SolidColorBrush(OColor);

            //Zeichnen der Linien 
            // Spielfeldwerte (d = Abstand zwischen zwei Linien, X0 und Y0 ist der Eckpunkt oben links)
            int X0 = 100;
            int Y0 = 200;

            double dblWidth = 0;
            UIElement ctl = (UIElement)canvas;
            DependencyObject parent = VisualTreeHelper.GetParent(ctl);
            while (canvas as Canvas == null)
            {
                parent = VisualTreeHelper.GetParent(canvas);
            }

            if (parent != null)
            {
                dblWidth = ((Canvas)canvas).ActualWidth;
                d = (int)(dblWidth - 200) / 3;
            }

            //Textbeschriftungen

            //Headline
            TextBlock Headline = new TextBlock();
            Headline.Text = "TicTacToe";
            Headline.FontSize = d/3;    //80
            Headline.FontWeight = FontWeights.Medium;
            Canvas.SetTop(Headline, 5);
            Canvas.SetLeft(Headline, X0 + 0.8*d) ;      //(dblWidth / 2) - 250)
            canvas.Children.Add(Headline);


            //Player1
            TextBlock Player1 = new TextBlock();
            Player1.Text = "Player 1:";
            Player1.FontSize = d/4;     //60
            Canvas.SetTop(Player1, 80);
            Canvas.SetLeft(Player1, X0);          //((dblWidth / 2) - 1.5 * d)
            canvas.Children.Add(Player1);

            Image Player1Symbol = new Image();
            Player1Symbol.Source = new BitmapImage(new Uri("pack://application:,,,/OOPGames;component/Resources/Gruppe H/Player1.png"));
            Player1Symbol.Height = d / 3;      //60
            Player1Symbol.Width = d / 3;        //60

            Canvas.SetTop(Player1Symbol, 85);
            Canvas.SetLeft(Player1Symbol, X0 + d);            //(dblWidth / 2) - 1.5 * d + 250
            canvas.Children.Add(Player1Symbol);


            //Player2
            TextBlock Player2 = new TextBlock();
            Player2.Text = "Player 2:";
            Player2.FontSize = d/4;     //60
            Canvas.SetTop(Player2, 80);
            Canvas.SetLeft(Player2, X0 + 1.7*d);              //(dblWidth / 2) + 0.3 * d
            canvas.Children.Add(Player2);

            Image Player2Symbol = new Image();
            Player2Symbol.Source = new BitmapImage(new Uri("pack://application:,,,/OOPGames;component/Resources/Gruppe H/Player2.png"));
            Player2Symbol.Height = d / 3;      //60
            Player2Symbol.Width = d / 3;    //60

            Canvas.SetTop(Player2Symbol, 90);
            Canvas.SetLeft(Player2Symbol, X0 + 2.7*d);            //(dblWidth / 2) + 0.3 * d + 200
            canvas.Children.Add(Player2Symbol);

            //Spielfeldlinien

            //Vertikal
            Line l1 = new Line() { X1 = X0 + d, Y1 = Y0, X2 = X0 + d, Y2 = Y0 + (3 * d), Stroke = lineStroke, StrokeThickness = 3.0 };
            canvas.Children.Add(l1);
            Line l2 = new Line() { X1 = X0 + (2 * d), Y1 = Y0, X2 = X0 + (2 * d), Y2 = Y0 + (3 * d), Stroke = lineStroke, StrokeThickness = 3.0 };
            canvas.Children.Add(l2);
            //Horizontal
            Line l3 = new Line() { X1 = X0, Y1 = Y0 + d, X2 = X0 + (3 * d), Y2 = Y0 + d, Stroke = lineStroke, StrokeThickness = 3.0 };
            canvas.Children.Add(l3);
            Line l4 = new Line() { X1 = X0, Y1 = Y0 + (2 * d), X2 = X0 + (3 * d), Y2 = Y0 + (2 * d), Stroke = lineStroke, StrokeThickness = 3.0 };
            canvas.Children.Add(l4);

            //Rahmen
            //oben
            Line l6 = new Line() { X1 = X0, Y1 = Y0, X2 = X0 + (3 * d), Y2 = Y0, Stroke = lineStroke, StrokeThickness = 3.0 };
            canvas.Children.Add(l6);
            //unten
            Line l5 = new Line() { X1 = X0, Y1 = Y0 + (3 * d), X2 = X0 + (3 * d), Y2 = Y0 + (3 * d), Stroke = lineStroke, StrokeThickness = 3.0 };
            canvas.Children.Add(l5);
            //links
            Line l7 = new Line() { X1 = X0, Y1 = Y0, X2 = X0, Y2 = Y0 + (3 * d), Stroke = lineStroke, StrokeThickness = 3.0 };
            canvas.Children.Add(l7);
            //rechts
            Line l8 = new Line() { X1 = X0 + (3 * d), Y1 = Y0, X2 = X0 + (3 * d), Y2 = Y0 + (3 * d), Stroke = lineStroke, StrokeThickness = 3.0 };
            canvas.Children.Add(l8);

            //Zeichnen der Kreuze und Kreise der Spieler
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    I_H_Feld current = null;
                    if (currentField is I_H_TicTacToe)
                    {
                        current = ((I_H_TicTacToe)currentField).GetFeldAt(i, j);
                        if (current.Player == 1 || current.Player == 2)
                        {
                            int X = X0 + (j * d);
                            int Y = Y0 + (i * d);

                            current.Symbol.Height = d;
                            current.Symbol.Width = d;

                            Canvas.SetTop(current.Symbol, Y);
                            Canvas.SetLeft(current.Symbol, X);
                            canvas.Children.Add(current.Symbol);
                        }

                        /*else if (currentField[i, j] == 2)
                        {
                            int X = X0 + (i * d);
                            int Y = Y0 + (j * d);

                            current.Symbol.Height = d;
                            current.Symbol.Width = d;

                            Canvas.SetTop(current.Symbol, Y);
                            Canvas.SetLeft(current.Symbol, X);
                            canvas.Children.Add(current.Symbol);
                        }*/


                    }

                    else if (currentField[i, j] == 1)
                    {
                        Line X1 = new Line() { X1 = X0 + (j * d), Y1 = Y0 + (i * d), X2 = X0 + d + (j * d), Y2 = Y0 + d + (i * d), Stroke = XStroke, StrokeThickness = 3.0 };
                        canvas.Children.Add(X1);
                        Line X2 = new Line() { X1 = X0 + (j * d), Y1 = Y0 + d + (i * d), X2 = X0 + d + (j * d), Y2 = Y0 + (i * d), Stroke = XStroke, StrokeThickness = 3.0 };
                        canvas.Children.Add(X2);
                    }
                    else if (currentField[i, j] == 2)
                    {
                        Ellipse OE = new Ellipse() { Margin = new Thickness(X0 + (j * d), Y0 + (i * d), 0, 0), Width = d, Height = d, Stroke = OStroke, StrokeThickness = 3.0 };
                        canvas.Children.Add(OE);
                    }
                }
            }
        }
    }



    //########### MOVE #############//
    public class H_TicTacToeMove : I_H_TicTacToeMove
    {
        int _Row = 0;
        int _Column = 0;
        int _PlayerNumber = 0;

        public H_TicTacToeMove(int row, int column, int playerNumber)
        {
            _Row = row;
            _Column = column;
            _PlayerNumber = playerNumber;
        }

        public int Row { get { return _Row; } }
        public int Column { get { return _Column; } }
        public int PlayerNumber { get { return _PlayerNumber; } }
    }

    //############# FELD ##############//
    public class HFeld : I_H_Feld
    {
        //(Objekte für Schnecke/X/O sollen existieren ung bei Abfrage zurückgegeben werden.-->Falsch?)
        //Hier wird festgelegt, was der Painter zeichnen soll, es wird weg gegengen werden von dem Field mit 0/1/2 als Auswahl???
        int _player;
        Image _symbol;
        public int Player   // Auswertung welcher Player gerade den Move macht
        {
            get
            {
                return _player;
            }
            set
            {
                _player = value;
            }
        }
        public Image Symbol
        {
            get
            {
                return _symbol;
            }
            set
            {
                _symbol = value;
            }
        }
    }

    //############# FIELD ##############//
    public class H_TicTacToeField : I_H_TicTacToe
    {
        I_H_Feld[,] _Feld = new I_H_Feld[3, 3];                     //Leitet von kommentar darüber ab erstellt ein 3x3 Feld, das in jedem Feld IH Feld haben muss????
        public H_TicTacToeField()                               //in jedes Feld des 3x3Spielfelds wird HFeld eingefügt, darin sind dann alle Symbole der Spieler enthalten.?
        {
            int r, c;
            for (r = 0; r < 3; r++)
            {
                for (c = 0; c < 3; c++)
                {
                    _Feld[r, c] = new HFeld();
                }
            }
        }

        public I_H_Feld this[int r, int c]
        {
            get
            {
                if (r >= 0 && r < 3 && c >= 0 && c < 3)
                {
                    return _Feld[r, c];
                }
                else
                {
                    return null;
                }
            }
            set
            {
                if (r >= 0 && r < 3 && c >= 0 && c > 3)
                {
                    _Feld[r, c] = value;
                }
            }
        }

        int I_H_TicTacToe.this[int r, int c]
        {
            get
            {
                if (r >= 0 && r < 3 && c >= 0 && c < 3)
                {
                    return _Feld[r, c].Player;
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                if (r >= 0 && r < 3 && c >= 0 && c > 3)
                {
                    _Feld[r, c].Player = value;
                }
            }
        }

        public bool CanBePaintedBy(IPaintGame painter)
        {
            return painter is I_H_PaintTicTacToe;
        }

        I_H_Feld I_H_TicTacToe.GetFeldAt(int r, int c)
        {
            return _Feld[r, c];
        }
    }


    //############# RULES ##############//
    public class H_TicTacToeRules : I_H_TicTacToeRules
    {

        /* Allg. Infos zu Rules:
        * in den Feldern werden Spielernummern hinterlegt: Spielernummer 0 = Feld frei, 1 oder 2 = der jeweilige Spieler hat dort ein X oder O.
        * 
        * Spielfeld Aufbau: oben links ist 0,0; unten rechts 2,2; unten links ist 2,0; oben rechts ist 0,2
        */

        //erstellt die öffentliche Variable Name, diese wird vom Programmfenster ausgelesen und angezeigt
        public string Name { get { return "H_TicTacToe_Rules"; } }


        //ein neues Spielfeld wird erstellt, bzw. eine Instanz der Spielfeldklasse erzeugt. Das neue Spielfeld nennt sich "_Spielfeld".
        H_TicTacToeField _Spielfeld = new H_TicTacToeField();
        bool firstMoveDone = false;                                       //Variable die erfasst ob der erste Zug bereits gemacht wurde.
        int rowAbweichung;                                                      //Variabeln die die Abweichung für die Spezialregeln erfassen.
        int columnAbweichung;
        public int RowAbweichung { get { return (rowAbweichung); } }
        public int ColumnAbweichung { get { return (columnAbweichung); } }
        public I_H_TicTacToe TicTacToeField { get { return _Spielfeld; } }      //gibt beim Aufruf das aktuelle (erstellte) Spielfeld zurück. Wurde im gegensatz zum Griesbauer Beispiel _Spielfeld statt _Field genannt.

        int d;
        public int D { set { d = value; } }

        //Es wird überprüft, ob der Spieler innerhalb des Spielfeldes (3 breit, 3 hoch) geklickt hat, wenn Ja wird dem _Spielfeld der die Feldnummern und die Spielernummer übergeben
        public void DoTicTacToeMove(I_H_TicTacToeMove spielerZug)               //move wird übergeben, hier SpielerZug genannt für besseres verständnis
        {
            if (spielerZug.Column <= 3 && spielerZug.Column >= 0 && spielerZug.Row <= 3 && spielerZug.Row >= 0)
            {
                _Spielfeld[spielerZug.Row, spielerZug.Column].Player = spielerZug.PlayerNumber;
            }
        }


        //Leert beim Aufruf das aktuelle Spielfeld.
        //Alle Spielfelder werden nacheinander aufgerufen und der Wert 0 als Spielernummer (PlayerNumber) eingetragen.
        public void ClearField()
        {
            for (int row = 0; row <= 2; row++)
            {
                for (int column = 0; column <= 2; column++)
                {
                    _Spielfeld[row, column].Player = 0;
                    _Spielfeld[row, column].Symbol = null;

                    firstMoveDone = false;                                //Zähler für erste Bewegung wird auf null gesetzt
                }
            }
        }


        //Funktion wird aufgerufen um zu prüfen, ob jemand gewonnen hat. --> Tippfehler in IGameRules PLayer wenn Player geschrieben wird, wird Implementierung nicht erkannt.
        public int CheckIfPLayerWon()
        {
            for (int i = 0; i <= 2; i++)                                                                                                                                                           //Überprüfung ob im ersten Feld der 3 Reihen ein Spieler gesetzt hat (Spieler > 0) und ob immer derselbe Spieler in eine der drei Reihen gesetzt hat. Gibt ggf. den Spieler zurück.
            {
                if (_Spielfeld[0, i].Player > 0 && _Spielfeld[0, i].Player == _Spielfeld[1, i].Player && _Spielfeld[0, i].Player == _Spielfeld[2, i].Player) { return (_Spielfeld[0, i].Player); }
            }
            for (int i = 0; i <= 2; i++)                                                                                                                                                           //Überprüfung der drei Spalten, ggf. Rückgabe des Spielers.
            {
                if (_Spielfeld[i, 0].Player > 0 && _Spielfeld[i, 0].Player == _Spielfeld[i, 1].Player && _Spielfeld[i, 0].Player == _Spielfeld[i, 2].Player) { return (_Spielfeld[i, 0].Player); }
            }
            if (_Spielfeld[0, 0].Player > 0 && _Spielfeld[0, 0].Player == _Spielfeld[1, 1].Player && _Spielfeld[0, 0].Player == _Spielfeld[2, 2].Player) { return (_Spielfeld[0, 0].Player); }     //Überprüfung der beiden Diagonalen, ggf. Rückgabe des Spielers.
            if (_Spielfeld[0, 2].Player > 0 && _Spielfeld[0, 2].Player == _Spielfeld[1, 1].Player && _Spielfeld[0, 2].Player == _Spielfeld[2, 0].Player) { return (_Spielfeld[0, 2].Player); }

            return (-1);                                                                                                                                                                           //Wenn bis hierher kein Return genutzt wurde, hat noch keiner gewonnen. Es wird -1 übergeben. (Siehe Interface, kein gewinner = -1)
        }

        //Übergibt das aktuelle Spielfeld (Klasse TicTacToe Field) an IGameField.
        public IGameField CurrentField { get { return _Spielfeld; } }

        //Soll prüfen, ob noch Bewegungen möglich sind
        //überprüft alle Felder ob eines noch den Spielerwert 0 hat, wenn ja kann dort noch gesetzt werden --> true wird zurückgegeben. Wenn keines leer ist --> false.
        public bool MovesPossible
        {
            get                                                                                     //get, weil in den IGameRules von denen abgeleitet wird, ist das als get deffiniert --> soll nur gelesen werden können? Außerdem das Programm schimpft sont???
            {
                for (int r = 0; r <= 2; r++)
                {
                    for (int c = 0; c <= 2; c++)
                    {
                        if (_Spielfeld[r, c].Player == 0) { return true; }
                    }
                }
                return false;
            }
        }

        //Bild setzen
        public void DoMove(IPlayMove move)
        {
            if (move is I_H_TicTacToeMove)                                                          //überprüft ob auch wirklich ein TicTacToe Move gemacht wurde und ITicTacToe Move implementiert (aus Griesbauer BaseTicTacToe)
            {
                if (firstMoveDone == false)
                {
                    firstMoveDone = true;                                                           //Erster Move wurde gemacht, Variable wird auf true gesetzt
                    firstMove((I_H_TicTacToeMove)move);                                             //ruft Objekt first Move auf, Klammer Inhalt ven Griesbauer, was tut er genau??? --> scheint die Werte das aktuellen moves (angekliktes Feld?) zu übergeben??
                }
                else                                                                                //firstMoveDone ist true, bedeutet das ist der zweite Move und die spezial regeln gelten.
                {
                    secondMove((I_H_TicTacToeMove)move);                                           //ruft Objekt newRuleMove auf
                }
            }
        }

        //der erste Spielzug, es wird zufällig ein Feld gewählt
        public void firstMove(I_H_TicTacToeMove move)
        {
            if (move.Row >= 0 && move.Row < 3 && move.Column >= 0 && move.Column < 3)
            {
                Random rnd = new Random();                                              //Random Objekt namens rnd wird erstellt, die Funktion gibts vom System :D
                int rowRnd = rnd.Next(0, 3);                                            //mit dem .Next ding lässt sich festlegen in welchem Bereich die Zahlen sin bewegen sollen (hier von =0 bis <3). --> die zufallszahlen werden als Koordinaten an das Spielfeld übergeben.
                int columnRnd = rnd.Next(0, 3);
                _Spielfeld[rowRnd, columnRnd].Player = move.PlayerNumber;

                rowAbweichung = rowRnd - move.Row;                                      //soll die Abweichung berechnen und an die Abweichungs Variablen übergeben.
                columnAbweichung = columnRnd - move.Column;

                if (move.PlayerNumber == 1)
                {
                    Image Player1 = new Image();
                    Player1.Source = new BitmapImage(new Uri("pack://application:,,,/OOPGames;component/Resources/Gruppe H/Player1.png"));
                    Player1.Height = d; //150
                    Player1.Width = d; // 150

                    _Spielfeld[rowRnd, columnRnd].Symbol = Player1;
                }
                else
                {
                    Image Player2 = new Image();
                    Player2.Source = new BitmapImage(new Uri("pack://application:,,,/OOPGames;component/Resources/Gruppe H/Player2.png"));
                    Player2.Height = d; //150
                    Player2.Width = d;  //150

                    _Spielfeld[rowRnd, columnRnd].Symbol = Player2;
                }
            }
        }

        //ab dem zweiten Spielzug, es sollte die Regel vom ersten erfasst und übernommen werden.
        public void secondMove(I_H_TicTacToeMove move)
        {
            if (move.Row >= 0 && move.Row < 3 && move.Column >= 0 && move.Column < 3)    //erste Zeile von Griesbauer, überprüft ob der move innerhalb des 3x3 Feldes war.
            {
                int rowNew = abweichung(move.Row, rowAbweichung);                        //berechnet Abweichendes Spielfeld mithilfe der Abweichung die im ersten Zug festgelegt wurde.
                int columnNew = abweichung(move.Column, columnAbweichung);

                _Spielfeld[rowNew, columnNew].Player = move.PlayerNumber;                //übergibt die an die Regeln angepassten Koordinaten an das Spielfeld, zusammen mit der Spieler Nummer.

                if (move.PlayerNumber == 1)
                {
                    Image Player1 = new Image();
                    Player1.Source = new BitmapImage(new Uri("pack://application:,,,/OOPGames;component/Resources/Gruppe H/Player1.png"));
                    Player1.Height = d; //150
                    Player1.Width = d;  //150

                    _Spielfeld[rowNew, columnNew].Symbol = Player1;
                }
                else
                {
                    Image Player2 = new Image();
                    Player2.Source = new BitmapImage(new Uri("pack://application:,,,/OOPGames;component/Resources/Gruppe H/Player2.png"));
                    Player2.Height = d; //150
                    Player2.Width = d;  //150

                    _Spielfeld[rowNew, columnNew].Symbol = Player2;
                }
            }
        }

        //berechnung der abweichenden Koordinate. Abweichung und original Koordinate müssen übergeben werden.
        public int abweichung(int koordinate, int abw)
        {
            int kNew = koordinate + abw;                                                //soll abweichung addieren
            if (kNew < 0) { kNew = kNew + 3; }                                          //stellt fest, ob das neue Feld außerhalb vom Spielfeld ist und passt an, damit das Kreuz auf der anderen Seite entsteht.
            if (kNew > 2) { kNew = kNew - 3; }
            return (kNew);
        }
    }


    //############## PLAYER ################//

    //HUMAN PLAYER

    public class H_TicTacToeHumanPlayer : I_H_HumanTicTacToePlayer
    {
        int _PlayerNumber = 0;
        public string Name { get { return "H_TicTacToeHumanPlayer"; } }
        public int PlayerNumber { get { return _PlayerNumber; } }

        int _rowAbweichung;                                                                         //speichern die Abweichung, des aktuellen Spiels, diese bekommen sie über das MainWindow von den Rules
        int _columnAbweichung;
        public int RowAbweichung { set { _rowAbweichung = value; } }
        public int ColumnAbweichung { set { _columnAbweichung = value; } }

        int d;
        public int D { set { d = value; } }

        public I_H_TicTacToeMove GetMove(IMoveSelection selection, I_H_TicTacToe field)
        {
            int X0 = 100;                                                                           //X0;Y0 Linke obere Ecke des Feldes
            int Y0 = 200;

            if (selection is IClickSelection)
            {
                IClickSelection sel = (IClickSelection)selection;                                   //Abfrage aller Felder, ob der Klick innerhalb der Koordinaten des jeweiligen Feldes stattfand
                for (int i = 0; i < 3; i++)                                                         //und ob das jeweilige Feld leer ist. Wenn Ja wird das jeweilige Feld auf die aktuelle Spielernummer gesetzt.
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (sel.XClickPos > X0 + (j * d) && sel.XClickPos < X0 + d + (j * d) &&
                           sel.YClickPos > Y0 + (i * d) && sel.YClickPos < Y0 + d + (i * d))
                        {
                            I_H_TicTacToeRules regel = new H_TicTacToeRules();                      //Abweichung nach Spezialregeln gruppe H wird berechnet, hierfür wird die abweichungs Methode der H_Rules verwendet
                            int abwR = regel.abweichung(i, _rowAbweichung);
                            int abwC = regel.abweichung(j, _columnAbweichung);

                            I_H_Feld _spielfeld = field.GetFeldAt(abwR, abwC);                      //überprüfen ob an den Koordinaten bereits gesetzt wurde
                            if (_spielfeld.Player <= 0)
                            {
                                return new H_TicTacToeMove(i, j, _PlayerNumber);
                            }
                        }
                    }
                }
            }
            return null;
        }

        public IGamePlayer Clone()
        {
            H_TicTacToeHumanPlayer ttthp = new H_TicTacToeHumanPlayer();
            ttthp.SetPlayerNumber(_PlayerNumber);
            return ttthp;
        }

        public void SetPlayerNumber(int playerNumber)
        {
            _PlayerNumber = playerNumber;
        }

        public IPlayMove GetMove(IMoveSelection selection, IGameField field)
        {
            if (field is I_H_TicTacToe)
            {
                return GetMove(selection, (I_H_TicTacToe)field);
            }
            else
            {
                return null;
            }
        }

        public bool CanBeRuledBy(IGameRules rules)
        {
            return rules is I_H_TicTacToeRules;
        }
    }


    //COMPUTER PLAYER

    public class H_TicTacToeComputerPlayer : BaseComputerTicTacToePlayer
    {
        int _PlayerNumber = 0;
        public override string Name { get { return "H_TicTacToeComputerPlayer"; } }
        public override int PlayerNumber { get { return _PlayerNumber; } }

        public override IGamePlayer Clone()
        {
            H_TicTacToeComputerPlayer ttthp = new H_TicTacToeComputerPlayer();
            ttthp.SetPlayerNumber(_PlayerNumber);
            return ttthp;
        }

        public override ITicTacToeMove GetMove(ITicTacToeField field)
        {
            int r = 0; //row
            int c = 0; //column

            //Nummeriert die Felder von 1 bis 9
            for (int i = 1; i <= 9; i++)
            {
                for (r = 0; r <= 2; r++)
                {
                    for (c = 0; c <= 2; c++)
                    {
                        int fieldi = field[r, c];
                    }
                }
            }                           //Setzt Kreis immer links oben und danach immer eins nach rechts
            for (r = 0; r <= 2; r++)
            {
                for (c = 0; c <= 2; c++)
                {
                    if (field[r, c] <= 0)
                    {
                        return new TicTacToeMove(r, c, _PlayerNumber);
                    }
                }
            }                       // Woher weiß ich von wem das Kästchen besetzt ist? Beide haben die Zahl 0?       --> Field[r,c] =0-->Feld leer; =1-->Spieler 1; =2-->Spieler 2      :D
            return null;
        }
        public override void SetPlayerNumber(int playerNumber)
        {
            _PlayerNumber = playerNumber;
        }
    }



}