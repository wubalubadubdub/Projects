using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Person
{
    class Student
    {
        //create vars for info about a student
        static string firstName, lastName, birthDate;
        static string adrLine1, adrLine2, city;
        static string stateOrProvince, zip, country;

        static void Main(string[] args)
        {



            readInfo(
                 out firstName, out lastName, out birthDate,
            out adrLine1, out adrLine2, out city,
            out stateOrProvince, out zip, out country

                );

            displayInfo();











        }

        static void readInfo(
            out string firstName, out string lastName, out string birthDate,
            out string adrLine1, out string adrLine2, out string city,
            out string stateOrProvince, out string zip, out string country

            )
        {
            firstName = readString("first name: ");
            lastName = readString("last name: ");
            birthDate = readString("date of birth (mm/dd/yyyy): ");
            adrLine1 = readString("street address, e.g. 123 Fake St: ");
            adrLine2 = readString("Apt or Unit number (enter n/a if doesn't apply): ");
            city = readString("city: ");
            stateOrProvince = readString("state or province: ");
            zip = readString("ZIP code: ");
            country = readString("country: ");



        }

        static string readString(string prompt)

        {
            string result;
            do
            {
                Console.WriteLine("Enter " + prompt); //e.g. prompt is "first name" -> "Enter first name: "
                result = Console.ReadLine();
            } while (result == "");

            return result;


        }

        static void displayInfo()
        {
            Console.WriteLine("Name: " + "\n{0}, {1}", lastName, firstName);
            Console.WriteLine("Date of Birth: " + birthDate);

            if (adrLine2 == "n/a") //if no apt #, don't display n/a
            {
                Console.WriteLine("Address: " + adrLine1);
            }
            else Console.WriteLine("Address: " + "{0}, {1}", adrLine1, adrLine2);

            Console.WriteLine("{0}, {1} {2}, {3}", city, stateOrProvince, zip, country);

            
        }



    }
}
