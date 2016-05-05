using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstApp
{
    class MyArray
    {

        private Random random = new Random((int)DateTime.Now.Ticks);
        private int[] sourceArray;
        private int taskNumber;

        private const int ARRAY_LENGTH = 20, ARRAY_MIN_VALUE = -10, ARRAY_MAX_VALUE = 10;

        //static void Main(string[] args)
        //{
        //    var program = new Array();
        //    program.StartApplication();
        //}

        public void StartApplication()
        {

            SetTaskNumberFromConsole();
            Console.WriteLine("Array:=");
            PrintArray(BuildArray(ARRAY_LENGTH));
            ModifyArray(taskNumber);

        }

        private int[] BuildArray(int arrayLength)
        {
            sourceArray = new int[arrayLength];
            for (int i = 0; i < sourceArray.Length; i++)
            {
                sourceArray[i] = GetRandomValue(ARRAY_MIN_VALUE, ARRAY_MAX_VALUE);
            }

            return sourceArray;
        }

        private int GetRandomValue(int min, int max)
        {
            return random.Next(min, max);
        }

        private void PrintArray(int[] array)
        {

           for(int i=0;i< array.Length;i++) 
           {
              Console.WriteLine(array[i] + " ");
           }
        }

        private int SetTaskNumberFromConsole()
        {
            Console.WriteLine("Type task number:");
            taskNumber = Int32.Parse(Console.ReadLine());
            return taskNumber;
        }

        private void PrintNegativePositivePositions(int positionPositive, int positionNegative) 
        {

             Console.WriteLine("\n" + "positivePosition=" + positionPositive);
             Console.WriteLine("negativePosition=" + positionNegative);
        }

        //Решения задач
        private void ModifyArray(int task) {


        switch (task) {

            case 1://В массиве целых чисел поменять местами максимальный отрицательный элемент и минимальный положительный

                try {
                //Получаем исходный массив
                int[] modifiedArray = GetArray();
                int minPositive = ARRAY_MAX_VALUE, maxNegative = ARRAY_MIN_VALUE, countNegativeValue = 0, countPositiveValue = 0, positionNegative = 0, positionPositive = 0;

                    for(int i=0;i<modifiedArray.Length;i++) {

                        //Есть ли отриц. элементы
                        if (modifiedArray[i]<0) 
                        {
                            countNegativeValue++;
                            //Поиск максимального отрицательного
                            if (modifiedArray[i]>maxNegative) 
                            {
                                maxNegative=modifiedArray[i];
                                positionNegative = i;
                            }
                        }

                        //Есть ли положит. элементы
                        if (modifiedArray[i]>=0) 
                        {
                            countPositiveValue++;
                            //Поиск минимального положительного
                            if (modifiedArray[i]<minPositive) 
                            {
                                minPositive=modifiedArray[i];
                                positionPositive = i;
                            }
                        }
                    }


                    //Если нету положительных, выходим
                    if (countPositiveValue==0) 
                    {
                        Console.WriteLine("\n"+ "There are no positive values");
                        break;
                    }

                    //Если нету отрицательных, выходим
                    if (countNegativeValue==0) 
                    {
                        Console.WriteLine("\n"+ "There are no negative values");
                        break;
                    }

                    //Смена значений
                    modifiedArray[positionPositive] = maxNegative;
                    modifiedArray[positionNegative] = minPositive;

                    Console.WriteLine("\n" + "Modified array:=");
                    PrintArray(modifiedArray);


                    //Вывод позиций заменяющихся элементов
                    PrintNegativePositivePositions(positionPositive, positionNegative);


                }  catch (NullReferenceException) {
                    Console.WriteLine("\n" + "Got null value");

                }

                break;


            case 2: //В массиве целых чисел определить сумму элементов, состоящих на чётных позициях.

                try {

                    int summ = 0;

                    //Получаем исходный массив
                    int[] modifiedArray = GetArray();

                    for(int i=0;i<modifiedArray.Length;i++) 
                    {
                        //Проверка на чётность
                        if (i %2 == 0) {
                            summ += modifiedArray[i];
                        }
                    }

                   Console.WriteLine("\n" + "Summ=" + summ);

                } catch (NullReferenceException) {
                    Console.WriteLine("\n" + "Got null value");
                }

                break;


            case 3: //В массиве целых чисел заменить нулями отрицательные элементы

                try {
                    int countNegativeValue = 0;

                    //Получаем исходный массив
                    int[] modifiedArray = GetArray();

                    for(int i=0;i<modifiedArray.Length;i++) 
                    {

                        //Есть ли отриц. элементы
                        if (modifiedArray[i]<0) 
                        {
                            countNegativeValue++;
                            modifiedArray[i]=0;
                        }
                    }
                    //Если нету отрицательных, выходим
                    if (countNegativeValue==0) 
                    {
                        Console.WriteLine("\n"+ "There are no negative values");
                        break;
                    }

                    //Вывод изменённого массива
                    Console.WriteLine("\n"+"Modified array:=");
                    PrintArray(modifiedArray);
                }
                catch (NullReferenceException) 
                {
                    Console.WriteLine("\n" + "Got null value");
                }

                break;

            case 4: //В массиве целых чисел утроить каждый положительный элемент, который стоит перед отрицательным.
                try {

                    //Получаем исходный массив
                    int[] modifiedArray = GetArray();

                    for(int i=0;i<modifiedArray.Length-1;i++) 
                    {

                        if (modifiedArray[i]>0 && modifiedArray[i+1]<0)  
                        {
                            modifiedArray[i] = modifiedArray[i] * 3;
                        }

                    }

                    Console.WriteLine("\n");

                    //Вывод изменённого массива
                    Console.WriteLine("Modified array:=");
                    PrintArray(modifiedArray);

                } catch (NullReferenceException) {

                    Console.WriteLine("\n" + "Got null value") ;
                }

                break;


            case 5: //В массиве целых чисел найти разницу между средним арифметическим и значение минимального элемента

                try {

                    int minElement = ARRAY_MAX_VALUE;
                    double average = 0, result = 0, summ = 0;

                    //Получаем исходный массив
                    int[] modifiedArray = GetArray();
                    for(int i=0;i<modifiedArray.Length;i++) 
                    {
                        //Считаем сумму
                        summ += modifiedArray[i];

                        //Поиск минимального
                        if (modifiedArray[i]<minElement) {

                            minElement = modifiedArray[i];
                        }
                    }

                    //Считаем среднее арифм.
                    average = summ/ARRAY_LENGTH;

                    //Считаем разницу
                    result = average - minElement;
                    Console.WriteLine("\n" + "Result=" + result);
                    Console.WriteLine("\n");

                } catch (NullReferenceException) {

                    Console.WriteLine("\n" + "Got null value");
                }

                break;


            case 6: //В массиве целых чисел вывести все элементы, которые встречаются больше одного раза и индексы которых нечётные

                try {


                    int[] srcArray = GetArray();
                    int[] modifiedArray = GetArray();
                    var oneMoreTimeValues = new List<Int32>();

                    Console.WriteLine("\n" + "Result=");

                    Array.Sort(modifiedArray);
                   
                    for(int i=0;i<modifiedArray.Length-1;i++) 
                    {
                        //Добавляем в лист все элементы, которые встречаются более одного раза
                        if(modifiedArray[i] == modifiedArray[i+1]){
                            oneMoreTimeValues.Add(modifiedArray[i]);
                        }
                    }

                    //Проверяем, есть ли элементы в листе, которые стоят на нечетных позициях в исходном массиве
                    for (int i=1;i<srcArray.Length;i+=2) {
                        if (oneMoreTimeValues.Contains(srcArray[i])) {
                            Console.WriteLine(" " + srcArray[i]);
                        }
                    }


                } catch (IndexOutOfRangeException e) {

                    Console.WriteLine("\n" + "ArrayIndexOut, see error log below!");
                    Console.WriteLine(e.ToString());
                }

                break;


            default: Console.WriteLine("\n" + "Invalid task number, try again!");
                ModifyArray(SetTaskNumberFromConsole());
                break;
        }
    }

        private int[] GetArray()
        {
            return this.sourceArray;
        }


    }
}
