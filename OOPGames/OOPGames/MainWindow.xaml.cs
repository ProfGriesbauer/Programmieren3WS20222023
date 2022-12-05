﻿using OOPGames.Classes.Gruppe_B;
//using OOPGames.Classes.Gruppe_F;
using OOPGames.Classes.Gruppe_C;
using OOPGames.Classes.Gruppe_K;
using OOPGames.Classes.GruppeI;
using OOPGames.Classes.GruppeJ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Drawing;
using Color = System.Drawing.Color;
using static OOPGames.PlayerD;
using OOPGames.Classes.Gruppe_D;
using static OOPGames.Classes.Gruppe_C.C_TicTacToeHumanPlayer;
//using OOPGames.Interfaces.Gruppe_E;
using OOPGames.Classes.Gruppe_E;
using OOPGames.Classes.Gruppe_D.Schiffeverseanken;
using System.Windows.Markup;
using Brushes = System.Windows.Media.Brushes;
using OOPGames.Classes.Gruppe_K.Form;

namespace OOPGames
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        IGamePlayer _CurrentPlayer = null;
        IPaintGame _CurrentPainter = null;
        IGameRules _CurrentRules = null;
        IGamePlayer _CurrentPlayer1 = null;
        IGamePlayer _CurrentPlayer2 = null;
        System.Windows.Media.Color X_Color;
        System.Windows.Media.Color O_Color;



        System.Windows.Threading.DispatcherTimer _PaintTimer = null;

        public MainWindow()
        {
            /////////////////////////
            //RunDinoGame();
            ////////////////////////
            //REGISTER YOUR CLASSES HERE
            //Painters
            OOPGamesManager.Singleton.RegisterPainter(new TicTacToePaint());
            OOPGamesManager.Singleton.RegisterPainter(new TicTacToePaint_G());
            OOPGamesManager.Singleton.RegisterPainter(new K_Painter_Rotating());
            OOPGamesManager.Singleton.RegisterPainter(new K_PaintGameObject());
            OOPGamesManager.Singleton.RegisterPainter(new B_Painter());
            OOPGamesManager.Singleton.RegisterPainter(new PainterD());
            OOPGamesManager.Singleton.RegisterPainter(new H_TicTacToePaint());
            //OOPGamesManager.Singleton.RegisterPainter(new TTTPaint());
            //OOPGamesManager.Singleton.RegisterPainter(new E_vierGewinnt_Painter());
            OOPGamesManager.Singleton.RegisterPainter(new PainterD());
            OOPGamesManager.Singleton.RegisterPainter(new H_TicTacToePaint());
            //OOPGamesManager.Singleton.RegisterPainter(new TTTPaint());
            OOPGamesManager.Singleton.RegisterPainter(new PainterI());
            OOPGamesManager.Singleton.RegisterPainter(new C_Painter());
            OOPGamesManager.Singleton.RegisterPainter(new PainterSV());

            OOPGamesManager.Singleton.RegisterPainter(new GJ_TicTacToePaint());
            OOPGamesManager.Singleton.RegisterPainter(new B_Pong_Painter());

            //Rules
            OOPGamesManager.Singleton.RegisterRules(new TicTacToeRules());

            //OOPGamesManager.Singleton.RegisterRules(new G_I_TiTacToeRules());

            OOPGamesManager.Singleton.RegisterRules(new GC_TicTacToeRules());
            OOPGamesManager.Singleton.RegisterRules(new TicTacToeRules_G());
            OOPGamesManager.Singleton.RegisterRules(new RulesD());
            OOPGamesManager.Singleton.RegisterRules(new BestOfFiveRulesD());
            OOPGamesManager.Singleton.RegisterRules(new E_TicTacToeRules());
            OOPGamesManager.Singleton.RegisterRules(new H_TicTacToeRules());
            OOPGamesManager.Singleton.RegisterRules(new GJ_TicTacToeRules());
            OOPGamesManager.Singleton.RegisterRules(new B_Rules());
            OOPGamesManager.Singleton.RegisterRules(new K_RulesGameObject());
            OOPGamesManager.Singleton.RegisterRules(new TTTRulesF());
            OOPGamesManager.Singleton.RegisterRules(new I_TicTacToeRules());
            OOPGamesManager.Singleton.RegisterRules(new RulerSV());

            OOPGamesManager.Singleton.RegisterRules(new B_Rules_Pong());


            //Players
            OOPGamesManager.Singleton.RegisterPlayer(new TicTacToeHumanPlayer());
            OOPGamesManager.Singleton.RegisterPlayer(new HumanTicTacToePlayer_G());
            OOPGamesManager.Singleton.RegisterPlayer(new ComputerTicTacToePlayer_G());
            OOPGamesManager.Singleton.RegisterPlayer(new E_TicTacToeHumanPlayer());
            OOPGamesManager.Singleton.RegisterPlayer(new E_TicTacToeComputerPlayer_easy());
            OOPGamesManager.Singleton.RegisterPlayer(new E_TicTacToeComputerPlayer_hard());
            OOPGamesManager.Singleton.RegisterPlayer(new TicTacToeComputerPlayer());
            OOPGamesManager.Singleton.RegisterPlayer(new TicTacToeComputerPlayerD());
            OOPGamesManager.Singleton.RegisterPlayer(new TicTacToeHumanPlayerD());
            OOPGamesManager.Singleton.RegisterPlayer(new GJ_TicTacToeHumanPlayer());
            OOPGamesManager.Singleton.RegisterPlayer(new GJ_TicTacToeComputerPlayer());
            OOPGamesManager.Singleton.RegisterPlayer(new C_TicTacToeHumanPlayer());
            OOPGamesManager.Singleton.RegisterPlayer(new C_TicTacToeComputerPlayer());
            OOPGamesManager.Singleton.RegisterPlayer(new B_ComputerPlayer());
            OOPGamesManager.Singleton.RegisterPlayer(new B_HumanPlayer()); 
            OOPGamesManager.Singleton.RegisterPlayer(new TTTAIGruppeF());
            OOPGamesManager.Singleton.RegisterPlayer(new TTTAIGruppeF_v1_2());
            OOPGamesManager.Singleton.RegisterPlayer(new H_TicTacToeHumanPlayer());
            OOPGamesManager.Singleton.RegisterPlayer(new H_TicTacToeComputerPlayer());
            OOPGamesManager.Singleton.RegisterPlayer(new K_Computerplayer());
            OOPGamesManager.Singleton.RegisterPlayer(new Human_PlayerI());

            //OOPGamesManager.Singleton.RegisterPlayer(new B_HumanPlayer_Pong());
            InitializeComponent();
            PaintList.ItemsSource = OOPGamesManager.Singleton.Painters;
            Player1List.ItemsSource = OOPGamesManager.Singleton.Players;
            Player2List.ItemsSource = OOPGamesManager.Singleton.Players;
            RulesList.ItemsSource = OOPGamesManager.Singleton.Rules;

            _PaintTimer = new System.Windows.Threading.DispatcherTimer();
            _PaintTimer.Interval = new TimeSpan(0, 0, 0, 0, 40);
            _PaintTimer.Tick += _PaintTimer_Tick;
            _PaintTimer.Start();


            foreach (IGameRules element in OOPGamesManager.Singleton.Rules)
            {
                if (element is IGameRulesB)
                {
                    IGameRulesB elementRulesB = (IGameRulesB)element;
                    PlayerChanged += elementRulesB.OnPlayerChange;
                    elementRulesB.TimeEvent += OnTimeEnded;

                }
                
            }
                
        }
        /// <summary>
        /// //////////////////////////////////////
        /// </summary>
        
        public void RunDinoGame()
        {
            OOPGames.Classes.GruppeJ.Dino_Game.StartDinoGame();

        }
        /// <summary>
        /// ///////////////////////////////
        /// </summary>

        private void _PaintTimer_Tick(object sender, EventArgs e)
        {
            if (_CurrentPainter != null &&
                _CurrentRules != null)
            {
                if (_CurrentPainter is IPaintGame2 &&
                    _CurrentRules.CurrentField != null &&
                    _CurrentRules.CurrentField.CanBePaintedBy(_CurrentPainter))
                {
                    ((IPaintGame2)_CurrentPainter).TickPaintGameField(PaintCanvas, _CurrentRules.CurrentField);
                }

                if (_CurrentRules is IGameRules2)
                {
                    ((IGameRules2)_CurrentRules).TickGameCall();
                }
            }
        }

        private void StartGame_Click(object sender, RoutedEventArgs e)
        {
            _CurrentPlayer1 = null;
            if (Player1List.SelectedItem is IGamePlayer)
            {
                _CurrentPlayer1 = ((IGamePlayer)Player1List.SelectedItem).Clone();
                _CurrentPlayer1.SetPlayerNumber(1);
            }
            _CurrentPlayer2 = null;
            if (Player2List.SelectedItem is IGamePlayer)
            {
                _CurrentPlayer2 = ((IGamePlayer)Player2List.SelectedItem).Clone();
                _CurrentPlayer2.SetPlayerNumber(2);
            }

            _CurrentPlayer = null;
            _CurrentPainter = PaintList.SelectedItem as IPaintGame;
            _CurrentRules = RulesList.SelectedItem as IGameRules;

            if (_CurrentRules is IGameRules2)
            {
                ((IGameRules2)_CurrentRules).StartedGameCall();
            }

            if (_CurrentPainter != null &&
                _CurrentRules != null && _CurrentPlayer1 != null && _CurrentPlayer2 != null && _CurrentRules.CurrentField.CanBePaintedBy(_CurrentPainter))
            {
                _CurrentPlayer = _CurrentPlayer1;
                Status.Text = "Game startet!";
                Status.Text = "Player " + _CurrentPlayer.PlayerNumber + "'s turn!";
                _CurrentRules.ClearField();
                //Hinzufügen der Gewählten Farben
                if( _CurrentPainter is J_IPaintTicTacToe) 
                {
                    ((J_IPaintTicTacToe)_CurrentPainter).X_Color = this.X_Color;
                    ((J_IPaintTicTacToe)_CurrentPainter).O_Color = this.O_Color;
                }
                _CurrentPainter.PaintGameField(PaintCanvas, _CurrentRules.CurrentField);
                DoComputerMoves();
            }
        }


        private void DoComputerMoves()
        {
            int winner = _CurrentRules.CheckIfPLayerWon();
            if (winner > 0)
            {
                Status.Text = "Player " + winner + " Won!";
            }
            else
            {
                while (_CurrentRules.MovesPossible &&
                       winner <= 0 &&
                       _CurrentPlayer is IComputerGamePlayer)
                {
                    IPlayMove pm = ((IComputerGamePlayer)_CurrentPlayer).GetMove(_CurrentRules.CurrentField);
                    if (pm != null)
                    {
                        _CurrentRules.DoMove(pm);
                        _CurrentPainter.PaintGameField(PaintCanvas, _CurrentRules.CurrentField);
                        _CurrentPlayer = _CurrentPlayer == _CurrentPlayer1 ? _CurrentPlayer2 : _CurrentPlayer1;
                        Status.Text = "Player " + _CurrentPlayer.PlayerNumber + "'s turn!";
                    }

                    winner = _CurrentRules.CheckIfPLayerWon();
                    if (winner > 0)
                    {
                        Status.Text = "Player " + winner + " Won!";
                    }
                }
            }
        }

        private void PaintCanvas_MouseDown(object sender, MouseButtonEventArgs e)
        {
            int winner = _CurrentRules.CheckIfPLayerWon();
           
            
            if (winner > 0)
            {
                Status.Text = "Player " + winner + " Won!";
            }
            else
            {
                if (_CurrentRules.MovesPossible &&
                    _CurrentPlayer is IHumanGamePlayer)
                {
                    /*if (_CurrentPlayer is ISVPlayer) // added by Gruppe D BITTE NICHT LÖSCHEN WIRD NOCH BENÖTIGT LG Tim
                    {
                        int click = 0;

                        if (e.ChangedButton == MouseButton.Left)
                        {
                            click = 1;
                        } 
                        if (e.ChangedButton == MouseButton.Right)
                        {
                            click = 2;
                        }
                        IPlayMove pm = ((IHumanGamePlayer)_CurrentPlayer).GetMove(new ClickSelection((int)e.GetPosition(PaintCanvas).X, (int)e.GetPosition(PaintCanvas).Y), _CurrentRules.CurrentField);
                    }*/
                    IPlayMove pm = ((IHumanGamePlayer)_CurrentPlayer).GetMove(new ClickSelection((int)e.GetPosition(PaintCanvas).X, (int)e.GetPosition(PaintCanvas).Y), _CurrentRules.CurrentField);
                    
                    if (pm != null)
                    {
                        _CurrentRules.DoMove(pm);
                        _CurrentPainter.PaintGameField(PaintCanvas, _CurrentRules.CurrentField);
                        _CurrentPlayer = _CurrentPlayer == _CurrentPlayer1 ? _CurrentPlayer2 : _CurrentPlayer1;
                        OnPlayerChanged(_CurrentRules);
                        Status.Text = "Player " + _CurrentPlayer.PlayerNumber + "'s turn!";
                    }

                    DoComputerMoves();
                }
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            _PaintTimer.Tick -= _PaintTimer_Tick;
            _PaintTimer.Stop();
            _PaintTimer = null;
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (_CurrentRules == null) return;
            int winner = _CurrentRules.CheckIfPLayerWon();
            if (winner > 0)
            {
                Status.Text = "Player" + winner + " Won!";
            }
            else
            {
                if (_CurrentRules.MovesPossible &&
                    _CurrentPlayer is IHumanGamePlayer)
                {
                    IPlayMove pm = ((IHumanGamePlayer)_CurrentPlayer).GetMove(new KeySelection(e.Key), _CurrentRules.CurrentField);
                    if (pm != null)
                    {
                        _CurrentRules.DoMove(pm);
                        _CurrentPlayer = _CurrentPlayer == _CurrentPlayer1 ? _CurrentPlayer2 : _CurrentPlayer1;
                        OnPlayerChanged(_CurrentRules);
                        Status.Text = "Player " + _CurrentPlayer.PlayerNumber + "'s turn!";
                    }

                    DoComputerMoves();
                }
            }
        }



        //Automatisches wechseln nach einer gewissen Zeit 
        public event EventHandler<RulesEventArgs> PlayerChanged;

        protected virtual void OnPlayerChanged(IGameRules currentRules)
        {
            if(PlayerChanged != null)
                PlayerChanged(this, new RulesEventArgs() { gameRules = currentRules});
        }

        public void OnTimeEnded(object source, EventArgs e)
        { 
            if (_CurrentRules is IGameRulesB) 
            {
                _CurrentPlayer = _CurrentPlayer == _CurrentPlayer1 ? _CurrentPlayer2 : _CurrentPlayer1;
                OnPlayerChanged(_CurrentRules);
                //DoComputerMoves();
            }
            
            
        }

        private void GJ_ChooseColor(object sender, RoutedEventArgs e)
        {
            var myForm = new Classes.GruppeJ.Form1();
            var result = myForm.ShowDialog();
            //
            //Color musste hier leider etwas umständlich Konvertiert werden
            //
            System.Windows.Media.Color p1 = System.Windows.Media.Color.FromRgb(255, 255, 255); //^= Weiß
            System.Windows.Media.Color p2 = System.Windows.Media.Color.FromRgb(255, 255, 255); //^= Weiß
            do
            {
               //System.Application.DoEvents();
                System.Drawing.Color color = myForm.p1Color;
                p1 = System.Windows.Media.Color.FromArgb(color.A, color.R, color.G, color.B);
                color = myForm.p2Color;
                p2 = System.Windows.Media.Color.FromArgb(color.A, color.R, color.G, color.B);
                
            } while ((result== System.Windows.Forms.DialogResult.None) && (p1 == System.Windows.Media.Color.FromRgb(255, 255, 255) || p2 == System.Windows.Media.Color.FromRgb(255, 255, 255)));
            
            this.X_Color = p1;
            this.O_Color = p2;
        }



        private void GK_ShowCompatibleRules(object sender, RoutedEventArgs e)
        {
            List<IGameRules> usableRules = new List<IGameRules>();
            IPaintGame selectedPainter = PaintList.SelectedItem as IPaintGame;
            if (selectedPainter != null)
            {
                foreach (IGameRules data in OOPGamesManager.Singleton.Rules)
                {
                    IGameField field= data.CurrentField;
                    if (field!=null && field.CanBePaintedBy(selectedPainter))
                    {
                        usableRules.Add(data);
                    }
                    
                }
            }

            IGameRules selectedRule = GK_OpenSelectionWindow<IGameRules>(usableRules, "Painter Selection" , "Useable Rules");
            if (selectedRule != null)
            {
                RulesList.SelectedItem = selectedRule;
            }
        }
        private void GK_ShowCompatiblePainters(object sender, RoutedEventArgs e)
        {
            List<IPaintGame> usablePainters = new List<IPaintGame>();
            IGameRules selectedRule = RulesList.SelectedItem as IGameRules;
            if (selectedRule != null)
            {
                IGameField field= selectedRule.CurrentField;
                if (field != null)
                {
                    foreach (IPaintGame data in OOPGamesManager.Singleton.Painters)
                    {
                        if (field.CanBePaintedBy(data))
                        {
                            usablePainters.Add(data);
                        }

                    }
                }
            }

            IPaintGame selectedPainter = GK_OpenSelectionWindow<IPaintGame>(usablePainters, "Painter Selection", "Useable Painters");
            if (selectedPainter != null)
            {
                PaintList.SelectedItem=selectedPainter;
            }
        }

        private T GK_OpenSelectionWindow<T>(List<T> data, String title, String listName)
        {
            if (data.Count == 0)
            {
                K_InformationWindow.createInformationPopUp("List Empty","List is empty", true);
                return default(T); 
            }

            K_SelectionWindow selectionform = new K_SelectionWindow();
            selectionform.K_title.Content = listName;
            selectionform.Title = title;
            selectionform.K_selectionList.ItemsSource = data;

            bool result = (bool)selectionform.ShowDialog();
            while (result);

            return selectionform.selectionPerformed ? (T)selectionform.K_selectionList.SelectedItem : default(T); ;
        }


    }
}
