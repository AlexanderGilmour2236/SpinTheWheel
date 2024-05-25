using SpinTheWheelTest.Services;
using UnityEngine;

namespace SpinTheWheelTest.Configs
{
    [CreateAssetMenu(fileName = "UpgradeItemConfig", menuName = "Configs/Items/UpgradeItemConfig")]
    public class UpgradeItemConfig : ItemConfig
    {
        public override void ApplyItem(IItemsService itemsService)
        {
            itemsService.ApplyItem(this);
        }
    }
}