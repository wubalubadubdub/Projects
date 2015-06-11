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




        public Form1()
        {
           

            InitializeComponent();

            //starting states for the three buttons
            dealBtn.Enabled = true;
            hitBtn.Enabled = false;
            standBtn.Enabled = false;

            Blackjack.associateNumsWithCards();
            Blackjack.associateNumsWithValues();

            //TextWriter t = new StreamWriter("valuesdict.txt");
            //foreach (KeyValuePair<int, int> pair in Blackjack.numsToValue)
            //    t.WriteLine(pair);
            //t.Close();

            //TextWriter t2 = new StreamWriter("dict.txt");
            //foreach (KeyValuePair<int, string> p2 in Blackjack.numsToCards)
            //    t2.WriteLine(p2);
            //t2.Close();

          



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


            

            //restore default btn states
            dealBtn.Enabled = false;
            hitBtn.Enabled = true;
            standBtn.Enabled = true;

            BlackjackPlayer.You.addSomeValues(2); //adds the value of your cards together
            BlackjackPlayer.You.addToYourHand(); //we have two cards in our hand as a list of str
            //when this call finishes
           
            BlackjackPlayer.Dealer.addSomeValues(1); //dealer only gets one card to start
            BlackjackPlayer.Dealer.addToDealersHand();
            

            //display hands
            playerHand.Text = BlackjackPlayer.You.displayHand();
            dealerHand.Text = BlackjackPlayer.Dealer.displayHand();

            //display the players' totals
            displayTotals();

            checkPlayerTotal(); //checks to see if we have blackjack
            //this needs to be called after displayTotals because otherwise the text would 
            //just be reset to our score and we wouldn't see the "Blackjack!" message



        }

        private void hitBtn_Click(object sender, EventArgs e)
        {
            dealBtn.Enabled = false;
            BlackjackPlayer.You.addSomeValues(1); //must come before addToYourHand
            displayTotals();
            
            
            BlackjackPlayer.You.addToYourHand();
           
            playerHand.Text = BlackjackPlayer.You.displayHand();
            checkPlayerTotal(); //checks to see if we're over 21

        }

        private void standBtn_Click(object sender, EventArgs e)
        {
            dealBtn.Enabled = true;
            hitBtn.Enabled = false;
            standBtn.Enabled = false;




            //give the dealer another card and display it
            BlackjackPlayer.Dealer.addSomeValues(1);
            BlackjackPlayer.Dealer.addToDealersHand();
            dealerHand.Text = BlackjackPlayer.Dealer.displayHand();
            displayTotals();


            //TODO: call method that makes dealer draw according to 
            //predefined rules

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
            totals.Text = "You: " + BlackjackPlayer.You.getTotal() + 
                "  Dealer: " + BlackjackPlayer.Dealer.getTotal();
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
                BlackjackPlayer.Dealer.hand.RemoveAt(1); //removes "XX" from dealer's hand
                BlackjackPlayer.Dealer.addSomeValues(1); //dealer needs a second card
                //immediately if we get a blackjack, so that he has a chance for one as well
                BlackjackPlayer.Dealer.addToDealersHand();
                dealerHand.Text = BlackjackPlayer.Dealer.displayHand();



                if (BlackjackPlayer.Dealer.total == 21 &&
                    BlackjackPlayer.Dealer.hand.Count == 2)
                {
                    dealBtn.Enabled = true;
                    hitBtn.Enabled = false;
                    standBtn.Enabled = false;
                    totals.Text = "You both have blackjack! It's a push";

                }

                else
                {
                    dealBtn.Enabled = true;
                    hitBtn.Enabled = false;
                    standBtn.Enabled = false;
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
                if(BlackjackPlayer.You.total == 21 && 
                    BlackjackPlayer.You.hand.Count == 2)
                {
                    dealBtn.Enabled = true;
                    hitBtn.Enabled = false;
                    standBtn.Enabled = false;
                    totals.Text = "You both have blackjack! It's a push.";
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


    }
}