using SpinTheWheelTest.Factories;
using SpinTheWheelTest.View;
using SpinTheWheelTest.UI.Windows;

namespace SpinTheWheelTest.Services
{
    public class UIService : IUIService
    {
        private readonly IUIFactory _uiFactory;
        
        private UIRoot _uiRoot;
        private SpinTheWheelWindow _spinTheWheelWindow;

        public UIService(IUIFactory uiFactory)
        {
            _uiFactory = uiFactory;
        }
        public void SetUIRoot(UIRoot uiRoot)
        {
            _uiRoot = uiRoot;
        }

        public SpinTheWheelWindow GetSpinTheWheelWindow()
        {
            if (_spinTheWheelWindow == null)
            {
                _spinTheWheelWindow = _uiFactory.CreateSpinTheWheelWindow();
            }
            
            _spinTheWheelWindow.transform.SetParent(_uiRoot.transform, false);
            
            return _spinTheWheelWindow;
        }
    }
}