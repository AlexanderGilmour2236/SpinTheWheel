using SpinTheWheelTest.Configs;

namespace SpinTheWheel.Services
{
    public interface IConfigService
    {
        public WheelOfLuckConfig LuckyWheelConfig { get; }
    }
}