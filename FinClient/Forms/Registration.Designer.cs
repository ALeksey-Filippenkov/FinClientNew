namespace FinClient.Forms
{
    partial class Registration
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
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            name = new TextBox();
            surnameInput = new TextBox();
            ageInput = new TextBox();
            phoneInput = new TextBox();
            adressInput = new TextBox();
            cityInput = new TextBox();
            passwordInput = new TextBox();
            loginInput = new TextBox();
            emailInput = new TextBox();
            backButton = new Button();
            addButton = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(63, 45);
            label1.Name = "label1";
            label1.Size = new Size(108, 15);
            label1.TabIndex = 0;
            label1.Text = "Введите Ваше имя";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(63, 78);
            label2.Name = "label2";
            label2.Size = new Size(141, 15);
            label2.TabIndex = 1;
            label2.Text = "Введите Вашу фамилию";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(63, 115);
            label3.Name = "label3";
            label3.Size = new Size(122, 15);
            label3.TabIndex = 2;
            label3.Text = "Введите Ваш возраст";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(63, 149);
            label4.Name = "label4";
            label4.Size = new Size(112, 15);
            label4.TabIndex = 3;
            label4.Text = "Введите Ваш город";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(63, 185);
            label5.Name = "label5";
            label5.Size = new Size(111, 15);
            label5.TabIndex = 4;
            label5.Text = "Введите Ваш адрес";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(63, 226);
            label6.Name = "label6";
            label6.Size = new Size(127, 15);
            label6.TabIndex = 5;
            label6.Text = "Введите Ваш телефон";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(63, 260);
            label7.Name = "label7";
            label7.Size = new Size(195, 15);
            label7.TabIndex = 6;
            label7.Text = "Введите Вашу электронную почту";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(63, 309);
            label8.Name = "label8";
            label8.Size = new Size(272, 15);
            label8.TabIndex = 7;
            label8.Text = "Введите Ваш логин для входа в личный кабинет";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(63, 346);
            label9.Name = "label9";
            label9.Size = new Size(279, 15);
            label9.TabIndex = 8;
            label9.Text = "Введите Ваш пароль для входа в личный кабинет";
            // 
            // name
            // 
            name.Location = new Point(372, 37);
            name.Name = "name";
            name.Size = new Size(377, 23);
            name.TabIndex = 9;
            // 
            // surnameInput
            // 
            surnameInput.Location = new Point(372, 70);
            surnameInput.Name = "surnameInput";
            surnameInput.Size = new Size(377, 23);
            surnameInput.TabIndex = 10;
            // 
            // ageInput
            // 
            ageInput.Location = new Point(372, 107);
            ageInput.Name = "ageInput";
            ageInput.Size = new Size(377, 23);
            ageInput.TabIndex = 11;
            // 
            // phoneInput
            // 
            phoneInput.Location = new Point(372, 218);
            phoneInput.Name = "phoneInput";
            phoneInput.Size = new Size(377, 23);
            phoneInput.TabIndex = 14;
            // 
            // adressInput
            // 
            adressInput.Location = new Point(372, 177);
            adressInput.Name = "adressInput";
            adressInput.Size = new Size(377, 23);
            adressInput.TabIndex = 13;
            // 
            // cityInput
            // 
            cityInput.Location = new Point(372, 141);
            cityInput.Name = "cityInput";
            cityInput.Size = new Size(377, 23);
            cityInput.TabIndex = 12;
            // 
            // passwordInput
            // 
            passwordInput.Location = new Point(372, 338);
            passwordInput.Name = "passwordInput";
            passwordInput.Size = new Size(377, 23);
            passwordInput.TabIndex = 17;
            // 
            // loginInput
            // 
            loginInput.Location = new Point(372, 301);
            loginInput.Name = "loginInput";
            loginInput.Size = new Size(377, 23);
            loginInput.TabIndex = 16;
            // 
            // emailInput
            // 
            emailInput.Location = new Point(372, 252);
            emailInput.Name = "emailInput";
            emailInput.Size = new Size(377, 23);
            emailInput.TabIndex = 15;
            // 
            // backButton
            // 
            backButton.Location = new Point(63, 388);
            backButton.Name = "backButton";
            backButton.Size = new Size(75, 23);
            backButton.TabIndex = 18;
            backButton.Text = "Назад";
            backButton.UseVisualStyleBackColor = true;
            backButton.Click += BackButton_Click;
            // 
            // addButton
            // 
            addButton.Location = new Point(674, 388);
            addButton.Name = "addButton";
            addButton.Size = new Size(75, 23);
            addButton.TabIndex = 19;
            addButton.Text = "Добавить";
            addButton.UseVisualStyleBackColor = true;
            addButton.Click += AddButton_Click;
            // 
            // Registration
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(addButton);
            Controls.Add(backButton);
            Controls.Add(passwordInput);
            Controls.Add(loginInput);
            Controls.Add(emailInput);
            Controls.Add(phoneInput);
            Controls.Add(adressInput);
            Controls.Add(cityInput);
            Controls.Add(ageInput);
            Controls.Add(surnameInput);
            Controls.Add(name);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Registration";
            Text = "Регистрация";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private TextBox name;
        private TextBox surnameInput;
        private TextBox ageInput;
        private TextBox phoneInput;
        private TextBox adressInput;
        private TextBox cityInput;
        private TextBox passwordInput;
        private TextBox loginInput;
        private TextBox emailInput;
        private Button backButton;
        private Button addButton;
    }
}