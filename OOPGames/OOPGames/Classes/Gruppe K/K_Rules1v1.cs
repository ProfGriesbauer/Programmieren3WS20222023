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

/*
TO-DO:
-Leben hinzufügen



*/

namespace OOPGames.Classes.Gruppe_K
{
    internal class K_Rules1v1 : K_RulesPanzer
    {

        OOPGamesManager _OOPmanager = OOPGamesManager.Singleton;
        K_GameObjectManager _KgameManager = new K_GameObjectManager();
        List<K_Player> Panzerplayer = new List<K_Player>();
        K_Text textpow1 = new K_Text();
        K_Text textpow2 = new K_Text();
        K_Text textwinkel1 = new K_Text();
        K_Text textwinkel2 = new K_Text();
        K_Text textfuel1 = new K_Text();
        K_Text textfuel2 = new K_Text();
        K_Text texthealth1 = new K_Text();
        K_Text texthealth2 = new K_Text();
        K_Text textplayeranzeige1 = new K_Text();
        K_Text textplayeranzeige2 = new K_Text();
        K_Progressbar progressbarpow1 = new K_Progressbar();
        K_Progressbar progressbarpow2 = new K_Progressbar();
        K_Progressbar progressbarfuel1 = new K_Progressbar();
        K_Progressbar progressbarfuel2 = new K_Progressbar();
        K_Progressbar progressbarhealth1 = new K_Progressbar();
        K_Progressbar progressbarhealth2 = new K_Progressbar();

        int _gravitation = 500;                                                      //Gravitation in Pixel/(s^2)
        double _t = 0;                                                               //Zeit für Schussberechnung
        double _lastt = 0;
        int _Playertomove ;  //0-> Spieler 1, 1-> Spieler 2
        int _lastPlayer ;
        int[] xPosold;

        public override string Name { get { return "K Rules 1v1"; } }

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
            stdSchuss = new K_Projectile();
            
            _Playertomove = 0;
            _lastPlayer = 1;
            //Panzerspieler 1 erstellen

            if (_OOPmanager.activePlayers.Count() > 0 && _OOPmanager.activePlayers.ElementAt(0) is K_Player)
            {
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

                Panzerplayer.Last<K_Player>().Status = new K_Status();
                Panzerplayer.Last<K_Player>().Status.State = 0;
                Panzerplayer.Last<K_Player>().Schusspow = 75;
                Panzerplayer.Last<K_Player>().Health = 1;
                Panzerplayer.Last<K_Player>().Fuel = 1;
            }

            
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
                    Panzerplayer.Last<K_Player>().Schusspow = 75;
                    Panzerplayer.Last<K_Player>().Health = 1;
                    Panzerplayer.Last<K_Player>().Fuel = 1;
            }
            
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

            //Projectile erstellen

            K_DrawObject.DrawSetting drawSettingProjectile = new K_DrawObject.DrawSetting();
            drawSettingProjectile.Scale = 1;
            drawSettingProjectile.xPos = -20;
            drawSettingProjectile.yPos = 0;
            drawSettingProjectile.Rotation = 0;
            drawSettingProjectile.DrawIndex = 7;
            stdSchuss.PositionData = drawSettingProjectile;
            stdSchuss.loadImage("Assets/K/Normaler_Schuss.png", K_DrawObject.Position.Center);

            // Text für Playeranzeige Player 1
            textplayeranzeige1.xPos = 0;
            textplayeranzeige1.yPos = 550;
            textplayeranzeige1.Text = "   Player 1";
            textplayeranzeige1.FontSize = 45;
            textplayeranzeige1.TextColor = Colors.Red;
            textplayeranzeige1.BackgroundColor = Colors.Transparent;
            _KgameManager.Objects.Add(textplayeranzeige1);

            // Text für Playeranzeige Player 2
            textplayeranzeige2.xPos = 500;
            textplayeranzeige2.yPos = 550;
            textplayeranzeige2.Text = "   Player 2";
            textplayeranzeige2.FontSize = 45;
            textplayeranzeige2.TextColor = Colors.Transparent;
            textplayeranzeige2.BackgroundColor = Colors.Transparent;
            _KgameManager.Objects.Add(textplayeranzeige2);

            // Text für Health Player 1
            texthealth1.xPos = 0;
            texthealth1.yPos = 420;
            texthealth1.Text = "Leben:                         " + Math.Floor(Panzerplayer[0].Health * 100f);
            texthealth1.FontSize = 20;
            texthealth1.TextColor = Colors.Black;
            texthealth1.BackgroundColor = Colors.Transparent;
            _KgameManager.Objects.Add(texthealth1);

