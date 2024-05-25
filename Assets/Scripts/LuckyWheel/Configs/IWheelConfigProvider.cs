namespace LuckyWheel.Configs
{
    public interface IWheelConfigProvider
    {
        public LuckyWheelSpinData GetLuckyWheelSpinData();

        public LuckyWheelItemData[] GetPossibleConsumableItems();
        public LuckyWheelItemData[] GetPossibleNonConsumableItems();

        public string[] FirstRollsItems();
        LuckyWheelItemData GetItemForID(string itemID);
    }
}