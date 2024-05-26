using System;
using System.Collections.Generic;

namespace SpinTheWheelTest.Services.Player
{
    public interface IPlayerService
    {
        public List<string> PlayerItems { get; }
        int PlayerCurrency { get; set; }
        bool HasItem(string id);
    }
}