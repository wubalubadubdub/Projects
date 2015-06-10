using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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

      
       

        public Form1()
        {
           

            InitializeComponent();

            //starting states for the three buttons
            dealBtn.Enabled = true;
            hitBtn.Enabled = false;
            standBtn.Enabled = false;

            Blackjack.associateNumsWithCards();
            

          



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

            //restore default btn states
            dealBtn.Enabled = false;
            hitBtn.Enabled = true;
            standBtn.Enabled = true;

            BlackjackPlayer.You.addToYourHand();
            BlackjackPlayer.Dealer.addToDealersHand();
            playerHand.Text = BlackjackPlayer.You.displayHand();
            dealerHand.Text = BlackjackPlayer.Dealer.displayHand();
           
            

        }

        private void hitBtn_Click(object sender, EventArgs e)
        {
            dealBtn.Enabled = false;
            BlackjackPlayer.You.addToYourHand();
            playerHand.Text = BlackjackPlayer.You.displayHand();

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

        
    }
}