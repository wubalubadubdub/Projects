using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeBank
{
    public interface IBank
    {
        IAccount FindAccount(string name); //method that finds an account

        //that implements the IAccount interface based on the name provided

        bool StoreAccount(IAccount account); //method that takes in an account

        //that implements IAccount interface and stores it

        //a class that implements these methods can be used for the storage of accounts

        bool Save(string filename);
    }
}