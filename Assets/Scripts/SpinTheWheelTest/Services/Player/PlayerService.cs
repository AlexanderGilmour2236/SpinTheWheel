using System;
using System.Collections.Generic;
using System.Linq;

namespace SpinTheWheelTest.Services.Player
{
    public class PlayerService : IPlayerService
    {
        private List<string> _playerItems = new List<string>();
        private int _playerCurrency;

        public List<string> PlayerItems
        {
            get { return _playerItems; }
        }

        // Temporary solution
        public int PlayerCurrency
        {
            get { return _playerCurrency; }
            set { _playerCurrency = value; }
        }

        public bool HasItem(string id)
        {
            return PlayerItems.Contains(id);
        }
    }
}