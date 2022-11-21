using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPGames
{
    public interface IGameRulesB : IGameRules
    {
        event EventHandler<EventArgs> TimeEvent;
        void OnPlayerChange(object source, RulesEventArgs e);

       
    }


    public class RulesEventArgs : EventArgs
    {
        public IGameRules gameRules { get; set; }
    }
}
