using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstApp.Module2.Aircrafts
{
    class Aircraft:Fly
    {
        public override string name {get { return "Aircraft"; } }

        public Aircraft(int capacity, int liftingCapacity)
        {
            this.capacity = capacity;
            this.liftingCapacity = liftingCapacity;
            this.flightRange = 2000;
            
        }


        public Aircraft(int capacity, int liftingCapacity, int flightRange) : this(capacity, liftingCapacity)
        {
            this.flightRange = flightRange;
        }
    }
}
