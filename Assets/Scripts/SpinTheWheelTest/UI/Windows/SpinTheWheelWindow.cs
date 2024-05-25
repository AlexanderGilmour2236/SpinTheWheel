using System;
using System.Text;
using LuckyWheel.Configs;
using SpinTheWheelTest.ViewModel;
using UnityEngine;
using UnityEngine.UI;

namespace SpinTheWheelTest.UI.Windows
{
    public class SpinTheWheelWindow : MonoBehaviour
    {
        [SerializeField] private Button _spinButton;
        
        private ISpinTheWheelWindowViewModel _spinTheWheelWindowVM;

        public void Initialize(ISpinTheWheelWindowViewModel spinTheWheelWindowVM)
        {
            _spinTheWheelWindowVM = spinTheWheelWindowVM;
            _spinTheWheelWindowVM.WheelItemsChange += UpdateItemsOnWheel;
        }

        private void Awake()
        {
            _spinButton.onClick.AddListener(OnSpinClick);
        }

        private void OnSpinClick()
        {
            _spinTheWheelWindowVM.TrySpin();
        }

        public void Show()
        {
            gameObject.SetActive(true);
            UpdateItemsOnWheel();
        }

        private void UpdateItemsOnWheel()
        {
            StringBuilder itemsString = new StringBuilder();
            foreach (LuckyWheelItemData itemData in _spinTheWheelWindowVM.GetCurrentLuckyWheelsItems())
            {
                itemsString.Append(itemData.ItemID + ", ");
            }
            Debug.Log(itemsString);
        }
    }
}