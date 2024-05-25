using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Main
{
    public abstract class StatesFactory
    {
        protected Dictionary<Type,Func<IState>> _states;

        public StatesFactory(DiContainer container)
        {
            _states = RegisterStates(container);
        }

        protected abstract Dictionary<Type, Func<IState>> RegisterStates(DiContainer container);

        public IState Create(Type type)
        {
            if (_states == null || _states.Count == 0)
            {
                throw new Exception($"State factory has not been initialized!");
            }
            if (!_states.ContainsKey(type))
            {
                throw new KeyNotFoundException($"State '{type}' has not been registered in {this.GetType()} factory!");
            }
            return _states[type]();
        }
    }
}