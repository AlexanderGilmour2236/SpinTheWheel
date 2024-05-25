using System.Collections.Generic;

namespace SpinTheWheelTest.Services.Player
{
    public interface IPlayerService
    {
        public List<string> PlayerItems { get; }
        bool HasItem(string id);
    }
}