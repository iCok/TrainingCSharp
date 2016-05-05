using MyFirstApp.Module2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstApp.Module2.Aircrafts
{
    class TransportAircraft:Aircraft, ITransport
    {

        private int currentWeight { get; set; }

        public override string name { get { return "TransportAircraft"; } }

        
        public TransportAircraft(int capacity, int liftingCapacity) : base(capacity, liftingCapacity)
        {
            this.currentWeight = 0;
            
        }

        public TransportAircraft(int capacity, int liftingCapacity, int flightRange) : base(capacity, liftingCapacity, flightRange)
        {
            this.currentWeight = 0;
            
        }


        public bool LoadSomeThing(int weightToLoad, out int resultWeight)
        {
            if (currentWeight + weightToLoad < liftingCapacity)
            {
                currentWeight += weightToLoad;
                resultWeight = currentWeight;
                return true;
            }

            resultWeight = currentWeight;
            return false;
        }
    }
}
