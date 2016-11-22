using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using static Pluralinput.Sdk.NativeFlags;

namespace Pluralinput.Sdk
{
    public class NativeStructs
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct RAWINPUTDEVICE
        {
            [MarshalAs(UnmanagedType.U2)]
            public ushort usUsagePage;

            [MarshalAs(UnmanagedType.U2)]
            public ushort usUsage;

            [MarshalAs(UnmanagedType.I4)]
            public int dwFlags;

            public IntPtr hwndTarget;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct RAWINPUTDEVICELIST
        {
            internal IntPtr hDevice;

            [MarshalAs(UnmanagedType.I4)]
            internal int dwType;
        }

        [StructLayout(LayoutKind.Explicit)]
        public struct RAWINPUT
        {
            [FieldOffset(0)]
            public RAWINPUTHEADER header;

            [FieldOffset(16 + 8)]
            public RAWMOUSE mouse;

            [FieldOffset(16 + 8)]
            public RAWKEYBOARD keyboard;

            [FieldOffset(16 + 8)]
            public RAWHID hid;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct RAWINPUTHEADER
        {
            /// <summary>Type of device the input is coming from.</summary>
            public int dwType;
            /// <summary>Size of the packet of data.</summary>
            public int dwSize;
            /// <summary>Handle to the device sending the data.</summary>
            public IntPtr hDevice;
            /// <summary>wParam from the window message.</summary>
            public IntPtr wParam;
        }

        /// <summary>
        /// Contains information about the state of the mouse.
        /// </summary>
        [StructLayout(LayoutKind.Explicit)]
        public struct RAWMOUSE
        {
            /// <summary>
            /// The mouse state.
            /// </summary>
            [FieldOffset(0)]
            public ushort Flags;
            /// <summary>
            /// Flags for the event.
            /// </summary>
            [FieldOffset(4)]
            public ushort ButtonFlags;
            /// <summary>
            /// If the mouse wheel is moved, this will contain the delta amount.
            /// </summary>
            [FieldOffset(6)]
            public ushort ButtonData;
            /// <summary>
            /// Raw button data.
            /// </summary>
            [FieldOffset(8)]
            public uint RawButtons;
            /// <summary>
            /// The motion in the X direction. This is signed relative motion or 
            /// absolute motion, depending on the value of usFlags. 
            /// </summary>
            [FieldOffset(12)]
            public int LastX;
            /// <summary>
            /// The motion in the Y direction. This is signed relative motion or absolute motion, 
            /// depending on the value of usFlags. 
            /// </summary>
            [FieldOffset(16)]
            public int LastY;
            /// <summary>
            /// The device-specific additional information for the event. 
            /// </summary>
            [FieldOffset(20)]
            public uint ExtraInformation;
        }

        /// <summary>
        /// Value type for raw input from a keyboard.
        /// </summary>    
        [StructLayout(LayoutKind.Sequential)]
        public struct RAWKEYBOARD
        {
            /// <summary>Scan code for key depression.</summary>
            public ushort MakeCode;
            /// <summary>Scan code information.</summary>
            public ushort Flags;
            /// <summary>Reserved.</summary>
            public short Reserved;
            /// <summary>Virtual key code.</summary>
            public ushort VirtualKey;
            /// <summary>Corresponding window message.</summary>
            public uint Message;
            /// <summary>Extra information.</summary>
            public int ExtraInformation;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct RAWHID
        {
            public int Size;
            public int Count;
            public IntPtr Data;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct RID_DEVICE_INFO_HID
        {
            [MarshalAs(UnmanagedType.U4)]
            public int dwVendorId;
            [MarshalAs(UnmanagedType.U4)]
            public int dwProductId;
            [MarshalAs(UnmanagedType.U4)]
            public int dwVersionNumber;
            [MarshalAs(UnmanagedType.U2)]
            public ushort usUsagePage;
            [MarshalAs(UnmanagedType.U2)]
            public ushort usUsage;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct RID_DEVICE_INFO_KEYBOARD
        {
            [MarshalAs(UnmanagedType.U4)]
            public int dwType;
            [MarshalAs(UnmanagedType.U4)]
            public int dwSubType;
            [MarshalAs(UnmanagedType.U4)]
            public int dwKeyboardMode;
            [MarshalAs(UnmanagedType.U4)]
            public int dwNumberOfFunctionKeys;
            [MarshalAs(UnmanagedType.U4)]
            public int dwNumberOfIndicators;
            [MarshalAs(UnmanagedType.U4)]
            public int dwNumberOfKeysTotal;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct RID_DEVICE_INFO_MOUSE
        {
            [MarshalAs(UnmanagedType.U4)]
            public int dwId;
            [MarshalAs(UnmanagedType.U4)]
            public int dwNumberOfButtons;
            [MarshalAs(UnmanagedType.U4)]
            public int dwSampleRate;
            [MarshalAs(UnmanagedType.U4)]
            public int fHasHorizontalWheel;
        }

        [StructLayout(LayoutKind.Explicit)]
        public struct RID_DEVICE_INFO
        {
            [FieldOffset(0)]
            public int cbSize;
            [FieldOffset(4)]
            public int dwType;
            [FieldOffset(8)]
            public RID_DEVICE_INFO_MOUSE mouse;
            [FieldOffset(8)]
            public RID_DEVICE_INFO_KEYBOARD keyboard;
            [FieldOffset(8)]
            public RID_DEVICE_INFO_HID hid;
        }

        [StructLayout(LayoutKind.Sequential)]
        internal struct WNDCLASSEX
        {
            public uint cbSize;
            public ClassStyles style;
            [MarshalAs(UnmanagedType.FunctionPtr)]
            public WndProc lpfnWndProc;
            public int cbClsExtra;
            public int cbWndExtra;
            public IntPtr hInstance;
            public IntPtr hIcon;
            public IntPtr hCursor;
            public IntPtr hbrBackground;
            public string lpszMenuName;
            public string lpszClassName;
            public IntPtr hIconSm;
        }

        [StructLayout(LayoutKind.Sequential)]
        internal struct WNDCLASS
        {
            public ClassStyles style;
            [MarshalAs(UnmanagedType.FunctionPtr)]
            public WndProc lpfnWndProc;
            public int cbClsExtra;
            public int cbWndExtra;
            public IntPtr hInstance;
            public IntPtr hIcon;
            public IntPtr hCursor;
            public IntPtr hbrBackground;
            [MarshalAs(UnmanagedType.LPTStr)]
            public string lpszMenuName;
            [MarshalAs(UnmanagedType.LPTStr)]
            public string lpszClassName;
        }

        internal delegate IntPtr WndProc(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam);

        [StructLayout(LayoutKind.Sequential)]
        internal struct MSG
        {
            public IntPtr hwnd;
            public uint message;
            public IntPtr wParam;
            public IntPtr lParam;
            public uint time;
            public POINT pt;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct POINT
        {
            public int X;
            public int Y;
        }
    }
}
