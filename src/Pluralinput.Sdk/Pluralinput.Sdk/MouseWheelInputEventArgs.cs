using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pluralinput.Sdk
{
    public class MouseWheelInputEventArgs : EventArgs
    {
        public MouseWheelInputEventArgs(int wheelDelta)
        {
            WheelDelta = wheelDelta;
        }

        public int WheelDelta { get; private set; }
    }
}
