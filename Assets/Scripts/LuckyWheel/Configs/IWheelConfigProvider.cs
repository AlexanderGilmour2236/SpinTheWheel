namespace LuckyWheel.Configs
{
    public interface IWheelConfigProvider
    {
        public int GetSectorsOnWheelCount();
        
        public int GetConsumableSectorsCount();
        public int NonConsumableSectorsCount();

        public LuckyWheelItemData[] GetPossibleConsumableItems();
        public LuckyWheelItemData[] GetPossibleNonConsumableItems();

        public string[] FirstRollsItems();
    }
}