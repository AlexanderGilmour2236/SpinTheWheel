using Main;
using SpinTheWheel.Services;
using SpinTheWheel.States;
using UnityEngine;
using Zenject;

namespace SpinTheWheel
{
    public class MainInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            InstallStateMachine();
            InstallStates();
            InstallServices();
            InstallControllers();
        }

        private void InstallStateMachine()
        {
            Container.BindInterfacesAndSelfTo<SpinTheWheelStateMachine>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<SpinTheWheelStatsFactory>().AsSingle().NonLazy();
            
        }

        private void InstallStates()
        {
            Container.BindInterfacesAndSelfTo<LoadGameState>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<SpinWheelState>().AsSingle().NonLazy();
        }

        private void InstallServices()
        {
            Container.BindInterfacesAndSelfTo<WheelService>().AsSingle().NonLazy();
        }

        private void InstallControllers()
        {
        }
    }
}