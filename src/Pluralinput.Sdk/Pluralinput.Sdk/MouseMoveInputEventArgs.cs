﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pluralinput.Sdk
{
    public class MouseMoveInputEventArgs
    {
        public MouseMoveInputEventArgs(int lastX, int lastY)
        {
            LastX = lastX;
            LastY = lastY;
        }

        public int LastX { get; set; }
        public int LastY { get; set; }
    }
}
