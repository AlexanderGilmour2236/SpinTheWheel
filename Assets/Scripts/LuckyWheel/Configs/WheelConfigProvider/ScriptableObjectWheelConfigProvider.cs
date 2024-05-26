using System.Collections.Generic;
using System.Linq;
using SpinTheWheelTest.Configs;

namespace LuckyWheel.Configs
{
    public class ScriptableObjectWheelConfigProvider : IWheelConfigProvider
    {
        private readonly WheelOfLuckConfig _wheelOfLuckConfig;
        private readonly Dictionary<string, LuckyWheelItemData> _idToItemData = new Dictionary<string, LuckyWheelItemData>();

        public ScriptableObjectWheelConfigProvider(WheelOfLuckConfig wheelOfLuckConfig)
        {
            _wheelOfLuckConfig = wheelOfLuckConfig;
            foreach (LuckyWheelItemData luckyWheelItemData in _wheelOfLuckConfig.PossibleItemIDs)
            {
                _idToItemData[luckyWheelItemData.ItemID] = luckyWheelItemData;
            }
        }

        public LuckyWheelSpinData GetLuckyWheelSpinData()
        {
            return new LuckyWheelSpinData()
            {
                SectorsCount = _wheelOfLuckConfig.SectorsOnWheel,
                ConsumablesCount = _wheelOfLuckConfig.ConsumablesCount,
                NonConsumablesCount = _wheelOfLuckConfig.NonConsumablesCount
            };
        }

        public ILuckyWheelItemData[] GetPossibleConsumableItems()
        {
            return _wheelOfLuckConfig.PossibleItemIDs.Where((item)=>item.Consumable).ToArray();
        }

        public ILuckyWheelItemData[] GetPossibleNonConsumableItems()
        {
            return _wheelOfLuckConfig.PossibleItemIDs.Where((item)=>!item.Consumable).ToArray();
        }

        public PredefinedLuckyWheelConfig[] GetPredefinedLuckyWheelConfigs()
        {
            return _wheelOfLuckConfig.PredefinedItemsConfigs;
        }
    }
}