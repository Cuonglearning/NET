﻿namespace Banking
{
    partial class Transaction
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
            this.comboBoxFromAccount = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFromAccountHolderName = new System.Windows.Forms.TextBox();
            this.txtToAccountHolderName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxToAccount = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtBranchName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBoxBranchID = new System.Windows.Forms.ComboBox();
            this.txtTransferAmount = new System.Windows.Forms.TextBox();
            this.btnTransfer = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.txtPin = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // comboBoxFromAccount
            // 
            this.comboBoxFromAccount.FormattingEnabled = true;
            this.comboBoxFromAccount.Location = new System.Drawing.Point(177, 127);
            this.comboBoxFromAccount.Name = "comboBoxFromAccount";
            this.comboBoxFromAccount.Size = new System.Drawing.Size(129, 24);
            this.comboBoxFromAccount.TabIndex = 0;
            this.comboBoxFromAccount.SelectedIndexChanged += new System.EventHandler(this.comboBoxFromAccount_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(24, 127);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(147, 24);
            this.label8.TabIndex = 78;
            this.label8.Text = "From account id";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(383, 127);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 24);
            this.label1.TabIndex = 79;
            this.label1.Text = "Name";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // txtFromAccountHolderName
            // 
            this.txtFromAccountHolderName.Location = new System.Drawing.Point(474, 131);
            this.txtFromAccountHolderName.Name = "txtFromAccountHolderName";
            this.txtFromAccountHolderName.ReadOnly = true;
            this.txtFromAccountHolderName.Size = new System.Drawing.Size(294, 22);
            this.txtFromAccountHolderName.TabIndex = 80;
            this.txtFromAccountHolderName.TextChanged += new System.EventHandler(this.txtFromAccountHolderName_TextChanged);
            // 
            // txtToAccountHolderName
            // 
            this.txtToAccountHolderName.Location = new System.Drawing.Point(474, 199);
            this.txtToAccountHolderName.Name = "txtToAccountHolderName";
            this.txtToAccountHolderName.ReadOnly = true;
            this.txtToAccountHolderName.Size = new System.Drawing.Size(294, 22);
            this.txtToAccountHolderName.TabIndex = 84;
            this.txtToAccountHolderName.TextChanged += new System.EventHandler(this.txtToAccountHolderName_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(383, 197);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 24);
            this.label2.TabIndex = 83;
            this.label2.Text = "Receiver";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(24, 193);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(125, 24);
            this.label3.TabIndex = 82;
            this.label3.Text = "To account id";
            // 
            // comboBoxToAccount
            // 
            this.comboBoxToAccount.FormattingEnabled = true;
            this.comboBoxToAccount.Location = new System.Drawing.Point(177, 193);
            this.comboBoxToAccount.Name = "comboBoxToAccount";
            this.comboBoxToAccount.Size = new System.Drawing.Size(129, 24);
            this.comboBoxToAccount.TabIndex = 81;
            this.comboBoxToAccount.SelectedIndexChanged += new System.EventHandler(this.comboBoxToAccount_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(257, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(285, 42);
            this.label4.TabIndex = 85;
            this.label4.Text = "TRANSACTION";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // txtBranchName
            // 
            this.txtBranchName.Location = new System.Drawing.Point(474, 267);
            this.txtBranchName.Name = "txtBranchName";
            this.txtBranchName.ReadOnly = true;
            this.txtBranchName.Size = new System.Drawing.Size(294, 22);
            this.txtBranchName.TabIndex = 89;
            this.txtBranchName.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(383, 265);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 24);
            this.label5.TabIndex = 88;
            this.label5.Text = "Branch";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(24, 261);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(90, 24);
            this.label6.TabIndex = 87;
            this.label6.Text = "Branch Id";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // comboBoxBranchID
            // 
            this.comboBoxBranchID.FormattingEnabled = true;
            this.comboBoxBranchID.Location = new System.Drawing.Point(177, 261);
            this.comboBoxBranchID.Name = "comboBoxBranchID";
            this.comboBoxBranchID.Size = new System.Drawing.Size(129, 24);
            this.comboBoxBranchID.TabIndex = 86;
            this.comboBoxBranchID.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // txtTransferAmount
            // 
            this.txtTransferAmount.Location = new System.Drawing.Point(474, 329);
            this.txtTransferAmount.Name = "txtTransferAmount";
            this.txtTransferAmount.Size = new System.Drawing.Size(294, 22);
            this.txtTransferAmount.TabIndex = 90;
            this.txtTransferAmount.TextChanged += new System.EventHandler(this.txtTransferAmount_TextChanged);
            // 
            // btnTransfer
            // 
            this.btnTransfer.Location = new System.Drawing.Point(335, 377);
            this.btnTransfer.Name = "btnTransfer";
            this.btnTransfer.Size = new System.Drawing.Size(99, 41);
            this.btnTransfer.TabIndex = 92;
            this.btnTransfer.Text = "Transfer";
            this.btnTransfer.UseVisualStyleBackColor = true;
            this.btnTransfer.Click += new System.EventHandler(this.btnTransfer_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label9.Location = new System.Drawing.Point(36, 329);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(30, 17);
            this.label9.TabIndex = 94;
            this.label9.Text = "PIN";
            this.label9.Click += new System.EventHandler(this.label9_Click);
            // 
            // txtPin
            // 
            this.txtPin.Location = new System.Drawing.Point(177, 325);
            this.txtPin.Name = "txtPin";
            this.txtPin.Size = new System.Drawing.Size(129, 22);
            this.txtPin.TabIndex = 93;
            this.txtPin.TextChanged += new System.EventHandler(this.txtPin_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(24, 325);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(40, 24);
            this.label10.TabIndex = 95;
            this.label10.Text = "PIN";
            this.label10.Click += new System.EventHandler(this.label10_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(383, 327);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(76, 24);
            this.label11.TabIndex = 96;
            this.label11.Text = "Amount";
            this.label11.Click += new System.EventHandler(this.label11_Click);
            // 
            // Transaction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtPin);
            this.Controls.Add(this.btnTransfer);
            this.Controls.Add(this.txtTransferAmount);
            this.Controls.Add(this.txtBranchName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.comboBoxBranchID);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtToAccountHolderName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBoxToAccount);
            this.Controls.Add(this.txtFromAccountHolderName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.comboBoxFromAccount);
            this.Name = "Transaction";
            this.Text = "Transaction";
            this.Load += new System.EventHandler(this.Transaction_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxFromAccount;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFromAccountHolderName;
        private System.Windows.Forms.TextBox txtToAccountHolderName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBoxToAccount;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtBranchName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBoxBranchID;
        private System.Windows.Forms.TextBox txtTransferAmount;
        private System.Windows.Forms.Button btnTransfer;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtPin;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
    }
}