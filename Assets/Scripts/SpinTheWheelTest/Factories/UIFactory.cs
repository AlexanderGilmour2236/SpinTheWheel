using UnityEngine;
using SpinTheWheelTest.UI.Windows;

namespace SpinTheWheelTest.Factories
{
    public interface IUIFactory
    {
        SpinTheWheelWindow CreateSpinTheWheelWindow();
    }
    
    public class UIFactory : IUIFactory
    {
        public SpinTheWheelWindow CreateSpinTheWheelWindow()
        {
            return Instantiate(ResourcePath.SpinTheWheelWindow).GetComponent<SpinTheWheelWindow>();
        }

        private GameObject Instantiate(string path)
        {
            return Object.Instantiate(Resources.Load<GameObject>(path));
        }
    }
}