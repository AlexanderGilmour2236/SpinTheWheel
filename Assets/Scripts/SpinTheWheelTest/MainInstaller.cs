using LuckyWheel.Services;
using SpinTheWheelTest.Services;
using SpinTheWheelTest.Services.Player;
using SpinTheWheelTest.Factories;
using SpinTheWheelTest.States;
using Zenject;

namespace SpinTheWheelTest
{
    public class MainInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            InstallStateMachine();
            InstallStates();
            InstallServices();
            InstallFactories();
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
            Container.BindInterfacesAndSelfTo<UIService>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<WheelService>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<LuckyWheelService>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<ConfigService>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<PlayerService>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<ItemsService>().AsSingle().NonLazy();
        }

        private void InstallFactories()
        {
            Container.BindInterfacesAndSelfTo<UIFactory>().AsSingle().NonLazy();
        }
    }
}