﻿using OOPGames.Classes.Gruppe_B;
using OOPGames.Classes.Gruppe_F;
using OOPGames.Classes.Gruppe_C;
using OOPGames.Classes.Gruppe_K;
using OOPGames.Classes.GruppeI;
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
            //REGISTER YOUR CLASSES HERE
            //Painters
            OOPGamesManager.Singleton.RegisterPainter(new TicTacToePaint());
            OOPGamesManager.Singleton.RegisterPainter(new K_Painter_Rotating());
            OOPGamesManager.Singleton.RegisterPainter(new B_Painter());
            OOPGamesManager.Singleton.RegisterPainter(new PainterD());
            OOPGamesManager.Singleton.RegisterPainter(new H_TicTacToePaint());
            OOPGamesManager.Singleton.RegisterPainter(new TTTPaint());
            OOPGamesManager.Singleton.RegisterPainter(new E_Painter());
            OOPGamesManager.Singleton.RegisterPainter(new H_TicTacToePaint());
            OOPGamesManager.Singleton.RegisterPainter(new TTTPaint());
            OOPGamesManager.Singleton.RegisterPainter(new PainterI());
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
           // OOPGamesManager.Singleton.RegisterPainter(new C_Painter());
=======
            OOPGamesManager.Singleton.RegisterPainter(new GJ_TicTacToePaint());
            //OOPGamesManager.Singleton.RegisterPainter(new C_Painter());
=======
        
=======
            OOPGamesManager.Singleton.RegisterPainter(new GJ_TicTacToePaint());
>>>>>>> 19de95fc7f6b5bbbf4ec4099a75cf4731e121ee7
            OOPGamesManager.Singleton.RegisterPainter(new TicTacToePaint_G());
>>>>>>> fd03840ce61cc2313ebd5698c0bc5886d70f0a45

>>>>>>> b07f5c33a28ae1577807d06756ba3e8ba6539efa
            //Rules
            OOPGamesManager.Singleton.RegisterRules(new TicTacToeRules());
            OOPGamesManager.Singleton.RegisterRules(new GC_TicTacToeRules());
            OOPGamesManager.Singleton.RegisterRules(new RulesD());
            OOPGamesManager.Singleton.RegisterRules(new E_TicTacToeRules());
            //OOPGamesManager.Singleton.RegisterRules(new H_TicTacToeRules());
            OOPGamesManager.Singleton.RegisterRules(new GJ_TicTacToeRules());

            //Players
            OOPGamesManager.Singleton.RegisterPlayer(new TicTacToeHumanPlayer());
            OOPGamesManager.Singleton.RegisterPlayer(new E_TicTacToeHumanPlayer());
            OOPGamesManager.Singleton.RegisterPlayer(new TicTacToeComputerPlayer());
            OOPGamesManager.Singleton.RegisterPlayer(new TicTacToeComputerPlayerD());
            OOPGamesManager.Singleton.RegisterPlayer(new GJ_TicTacToeHumanPlayer());
            OOPGamesManager.Singleton.RegisterPlayer(new GJ_TicTacToeComputerPlayer());

            InitializeComponent();
            PaintList.ItemsSource = OOPGamesManager.Singleton.Painters;
            Player1List.ItemsSource = OOPGamesManager.Singleton.Players;
            Player2List.ItemsSource = OOPGamesManager.Singleton.Players;
            RulesList.ItemsSource = OOPGamesManager.Singleton.Rules;

            _PaintTimer = new System.Windows.Threading.DispatcherTimer();
            _PaintTimer.Interval = new TimeSpan(0, 0, 0, 0, 40);
            _PaintTimer.Tick += _PaintTimer_Tick;
            _PaintTimer.Start();
        }

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
                _CurrentRules != null && _CurrentRules.CurrentField.CanBePaintedBy(_CurrentPainter))
            {
                _CurrentPlayer = _CurrentPlayer1;
                Status.Text = "Game startet!";
                Status.Text = "Player " + _CurrentPlayer.PlayerNumber + "'s turn!";
                _CurrentRules.ClearField();
                //Hinzufügen der Gewählten Farben
                if( _CurrentPainter is GJ_TicTacToePaint) 
                {
                    ((GJ_TicTacToePaint)_CurrentPainter).X_Color = this.X_Color;
                    ((GJ_TicTacToePaint)_CurrentPainter).O_Color = this.O_Color;
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
                    IPlayMove pm = ((IHumanGamePlayer)_CurrentPlayer).GetMove(new ClickSelection((int)e.GetPosition(PaintCanvas).X, (int)e.GetPosition(PaintCanvas).Y), _CurrentRules.CurrentField);
                    if (pm != null)
                    {
                        _CurrentRules.DoMove(pm);
                        _CurrentPainter.PaintGameField(PaintCanvas, _CurrentRules.CurrentField);
                        _CurrentPlayer = _CurrentPlayer == _CurrentPlayer1 ? _CurrentPlayer2 : _CurrentPlayer1;
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
                        Status.Text = "Player " + _CurrentPlayer.PlayerNumber + "'s turn!";
                    }

                    DoComputerMoves();
                }
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
                
                System.Drawing.Color color = myForm.p1Color;
                p1 = System.Windows.Media.Color.FromArgb(color.A, color.R, color.G, color.B);
                color = myForm.p2Color;
                p2 = System.Windows.Media.Color.FromArgb(color.A, color.R, color.G, color.B);
                
            } while (p1 == System.Windows.Media.Color.FromRgb(255, 255, 255) || p2 == System.Windows.Media.Color.FromRgb(255, 255, 255));
            this.X_Color = p1;
            this.O_Color = p2;
        }
    }
}
