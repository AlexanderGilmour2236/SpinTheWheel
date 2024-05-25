using Main;
using SpinTheWheelTest.Services;
using SpinTheWheelTest.View;
using UnityEngine;
using Zenject;

namespace SpinTheWheelTest.States
{
    public class LoadGameState : IState
    {
        private readonly SpinTheWheelStateMachine _stateMachine;
        private IUIService _uiService;
        private UIRoot _uiRoot;

        [Inject]
        public LoadGameState(SpinTheWheelStateMachine stateMachine, IUIService uiService)
        {
            _stateMachine = stateMachine;
            _uiService = uiService;
        }
        
        public void Enter()
        {
            Debug.Log("Load Game State");
            InitCanvas();
            _stateMachine.Enter<SpinWheelState>();
        }

        private void InitCanvas()
        {
            if (_uiRoot == null)
            {
                _uiRoot = Object.FindObjectOfType<UIRoot>();
                _uiService.SetUIRoot(_uiRoot);   
            }
        }

        public void Exit()
        {
        }
    }
}