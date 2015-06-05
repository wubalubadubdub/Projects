using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LearningCSharp
{
    class MainForTesting
    {
        static void Main(string[] args)
        {
            /*
            string filePath = "C:\\Users\\intensiveporpoises\\Documents\\misc\\";
            StreamWriter writer = new StreamWriter(filePath + "writetest.txt");
            writer.WriteLine("ey b0ss can i habe da p0ssy pls");
            writer.Close();
            */
            string filePath = @"C:\Users\intensiveporpoises\Documents\misc\";
            //with @ it isn't necessary to escape each \ in the code above
            StreamReader reader = new StreamReader(filePath + "rsa.txt");
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                Console.WriteLine(line);
            }
            reader.Close();
            


        }
    }

}
