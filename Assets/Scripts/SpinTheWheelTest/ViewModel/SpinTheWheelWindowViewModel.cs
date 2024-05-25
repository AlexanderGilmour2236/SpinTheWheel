using System;
using System.Collections.Generic;
using LuckyWheel.Configs;
using LuckyWheel.Services;
using UnityEngine;

namespace SpinTheWheelTest.ViewModel
{
    public class SpinTheWheelWindowViewModel : ISpinTheWheelWindowViewModel
    {
        public event Action WheelItemsChange;
        
        private readonly ILuckyWheelService _luckyWheelService;

        public SpinTheWheelWindowViewModel(ILuckyWheelService luckyWheelService)
        {
            _luckyWheelService = luckyWheelService;
        }
        
        public List<LuckyWheelItemData> GetCurrentLuckyWheelsItems()
        {
            return _luckyWheelService.GetCurrentSpinPossibleItems();
        }

        public void TrySpin()
        {
            _luckyWheelService.TrySpin();
            WheelItemsChange?.Invoke();
        }
    }
}