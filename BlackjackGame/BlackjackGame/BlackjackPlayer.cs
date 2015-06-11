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
                    cardsToAdd = Blackjack.dealSomeCards(1); //get one card for dealer
                    this.hand.Add(cardsToAdd[0]); //add card to dealer's hand
                    this.hand.Add("XX"); //represents hole card of dealer
                   
                    break;

                case "standBtn_Click":
                    //TODO: implement logic for when dealer should stop getting cards

                    this.hand.RemoveAt(1); //removes "XX" from dealer's hand
                    cardsToAdd = Blackjack.dealSomeCards(1); //dealer gets his hole card 
                    this.hand.Add(cardsToAdd[0]);

                    break;

                default:
                    break;

            }

        }

        public string displayHand()
        {
            return string.Join(" ", hand.ToArray());//converts List<string> into a string with
            //elements separated by a space

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
