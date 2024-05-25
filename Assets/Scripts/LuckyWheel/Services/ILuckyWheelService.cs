using System.Collections.Generic;
using LuckyWheel.Configs;

namespace LuckyWheel.Services
{
    public interface ILuckyWheelService
    {
        void SetWheelConfigProvider(IWheelConfigProvider wheelConfigProvider);
        List<string> GetCurrentSpinPossibleItems();
        void SetSeed(int seed);
    }
}