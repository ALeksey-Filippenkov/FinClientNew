namespace FinancialApp.Forms
{
    partial class CreatingMoneyAccount
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
            listBox1 = new ListBox();
            creatingCashAccount = new Button();
            label1 = new Label();
            exit = new Button();
            SuspendLayout();
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 15;
            listBox1.Items.AddRange(new object[] { "RUB", "USD", "EUR" });
            listBox1.Location = new Point(54, 128);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(320, 79);
            listBox1.TabIndex = 1;
            // 
            // creatingCashAccount
            // 
            creatingCashAccount.Location = new Point(54, 253);
            creatingCashAccount.Name = "creatingCashAccount";
            creatingCashAccount.Size = new Size(320, 23);
            creatingCashAccount.TabIndex = 6;
            creatingCashAccount.Text = "Создать счет";
            creatingCashAccount.UseVisualStyleBackColor = true;
            creatingCashAccount.Click += CreatingCashAccount_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(54, 66);
            label1.Name = "label1";
            label1.Size = new Size(159, 15);
            label1.TabIndex = 7;
            label1.Text = "Выберите валюту для счета";
            // 
            // exit
            // 
            exit.Location = new Point(700, 415);
            exit.Name = "exit";
            exit.Size = new Size(75, 23);
            exit.TabIndex = 8;
            exit.Text = "Назад";
            exit.UseVisualStyleBackColor = true;
            exit.Click += Exit_Click;
            // 
            // CreatingAccount
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(exit);
            Controls.Add(label1);
            Controls.Add(creatingCashAccount);
            Controls.Add(listBox1);
            Name = "CreatingAccount";
            Text = "Создание счета";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox listBox1;
        private Button creatingCashAccount;
        private Label label1;
        private Button exit;
    }
}