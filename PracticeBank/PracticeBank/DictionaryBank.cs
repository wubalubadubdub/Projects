using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeBank
{
    public class DictionaryBank : IBank
    {
        public Dictionary<string, IAccount> accounts =
           new Dictionary<string, IAccount>();

        public bool StoreAccount(IAccount account)
        {
            accounts.Add(account.getName(), account);
            //the name of our new account becomes a key in the dictionary
            //associated with the reference to our new account, which is
            //what we pass into the method
            return true;
        }

        public IAccount FindAccount(string name)
        {
            return accounts[name]; //cast to IAccount is not needed as all dictionary
            //objects are of the type IAccount
        }

        //create save and load methods that can be called on instances of DictionaryBank to
        //save all accounts to the same file by using a stream and load all accounts from that stream

        public bool Save(string filename)
        {
            TextWriter textOut = null;
            try
            {
                textOut = new StreamWriter(filename);
                foreach (IAccount account in accounts.Values)
                {
                    textOut.WriteLine(account.GetType().Name);
                    account.Save(textOut);
                }
            }
            catch
            {
                return false;
            }
            finally
            {
                textOut.Close();
            }
            return true;
        }
    }
}