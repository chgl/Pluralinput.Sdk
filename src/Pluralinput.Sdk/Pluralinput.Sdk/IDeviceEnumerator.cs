using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pluralinput.Sdk
{
    public interface IDeviceEnumerator
    {
        IEnumerable<Mouse> EnumerateMice();
        IEnumerable<Keyboard> EnumerateKeyboards();
    }
}
