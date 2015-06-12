using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BlackjackGame
{
    class BlackjackPlayer
    {
        
        public List<string> hand = new List<string>(); //contains cards

        //init var for keeping track of each player's hand value
        public int total;

        public static BlackjackPlayer You = new BlackjackPlayer();
        public static BlackjackPlayer Dealer = new BlackjackPlayer();



        public void addToYourHand([CallerMemberName]string memberName = "")
        {
            List<string> cardsToAdd;
            //take action depending on which button click called the method

           

            switch (memberName)
            {
                case "dealBtn_Click":
                    cardsToAdd = Blackjack.dealSomeCards(2); //get two cards for me                 
                    this.hand.Add(cardsToAdd[0]); //add first two cards to my hand...
                    this.hand.Add(cardsToAdd[1]);    
                    break;

                case "hitBtn_Click":
                    cardsToAdd = Blackjack.dealSomeCards(1);
                    this.hand.Add(cardsToAdd[0]); //only add one card to hand if hit is clicked
                    break;

                default:
                    break;

            }
            
           
        }

        public void addToDealersHand([CallerMemberName]string memberName = "")
        {
            List<string> cardsToAdd;
            //take action depending on which button click called the method

            //if deal was clicked

            switch (memberName)
            {
                case "dealBtn_Click":
                    cardsToAdd = Blackjack.dealSomeCards(2); //get two cards for dealer
                    this.hand.Add(cardsToAdd[0]); //add cards to dealer's hand
                    this.hand.Add(cardsToAdd[1]);                                    
                    break;

                default:
                    break;

            }
            

            if(Form1.playerHasStood)
            {
                
                cardsToAdd = Blackjack.dealSomeCards(1);
                this.hand.Add(cardsToAdd[0]);
            }



        }

        public string displayPlayerHand()
        {
            return string.Join(" ", hand.ToArray());//converts List<string> into a string with
            //elements separated by a space

        }

        public string displayDealerHand() //only call for initial deal
        {
           
            string temp = String.Join(" ", hand);
            string holeCardCensored = temp.Replace(hand[1], "XX");
            return holeCardCensored;
            

        }

        

        public void emptyHand()
        {
            this.hand.Clear();
        }

        public int getTotal()
        {
            return total;
        }

        public void addSomeValues(int num)

        {
            for (int i = 0; i < num; i++)
            {
                int value;

                Blackjack.numsToValue.TryGetValue(
                    (Blackjack.deck[i + Blackjack.numDealt]), out value);

               this.total += value;
            }
        }






    }
}
