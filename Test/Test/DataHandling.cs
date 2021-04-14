using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using SocketConnection;
using Ticks;

namespace Handling
{
    class DataHandling
    {
        Tick tickdata;
        string command;
        bool stop = false;
        Connection connection = new Connection("127.0.0.1", 8015);
        public DataHandling(Tick tick)
        {
            tickdata = tick;
            connection.Connect();
            Thread.Sleep(2000);
            stop = true;
        }

        public void MakeCommand(Object stateInfo)
        {
            if (stop)
            {
                AutoResetEvent autoEvent = (AutoResetEvent)stateInfo;
                command = $"{Format(tickdata.servo2)}{Format(tickdata.servo3)}{Format(tickdata.servo1)}{Format(tickdata.servo4)}";
                connection.SendMessage(command);
                Console.WriteLine(command);
            }
            
        }

        string Format(int data)
        {
            if (data < 100)
            {
                if (data < 10)
                {
                    if (data == 0)
                    {
                        return $"000";
                    }
                    else
                    {
                        return $"00{data}";
                    }
                }
                else
                {
                    return $"0{data}";
                }
            }
            else
            {
                return $"{data}";
            }
            
        }
    }
}
