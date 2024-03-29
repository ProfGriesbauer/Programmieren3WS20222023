﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Drawing;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using static OOPGames.TicTacToePaint_G;
using static OOPGames.TicTacToeField_G;
using static OOPGames.TicTacToeRules_G;
using System.Diagnostics;
using System.Drawing.Imaging;
using static OOPGames.MainWindow;
using Brush = System.Windows.Media.Brush;
using Color = System.Windows.Media.Color;
using ProgressBar = System.Windows.Controls.ProgressBar;
using Orientation = System.Windows.Controls.Orientation;
using TextBox = System.Windows.Controls.TextBox;
using Label = System.Windows.Forms.Label;
using Button = System.Windows.Forms.Button;
using OOPGames.Assets.G;
using System.Windows.Media.Animation;

namespace OOPGames
{
       //Interface ICasket für Classe Casket (Speilfeldeinheiten)
    public interface ICasket
    {
        int x { get; set; }
        int y { get; set; }
        int size { get; set; }
        bool flag { get; set; }
        bool keyFlag { get; set; }
        int player { get; set; }
        void paintFrame(Canvas canvas);
        void paintFill(Canvas canvas);
        Casket isMySpace(int x, int y);
    }

    // neues Interface: Erbt von ITicTacToeFeld, fügt aber noch die momentane Größe des Spielfelds hinzu...
    public interface ITicTacToeField_G : ITicTacToeField
    {
        int Fieldsize { get; set; }
        List<Casket> Field { get; }
        void increaseField();

    }

    //Klasse Casket (Spielfeldeinheit)
    //jedes Feld (ursprünglich Array) besteht aus einem Objekt
    public class Casket : ICasket
    {
        //Klassenmethode
        public Casket(Casket c)
        {
            this.x = c.x;
            this.y = c.y;
            this.size = c.size;
            this.flag = c.flag;
            this.player = c.player;
        }
        public Casket()
        { }

        int _x;
        int _y;
        int _size;
        bool _flag;
        bool _keyFlag;
        int _player;
        public int x
        {
            get { return _x; }

            set { _x = value; }
        }
        public int y
        {
            get { return _y; }

            set { _y = value; }
        }
        public int size
        {
            get { return _size; }

            set { _size = value; }
        }
        public bool flag
        {
            get { return _flag; }
            set { _flag = value; }
        }

        public bool keyFlag
        {
            get { return _keyFlag; }
            set { _keyFlag = value; }
        }
        public int player
        {
            get { return _player; }

            set { _player = value; }
        }

        //Zeichnet die Außenlinien des Felds
        public void paintFrame(Canvas canvas)
        {
            Color lineColor = Color.FromRgb(0, 0, 0);
            if (_keyFlag)
            {
                lineColor = Color.FromRgb(255, 0, 0);
            }

            Brush lineStroke = new SolidColorBrush(lineColor);

            //Obere Linie
            Line Up = new Line()
            {
                X1 = (_x) * _size,
                Y1 = (_y) * _size,
                X2 = (_x + 1) * _size,
                Y2 = (_y) * _size,
                Stroke = lineStroke,
                StrokeThickness = 3.0
            };
            canvas.Children.Add(Up);

            //Untere Linie
            Line Down = new Line()
            {
                X1 = (_x) * _size,
                Y1 = (_y + 1) * _size,
                X2 = (_x + 1) * _size,
                Y2 = (_y + 1) * _size,
                Stroke = lineStroke,
                StrokeThickness = 3.0
            };
            canvas.Children.Add(Down);

            //Linke Linie
            Line Left = new Line()
            {
                X1 = (_x) * _size,
                Y1 = (_y) * _size,
                X2 = (_x) * _size,
                Y2 = (_y + 1) * _size,
                Stroke = lineStroke,
                StrokeThickness = 3.0
            };
            canvas.Children.Add(Left);

            //Rechte Linie
            Line Right = new Line()
            {
                X1 = (_x + 1) * _size,
                Y1 = (_y) * _size,
                X2 = (_x + 1) * _size,
                Y2 = (_y + 1) * _size,
                Stroke = lineStroke,
                StrokeThickness = 3.0
            };
            canvas.Children.Add(Right);
        }

