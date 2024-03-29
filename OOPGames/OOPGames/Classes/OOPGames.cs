﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace OOPGames
{
    public class OOPGamesManager
    {
        private static OOPGamesManager _OOPGames;
        IList<IPaintGame> _Painters;
        IList<IGamePlayer> _Players;
        IList<IGameRules> _Rules;

        IList<IGamePlayer> _activePlayers;

        public OOPGamesManager ()
        {
            _Painters = new List<IPaintGame>();
            _Players = new List<IGamePlayer>();
            _Rules = new List<IGameRules>();
            _activePlayers = new List<IGamePlayer>();
        }

        public void RegisterPainter (IPaintGame painter)
        {
            _Painters.Add(painter);
        }

        public void UnregisterPainter(IPaintGame painter)
        {
            _Painters.Remove(painter);
        }

        public void RegisterPlayer(IGamePlayer player)
        {
            _Players.Add(player);
        }

        public void RegisterActivePlayers(IList<IGamePlayer> activePlayers)
        {
            _activePlayers.Clear();
            foreach (IGamePlayer player in activePlayers) {
                _activePlayers.Add(player);
                    }
        }

        public void UnregisterPlayer(IGamePlayer player)
        {
            _Players.Remove(player);
        }

        public void RegisterRules(IGameRules rules)
        {
            _Rules.Add(rules);
        }

        public void unregisterRules(IGameRules rules)
        {
            _Rules.Remove(rules);
        }

        public IEnumerable<IPaintGame> Painters { get { return _Painters; } }

        public IEnumerable<IGamePlayer> Players {  get { return _Players; } }

        public IEnumerable<IGamePlayer> activePlayers { get { return _activePlayers; } }

        public IEnumerable<IGameRules> Rules { get { return _Rules; } }

        public static OOPGamesManager Singleton
        {
            get
            {
                if (_OOPGames == null)
                {
                    _OOPGames = new OOPGamesManager();
                }
                return _OOPGames;
            }
        }

    }

    public class ClickSelection : IClickSelection
    {
        int _ClickX;
        int _ClickY;

        public ClickSelection (int clickX, int clickY)
        {
            _ClickX = clickX;
            _ClickY = clickY;
        }

        public int XClickPos { get { return _ClickX; } }

        public int YClickPos { get { return _ClickY; } }

        public MoveType MoveType { get { return MoveType.click; } }
    }

    public class KeySelection : IKeySelection
    {
        Key _Key;
        int _ClickX = 0;
        int _ClickY = 0;

        public KeySelection(Key key)
        {
            _Key = key;
        }

        public int XClickPos { get { return _ClickX; } }

        public int YClickPos { get { return _ClickY; } }

        public Key Key { get { return _Key; } }

        public MoveType MoveType { get { return MoveType.key; } }
    }
}
