using MyFirstApp.Module2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstApp.Module2
{
   abstract class Fly : IFly, IComparable<Fly>
    {

        //Вместимость человек
        public int capacity { get;  protected set; }

        //Грузоподъемность в тоннах
        public int liftingCapacity { get; protected set; }

        //Дальность полёта в километрах
        public int flightRange { get; protected set; }

        public abstract string name {get;}

        public override String ToString()
        {
            return name;
        }

        public int CompareTo(Fly other)
        {
            return flightRange.CompareTo(other.flightRange);
        }


        public virtual void fly()
        {
            Console.WriteLine("I can fly!");
        }
    }
    
   
}
