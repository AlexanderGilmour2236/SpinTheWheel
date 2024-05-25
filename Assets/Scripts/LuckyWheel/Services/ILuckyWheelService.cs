using System;
using System.Collections.Generic;
using LuckyWheel.Configs;

namespace LuckyWheel.Services
{
    public interface ILuckyWheelService
    {
        event Action<string> ItemRewarded;
        void SetWheelConfigProvider(IWheelConfigProvider wheelConfigProvider);
        List<LuckyWheelItemData> GetCurrentSpinPossibleItems();
        void TrySpin();
    }
}