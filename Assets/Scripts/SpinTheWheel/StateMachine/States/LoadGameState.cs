using Main;
using SpinTheWheel.Services;
using SpinTheWheel.View;
using UnityEngine;
using Zenject;

namespace SpinTheWheel.States
{
    public class LoadGameState : IState
    {
        private readonly SpinTheWheelStateMachine _stateMachine;
        private IUIService _uiService;

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
            UIRoot uiRoot = GameObject.FindObjectOfType<UIRoot>();
            _uiService.SetUIRoot(uiRoot);
        }

        public void Exit()
        {
            
        }
    }
}