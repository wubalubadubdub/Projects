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
        [DllImport("user32.dll")]
        static extern bool HideCaret(IntPtr hWnd);
        //for hiding the blinking cursor in textboxes

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
            HideCaret(dealerHand.Handle);
        }

        private void playerHand_TextChanged(object sender, EventArgs e)
        {
            HideCaret(playerHand.Handle);
        }

        private void totals_TextChanged(object sender, EventArgs e)
        {
            HideCaret(totals.Handle);
        }

        private void results_TextChanged(object sender, EventArgs e)
        {
            HideCaret(results.Handle);
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
            BlackjackPlayer.You.addToYourHand();

            BlackjackPlayer.Dealer.addSomeValues(1); //dealer only gets one card to start
            BlackjackPlayer.Dealer.addToDealersHand();
            

            //display hands
            playerHand.Text = BlackjackPlayer.You.displayHand();
            dealerHand.Text = BlackjackPlayer.Dealer.displayHand();

            //display the players' totals
            displayTotals();
            

        }

        private void hitBtn_Click(object sender, EventArgs e)
        {
            dealBtn.Enabled = false;
            BlackjackPlayer.You.addSomeValues(1);
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
            BlackjackPlayer.Dealer.addToDealersHand();
            dealerHand.Text = BlackjackPlayer.Dealer.displayHand();


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

            
            

            //checks to see if your total is over 21. if it is, it checks to see if
            //you have an ace you haven't used yet, and if you do, subtracts 10 from 
            //your total
            if(yourTotal > 21)
            {
                if (aceLoc != -1) {
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
            else if(yourTotal < 21) //we need to count the ace even if its value will be 11 
                
            {
                if (aceLoc != -1)
                {
                    aceIndex = aceLoc + 1;
                }
            }
        }

        
    }
}