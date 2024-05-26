namespace LuckyWheel.Configs
{
    public interface ILuckyWheelItemData
    {
        string ItemID { get; }
        
        public int Probability { get; }
        public int ProbabilityOnWheel { get; }
        bool Consumable { get; }
    }
}