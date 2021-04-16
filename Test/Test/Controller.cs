using SharpDX.DirectInput;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Test
{
    class Controller
    {
        public bool change = true;
        Joystick joystick;
        public Controller(Joystick joysticks)
        {
            joystick = joysticks;
        }

        public void Switch(Object stateInfo)
        {
            AutoResetEvent autoEvent = (AutoResetEvent)stateInfo;

                //var state = joystick.GetCurrentState();
                
                //if (state.Buttons[1] == true)
                //{
                //    if (change)
                //    {
                //        change = false;
                //    }
                //    else
                //    {
                //        change = true;
                //    }
                //}

                

            

        }
    }
}