            // Text für Health Player 2
            texthealth2.xPos = 500;
            texthealth2.yPos = 420;
            texthealth2.Text = "Leben:                         " + Math.Floor(Panzerplayer[1].Health * 100f);
            texthealth2.FontSize = 20;
            texthealth2.TextColor = Colors.Black;
            texthealth2.BackgroundColor = Colors.Transparent;
            _KgameManager.Objects.Add(texthealth2);


            // ProgressBar für Health PLayer 1
            progressbarhealth1.xPos = 115;
            progressbarhealth1.yPos = 425;
            progressbarhealth1.Width = 80;
            progressbarhealth1.Height = 20;
            progressbarhealth1.StrokeThickness = 2;
            progressbarhealth1.InnerColor1 = Colors.White;
            progressbarhealth1.InnerColor2 = Colors.MediumSpringGreen;
            progressbarhealth1.OuterColor = Colors.Black;
            progressbarhealth1.Progress = 1f;
            _KgameManager.Objects.Add(progressbarhealth1);


            // ProgressBar für Health PLayer 2
            progressbarhealth2.xPos = 615;
            progressbarhealth2.yPos = 425;
            progressbarhealth2.Width = 80;
            progressbarhealth2.Height = 20;
            progressbarhealth2.StrokeThickness = 2;
            progressbarhealth2.InnerColor1 = Colors.White;
            progressbarhealth2.InnerColor2 = Colors.MediumSpringGreen;
            progressbarhealth2.OuterColor = Colors.Black;
            progressbarhealth2.Progress = 1f;
            _KgameManager.Objects.Add(progressbarhealth2);

            // Text für Schussstärke für Player1
            textpow1.xPos = 00;
            textpow1.yPos = 450;
            textpow1.Text = "Schusskraft:      " + Panzerplayer[0].Schusspow.ToString();
            textpow1.FontSize = 20;
            textpow1.TextColor = Colors.Black;
            textpow1.BackgroundColor = Colors.Transparent;
            _KgameManager.Objects.Add(textpow1);

            // Text für Schussstärke für Player2
            textpow2.xPos = 500;
            textpow2.yPos = 450;
            textpow2.Text = "Schusskraft:      " + Panzerplayer[1].Schusspow.ToString();
            textpow2.FontSize = 20;
            textpow2.TextColor = Colors.Black;
            textpow2.BackgroundColor = Colors.Transparent;
            _KgameManager.Objects.Add(textpow2);

            // ProgressBar für Schussstärke PLayer 1
            progressbarpow1.xPos = 115;
            progressbarpow1.yPos = 455;
            progressbarpow1.Width = 80;
            progressbarpow1.Height = 20;
            progressbarpow1.StrokeThickness = 2;
            progressbarpow1.InnerColor1 = Colors.White;
            progressbarpow1.InnerColor2 = Colors.Green;
            progressbarpow1.OuterColor = Colors.Black;
            progressbarpow1.Progress = 0.5f;
            _KgameManager.Objects.Add(progressbarpow1);


            // ProgressBar für Schussstärke PLayer 2
            progressbarpow2.xPos = 615;
            progressbarpow2.yPos = 455;
            progressbarpow2.Width = 80;
            progressbarpow2.Height = 20;
            progressbarpow2.StrokeThickness = 2;
            progressbarpow2.InnerColor1 = Colors.White;
            progressbarpow2.InnerColor2 = Colors.Green;
            progressbarpow2.OuterColor = Colors.Black;
            progressbarpow2.Progress = 0.5f;
            _KgameManager.Objects.Add(progressbarpow2);

            // Text für Winkel Player 1
            textwinkel1.xPos = 0;
            textwinkel1.yPos = 480;
            textwinkel1.Text = "Winkel:  ";
            textwinkel1.FontSize = 20;
            textwinkel1.TextColor = Colors.Black;
            textwinkel1.BackgroundColor = Colors.Transparent;
            _KgameManager.Objects.Add(textwinkel1);

            // Text für Winkel Player 2
            textwinkel2.xPos = 500;
            textwinkel2.yPos = 480;
            textwinkel2.Text = "Winkel:  ";
            textwinkel2.FontSize = 20;
            textwinkel2.TextColor = Colors.Black;
            textwinkel2.BackgroundColor = Colors.Transparent;
            _KgameManager.Objects.Add(textwinkel2);

            //Text für Fuel Player 1
            textfuel1.xPos = 0;
            textfuel1.yPos = 510;
            textfuel1.Text = "Treibstoff:         " + Panzerplayer[0].Fuel.ToString();
            textfuel1.FontSize = 20;
            textfuel1.TextColor = Colors.Black;
            textfuel1.BackgroundColor = Colors.Transparent;
            _KgameManager.Objects.Add(textfuel1);

