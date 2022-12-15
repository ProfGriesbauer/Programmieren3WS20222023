using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPGames.Classes.Gruppe_K
{
    abstract class K_RulesPanzer:  IGameRules2
    {
        protected K_GameField randomeSpielfeld = new K_GameField();

        protected K_Projectile stdSchuss = new K_Projectile();

        protected int _gamestate = 0;

        protected bool _movePossible = true;

        public abstract string Name { get; }
        public abstract IGameField CurrentField { get; }
        public abstract bool MovesPossible { get; }

        public abstract int CheckIfPLayerWon();
        public abstract void ClearField();
        public abstract void DoMove(IPlayMove move);

        public  void resetMovePossible() { _movePossible = false; }

        public abstract void StartedGameCall();
        public abstract void TickGameCall();

        protected void createhole(int mx, int my, int r)
        {

            int holeX = mx;
            int holeY = my;
            int holeRX = r;
            int holeRY = r;
            for (int x = -holeRX; x < holeRX; x++)
            {
                for (int y = -holeRY; y < holeRY; y++)
                {
                    float x2 = (holeRY / (float)holeRX) * x * x;
                    float y2 = (holeRX / (float)holeRY) * y * y;
                    if ((x2 + y2) <= holeRX * holeRY)
                    {
                        randomeSpielfeld.setField(x + holeX, y + holeY, 0);
                    }
                }
            }
        }
    }
}
