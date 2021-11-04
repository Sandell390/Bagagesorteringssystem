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
                Console.WriteLine(message);

                Thread.Sleep(1000);
            }
        }

        public static void SortingView()
        {
            Console.WriteLine("Creating Sorter");
            Sortering sortering = new Sortering();
            while (true)
            {

                Console.WriteLine($"{sortering.SortBaggage()}");

                Thread.Sleep(1000);
            }
        }

        public static void PlaneView()
        {
            Console.WriteLine("Creating Consumer");
            Plane plane = new Plane();
            while (true)
            {

                Thread.Sleep(1000);
            }
        }

    }
}
