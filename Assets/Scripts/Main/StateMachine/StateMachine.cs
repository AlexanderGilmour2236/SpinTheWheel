namespace Main
{
    public abstract class StateMachine
    {
        protected StatesFactory _statesFactory;
        
        protected IState _activeState;

        public virtual void Enter<TState>()
        {
            ExitCurrentState<TState>();
            _activeState = _statesFactory.Create(typeof(TState));
            _activeState.Enter();
        }

        protected virtual void ExitCurrentState<TState>()
        {
            if (_activeState != null)
            {
                _activeState.Exit();
            }
        }
    }
}