using SpinTheWheelTest.UI.Windows;
using SpinTheWheelTest.View;

namespace SpinTheWheelTest.Services
{
    public interface IUIService
    {
        void SetUIRoot(UIRoot uiRoot);
        SpinTheWheelWindow GetSpinTheWheelWindow();
    }
}