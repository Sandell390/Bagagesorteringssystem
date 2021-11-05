using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Bagagesorteringssystem
{
    public class Sortering
    {
        bool isProducerEmpty;
        bool isConsumerFull;

        public Sortering()
        {

        }

        public string SortBaggage()
        {
            Baggage baggage;

            string message = "";

            for (int i = 0; i < Producer.airDesks.Count; i++)
            {
                if (Producer.airDesks[i].baggages.Any(x => x != null))
                {
                    
                    if (Monitor.TryEnter(Producer.airDesks[i].baggages))
                    {
                        isProducerEmpty = false;

                        baggage = Array.Find(Producer.airDesks[i].baggages, x => x != null);

                        Terminal terminal = Plane.terminals.Find(x => x.destination == baggage.destination);

                        if (terminal.baggages.Any(x => x == null))
                        {
                            isConsumerFull = false;

                            Producer.airDesks[i].baggages[Array.IndexOf(Producer.airDesks[i].baggages, baggage)] = null;

                            Monitor.TryEnter(Producer._producerLock);
                            try
                            {
                                Monitor.PulseAll(Producer._producerLock);
                            }
                            finally
                            {
                                Monitor.Exit(Producer._producerLock);
                            }

                            Monitor.Exit(Producer.airDesks[i].baggages);

                            Monitor.TryEnter(terminal.baggages);
                            try
                            {
                                terminal.baggages[Array.IndexOf(terminal.baggages, null)] = baggage;

                                Monitor.TryEnter(Plane._planeLock);
                                try
                                {
                                    Monitor.PulseAll(Plane._planeLock);
                                }
                                finally
                                {
                                    Monitor.Exit(Plane._planeLock);
                                }
                            }
                            finally
                            {
                                Monitor.Exit(terminal.baggages);
                            }

                            message = $"Baggage nr. {baggage.nr} is removed from AirDesk nr. {Producer.airDesks[i].nr}";
                            message += $"\r\nBaggage nr. {baggage.nr} is added to terminal {terminal.destination}";

                        }
                        else
                        {
                            isConsumerFull = true;
                        }
                    }
                    
                }
                else
                {
                    isProducerEmpty = true;
                }

            }

            return message;
        }

        public void SortWait()
        {
            if(isConsumerFull)
            {
                Monitor.Enter(Plane._planeLock);

                try
                {
                    Monitor.Wait(Plane._planeLock);
                }
                finally
                {
                    Monitor.Exit(Plane._planeLock);
                }

            }else if (isProducerEmpty)
            {
                Monitor.Enter(Producer._producerLock);

                try
                {
                    Monitor.Wait(Producer._producerLock);
                }
                finally
                {
                    Monitor.Exit(Producer._producerLock);
                }
            }



        }

    }
}
