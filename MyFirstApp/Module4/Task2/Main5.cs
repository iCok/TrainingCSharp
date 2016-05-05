using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstApp.Module4.Task2
{
    class Main5
    {

        private static Random rng = new Random();

        static void Main(string[] args)
        {

            Main5 main = new Main5();
            main.startApplication();
        }

        private static void Shuffle<T>(IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }

        private void startApplication()
        {
            List<Int32> collection = generateCollection();
            Console.WriteLine("Min element: " + findMin(collection));
            Console.WriteLine("Previous from max element is: " + findPrevFromMaxElement(collection));
            Console.WriteLine("Size of collection after removing even numbers: " + removeEvenNumbers(collection).Count);
            Console.ReadLine();
        }

        private List<Int32> generateCollection()
        {

            List<Int32> Int32Collection = Enumerable.Range(0, 1000000).ToList();

            if (!isDistinct(Int32Collection))
            {
                Console.WriteLine("Collection is not distinct");
            }

            Shuffle<Int32>(Int32Collection);

            return Int32Collection;
        }

        private bool isDistinct(List<Int32> list)
        {

            list.Sort((n, m) => n.CompareTo(m));

            for (int i = 0; i < list.Count - 1; i++)
            {
                if (list[i].Equals(list[i + 1]))
                {
                    return false;
                }
            }
            return true;
        }

        private Int32 findMin(List<Int32> list)
        {

            return list.Min();
        }

        private List<Int32> removeEvenNumbers(List<Int32> list)
        {
            list = list
                .Where(k => k % 2 != 0)
                .Select(k => k)
                .ToList();

            return list;
        }

        private Int32 findPrevFromMaxElement(List<Int32> list)
        {

            list.Sort((n, m) => n.CompareTo(m));
            return list[list.Count - 2];

        }


    }
}
