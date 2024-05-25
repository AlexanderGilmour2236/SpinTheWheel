using SpinTheWheelTest.Configs;
using SpinTheWheelTest.Factories;
using UnityEngine;
using Zenject;

namespace SpinTheWheel.Services
{
    public class ConfigService : IConfigService
    {
        public WheelOfLuckConfig LuckyWheelConfig { get; private set; }
        
        public ConfigService()
        {
            LoadConfigs();
        }

        private void LoadConfigs()
        {
            LuckyWheelConfig = Resources.Load<WheelOfLuckConfig>(ResourcePath.LuckyWheelConfig);
        }
    }
}