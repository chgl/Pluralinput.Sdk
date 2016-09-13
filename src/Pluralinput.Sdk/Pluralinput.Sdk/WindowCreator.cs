using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using static Pluralinput.Sdk.NativeFlags;
using static Pluralinput.Sdk.NativeStructs;
using static Pluralinput.Sdk.NativeMethods;
using static Pluralinput.Sdk.NativeConst;

namespace Pluralinput.Sdk
{
    public class WindowCreator : IDisposable
    {
        private bool isDisposed = false;
        private static WndProc WndProcDelegate;
        private WNDCLASSEX windowClassEx = new WNDCLASSEX();
        private IntPtr windowHandle = IntPtr.Zero;

        public WindowCreator(RawInputParser rawInputParser)
        {
            RawInputParser = rawInputParser;
            WndProcDelegate = WndProc;
        }

        private RawInputParser RawInputParser { get; set; }

        private IntPtr WndProc(IntPtr hwnd, uint message, IntPtr wParam, IntPtr lParam)
        {
            switch ((WM)message)
            {
                case WM.DESTROY:
                    PostQuitMessage(0);
                    return IntPtr.Zero;
                case WM.INPUT:
                    RawInputParser.Parse(hwnd, wParam, lParam);
                    break;
            }

            return DefWindowProc(hwnd, (WM)message, wParam, lParam);
        }
        
        public IntPtr CreateWindow()
        {
            //TODO: possible race condition if CreateWindow is called from multiple threads.
            if (windowHandle != IntPtr.Zero)
                throw new InvalidOperationException("Only a single call to CreateWindow is allowed per WindowCreator instance.");

            //SafeHandle instanceHandle = Process.GetCurrentProcess().SafeHandle;
            string windowClassName = "PluralinputSDKHiddenWindowClass";

            windowClassEx.cbSize = (uint)Marshal.SizeOf<WNDCLASSEX>();
            windowClassEx.style = 0;
            windowClassEx.lpfnWndProc = new WndProc(WndProcDelegate);
            windowClassEx.cbClsExtra = 0;
            windowClassEx.cbWndExtra = 0;
            windowClassEx.hInstance = IntPtr.Zero; //instanceHandle.DangerousGetHandle();
            windowClassEx.hIcon = LoadIcon(IntPtr.Zero, new IntPtr((int)SystemIcons.IDI_APPLICATION));
            windowClassEx.hIconSm = LoadIcon(IntPtr.Zero, new IntPtr((int)SystemIcons.IDI_APPLICATION));
            windowClassEx.hCursor = LoadCursor(IntPtr.Zero, (int)IdcStandardCursors.IDC_ARROW);
            windowClassEx.hbrBackground = GetStockObject(StockObjects.WHITE_BRUSH);
            windowClassEx.lpszMenuName = null;
            windowClassEx.lpszClassName = windowClassName;

            short regResult = RegisterClassEx(ref windowClassEx);

            if (regResult == 0)
            {
                throw new Win32Exception();
            }

            var hwnd = CreateWindowEx(
                WindowStylesEx.WS_EX_NOACTIVATE | WindowStylesEx.WS_EX_TRANSPARENT,
                windowClassName,
                "Pluralinput.Sdk Window (You really shouldn't see this...)",
                WindowStyles.WS_DISABLED,
                CW_USEDEFAULT,
                CW_USEDEFAULT,
                CW_USEDEFAULT,
                CW_USEDEFAULT,
                IntPtr.Zero,
                IntPtr.Zero,
                IntPtr.Zero,//instanceHandle.DangerousGetHandle(),
                IntPtr.Zero);

            if (hwnd == IntPtr.Zero)
            {
                throw new Win32Exception();
            }

            // no need to show a hidden window.
            //ShowWindow(hwnd, (int)ShowWindowCommands.Hide);
            UpdateWindow(hwnd);

            Task.Run(() =>
            {
                MSG msg;
                while (GetMessage(out msg, IntPtr.Zero, 0, 0) != 0)
                {
                    TranslateMessage(ref msg);
                    DispatchMessage(ref msg);
                }
            });

            windowHandle = hwnd;

            return hwnd;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!isDisposed)
            {
                if (disposing)
                {
                    // dispose managed resources
                }
                
                if (windowHandle != IntPtr.Zero)
                {
                    DestroyWindow(windowHandle);
                    windowHandle = IntPtr.Zero;
                }
            }
        }
    }
}