        //Zeichnet X oder O im jeweiligen Feld
        public void paintFill(Canvas canvas)
        {
            /*
             * falls Color Chooser verwendet werden wollte muss vom (funtionierenden?? Interface Gruppe J geerbt werden)
             * Color XColor = X_Color ?? Color.FromRgb(0, 255, 0);
             * Brush XStroke = new SolidColorBrush(XColor);
             * Color OColor = O_Color ?? Color.FromRgb(0, 0, 255);
             * Brush OStroke = new SolidColorBrush(OColor);
            */

            Color XColor;
            if (_flag) XColor = Color.FromRgb(255, 255, 0);
            else XColor = Color.FromRgb(0, 255, 0);

            Color OColor;
            if (_flag) OColor = Color.FromRgb(0, 255, 255);
            else OColor = Color.FromRgb(0, 0, 255);


            Brush XStroke = new SolidColorBrush(XColor);
            Brush OStroke = new SolidColorBrush(OColor);


            if (_player == 1)
            {
                Line l1 = new Line()
                {
                    X1 = ((_x) * _size) + 5,
                    Y1 = ((_y) * _size) + 5,
                    X2 = ((_x + 1) * _size) - 5,
                    Y2 = ((_y + 1) * _size) - 5,
                    Stroke = XStroke,
                    StrokeThickness = 2.0
                };
                Line l2 = new Line()
                {
                    X1 = ((_x) * _size) + 5,
                    Y1 = ((_y + 1) * _size) - 5,
                    X2 = ((_x + 1) * _size) - 5,
                    Y2 = ((_y) * _size) + 5,
                    Stroke = XStroke,
                    StrokeThickness = 2.0
                };
                canvas.Children.Add(l1);
                canvas.Children.Add(l2);
            }
            else if (_player == 2)
            {
                Ellipse OE = new Ellipse()
                {
                    Margin = new Thickness(((_x) * _size) + 4,
                    ((_y) * _size) + 4, 0, 0),
                    Width = _size - 8,
                    Height = _size - 8,
                    Stroke = OStroke,
                    StrokeThickness = 2.0
                };
                canvas.Children.Add(OE);
            }
        }

        //Gibt 0 zurück, fallls die Koordinaten nicht in dem Feld liegen
        //Gibt 1 zurück, fallls die Koordinaten in dem Feld liegen
        public Casket isMySpace(int x, int y)
        {
            if ((_x * _size) <= x && (_x + 1) * _size >= x)
            {
                if ((_y * _size) <= y && (_y + 1) * _size >= y)
                {
                    return this;
                }
            }
            Console.WriteLine("Click ist nicht im Feld Fehlercode: x58746");
            return null;
        }

    }



    public class TicTacToePaint_G : BaseTicTacToePaint, IPaintGame2
    {
        static int _Score1;
        static int _Score2;
        static int _CurrentPlayer;
        static int _MaxSize = 20;
        static bool _notcalled = true;

        //Übergabe des Namens an das Framework
        public override string Name { get { return "GruppeGTicTacToePaint"; } }

        //Erstellen des Painters
        public void TickPaintGameField(Canvas canvas, IGameField currentField)
        {
            if (currentField is ITicTacToeField_G)
            {
                PaintTicTacToeField_G(canvas, (ITicTacToeField_G)currentField);
            }
        }

        //Score Player 1 variable
        public static int Score1
        {
            get { return _Score1; }
            set { _Score1 = value; }
        }

        //Score Player 2 variable
        public static int Score2
        {
            get { return _Score2; }
            set { _Score2 = value; }
        }

        //Hilfsvariable: Gibt den aktuellen Spieler zurück
        public static int CurrentPlayer
        {
            get { return _CurrentPlayer; }
            set { _CurrentPlayer = value; }
        }

        //Spiellänge (wird am anfang jedes Spieles durch das Eingabefenster gesetzt)
        public static int MaxSize
        {
            get { return _MaxSize; }
            set { _MaxSize = value; }
        }

        //Hilfsvariable beinhaltet Wert, ob Eingabe erfolgt ist
        public static bool Notcalled
        {
            get { return _notcalled; }
            set { _notcalled = value; }
        }

