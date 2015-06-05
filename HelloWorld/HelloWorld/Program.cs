using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello world");
            for (int i = 0; i < 10; i++)
            {
               // Console.WriteLine(i.ToString());
               if (i == 7)
                {
                    Console.WriteLine("Found seven.");
                    break;
                }
            }

            for (int myvalue = 0; myvalue < 12; myvalue++)
            {

            }

            Console.ReadLine();


        }
    }
}
