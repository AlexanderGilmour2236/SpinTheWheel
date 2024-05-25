﻿using LuckyWheel.Services;
using SpinTheWheel.Services;
using SpinTheWheelTest.Factories;
using SpinTheWheelTest.Services;
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
            Container.BindInterfacesAndSelfTo<UIService>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<WheelService>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<LuckyLuckyWheelService>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<ConfigService>().AsSingle().NonLazy();
        }

        private void InstallFactories()
        {
            Container.BindInterfacesAndSelfTo<UIFactory>().AsSingle().NonLazy();
        }

        private void InstallControllers()
        {
        }
    }
}