using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace OOPGames.Classes.Gruppe_B
{
    public class Werte
    {
        public int variante
        {
            get;
            set;
        }
        public int score
        {
            get;
            set;
        }
    }
    public class B_ComputerPlayer : IComputerTicTacToePlayer
    {

        int _PlayerNumber = 0;
        int otherPlayerNumber = 0;
        private int[] origBoard = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };




        public string Name { get { return "GruppeBComputerPlayer"; } }

        public int PlayerNumber { get { return _PlayerNumber; } }

        public IGamePlayer Clone()
        {
            B_ComputerPlayer other = new B_ComputerPlayer();
            other.SetPlayerNumber(_PlayerNumber);
            return other;
        }

        private bool winning(int player, int[] newBoard)
        {
            if (
                (newBoard[0] == player && newBoard[1] == player && newBoard[2] == player) ||
                (newBoard[3] == player && newBoard[4] == player && newBoard[5] == player) ||
                (newBoard[6] == player && newBoard[7] == player && newBoard[8] == player) ||
                (newBoard[0] == player && newBoard[3] == player && newBoard[6] == player) ||
                (newBoard[1] == player && newBoard[4] == player && newBoard[7] == player) ||
                (newBoard[2] == player && newBoard[5] == player && newBoard[8] == player) ||
                (newBoard[0] == player && newBoard[4] == player && newBoard[8] == player) ||
                (newBoard[2] == player && newBoard[4] == player && newBoard[6] == player)
 )
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private List<int> emptyIndexes(int[] board)
        {
            List<int> freieStellen = new List<int>();

            for (int i = 0; i < 9; i++)
            {
                if (board[i] == 0)
                {
                    freieStellen.Add(i);

                }
            }

            return freieStellen;
        }

        int countt = 0;
        private Werte MiniMax(int[] newBoard, int player)
        {
            List<int> freieStellen = new List<int>();
            //List<int> Score = new List<int>();
            List<Werte> ScoreVariante = new List<Werte>();
            Werte objektScoreVariante = new Werte();






            freieStellen = emptyIndexes(newBoard);

            if (countt == 0)
            {
                for (int i = 0; i < freieStellen.Count; i++)
                {
                    Console.WriteLine("Freie Stellen");
                    Console.WriteLine(freieStellen[i]);
                    countt++;
                }
            }

            if (winning(otherPlayerNumber, newBoard))
            {
                objektScoreVariante.score = -10;
                objektScoreVariante.variante = 0;
                return objektScoreVariante;
            }
            else if (winning(_PlayerNumber, newBoard))
            {
                objektScoreVariante.score = 10;
                objektScoreVariante.variante = 0;
                return objektScoreVariante;
            }
            else if (freieStellen.Count == 0)
            {
                objektScoreVariante.score = 0;
                objektScoreVariante.variante = 0;
                return objektScoreVariante;
            }

            for (int i = 0; i < freieStellen.Count; i++)
            {
                newBoard[freieStellen[i]] = player;

                if (player == _PlayerNumber)
                {
                    ScoreVariante.Add(MiniMax(newBoard, otherPlayerNumber));
                }
                else
                {
                    ScoreVariante.Add(MiniMax(newBoard, _PlayerNumber));
                }
                newBoard[freieStellen[i]] = 0;

            }

            int c = 0;
            if (player == _PlayerNumber)
            {
                int bestScore = -10000;
                for (int i = 0; i < ScoreVariante.Count; i++)
                {
                    if (ScoreVariante[i].score > bestScore)
                    {
                        bestScore = ScoreVariante[i].score;
                        objektScoreVariante.variante = freieStellen[i];
                        objektScoreVariante.score = ScoreVariante[i].score;

                        c = i;
                    }
                }
            }
            else
            {
                int bestScore = 10000;

                for (int i = 0; i < ScoreVariante.Count; i++)
                {
                    if (ScoreVariante[i].score < bestScore)
                    {
                        bestScore = ScoreVariante[i].score;
                        objektScoreVariante.variante = freieStellen[i];
                        objektScoreVariante.score = ScoreVariante[i].score;
                        c = i;
                    }
                }

            }
            return objektScoreVariante;

        }

        public ITicTacToeMove GetMove(ITicTacToeField field)
        {
            // Array origBoard über aktuelles Spielfeld
            int count = 0;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    origBoard[count] = field[i, j];
                    count++;
                }
            }
            Console.WriteLine("New Field");
            for (int i = 0; i < 9; i++)
            {

                Console.WriteLine(origBoard[i]);


            }
            // Beste Spielzüge heruasfinden

            Werte bestSpot = MiniMax(origBoard, _PlayerNumber);
            Console.WriteLine("Bester Zug:");
            Console.WriteLine(bestSpot);

            if (bestSpot.variante == 0)
            {
                return new TicTacToeMove(0, 0, _PlayerNumber);
            }
            if (bestSpot.variante == 1)
            {
                return new TicTacToeMove(0, 1, _PlayerNumber);
            }
            if (bestSpot.variante == 2)
            {
                return new TicTacToeMove(0, 2, _PlayerNumber);
            }
            if (bestSpot.variante == 3)
            {
                return new TicTacToeMove(1, 0, _PlayerNumber);
            }
            if (bestSpot.variante == 4)
            {
                return new TicTacToeMove(1, 1, _PlayerNumber);
            }
            if (bestSpot.variante == 5)
            {
                return new TicTacToeMove(1, 2, _PlayerNumber);
            }
            if (bestSpot.variante == 6)
            {
                return new TicTacToeMove(2, 0, _PlayerNumber);
            }
            if (bestSpot.variante == 7)
            {
                return new TicTacToeMove(2, 1, _PlayerNumber);
            }
            if (bestSpot.variante == 8)
            {
                return new TicTacToeMove(2, 2, _PlayerNumber);
            }
            return new TicTacToeMove(2, 2, _PlayerNumber);


        }

        public void SetPlayerNumber(int playerNumber)
        {
            _PlayerNumber = playerNumber;

            if (_PlayerNumber == 1)
            {
                otherPlayerNumber = 2;
            }
            else { otherPlayerNumber = 1; }
        }

        public IPlayMove GetMove(IGameField field)
        {
            if (field is ITicTacToeField)
            {
                return GetMove((ITicTacToeField)field);
            }
            else
            {
                return null;
            }
        }

        public bool CanBeRuledBy(IGameRules rules)
        {
            return rules is ITicTacToeRules; ;
        }
    }
}