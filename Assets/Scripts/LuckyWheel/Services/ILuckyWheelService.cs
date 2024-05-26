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
        void SetCurrentSpinCount(int spinCount);
        public int CurrentSeed { get; }
        public int CurrentSpinCount { get; }
        void Initialize(IWheelConfigProvider wheelConfigProvider, Func<bool> canSpinMethod, Action chargePlayerAction);
    }
}