using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeBank
{
    public abstract class Account : IAccount
    {
        protected decimal balance = 0;
        protected string name;

        public abstract string RudeLetterString(); //each child class provides its own implementation

        public virtual bool WithdrawFunds(decimal amount) //allows method to be overriden in child class
        {
            if (balance < amount)

            {
                return false;
            }

            balance -= amount;

            return true;
        }

        //these two methods are the same for all account objects
        public decimal GetBalance()
        {
            return balance;
        }

        public void PayInFunds(decimal amount)
        {
            balance += amount;
        }

        public override string ToString()
        {
            return ("Name: " + name + " Balance: " + balance);
        }

        //create a constructor
        public Account(string inName, decimal inBalance)

        {
            name = inName;

            balance = inBalance;
        }

        public string getName()
        {
            return name;
        }

        public abstract bool Save(string filename);

        public abstract void Save(TextWriter textOut);

        private static void Main(string[] args)
        {
            //Account a = new CustomerAccount("Cluf Drangus", 3.50m);
            //Console.WriteLine(a.ToString());

            //Account b = new ChildAccount("Wubwub", 40m, "male");
            //Console.WriteLine(b.ToString());

            //Console.WriteLine(b.getName());

            IBank friendlyBank = new DictionaryBank(); //creates a new dictionary bank called friendlyBank
            //our DictionaryBank is a class that contains methods to store and retreive acct info in a
            //dictionary, which is a typesafe form of a hashtable
            IAccount bobsAccount = new CustomerAccount("Bob", 0); //account can refer to any Account class that
            //implements the IAccount interface
            friendlyBank.StoreAccount(bobsAccount); //stores the new account in friendly Bank
            Console.WriteLine(friendlyBank.FindAccount("Bob"));
            //implicitly calls our toString method that prints out the name and balance of the account object
            //Console.WriteLine(bobsAccount); //does the same as the above line
            IAccount tomsAccount = new CustomerAccount("Tom", 50);
            IAccount johnsAccount = new ChildAccount("John", 10, "Dan");

            friendlyBank.StoreAccount(tomsAccount);
            friendlyBank.StoreAccount(johnsAccount);

            IAccount billysAccount = new CustomerAccount("Billy", 23);
            friendlyBank.StoreAccount(billysAccount);

            friendlyBank.Save("test.txt");
            billysAccount.Save("billy.txt");
        }
    }
}