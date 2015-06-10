using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackjackGame
{
    class Blackjack
    {
        public static int[] deck = Enumerable.Range(0, 52).ToArray();
        //first num is where to start, 2nd num is how many nums
        //(includ. start num) you want in the range. that's 52 for 52 cards
        //int a = a[i] = i in the unshuffled deck

        //create arrays for ranks and suits, to be used in displaying the cards
        static string[] ranks = {"2", "3", "4", "5", "6", "7", "8", "9",
            "10", "J", "Q", "K", "A" };
        static string[] suits = { "h", "s", "c", "d" };

        public static int numDealt = 0;

        
       


        private static Random r = new Random();

        //associate each number in the int array deck with a string that will 
        //displayed as a card
        public static Dictionary<int, string> numsToCards = new Dictionary<int, string>();

        //associate each number in the int array with a numeric value
        public static Dictionary<int, int> numsToValue = new Dictionary<int, int>();

        public static void associateNumsWithCards()
        {
            //add a key,value pair for each int in deck and a string composed of a rank+suit
            for (int i = 0; i < 52; i++)
            {
                if (i < 13)
                {
                    numsToCards.Add(i, ranks[i] + suits[0]);

                }

                if (i >= 13 && i < 26)
                {
                    numsToCards.Add(i, ranks[i - 13] + suits[1]); //rank elements go from 0 to 12
                    //so in this and the subsequent ifs, an offset is required
                }

                if (i >= 26 && i < 39)
                {
                    numsToCards.Add(i, ranks[i - 26] + suits[2]);
                }

                if (i >= 39 && i < 52)
                {
                    numsToCards.Add(i, ranks[i - 39] + suits[3]);
                }
            }
        }

        public static void associateNumsWithValues()
        {
            for(int i = 0; i < 52; i++)
            {
                int remainder = i % 13;

                switch(remainder)
                {
                    case 0: //i is a multiple of 13
                        numsToValue.Add(i, 2); //i = 0 corresponds to 2h, 
                        //i = 13 corresponds to 2d, etc. 
                        break;

                    case 1: //1+i is a multiple of 13. 1 = 3h, 14 = 3d, etc. 
                        numsToValue.Add(i, 3);
                        break;

                    case 2: //2+i is a multiple of 13. 2 = 4h, 15 = 4d, etc. 
                        numsToValue.Add(i, 4);
                        break;

                    case 3:
                        numsToValue.Add(i, 5);
                        break;

                    case 4:
                        numsToValue.Add(i, 6);
                        break;

                    case 5:
                        numsToValue.Add(i, 7);
                        break;

                    case 6:
                        numsToValue.Add(i, 8);
                        break;

                    case 7:
                        numsToValue.Add(i, 9);
                        break;

                        //cases where int reps. 10, J, Q,  or K
                    case 8:
                    case 9:
                    case 10:
                    case 11:
                        numsToValue.Add(i, 10);
                        break;

                    case 12:
                        numsToValue.Add(i, 11); //count ace as 11, will count as 1 as needed
                        break;

                }
                
            }
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

        public static List<string> dealSomeCards(int numCardsToDeal)
        {
            
            List<string> cards = new List<string>();
           


            for (int i = 0; i < numCardsToDeal; i++)
            {
                string card;
                
                numsToCards.TryGetValue((deck[i + numDealt]), out card); //get the card associated
                //with the randomly ordered ints in the deck, adjusting by the number of cards we've
                //already dealt

                cards.Add(card);

               
                
                


            


            }



            numDealt += numCardsToDeal; //keep track of how many cards we've dealt
                                        //so that we can adjust the index in the line above accordingly

            return cards;

        }

       

        

        



















       



        public static int[] getDeck()
        {
            return deck;
        }


    }

}