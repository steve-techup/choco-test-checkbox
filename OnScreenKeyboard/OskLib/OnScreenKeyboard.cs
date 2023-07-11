using OnScreenKeyboard.OskLib;

namespace Osklib
{
    public static class OnScreenKeyboard
    {

        private static readonly OnScreenKeyboardController _oskController;

        static OnScreenKeyboard()
        {
            _oskController = new ComOnScreenKeyboardController();
        }

        public static void Show()
        {
            _oskController.Show();
        }

        public static bool IsOpened()
        {
            return _oskController.IsOpened();
        }

        public static bool Close()
        {
            return _oskController.Close();
        }
    }
}