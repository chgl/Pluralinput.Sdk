using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pluralinput.Sdk.ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var im = new InputManager();

            foreach (var mouse in im.DeviceEnumerator.EnumerateMice())
            {
                mouse.ButtonDown += Mouse_ButtonDown;
                mouse.Move += Mouse_Move;
                Console.WriteLine(mouse.DeviceName);
            }
        }

        private static void Mouse_Move(object sender, MouseMoveInputEventArgs e)
        {
            Console.WriteLine("move");
        }

        private static void Mouse_ButtonDown(object sender, MouseButtonInputEventArgs e)
        {
            Console.WriteLine("BDOWN");
        }
    }
}
