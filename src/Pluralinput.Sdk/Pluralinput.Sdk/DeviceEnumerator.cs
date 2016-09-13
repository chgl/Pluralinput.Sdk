using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using static Pluralinput.Sdk.NativeStructs;
using static Pluralinput.Sdk.NativeMethods;
using static Pluralinput.Sdk.NativeConst;

namespace Pluralinput.Sdk
{
    public class DeviceEnumerator : IDeviceEnumerator
    {
        public DeviceEnumerator(IRawInputSource rawInputSource)
        {
            RawInputSource = rawInputSource;
        }

        private IRawInputSource RawInputSource { get; set; }

        public IEnumerable<Mouse> EnumerateMice()
        {
            var mice = GetRawInputDevices(RIM_TYPEMOUSE);
            return mice.Select(ridl => new Mouse(ridl.hDevice, RawInputSource));
        }

        public IEnumerable<Keyboard> EnumerateKeyboards()
        {
            var keyboards = GetRawInputDevices(RIM_TYPEKEYBOARD);
            return keyboards.Select(ridl => new Keyboard(ridl.hDevice, RawInputSource));
        }

        private IEnumerable<RAWINPUTDEVICELIST> GetRawInputDevices(uint type)
        {
            uint deviceCount = 0;
            uint dwSize = (uint)Marshal.SizeOf<RAWINPUTDEVICELIST>();

            // First call the system routine with a null pointer
            // for the array to get the size needed for the list
            uint retValue = GetRawInputDeviceList(null, ref deviceCount, dwSize);

            // If anything but zero is returned, the call failed, so return a null list
            if (0 != retValue)
                return null;

            // Now allocate an array of the specified number of entries
            RAWINPUTDEVICELIST[] deviceList = new RAWINPUTDEVICELIST[deviceCount];

            // Now make the call again, using the array
            retValue = GetRawInputDeviceList(deviceList, ref deviceCount, dwSize);

            // Free up the memory we first got the information into as
            // it is no longer needed, since the structures have been 
            // copied to the managed deviceList array.

            // Finally, return the filled in list
            return deviceList.Where(ridl => ridl.dwType == type);
        }
    }
}
