namespace BlackjackGame
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dealerHand = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.dealBtn = new System.Windows.Forms.Button();
            this.hitBtn = new System.Windows.Forms.Button();
            this.standBtn = new System.Windows.Forms.Button();
            this.totals = new System.Windows.Forms.TextBox();
            this.playerHand = new System.Windows.Forms.TextBox();
            this.results = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.Controls.Add(this.dealerHand, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.totals, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.playerHand, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.results, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(486, 270);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // dealerHand
            // 
            this.dealerHand.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.dealerHand.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dealerHand.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.dealerHand.Location = new System.Drawing.Point(3, 3);
            this.dealerHand.Multiline = true;
            this.dealerHand.Name = "dealerHand";
            this.dealerHand.ReadOnly = true;
            this.dealerHand.Size = new System.Drawing.Size(91, 129);
            this.dealerHand.TabIndex = 0;
            this.dealerHand.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.dealerHand.TextChanged += new System.EventHandler(this.dealerHand_TextChanged);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.dealBtn);
            this.flowLayoutPanel1.Controls.Add(this.hitBtn);
            this.flowLayoutPanel1.Controls.Add(this.standBtn);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(100, 138);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(188, 129);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // dealBtn
            // 
            this.dealBtn.Location = new System.Drawing.Point(3, 3);
            this.dealBtn.Name = "dealBtn";
            this.dealBtn.Size = new System.Drawing.Size(75, 23);
            this.dealBtn.TabIndex = 0;
            this.dealBtn.Text = "Deal";
            this.dealBtn.UseVisualStyleBackColor = true;
            this.dealBtn.Click += new System.EventHandler(this.dealBtn_Click);
            // 
            // hitBtn
            // 
            this.hitBtn.Location = new System.Drawing.Point(3, 32);
            this.hitBtn.Name = "hitBtn";
            this.hitBtn.Size = new System.Drawing.Size(75, 23);
            this.hitBtn.TabIndex = 1;
            this.hitBtn.Text = "Hit";
            this.hitBtn.UseVisualStyleBackColor = true;
            this.hitBtn.Click += new System.EventHandler(this.hitBtn_Click);
            // 
            // standBtn
            // 
            this.standBtn.Location = new System.Drawing.Point(3, 61);
            this.standBtn.Name = "standBtn";
            this.standBtn.Size = new System.Drawing.Size(75, 23);
            this.standBtn.TabIndex = 2;
            this.standBtn.Text = "Stand";
            this.standBtn.UseVisualStyleBackColor = true;
            this.standBtn.Click += new System.EventHandler(this.standBtn_Click);
            // 
            // totals
            // 
            this.totals.Dock = System.Windows.Forms.DockStyle.Fill;
            this.totals.Location = new System.Drawing.Point(100, 3);
            this.totals.Multiline = true;
            this.totals.Name = "totals";
            this.totals.ReadOnly = true;
            this.totals.Size = new System.Drawing.Size(188, 129);
            this.totals.TabIndex = 2;
            this.totals.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.totals.TextChanged += new System.EventHandler(this.totals_TextChanged);
            // 
            // playerHand
            // 
            this.playerHand.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.playerHand.Dock = System.Windows.Forms.DockStyle.Fill;
            this.playerHand.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.playerHand.Location = new System.Drawing.Point(3, 138);
            this.playerHand.Multiline = true;
            this.playerHand.Name = "playerHand";
            this.playerHand.ReadOnly = true;
            this.playerHand.Size = new System.Drawing.Size(91, 129);
            this.playerHand.TabIndex = 3;
            this.playerHand.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.playerHand.TextChanged += new System.EventHandler(this.playerHand_TextChanged);
            // 
            // results
            // 
            this.results.Dock = System.Windows.Forms.DockStyle.Fill;
            this.results.Location = new System.Drawing.Point(294, 3);
            this.results.Multiline = true;
            this.results.Name = "results";
            this.results.ReadOnly = true;
            this.results.Size = new System.Drawing.Size(189, 129);
            this.results.TabIndex = 4;
            this.results.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.results.TextChanged += new System.EventHandler(this.results_TextChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(486, 270);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox dealerHand;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button dealBtn;
        private System.Windows.Forms.Button hitBtn;
        private System.Windows.Forms.Button standBtn;
        private System.Windows.Forms.TextBox totals;
        private System.Windows.Forms.TextBox playerHand;
        private System.Windows.Forms.TextBox results;
    }
}

