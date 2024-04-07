namespace FinancialApp.Forms
{
    partial class OperationSearch
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
            operationHistory = new Label();
            exitButton = new Button();
            searchButton = new Button();
            label2 = new Label();
            currencyTypeTextBox = new TextBox();
            label3 = new Label();
            personRecipientNameTextBox = new TextBox();
            monthCalendar1 = new MonthCalendar();
            HistoryOperationExcel = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(46, 44);
            label1.Name = "label1";
            label1.Size = new Size(76, 15);
            label1.TabIndex = 1;
            label1.Text = "Введите дату";
            // 
            // operationHistory
            // 
            operationHistory.AutoSize = true;
            operationHistory.Location = new Point(496, 36);
            operationHistory.Name = "operationHistory";
            operationHistory.Size = new Size(0, 15);
            operationHistory.TabIndex = 2;
            // 
            // exitButton
            // 
            exitButton.Location = new Point(42, 485);
            exitButton.Name = "exitButton";
            exitButton.Size = new Size(75, 23);
            exitButton.TabIndex = 3;
            exitButton.Text = "Назад";
            exitButton.UseVisualStyleBackColor = true;
            exitButton.Click += ExitButton_Click;
            // 
            // searchButton
            // 
            searchButton.Location = new Point(42, 422);
            searchButton.Name = "searchButton";
            searchButton.Size = new Size(424, 23);
            searchButton.TabIndex = 4;
            searchButton.Text = "Поиск";
            searchButton.UseVisualStyleBackColor = true;
            searchButton.Click += SearchButton_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(46, 225);
            label2.Name = "label2";
            label2.Size = new Size(73, 15);
            label2.TabIndex = 5;
            label2.Text = "Тип валюты";
            // 
            // currencyTypeTextBox
            // 
            currencyTypeTextBox.Location = new Point(302, 225);
            currencyTypeTextBox.Name = "currencyTypeTextBox";
            currencyTypeTextBox.Size = new Size(164, 23);
            currencyTypeTextBox.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(46, 282);
            label3.Name = "label3";
            label3.Size = new Size(98, 15);
            label3.TabIndex = 7;
            label3.Text = "Имя получателя";
            // 
            // personRecipientNameTextBox
            // 
            personRecipientNameTextBox.Location = new Point(302, 282);
            personRecipientNameTextBox.Name = "personRecipientNameTextBox";
            personRecipientNameTextBox.Size = new Size(164, 23);
            personRecipientNameTextBox.TabIndex = 8;
            // 
            // monthCalendar1
            // 
            monthCalendar1.Location = new Point(302, 36);
            monthCalendar1.Name = "monthCalendar1";
            monthCalendar1.TabIndex = 9;
            // 
            // HistoryOperationExcel
            // 
            HistoryOperationExcel.Location = new Point(579, 485);
            HistoryOperationExcel.Name = "HistoryOperationExcel";
            HistoryOperationExcel.Size = new Size(251, 23);
            HistoryOperationExcel.TabIndex = 17;
            HistoryOperationExcel.Text = "История операций в EXCEL";
            HistoryOperationExcel.UseVisualStyleBackColor = true;
            HistoryOperationExcel.Click += HistoryOperationExcel_Click;
            // 
            // OperationSearch
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(854, 520);
            Controls.Add(HistoryOperationExcel);
            Controls.Add(monthCalendar1);
            Controls.Add(personRecipientNameTextBox);
            Controls.Add(label3);
            Controls.Add(currencyTypeTextBox);
            Controls.Add(label2);
            Controls.Add(searchButton);
            Controls.Add(exitButton);
            Controls.Add(operationHistory);
            Controls.Add(label1);
            Name = "OperationSearch";
            Text = "Поиск операции:";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label1;
        private Label operationHistory;
        private Button exitButton;
        private Button searchButton;
        private Label label2;
        private TextBox currencyTypeTextBox;
        private Label label3;
        private TextBox personRecipientNameTextBox;
        private MonthCalendar monthCalendar1;
        private Button HistoryOperationExcel;
    }
}