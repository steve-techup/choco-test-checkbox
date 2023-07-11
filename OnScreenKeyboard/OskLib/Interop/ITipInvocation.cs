using System;
using System.Runtime.InteropServices;

namespace OnScreenKeyboard.OskLib.Interop
{
    [ComImport]
    [Guid( "37c994e7-432b-4834-a2f7-dce1f13b834b" )]
    [InterfaceType( ComInterfaceType.InterfaceIsIUnknown )]
    internal interface ITipInvocation
    {
        void Toggle( IntPtr hwnd );
    }
}