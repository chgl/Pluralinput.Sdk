using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pluralinput.Sdk
{
    public interface IRawInputSource
    {
        event EventHandler<RawMouseInputEventArgs> MouseInput;
        event EventHandler<RawKeyboardInputEventArgs> KeyboardInput;
    }
}
