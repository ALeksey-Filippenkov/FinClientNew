namespace FinClient.Forms
{
    partial class ShowUserInformation
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
            components = new System.ComponentModel.Container();
            exitButton = new Button();
            userInformationDataGridView = new DataGridView();
            ContextMenuStripForGrid = new ContextMenuStrip(components);
            BanUser = new ToolStripMenuItem();
            RestoreUser = new ToolStripMenuItem();
            MakeAdministrator = new ToolStripMenuItem();
            ShowHistoryOperations = new ToolStripMenuItem();
            nameTextBox = new TextBox();
            label1 = new Label();
            printExcelButton = new Button();
            userStatusComboBox = new ComboBox();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)userInformationDataGridView).BeginInit();
            ContextMenuStripForGrid.SuspendLayout();
            SuspendLayout();
            // 
            // exitButton
            // 
            exitButton.Location = new Point(39, 497);
            exitButton.Name = "exitButton";
            exitButton.Size = new Size(75, 23);
            exitButton.TabIndex = 0;
            exitButton.Text = "Назад";
            exitButton.UseVisualStyleBackColor = true;
            exitButton.Click += ExitButton_Click;
            // 
            // userInformationDataGridView
            // 
            userInformationDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            userInformationDataGridView.ContextMenuStrip = ContextMenuStripForGrid;
            userInformationDataGridView.Location = new Point(12, 51);
            userInformationDataGridView.Name = "userInformationDataGridView";
            userInformationDataGridView.RowTemplate.Height = 25;
            userInformationDataGridView.Size = new Size(1206, 428);
            userInformationDataGridView.TabIndex = 21;
            userInformationDataGridView.CellEndEdit += DataGridViewPersons_CellEndEdit;
            userInformationDataGridView.MouseDown += UserInformationDataGridView_MouseDown;
            // 
            // ContextMenuStripForGrid
            // 
            ContextMenuStripForGrid.Items.AddRange(new ToolStripItem[] { BanUser, RestoreUser, MakeAdministrator, ShowHistoryOperations });
            ContextMenuStripForGrid.Name = "contextMenuStrip1";
            ContextMenuStripForGrid.Size = new Size(234, 92);
            ContextMenuStripForGrid.Opening += ContextMenuStripForGrid_Opening;
            // 
            // BanUser
            // 
            BanUser.Name = "BanUser";
            BanUser.Size = new Size(233, 22);
            BanUser.Text = "&Забанить пользователя";
            BanUser.Click += BanUser_Click;
            // 
            // RestoreUser
            // 
            RestoreUser.Name = "RestoreUser";
            RestoreUser.Size = new Size(233, 22);
            RestoreUser.Text = "&Восстановить пользователя";
            RestoreUser.Click += RestoreUser_Click;
            // 
            // MakeAdministrator
            // 
            MakeAdministrator.Name = "MakeAdministrator";
            MakeAdministrator.Size = new Size(233, 22);
            MakeAdministrator.Text = "&Сделать администратором";
            MakeAdministrator.Click += MakeAdministrator_Click;
            // 
            // ShowHistoryOperations
            // 
            ShowHistoryOperations.Name = "ShowHistoryOperations";
            ShowHistoryOperations.Size = new Size(233, 22);
            ShowHistoryOperations.Text = "&Показать историю операций";
            ShowHistoryOperations.Click += ShowHistoryOperations_Click;
            // 
            // nameTextBox
            // 
            nameTextBox.Location = new Point(247, 22);
            nameTextBox.Name = "nameTextBox";
            nameTextBox.Size = new Size(456, 23);
            nameTextBox.TabIndex = 17;
            nameTextBox.TextChanged += NameTextBox_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 22);
            label1.Name = "label1";
            label1.Size = new Size(158, 15);
            label1.TabIndex = 18;
            label1.Text = "Введите данные для поиска";
            // 
            // printExcelButton
            // 
            printExcelButton.Location = new Point(1001, 497);
            printExcelButton.Name = "printExcelButton";
            printExcelButton.Size = new Size(217, 23);
            printExcelButton.TabIndex = 20;
            printExcelButton.Text = "Выгрузить в EXCEL";
            printExcelButton.UseVisualStyleBackColor = true;
            printExcelButton.Click += PrintExcelButton_Click;
            // 
            // userStatusComboBox
            // 
            userStatusComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            userStatusComboBox.FormattingEnabled = true;
            userStatusComboBox.Items.AddRange(new object[] { "Все", "Забанен", "Не забаненные" });
            userStatusComboBox.Location = new Point(969, 22);
            userStatusComboBox.Name = "userStatusComboBox";
            userStatusComboBox.Size = new Size(121, 23);
            userStatusComboBox.TabIndex = 23;
            userStatusComboBox.SelectedIndexChanged += ComboBox1_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(769, 25);
            label2.Name = "label2";
            label2.Size = new Size(176, 15);
            label2.TabIndex = 24;
            label2.Text = "Выберите статус пользователя";
            // 
            // ShowUserInformation
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1230, 532);
            Controls.Add(label2);
            Controls.Add(userStatusComboBox);
            Controls.Add(printExcelButton);
            Controls.Add(label1);
            Controls.Add(nameTextBox);
            Controls.Add(userInformationDataGridView);
            Controls.Add(exitButton);
            Name = "ShowUserInformation";
            Text = "Информация о пользователе";
            Load += ShowUserInformation_Load;
            ((System.ComponentModel.ISupportInitialize)userInformationDataGridView).EndInit();
            ContextMenuStripForGrid.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button exitButton;
        private DataGridView userInformationDataGridView;
        private TextBox nameTextBox;
        private Label label1;
        private Button printExcelButton;
        private ComboBox userStatusComboBox;
        private Label label2;
        private ContextMenuStrip ContextMenuStripForGrid;
        private ToolStripMenuItem BanUser;
        private ToolStripMenuItem RestoreUser;
        private ToolStripMenuItem MakeAdministrator;
        private ToolStripMenuItem ShowHistoryOperations;
    }
}