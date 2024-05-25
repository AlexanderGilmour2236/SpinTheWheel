using System;
using System.Collections.Generic;
using LuckyWheel.Configs;
using Random = UnityEngine.Random;

namespace LuckyWheel.Services
{
    public class LuckyLuckyWheelService : ILuckyWheelService 
    {
        private IWheelConfigProvider _wheelConfigProvider;
        
        private int _seed = -1;

        public void SetWheelConfigProvider(IWheelConfigProvider wheelConfigProvider)
        {
            _wheelConfigProvider = wheelConfigProvider;
        }

        public void SetSeed(int seed)
        {
            _seed = seed;
        }

        public List<string> GetCurrentSpinPossibleItems()
        {
            if (!IsConfigValid(_wheelConfigProvider))
            {
                throw new Exception("Config values are not valid");
            }

            List<string> currentSpinItems = new List<string>();

            AddPossibleItems(currentSpinItems, _wheelConfigProvider.GetPossibleConsumableItems(), _wheelConfigProvider.GetConsumableSectorsCount());
            AddPossibleItems(currentSpinItems, _wheelConfigProvider.GetPossibleNonConsumableItems(), _wheelConfigProvider.NonConsumableSectorsCount());

            return currentSpinItems;
        }

        private bool IsConfigValid(IWheelConfigProvider wheelConfigProvider)
        {
            return wheelConfigProvider.GetConsumableSectorsCount() + wheelConfigProvider.NonConsumableSectorsCount()
                   <= wheelConfigProvider.GetSectorsOnWheelCount();
        }

        private void AddPossibleItems(List<string> currentSpinItems, LuckyWheelItemData[] allPossibleItems, int itemsOnWheelCount)
        {
            for (int i = 0; i < itemsOnWheelCount; i++)
            {
                string randomItemID = GetRandomItemFromList(allPossibleItems).ItemID;
                currentSpinItems.Add(randomItemID);
            }
        }

        private LuckyWheelItemData GetRandomItemFromList(LuckyWheelItemData[] items)
        {
            if (_seed != -1)
            {
                Random.InitState(_seed);
            }
            return items[Random.Range(0, items.Length)];
        }
    }
}