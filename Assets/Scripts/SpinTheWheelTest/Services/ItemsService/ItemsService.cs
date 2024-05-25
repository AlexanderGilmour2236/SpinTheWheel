using SpinTheWheelTest.Configs;
using SpinTheWheelTest.Services.Player;
using UnityEngine;

namespace SpinTheWheelTest.Services
{
    public class ItemsService : IItemsService
    {
        private readonly IPlayerService _playerService;
        private readonly IConfigService _configService;

        public ItemsService(IPlayerService playerService, IConfigService configService)
        {
            _playerService = playerService;
            _configService = configService;
        }
        
        public void ApplyItem(string itemID)
        {
            _configService.ItemsConfig.GetItemByID(itemID).ApplyItem(this);
        }

        public void ApplyItem(CurrencyItemConfig itemConfig)
        {
            // TODO: apply currency 
            Debug.Log($"Added {itemConfig.Count} {itemConfig.CurrencyType} currency");
        }

        public void ApplyItem(UpgradeItemConfig itemConfig)
        {
            _playerService.PlayerItems.Add(itemConfig.ItemID);
        }
    }
}