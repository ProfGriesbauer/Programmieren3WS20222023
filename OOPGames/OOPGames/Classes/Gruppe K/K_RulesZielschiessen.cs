using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using static System.Net.Mime.MediaTypeNames;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Forms;

namespace OOPGames.Classes.Gruppe_K
{
    internal class K_RulesZielschiessen : K_RulesPanzer
    {
        OOPGamesManager _OOPmanager= OOPGamesManager.Singleton;
        K_GameObjectManager _KgameManager=new K_GameObjectManager();
        List<K_Player> Panzerplayer = new List<K_Player>();
        K_Target randomeTarget = new K_Target();
        K_Text textpow = new K_Text();
        K_Text textwinkel = new K_Text();
        K_Text textscore = new K_Text();
        K_Text texttime = new K_Text();
        K_Progressbar progressbarpow = new K_Progressbar();
        

        int _gravitation = 500;                                                      //Gravitation in Pixel/(s^2)
        double _t = 0;                                                               //Zeit für Schussberechnung
        double _lastt = 0;
        int score = 0;
        float spielzeit = 30;

        public override string Name { get { return "K Rules Zielschießen"; } }

        public override bool MovesPossible { get { return _movePossible; } }


        public override IGameField CurrentField { get { return _KgameManager; } }

        public override int CheckIfPLayerWon()
        {
            return 0;
        }

        public override void ClearField()
        {

        }

        public override void DoMove(IPlayMove move)
        {
            
        }


       

