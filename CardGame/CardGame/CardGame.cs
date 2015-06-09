using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    public abstract class CardGame
    {
        private static int[] deck = Enumerable.Range(0, 52).ToArray();
        //first num is where to start, 2nd num is how many nums
        //(includ. start num) you want in the range. that's 52 for 52 cards
        //int a = a[i] = i in the unshuffled deck

        private static Random r = new Random();

        private static void Main(string[] args)
        {
            foreach (int i in deck)
                Console.WriteLine(i);

            shuffle(deck);

            Console.WriteLine("\n");
            foreach (int i in deck)
                Console.WriteLine(i);
        }

        //implement fisher-yates shuffle
        public static void shuffle(int[] deck)
        {
            for (int n = deck.Length - 1; n > 0; --n)
            {
                int k = r.Next(n + 1); //gives a random int between 0 and 51
                int temp = deck[n]; //temp is where we are in the deck, starting
                //with deck[51] = 51 and counting down
                deck[n] = deck[k]; //give the int at deck[n] the value of the int at
                //random pos deck[k]
                deck[k] = temp; //give the int at deck[k] the value of the int at deck[n]
            }
        }
    }
}