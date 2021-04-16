using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Ticks
{
    class Tick
    {
        int max = 180;
        int min = 0;
        public float speed = 1;
        public int servo1 = 90;
        public float servo1Change = 0;
        public int servo2 = 90;
        public float servo2Change = 0;
        public int servo3 = 90;
        public float servo3Change = 0;
        public int servo4 = 90;
        public float servo4Change = 0;

        public Tick()
        {
            
        }

        public void CheckStatus(Object stateInfo)
        {
            AutoResetEvent autoEvent = (AutoResetEvent)stateInfo;
            
            if (servo1 + servo1Change*speed <= max && servo1 + servo1Change*speed >= min & servo1Change*speed != 0)
            {
                servo1 = (int)(servo1 + servo1Change);
                //Console.WriteLine($"X :{servo1}");
            }

            if (servo2 + servo2Change*speed <= max && servo2 + servo2Change*speed >= min & servo2Change*speed != 0)
            {
                servo2 = (int)(servo2 + servo2Change);
                //Console.WriteLine($"Y :{servo2}");
            }

            if (servo3 + servo3Change * speed <= max && servo3 + servo3Change * speed >= min & servo3Change * speed != 0)
            {
                servo3 = (int)(servo3 + servo3Change);
                //Console.WriteLine($"Y :{servo2}");
            }


        }
    }
}
