using System.Collections.Generic;
using LuckyWheel.Configs;
using LuckyWheel.Services;

namespace SpinTheWheelTest.ViewModel
{
    public class SpinTheWheelWindowViewModel : ISpinTheWheelWindowViewModel 
    {
        private readonly ILuckyWheelService _luckyWheelService;

        public SpinTheWheelWindowViewModel(ILuckyWheelService luckyWheelService)
        {
            _luckyWheelService = luckyWheelService;
        }
        
        public List<string> GetCurrentLuckyWheelsItems()
        {
            return _luckyWheelService.GetCurrentSpinPossibleItems();
        }
    }
}