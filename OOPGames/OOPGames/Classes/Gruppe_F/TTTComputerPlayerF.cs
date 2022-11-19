using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPGames.Classes.Gruppe_F
{
    public class TTTAIGruppeF : BaseComputerTicTacToePlayer
    {
        int _PlayerNumber = 0;

        public override string Name { get { return "AIGruppeF"; } }

        public override int PlayerNumber { get { return _PlayerNumber; } }

        public override IGamePlayer Clone()
        {
            TTTAIGruppeF ttthp = new TTTAIGruppeF();
            ttthp.SetPlayerNumber(_PlayerNumber);
            return ttthp;
        }

        public override ITicTacToeMove GetMove(ITicTacToeField field)
        {
            int AIzerocount = 0;
            int AIspotsum = 0;
            int tempspotnum = 0;
            int temprow = 1;
            int tempcoloumn = 1;
            int c = 1;
            int r = 1;



            // Zeilen, dann Spalten

            for (r = 0; r <= 2; r++)
            {
                for (c = 0; c <= 2; c++)
                {
                    tempspotnum = field[r, c];
                    AIspotsum += tempspotnum;
                    if (tempspotnum == 0)
                    {
                        temprow = r;
                        tempcoloumn = c;
                        AIzerocount++;
                    }

                }
                if (AIzerocount == 1 && AIspotsum % 2 == 0)
                {
                    return new TicTacToeMove(temprow, tempcoloumn, _PlayerNumber);
                }
                AIzerocount = 0;

                AIspotsum = 0;
            }


            // Spalten, dann Zeilen

            for (c = 0; c <= 2; c++)
            {
                for (r = 0; r <= 2; r++)
                {
                    tempspotnum = field[r, c];
                    AIspotsum += tempspotnum;
                    if (tempspotnum == 0)
                    {
                        temprow = r;
                        tempcoloumn = c;
                        AIzerocount++;
                    }

                }
                if (AIzerocount == 1 && AIspotsum % 2 == 0)
                {
                    return new TicTacToeMove(temprow, tempcoloumn, _PlayerNumber);
                }
                AIzerocount = 0;

                AIspotsum = 0;
            }



            // Links oben nach rechts unten

            int c1 = 0;
            for (r = 0; r <= 2; r++)
            {
                tempspotnum = field[r, c1];
                AIspotsum += tempspotnum;
                if (tempspotnum == 0)
                {
                    temprow = r;
                    tempcoloumn = c1;
                    AIzerocount++;
                }

                c1++;
            }
            if (AIzerocount == 1 && AIspotsum % 2 == 0)
            {
                return new TicTacToeMove(temprow, tempcoloumn, _PlayerNumber);
            }
            AIzerocount = 0;

            AIspotsum = 0;


            // Links unten nach rechts oben

            int c2 = 0;
            for (r = 2; r >= 0; r--)
            {
                tempspotnum = field[r, c2];
                AIspotsum += tempspotnum;
                if (tempspotnum == 0)
                {
                    temprow = r;
                    tempcoloumn = c2;
                    AIzerocount++;
                }


                c2++;
            }
            if (AIzerocount == 1 && AIspotsum % 2 == 0)
            {
                return new TicTacToeMove(temprow, tempcoloumn, _PlayerNumber);
            }
            AIzerocount = 0;

            AIspotsum = 0;


            // Keinen kritischen Zug gefunden -> Zufall

            Random rand = new Random();
            int f = rand.Next(0, 8);
            for (int i = 0; i < 9; i++)
            {
                int cRand = f % 3;
                int rRand = ((f - cRand) / 3) % 3;
                if (field[rRand, cRand] <= 0)
                {
                    return new TicTacToeMove(rRand, cRand, _PlayerNumber);
                }
                else
                {
                    f++;
                }
            }

            return null;
        }

        public override void SetPlayerNumber(int playerNumber)
        {
            _PlayerNumber = playerNumber;
        }
    }

    //------------------------------------------------------------------------------
}
