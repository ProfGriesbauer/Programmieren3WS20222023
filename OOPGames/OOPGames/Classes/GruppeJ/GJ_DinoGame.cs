using OOPGames.Classes.Gruppe_E;
using OOPGames.Classes.Gruppe_K;
using OOPGames.Interfaces.Gruppe_J;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace OOPGames
{
    public class Obstacle
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public int pos { get; set; }
        public Image image { get; set; }

        public Obstacle (Canvas canvas, BitmapSource source)
        {
            image = new Image
            {
                Height = source.Height,
                Width = source.Width,
                Source = source
            };
            canvas.Children.Add(image); 
            Random rand = new Random();
            Canvas.SetTop(image, 300);
            Canvas.SetLeft(image, 300 + rand.Next(0,100));
            //canvas.set
        }
        private int getLeftPos;
        public int GetLeftPos {
        get { return getLeftPos - (int)(0.5 * this.Width); }
        set { getLeftPos = value; }
        }
        public int getTopPos()
        { return pos - (int)(0.5 * this.Height); }

    }
    public class GJ_DinoPlayMove : GJ_IDinoPlayMove
    {
        public int PlayerNumber { get { return 1; } }

        public GJ_DinoPlayMove()
        {

        }
    }

    public class GJ_DinoPaintGame : GJ_IDinoPaintGame
    {
        public override string Name { get { return "GJ_DinoPainter"; } }

        public override void PaintDinoGameField(Canvas canvas, GJ_IDinoGameField currentField)
        {
            // Painting Starting Game Field
            canvas.Children.Clear();
            Color bgColor = Color.FromRgb(255, 255, 255);
            canvas.Background = new SolidColorBrush(bgColor);
            Image dinoPic = new Image();
            dinoPic.Width = 40;
            dinoPic.Height = 43;
            // Mögliche Option, den Ressourcenpfad relativ im Projekt zu schreiben, vorerst lokal auf meinem PC (Jannik)
            //dinoPic.Source = new BitmapImage(new Uri("pack://application:,,,/OOPGames;componentResources/running.gif"));
            dinoPic.Source = new BitmapImage(new Uri("C:\\Users\\Jannik\\Google Drive\\WS23\\Programmieren 3\\Project\\Programmieren3WS20222023\\OOPGames\\OOPGames\\Resources\\running.gif"));
            canvas.Children.Add(dinoPic);
            Canvas.SetTop(dinoPic, 200);
            
            //ImageBrush dino = new ImageBrush(new ImageSource(""));
        }

        public void PaintGameField(Canvas canvas, IGameField currentField)
        {
            if (currentField is GJ_DinoGameField)
            {
                PaintDinoGameField(canvas, (GJ_DinoGameField)currentField);
            }
        }

        public override void TickPaintGameField(Canvas canvas, IGameField currentField)
        {
            //Nur Temporär eingefügt!
            if (currentField is GJ_DinoGameField)
            {
                TickPaintDinoGameField(canvas, (GJ_DinoGameField)currentField);
            }
        }
        public void TickPaintDinoGameField(Canvas canvas, GJ_DinoGameField currentField)
        {
            // Painting Starting Game Field
            canvas.Children.Clear();
            Color bgColor = Color.FromRgb(255, 255, 255);
            canvas.Background = new SolidColorBrush(bgColor);
            Image dinoPic = new Image();
            dinoPic.Width = 40;
            dinoPic.Height = 43;
            TextBlock score = new TextBlock();
            score.Text = "Score: ";
            canvas.Children.Add(score);
            //Canvas.Set
            // Mögliche Option, den Ressourcenpfad relativ im Projekt zu schreiben, vorerst lokal auf meinem PC (Jannik)
            //dinoPic.Source = new BitmapImage(new Uri("pack://application:,,,/OOPGames;componentResources/running.gif"));
            dinoPic.Source = new BitmapImage(new Uri("C:\\Users\\Jannik\\Google Drive\\WS23\\Programmieren 3\\Project\\Programmieren3WS20222023\\OOPGames\\OOPGames\\Resources\\running.gif"));
            canvas.Children.Add(dinoPic);
            Canvas.SetTop(dinoPic, 200);
            GJ_DinoGameRules rules= new GJ_DinoGameRules();
            Canvas.SetLeft(dinoPic, rules.getDinoXPosition);   
        }
    }

        
    public class GJ_DinoGameField : GJ_IDinoGameField
    {
        int[,] _Field = new int[3, 3];
        public int this[int i]
        {
            get
            {
                return _Field[0, 0];
            }
            set
            {
                _Field[0, 0] = 0;
            }
        }
        public bool CanBePaintedBy(IPaintGame painter)
        {
            return painter is GJ_IDinoPaintGame;
        }
    }

    public class GJ_DinoGameRules : GJ_IDinoGameRules
    {
        public override string Name { get { return "GJ_DinoRules"; } }

        public GJ_DinoGameField _currentField = new GJ_DinoGameField(); 
        public override IGameField CurrentField { get { return _currentField; } }


        public override bool MovesPossible { get; }

        public override bool jumping { get; set;  }

        public override bool gameOver { get; }

        public override int jumpspeed { get; set; }
        public override int force { get; set; }
        public override int gameScore { get; set; }
        public override int ObstacleSpeed { get; set; }
        public override int dinoYPosition { get; set; }

        private const int dinoXPosition = 60;

        public override int scoreNumber { get; set; }

        public int getDinoXPosition { get { return dinoXPosition; } }

        public List<Obstacle> obstacles;

        public void addObstacle(Obstacle ob)
        { 

            obstacles.Add(ob);
        }

        public void removeObstacle(Obstacle ob)
        { obstacles.Remove(ob); }

        public int getObstacleCount()
        { return obstacles.Count; }

        public override int CheckIfPLayerWon()
        {
            Random rand = new Random();
            foreach (Obstacle x in obstacles)
            {
                if (x is Obstacle)
                { 
                    x.GetLeftPos -= ObstacleSpeed;
                    if (x.GetLeftPos < 100)
                    {
                        // Temporär Canvasbreite Hardcoded
                        x.GetLeftPos = 550 + rand.Next(200, 500) + (x.Width * 25);
                        gameScore++;
                        scoreNumber++;
                    }
                    // DinoWidth = 40, DinoHeight = 43
                    if (((dinoYPosition + 43)>x.getTopPos()) && ((dinoXPosition + 40) > x.getTopPos()) && (dinoXPosition < (x.Width + x.GetLeftPos)))
                    {
                        //TODO:
                        // fm.S_G_Dino.Image = Properties.Resources.dead;
                        //fm.TxtScore.Text += "\nPress R to restart the game!";
                        //Player.IsGameOver = true;
                        return 1;

                    }
                }
            }
            if (scoreNumber > 10)
            {
                //Player.ObstacleSpeed++;
                scoreNumber = 0;
            }
            return 0;
        }

        public override void ClearField()
        {
            
        }

        public override void DoMove(GJ_DinoPlayMove move)
        {
            
        }

        public override void StartedGameCall()
        {
            jumping = false;
            force = 12;
            gameScore= 0;
            scoreNumber = 0;
            obstacles = new List<Obstacle>();
        }

        public override void TickGameCall()
        {
            
        }
    }

    public class GJ_DinoGamePlayer : GJ_IDinoGamePlayer
    {
        public override string Name { get { return "GJ_DinoPlayer"; } }

        public override int PlayerNumber { get; set; }

        public override bool CanBeRuledBy(IGameRules rules)
        {
            return rules is GJ_DinoGameRules;
        }

        public override IGamePlayer Clone()
        {
            GJ_DinoGamePlayer dgp = new GJ_DinoGamePlayer();
            dgp.SetPlayerNumber(1);
            return dgp; 
        }

        public override GJ_DinoPlayMove GetMove(IMoveSelection selection, GJ_IDinoGameField field)
        {
            return new GJ_DinoPlayMove();
        }

        public override void SetPlayerNumber(int playerNumber)
        {
            PlayerNumber = playerNumber;
        }
    }

}
