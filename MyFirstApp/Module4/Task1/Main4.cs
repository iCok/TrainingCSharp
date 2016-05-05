using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyFirstApp.Module4.Task1;

namespace MyFirstApp.Module4.Task1
{
    class Main4
    {
        DynamicArray<Int32> dynamicArray = new DynamicArray<Int32>(3);

        static void Main(string[] args)
        {
            Main4 main = new Main4();

            main.checkAdd();
            main.checkGet();
            main.checkRemove();
            Console.ReadLine();

        }

        private void checkAdd() {

        for (int i=0; i<20; i++) {
            dynamicArray.add(i);
        }

        Console.WriteLine("Check adding method with 20 iteration: " + dynamicArray.ToString());
            
    }


    private void checkGet() {

        var array = new DynamicArray<Int32>(3);

        for (int i=0; i<20; i++) {
           array.add(dynamicArray.get(i));
        }
        Console.WriteLine("Check getting method with 20 iteration: " + array.ToString());
    }


    private void checkRemove() {

        for (int i=20; i>0; i--) {
            dynamicArray.remove(i);
        }
        Console.WriteLine("Check removing method with 20 iteration: " + dynamicArray.ToString());
    }

    }
}
