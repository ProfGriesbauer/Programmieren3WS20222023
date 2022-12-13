using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPGames.Classes.Gruppe_K
{
    abstract class K_RulesPanzer
    {
        protected bool _movePossible = false;
        public void resetMovePossible() { _movePossible = false; }
    }
}
