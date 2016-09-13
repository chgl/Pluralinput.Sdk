using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Pluralinput.Sdk.NativeStructs;

namespace Pluralinput.Sdk
{
    public class RawMouseInputEventArgs
    {
        public RawMouseInputEventArgs(RAWINPUTHEADER header, RAWMOUSE data)
        {
            Header = header;
            Data = data;
        }

        public RAWINPUTHEADER Header { get; private set; }
        public RAWMOUSE Data { get; private set; }
    }
}
