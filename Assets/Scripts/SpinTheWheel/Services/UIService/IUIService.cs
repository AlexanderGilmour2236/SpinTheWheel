using SpinTheWheel.View;
using WheelOfLuck.UI.Windows;

namespace SpinTheWheel.Services
{
    public interface IUIService
    {
        void SetUIRoot(UIRoot uiRoot);
        SpinTheWheelWindow GetSpinTheWheelWindow();
    }
}