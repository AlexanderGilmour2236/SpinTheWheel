using SpinTheWheelTest.ViewModel;
using UnityEngine;

namespace SpinTheWheelTest.UI.Windows
{
    public class SpinTheWheelWindow : MonoBehaviour
    {
        private ISpinTheWheelWindowViewModel _spinTheWheelWindowVM;

        public void Show()
        {
            gameObject.SetActive(true);
            foreach (string itemID in _spinTheWheelWindowVM.GetCurrentLuckyWheelsItems())
            {
                Debug.Log(itemID);
            }
        }


        public void Initialize(ISpinTheWheelWindowViewModel spinTheWheelWindowVM)
        {
            _spinTheWheelWindowVM = spinTheWheelWindowVM;
        }
    }
}