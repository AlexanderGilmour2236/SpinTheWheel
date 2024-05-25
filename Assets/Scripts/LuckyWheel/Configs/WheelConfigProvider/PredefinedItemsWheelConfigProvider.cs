using System.Collections.Generic;
using System.Linq;

namespace LuckyWheel.Configs
{
    public class PredefinedItemsWheelConfigProvider : IWheelConfigProvider
    {
        private readonly PredefinedLuckyWheelConfig _predefinedLuckyWheelConfig;

        public PredefinedItemsWheelConfigProvider(PredefinedLuckyWheelConfig predefinedLuckyWheelConfig)
        {
            _predefinedLuckyWheelConfig = predefinedLuckyWheelConfig;
        }
        
        public LuckyWheelSpinData GetLuckyWheelSpinData()
        {
            return new LuckyWheelSpinData()
            {
                SectorsCount = _predefinedLuckyWheelConfig.LuckyWheelItemData.Length,
                ConsumablesCount = GetPossibleConsumableItems().Length,
                NonConsumablesCount = GetPossibleNonConsumableItems().Length
            };
        }

        public LuckyWheelItemData[] GetPossibleConsumableItems()
        {
            return _predefinedLuckyWheelConfig.LuckyWheelItemData.Where(item => item.Consumable).ToArray();
        }

        public LuckyWheelItemData[] GetPossibleNonConsumableItems()
        {
            return _predefinedLuckyWheelConfig.LuckyWheelItemData.Where(item => !item.Consumable).ToArray();
        }

        public PredefinedLuckyWheelConfig[] GetPredefinedLuckyWheelConfigs()
        {
            return new [] { _predefinedLuckyWheelConfig };
        }
    }
}