using System;
using System.Collections.Generic;
using LuckyWheel.Configs;
using LuckyWheel.Services;
using Main;
using SpinTheWheel.Services;
using SpinTheWheelTest.Services;
using SpinTheWheelTest.UI.Windows;
using SpinTheWheelTest.ViewModel;
using UnityEngine;

namespace SpinTheWheelTest.States
{
    public class SpinWheelState : IState
    {
        private readonly IUIService _uiService;
        private readonly ILuckyWheelService _luckyWheelService;
        private ISpinTheWheelWindowViewModel _spinTheWheelWindowVM;
        private IConfigService _configService;
        private HashSet<string> _playerItems = new HashSet<string>();

        public SpinWheelState(IUIService uiService, ILuckyWheelService luckyWheelService, IConfigService configService)
        {
            _uiService = uiService;
            _luckyWheelService = luckyWheelService;
            _configService = configService;
        }
        
        public void Enter()
        {
            Debug.Log("Spin Wheel State");

            InitWheelService();
            InitWindow();
        }

        private void InitWheelService()
        {
            IWheelConfigProvider basicWheelConfigProvider = new ScriptableObjectWheelConfigProvider(_configService.LuckyWheelConfig);
            
            _luckyWheelService.SetWheelConfigProvider
            (
                new ExcludeAlreadyPickedItemsWheelConfigProvider(basicWheelConfigProvider, PlayerHasItemCheck)
            );
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
            return _playerItems.Contains(id);
        }

        public void Exit()
        {
            _spinTheWheelWindowVM = null;
        }
    }
}