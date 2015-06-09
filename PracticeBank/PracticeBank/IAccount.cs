using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeBank
{
    public interface IAccount
    {
        void PayInFunds(decimal amount);

        bool WithdrawFunds(decimal amount);

        decimal GetBalance();

        string getName();

        bool Save(string filename);

        void Save(TextWriter textOut);
    }
}