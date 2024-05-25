using SpinTheWheelTest.Configs;

namespace SpinTheWheelTest.Services
{
    public interface IItemsService
    {
        void ApplyItem(string itemID);
        void ApplyItem(CurrencyItemConfig itemConfig);
        void ApplyItem(UpgradeItemConfig itemConfig);
    }
}