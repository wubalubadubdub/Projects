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
            
            Blackjack.associateNumsWithCards();
            Blackjack.shuffle(Blackjack.getDeck());

            //playerHand.Text = BlackjackPlayer.You.getHand().ToString();
            //dealerHand.Text = BlackjackPlayer.Dealer.getHand().ToString();




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
            BlackjackPlayer.You.addToYourHand();
            BlackjackPlayer.Dealer.addToDealersHand();
            playerHand.Text = BlackjackPlayer.You.getHand();
            dealerHand.Text = BlackjackPlayer.Dealer.getHand();
           
            

        }

        private void hitBtn_Click(object sender, EventArgs e)
        {

        }

        private void standBtn_Click(object sender, EventArgs e)
        {

        }

        public static void displayYourHand()
        {
            
           
                 
        }
    }
}