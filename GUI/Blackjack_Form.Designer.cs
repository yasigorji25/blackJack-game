namespace GUI {
    partial class Blackjack_Form {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.btnHit = new System.Windows.Forms.Button();
            this.btnStand = new System.Windows.Forms.Button();
            this.btnSurrender = new System.Windows.Forms.Button();
            this.btnSplit = new System.Windows.Forms.Button();
            this.btnHit2 = new System.Windows.Forms.Button();
            this.btnDouble2 = new System.Windows.Forms.Button();
            this.btnStand2 = new System.Windows.Forms.Button();
            this.btnDeal = new System.Windows.Forms.Button();
            this.btnDouble = new System.Windows.Forms.Button();
            this.tblPlayerHand2 = new System.Windows.Forms.TableLayoutPanel();
            this.lblDealerInfo = new System.Windows.Forms.Label();
            this.lblDealer = new System.Windows.Forms.Label();
            this.lblPlayerInfo = new System.Windows.Forms.Label();
            this.lblInfoPlayer = new System.Windows.Forms.Label();
            this.lblPlayer2 = new System.Windows.Forms.Label();
            this.picCard = new System.Windows.Forms.PictureBox();
            this.lblBet = new System.Windows.Forms.Label();
            this.nudBet = new System.Windows.Forms.NumericUpDown();
            this.lblCurrency = new System.Windows.Forms.Label();
            this.lblInstruction = new System.Windows.Forms.Label();
            this.btnReset = new System.Windows.Forms.Button();
            this.tblPlayerHand = new System.Windows.Forms.TableLayoutPanel();
            this.tblDealerHand = new System.Windows.Forms.TableLayoutPanel();
            this.lblMoeny = new System.Windows.Forms.Label();
            this.lblPlayer = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picCard)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBet)).BeginInit();
            this.SuspendLayout();
            // 
            // btnHit
            // 
            this.btnHit.BackColor = System.Drawing.Color.Yellow;
            this.btnHit.Enabled = false;
            this.btnHit.Location = new System.Drawing.Point(14, 671);
            this.btnHit.Name = "btnHit";
            this.btnHit.Size = new System.Drawing.Size(131, 65);
            this.btnHit.TabIndex = 0;
            this.btnHit.Text = "Hit ";
            this.btnHit.UseVisualStyleBackColor = false;
            this.btnHit.Click += new System.EventHandler(this.btnHit_Click);
            // 
            // btnStand
            // 
            this.btnStand.BackColor = System.Drawing.Color.Yellow;
            this.btnStand.Enabled = false;
            this.btnStand.Location = new System.Drawing.Point(288, 671);
            this.btnStand.Name = "btnStand";
            this.btnStand.Size = new System.Drawing.Size(131, 65);
            this.btnStand.TabIndex = 2;
            this.btnStand.Text = "Stand";
            this.btnStand.UseVisualStyleBackColor = false;
            this.btnStand.Click += new System.EventHandler(this.btnStand_Click);
            // 
            // btnSurrender
            // 
            this.btnSurrender.BackColor = System.Drawing.Color.Yellow;
            this.btnSurrender.Enabled = false;
            this.btnSurrender.Location = new System.Drawing.Point(425, 671);
            this.btnSurrender.Name = "btnSurrender";
            this.btnSurrender.Size = new System.Drawing.Size(131, 65);
            this.btnSurrender.TabIndex = 3;
            this.btnSurrender.Text = "Surrender";
            this.btnSurrender.UseVisualStyleBackColor = false;
            this.btnSurrender.Click += new System.EventHandler(this.btnSurrender_Click);
            // 
            // btnSplit
            // 
            this.btnSplit.BackColor = System.Drawing.Color.Yellow;
            this.btnSplit.Enabled = false;
            this.btnSplit.Location = new System.Drawing.Point(571, 671);
            this.btnSplit.Name = "btnSplit";
            this.btnSplit.Size = new System.Drawing.Size(131, 65);
            this.btnSplit.TabIndex = 4;
            this.btnSplit.Text = "Split";
            this.btnSplit.UseVisualStyleBackColor = false;
            this.btnSplit.Click += new System.EventHandler(this.btnSplit_Click);
            // 
            // btnHit2
            // 
            this.btnHit2.BackColor = System.Drawing.Color.Yellow;
            this.btnHit2.Enabled = false;
            this.btnHit2.Location = new System.Drawing.Point(774, 671);
            this.btnHit2.Name = "btnHit2";
            this.btnHit2.Size = new System.Drawing.Size(119, 65);
            this.btnHit2.TabIndex = 5;
            this.btnHit2.Text = "Hit";
            this.btnHit2.UseVisualStyleBackColor = false;
            this.btnHit2.Click += new System.EventHandler(this.btnHit2_Click);
            // 
            // btnDouble2
            // 
            this.btnDouble2.BackColor = System.Drawing.Color.Yellow;
            this.btnDouble2.Enabled = false;
            this.btnDouble2.Location = new System.Drawing.Point(921, 671);
            this.btnDouble2.Name = "btnDouble2";
            this.btnDouble2.Size = new System.Drawing.Size(131, 65);
            this.btnDouble2.TabIndex = 6;
            this.btnDouble2.Text = "Double";
            this.btnDouble2.UseVisualStyleBackColor = false;
            this.btnDouble2.Click += new System.EventHandler(this.btnDouble2_Click);
            // 
            // btnStand2
            // 
            this.btnStand2.BackColor = System.Drawing.Color.Yellow;
            this.btnStand2.Enabled = false;
            this.btnStand2.Location = new System.Drawing.Point(1084, 671);
            this.btnStand2.Name = "btnStand2";
            this.btnStand2.Size = new System.Drawing.Size(131, 65);
            this.btnStand2.TabIndex = 7;
            this.btnStand2.Text = "Stand";
            this.btnStand2.UseVisualStyleBackColor = false;
            this.btnStand2.Click += new System.EventHandler(this.btnStand2_Click);
            // 
            // btnDeal
            // 
            this.btnDeal.BackColor = System.Drawing.Color.Yellow;
            this.btnDeal.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnDeal.FlatAppearance.BorderSize = 2;
            this.btnDeal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeal.Location = new System.Drawing.Point(735, 342);
            this.btnDeal.Name = "btnDeal";
            this.btnDeal.Size = new System.Drawing.Size(131, 57);
            this.btnDeal.TabIndex = 8;
            this.btnDeal.Text = "Deal";
            this.btnDeal.UseVisualStyleBackColor = false;
            this.btnDeal.Click += new System.EventHandler(this.btnDeal_Click);
            // 
            // btnDouble
            // 
            this.btnDouble.BackColor = System.Drawing.Color.Yellow;
            this.btnDouble.Enabled = false;
            this.btnDouble.Location = new System.Drawing.Point(151, 671);
            this.btnDouble.Name = "btnDouble";
            this.btnDouble.Size = new System.Drawing.Size(131, 65);
            this.btnDouble.TabIndex = 10;
            this.btnDouble.Text = "Double";
            this.btnDouble.UseVisualStyleBackColor = false;
            this.btnDouble.Click += new System.EventHandler(this.btnDouble_Click);
            // 
            // tblPlayerHand2
            // 
            this.tblPlayerHand2.ColumnCount = 11;
            this.tblPlayerHand2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.09091F));
            this.tblPlayerHand2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.09091F));
            this.tblPlayerHand2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.09091F));
            this.tblPlayerHand2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.09091F));
            this.tblPlayerHand2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.09091F));
            this.tblPlayerHand2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.09091F));
            this.tblPlayerHand2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.09091F));
            this.tblPlayerHand2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.09091F));
            this.tblPlayerHand2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.09091F));
            this.tblPlayerHand2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.09091F));
            this.tblPlayerHand2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.09091F));
            this.tblPlayerHand2.Location = new System.Drawing.Point(867, 466);
            this.tblPlayerHand2.Name = "tblPlayerHand2";
            this.tblPlayerHand2.RowCount = 1;
            this.tblPlayerHand2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblPlayerHand2.Size = new System.Drawing.Size(852, 199);
            this.tblPlayerHand2.TabIndex = 13;
            // 
            // lblDealerInfo
            // 
            this.lblDealerInfo.AutoSize = true;
            this.lblDealerInfo.ForeColor = System.Drawing.Color.White;
            this.lblDealerInfo.Location = new System.Drawing.Point(46, 231);
            this.lblDealerInfo.Name = "lblDealerInfo";
            this.lblDealerInfo.Size = new System.Drawing.Size(116, 25);
            this.lblDealerInfo.TabIndex = 14;
            this.lblDealerInfo.Text = "Dealer info";
            // 
            // lblDealer
            // 
            this.lblDealer.AutoSize = true;
            this.lblDealer.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDealer.ForeColor = System.Drawing.Color.White;
            this.lblDealer.Location = new System.Drawing.Point(45, 256);
            this.lblDealer.Name = "lblDealer";
            this.lblDealer.Size = new System.Drawing.Size(100, 31);
            this.lblDealer.TabIndex = 15;
            this.lblDealer.Text = "Dealer";
            // 
            // lblPlayerInfo
            // 
            this.lblPlayerInfo.AutoSize = true;
            this.lblPlayerInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlayerInfo.ForeColor = System.Drawing.Color.White;
            this.lblPlayerInfo.Location = new System.Drawing.Point(48, 420);
            this.lblPlayerInfo.Name = "lblPlayerInfo";
            this.lblPlayerInfo.Size = new System.Drawing.Size(115, 26);
            this.lblPlayerInfo.TabIndex = 16;
            this.lblPlayerInfo.Text = "Player info";
            // 
            // lblInfoPlayer
            // 
            this.lblInfoPlayer.AutoSize = true;
            this.lblInfoPlayer.ForeColor = System.Drawing.Color.White;
            this.lblInfoPlayer.Location = new System.Drawing.Point(49, 438);
            this.lblInfoPlayer.Name = "lblInfoPlayer";
            this.lblInfoPlayer.Size = new System.Drawing.Size(0, 25);
            this.lblInfoPlayer.TabIndex = 17;
            // 
            // lblPlayer2
            // 
            this.lblPlayer2.AutoSize = true;
            this.lblPlayer2.ForeColor = System.Drawing.Color.White;
            this.lblPlayer2.Location = new System.Drawing.Point(872, 421);
            this.lblPlayer2.Name = "lblPlayer2";
            this.lblPlayer2.Size = new System.Drawing.Size(53, 25);
            this.lblPlayer2.TabIndex = 18;
            this.lblPlayer2.Text = "Info ";
            // 
            // picCard
            // 
            this.picCard.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picCard.Location = new System.Drawing.Point(554, 246);
            this.picCard.Name = "picCard";
            this.picCard.Size = new System.Drawing.Size(147, 192);
            this.picCard.TabIndex = 19;
            this.picCard.TabStop = false;
            // 
            // lblBet
            // 
            this.lblBet.AutoSize = true;
            this.lblBet.ForeColor = System.Drawing.Color.White;
            this.lblBet.Location = new System.Drawing.Point(707, 296);
            this.lblBet.Name = "lblBet";
            this.lblBet.Size = new System.Drawing.Size(44, 25);
            this.lblBet.TabIndex = 20;
            this.lblBet.Text = "Bet";
            // 
            // nudBet
            // 
            this.nudBet.BackColor = System.Drawing.Color.Yellow;
            this.nudBet.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudBet.Location = new System.Drawing.Point(774, 296);
            this.nudBet.Maximum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudBet.Name = "nudBet";
            this.nudBet.Size = new System.Drawing.Size(84, 31);
            this.nudBet.TabIndex = 21;
            // 
            // lblCurrency
            // 
            this.lblCurrency.AutoSize = true;
            this.lblCurrency.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrency.ForeColor = System.Drawing.Color.Yellow;
            this.lblCurrency.Location = new System.Drawing.Point(625, 266);
            this.lblCurrency.Name = "lblCurrency";
            this.lblCurrency.Size = new System.Drawing.Size(0, 31);
            this.lblCurrency.TabIndex = 22;
            // 
            // lblInstruction
            // 
            this.lblInstruction.AutoSize = true;
            this.lblInstruction.ForeColor = System.Drawing.Color.White;
            this.lblInstruction.Location = new System.Drawing.Point(872, 342);
            this.lblInstruction.Name = "lblInstruction";
            this.lblInstruction.Size = new System.Drawing.Size(167, 25);
            this.lblInstruction.TabIndex = 23;
            this.lblInstruction.Text = "INSTRUCTIONS";
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.Yellow;
            this.btnReset.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnReset.FlatAppearance.BorderSize = 2;
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReset.Location = new System.Drawing.Point(1115, 26);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(131, 57);
            this.btnReset.TabIndex = 24;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // tblPlayerHand
            // 
            this.tblPlayerHand.ColumnCount = 11;
            this.tblPlayerHand.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.09091F));
            this.tblPlayerHand.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.09091F));
            this.tblPlayerHand.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.09091F));
            this.tblPlayerHand.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.79021F));
            this.tblPlayerHand.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.090909F));
            this.tblPlayerHand.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.041958F));
            this.tblPlayerHand.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.09091F));
            this.tblPlayerHand.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.09091F));
            this.tblPlayerHand.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.09091F));
            this.tblPlayerHand.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.09091F));
            this.tblPlayerHand.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.09091F));
            this.tblPlayerHand.Location = new System.Drawing.Point(40, 466);
            this.tblPlayerHand.Name = "tblPlayerHand";
            this.tblPlayerHand.RowCount = 1;
            this.tblPlayerHand.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblPlayerHand.Size = new System.Drawing.Size(789, 199);
            this.tblPlayerHand.TabIndex = 25;
            // 
            // tblDealerHand
            // 
            this.tblDealerHand.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tblDealerHand.ColumnCount = 11;
            this.tblDealerHand.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.09091F));
            this.tblDealerHand.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.09091F));
            this.tblDealerHand.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.09091F));
            this.tblDealerHand.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.09091F));
            this.tblDealerHand.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.09091F));
            this.tblDealerHand.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.09091F));
            this.tblDealerHand.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.09091F));
            this.tblDealerHand.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.09091F));
            this.tblDealerHand.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.09091F));
            this.tblDealerHand.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.09091F));
            this.tblDealerHand.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.09091F));
            this.tblDealerHand.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.tblDealerHand.Location = new System.Drawing.Point(40, 26);
            this.tblDealerHand.Name = "tblDealerHand";
            this.tblDealerHand.RowCount = 1;
            this.tblDealerHand.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblDealerHand.Size = new System.Drawing.Size(818, 202);
            this.tblDealerHand.TabIndex = 14;
            // 
            // lblMoeny
            // 
            this.lblMoeny.AutoSize = true;
            this.lblMoeny.ForeColor = System.Drawing.Color.Yellow;
            this.lblMoeny.Location = new System.Drawing.Point(780, 262);
            this.lblMoeny.Name = "lblMoeny";
            this.lblMoeny.Size = new System.Drawing.Size(66, 25);
            this.lblMoeny.TabIndex = 27;
            this.lblMoeny.Text = "1,000";
            // 
            // lblPlayer
            // 
            this.lblPlayer.AutoSize = true;
            this.lblPlayer.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlayer.ForeColor = System.Drawing.Color.White;
            this.lblPlayer.Location = new System.Drawing.Point(48, 389);
            this.lblPlayer.Name = "lblPlayer";
            this.lblPlayer.Size = new System.Drawing.Size(97, 31);
            this.lblPlayer.TabIndex = 28;
            this.lblPlayer.Text = "Player";
            // 
            // Blackjack_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SeaGreen;
            this.ClientSize = new System.Drawing.Size(2248, 1017);
            this.Controls.Add(this.lblPlayer);
            this.Controls.Add(this.lblMoeny);
            this.Controls.Add(this.tblDealerHand);
            this.Controls.Add(this.tblPlayerHand);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.lblInstruction);
            this.Controls.Add(this.lblCurrency);
            this.Controls.Add(this.nudBet);
            this.Controls.Add(this.lblBet);
            this.Controls.Add(this.picCard);
            this.Controls.Add(this.lblPlayer2);
            this.Controls.Add(this.lblInfoPlayer);
            this.Controls.Add(this.lblPlayerInfo);
            this.Controls.Add(this.lblDealer);
            this.Controls.Add(this.lblDealerInfo);
            this.Controls.Add(this.tblPlayerHand2);
            this.Controls.Add(this.btnDouble);
            this.Controls.Add(this.btnDeal);
            this.Controls.Add(this.btnStand2);
            this.Controls.Add(this.btnDouble2);
            this.Controls.Add(this.btnHit2);
            this.Controls.Add(this.btnSplit);
            this.Controls.Add(this.btnSurrender);
            this.Controls.Add(this.btnStand);
            this.Controls.Add(this.btnHit);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(2774, 1088);
            this.MinimumSize = new System.Drawing.Size(2274, 1088);
            this.Name = "Blackjack_Form";
            this.Text = "Blackjack";
            ((System.ComponentModel.ISupportInitialize)(this.picCard)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnHit;
        private System.Windows.Forms.Button btnStand;
        private System.Windows.Forms.Button btnSurrender;
        private System.Windows.Forms.Button btnSplit;
        private System.Windows.Forms.Button btnHit2;
        private System.Windows.Forms.Button btnDouble2;
        private System.Windows.Forms.Button btnStand2;
        private System.Windows.Forms.Button btnDeal;
        private System.Windows.Forms.Button btnDouble;
        private System.Windows.Forms.TableLayoutPanel tblPlayerHand2;
        private System.Windows.Forms.Label lblDealerInfo;
        private System.Windows.Forms.Label lblDealer;
        private System.Windows.Forms.Label lblPlayerInfo;
        private System.Windows.Forms.Label lblInfoPlayer;
        private System.Windows.Forms.Label lblPlayer2;
        private System.Windows.Forms.PictureBox picCard;
        private System.Windows.Forms.Label lblBet;
        private System.Windows.Forms.NumericUpDown nudBet;
        private System.Windows.Forms.Label lblCurrency;
        private System.Windows.Forms.Label lblInstruction;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.TableLayoutPanel tblPlayerHand;
        private System.Windows.Forms.TableLayoutPanel tblDealerHand;
        private System.Windows.Forms.Label lblMoeny;
        private System.Windows.Forms.Label lblPlayer;
    }
}