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
        private int _currentSpinCount = 0;

        private Func<bool> CanSpinCheckMethod = () => true;
        private Action ChargePlayerAction = null;

        public event Action<string> ItemRewarded;

        public void Initialize(IWheelConfigProvider wheelConfigProvider, Func<bool> canSpinMethod, Action chargePlayerAction)
        {
            SetWheelConfigProvider(wheelConfigProvider);
            CanSpinCheckMethod = canSpinMethod;
            ChargePlayerAction = chargePlayerAction;
        }


        public void SetCurrentSpinCount(int spinCount)
        {
            _currentSpinCount = spinCount;
        }

        public void SetWheelConfigProvider(IWheelConfigProvider wheelConfigProvider)
        {
            _wheelConfigProvider = wheelConfigProvider;
        }

        public List<ILuckyWheelItemData> GetCurrentSpinPossibleItems()
        {
            if (!IsConfigValid(GetWheelConfigProvider()))
            {
                throw new Exception("Config values are not valid");
            }
            
            Random.InitState(GetCurrentSeed());
            
            List<ILuckyWheelItemData> currentSpinItems = new List<ILuckyWheelItemData>();

            LuckyWheelSpinData luckyWheelSpinData = GetWheelConfigProvider().GetLuckyWheelSpinData();
            AddPossibleItems(currentSpinItems, GetWheelConfigProvider().GetPossibleConsumableItems(), luckyWheelSpinData.ConsumablesCount);
            AddPossibleItems(currentSpinItems, GetWheelConfigProvider().GetPossibleNonConsumableItems(), luckyWheelSpinData.NonConsumablesCount);

            return currentSpinItems;
        }

        private bool IsConfigValid(IWheelConfigProvider wheelConfigProvider)
        {
            LuckyWheelSpinData luckyWheelSpinData = GetWheelConfigProvider().GetLuckyWheelSpinData();;

            return wheelConfigProvider != null &&
                   luckyWheelSpinData.ConsumablesCount + luckyWheelSpinData.NonConsumablesCount
                   <= wheelConfigProvider.GetLuckyWheelSpinData().SectorsCount;
        }

        private void AddPossibleItems(List<ILuckyWheelItemData> currentSpinItems, ILuckyWheelItemData[] allPossibleItems, int itemsOnWheelCount)
        {
            List<ObjectWithProbability<ILuckyWheelItemData>> itemsWithProbabilities = new List<ObjectWithProbability<ILuckyWheelItemData>>();

            for (int i = 0; i < allPossibleItems.Length; i++)
            {
                ILuckyWheelItemData luckyWheelItemData = allPossibleItems[i];
                
                ObjectWithProbability<ILuckyWheelItemData> itemWithProbability =
                    new ObjectWithProbability<ILuckyWheelItemData>(luckyWheelItemData, luckyWheelItemData.ProbabilityOnWheel);
                
                itemsWithProbabilities.Add(itemWithProbability);
            }
            
            for (int i = 0; i < itemsOnWheelCount; i++)
            {
                ObjectWithProbability<ILuckyWheelItemData> item = RandomSelector.GetRandomObject(itemsWithProbabilities);
                currentSpinItems.Add(item.Object);
                if (!item.Object.Consumable)
                {
                    itemsWithProbabilities.Remove(item);
                }
            }
        }

        public void TrySpin()
        {
            bool isFreeSpin = IsFreeSpin();
            if (isFreeSpin || CanSpinCheckMethod())
            {
                string rewardedItemID = GetCurrentSpinItem();
            
                _currentSeed++;
                _currentSpinCount++;
            
                Debug.Log($"Rewarded with item: {rewardedItemID}");

                if (!isFreeSpin)
                {
                    ChargePlayerAction?.Invoke();
                }
                else
                {
                    Debug.Log("Free spin!");
                }
                ItemRewarded?.Invoke(rewardedItemID);
            }
            else
            {
                Debug.Log("Cannot spin the wheel");
            }
        }

        private bool IsFreeSpin()
        {
            return _currentSpinCount == 0;
        }

        private string GetCurrentSpinItem()
        {
            if (IsCurrentSpinPredefined())
            {
                return GetPredefinedSpinRewardItem();
            }

            return GetSpinRewardItemBasedOnProbabilities();
        }

        private string GetPredefinedSpinRewardItem()
        {
            PredefinedLuckyWheelConfig[] predefinedLuckyWheelConfigs = _wheelConfigProvider.GetPredefinedLuckyWheelConfigs();
            return predefinedLuckyWheelConfigs[_currentSpinCount].RewardItem.ItemID;
        }

        private string GetSpinRewardItemBasedOnProbabilities()
        {
            List<ObjectWithProbability<string>> itemsWithProbabilities = new List<ObjectWithProbability<string>>();

            List<ILuckyWheelItemData> currentSpinPossibleItems = GetCurrentSpinPossibleItems();
            foreach (ILuckyWheelItemData possibleItem in currentSpinPossibleItems)
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

        private IWheelConfigProvider GetWheelConfigProvider()
        {
            PredefinedLuckyWheelConfig[] predefinedLuckyWheelConfigs = _wheelConfigProvider.GetPredefinedLuckyWheelConfigs();
            
            if (IsCurrentSpinPredefined())
            {
                return new PredefinedItemsWheelConfigProvider(predefinedLuckyWheelConfigs[_currentSpinCount]);
            }

            return _wheelConfigProvider;
        }

        private bool IsCurrentSpinPredefined()
        {
            PredefinedLuckyWheelConfig[] predefinedLuckyWheelConfigs = _wheelConfigProvider.GetPredefinedLuckyWheelConfigs();
            return _currentSpinCount < predefinedLuckyWheelConfigs.Length;
        }

        public int CurrentSeed
        {
            get { return _currentSeed; }
        }

        public int CurrentSpinCount
        {
            get { return _currentSpinCount; }
        }
    }
}