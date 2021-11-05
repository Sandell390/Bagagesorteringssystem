using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bagagesorteringssystem
{
    public class Baggage
    {
        public int nr;

        public static int nOfBaggage;

        public string destination;

        public Baggage(string destination)
        {
            this.destination = destination;
            nr = nOfBaggage;
            nOfBaggage++;
        }
    }
}
