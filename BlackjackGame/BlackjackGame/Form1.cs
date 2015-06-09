using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlackjackGame
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            dealerHand.AppendText(" 2c 4c Kd 6s");
            Blackjack.associateNumsWithCards();

            Blackjack.testPrint();
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

        }

        private void hitBtn_Click(object sender, EventArgs e)
        {

        }

        private void standBtn_Click(object sender, EventArgs e)
        {

        }
    }
}