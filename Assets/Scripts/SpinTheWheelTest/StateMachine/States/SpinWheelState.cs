using System.Collections.Generic;
using LuckyWheel.Configs;
using LuckyWheel.Services;
using Main;
using SpinTheWheelTest.Services;
using SpinTheWheelTest.Services.Player;
using SpinTheWheelTest.UI.Windows;
using SpinTheWheelTest.ViewModel;
using UnityEngine;

namespace SpinTheWheelTest.States
{
    public class SpinWheelState : IState
    {
        private readonly IUIService _uiService;
        private readonly ILuckyWheelService _luckyWheelService;
        private readonly IPlayerService _playerService;
        private readonly IItemsService _itemsService;

        private ISpinTheWheelWindowViewModel _spinTheWheelWindowVM;
        private IConfigService _configService;

        public SpinWheelState(IUIService uiService, ILuckyWheelService luckyWheelService, IConfigService configService,
            IPlayerService playerService, IItemsService itemsService)
        {
            _uiService = uiService;
            _luckyWheelService = luckyWheelService;
            _configService = configService;
            _playerService = playerService;
            _itemsService = itemsService;
        }
        
        public void Enter()
        {
            Debug.Log("Spin Wheel State");
            
            InitWheelService();
            InitWindow();
            
            _luckyWheelService.ItemRewarded += OnSpinRewardedItem;
        }

        private void OnSpinRewardedItem(string itemID)
        {
            _itemsService.ApplyItem(itemID);
        }

        private void InitWheelService()
        {
            _luckyWheelService.SetWheelConfigProvider(GetWheelConfigProvider());
        }

        private IWheelConfigProvider GetWheelConfigProvider()
        {
            IWheelConfigProvider basicWheelConfigProvider = new ScriptableObjectWheelConfigProvider(_configService.LuckyWheelConfig);
            return new ExcludeItemsWheelConfigProvider(basicWheelConfigProvider, PlayerHasItemCheck);
        }

        private void InitWindow()
        {
            SpinTheWheelWindow spinTheWheelWindow = _uiService.GetSpinTheWheelWindow();

            _spinTheWheelWindowVM = new SpinTheWheelWindowViewModel(_luckyWheelService);
            spinTheWheelWindow.Initialize(_spinTheWheelWindowVM);
            spinTheWheelWindow.Show();
        }

        private bool PlayerHasItemCheck(string id)
        {
            return _playerService.HasItem(id);
        }

        public void Exit()
        {
            _spinTheWheelWindowVM = null;
            _luckyWheelService.ItemRewarded -= OnSpinRewardedItem;
        }
    }
}