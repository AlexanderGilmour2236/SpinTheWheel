using Main;
using UnityEngine;
using Zenject;

namespace SpinTheWheel.States
{
    public class LoadGameState : IState
    {
        private readonly SpinTheWheelStateMachine _stateMachine;

        [Inject]
        public LoadGameState(SpinTheWheelStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }
        
        public void Enter()
        {
            Debug.Log("Load Game State");
            InitCanvas();
            _stateMachine.Enter<SpinWheelState>();
        }

        private void InitCanvas()
        {
            
        }

        public void Exit()
        {
            
        }
    }
}