using System.Runtime.InteropServices;

namespace OnScreenKeyboard.OskLib.Interop
{
    [ComImport]
    [Guid("2166ee67-71df-4476-8394-0ced2ed05274")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    interface IInputHostManagerBroker
    {
        void GetIhmLocation(out Rect rect, out DisplayMode mode);
    }
}