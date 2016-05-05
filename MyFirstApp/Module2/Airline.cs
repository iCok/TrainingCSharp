using MyFirstApp.Module2.Aircrafts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Collections;


namespace MyFirstApp.Module2
{
    class Airline
    {

        private delegate bool AcceptCriteria(int value, int minRange, int MaxRange);
        private delegate bool FilterBy(Fly f, IList<int[]> nameParamToRange, AcceptCriteria accept);

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

            //var acceptCriteries = new AcceptCriteria(AcceptValueInRange);
            AcceptCriteria acceptCriteria = (value, min, max) => value >= min && value <= max;
            var filterBy = new FilterBy(FilterByAllParameters);
            

            if (NeedFind()) { FindAirplaneBy(flies, filterBy); };
        }

        private bool FilterByAllParameters(Fly f, IList<int[]> rangeList, AcceptCriteria accept)
        {
            Boolean isAccept = true;
            for (int i = 0; i < rangeList.Count; i++)
            {
                int[] range = rangeList[i];

                while (isAccept)
                {
                    isAccept = accept(f.flightRange, range[0], range[1]);
                    isAccept = accept(f.capacity, range[0], range[1]);
                    isAccept = accept(f.liftingCapacity, range[0], range[1]);
                }


            }


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

        

        private bool AcceptValueInRange(int value, int minRange, int maxRange)
        {
            if (value >= minRange && value <= maxRange)
            {
                return true;
            }
            return false;
        }

        

        private void FindAirplaneBy(Fly[] flies, FilterBy filterBy)
        {
            
           
            Boolean isExist = false;

            
            var resultList = new List<String>();
            

            foreach (Fly f in flies)
            {
               
                if (AcceptRangeCriteria(valueToRange, filterBy))
                {
                    resultList.Add(f.ToString());
                    isExist = true;
                    break;
                }

              

            }

            if (!isExist) {
                Console.WriteLine("Did not find any airplanes by your paramaters");
            }
        }

       

        private IList<int[]> GetParameters()
        {
            var rangeList = new List<int[]>();

            Console.WriteLine("Type a range of values for parameters, e.g. '300-500'");
            Console.WriteLine("FlightRange=");
            rangeList.Add(GetSomeRangeForParameter());

            Console.WriteLine("PeopleCapacity=");
            rangeList.Add(GetSomeRangeForParameter());

            Console.WriteLine("LiftingCapacity=");
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

        private void PrintFlyableArray(Fly[] flies)
        {
            Console.WriteLine("Order by Flight Range: (Min to Max)");
            for (int i = 0; i<flies.Length; i++) 
            {
                Console.WriteLine(flies[i].ToString());
            }
        }

        private Fly[] SortByFlightRange(Fly[] flies)
        {
            Array.Sort(flies);
            return flies;
        }

        private int CalculateGeneralLifting(Fly[] flies)
        {
            int sum = 0;

            foreach (Fly f in flies)
            {
                sum += f.liftingCapacity;
            }

            return sum;
        }

        private int CalculateGeneralCapacity(Fly[] flies)
        {
               int sum = 0;

                foreach (Fly f in flies)
                {
                    sum += f.capacity;
                }
               
              return sum;
        }

        private Fly[] CreateFliesArray()
        {
          
            Fly[] flies = new Fly[3];
            flies[0] = new Aircraft(200, 150, 1800);
            flies[1] = new MilitaryAircraft(2, 2, 2700);
            flies[2] = new TransportAircraft(700, 300, 6000);
            
            return flies;
        }

       
    }
}
