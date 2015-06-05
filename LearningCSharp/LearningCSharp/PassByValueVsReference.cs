using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassByValueVsReference
{
    class LearningCSharp
    {
        
        /*
            int test = 20;
            addOneToParam(test);
            Console.WriteLine("test is " + test);

            the above shows that i is 21 but test is still 20
            this is because we didn't pass the actual variable into the method, 
            but just the value of it, which is 20. this is called pass by value. 
            the test variable was not increased by 1. nothing the method does can
            affect variables in the code that calls it when pass by value is used. 
            
            

            test = 20; //reset test to 20 for second example
            addOneToRefParam(ref test);
            Console.WriteLine("test is " + test);

            /*here we've passed in not the value of test, but a reference to test, which
            is its location in memory. now test will be modified to equal 21 just like i 
            will be. this is called pass by reference. passing by reference allows us to 
            use methods to change the values of variables outside of them. this is called
            a "side effect" of the method

            run the above code in the main method of MainForTesting.cs to see the idea in action


            */

            

           




        

        static void addOneToParam(int i)
        {
            
            i++;
            Console.WriteLine("i is " + i);
           
        }

        static void addOneToRefParam(ref int i)
        {
            
            i++;
            Console.WriteLine("i is " + i);
        }
    }
}
