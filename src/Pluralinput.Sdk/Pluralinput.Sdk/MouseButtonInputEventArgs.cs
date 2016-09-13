﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pluralinput.Sdk
{
    public class MouseButtonInputEventArgs
    {
        public MouseButtonInputEventArgs(VirtualKeys button)
        {
            Button = button;
        }

        public VirtualKeys Button { get; private set; }
    }
}
