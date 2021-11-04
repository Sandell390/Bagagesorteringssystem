using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bagagesorteringssystem
{
    public class Plane
    {
        public static List<Terminal> terminals;

        public Plane()
        {
            for (int i = 0; i < Program.destinations.Length; i++)
            {
                terminals.Add(new Terminal(Program.destinations[i]));
            }
        }

    }
}
