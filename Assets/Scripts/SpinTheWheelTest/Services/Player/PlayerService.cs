using System.Collections.Generic;
using System.Linq;

namespace SpinTheWheelTest.Services.Player
{
    public class PlayerService : IPlayerService
    {
        private List<string> _playerItems = new List<string>();

        public List<string> PlayerItems
        {
            get { return _playerItems; }
        }

        public bool HasItem(string id)
        {
            return PlayerItems.Contains(id);
        }
    }
}