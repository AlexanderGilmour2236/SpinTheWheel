using Main;
using SpinTheWheelTest.Services;
using UnityEngine;

namespace SpinTheWheelTest.States
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