namespace FinClient.Forms
{
    partial class MoneyTransfer
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
            label1 = new Label();
            phoneNumerTransferInput = new TextBox();
            moneyTransferInput = new TextBox();
            label2 = new Label();
            currencyList = new ListBox();
            label3 = new Label();
            exitButton = new Button();
            transferButton = new Button();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            tabPage2 = new TabPage();
            linkLabel1 = new LinkLabel();
            exchangeButton = new Button();
            label7 = new Label();
            label4 = new Label();
            replenishmentAccountComboBox = new ComboBox();
            debitAccountComboBox = new ComboBox();
            moneyTextBox = new TextBox();
            label5 = new Label();
            label6 = new Label();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(48, 34);
            label1.Name = "label1";
            label1.Size = new Size(331, 15);
            label1.TabIndex = 0;
            label1.Text = "Введите номер телефона , кому вы хотите отправть деньги";
            // 
            // phoneNumerTransferInput
            // 
            phoneNumerTransferInput.Location = new Point(48, 72);
            phoneNumerTransferInput.Name = "phoneNumerTransferInput";
            phoneNumerTransferInput.Size = new Size(331, 23);
            phoneNumerTransferInput.TabIndex = 1;
            // 
            // moneyTransferInput
            // 
            moneyTransferInput.Location = new Point(48, 273);
            moneyTransferInput.Name = "moneyTransferInput";
            moneyTransferInput.Size = new Size(331, 23);
            moneyTransferInput.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(48, 244);
            label2.Name = "label2";
            label2.Size = new Size(165, 15);
            label2.TabIndex = 3;
            label2.Text = "Введите сумму для перевода";
            // 
            // currencyList
            // 
            currencyList.FormattingEnabled = true;
            currencyList.ItemHeight = 15;
            currencyList.Items.AddRange(new object[] { "RUB", "USD", "EUR" });
            currencyList.Location = new Point(48, 141);
            currencyList.Name = "currencyList";
            currencyList.Size = new Size(331, 79);
            currencyList.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(48, 110);
            label3.Name = "label3";
            label3.Size = new Size(165, 15);
            label3.TabIndex = 5;
            label3.Text = "Выберите счет для списания";
            // 
            // exitButton
            // 
            exitButton.Location = new Point(54, 402);
            exitButton.Name = "exitButton";
            exitButton.Size = new Size(75, 23);
            exitButton.TabIndex = 6;
            exitButton.Text = "Назад";
            exitButton.UseVisualStyleBackColor = true;
            exitButton.Click += ExitButton_Click;
            // 
            // transferButton
            // 
            transferButton.Location = new Point(775, 309);
            transferButton.Name = "transferButton";
            transferButton.Size = new Size(232, 23);
            transferButton.TabIndex = 7;
            transferButton.Text = "Перевести деньги";
            transferButton.UseVisualStyleBackColor = true;
            transferButton.Click += TransferButton_Click;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Location = new Point(2, -1);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1037, 378);
            tabControl1.TabIndex = 13;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(label1);
            tabPage1.Controls.Add(transferButton);
            tabPage1.Controls.Add(phoneNumerTransferInput);
            tabPage1.Controls.Add(moneyTransferInput);
            tabPage1.Controls.Add(label2);
            tabPage1.Controls.Add(currencyList);
            tabPage1.Controls.Add(label3);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(1029, 350);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Перевод другому человеку";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(linkLabel1);
            tabPage2.Controls.Add(exchangeButton);
            tabPage2.Controls.Add(label7);
            tabPage2.Controls.Add(label4);
            tabPage2.Controls.Add(replenishmentAccountComboBox);
            tabPage2.Controls.Add(debitAccountComboBox);
            tabPage2.Controls.Add(moneyTextBox);
            tabPage2.Controls.Add(label5);
            tabPage2.Controls.Add(label6);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(1029, 350);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Обмен денег";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.LinkArea = new LinkArea(35, 50);
            linkLabel1.Location = new Point(612, 99);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(284, 21);
            linkLabel1.TabIndex = 17;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "Курс взят с официального сайта ЦБ: https://cbr.ru";
            linkLabel1.UseCompatibleTextRendering = true;
            linkLabel1.LinkClicked += LinkLabel1_LinkClicked;
            // 
            // exchangeButton
            // 
            exchangeButton.Location = new Point(612, 299);
            exchangeButton.Name = "exchangeButton";
            exchangeButton.Size = new Size(383, 23);
            exchangeButton.TabIndex = 16;
            exchangeButton.Text = "Перевести деньги";
            exchangeButton.UseVisualStyleBackColor = true;
            exchangeButton.Click += ExchangeButton_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(612, 53);
            label7.Name = "label7";
            label7.Size = new Size(128, 15);
            label7.TabIndex = 15;
            label7.Text = "Курс основных валют";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(45, 128);
            label4.Name = "label4";
            label4.Size = new Size(159, 15);
            label4.TabIndex = 14;
            label4.Text = "Выберите счет пополнения";
            // 
            // replenishmentAccountComboBox
            // 
            replenishmentAccountComboBox.FormattingEnabled = true;
            replenishmentAccountComboBox.Items.AddRange(new object[] { "RUB", "USD", "EUR" });
            replenishmentAccountComboBox.Location = new Point(45, 167);
            replenishmentAccountComboBox.Name = "replenishmentAccountComboBox";
            replenishmentAccountComboBox.Size = new Size(121, 23);
            replenishmentAccountComboBox.TabIndex = 13;
            // 
            // debitAccountComboBox
            // 
            debitAccountComboBox.FormattingEnabled = true;
            debitAccountComboBox.Items.AddRange(new object[] { "RUB", "USD", "EUR" });
            debitAccountComboBox.Location = new Point(48, 67);
            debitAccountComboBox.Name = "debitAccountComboBox";
            debitAccountComboBox.Size = new Size(121, 23);
            debitAccountComboBox.TabIndex = 12;
            // 
            // moneyTextBox
            // 
            moneyTextBox.Location = new Point(48, 256);
            moneyTextBox.Name = "moneyTextBox";
            moneyTextBox.Size = new Size(331, 23);
            moneyTextBox.TabIndex = 8;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(48, 225);
            label5.Name = "label5";
            label5.Size = new Size(156, 15);
            label5.TabIndex = 9;
            label5.Text = "Введите сумму для обмена";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(48, 29);
            label6.Name = "label6";
            label6.Size = new Size(165, 15);
            label6.TabIndex = 11;
            label6.Text = "Выберите счет для списания";
            // 
            // MoneyTransfer
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1051, 450);
            Controls.Add(tabControl1);
            Controls.Add(exitButton);
            Name = "MoneyTransfer";
            Text = "Перевод денег";
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private TextBox phoneNumerTransferInput;
        private TextBox moneyTransferInput;
        private Label label2;
        private ListBox currencyList;
        private Label label3;
        private Button exitButton;
        private Button transferButton;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private ComboBox debitAccountComboBox;
        private TextBox moneyTextBox;
        private Label label5;
        private Label label6;
        private Label label4;
        private ComboBox replenishmentAccountComboBox;
        private Label label7;
        private Button exchangeButton;
        private LinkLabel linkLabel1;
    }
}