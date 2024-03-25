namespace FinClient.Forms
{
    partial class AuthorizationForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            loginInput = new TextBox();
            label2 = new Label();
            passwordInput = new TextBox();
            enterButton = new Button();
            registrationButton = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(183, 102);
            label1.Name = "label1";
            label1.Size = new Size(89, 15);
            label1.TabIndex = 0;
            label1.Text = "Введите логин:";
            // 
            // loginInput
            // 
            loginInput.Location = new Point(330, 94);
            loginInput.Name = "loginInput";
            loginInput.Size = new Size(250, 23);
            loginInput.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(183, 137);
            label2.Name = "label2";
            label2.Size = new Size(96, 15);
            label2.TabIndex = 2;
            label2.Text = "Введите пароль:";
            // 
            // passwordInput
            // 
            passwordInput.Location = new Point(330, 129);
            passwordInput.Name = "passwordInput";
            passwordInput.Size = new Size(250, 23);
            passwordInput.TabIndex = 3;
            // 
            // enterButton
            // 
            enterButton.Location = new Point(330, 211);
            enterButton.Name = "enterButton";
            enterButton.Size = new Size(145, 23);
            enterButton.TabIndex = 4;
            enterButton.Text = "Войти";
            enterButton.UseVisualStyleBackColor = true;
            enterButton.Click += EnterButton_Click;
            // 
            // registrationButton
            // 
            registrationButton.Location = new Point(330, 280);
            registrationButton.Name = "registrationButton";
            registrationButton.Size = new Size(145, 23);
            registrationButton.TabIndex = 5;
            registrationButton.Text = "Зарегистрироваться";
            registrationButton.UseVisualStyleBackColor = true;
            registrationButton.Click += RegistrationButton_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(registrationButton);
            Controls.Add(enterButton);
            Controls.Add(passwordInput);
            Controls.Add(label2);
            Controls.Add(loginInput);
            Controls.Add(label1);
            Name = "Form1";
            Text = "МЕГА ПУПЕР ДЕНЬГИ";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox loginInput;
        private Label label2;
        private TextBox passwordInput;
        private Button enterButton;
        private Button registrationButton;
    }
}