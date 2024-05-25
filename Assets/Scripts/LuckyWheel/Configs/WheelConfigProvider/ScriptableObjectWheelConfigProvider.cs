﻿using System.Collections.Generic;
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
        
        public int GetSectorsOnWheelCount()
        {
            return _wheelOfLuckConfig.SectorsOnWheel;
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

        public LuckyWheelItemData GetItemForID(string itemID)
        {
            return _idToItemData[itemID];
        }
    }
}