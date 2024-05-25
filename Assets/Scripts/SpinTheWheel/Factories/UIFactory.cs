using UnityEngine;
using WheelOfLuck.UI.Windows;

namespace SpinTheWheel.Factories
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