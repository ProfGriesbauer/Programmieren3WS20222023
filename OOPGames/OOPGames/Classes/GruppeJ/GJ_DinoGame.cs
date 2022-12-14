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
using System.Windows.Shapes;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;
using System.Windows.Input;
using System.Reflection.Emit;

namespace OOPGames
{
    public class Obstacle
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public int posY { get; set; }
        public int posX { get; set; }
        public Image image { get; set; }

        public Obstacle (BitmapSource source)
        {
            image = new Image
            {
                Height = source.Height,
                Width = source.Width,
                Source = source,
            };
            posY = 365;
            Random rand = new Random();
            
            posX = 550 + rand.Next(0, 500);
           
        }
        public int GetLeftPos {
            get { return posX - (int)(0.5 * this.Width); }
        }
        public int GetTopPos()
        { return posY - (int)(0.5 * this.Height); }
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
        GJ_DinoGameRules rules = new GJ_DinoGameRules();

        public override string Name { get { return "GJ_DinoPainter"; } }
            
        public override void PaintDinoGameField(Canvas canvas, GJ_IDinoGameField currentField)
        {

            canvas.Children.Clear();
            Color bgColor = Color.FromRgb(255, 255, 255);
            canvas.Background = new SolidColorBrush(bgColor);
            Color lineColor = Color.FromRgb(40, 40, 40);
            Brush lineStroke = new SolidColorBrush(lineColor);
            Line l1 = new Line() { X1 = 0, Y1 = 417, X2 = 555, Y2 = 417, Stroke = lineStroke, StrokeThickness = 20.0 };
            canvas.Children.Add(l1);
            Image dinoPic = new Image();
          

            if (currentField.DinoHealth == "dead")
            {
                dinoPic.Source = new BitmapImage(new Uri("pack://application:,,,/OOPGames;component/Resources/dead.png"));
            }
            else if(rules.dinoHealth == "alive")
            {
                dinoPic.Source = new BitmapImage(new Uri("pack://application:,,,/OOPGames;component/Resources/running.gif"));
            }
            dinoPic.Width = dinoPic.Source.Width;
            dinoPic.Height= dinoPic.Source.Height;
            canvas.Children.Add(dinoPic);
            Canvas.SetTop(dinoPic, currentField.DinoYPos);
            Canvas.SetLeft(dinoPic, currentField.DinoXPos);
            foreach (Obstacle x in currentField.obstacles)
            {
                //Sobald Obstacle im Zeichenbereich ist
                if(x.posX <= 550)
                {
                    canvas.Children.Add((x.image));
                    Canvas.SetTop(x.image, x.posY);
                    Canvas.SetLeft(x.image, x.posX);

                }
            }
            TextBlock score = new TextBlock();

            score.Text = "Score: " + currentField.Score+ currentField.RestartGameText;

            
            score.FontSize = 20;
            Canvas.SetLeft(score, 20);
            Canvas.SetTop(score, 50);
            canvas.Children.Add(score);

        }

    }

        
    public class GJ_DinoGameField : GJ_IDinoGameField
    {
        int[,] _Field = new int[3, 3];

        public List<Obstacle> obstacles { get; set; }
        public int DinoYPos { get; set; }
        public int DinoXPos { get; set; }
  

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

        public override int jumpSpeed { get; set; }
        public override int force { get; set; }
        public override int gameScore { get; set; }
        public override int ObstacleSpeed { get; set; }
        public override int dinoYPosition { get; set; }

        private const int dinoXPosition = 100;
        public int DinoXPosition => dinoXPosition;
        

        public override int scoreNumber { get; set; }

        public int startNumber = 0;

        public override void Jump()
        {
            dinoYPosition += jumpSpeed;
            if (jumping == true && force < 0)
            {
                jumping = false;

            }
            if (jumping == true)
            {
                jumpSpeed = -12;
                force -= 1;
            }
            else
            {
                jumpSpeed = 12;
            }
                
            if (dinoYPosition > 364 && jumping == false)
            {
                force = 12;
                dinoYPosition = 365;
                jumpSpeed = 0;
            }
            _currentField.DinoYPos = dinoYPosition;
                          
        }

        public int getDinoXPosition { get { return dinoXPosition; } }

        public List<Obstacle> obstacles;

        public override int CheckIfPLayerWon()
        {
            if (_currentField.DinoHealth == "dead")
            {
                return -1;
            }
            else { return 0; }
        }

        public void CheckHealth()
        {
            Random rand = new Random();
            if (obstacles.Count() != 0)
            {
                foreach (Obstacle x in obstacles)
                {
                    x.posX -= ObstacleSpeed;
                    if (x.GetLeftPos < 30)
                    {
                        // Temporär Canvasbreite Hardcoded
                        x.posX = 550 + rand.Next(200, 500) + (x.Width * 25);
                        gameScore++;
                        scoreNumber++;
                    }
                    // DinoWidth = 40, DinoHeight = 43
                    if (dinoYPosition + 43 >= x.posY)
                    {
                        if ((dinoXPosition >= x.posX && dinoXPosition <= x.posX+x.Width) || (dinoXPosition+40 >= x.posX && dinoXPosition + 40 <= x.posX + x.Width))
                        {
                            _currentField.DinoHealth = "dead";
                            _currentField.RestartGameText = "\nPress R to restart the game!";
                            _currentField.obstacles = obstacles;
                            ObstacleSpeed = 0;
                        }
                    }

                }

            }
            if (scoreNumber > 10)
            {
                ObstacleSpeed++;
                scoreNumber = 0;
            }
            _currentField.obstacles = obstacles;
        }
        public override void ClearField()
        {
            
        }

        public override void DoMove(GJ_DinoPlayMove move)
        {
            
        }

        public override void StartedGameCall()
        {
            if(startNumber==0)
            {
                Start();
                startNumber = 1;
            }
        }

        public void Start()
        {
            _currentField.DinoHealth = "alive";
            jumping = false;
            jumpSpeed = 0;
            force = 12;
            gameScore = 0;
            _currentField.Score = gameScore;
            scoreNumber = 0;
            dinoYPosition = 365;
            ObstacleSpeed = 5;
            _currentField.DinoYPos = dinoYPosition;
            _currentField.DinoXPos = dinoXPosition;
            obstacles = new List<Obstacle>();
            BitmapImage bmi1 = new BitmapImage(new Uri("pack://application:,,,/OOPGames;component/Resources/obstacle-1.gif"));
            Obstacle obs1 = new Obstacle(bmi1);
            obs1.posY -= 4;
            obstacles.Add(obs1);
            BitmapImage bmi2 = new BitmapImage(new Uri("pack://application:,,,/OOPGames;component/Resources/obstacle-2.gif"));
            Obstacle obs2 = new Obstacle(bmi2);
            obs2.posY += 10;
            obs2.posX += 400;
            obstacles.Add(obs2);
            _currentField.obstacles = obstacles;
            _currentField.RestartGameText = "";
        }

        public override void TickGameCall()
        {
            KeyAction();
            Jump();
            CheckHealth();

        }

        public void KeyAction()
        {
            if (Keyboard.IsKeyDown(Key.Space) && jumping == false && _currentField.DinoHealth == "alive")
            {
                jumping = true;
            }
            else if (Keyboard.IsKeyUp(Key.Space) && jumping == true)
            {
                jumping = false;

            }
            if(Keyboard.IsKeyDown(Key.R) && ObstacleSpeed == 0)
            {
                Start();
            }
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
