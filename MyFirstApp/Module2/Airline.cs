using MyFirstApp.Module2.Aircrafts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Specialized;
using System.Collections;


namespace MyFirstApp.Module2
{
    class Airline
    {

        private delegate bool AcceptCriteria(int value, int minRange, int MaxRange);
        private delegate bool FilterBy(Fly f, AcceptCriteria accept, int[] range);
       

        static void Main(string[] args)
        {
            Airline airline = new Airline();
            airline.StartApplication();
        }

        private void StartApplication()
        {
            Fly[] flies = CreateFliesArray();

            Console.WriteLine("General people's capacity = " + CalculateGeneralCapacity(flies) + " people");
            Console.WriteLine("General lifting capacity = " + CalculateGeneralLifting(flies) + " tons");

            PrintFlyableArray(SortByFlightRange(flies));

            AcceptCriteria acceptCriteria = (value, min, max) => value >= min && value <= max;
            FilterBy filterBy = (Fly f, AcceptCriteria accept, int[] range) => accept(f.capacity, range[0], range[1]);
            filterBy += (Fly f, AcceptCriteria accept, int[] range) => accept(f.liftingCapacity, range[0], range[1]);
            filterBy += (Fly f, AcceptCriteria accept, int[] range) => accept(f.flightRange, range[0], range[1]);
               
            
            if (NeedFind()) { FindAirplaneBy(flies, filterBy, GetParameters(), acceptCriteria); };
        }


        private int[] GetSomeRangeForParameter()
        {
            String range = Console.ReadLine();
            if (!range.Contains("-")) 
            {
                range = range + "-" + range;
            }
            
            String[] rangeSplit = range.Split('-');
            var result = new int[2];

            result[0] = Int32.Parse(rangeSplit[0]);
            result[1] = Int32.Parse(rangeSplit[1]);

            return result;
        }

        
        private void FindAirplaneBy(Fly[] flies, FilterBy filterBy, IList<int[]> rangeList, AcceptCriteria accept)
        {
            
            Boolean isExist = false;
            var resultList = new List<String>();

            for(int i=0; i<flies.Length && i<rangeList.Count;i++)
            {
                if (filterBy(flies[i], accept, rangeList[i]))
                {
                    resultList.Add(flies[i].ToString());
                    isExist = true;
                }

            }

            if (!isExist) {
                Console.WriteLine("Did not find any airplanes by your paramaters");
                Console.ReadLine();
            }
            else
            {
                resultList.ForEach(s => Console.WriteLine("Found: {0}", s));
                Console.ReadLine();
            }
        }

       

        private IList<int[]> GetParameters()
        {
            var rangeList = new List<int[]>();

            Console.WriteLine("Type a range of values for parameters, e.g. '300-500'");
            Console.WriteLine("PeopleCapacity=");
            rangeList.Add(GetSomeRangeForParameter());

            Console.WriteLine("LiftingCapacity=");
            rangeList.Add(GetSomeRangeForParameter());

            Console.WriteLine("FlightRange=");
            rangeList.Add(GetSomeRangeForParameter());

            return rangeList;
            
        }

        private bool NeedFind()
        {
            
            Console.WriteLine("Do you want to find some airplane ? (Type yes/no)");
            String tempYes = Console.ReadLine();
            
            if (tempYes.ToLower().Equals("yes"))
            {
                return true;
            }

            return false;
        }

        public void PrintFlyableArray(Fly[] flies)
        {
            Console.WriteLine("Order by Flight Range: (Min to Max)");
            for (int i = 0; i<flies.Length; i++) 
            {
                Console.WriteLine(" {0}", flies[i].ToString());
            }
        }

        private Fly[] SortByFlightRange(Fly[] flies)
        {
            Array.Sort(flies);
            return flies;
        }

        public int CalculateGeneralLifting(Fly[] flies)
        {
            int sum = 0;

            foreach (Fly f in flies)
            {
                sum += f.liftingCapacity;
            }

            return sum;
        }

        public int CalculateGeneralCapacity(Fly[] flies)
        {
               int sum = 0;

                foreach (Fly f in flies)
                {
                    sum += f.capacity;
                }
               
              return sum;
        }

        public Fly[] CreateFliesArray()
        {
          
            Fly[] flies = new Fly[3];
            flies[0] = new Aircraft(200, 150, 1800);
            flies[1] = new MilitaryAircraft(2, 2, 2700);
            flies[2] = new TransportAircraft(700, 300, 6000);
            
            return flies;
        }

       
    }
}
