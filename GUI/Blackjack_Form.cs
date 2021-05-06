using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using GameObjects;
using Games;

namespace GUI {
    /// <summary>
    /// Blackjack_Form is subclass of Form. 
    /// <author>Yanmei Zeng 10307389</author>
    /// <author>Yasaman Gorjinejad 10295647</author>
    /// </summary>
    public partial class Blackjack_Form : Form {
        /// <summary>
        /// Display the images of the cards. 
        /// </summary>
        private void DisplayHand(Hand hand, TableLayoutPanel panel, bool showAllCards = true) {
            panel.Controls.Clear();
            panel.ColumnStyles.Clear();
            panel.ColumnCount = hand.Count;
            for (int i = 0; i < hand.Count; i++) {
                panel.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
                PictureBox picCard = new PictureBox();
                picCard.SizeMode = PictureBoxSizeMode.AutoSize;
                if ((!showAllCards && i == 0) || showAllCards) {
                    picCard.Image = Images.GetCardImage(hand.GetCard(i));
                } else {
                    picCard.Image = Images.GetBackOfCardImage();
                }
                panel.Controls.Add(picCard, i, 0);
            }
        }

        public Blackjack_Form() {
            InitializeComponent();
            picCard.Image = Images.GetBackOfCardImage();
            Reset();
        }
        /// <summary>
        /// reset method will reset the game make the game as it was original 
        /// so the moeny will be 1000 
        /// all the buttons will be disable except Deal and Reset. 
        /// the cards and labels for score will be disappear. 
        /// </summary>
        public void Reset() {
            Blackjack.Reset();
            nudBet.Maximum = Blackjack.PlayerFunds;
            lblMoeny.Text = string.Format("{0:C}", Blackjack.PlayerFunds);
            tblPlayerHand.Controls.Clear();
            tblDealerHand.Controls.Clear();
            tblPlayerHand2.Controls.Clear();
            lblPlayerInfo.Text = "";
            lblDealerInfo.Text = "";
            //disable all buttond except Deal and Reset.
            SetButtonEnabled(btnDeal, true);
            SetButtonEnabled(btnReset, true);

            SetButtonEnabled(btnHit, false);
            SetButtonEnabled(btnHit2, false);
            SetButtonEnabled(btnSplit, false);
            SetButtonEnabled(btnStand, false);
            SetButtonEnabled(btnStand2, false);
            SetButtonEnabled(btnSurrender, false);
            SetButtonEnabled(btnDouble, false);
            SetButtonEnabled(btnDouble2, false);
            //continue disabling all buttons
        }
        /// <summary>
        /// this methos simply will change the color of the buttons depends on
        /// if the button enable or disable 
        /// </summary>
        /// <param name="button">the buttons in the GUI</param>
        /// <param name="enable">the button is enable</param>
        public void SetButtonEnabled(Button button, bool enable = true) {
            button.Enabled = enable;
            // if button is anble set the color to yellow 
            if (enable) {
                button.BackColor = Color.Yellow;

            } else // if button is diable change the color to beige!
            {
                button.BackColor = Color.Beige;
            }
        }

        private void btnHit_Click(object sender, EventArgs e) {
            Blackjack.Hit(0);
            UpdateLabel();
        }

        private void btnDeal_Click(object sender, EventArgs e) {
            btnReset.Focus();
            lblInstruction.Text = "choose your move...";
            lblDealerInfo.Text = "";
            //start a new round 
            tblPlayerHand2.Controls.Clear();
            lblPlayer2.Text = "";
            Blackjack.NewRound((int)nudBet.Value);
            UpdateLabel();
            UpdateGUI();
            // update playerfunds 
            lblMoeny.Text = string.Format("{0:C}", Blackjack.PlayerFunds);
            if (Blackjack.CanPlayerPlay()) {
                SetButtonEnabled(btnDeal, false);
            }
        }
        /// <summary>
        /// this method will update the GUI so it will display hands and update it 
        /// set the buttons enable or disable depends on game rules.
        /// </summary>
        public void UpdateGUI() {
            //display hands
            DisplayHand(Blackjack.DealerHand, tblDealerHand, !Blackjack.CanPlayerPlay());
            DisplayHand(Blackjack.PlayerHands[0], tblPlayerHand, true);
            if (Blackjack.PlayerHands.Count == 2) {
                DisplayHand(Blackjack.PlayerHands[1], tblPlayerHand2, true);
            }

            // enable/disable buttons
            SetButtonEnabled(btnHit, Blackjack.CanHit(0));
            SetButtonEnabled(btnHit2, Blackjack.CanHit(1));
            SetButtonEnabled(btnSplit, Blackjack.CanSplit());
            SetButtonEnabled(btnStand, Blackjack.CanStand(0));
            SetButtonEnabled(btnStand2, Blackjack.CanStand(1));
            SetButtonEnabled(btnSurrender, Blackjack.CanSurrender());
            SetButtonEnabled(btnDouble, Blackjack.CanDouble(0));
            SetButtonEnabled(btnDouble2, Blackjack.CanDouble(1));
            nudBet.Maximum = Blackjack.PlayerFunds;
        }

