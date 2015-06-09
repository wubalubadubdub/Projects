using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeBank
{
    public class CustomerAccount : Account, IAccount
    {
        public override string RudeLetterString()

        {
            return "You are overdrawn";
        }

        public CustomerAccount(string inName, decimal inBalance) :
            base(inName, inBalance)
        {
        }

        public override void Save(TextWriter textOut)
        {
            textOut.WriteLine(name);
            textOut.WriteLine(balance);
        }

        public override bool Save(string filename)
        {
            TextWriter textOut = null;
            try
            {
                textOut = new StreamWriter(filename);
                Save(textOut);
            }
            catch
            {
                return false;
            }
            finally
            {
                if (textOut != null)
                {
                    textOut.Close();
                }
            }
            return true;
        }
    }
}