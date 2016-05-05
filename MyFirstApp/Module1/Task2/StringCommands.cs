using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstApp.Module1.Task2
{
    class StringCommands
    {

        private IList<String> strings = new List<String>();
    
        private int countOfString = 0;
        private int tempLength = 0;

        //static void Main(string[] args)
        //{
        //    StringCommands myString = new StringCommands();
        //    myString.StartApplication();

        //}

        public void StartApplication() 
        {

        SetStringList();
        Console.WriteLine("Max string=" + FindLongString(strings) + " Length=" + tempLength);
        Console.WriteLine("Min string=" + FindShortString(strings) + " Length=" + tempLength);
        }

        private IList<String> SetStringList() 
        {

        int stringCount = 0;
       
        Console.WriteLine("Type count of string:");
 
        countOfString = Int32.Parse(Console.ReadLine());
        Console.WriteLine("Type strings:");


        while (stringCount != countOfString) 
        {
            strings.Add(Console.ReadLine());
            stringCount++;
        }
        
        return strings;

        }

        private String FindLongString(IList<String> stringList)
        {


            String tempString = stringList[0];
            Int32 length = stringList[0].Length;

            for (int i = 0; i < stringList.Count; i++)
            {

                if (stringList[i].Length > length)
                {
                    length = stringList[i].Length;
                    tempString = stringList[i];
                }
            }
            tempLength = length;
            return tempString;

        }

        private String FindShortString(IList<String> stringList)
        {


            String tempString = stringList[0];
            Int32 length = stringList[0].Length;

            for (int i = 0; i < stringList.Count; i++)
            {

                if (stringList[i].Length < length)
                {
                    length = stringList[i].Length;
                    tempString = stringList[i];
                }

            }
            tempLength = length;
            return tempString;

        }
    }
}