        //Überschreibt abstrakte Methode aus BaseTicTacToePaint, prüft ob ein Spielfeld Gruppe G vorhanden ist und konvertiert dann das Spielfeld
        public override void PaintTicTacToeField(Canvas canvas, ITicTacToeField currentField)
        {
            if (currentField is ITicTacToeField_G)
            {
                PaintTicTacToeField_G(canvas, (ITicTacToeField_G)currentField);
            }
        }

        public void PaintTicTacToeField_G(Canvas canvas, ITicTacToeField_G currentField)
        {
            ITicTacToeField_G field_G = currentField;
            canvas.Children.Clear();
            Color bgColor = Color.FromRgb(255, 255, 255);
            canvas.Background = new SolidColorBrush(bgColor);

            //Zeichnen der Umrandung
            foreach (Casket C in currentField.Field)
            {
                C.paintFrame(canvas);
                C.paintFill(canvas);
            }

            //Zeichnen der Felder mit Flag
            foreach (Casket C in currentField.Field)
            {
                if (C.keyFlag) C.paintFrame(canvas);
            }

            //Zeichnen des rechten Fortschrittsbalkens
            //Balken zeigt Verhältnis der belegten Felder im Vergleich zu allen Feldern
            ProgressBar Progress = new ProgressBar();
            Progress.Foreground = new SolidColorBrush(Color.FromRgb(250, 0, 125));
            Canvas.SetTop(Progress, 0);
            Canvas.SetLeft(Progress, 420);
            Progress.Width = 20;
            Progress.Height = 400;
            Progress.Minimum = 0;
            Progress.Maximum = field_G.Field.Count;
            int value = 0;
            foreach (Casket c in field_G.Field)
            {
                if (c.player != 0) { value++; }
            }
            Progress.Value = value;
            Progress.Orientation = Orientation.Vertical;
            canvas.Children.Add(Progress);

            //zeichnet Scores
            PaintScore(canvas);

            //Öffnet Eingabefenster beim ersten Start
            if (_notcalled)
            {
                InputSize();
                _notcalled = false;
            }
        }

        //Zeichnet Score 1 und Score 2 mit Fortschrittsbalken
        void PaintScore(Canvas canvas)
        {
            SolidColorBrush ColorPlayer1 = new SolidColorBrush(Color.FromRgb(0, 255, 0));

            TextBox TBscore1 = new TextBox();
            TBscore1.Text = "Player 1: " + Score1.ToString();
            TBscore1.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));
            Canvas.SetLeft(TBscore1, 10);
            Canvas.SetTop(TBscore1, 420);
            if (_CurrentPlayer == 2 || _CurrentPlayer == 0)
            {
                TBscore1.Background = ColorPlayer1;
            }
            else
            {
                TBscore1.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            }
            canvas.Children.Add(TBscore1);

            ProgressBar Progress1 = new ProgressBar();
            Progress1.Foreground = ColorPlayer1;
            Canvas.SetTop(Progress1, 420);
            Canvas.SetLeft(Progress1, 100);
            Progress1.Width = 300;
            Progress1.Height = 20;
            Progress1.Minimum = 0;
            Progress1.Maximum = _MaxSize;
            Progress1.Value = Score1;
            Progress1.Orientation = Orientation.Horizontal;
            canvas.Children.Add(Progress1);


            SolidColorBrush ColorPlayer2 = new SolidColorBrush(Color.FromRgb(0, 0, 255));

