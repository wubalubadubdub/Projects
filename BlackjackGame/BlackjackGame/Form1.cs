using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlackjackGame
{
    public partial class Form1 : Form


    {


        int aceIndex = 0; //for keeping track of aces in the player's hand
        public static bool playerHasStood = false;




        public Form1()
        {


            InitializeComponent();

            //starting states for the three buttons
            dealBtn.Enabled = true;
            hitBtn.Enabled = false;
            standBtn.Enabled = false;

            Blackjack.associateNumsWithCards();
            Blackjack.associateNumsWithValues();

           
        }

        private void dealerHand_TextChanged(object sender, EventArgs e)
        {

        }

        private void playerHand_TextChanged(object sender, EventArgs e)
        {

        }

        private void totals_TextChanged(object sender, EventArgs e)
        {

        }

        private void results_TextChanged(object sender, EventArgs e)
        {

        }

        private void dealBtn_Click(object sender, EventArgs e)
        {
            Blackjack.shuffle(Blackjack.getDeck()); //shuffle before every deal

            //clear out previous cards, if any
            this.clearHands();

            //clear previous scores and states
            BlackjackPlayer.You.total = 0;
            BlackjackPlayer.Dealer.total = 0;
            totals.Text = "";
            aceIndex = 0;
            playerHasStood = false;




            //restore default btn states
            dealBtn.Enabled = false;
            hitBtn.Enabled = true;
            standBtn.Enabled = true;

            BlackjackPlayer.You.addSomeValues(2); //adds the value of your cards together
            BlackjackPlayer.You.addToYourHand(); //we have two cards in our hand as a list of str
                                                 //when this call finishes

            //we want to add the dealer's cards together but not show their sum until the stand
            //button has been clicked
            BlackjackPlayer.Dealer.addSomeValues(2);
            BlackjackPlayer.Dealer.addToDealersHand();


            //display hands
            playerHand.Text = BlackjackPlayer.You.displayPlayerHand();
            dealerHand.Text = BlackjackPlayer.Dealer.displayDealerHand();

            //display the players' totals
            displayTotals();

            checkPlayerTotal(); //checks to see if we have blackjack
                                //this needs to be called after displayTotals because otherwise the text would 
                                //just be reset to our score and we wouldn't see the "Blackjack!" message

            checkDealerTotal(); //checks to see if dealer has blackjack




        }

        private void hitBtn_Click(object sender, EventArgs e)
        {
            dealBtn.Enabled = false;
            BlackjackPlayer.You.addSomeValues(1); //must come before addToYourHand
            displayTotals();


            BlackjackPlayer.You.addToYourHand();
            playerHand.Text = BlackjackPlayer.You.displayPlayerHand();
            checkPlayerTotal(); //checks to see if we're over 21

        }

        private void standBtn_Click(object sender, EventArgs e)
        {
            //set button states and flag for player having stood so that the 
            //dealer's second card will be revealed
            dealBtn.Enabled = true;
            hitBtn.Enabled = false;
            standBtn.Enabled = false;
            playerHasStood = true;

            showDealerHoleCard();

            dealerDraw(); // makes dealer draw according to predefined rules
                          
        }

        private void clearHands()
        {

            //set each player's hand to contain nothing and clear the displayed
            //cards from the screen
            BlackjackPlayer.You.emptyHand();
            BlackjackPlayer.Dealer.emptyHand();
            playerHand.Text = "";
            dealerHand.Text = "";
            Blackjack.numDealt = 0; //reset counter of cards dealt
        }

        private void displayTotals()
        {
            //remove the value of the 2nd dealer card if player hasn't stood yet



            int dealersSecondCard;

            Blackjack.numsToValue.TryGetValue(Blackjack.deck[3], out dealersSecondCard);

            int hiddenTotal = BlackjackPlayer.Dealer.getTotal() - dealersSecondCard;

            //if player has stood or if player has blackjack, display the full totals for both players
            if (playerHasStood || (BlackjackPlayer.You.total == 21 &&
                BlackjackPlayer.You.hand.Count == 2))
                totals.Text = "You: " + BlackjackPlayer.You.getTotal() +
                    "  Dealer: " + BlackjackPlayer.Dealer.getTotal();

            else
                totals.Text = "You: " + BlackjackPlayer.You.getTotal() +
                     "  Dealer: " + hiddenTotal;
        }

        private void checkPlayerTotal()
        {
            int yourTotal = BlackjackPlayer.You.getTotal();
            string yourHand = string.Join(" ", BlackjackPlayer.You.hand.ToArray());
            int aceLoc = yourHand.IndexOf('A', aceIndex);
            int numCards = BlackjackPlayer.You.hand.Count;





            //checks to see if your total is over 21. if it is, it checks to see if
            //you have an ace you haven't used yet, and if you do, subtracts 10 from 
            //your total
            if (yourTotal > 21)
            {
                if (aceLoc != -1)
                {
                    BlackjackPlayer.You.total -= 10;
                    displayTotals();
                    aceIndex = aceLoc + 1;

                }
                else
                {
                    dealBtn.Enabled = true;
                    hitBtn.Enabled = false;
                    standBtn.Enabled = false;
                    totals.Text = yourTotal + ": Bust!";
                }
            }



            else if (yourTotal == 21 && numCards == 2) //if player has blackjack

            {
                dealBtn.Enabled = true;
                hitBtn.Enabled = false;
                standBtn.Enabled = false;

                showDealerHoleCard();



                if (BlackjackPlayer.Dealer.total == 21 &&
                    BlackjackPlayer.Dealer.hand.Count == 2)
                {

                    totals.Text = "You both have blackjack! It's a push";

                }

                else
                {

                    totals.Text = "Blackjack! You win!";
                }

            }


        }

        private void checkDealerTotal()
        {
            int dealerTotal = BlackjackPlayer.Dealer.getTotal();
            string dealerHand = string.Join(" ", BlackjackPlayer.Dealer.hand.ToArray());
            int aceLoc = dealerHand.IndexOf('A', aceIndex); //aceLocal and numCards are local vars
            int numCards = BlackjackPlayer.Dealer.hand.Count;

            if (dealerTotal > 21)
            {
                if (aceLoc != -1)
                {
                    BlackjackPlayer.Dealer.total -= 10;
                    displayTotals();
                    aceIndex = aceLoc + 1;

                }
                else
                {
                    dealBtn.Enabled = true;
                    hitBtn.Enabled = false;
                    standBtn.Enabled = false;
                    totals.Text = dealerTotal + ": Dealer Bust!";
                }
            }



            else if (dealerTotal == 21 && numCards == 2) //if dealer has blackjack

            {
                showDealerHoleCard();

                if (BlackjackPlayer.You.total == 21 &&  //if player also has blackjack
                    BlackjackPlayer.You.hand.Count == 2)
                {
                    dealBtn.Enabled = true;
                    hitBtn.Enabled = false;
                    standBtn.Enabled = false;
                    totals.Text = "You both have blackjack! It's a tie.";
                }

                else
                {
                    dealBtn.Enabled = true;
                    hitBtn.Enabled = false;
                    standBtn.Enabled = false;
                    totals.Text = "Dealer has blackjack. Dealer wins.";
                }

            }



        }

        public void showDealerHoleCard()
        {
            dealerHand.Text = String.Join(" ", BlackjackPlayer.Dealer.hand);
            //the hand still actually contains both cards. we only created a string
            //and replaced the second card with XX, and this sets the text to both
            //of the dealer's actual cards
        }

        public void dealerDraw()
        {
            while (BlackjackPlayer.Dealer.getTotal() < 17)
            {   //dealer stands on any 17
                BlackjackPlayer.Dealer.addSomeValues(1);
                BlackjackPlayer.Dealer.addToDealersHand();
                checkDealerTotal();

            }


            displayTotals();
           
            showDealerHoleCard();       
            dealBtn.Enabled = true;
            hitBtn.Enabled = false;
            standBtn.Enabled = false;



        }
    }
}