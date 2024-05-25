using System;
using System.Linq;

namespace LuckyWheel.Configs
{
    public class ExcludeItemsWheelConfigProvider : IWheelConfigProvider
    {
        private readonly IWheelConfigProvider _basicWheelConfigProvider;

        private Func<string, bool> IsExcludedMethod;

        public ExcludeItemsWheelConfigProvider(IWheelConfigProvider basicWheelConfigProvider, Func<string, bool> isExcludedMethod)
        {
            _basicWheelConfigProvider = basicWheelConfigProvider;
            IsExcludedMethod = isExcludedMethod;
        }

        public LuckyWheelSpinData GetLuckyWheelSpinData()
        {
            LuckyWheelSpinData basicSpinData = _basicWheelConfigProvider.GetLuckyWheelSpinData();
            int consumablesCount = basicSpinData.ConsumablesCount;
            int nonConsumablesCount = basicSpinData.NonConsumablesCount;

            int possibleNonConsumablesCount = GetPossibleNonConsumableItems().Length;
            if (nonConsumablesCount > possibleNonConsumablesCount)
            {
                nonConsumablesCount = possibleNonConsumablesCount;
                consumablesCount = basicSpinData.SectorsCount - possibleNonConsumablesCount;
            }
            
            return new LuckyWheelSpinData()
            {
                SectorsCount = basicSpinData.SectorsCount,
                ConsumablesCount = consumablesCount,
                NonConsumablesCount = nonConsumablesCount
            };
        }

        public LuckyWheelItemData[] GetPossibleConsumableItems()
        {
            return _basicWheelConfigProvider.GetPossibleConsumableItems();
        }

        public LuckyWheelItemData[] GetPossibleNonConsumableItems()
        {
            return _basicWheelConfigProvider.GetPossibleNonConsumableItems().Where(item => !IsExcludedMethod(item.ItemID))
                .ToArray();
        }

        public string[] FirstRollsItems()
        {
            return _basicWheelConfigProvider.FirstRollsItems();
        }

        public LuckyWheelItemData GetItemForID(string itemID)
        {
            return _basicWheelConfigProvider.GetItemForID(itemID);
        }
    }
}