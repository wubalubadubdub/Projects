using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeBank
{
    internal class AccountFactory
    {
        public static IAccount MakeAccount(
            string name, TextReader textIn)

        {
            switch (name)
            {
                case "CustomerAccount":
                    return new CustomerAccount(textIn);
            }
        }
    }
}