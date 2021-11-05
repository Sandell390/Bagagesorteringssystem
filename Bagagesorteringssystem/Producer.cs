using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Bagagesorteringssystem
{
    public class Producer
    {
        public static List<AirDesk> airDesks = new List<AirDesk>();

        private Random random = new Random();

        public static object _producerLock = new object();

        public Producer()
        {
            airDesks.Add(new AirDesk(Program.destinations));
            airDesks.Add(new AirDesk(Program.destinations));
            airDesks.Add(new AirDesk(Program.destinations));
        }

        public string BagageProducer()
        {
            lock (_producerLock)
            {
                for (int i = 0; i < airDesks.Count; i++)
                {
                    string msg = airDesks[i].AddBaggage();
                    if (msg != "")
                    {
                        return msg;
                    }
                }
            }
            return "";
        }

        public void ProducerWait()
        {
            for (int i = 0; i < airDesks.Count; i++)
            {
                if (airDesks[i].baggages.All(x => x != null))
                {
                    Monitor.Enter(_producerLock);

                    try
                    {
                        Monitor.Wait(_producerLock);
                    }
                    finally
                    {
                        Monitor.Exit(_producerLock);
                    }
                }
            }
            
        }

    }
}
