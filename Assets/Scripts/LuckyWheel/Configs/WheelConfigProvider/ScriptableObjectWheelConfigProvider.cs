using System.Linq;
using LuckyWheel.Configs;
using SpinTheWheelTest.Configs;

namespace LuckyWheel.Configs
{
    public class ScriptableObjectWheelConfigProvider : IWheelConfigProvider
    {
        private readonly WheelOfLuckConfig _wheelOfLuckConfig;

        public ScriptableObjectWheelConfigProvider(WheelOfLuckConfig wheelOfLuckConfig)
        {
            _wheelOfLuckConfig = wheelOfLuckConfig;
        }
        
        public int GetSectorsOnWheelCount()
        {
            return _wheelOfLuckConfig.SectorsOnWheel;
        }

        public int GetConsumableSectorsCount()
        {
            return _wheelOfLuckConfig.ConsumablesCount;
        }

        public int NonConsumableSectorsCount()
        {
            return _wheelOfLuckConfig.NonConsumablesCount;
        }

        public LuckyWheelItemData[] GetPossibleConsumableItems()
        {
            return _wheelOfLuckConfig.PossibleItemIDs.Where((item)=>item.Consumable).ToArray();
        }

        public LuckyWheelItemData[] GetPossibleNonConsumableItems()
        {
            return _wheelOfLuckConfig.PossibleItemIDs.Where((item)=>!item.Consumable).ToArray();
        }

        public string[] FirstRollsItems()
        {
            return _wheelOfLuckConfig.FirstRollsItems;
        }
    }
}