﻿using System; 
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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
using OOPGames.Classes.Gruppe_D.Schiffeverseanken;

namespace OOPGames
{
    public interface ICasket
    {
        int x { get; set; }
        int y { get; set; }
        int size { get; set; }
        bool flag { get; set; }
        int player { get; set; } // evtl IGamePlayer anstelle von int
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

    public class Casket : ICasket 
    {
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
        public int player
        {
            get { return _player; }

            set { _player = value; }
        }
        public void paintFrame(Canvas canvas)
        {
            Color lineColor = Color.FromRgb(255, 0, 0);
            Brush lineStroke = new SolidColorBrush(lineColor);

            //Obere Linie
            Line Up = new Line() {
                X1 = (_x) * _size,
                Y1 = (_y) * _size,
                X2 = (_x + 1) * _size,
                Y2 = (_y) * _size,
                Stroke = lineStroke,
                StrokeThickness = 3.0 };
            canvas.Children.Add(Up);

            //Untere Linie
            Line Down = new Line() {
                X1 = (_x) * _size,
                Y1 = (_y + 1 ) * _size,
                X2 = (_x + 1 ) * _size,
                Y2 = (_y + 1) * _size,
                Stroke = lineStroke,
                StrokeThickness = 3.0 };
            canvas.Children.Add(Down);
            
            //Linke Linie
            Line Left = new Line() {
                X1 = (_x) * _size,
                Y1 = (_y) * _size,
                X2 = (_x) * _size,
                Y2 = (_y + 1) * _size,
                Stroke = lineStroke,
                StrokeThickness = 3.0 };
            canvas.Children.Add(Left);

            //Rechte Linie
            Line Right = new Line() {
                X1 = (_x + 1) * _size,
                Y1 = (_y) * _size,
                X2 = (_x + 1) * _size,
                Y2 = (_y + 1) * _size,
                Stroke = lineStroke,
                StrokeThickness = 3.0 };
            canvas.Children.Add(Right);
        }
        public void paintFill(Canvas canvas)
        {
            /*
            Color XColor = X_Color ?? Color.FromRgb(0, 255, 0);
            Brush XStroke = new SolidColorBrush(XColor);
            Color OColor = O_Color ?? Color.FromRgb(0, 0, 255);
            Brush OStroke = new SolidColorBrush(OColor);
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
                Line l1 = new Line() {
                    X1 = ((_x) * _size)+5,
                    Y1 = ((_y) * _size)+5,
                    X2 = ((_x + 1) * _size)-5,
                    Y2 = ((_y + 1) * _size)-5,
                    Stroke = XStroke,
                    StrokeThickness = 2.0 };
                Line l2 = new Line() {
                    X1 = ((_x) * _size)+5,
                    Y1 = ((_y + 1) * _size)-5,
                    X2 = ((_x + 1) * _size)-5,
                    Y2 = ((_y) * _size)+5,
                    Stroke = XStroke,
                    StrokeThickness = 2.0 };
                canvas.Children.Add(l1);
                canvas.Children.Add(l2);
            }
            else if (_player == 2)
            {
                Ellipse OE = new Ellipse() {
                    Margin = new Thickness(((_x) * _size)+4,
                    ((_y) * _size)+4, 0, 0),
                    Width = _size-8,
                    Height = _size-8,
                    Stroke = OStroke,
                    StrokeThickness = 2.0 };
                canvas.Children.Add(OE);
            }
        }

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
        public override string Name { get { return "GruppeGTicTacToePaint"; } }

        public void TickPaintGameField(Canvas canvas, IGameField currentField)
        {
            if (currentField is ITicTacToeField_G)
            {
                PaintTicTacToeField_G(canvas, (ITicTacToeField_G)currentField);
            }

        }
        public static int Score1
        {
            get { return _Score1; }
            set { _Score1 = value; }
        }
        public static int Score2
        {
            get { return _Score2; }
            set { _Score2 = value; }
        }

        public static int CurrentPlayer
        {
            get { return _CurrentPlayer; }
            set { _CurrentPlayer = value; }
        }

        // Überschreibt abstract Methode aus BaseTicTacToePaint, prüft ob ein Spielfeld Gruppe G vorhanden ist und konvertiert dann das Spielfeld
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
            foreach (Casket C in currentField.Field)
            {
                C.paintFrame(canvas);
                C.paintFill(canvas);
            }

            ProgressBar Progress = new ProgressBar();
            Progress.Foreground = new SolidColorBrush(Color.FromRgb(250, 0, 125));
            //Progress.Background = new SolidColorBrush(Color.FromRgb(0, 255, 0));
            Canvas.SetTop(Progress, 0);
            Canvas.SetLeft(Progress, 420);
            Progress.Width = 20;
            Progress.Height = 400;
            Progress.Minimum = 0;
            Progress.Maximum = field_G.Field.Count;
            int value = 0;
            foreach(Casket c in field_G.Field)
            {
                if (c.player != 0) { value++; }
            }
            Progress.Value = value;
            Progress.Orientation = Orientation.Vertical;
            canvas.Children.Add(Progress);


            PaintScore(canvas);
            
        }

        void PaintScore(Canvas canvas)
        {
            SolidColorBrush ColorPlayer1 = new SolidColorBrush(Color.FromRgb(0, 255, 0));

            TextBox TBscore1 = new TextBox();
            TBscore1.Text = "Player 1: " + Score1.ToString();
            TBscore1.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));
            Canvas.SetLeft(TBscore1, 10);
            Canvas.SetTop(TBscore1, 420);
            if (_CurrentPlayer == 2)
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
            Progress1.Maximum = 3;
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
            Progress2.Maximum = 3;
            Progress2.Value = Score2;
            Progress2.Orientation = Orientation.Horizontal;
            canvas.Children.Add(Progress2);
        }

    }

    /*
    public class TicTacToePaint_G : J_BaseTicTacToePaint
    {
        public override string Name { get { return "GruppeGTicTacToePaint"; } }

        public override Color X_Color
        {
            get
            {
                return X_Color;
            }

            set
            {
                X_Color = value;
            }
        }
        public override Color O_Color
        {
            get
            {
                return O_Color;
            }

            set
            {
                O_Color = value;
            }
        }


        // Überschreibt abstract Methode aus BaseTicTacToePaint, prüft ob ein Spielfeld Gruppe G vorhanden ist und konvertiert dann das Spielfeld
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
            foreach (Casket C in currentField.Field)
            {
                C.paintFrame(canvas);
            }


        }
    }

    */
    public class TicTacToeRules_G : BaseTicTacToeRules
    {
        public TicTacToeRules_G()
        {
            _Rules = this;
        }
            

            

        TicTacToeField_G _Field = new TicTacToeField_G();
        static TicTacToeRules_G _Rules;


        public static TicTacToeRules_G Rules { get { return _Rules; } }

        public TicTacToeField_G Field()
        {
            return Field();
        }

        public override ITicTacToeField TicTacToeField { get { return _Field; } }

        public override bool MovesPossible
        {
            get
            {
                foreach (Casket C in _Field.Field)
                {
                    if(C.player==0)
                    {
                        return true;
                    }
                }

                return false;
            }
        }

        public override string Name { get { return "GruppeGTicTacToeRules"; } }

        public override int CheckIfPLayerWon() //wird ein default wert benötigt?
        {
            int whohasthree = threeinarow(_Field.Field);


            if (whohasthree > 0) 
            {

                if (Score1<3 && Score2<3)
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
            }

            if(Score1 >= 3 || Score2 >= 3 || MovesPossible==false)
            {
                if (Score1 == 3)
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

        public override void ClearField()
        {
            while (_Field.Field.Count>9)
            {
                _Field.Field.RemoveAt(9);
            }

            foreach(Casket C in _Field.Field)
            {
                C.player=0;
                C.flag = false;
                C.size = _Field.Fieldsize / 3;
            }

            Score1 = 0;
            Score2 = 0;
        }


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

        public override void DoTicTacToeMove(ITicTacToeMove move)
        {

            foreach(Casket cas in _Field.Field)
            {
                if(cas.x == move.Column && cas.y == move.Row)
                {
                    cas.player = move.PlayerNumber;
                }
            }
                //  _Field[move.Row, move.Column] = move.PlayerNumber;
        }
    }


    public class TicTacToeField_G : ITicTacToeField_G
    {
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
            for (int i = 0; i < (lastSize)+1; i++)
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

        public bool CanBePaintedBy(IPaintGame painter)
        {
            return painter is IPaintTicTacToe;
        }
    }

    public class HumanTicTacToePlayer_G : BaseHumanTicTacToePlayer
    {
        int _PlayerNumber = 0;

        public override string Name { get { return "GruppeGHumanTicTacToePlayer"; } }

        public override int PlayerNumber { get { return _PlayerNumber; } }

        public override IGamePlayer Clone()
        {
            HumanTicTacToePlayer_G ttthp = new HumanTicTacToePlayer_G();
            ttthp.SetPlayerNumber(_PlayerNumber);
            return ttthp;
        }

        public override ITicTacToeMove GetMove(IMoveSelection selection, ITicTacToeField field)
        {
            if (field is ITicTacToeField_G)
            {
                return GetMove_G(selection, (ITicTacToeField_G)field);
            }
            Console.WriteLine("Kein passendes Gruppe G Feld");
            return null;
        }

        public ITicTacToeMove GetMove_G(IMoveSelection selection, ITicTacToeField_G field_G)
        {
            //List<Casket> field = field_G.Field;

            if (selection is IClickSelection)
            {
                IClickSelection sel = (IClickSelection)selection;

                foreach(Casket cas in field_G.Field)
                {
                    if(cas.isMySpace(sel.XClickPos, sel.YClickPos) != null && cas.player==0)
                    {
                        Console.WriteLine(sel.YClickPos + ";" + sel.YClickPos);
                        Console.WriteLine(cas.x + ";" + cas.y + ";" + cas.size);

                        CurrentPlayer = _PlayerNumber;

                        return new TicTacToeMove(cas.y, cas.x, _PlayerNumber);
                    }

                }
            }

            return null;
        }

        public override void SetPlayerNumber(int playerNumber)
        {
            _PlayerNumber = playerNumber;
        }
    }

    public class ComputerTicTacToePlayer_G : BaseComputerTicTacToePlayer
    {
        int _PlayerNumber = 0;

        public override string Name { get { return "GruppeGComputerTicTacToePlayer"; } }

        public override int PlayerNumber { get { return _PlayerNumber; } }

        public override IGamePlayer Clone()
        {
            ComputerTicTacToePlayer_G ttthp = new ComputerTicTacToePlayer_G();
            ttthp.SetPlayerNumber(_PlayerNumber);
            return ttthp;
        }


        public override ITicTacToeMove GetMove(ITicTacToeField field)
        {
            
            if (field is ITicTacToeField_G)
            {
                return GetMove_G((ITicTacToeField_G)field);
            }
            Console.WriteLine("Kein passendes Gruppe G Feld");
            return null;
        }

        public ITicTacToeMove GetMove_G(ITicTacToeField_G field)
        {
            List<Casket> Clone = field.Field.ConvertAll(x => new Casket(x));

            foreach (Casket c in Clone)
            {
                if(c.player==0)
                {
                    c.player = 1;
                    if(Rules.threeinarow(Clone) !=0)
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
                    c.player = 2;
                    if (Rules.threeinarow(Clone) != 0)
                    {
                        return new TicTacToeMove(c.y, c.x, _PlayerNumber);
                    }
                    c.player = 0;
                }
            }





            Random rand = new Random();
            int f = rand.Next(0,field.Field.Count-1);

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

        public override void SetPlayerNumber(int playerNumber)
        {
            _PlayerNumber = playerNumber;
        }
    }
}






