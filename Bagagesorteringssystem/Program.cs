using System;
using System.Threading;

namespace Bagagesorteringssystem
{
    class Program
    {
        public static string[] destinations = new[] { "London", "Berlin", "CPH", "Tokyo", "Hong kung", "Moskva", "Hanoi" };

        static void Main(string[] args)
        {
            Thread producer = new Thread(GUI.ProducerView);
            producer.Name = "Producer";
            producer.Start();

            Thread sorter = new Thread(GUI.SortingView);
            sorter.Name = "Sorter";
            sorter.Start();

            Thread plane = new Thread(GUI.PlaneView);
            plane.Name = "Plane";
            plane.Start();

            Console.ReadLine();
        }
    }
}
