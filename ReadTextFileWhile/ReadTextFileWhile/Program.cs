using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadTextFileWhile
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader myReader = new StreamReader("values.txt"); 
            string line = "";

            /* be sure that for values.txt, under properties, copy is set to copy always/copy if newer
            so that the textfile goes into our bin directory when the program is compiled
            */

            while (line != null) //null refers to an unknown or indeterminate value, not an empty one
                //when we reach the end of the text file the value becomes null
            {
                line = myReader.ReadLine();
                if (line != null)
                    Console.WriteLine(line);
            }

            myReader.Close();
            Console.ReadLine();




        }
    }
}