            TextBox TBscore2 = new TextBox();
            TBscore2.Text = "Player 2: " + Score2.ToString();
            TBscore2.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));
            Canvas.SetLeft(TBscore2, 10);
            Canvas.SetTop(TBscore2, 450);
            if (_CurrentPlayer == 1)
            {
                TBscore2.Background = ColorPlayer2;
            }
            else
            {
                TBscore2.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            }
            canvas.Children.Add(TBscore2);

            ProgressBar Progress2 = new ProgressBar();
            Progress2.Foreground = ColorPlayer2;
            Canvas.SetTop(Progress2, 450);
            Canvas.SetLeft(Progress2, 100);
            Progress2.Width = 300;
            Progress2.Height = 20;
            Progress2.Minimum = 0;
            Progress2.Maximum = _MaxSize;
            Progress2.Value = Score2;
            Progress2.Orientation = Orientation.Horizontal;
            canvas.Children.Add(Progress2);
        }

        //Öffnet Eingabefenster
        void InputSize()
        {
            MaxSizeWindow Fenster = new MaxSizeWindow();
            Fenster.Show();
        }

    }

    public class TicTacToeRules_G : BaseTicTacToeRules, IGameRules2
    {
        public TicTacToeRules_G()
        {
            _Rules = this;
        }
        
        //Erzeugt ein Spielfeld der Gruppe G
        TicTacToeField_G _Field = new TicTacToeField_G();

        static TicTacToeRules_G _Rules;


        public static TicTacToeRules_G Rules { get { return _Rules; } }

        public TicTacToeField_G Field()
        {
            return Field();
        }

        public override ITicTacToeField TicTacToeField { get { return _Field; } }

        //gibt 0 zurück, wenn Spielzüge nicht möglich sind
        //gibt 1 zurück, wenn Spielzüge möglich sind
        public override bool MovesPossible
        {
            get
            {
                foreach (Casket C in _Field.Field)
                {
                    if (C.player == 0)
                    {
                        return true;
                    }
                }

                return false;
            }
        }

        //Übergibt Rules an das Framework
        public override string Name { get { return "GruppeGTicTacToeRules"; } }

        //Gibt Spielernummer des Gewonnenen Spielers zurück
        public override int CheckIfPLayerWon() //wird ein default wert benötigt?
        {
            int whohasthree = threeinarow(_Field.Field);


            if (whohasthree > 0)
            {

                if (Score1 < MaxSize && Score2 < MaxSize)
                {
                    _Field.increaseField();
                }

                if (whohasthree == 1)
                {
                    Score1++;
                }
                else
                {
                    Score2++;
                }
            }

            if (MovesPossible == false)
            {
                if (Score1 == 0 && Score2 == 0)
                {
                    _Field.increaseField();
                }
                else if (Score1 > Score2)
                {
                    return 1;
                }
                else
                {
                    return 2;
                }

            }

            if (Score1 >= MaxSize || Score2 >= MaxSize)
            {
                if (Score1 == MaxSize)
                {
                    return 1;
                }
                else
                {
                    return 2;
                }
            }
            return -1;
        }

        //setzt das Spielfeld auf Spielstart zurück zurück
        public override void ClearField()
        {

            Notcalled = true;

            while (_Field.Field.Count > 9)
            {
                _Field.Field.RemoveAt(9);
            }

            foreach (Casket C in _Field.Field)
            {
                C.player = 0;
                C.flag = false;
                C.size = _Field.Fieldsize / 3;
            }

            Score1 = 0;
            Score2 = 0;
        }

        //Prüft auf 3 gesetzte Felder in einer Reihe
        //0 falls keine 3 in einer Reihe
        //1 falls Spieler 1 3 in einer Reihe
        //2 falls Spieler 2 3 in einer Reihe
        public int threeinarow(List<Casket> Field) //überprüft, ob sich drei in einer Reihe befinden
        {
            foreach (Casket C in Field) //für jedes kästchen um die mitte herum wird der spielerwert gesucht, dieser wird dann verglichen
            {


                if (C.player > 0 && !C.flag)
                {

                    int links = 0; //enthält Spieler des Kästchens
                    int linksi = 0; //enthält Position des Objekts, welches den obigen Spielerwert enthält, in Liste
                    int mitte = C.player;
                    int rechts = 0;
                    int rechtsi = 0;
                    int olinks = 0;
                    int olinksi = 0;
                    int omitte = 0;
                    int omittei = 0;
                    int orechts = 0;
                    int orechtsi = 0;
                    int ulinks = 0;
                    int ulinksi = 0;
                    int umitte = 0;
                    int umittei = 0;
                    int urechts = 0;
                    int urechtsi = 0;

                    int xpos = C.x;
                    int ypos = C.y;
                    int searchx; //enthält gesuchte xpos des kästchens um das aktuelle kästchen herum
                    int searchy; //enthält gesuchte ypos des kästchens um das aktuelle kästchen herum

                    for (int i = 0; i < Field.Count; i++)
                    {
                        searchx = xpos - 1;
                        searchy = ypos - 1;
                        if (searchx == Field[i].x && searchy == Field[i].y && !Field[i].flag)
                        {
                            ulinks = Field[i].player;
                            ulinksi = i;
                        };

                        searchx = xpos - 1;
                        searchy = ypos;
                        if (searchx == Field[i].x && searchy == Field[i].y && !Field[i].flag)
                        {
                            links = Field[i].player;
                            linksi = i;
                        };

                        searchx = xpos - 1;
                        searchy = ypos + 1;
                        if (searchx == Field[i].x && searchy == Field[i].y && !Field[i].flag)
                        {
                            olinks = Field[i].player;
                            olinksi = i;
                        };

                        searchx = xpos;
                        searchy = ypos + 1;
                        if (searchx == Field[i].x && searchy == Field[i].y && !Field[i].flag)
                        {
                            omitte = Field[i].player;
                            omittei = i;
                        };

                        searchx = xpos + 1;
                        searchy = ypos + 1;
                        if (searchx == Field[i].x && searchy == Field[i].y && !Field[i].flag)
                        {
                            orechts = Field[i].player;
                            orechtsi = i;
                        };

                        searchx = xpos + 1;
                        searchy = ypos;
                        if (searchx == Field[i].x && searchy == Field[i].y && !Field[i].flag)
                        {
                            rechts = Field[i].player;
                            rechtsi = i;
                        };

                        searchx = xpos + 1;
                        searchy = ypos - 1;
                        if (searchx == Field[i].x && searchy == Field[i].y && !Field[i].flag)
                        {
                            urechts = Field[i].player;
                            urechtsi = i;
                        };

                        searchx = xpos;
                        searchy = ypos - 1;
                        if (searchx == Field[i].x && searchy == Field[i].y && !Field[i].flag)
                        {
                            umitte = Field[i].player;
                            umittei = i;
                        };

                    }


                    if (mitte == links && mitte == rechts)
                    {
                        C.flag = true;
                        Field[linksi].flag = true;
                        Field[rechtsi].flag = true;
                        return mitte;
                    }
                    if (mitte == olinks && mitte == urechts)
                    {
                        C.flag = true;
                        Field[olinksi].flag = true;
                        Field[urechtsi].flag = true;
                        return mitte;
                    }
                    if (mitte == omitte && mitte == umitte)
                    {
                        C.flag = true;
                        Field[omittei].flag = true;
                        Field[umittei].flag = true;
                        return mitte;
                    }
                    if (mitte == ulinks && mitte == orechts)
                    {
                        C.flag = true;
                        Field[ulinksi].flag = true;
                        Field[orechtsi].flag = true;
                        return mitte;
                    }
                }

            }

            return 0;

        }

        //führt einen Spielzug aus
        public override void DoTicTacToeMove(ITicTacToeMove move)
        {

            foreach (Casket cas in _Field.Field)
            {
                if (cas.x == move.Column && cas.y == move.Row)
                {
                    cas.player = move.PlayerNumber;
                }
            }
            //  _Field[move.Row, move.Column] = move.PlayerNumber;
        }

        void IGameRules2.StartedGameCall()
        {

        }

        void IGameRules2.TickGameCall()
        {

        }
    }


    public class TicTacToeField_G : ITicTacToeField_G
    {
        //Größe des gesamten Spielfeldes in px
        int _Fieldsize = 400;
        List<Casket> _Field = new List<Casket>();

        public int Fieldsize
        {
            get { return _Fieldsize; }
            set { _Fieldsize = value; }
        }

        public List<Casket> Field
        {
            get { return _Field; }
        }


        // Initialisieren 3x3 Feld
        public TicTacToeField_G()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Casket C = new Casket();
                    C.x = i;
                    C.y = j;
                    C.size = _Fieldsize / 3;
                    _Field.Add(C);
                }
            }
        }

        //Feld zum erstellen aus Frameworkaufruf (aus Vorlage übernommen und angepasst)
        int ITicTacToeField.this[int r, int c]
        {
            get
            {
                foreach (Casket C in _Field)
                {
                    if (C.x == c && C.y == r)
                    {
                        return C.player;
                    }
                }
                return -1;
            }

            set
            {
                foreach (Casket C in _Field)
                {
                    if (C.x == c && C.y == r)
                    {
                        C.player = value;
                    }
                }
            }

        }

        //Vergrößert das Spielfeld um eine Reihe und eine Zeile
        public void increaseField()
        {
            //berechnet die Länge der Liste in x - Richtung
            int lastSize = (int)Math.Sqrt(_Field.Count);

            //Zeile hinzufügen
            for (int i = 0; i < lastSize; i++)
            {
                Casket C = new Casket();
                C.x = i;
                C.y = lastSize;
                C.size = _Fieldsize / lastSize;
                _Field.Add(C);
            }

            // Spalte hinzufügen
            for (int i = 0; i < (lastSize) + 1; i++)
            {
                Casket C = new Casket();
                C.x = lastSize;
                C.y = i;
                C.size = _Fieldsize / lastSize;
                _Field.Add(C);
            }

            // Größe Kästchen neu skalieren
            foreach (Casket C in _Field)
            {
                C.size = _Fieldsize / (int)Math.Sqrt(_Field.Count);
            }
        }

        //Feld zum erstellen aus Frameworkaufruf (aus Vorlage übernommen und angepasst)
        public int this[int r, int c]
        {
            get
            {
                foreach (Casket i in _Field)
                {
                    if (i.x == r && i.y == c)
                    {
                        return i.player;
                    }
                }
                return -1;
            }

            set
            {
                foreach (Casket i in _Field)
                {
                    if (i.x == r && i.y == c)
                    {
                        i.player = value;
                    }
                }
            }
        }

        //0 falls das Feld und der Painter nicht kompartibel sind
        //1 falls das Feld und der Painter kompartibel sind
        public bool CanBePaintedBy(IPaintGame painter)
        {
            return painter is IPaintTicTacToe;
        }
    }

    public class HumanTicTacToePlayer_G : BaseHumanTicTacToePlayer
    {
        int _PlayerNumber = 0;
        int _xPosKeys = 0;
        int _yPosKeys = 0;

        //Übergabe Namen an ddas Framework
        public override string Name { get { return "GruppeGHumanTicTacToePlayer"; } }

        public override int PlayerNumber { get { return _PlayerNumber; } }

        //Klont das Spielfeld
        public override IGamePlayer Clone()
        {
            HumanTicTacToePlayer_G ttthp = new HumanTicTacToePlayer_G();
            ttthp.SetPlayerNumber(_PlayerNumber);
            return ttthp;
        }

        //Greift den Move ab
        public override ITicTacToeMove GetMove(IMoveSelection selection, ITicTacToeField field)
        {
            if (field is ITicTacToeField_G && selection is IClickSelection)
            {
                return GetMove_GClick((IClickSelection)selection, (ITicTacToeField_G)field);
            }
            if (field is ITicTacToeField_G && selection is IKeySelection)
            {
                return GetMove_GKeys((IKeySelection)selection, (ITicTacToeField_G)field);
            }
            Console.WriteLine("Kein passendes Gruppe G Feld");
            return null;
        }

        //GetMoveSelection(...) für Gruppe G Feld
        public ITicTacToeMove GetMove_GClick(IClickSelection sel, ITicTacToeField_G field_G)
        {

            foreach (Casket cas in field_G.Field)
            {
                if (cas.isMySpace(sel.XClickPos, sel.YClickPos) != null && cas.player == 0)
                {
                    Console.WriteLine(sel.YClickPos + ";" + sel.YClickPos);
                    Console.WriteLine(cas.x + ";" + cas.y + ";" + cas.size);

                    return new TicTacToeMove(cas.y, cas.x, _PlayerNumber);
                }

            }


            return null;
        }

        //Tastatursteuerung WASD & E = Setzen
        public ITicTacToeMove GetMove_GKeys(IKeySelection sel, ITicTacToeField_G field_G)
        {

            int _size = (int)Math.Sqrt(field_G.Field.Count);

            switch (sel.Key)
            {
                case Key.W:
                    if (_yPosKeys > 0)
                    {
                        _yPosKeys--;
                    }
                    break;
                case Key.S:
                    if (_yPosKeys < _size - 1)
                    {
                        _yPosKeys++;
                    }
                    break;
                case Key.A:
                    if (_xPosKeys > 0)
                    {
                        _xPosKeys--;
                    }
                    break;
                case Key.D:
                    if (_xPosKeys < _size - 1)
                    {
                        _xPosKeys++;
                    }
                    break;
                case Key.E:
                    foreach (Casket c in field_G.Field)
                    {
                        c.keyFlag = false;
                    }
                    int _x = _xPosKeys;
                    int _y = _yPosKeys;
                    _xPosKeys = 0;
                    _yPosKeys = 0;
                    return new TicTacToeMove(_y, _x, _PlayerNumber);
                default:
                    break;
            }
            foreach (Casket c in field_G.Field)
            {
                if (c.x == _xPosKeys && c.y == _yPosKeys)
                {
                    c.keyFlag = true;
                }
                else
                {
                    c.keyFlag = false;
                }
            }



            return null;
        }

        //Setzt Spielernummer
        public override void SetPlayerNumber(int playerNumber)
        {
            _PlayerNumber = playerNumber;
        }



    }

    //Computerplayer
    public class ComputerTicTacToePlayer_G : BaseComputerTicTacToePlayer
    {
        int _PlayerNumber = 0;

        //Registriert Namen im Framework
        public override string Name { get { return "GruppeGComputerTicTacToePlayer"; } }

        public override int PlayerNumber { get { return _PlayerNumber; } }

        public override IGamePlayer Clone()
        {
            ComputerTicTacToePlayer_G ttthp = new ComputerTicTacToePlayer_G();
            ttthp.SetPlayerNumber(_PlayerNumber);
            return ttthp;
        }

        //nimmt Move an
        public override ITicTacToeMove GetMove(ITicTacToeField field)
        {

            if (field is ITicTacToeField_G)
            {
                return GetMove_G((ITicTacToeField_G)field);
            }
            Console.WriteLine("Kein passendes Gruppe G Feld");
            return null;
        }

        //GetMove(...) Gruppe G angepasst
        public ITicTacToeMove GetMove_G(ITicTacToeField_G field)
        {
            int opponent;
            if (_PlayerNumber == 1) opponent = 2;
            else opponent = 1;
            List<Casket> Clone = field.Field.ConvertAll(x => new Casket(x));

            foreach (Casket c in Clone)
            {
                if (c.player == 0)
                {
                    c.player = _PlayerNumber;
                    if (Rules.threeinarow(Clone) != 0)
                    {
                        return new TicTacToeMove(c.y, c.x, _PlayerNumber);
                    }
                    c.player = 0;
                }
            }
            foreach (Casket c in Clone)
            {
                if (c.player == 0)
                {
                    c.player = opponent;
                    if (Rules.threeinarow(Clone) != 0)
                    {
                        return new TicTacToeMove(c.y, c.x, _PlayerNumber);
                    }
                    c.player = 0;
                }
            }

            foreach (Casket c1 in field.Field)
            {
                if (c1.player == _PlayerNumber && c1.flag == false)
                {
                    foreach (Casket c2 in field.Field) // Suchen nach einem freien Feld neben c1
                    {
                        if (c2.player == 0) // Feld muss unbesetzt sein
                        {
                            if ((c2.x >= c1.x - 1) && (c2.x <= c1.x + 1) && (c2.y >= c1.y - 1) && (c2.y <= c1.y + 1)) // Feld darf max 1 Kästchen entfernt sein (auch diagonal)
                            {
                                return new TicTacToeMove(c2.y, c2.x, _PlayerNumber);
                            }
                        }

                    }
                }
            }




            Random rand = new Random();
            int f = rand.Next(0, field.Field.Count - 1);

            while (true)
            {
                if (field.Field[f].player == 0)
                {
                    return new TicTacToeMove(field.Field[f].y, field.Field[f].x, _PlayerNumber);
                }
                else if (f < field.Field.Count - 1)
                {
                    f++;
                }
                else
                {
                    f = 0;
                }
            }
        }

        //Setzt Spielernummer
        public override void SetPlayerNumber(int playerNumber)
        {
            _PlayerNumber = playerNumber;
        }
    }
}