            //Text für Fuel Player 2
            textfuel2.xPos = 500;
            textfuel2.yPos = 510;
            textfuel2.Text = "Treibstoff:   " + Panzerplayer[1].Fuel.ToString();
            textfuel2.FontSize = 20;
            textfuel2.TextColor = Colors.Black;
            textfuel2.BackgroundColor = Colors.Transparent;
            _KgameManager.Objects.Add(textfuel2);

            // ProgressBar für Fuel Player 1
            progressbarfuel1.xPos = 115;
            progressbarfuel1.yPos = 515;
            progressbarfuel1.Width = 80;
            progressbarfuel1.Height = 20;
            progressbarfuel1.StrokeThickness = 2;
            progressbarfuel1.InnerColor1 = Colors.White;
            progressbarfuel1.InnerColor2 = Colors.Red;
            progressbarfuel1.OuterColor = Colors.Black;
            progressbarfuel1.Progress = 1f;
            _KgameManager.Objects.Add(progressbarfuel1);


            // ProgressBar für Fuel Player 2
            progressbarfuel2.xPos = 615;
            progressbarfuel2.yPos = 515;
            progressbarfuel2.Width = 80;
            progressbarfuel2.Height = 20;
            progressbarfuel2.StrokeThickness = 2;
            progressbarfuel2.InnerColor1 = Colors.White;
            progressbarfuel2.InnerColor2 = Colors.Red;
            progressbarfuel2.OuterColor = Colors.Black;
            progressbarfuel2.Progress = 1f;
            _KgameManager.Objects.Add(progressbarfuel2);



            _KgameManager.GameField = randomeSpielfeld;

            _KgameManager.Objects.Add(randomeSpielfeld);

            _KgameManager.Objects.Add(stdSchuss);
            xPosold = new int[] {Panzerplayer[0].xPos, Panzerplayer[1].xPos};

