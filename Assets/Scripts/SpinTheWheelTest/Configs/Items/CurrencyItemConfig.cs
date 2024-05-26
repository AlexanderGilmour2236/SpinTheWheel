using SpinTheWheelTest.Services;
using UnityEngine;

namespace SpinTheWheelTest.Configs
{
    [CreateAssetMenu(fileName = "CurrencyItemConfig", menuName = "Configs/Items/CurrencyItemConfig")]
    public class CurrencyItemConfig : ItemConfig
    {
        public int Count;
        
        public override void ApplyItem(IItemsService itemsService)
        {
            itemsService.ApplyItem(this);
        }
    }
}