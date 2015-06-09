using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeBank
{
    public class ChildAccount : CustomerAccount, IAccount

    {
        private string parentName;

        public string getParentName()
        {
            return parentName;
        }

        public override bool WithdrawFunds(decimal amount) //you override methods that are
                                                           //abstract or virtual
        {
            if (amount > 10)
            {
                return false;
            }

            return base.WithdrawFunds(amount); //calls the method that we are overriding
            //this is the rest of the method that we need
        }

        public override string RudeLetterString()
        {
            return "Tell your daddy you are overdrawn";
        }

        public ChildAccount(string inName, decimal inBalance, string inParentName) :
            base(inName, inBalance)
        {
            parentName = inParentName;
        }

        public override void Save(TextWriter textOut)
        {
            base.Save(textOut);
            textOut.WriteLine(parentName);
        }

        //public ChildAccount(TextReader textIn):
        //    base (textIn)
        //{
        //    parentName = textIn.ReadLine();
        //}
    }
}