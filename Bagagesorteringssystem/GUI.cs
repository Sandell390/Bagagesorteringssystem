using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Pastel;

namespace Bagagesorteringssystem
{
    public static class GUI
    {

        public static void ProducerView()
        {
            Console.WriteLine("Creating Producer");
            Producer producer = new Producer();
            while (true)
            {
                string message = producer.BagageProducer();
                if (message != "")
                {
                    Console.WriteLine(message.Pastel(Color.Green));
                }
                else
                {
                    Console.WriteLine("Producer is waiting");
                    producer.ProducerWait();
                }

                Thread.Sleep(50);
            }
        }

        public static void SortingView()
        {
            Console.WriteLine("Creating Sorter");
            Sortering sortering = new Sortering();
            while (true)
            {
                string message = sortering.SortBaggage();
                if (message != "")
                {
                    Console.WriteLine(message.Pastel(Color.LightGreen));
                }
                else
                {
                    Console.WriteLine("Sorting is waiting");
                    sortering.SortWait();
                }
                


                Thread.Sleep(50);
            }
        }

        public static void PlaneView()
        {
            Console.WriteLine("Creating Plane");
            Plane plane = new Plane();
            while (true)
            {
                string message = plane.BagageConsumer();
                if (message != "")
                {
                    Console.WriteLine(message.Pastel(Color.Red));
                }
                else
                {
                    Console.WriteLine("Plane is waiting");
                    plane.PlaneWait();
                }

                Thread.Sleep(1000);
            }
        }

    }
}