        private void btnSplit_Click(object sender, EventArgs e) {
            Blackjack.Split();
            UpdateLabel();
        }

        private void btnReset_Click(object sender, EventArgs e) {
            Reset();
            btnDeal.Focus();
        }
        /// <summary>
        /// the main purpose of this method will update the label for both player and dealer hand.
        /// </summary>
        public void UpdateLabel() {
            if (!Blackjack.CanPlayerPlay()) {
                // Game is finishing 

                List<Blackjack.Result> results = Blackjack.DealerPlay();
                UpdateGUI();
                //for dealer it will just show the result when dealer goes Bust. plus, it will 
                // show the score at the end of the game. 
                lblDealerInfo.Text = string.Format("score: {0} {1}", Blackjack.DealerHand.Score,
                    Blackjack.DealerHand.Score > 21 ? "(BUST)" : "");
                // for both player hands it will show all the results at the end of the game, 
                //  also it will show score and bet at the end of the game.  
                lblPlayerInfo.Text = string.Format("score: {0},  Bet:{1:c}, ({2})", Blackjack.PlayerHands[0].Score,
                    Blackjack.PlayerHands[0].Bet, results[0]);
                // if there is 2 hand so do the same that it is done for the first hand. 
                if (Blackjack.PlayerHands.Count == 2) {
                    lblPlayer2.Text = string.Format("score: {0},  Bet:{1:c}, ({2})", Blackjack.PlayerHands[1].Score,
                        Blackjack.PlayerHands[1].Bet, results[1]);
                }
                // set the Deal button to enable. 
                SetButtonEnabled(btnDeal, true);
                // update the moeny lable 
                lblMoeny.Text = string.Format("{0:C}", Blackjack.PlayerFunds);
                lblInstruction.Text = "press deal to start a new round...";
            } else {
                // Game still Going 

                UpdateGUI();
                // show score and bet in player hand label while the game is still on ging. 
                lblPlayerInfo.Text = string.Format("score: {0},  Bet:{1:c}", Blackjack.PlayerHands[0].Score,
                    Blackjack.PlayerHands[0].Bet);
                // if there is 2 hand so do the same that it is done for the first hand. 
                if (Blackjack.PlayerHands.Count == 2) {
                    lblPlayer2.Text = string.Format("score: {0},  Bet:{1:c}", Blackjack.PlayerHands[1].Score,
                        Blackjack.PlayerHands[1].Bet);
                }
            }
        }

        private void btnDouble_Click(object sender, EventArgs e) {
            Blackjack.Double(0);
            UpdateLabel();
        }

        private void btnStand_Click(object sender, EventArgs e) {
            Blackjack.Stand(0);
            UpdateLabel();
        }

        private void btnSurrender_Click(object sender, EventArgs e) {
            Blackjack.Surrender();
            UpdateLabel();
        }

        private void btnHit2_Click(object sender, EventArgs e) {
            Blackjack.Hit(1);
            UpdateLabel();
        }

        private void btnDouble2_Click(object sender, EventArgs e) {
            Blackjack.Double(1);
            UpdateLabel();
        }

        private void btnStand2_Click(object sender, EventArgs e) {
            Blackjack.Stand(1);
            UpdateLabel();
        }


    }
}



