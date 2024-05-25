using Main;
using UnityEngine;

namespace SpinTheWheel.States
{
    public class SpinWheelState : IState
    {
        public void Enter()
        {
            Debug.Log("Spin Wheel State");

        }

        public void Exit()
        {
        }
    }
}