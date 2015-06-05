using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelperMethods
{
    class Program
    {
        static void Main(string[] args)
        {
            string myValue = superSecretFormula("ya dingus");
            Console.WriteLine(myValue);
            Console.ReadLine();
        }

        private static string superSecretFormula() //name convention for private methods
        {
            //some stuff here
            return "Hello World";
        }

        private static string superSecretFormula(string name) //this method is called instead of the one above
            //when you pass in a string

        
        {
            return String.Format("Hello, {0}", name);
        }
        // creating versions of the same method name but different input parameters/data type is called overloading

    }
}
