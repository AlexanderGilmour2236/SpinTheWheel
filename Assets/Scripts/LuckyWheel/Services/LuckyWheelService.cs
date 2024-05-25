using System;
using System.Collections.Generic;
using LuckyWheel.Configs;
using LuckyWheel.Utils;
using UnityEngine;
using Random = UnityEngine.Random;

namespace LuckyWheel.Services
{
    public class LuckyWheelService : ILuckyWheelService 
    {
        private IWheelConfigProvider _wheelConfigProvider;
        private int _currentSeed = 0;

        public event Action<string> ItemRewarded;
        
        public void SetWheelConfigProvider(IWheelConfigProvider wheelConfigProvider)
        {
            _wheelConfigProvider = wheelConfigProvider;
        }

        public List<LuckyWheelItemData> GetCurrentSpinPossibleItems()
        {
            if (!IsConfigValid(_wheelConfigProvider))
            {
                throw new Exception("Config values are not valid");
            }
            
            Random.InitState(GetCurrentSeed());
            
            List<LuckyWheelItemData> currentSpinItems = new List<LuckyWheelItemData>();

            LuckyWheelSpinData luckyWheelSpinData = _wheelConfigProvider.GetLuckyWheelSpinData();
            AddPossibleItems(currentSpinItems, _wheelConfigProvider.GetPossibleConsumableItems(), luckyWheelSpinData.ConsumablesCount);
            AddPossibleItems(currentSpinItems, _wheelConfigProvider.GetPossibleNonConsumableItems(), luckyWheelSpinData.NonConsumablesCount);

            return currentSpinItems;
        }

        private bool IsConfigValid(IWheelConfigProvider wheelConfigProvider)
        {
            LuckyWheelSpinData luckyWheelSpinData = _wheelConfigProvider.GetLuckyWheelSpinData();;

            return wheelConfigProvider != null &&
                   luckyWheelSpinData.ConsumablesCount + luckyWheelSpinData.NonConsumablesCount
                   <= wheelConfigProvider.GetLuckyWheelSpinData().SectorsCount;
        }

        private void AddPossibleItems(List<LuckyWheelItemData> currentSpinItems, LuckyWheelItemData[] allPossibleItems, int itemsOnWheelCount)
        {
            List<ObjectWithProbability<LuckyWheelItemData>> itemsWithProbabilities = new List<ObjectWithProbability<LuckyWheelItemData>>();

            for (int i = 0; i < allPossibleItems.Length; i++)
            {
                LuckyWheelItemData luckyWheelItemData = allPossibleItems[i];
                
                ObjectWithProbability<LuckyWheelItemData> itemWithProbability =
                    new ObjectWithProbability<LuckyWheelItemData>(luckyWheelItemData, luckyWheelItemData.ProbabilityOnWheel);
                
                itemsWithProbabilities.Add(itemWithProbability);
            }
            
            for (int i = 0; i < itemsOnWheelCount; i++)
            {
                ObjectWithProbability<LuckyWheelItemData> item = RandomSelector.GetRandomObject(itemsWithProbabilities);
                currentSpinItems.Add(item.Object);
                if (!item.Object.Consumable)
                {
                    itemsWithProbabilities.Remove(item);
                }
            }
        }

        public void TrySpin()
        {
            string rewardedItemID = GetCurrentSpinItem();
            Debug.Log($"Rewarded with item: {rewardedItemID}");
            _currentSeed++;
            ItemRewarded?.Invoke(rewardedItemID);
        }

        private string GetCurrentSpinItem()
        {
            List<ObjectWithProbability<string>> itemsWithProbabilities = new List<ObjectWithProbability<string>>();

            List<LuckyWheelItemData> currentSpinPossibleItems = GetCurrentSpinPossibleItems();
            foreach (LuckyWheelItemData possibleItem in currentSpinPossibleItems)
            {
                ObjectWithProbability<string> itemWithProbability =
                    new ObjectWithProbability<string>(possibleItem.ItemID, possibleItem.Probability);
                
                itemsWithProbabilities.Add(itemWithProbability);
            }
            
            return RandomSelector.GetRandomObject(itemsWithProbabilities).Object;
        }

        private int GetCurrentSeed()
        {
            return _currentSeed;
        }
    }
}