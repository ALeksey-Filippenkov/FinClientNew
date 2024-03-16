namespace FinancialApp.Forms
{
    partial class UsersPersonalAccount
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
            exitButton = new Button();
            saveLKButton = new Button();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            password = new TextBox();
            login = new TextBox();
            email = new TextBox();
            phone = new TextBox();
            adress = new TextBox();
            city = new TextBox();
            age = new TextBox();
            surname = new TextBox();
            name = new TextBox();
            label9 = new Label();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            tabPage2 = new TabPage();
            tabControl2 = new TabControl();
            tabPage3 = new TabPage();
            label10 = new Label();
            label11 = new Label();
            label12 = new Label();
            rubLebel = new Label();
            usdLebel = new Label();
            eurLebel = new Label();
            tabPage4 = new TabPage();
            historyOperationDataGridView = new DataGridView();
            date = new DataGridViewTextBoxColumn();
            Column1 = new DataGridViewTextBoxColumn();
            sender = new DataGridViewTextBoxColumn();
            type = new DataGridViewTextBoxColumn();
            money = new DataGridViewTextBoxColumn();
            Recipient = new DataGridViewTextBoxColumn();
            historyLebel = new Label();
            historyOperationExcel = new Button();
            searchButton = new Button();
            moneyTransferButton = new Button();
            createAccount = new Button();
            button1 = new Button();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            tabControl2.SuspendLayout();
            tabPage3.SuspendLayout();
            tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)historyOperationDataGridView).BeginInit();
            SuspendLayout();
            // 
            // exitButton
            // 
            exitButton.Location = new Point(26, 626);
            exitButton.Name = "exitButton";
            exitButton.Size = new Size(75, 23);
            exitButton.TabIndex = 2;
            exitButton.Text = "Выйти";
            exitButton.UseVisualStyleBackColor = true;
            exitButton.Click += ExitButton_Click;
            // 
            // saveLKButton
            // 
            saveLKButton.Location = new Point(801, 502);
            saveLKButton.Name = "saveLKButton";
            saveLKButton.Size = new Size(167, 23);
            saveLKButton.TabIndex = 3;
            saveLKButton.Text = "Сохранить изменения";
            saveLKButton.UseVisualStyleBackColor = true;
            saveLKButton.Click += SaveLKButton_Click;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Location = new Point(0, 1);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(985, 619);
            tabControl1.TabIndex = 4;
            tabControl1.BindingContextChanged += TabPage2_Click;
            tabControl1.Click += TabPage2_Click;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(password);
            tabPage1.Controls.Add(login);
            tabPage1.Controls.Add(email);
            tabPage1.Controls.Add(phone);
            tabPage1.Controls.Add(adress);
            tabPage1.Controls.Add(city);
            tabPage1.Controls.Add(age);
            tabPage1.Controls.Add(surname);
            tabPage1.Controls.Add(name);
            tabPage1.Controls.Add(label9);
            tabPage1.Controls.Add(label8);
            tabPage1.Controls.Add(label7);
            tabPage1.Controls.Add(label6);
            tabPage1.Controls.Add(label5);
            tabPage1.Controls.Add(label4);
            tabPage1.Controls.Add(label3);
            tabPage1.Controls.Add(label2);
            tabPage1.Controls.Add(label1);
            tabPage1.Controls.Add(saveLKButton);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(977, 591);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Личные данные";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // password
            // 
            password.Location = new Point(293, 306);
            password.Name = "password";
            password.Size = new Size(377, 23);
            password.TabIndex = 26;
            // 
            // login
            // 
            login.Location = new Point(293, 269);
            login.Name = "login";
            login.Size = new Size(377, 23);
            login.TabIndex = 25;
            // 
            // email
            // 
            email.Location = new Point(293, 230);
            email.Name = "email";
            email.Size = new Size(377, 23);
            email.TabIndex = 24;
            // 
            // phone
            // 
            phone.Location = new Point(293, 191);
            phone.Name = "phone";
            phone.Size = new Size(377, 23);
            phone.TabIndex = 23;
            // 
            // adress
            // 
            adress.Location = new Point(293, 150);
            adress.Name = "adress";
            adress.Size = new Size(377, 23);
            adress.TabIndex = 22;
            // 
            // city
            // 
            city.Location = new Point(293, 114);
            city.Name = "city";
            city.Size = new Size(377, 23);
            city.TabIndex = 21;
            // 
            // age
            // 
            age.Location = new Point(293, 80);
            age.Name = "age";
            age.Size = new Size(377, 23);
            age.TabIndex = 20;
            // 
            // surname
            // 
            surname.Location = new Point(293, 43);
            surname.Name = "surname";
            surname.Size = new Size(377, 23);
            surname.TabIndex = 19;
            // 
            // name
            // 
            name.Location = new Point(293, 10);
            name.Name = "name";
            name.Size = new Size(377, 23);
            name.TabIndex = 18;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(8, 306);
            label9.Name = "label9";
            label9.Size = new Size(49, 15);
            label9.TabIndex = 17;
            label9.Text = "Пароль";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(8, 269);
            label8.Name = "label8";
            label8.Size = new Size(41, 15);
            label8.TabIndex = 16;
            label8.Text = "Логин";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(6, 233);
            label7.Name = "label7";
            label7.Size = new Size(113, 15);
            label7.TabIndex = 15;
            label7.Text = "Электронная почта";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(6, 199);
            label6.Name = "label6";
            label6.Size = new Size(55, 15);
            label6.TabIndex = 14;
            label6.Text = "Телефон";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(6, 158);
            label5.Name = "label5";
            label5.Size = new Size(40, 15);
            label5.TabIndex = 13;
            label5.Text = "Адрес";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(6, 122);
            label4.Name = "label4";
            label4.Size = new Size(40, 15);
            label4.TabIndex = 12;
            label4.Text = "Город";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 88);
            label3.Name = "label3";
            label3.Size = new Size(50, 15);
            label3.TabIndex = 11;
            label3.Text = "Возраст";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 51);
            label2.Name = "label2";
            label2.Size = new Size(58, 15);
            label2.TabIndex = 10;
            label2.Text = "Фамилия";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 18);
            label1.Name = "label1";
            label1.Size = new Size(31, 15);
            label1.TabIndex = 9;
            label1.Text = "Имя";
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(tabControl2);
            tabPage2.Controls.Add(historyOperationExcel);
            tabPage2.Controls.Add(searchButton);
            tabPage2.Controls.Add(moneyTransferButton);
            tabPage2.Controls.Add(createAccount);
            tabPage2.Controls.Add(button1);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(977, 591);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Мои финансы";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabControl2
            // 
            tabControl2.Controls.Add(tabPage3);
            tabControl2.Controls.Add(tabPage4);
            tabControl2.Location = new Point(0, 3);
            tabControl2.Name = "tabControl2";
            tabControl2.SelectedIndex = 0;
            tabControl2.Size = new Size(974, 481);
            tabControl2.TabIndex = 17;
            tabControl2.Click += TabPage3_Click;
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(label10);
            tabPage3.Controls.Add(label11);
            tabPage3.Controls.Add(label12);
            tabPage3.Controls.Add(rubLebel);
            tabPage3.Controls.Add(usdLebel);
            tabPage3.Controls.Add(eurLebel);
            tabPage3.Location = new Point(4, 24);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3);
            tabPage3.Size = new Size(966, 453);
            tabPage3.TabIndex = 0;
            tabPage3.Text = "Счета";
            tabPage3.UseVisualStyleBackColor = true;
            tabPage3.Click += TabPage3_Click;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(32, 21);
            label10.Name = "label10";
            label10.Size = new Size(58, 15);
            label10.TabIndex = 0;
            label10.Text = "Счет RUB";
            label10.Click += TabPage3_Click;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(32, 83);
            label11.Name = "label11";
            label11.Size = new Size(58, 15);
            label11.TabIndex = 1;
            label11.Text = "Счет USD";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(32, 142);
            label12.Name = "label12";
            label12.Size = new Size(57, 15);
            label12.TabIndex = 2;
            label12.Text = "Счет EUR";
            // 
            // rubLebel
            // 
            rubLebel.AutoSize = true;
            rubLebel.Location = new Point(195, 21);
            rubLebel.Name = "rubLebel";
            rubLebel.Size = new Size(13, 15);
            rubLebel.TabIndex = 8;
            rubLebel.Text = "0";
            // 
            // usdLebel
            // 
            usdLebel.AutoSize = true;
            usdLebel.Location = new Point(195, 83);
            usdLebel.Name = "usdLebel";
            usdLebel.Size = new Size(13, 15);
            usdLebel.TabIndex = 9;
            usdLebel.Text = "0";
            // 
            // eurLebel
            // 
            eurLebel.AutoSize = true;
            eurLebel.Location = new Point(195, 142);
            eurLebel.Name = "eurLebel";
            eurLebel.Size = new Size(13, 15);
            eurLebel.TabIndex = 10;
            eurLebel.Text = "0";
            // 
            // tabPage4
            // 
            tabPage4.Controls.Add(historyOperationDataGridView);
            tabPage4.Controls.Add(historyLebel);
            tabPage4.Location = new Point(4, 24);
            tabPage4.Name = "tabPage4";
            tabPage4.Padding = new Padding(3);
            tabPage4.Size = new Size(966, 453);
            tabPage4.TabIndex = 1;
            tabPage4.Text = "История";
            tabPage4.UseVisualStyleBackColor = true;
            // 
            // historyOperationDataGridView
            // 
            historyOperationDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            historyOperationDataGridView.Columns.AddRange(new DataGridViewColumn[] { date, Column1, sender, type, money, Recipient });
            historyOperationDataGridView.Location = new Point(36, 22);
            historyOperationDataGridView.Name = "historyOperationDataGridView";
            historyOperationDataGridView.RowTemplate.Height = 25;
            historyOperationDataGridView.Size = new Size(667, 386);
            historyOperationDataGridView.TabIndex = 15;
            historyOperationDataGridView.Click += EnterForm_Load;
            // 
            // date
            // 
            date.Frozen = true;
            date.HeaderText = "Дата";
            date.Name = "date";
            date.ReadOnly = true;
            // 
            // Column1
            // 
            Column1.Frozen = true;
            Column1.HeaderText = "Тип операции";
            Column1.Name = "Column1";
            Column1.ReadOnly = true;
            // 
            // sender
            // 
            sender.HeaderText = "Отправитель";
            sender.Name = "sender";
            sender.ReadOnly = true;
            // 
            // type
            // 
            type.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            type.HeaderText = "Тип валюты";
            type.Name = "type";
            type.ReadOnly = true;
            type.Width = 60;
            // 
            // money
            // 
            money.HeaderText = "Деньги";
            money.Name = "money";
            money.ReadOnly = true;
            // 
            // Recipient
            // 
            Recipient.HeaderText = "Получатель";
            Recipient.Name = "Recipient";
            Recipient.ReadOnly = true;
            // 
            // historyLebel
            // 
            historyLebel.AutoSize = true;
            historyLebel.Location = new Point(36, 4);
            historyLebel.Name = "historyLebel";
            historyLebel.Size = new Size(105, 15);
            historyLebel.TabIndex = 6;
            historyLebel.Text = "Итория операций";
            // 
            // historyOperationExcel
            // 
            historyOperationExcel.Location = new Point(705, 548);
            historyOperationExcel.Name = "historyOperationExcel";
            historyOperationExcel.Size = new Size(251, 23);
            historyOperationExcel.TabIndex = 16;
            historyOperationExcel.Text = "История операций в EXCEL";
            historyOperationExcel.UseVisualStyleBackColor = true;
            historyOperationExcel.Click += HistoryOperationExcel_Click;
            // 
            // searchButton
            // 
            searchButton.Location = new Point(371, 548);
            searchButton.Name = "searchButton";
            searchButton.Size = new Size(273, 23);
            searchButton.TabIndex = 14;
            searchButton.Text = "Поиск операции";
            searchButton.UseVisualStyleBackColor = true;
            searchButton.Click += SearchButton_Click;
            // 
            // moneyTransferButton
            // 
            moneyTransferButton.Location = new Point(40, 548);
            moneyTransferButton.Name = "moneyTransferButton";
            moneyTransferButton.Size = new Size(292, 23);
            moneyTransferButton.TabIndex = 13;
            moneyTransferButton.Text = "Перевести деньги";
            moneyTransferButton.UseVisualStyleBackColor = true;
            moneyTransferButton.Click += MoneyTransferButton_Click;
            // 
            // createAccount
            // 
            createAccount.Location = new Point(40, 490);
            createAccount.Name = "createAccount";
            createAccount.Size = new Size(292, 23);
            createAccount.TabIndex = 11;
            createAccount.Text = "Создать счет";
            createAccount.UseVisualStyleBackColor = true;
            createAccount.Click += CreateAccount_Click;
            // 
            // button1
            // 
            button1.Location = new Point(40, 519);
            button1.Name = "button1";
            button1.Size = new Size(292, 23);
            button1.TabIndex = 7;
            button1.Text = "Пополнить счет";
            button1.UseVisualStyleBackColor = true;
            button1.Click += Button1_Click;
            // 
            // EnterForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(984, 661);
            Controls.Add(tabControl1);
            Controls.Add(exitButton);
            Name = "EnterForm";
            Text = "Личный кабинет";
            Load += EnterForm_Load;
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            tabPage2.ResumeLayout(false);
            tabControl2.ResumeLayout(false);
            tabPage3.ResumeLayout(false);
            tabPage3.PerformLayout();
            tabPage4.ResumeLayout(false);
            tabPage4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)historyOperationDataGridView).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Button exitButton;
        private Button saveLKButton;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private Label label9;
        private Label label8;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private TextBox password;
        private TextBox login;
        private TextBox email;
        private TextBox phone;
        private TextBox adress;
        private TextBox city;
        private TextBox age;
        private TextBox surname;
        private TextBox name;
        private Label label10;
        private Label label12;
        private Label label11;
        private Label historyLebel;
        private Button button1;
        private Label eurLebel;
        private Label usdLebel;
        private Label rubLebel;
        private Button createAccount;
        private Button moneyTransferButton;
        private Button searchButton;
        private DataGridView historyOperationDataGridView;
        private DataGridViewTextBoxColumn date;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn sender;
        private DataGridViewTextBoxColumn type;
        private DataGridViewTextBoxColumn money;
        private DataGridViewTextBoxColumn Recipient;
        private Button historyOperationExcel;
        private TabControl tabControl2;
        private TabPage tabPage3;
        private TabPage tabPage4;
    }
}