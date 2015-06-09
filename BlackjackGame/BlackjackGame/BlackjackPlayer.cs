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
        List<string> hand = new List<string>(); //contains cards
        int total; //for keeping track of each player's hand value

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
                    cardsToAdd = Blackjack.dealSomeCards(2); //get two cards for me
                    this.hand.Add(cardsToAdd[0]); //add first two cards to my hand...
                    this.hand.Add(cardsToAdd[1]);
                    break;

                case "standBtn_Click":
                   //TODO: implement logic for when dealer should stop getting cards
                    break;

                default:
                    break;

            }

        }

        public string getHand()
        {
            return string.Join(" ", hand.ToArray());

        }

        




    }
}
