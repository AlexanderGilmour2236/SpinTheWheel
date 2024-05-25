using Main;

namespace SpinTheWheel.States
{
    public class SpinTheWheelStateMachine : StateMachine, IMainStateMachine
    {
        private IState _activeState;

        public SpinTheWheelStateMachine(SpinTheWheelStatsFactory statesFactory)
        {
            _statesFactory = statesFactory;
        }

        public void Start()
        {
            _statesFactory.Create(typeof(LoadGameState)).Enter();
        }
    }
}