        public override void StartedGameCall()
        {
            
            _KgameManager = new K_GameObjectManager();
            _KgameManager.Status = new K_Status();
            Panzerplayer = new List<K_Player>();
            randomeSpielfeld = new K_GameField();
            randomeTarget = new K_Target();
            stdSchuss = new K_Projectile();
            
            
            _gamestate = 0;
            
            
            //Panzerspieler 1 erstellen
            
            if (_OOPmanager.activePlayers.Count() > 0 && _OOPmanager.activePlayers.ElementAt(0) is K_Player) {
                IGamePlayer player1 = _OOPmanager.activePlayers.ElementAt(0);
                Panzerplayer.Add((K_Player)player1);

                K_DrawObject.DrawSetting drawSettingTank = new K_DrawObject.DrawSetting();
                K_DrawObject.DrawSetting drawSettingTankR = new K_DrawObject.DrawSetting();
                drawSettingTank.Scale = 2;
                drawSettingTank.xPos = 100;
                drawSettingTank.yPos = 100;
                drawSettingTank.Rotation = 0;
                drawSettingTank.DrawIndex = 10;
                Panzerplayer.Last<K_Player>().PositionData = drawSettingTank;
                Panzerplayer.Last<K_Player>().loadImage("Assets/K/Panzer.png", K_DrawObject.Position.CenterBottom);
                drawSettingTankR.Scale = drawSettingTank.Scale / 2;
                drawSettingTankR.DrawIndex = drawSettingTank.DrawIndex - 1;
                drawSettingTankR.yPos -= (int)(15 * drawSettingTankR.Scale);
                drawSettingTankR.ID = "gun";
                Panzerplayer.Last<K_Player>().loadImage("Assets/K/PanzerR.png", drawSettingTankR, K_DrawObject.Position.LeftCenter);
                Panzerplayer.Last<K_Player>().AngleID = drawSettingTankR.ID;

                Panzerplayer.Last<K_Player>().Status=new K_Status();
                Panzerplayer.Last<K_Player>().Status.State = 0;
                Panzerplayer.Last<K_Player>().Schusspow = 75;
            }

            /*
            //Panzerspieler 2 erstellen
            
            if (_OOPmanager.activePlayers.Count() > 1 && _OOPmanager.activePlayers.ElementAt(1) is K_Player)
            {
                IGamePlayer player2 = _OOPmanager.activePlayers.ElementAt(1);

                    Panzerplayer.Add((K_Player)player2);

                    K_DrawObject.DrawSetting drawSettingTank = new K_DrawObject.DrawSetting();
                    K_DrawObject.DrawSetting drawSettingTankR = new K_DrawObject.DrawSetting();
                    drawSettingTank.Scale = 2;
                    drawSettingTank.xPos = 700;
                    drawSettingTank.yPos = 100;
                    drawSettingTank.Rotation = 0;
                    drawSettingTank.DrawIndex = 10;
                    Panzerplayer.Last<K_Player>().PositionData = drawSettingTank;
                    Panzerplayer.Last<K_Player>().loadImage("Assets/K/Panzer.png", K_DrawObject.Position.CenterBottom);
                    drawSettingTankR.Scale = drawSettingTank.Scale / 2;
                    drawSettingTankR.DrawIndex = drawSettingTank.DrawIndex - 1;
                    drawSettingTankR.yPos -= (int)(15 * drawSettingTankR.Scale);
                    drawSettingTankR.ID = "gun";
                    Panzerplayer.Last<K_Player>().loadImage("Assets/K/PanzerR.png", drawSettingTankR, K_DrawObject.Position.LeftCenter);
                    Panzerplayer.Last<K_Player>().AngleID = drawSettingTankR.ID;
                    Panzerplayer.Last<K_Player>().Angle = 180;

                    Panzerplayer.Last<K_Player>().Status = new K_Status();
                    Panzerplayer.Last<K_Player>().Status.State = 0;
                
            }
            */

            //Spielfeld erstellen

            List<Color> colorList = new List<Color>();
            colorList.Add(Colors.Transparent);
            colorList.Add(Colors.Aqua);
            colorList.Add(Colors.Brown);
            colorList.Add(Colors.Gray);
            randomeSpielfeld.Palette = new BitmapPalette(colorList);

            randomeSpielfeld.drawIndex = 1;

            Random rand = new Random();


            double f3 = rand.Next(7, 10) * 1e-7;
            double f2 = rand.Next(1, 2) * -1e-3;
            double f1 = rand.Next(1, 3) * 1e-1;
            double f0 = rand.Next(0, 50) + 280;

            //Testwerte für steilen Hang
            /*
            double f3 = 1e-7;
            double f2 = -1e-3;
            double f1 = -20e-1;
            double f0 = 280;
            */

            for (int x = 0; x < randomeSpielfeld.Width; x++)
            {
                int yLimit = (int)(f3 * Math.Pow(x, 3) + f2 * Math.Pow(x, 2) + f1 * x + f0);
                for (int y = 0; y < randomeSpielfeld.Height; y++)
                {
                    if (yLimit <= y)
                    {
                        randomeSpielfeld.setField(x, y, 2);
                    }
                    else
                    {
                        randomeSpielfeld.setField(x, y, 0);
                    }
                }
            }

            //Target erstellen

            K_DrawObject.DrawSetting drawSettingTarget = new K_DrawObject.DrawSetting();
            drawSettingTarget.Scale = 3;
            drawSettingTarget.xPos = rand.Next(50,750);
            drawSettingTarget.yPos = 50;
            drawSettingTarget.Rotation = 0;
            drawSettingTarget.DrawIndex = 10;
            randomeTarget.PositionData = drawSettingTarget;
            randomeTarget.loadImage("Assets/K/Target.png", K_DrawObject.Position.Center);

            //Projectile erstellen

            K_DrawObject.DrawSetting drawSettingProjectile = new K_DrawObject.DrawSetting();
            drawSettingProjectile.Scale = 1;
            drawSettingProjectile.xPos = -20;                                                                   
            drawSettingProjectile.yPos = 0;
            drawSettingProjectile.Rotation = 0;
            drawSettingProjectile.DrawIndex = 7;
            stdSchuss.PositionData = drawSettingProjectile;
            stdSchuss.loadImage("Assets/K/Normaler_Schuss.png", K_DrawObject.Position.Center);

            

            // testField K_GameField object
            K_GameField testField2 = new K_GameField();         //Hintergrund


            testField2.Palette = new BitmapPalette(colorList);

            // Set drawIndex
            testField2.drawIndex = 0;


            Random random = new Random();
            int resPos = random.Next(200) + 100;

            for (int x = 0; x < testField2.Width; x++)
            {
                for (int y = 0; y < testField2.Height; y++)
                {
                    if (x % resPos < (y - 100))
                    {
                        testField2.setField(x, y, 3);
                    }
                    else
                    {
                        testField2.setField(x, y, 1);
                    }
                }
                if (x % 300 >= 299)
                {
                    resPos = random.Next(200) + 100;
                }
            }
            

            // Text für Schussstärke
            textpow.xPos = 00;
            textpow.yPos = 420;
            textpow.Text = "Schusskraft:      " + Panzerplayer[0].Schusspow.ToString();
            textpow.FontSize = 20;
            textpow.TextColor = Colors.Black;
            textpow.BackgroundColor = Colors.Transparent;
            _KgameManager.Objects.Add(textpow);

            // ProgressBar für Schussstärke
            progressbarpow.xPos = 115;
            progressbarpow.yPos = 425;
            progressbarpow.Width = 80;
            progressbarpow.Height = 20;
            progressbarpow.StrokeThickness = 2;
            progressbarpow.InnerColor1= Colors.White;
            progressbarpow.InnerColor2 = Colors.Green;
            progressbarpow.OuterColor= Colors.Black;
            progressbarpow.Progress = 0.5f;
            _KgameManager.Objects.Add(progressbarpow);

            // Text für Winkel
            textwinkel.xPos = 300;
            textwinkel.yPos = 420;
            textwinkel.Text = "Winkel:  ";
            textwinkel.FontSize = 20;
            textwinkel.TextColor = Colors.Black;
            textwinkel.BackgroundColor = Colors.Transparent;
            _KgameManager.Objects.Add(textwinkel);
            
            // Text für Score
            textscore.xPos = 300;
            textscore.yPos = 450;
            textscore.Text = "Score:  0";
            textscore.FontSize = 20;
            textscore.TextColor = Colors.Black;
            textscore.BackgroundColor = Colors.Transparent;
            _KgameManager.Objects.Add(textscore);

            // Text für Zeit
            texttime.xPos = 0;
            texttime.yPos = 450;
            texttime.Text = "Verbleibende Zeit:  30";
            texttime.FontSize = 20;
            texttime.TextColor = Colors.Black;
            texttime.BackgroundColor = Colors.Transparent;
            _KgameManager.Objects.Add(texttime);


            _KgameManager.GameField = randomeSpielfeld;
            
            _KgameManager.Objects.Add(randomeSpielfeld);
            
            _KgameManager.Objects.Add(testField2);

            _KgameManager.Objects.Add(randomeTarget);

            _KgameManager.Objects.Add(stdSchuss);

           foreach (K_Player data in Panzerplayer)
            {
                _KgameManager.Objects.Add(data);
            }

            Panzerplayer[0].Status.CanMove = true;
            score = 0;
            spielzeit = 30;
        }

