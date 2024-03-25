namespace FinancialApp.Forms
{
    partial class ReplenishmentCashAccount
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
            currencyList = new ListBox();
            addMoneyBox = new TextBox();
            addMoneyButton = new Button();
            label1 = new Label();
            label2 = new Label();
            exitButton = new Button();
            SuspendLayout();
            // 
            // currencyList
            // 
            currencyList.FormattingEnabled = true;
            currencyList.ItemHeight = 15;
            currencyList.Items.AddRange(new object[] { "RUB", "USD", "EUR" });
            currencyList.Location = new Point(53, 93);
            currencyList.Name = "currencyList";
            currencyList.Size = new Size(320, 79);
            currencyList.TabIndex = 0;
            // 
            // addMoneyBox
            // 
            addMoneyBox.Location = new Point(264, 293);
            addMoneyBox.Name = "addMoneyBox";
            addMoneyBox.Size = new Size(100, 23);
            addMoneyBox.TabIndex = 1;
            // 
            // addMoneyButton
            // 
            addMoneyButton.Location = new Point(407, 293);
            addMoneyButton.Name = "addMoneyButton";
            addMoneyButton.Size = new Size(75, 23);
            addMoneyButton.TabIndex = 2;
            addMoneyButton.Text = "Добавить";
            addMoneyButton.UseVisualStyleBackColor = true;
            addMoneyButton.Click += AddMoneyButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(53, 301);
            label1.Name = "label1";
            label1.Size = new Size(167, 15);
            label1.TabIndex = 3;
            label1.Text = "Введите сумму попоплнения";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(53, 35);
            label2.Name = "label2";
            label2.Size = new Size(230, 15);
            label2.TabIndex = 4;
            label2.Text = "Выберите валюту счета для пополнения";
            // 
            // exitButton
            // 
            exitButton.Location = new Point(657, 356);
            exitButton.Name = "exitButton";
            exitButton.Size = new Size(75, 23);
            exitButton.TabIndex = 5;
            exitButton.Text = "Назад";
            exitButton.UseVisualStyleBackColor = true;
            exitButton.Click += ExitButton_Click;
            // 
            // AddMoney
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(766, 402);
            Controls.Add(exitButton);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(addMoneyButton);
            Controls.Add(addMoneyBox);
            Controls.Add(currencyList);
            Name = "AddMoney";
            Text = "Добавление денег на счет";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox currencyList;
        private TextBox addMoneyBox;
        private Button addMoneyButton;
        private Label label1;
        private Label label2;
        private Button exitButton;
    }
}