            foreach (K_Player data in Panzerplayer)
            {
                _KgameManager.Objects.Add(data);
            }
            Panzerplayer[0].Status.CanMove = true;
            Panzerplayer[0].updatePosition(randomeSpielfeld);
            Panzerplayer[1].updatePosition(randomeSpielfeld);
        }

        public override void TickGameCall()
        
        {
            randomeSpielfeld.removeHoles();
            BerechnungSchuss();
                
            

        }

        

        public void BerechnungSchuss()
        {
            
            if (_gamestate == 0)
            {
                Panzerplayer[_Playertomove].Status.CanMove = true;
                stdSchuss.xPos = -20;
                stdSchuss.yPos = 0;
                if (Panzerplayer[_Playertomove].xPos != xPosold[_Playertomove])
                {
                    Panzerplayer[_Playertomove].Fuel -= 0.03f;

                    if (Panzerplayer[_Playertomove].Fuel <= 0f)
                    {
                        Panzerplayer[_Playertomove].Fuel = 0f;
                        Panzerplayer[_Playertomove].Status.CanMove = false;
                        Panzerplayer[_Playertomove].Status.CanShootnoMove = true;
                    }
                    xPosold[_Playertomove] = Panzerplayer[_Playertomove].xPos;
                }
                

                textpow1.Text = "Schusskraft:                 " + Panzerplayer[0].Schusspow.ToString();
                progressbarpow1.Progress = (float)Panzerplayer[0].Schusspow / 100f;
                textwinkel1.Text = "Winkel:         " + Math.Floor(((Panzerplayer[0].Angle + Panzerplayer[0].Rotation))).ToString();
                textfuel1.Text = "Treibstoff:                    " + Math.Floor(Panzerplayer[0].Fuel * 100f);
                progressbarfuel1.Progress = (float)Panzerplayer[0].Fuel;

                textpow2.Text = "Schusskraft:                 " + Panzerplayer[1].Schusspow.ToString();
                progressbarpow2.Progress = (float)Panzerplayer[1].Schusspow / 100f;
                textwinkel2.Text = "Winkel:         " + Math.Floor(((Panzerplayer[1].Angle + Panzerplayer[1].Rotation))).ToString();
                textfuel2.Text = "Treibstoff:                    " + Math.Floor(Panzerplayer[1].Fuel * 100f);
                progressbarfuel2.Progress = (float)Panzerplayer[1].Fuel;

                Panzerplayer[_Playertomove].updatePosition(randomeSpielfeld);
                //_movePossible = true;

                if (Panzerplayer[_Playertomove].Status.State == 1)          //Wenn diese Eigenschaft = 1, wurde Schuss gedrückt
                {
                    stdSchuss.xSpeed = (float)(Math.Cos((Math.PI / (double)180) * (Panzerplayer[_Playertomove].Angle + Panzerplayer[_Playertomove].Rotation)) * (double)Panzerplayer[_Playertomove].Schusspow * 8.5);
                    stdSchuss.ySpeed = (float)(Math.Sin((Math.PI / (double)180) * (Panzerplayer[_Playertomove].Angle + Panzerplayer[_Playertomove].Rotation)) * (double)Panzerplayer[_Playertomove].Schusspow * 8.5);
                    stdSchuss.xStart = Panzerplayer[_Playertomove].xPos;
                    stdSchuss.yStart = Panzerplayer[_Playertomove].yPos;

                    Panzerplayer[_Playertomove].Status.CanMove = false;
                    Panzerplayer[_Playertomove].Status.State = 0;
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

                for (double _n = _lastt; _n < _t; _n += 0.002)               //20 mal pro Frame Koalisionsberechnung
                {
                    prodx = stdSchuss.xStart + stdSchuss.xSpeed * _n;
                    prody = stdSchuss.yStart + stdSchuss.ySpeed * _n + 0.5 * _gravitation * Math.Pow(_n, 2);

                    double Abstand = Math.Sqrt(Math.Pow(prodx - Panzerplayer[_lastPlayer].xPos, 2) + Math.Pow(prody - Panzerplayer[_lastPlayer].yPos, 2));

                    if (Abstand < (10 * Panzerplayer[_lastPlayer].Scale))                //wenn Gegner berührt
                    {
                        
                        _gamestate = 0;
                        

                        int ymax = 0;
                        while (randomeSpielfeld.getField(Panzerplayer[_lastPlayer].xPos, ymax) == 0)
                        {
                            ymax++;
                        }

                        
                        Panzerplayer[_Playertomove].Status.State = 0;
                        Panzerplayer[_lastPlayer].Health -= (float)Math.Sqrt(Math.Pow(stdSchuss.xSpeed, 2)+Math.Pow(stdSchuss.ySpeed, 2))*0.0003f;
                        if (Panzerplayer[_lastPlayer].Health< 0)
                        {
                            Panzerplayer[_lastPlayer].Health = 0;
                        }
                        changePlayer();
                    }

                    if (randomeSpielfeld.getField((int)prodx, (int)prody) == 2 && removestate == 0 && _t > 0.05)     //wenn Boden berührt
                    {
                        _gamestate = 0;
                        createhole((int)prodx, (int)prody, 25);
                        Panzerplayer[_Playertomove].Status.State = 0;
                        removestate = 1;
                        changePlayer();

                    }
                    Wincheck();

                }
                if (prodx < 0 || prodx > randomeSpielfeld.Width || prody >500)        //1 mal pro Frame: Prüfung ob außerhalb von Maprand   
                {
                    _gamestate = 0;
                    Panzerplayer[0].Status.State = 0;
                    Panzerplayer[1].Status.State = 0;
                    changePlayer();
                    return ;
                }
                else
                {
                    stdSchuss.xPos = (int)prodx;
                    stdSchuss.yPos = (int)prody;
                }


                texthealth1.Text = "Leben:                         " + Math.Floor(Panzerplayer[0].Health * 100f);
                progressbarhealth1.Progress = (float)Panzerplayer[0].Health;
                texthealth2.Text = "Leben:                         " + Math.Floor(Panzerplayer[1].Health * 100f);
                progressbarhealth2.Progress = (float)Panzerplayer[1].Health;
                _lastt = _t;
            }
        }
        public void changePlayer()
        {
            Panzerplayer[_Playertomove].Fuel = 1f;
            Panzerplayer[_Playertomove].Status.CanShootnoMove = false;
            Panzerplayer[0].updatePosition(randomeSpielfeld);
            Panzerplayer[1].updatePosition(randomeSpielfeld);
            if (_Playertomove == 0)
            {
                _lastPlayer = 0;
                _Playertomove = 1;
                textplayeranzeige1.TextColor = Colors.Transparent;
                textplayeranzeige2.TextColor = Colors.Blue;
                
            }

            else
            {
                _lastPlayer = 1;
                _Playertomove = 0;
                textplayeranzeige1.TextColor = Colors.Red;
                textplayeranzeige2.TextColor = Colors.Transparent;

            }


            
        }

        public void Wincheck()
        {
            if (Panzerplayer[0].Health == 0 || Panzerplayer[1].Health ==0)
            {
                _KgameManager.Objects.Clear();
                K_Text textwhowon = new K_Text();
                textwhowon.xPos = 20;
                textwhowon.yPos = 200;
                textwhowon.FontSize = 80;
                textwhowon.BackgroundColor = Colors.Transparent;
                _KgameManager.Objects.Add(textwhowon);
                if (Panzerplayer[0].Health == 0) {
                    textwhowon.Text = "Player 1 won";
                    textwhowon.TextColor = Colors.Red;
                }
                else
                {
                    textwhowon.Text = "Player 2 won!";
                    textwhowon.TextColor = Colors.Blue;
                }
            }
        }

    }
    
}




