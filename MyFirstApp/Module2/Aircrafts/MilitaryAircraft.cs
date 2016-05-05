using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyFirstApp.Module2.Interfaces;

namespace MyFirstApp.Module2.Aircrafts
{
    class MilitaryAircraft:Aircraft, IMilitary
    {
        private string name = "MilitaryAircraft";

        public MilitaryAircraft(int capacity, int liftingCapacity) : base(capacity, liftingCapacity)
        {
          
        }

        public MilitaryAircraft(int capacity, int liftingCapacity, int flightRange)
            : base(capacity, liftingCapacity, flightRange)
        {
            
        }

    
        public override void fly() 
        {
            Console.WriteLine("I can fly and shoot!");
        }

        public IMilitary Shoot()
        {
            Console.WriteLine("Fire Fire!");
            return this;
        }
    
    
    }


}
