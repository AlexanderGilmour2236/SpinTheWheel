namespace LuckyWheel.Configs
{
    public interface IWheelConfigProvider
    {
        public LuckyWheelSpinData GetLuckyWheelSpinData();

        public ILuckyWheelItemData[] GetPossibleConsumableItems();
        public ILuckyWheelItemData[] GetPossibleNonConsumableItems();
        public PredefinedLuckyWheelConfig[] GetPredefinedLuckyWheelConfigs();
    }
}