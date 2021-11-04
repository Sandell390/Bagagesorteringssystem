using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Bagagesorteringssystem
{
    public class AirDesk
    {
        private bool isOpen = false;

        private string[] destinations;

        public Baggage[] baggages = new Baggage[5];

        private int nr = 0;

        public static int nOfAirDesk = 0;

        private Random random = new Random();

        public AirDesk(string[] destinations)
        {
            this.destinations = destinations;

            nOfAirDesk++;
            nr = nOfAirDesk;
        }


        public string AddBaggage()
        {
            string msg = string.Empty;
            
            if (Monitor.TryEnter(baggages))
            {
                try
                {
                    if (baggages.Any(x => x == null))
                    {
                        string destination = destinations[random.Next(0, destinations.Length - 1)];

                        Baggage baggage = new Baggage(destination);

                        baggages[Array.IndexOf(baggages, null)] = baggage;

                        msg = $"Baggage nr. {baggage.nr} added to AirDesk nr. {nr}";
                    }
                }
                finally
                {
                    Monitor.Exit(baggages);
                }
            }
            return msg;
        }

    }
}
