using System.Collections;
using System.Collections.Generic;
using LuckyWheel.Configs;

namespace SpinTheWheelTest.ViewModel
{
    public interface ISpinTheWheelWindowViewModel
    {
        List<string> GetCurrentLuckyWheelsItems();
    }
}