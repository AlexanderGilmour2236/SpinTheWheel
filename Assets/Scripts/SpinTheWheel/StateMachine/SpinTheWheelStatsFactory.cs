using System;
using System.Collections.Generic;
using Main;
using Zenject;
using IState = Main.IState;

namespace SpinTheWheel.States
{
    public class SpinTheWheelStatsFactory : StatesFactory
    {
        public SpinTheWheelStatsFactory(DiContainer container) : base(container)
        {
        }

        protected override Dictionary<Type, Func<IState>> RegisterStates(DiContainer container)
        {
            var states = new Dictionary<Type, Func<IState>>()
            {
                {typeof(LoadGameState), container.Resolve<LoadGameState>},
                {typeof(SpinWheelState), container.Resolve<SpinWheelState>},
            };

            return states;
        }
    }
}