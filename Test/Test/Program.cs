using System;
using System.Threading;
using SharpDX.DirectInput;
using Ticks;
using Handling;

namespace Test
{
    class Program
    {
        static void Main(string[] arg)
        {

            bool change = true;
            var autoEvent = new AutoResetEvent(false);

            var tick = new Tick();

            var stateTimer = new Timer(tick.CheckStatus, 
                                   autoEvent, 0, 1);

            var handling = new DataHandling(tick);
            
            var handlingTimer = new Timer(handling.MakeCommand,
                                    autoEvent, 0, 1);
            

            // Initialize DirectInput
            var directInput = new DirectInput();

            // Find a Joystick Guid
            var joystickGuid = Guid.Empty;

            foreach (var deviceInstance in directInput.GetDevices(DeviceType.Gamepad,
                        DeviceEnumerationFlags.AllDevices))
                joystickGuid = deviceInstance.InstanceGuid;

            // If Gamepad not found, look for a Joystick
            if (joystickGuid == Guid.Empty)
                foreach (var deviceInstance in directInput.GetDevices(DeviceType.Joystick,
                        DeviceEnumerationFlags.AllDevices))
                    joystickGuid = deviceInstance.InstanceGuid;

            // If Joystick not found, throws an error
            if (joystickGuid == Guid.Empty)
            {
                Console.WriteLine("No joystick/Gamepad found.");
                Console.ReadKey();
                Environment.Exit(1);
            }

            // Instantiate the joystick
            var joystick = new Joystick(directInput, joystickGuid);

            var controller = new Controller(joystick);
            var buttonTimer = new Timer(controller.Switch,
                                    autoEvent, 0, 100);


            Console.WriteLine("Found Joystick/Gamepad with GUID: {0}", joystickGuid);

            // Query all suported ForceFeedback effects
            var allEffects = joystick.GetEffects();
            foreach (var effectInfo in allEffects)
                Console.WriteLine("Effect available {0}", effectInfo.Name);

            // Set BufferSize in order to use buffered data.
            joystick.Properties.BufferSize = 128;

            // Acquire the joystick
            joystick.Acquire();

            // Poll events from joystick
            while (true)
            {
                joystick.Poll();
                var state = joystick.GetCurrentState();

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

                tick.servo2Change = (int)Math.Round((state.X - 32768) * -0.0002);

                //if (state.Offset == JoystickOffset.Buttons6)
                //{
                //    Console.WriteLine($"TriggerOpen :{(state.Value)}");
                //}
                //if (state.Offset == JoystickOffset.Buttons0)
                //{
                //    Console.WriteLine($"TriggerClose :{(state.Value)}");
                //}

               

              
                tick.servo3Change = (int)Math.Round((state.Y - 32768) * -0.0002);

                tick.servo1Change = (int)Math.Round((state.RotationZ - 32768) * 0.0002);

                
                        


                    //if (state.Offset == JoystickOffset.Z)
                    //{
                    //    tick.speed = (float)(((state.Value * -0.0008) + 53)/5+1);
 
                    //}
                    

                
            }
        }
    }

}
