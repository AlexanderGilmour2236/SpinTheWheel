using SpinTheWheelTest.Configs;

namespace SpinTheWheelTest.Services
{
    public interface IConfigService
    {
        public WheelOfLuckConfig LuckyWheelConfig { get; }
    }
}