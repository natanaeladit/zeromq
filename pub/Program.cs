using NetMQ;
using NetMQ.Sockets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace pub
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var publisher = new PublisherSocket())
            {
                publisher.Bind("tcp://*:5556");

                int i = 0;

                while (true)
                {
                    publisher
                        .SendMoreFrame("A") // Topic
                        .SendFrame(i.ToString()); // Message

                    Console.WriteLine($"Send {i.ToString()}");

                    i++;
                    Thread.Sleep(1000);
                }
            }
        }
    }
}
