using System;
using System.Collections;
using System.Collections.Generic;
using LuckyWheel.Configs;

namespace SpinTheWheelTest.ViewModel
{
    public interface ISpinTheWheelWindowViewModel
    {
        event Action WheelItemsChange;
        List<ILuckyWheelItemData> GetCurrentLuckyWheelsItems();
        void TrySpin();
    }
}