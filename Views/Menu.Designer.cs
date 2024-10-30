namespace Banking
{
    partial class Menu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Menu));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loginToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.systemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.employeeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.branchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bankingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createAccountToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createAccountToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.depositAmountToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.withdrawalAmountToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.transactionAmountToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.balanceAccountToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.transactionLogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.userGuildToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(25, 41);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(854, 616);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.systemToolStripMenuItem,
            this.bankingToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(891, 28);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loginToolStripMenuItem,
            this.logoutToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(46, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // loginToolStripMenuItem
            // 
            this.loginToolStripMenuItem.Name = "loginToolStripMenuItem";
            this.loginToolStripMenuItem.Size = new System.Drawing.Size(139, 26);
            this.loginToolStripMenuItem.Text = "Login";
            this.loginToolStripMenuItem.Click += new System.EventHandler(this.loginToolStripMenuItem_Click);
            // 
            // logoutToolStripMenuItem
            // 
            this.logoutToolStripMenuItem.Enabled = false;
            this.logoutToolStripMenuItem.Name = "logoutToolStripMenuItem";
            this.logoutToolStripMenuItem.Size = new System.Drawing.Size(139, 26);
            this.logoutToolStripMenuItem.Text = "Logout";
            this.logoutToolStripMenuItem.Click += new System.EventHandler(this.logoutToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(139, 26);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // systemToolStripMenuItem
            // 
            this.systemToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.employeeToolStripMenuItem,
            this.branchToolStripMenuItem});
            this.systemToolStripMenuItem.Name = "systemToolStripMenuItem";
            this.systemToolStripMenuItem.Size = new System.Drawing.Size(70, 24);
            this.systemToolStripMenuItem.Text = "System";
            // 
            // employeeToolStripMenuItem
            // 
            this.employeeToolStripMenuItem.Enabled = false;
            this.employeeToolStripMenuItem.Name = "employeeToolStripMenuItem";
            this.employeeToolStripMenuItem.Size = new System.Drawing.Size(158, 26);
            this.employeeToolStripMenuItem.Text = "Employee";
            this.employeeToolStripMenuItem.Click += new System.EventHandler(this.employeeToolStripMenuItem_Click);
            // 
            // branchToolStripMenuItem
            // 
            this.branchToolStripMenuItem.Enabled = false;
            this.branchToolStripMenuItem.Name = "branchToolStripMenuItem";
            this.branchToolStripMenuItem.Size = new System.Drawing.Size(158, 26);
            this.branchToolStripMenuItem.Text = "Branch";
            this.branchToolStripMenuItem.Click += new System.EventHandler(this.branchToolStripMenuItem_Click);
            // 
            // bankingToolStripMenuItem
            // 
            this.bankingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createAccountToolStripMenuItem,
            this.createAccountToolStripMenuItem1,
            this.depositAmountToolStripMenuItem,
            this.withdrawalAmountToolStripMenuItem,
            this.transactionAmountToolStripMenuItem,
            this.balanceAccountToolStripMenuItem,
            this.transactionLogToolStripMenuItem});
            this.bankingToolStripMenuItem.Name = "bankingToolStripMenuItem";
            this.bankingToolStripMenuItem.Size = new System.Drawing.Size(76, 24);
            this.bankingToolStripMenuItem.Text = "Banking";
            // 
            // createAccountToolStripMenuItem
            // 
            this.createAccountToolStripMenuItem.Enabled = false;
            this.createAccountToolStripMenuItem.Name = "createAccountToolStripMenuItem";
            this.createAccountToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.createAccountToolStripMenuItem.Text = "Create Customer";
            this.createAccountToolStripMenuItem.Click += new System.EventHandler(this.createAccountToolStripMenuItem_Click);
            // 
            // createAccountToolStripMenuItem1
            // 
            this.createAccountToolStripMenuItem1.Enabled = false;
            this.createAccountToolStripMenuItem1.Name = "createAccountToolStripMenuItem1";
            this.createAccountToolStripMenuItem1.Size = new System.Drawing.Size(224, 26);
            this.createAccountToolStripMenuItem1.Text = "Create Account";
            this.createAccountToolStripMenuItem1.Click += new System.EventHandler(this.createAccountToolStripMenuItem1_Click);
            // 
            // depositAmountToolStripMenuItem
            // 
            this.depositAmountToolStripMenuItem.Enabled = false;
            this.depositAmountToolStripMenuItem.Name = "depositAmountToolStripMenuItem";
            this.depositAmountToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.depositAmountToolStripMenuItem.Text = "Deposit Amount";
            this.depositAmountToolStripMenuItem.Click += new System.EventHandler(this.depositAmountToolStripMenuItem_Click);
            // 
            // withdrawalAmountToolStripMenuItem
            // 
            this.withdrawalAmountToolStripMenuItem.Enabled = false;
            this.withdrawalAmountToolStripMenuItem.Name = "withdrawalAmountToolStripMenuItem";
            this.withdrawalAmountToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.withdrawalAmountToolStripMenuItem.Text = "Withdraw Amount";
            this.withdrawalAmountToolStripMenuItem.Click += new System.EventHandler(this.withdrawalAmountToolStripMenuItem_Click);
            // 
            // transactionAmountToolStripMenuItem
            // 
            this.transactionAmountToolStripMenuItem.Enabled = false;
            this.transactionAmountToolStripMenuItem.Name = "transactionAmountToolStripMenuItem";
            this.transactionAmountToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.transactionAmountToolStripMenuItem.Text = "Transaction Amount";
            this.transactionAmountToolStripMenuItem.Click += new System.EventHandler(this.transactionAmountToolStripMenuItem_Click);
            // 
            // balanceAccountToolStripMenuItem
            // 
            this.balanceAccountToolStripMenuItem.Enabled = false;
            this.balanceAccountToolStripMenuItem.Name = "balanceAccountToolStripMenuItem";
            this.balanceAccountToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.balanceAccountToolStripMenuItem.Text = "Account Balance";
            this.balanceAccountToolStripMenuItem.Click += new System.EventHandler(this.balanceAccountToolStripMenuItem_Click);
            // 
            // transactionLogToolStripMenuItem
            // 
            this.transactionLogToolStripMenuItem.Enabled = false;
            this.transactionLogToolStripMenuItem.Name = "transactionLogToolStripMenuItem";
            this.transactionLogToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.transactionLogToolStripMenuItem.Text = "Transaction Log";
            this.transactionLogToolStripMenuItem.Click += new System.EventHandler(this.transactionLogToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.userGuildToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(55, 24);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // userGuildToolStripMenuItem
            // 
            this.userGuildToolStripMenuItem.Name = "userGuildToolStripMenuItem";
            this.userGuildToolStripMenuItem.Size = new System.Drawing.Size(159, 26);
            this.userGuildToolStripMenuItem.Text = "User guild";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(159, 26);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(891, 669);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "Menu";
            this.Text = "Bank System";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loginToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logoutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem systemToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem employeeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem branchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bankingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createAccountToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createAccountToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem depositAmountToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem withdrawalAmountToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem transactionAmountToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem balanceAccountToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem transactionLogToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem userGuildToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
    }
}

