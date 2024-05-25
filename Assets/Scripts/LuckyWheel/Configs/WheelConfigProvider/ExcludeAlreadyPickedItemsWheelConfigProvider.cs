using System;
using System.Linq;

namespace LuckyWheel.Configs
{
    public class ExcludeAlreadyPickedItemsWheelConfigProvider : IWheelConfigProvider
    {
        private readonly IWheelConfigProvider _wheelConfigProvider;

        private Func<string, bool> ExcludedCheckMethod;

        public ExcludeAlreadyPickedItemsWheelConfigProvider(IWheelConfigProvider wheelConfigProvider, Func<string, bool> excludedCheckMethod)
        {
            _wheelConfigProvider = wheelConfigProvider;
            ExcludedCheckMethod = excludedCheckMethod;
        }
        
        public int GetSectorsOnWheelCount()
        {
            return _wheelConfigProvider.GetSectorsOnWheelCount();
        }

        public int GetConsumableSectorsCount()
        {
            return GetPossibleConsumableItems().Length;
        }

        public int NonConsumableSectorsCount()
        {
            int nonConsumableSectorsCount = _wheelConfigProvider.NonConsumableSectorsCount();
            
            int consumablesSectorsCount = GetConsumableSectorsCount();
            int possibleConsumablesCount = GetPossibleNonConsumableItems().Length;
            
            if (possibleConsumablesCount < consumablesSectorsCount)
            {
                nonConsumableSectorsCount += consumablesSectorsCount - possibleConsumablesCount;
            }
            
            return nonConsumableSectorsCount;
        }

        public LuckyWheelItemData[] GetPossibleConsumableItems()
        {
            return _wheelConfigProvider.GetPossibleConsumableItems().Where(item => ExcludedCheckMethod(item.ItemID))
                .ToArray();
        }

        public LuckyWheelItemData[] GetPossibleNonConsumableItems()
        {
            return _wheelConfigProvider.GetPossibleNonConsumableItems();
        }

        public string[] FirstRollsItems()
        {
            return _wheelConfigProvider.FirstRollsItems();
        }
    }
}