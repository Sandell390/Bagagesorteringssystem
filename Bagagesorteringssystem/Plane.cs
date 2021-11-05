using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Bagagesorteringssystem
{
    public class Plane
    {
        public static List<Terminal> terminals = new List<Terminal>();

        public static object _planeLock = new object();

        public Plane()
        {
            for (int i = 0; i < Program.destinations.Length; i++)
            {
                terminals.Add(new Terminal(Program.destinations[i]));
            }
        }

        public string BagageConsumer()
        {
            lock (_planeLock)
            {
                for (int i = 0; i < terminals.Count; i++)
                {
                    string msg = terminals[i].RemoveBaggage();
                    if (msg != "")
                    {
                        return msg;
                    }
                }
            }
            return "";
        }

        public void PlaneWait()
        {
            Monitor.Enter(_planeLock);

            try
            {
                Monitor.Wait(_planeLock);
            }
            finally
            {
                Monitor.Exit(_planeLock);
            }
        }

    }
}