        public override void TickGameCall()
        {
            
            randomeSpielfeld.removeHoles();
            spielzeit -= 0.06f;
            
            if(spielzeit < 0){ 
                _gamestate = 2;
                spielzeit = -0.1f;
            }
            
            texttime.Text = "Verbleibende Zeit:  " + Math.Round(spielzeit).ToString();

            if (_gamestate == 0)
            {
                Panzerplayer[0].Status.CanMove = true;
                stdSchuss.xPos = -20;
                stdSchuss.yPos = 0;

                Panzerplayer[0].updatePosition(randomeSpielfeld);
                
                textpow.Text = "Schusskraft                  " + Panzerplayer[0].Schusspow.ToString();
                progressbarpow.Progress = (float)Panzerplayer[0].Schusspow/100f;
                textwinkel.Text = "Winkel:  " + Math.Floor(((Panzerplayer[0].Angle + Panzerplayer[0].Rotation))).ToString();
                
                if (Panzerplayer[0].Status.State == 1)          //Wenn diese Eigenschaft = 1, wurde Schuss gedrückt
                {
                    stdSchuss.xSpeed = (float)(Math.Cos((Math.PI / (double)180) * (Panzerplayer[0].Angle + Panzerplayer[0].Rotation)) * (double)Panzerplayer[0].Schusspow * (double)6.5);   //Faktor 6.5 um Power von 0-100 auf 0-650 zu bekommen
                    stdSchuss.ySpeed = (float)(Math.Sin((Math.PI / (double)180) * (Panzerplayer[0].Angle + Panzerplayer[0].Rotation)) * (double)Panzerplayer[0].Schusspow * (double)6.5);
                    stdSchuss.xStart = Panzerplayer[0].xPos;
                    stdSchuss.yStart = Panzerplayer[0].yPos;

                    Panzerplayer[0].Status.CanMove = false;

                    _gamestate = 1;
                    _t = 0;
                    _lastt = 0; 
                }
            
            }
            
            if (_gamestate == 1)
            {
                _t += 0.04;

                double prodx = stdSchuss.xStart;
                double prody = stdSchuss.yStart;
                int removestate = 0;

                for(double _n = _lastt; _n < _t; _n += 0.002)               //20 mal pro Frame Koalisionsberechnung
                {
                    prodx = stdSchuss.xStart + stdSchuss.xSpeed * _n;
                    prody = stdSchuss.yStart + stdSchuss.ySpeed * _n  + 0.5 * _gravitation * Math.Pow(_n, 2);

                    double Abstand = Math.Sqrt(Math.Pow(prodx-randomeTarget.xPos, 2)+ Math.Pow(prody - randomeTarget.yPos, 2));
                    
                    if(Abstand < (10 * randomeTarget.Scale))                //wenn Target berührt
                    {
                        score++;
                        textscore.Text = "Score:  " + score.ToString();

                        Random rando = new Random();
                        _gamestate = 0;
                        randomeTarget.xPos = rando.Next(50, randomeSpielfeld.Width-50);
                        
                        int ymax= 0;
                        while (randomeSpielfeld.getField(randomeTarget.xPos, ymax) == 0)
                        {
                            ymax++;
                        }

                        randomeTarget.yPos = rando.Next(50, ymax);
                        Panzerplayer[0].Status.State = 0;
                        break;
                    }

                    if (randomeSpielfeld.getField((int)prodx, (int)prody) == 2 && removestate == 0 && _t > 0.05)     //wenn Boden berührt
                    {
                        _gamestate = 0;
                        createhole((int)prodx, (int)prody, 25);
                        Panzerplayer[0].Status.State = 0;
                        removestate = 1;
                    }

                }

                if (prodx < 0 || prodx > randomeSpielfeld.Width || prody > (randomeSpielfeld.Height+2))        //1 mal pro Frame: Prüfung ob außerhalb von Maprand
                    {
                    _gamestate = 0;
                    Panzerplayer[0].Status.State = 0;
                }
                else
                {
                    stdSchuss.xPos = (int)prodx;
                    stdSchuss.yPos = (int)prody;
                }
                
                _lastt = _t;
            }

            if (_gamestate == 2)
            {
                Panzerplayer[0].Status.CanMove = false;                                                        //nichts machen
                stdSchuss.xPos = -20;
                stdSchuss.yPos = 0;

            }
        }
    }
}