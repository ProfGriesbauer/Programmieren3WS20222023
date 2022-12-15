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
-Fuel hinzufügen
-Grafiken einfügen (Anzeigebalken)



*/

namespace OOPGames.Classes.Gruppe_K
{
    internal class K_Rules1v1 : K_RulesPanzer
    {

        OOPGamesManager _OOPmanager = OOPGamesManager.Singleton;
        K_GameObjectManager _KgameManager = new K_GameObjectManager();
        List<K_Player> Panzerplayer = new List<K_Player>();

        int _gravitation = 500;                                                      //Gravitation in Pixel/(s^2)
        double _t = 0;                                                               //Zeit für Schussberechnung
        double _lastt = 0;
        int _Playertomove ;  //0-> Spieler 1, 1-> Spieler 2

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
                Panzerplayer.Last<K_Player>().Schusspow = 650;
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
                    Panzerplayer.Last<K_Player>().Schusspow = 650;
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


            _KgameManager.GameField = randomeSpielfeld;

            _KgameManager.Objects.Add(randomeSpielfeld);

            _KgameManager.Objects.Add(stdSchuss);

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
                
            

            /*if (_Playertomove == 1)
            {
                BerechnungSchuss();
                resetMovePossible();
            }*/

            /*if (_gamestate == 0)
            {
                stdSchuss.xPos = -20;
                stdSchuss.yPos = 0;

                Panzerplayer[0].updatePosition(randomeSpielfeld);


                if (Panzerplayer[0].Status.State == 1)          //Wenn diese Eigenschaft = 1, wurde Schuss gedrückt
                {
                    _gamestate = 1;
                    _t = 0;
                    _lastt = 0;
                }

            }

            if (_gamestate == 1)
            {
                _t += 0.04;

                double prodx = Panzerplayer[0].xPos;
                double prody = Panzerplayer[0].yPos;
                int removestate = 0;

                for (double _n = _lastt; _n < _t; _n += 0.002)               //20 mal pro Frame Koalisionsberechnung
                {
                    prodx = Panzerplayer[0].xPos + Math.Cos((Math.PI / (double)180) * (Panzerplayer[0].Angle + Panzerplayer[0].Rotation)) * (double)Panzerplayer[0].Schusspow * _n;
                    prody = Panzerplayer[0].yPos + Math.Sin((Math.PI / (double)180) * (Panzerplayer[0].Angle + Panzerplayer[0].Rotation)) * (double)Panzerplayer[0].Schusspow * _n + 0.5 * _gravitation * Math.Pow(_n, 2);


                    if (randomeSpielfeld.getField((int)prodx, (int)prody) == 2 && removestate == 0 && _t > 0.05)     //wenn Boden berührt
                    {
                        _gamestate = 0;
                        createhole((int)prodx, (int)prody, 25);
                        Panzerplayer[0].Status.State = 0;
                        removestate = 1;
                    }
                }

                if (prodx < 0 || prodx > randomeSpielfeld.Width)        //1 mal pro Frame: Prüfung ob außerhalb von Maprand
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
            }*/
        }

        

        public void BerechnungSchuss()
        {
            if (_gamestate == 0)
            {
                Panzerplayer[_Playertomove].Status.CanMove = true;
                stdSchuss.xPos = -20;
                stdSchuss.yPos = 0;

                Panzerplayer[_Playertomove].updatePosition(randomeSpielfeld);
                //_movePossible = true;

                if (Panzerplayer[_Playertomove].Status.State == 1)          //Wenn diese Eigenschaft = 1, wurde Schuss gedrückt
                {
                    stdSchuss.xSpeed = (float)(Math.Cos((Math.PI / (double)180) * (Panzerplayer[_Playertomove].Angle + Panzerplayer[_Playertomove].Rotation)) * (double)Panzerplayer[_Playertomove].Schusspow);
                    stdSchuss.ySpeed = (float)(Math.Sin((Math.PI / (double)180) * (Panzerplayer[_Playertomove].Angle + Panzerplayer[_Playertomove].Rotation)) * (double)Panzerplayer[_Playertomove].Schusspow);
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

                    /*double Abstand = Math.Sqrt(Math.Pow(prodx - randomeTarget.xPos, 2) + Math.Pow(prody - randomeTarget.yPos, 2));

                    if (Abstand < (10 * randomeTarget.Scale))                //wenn Target berührt
                    {
                        Random rando = new Random();
                        _gamestate = 0;
                        randomeTarget.xPos = rando.Next(50, randomeSpielfeld.Width - 50);

                        int ymax = 0;
                        while (randomeSpielfeld.getField(randomeTarget.xPos, ymax) == 0)
                        {
                            ymax++;
                        }

                        randomeTarget.yPos = rando.Next(50, ymax);
                        Panzerplayer[0].Status.State = 0;

                    }*/

                    if (randomeSpielfeld.getField((int)prodx, (int)prody) == 2 && removestate == 0 && _t > 0.05)     //wenn Boden berührt
                    {
                        _gamestate = 0;
                        createhole((int)prodx, (int)prody, 25);
                        Panzerplayer[_Playertomove].Status.State = 0;
                        removestate = 1;
                        changePlayer();

                    }

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
                
                


                _lastt = _t;
            }
        }
        public void changePlayer()
        {
            if (_Playertomove == 0)
            {
                _Playertomove = 1;
            }

            else
            {
                _Playertomove = 0;
            }
        }
    }
    
}




