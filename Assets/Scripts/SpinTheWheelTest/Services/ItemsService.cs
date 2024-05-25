using SpinTheWheelTest.Services.Player;

namespace SpinTheWheelTest.Services
{
    public class ItemsService : IItemsService
    {
        private readonly IPlayerService _playerService;

        public ItemsService(IPlayerService playerService)
        {
            _playerService = playerService;
        }
        
        public void ApplyItem(string itemID)
        {
            _playerService.PlayerItems.Add(itemID);    
        }
    }
}