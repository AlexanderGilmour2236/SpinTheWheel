using Main;
using SpinTheWheel.Services;
using UnityEngine;

namespace SpinTheWheel.States
{
    public class SpinWheelState : IState
    {
        private readonly IUIService _uiService;

        public SpinWheelState(IUIService uiService)
        {
            _uiService = uiService;
        }
        
        public void Enter()
        {
            Debug.Log("Spin Wheel State");
            _uiService.GetSpinTheWheelWindow().Show();
        }

        public void Exit()
        {
        }
    }
}