using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Bagagesorteringssystem
{
    public class Terminal
    {
        public string destination;

        public Baggage[] baggages = new Baggage[5];

        private int nr = 0;

        public static int nOfTerminal = 0;

        public Terminal(string destination)
        {
            this.destination = destination;

            nOfTerminal++;
            nr = nOfTerminal;
        }

        public string RemoveBaggage()
        {
            string msg = string.Empty;

            if (Monitor.TryEnter(baggages))
            {
                try
                {
                    if (baggages.Any(x => x != null))
                    {

                        Baggage baggage = Array.Find(baggages, x => x != null);

                        baggages[Array.IndexOf(baggages, baggage)] = null;

                        msg = $"Baggage {baggage.destination} nr. {baggage.nr} remove from Terminal {destination}";

                        Monitor.PulseAll(Plane._planeLock);
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
