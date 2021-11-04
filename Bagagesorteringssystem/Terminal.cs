using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bagagesorteringssystem
{
    public class Terminal
    {
        private string destination;

        public Baggage[] baggages = new Baggage[5];

        private int nr = 0;

        public static int nOfTerminal = 0;

        public Terminal(string destination)
        {
            this.destination = destination;

            nOfTerminal++;
            nr = nOfTerminal;
        }
    }
}
