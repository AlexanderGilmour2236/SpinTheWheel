using SpinTheWheel.States;
using UnityEngine;
using Zenject;

namespace Main
{
    public class GameStarter : MonoBehaviour
    {
        private IMainStateMachine _stateMachine;

        [Inject]
        public void Constructor(IMainStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }
        
        private void Start()
        {
            Application.targetFrameRate = 60;
            _stateMachine.Start();
        }
    }
}