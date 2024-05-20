using System.Net.Http.Json;
using System.Runtime.InteropServices;
using FinClient.GeneralMethodsClient;
using FinCommon.DTO;
using FinCommon.Models;
using FinServer.DbModels;
using Excel = Microsoft.Office.Interop.Excel;

namespace FinClient.Forms
{
    public partial class ShowUserInformation : Form
    {
        private readonly Guid _id;
        private List<DbPerson> _user;
        private readonly List<string> _personData;
        private int _index;
        private bool cancelContextMenu = false;

        public ShowUserInformation(Guid id, bool isGeneralAdmin)
        {
            _id = id;
            _personData = PersonalData.GetUserData();
            InitializeComponent();
            RefreshDataGridView();

            if (isGeneralAdmin)
            {
                var deleteMenuItem = new ToolStripMenuItem("Удалить пользователя");
                ContextMenuStripForGrid.Items.Add(deleteMenuItem);
                deleteMenuItem.Click += DeleteMenuItem_Click;
            }
        }

        private void NameTextBox_TextChanged(object sender, EventArgs e)
        {
            RefreshDataGridView();
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            _index = userStatusComboBox.SelectedIndex;
            RefreshDataGridView();
        }

        private void ShowUserInformation_Load(object sender, EventArgs e)
        {
            RefreshDataGridView();
        }

        /// <summary>
        /// Обноваление в DataGrid информации
        /// </summary>
        private async void RefreshDataGridView()
        {
            userInformationDataGridView.DataSource = null;

            var dto = new SearchForUserDataDTO()
            {
                SearchString = nameTextBox.Text.ToLower(),
                Index = _index,
            };

            using var httpClient = new HttpClient();
            var response = await httpClient.PostAsync(ServerConst.URL + $"Admin/SearchUsersData", ServerToBody.ToBody(dto));

            var _user = await response.Content.ReadFromJsonAsync<UserDataOfTheProgramDTO>();
            
            userInformationDataGridView.DataSource = _user.UsersOfTheProgram;

            userInformationDataGridView.Columns["Name"].HeaderText = "Имя";
            userInformationDataGridView.Columns["Name"].Width = 100;
            userInformationDataGridView.Columns["Surname"].HeaderText = "Фамилия";
            userInformationDataGridView.Columns["Surname"].Width = 200;
            userInformationDataGridView.Columns["Age"].HeaderText = "Возраст";
            userInformationDataGridView.Columns["Age"].Width = 100;
            userInformationDataGridView.Columns["City"].HeaderText = "Город";
            userInformationDataGridView.Columns["City"].Width = 100;
            userInformationDataGridView.Columns["Address"].HeaderText = "Адрес";
            userInformationDataGridView.Columns["Address"].Width = 200;
            userInformationDataGridView.Columns["PhoneNumber"].HeaderText = "Номер телефона";
            userInformationDataGridView.Columns["PhoneNumber"].Width = 100;
            userInformationDataGridView.Columns["EmailAddress"].HeaderText = "Электронная почта";
            userInformationDataGridView.Columns["EmailAddress"].Width = 200;
            userInformationDataGridView.Columns["Login"].HeaderText = "Логин";
            userInformationDataGridView.Columns["Login"].Width = 100;
            userInformationDataGridView.Columns["Login"].ReadOnly = true;
            userInformationDataGridView.Columns["Password"].HeaderText = "Пароль";
            userInformationDataGridView.Columns["Password"].Width = 100;
            userInformationDataGridView.Columns["Password"].ReadOnly = true;
            userInformationDataGridView.Columns["Id"].Width = 300;
            userInformationDataGridView.Columns["Id"].ReadOnly = true;
            userInformationDataGridView.Columns["IsBanned"].HeaderText = "Статус бана";
            userInformationDataGridView.Columns["IsBanned"].Width = 100;
            userInformationDataGridView.Columns["IsBanned"].ReadOnly = true;
        }

        /// <summary>
        /// Поиск изменений информации о пользователе в DataGrid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGridViewPersons_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //var row = e.RowIndex;
            //var col = e.ColumnIndex;

            //var cell = userInformationDataGridView[col, row];

            //var cellValue = cell.Value;

            //var person = _user[row];



            //switch (col)
            //{
            //    case 0:
            //        person.Name = (string)cellValue;
            //        SavingChangesUsersPersonalData(person.Name);
            //        break;
            //    case 1:
            //        person.Surname = (string)cellValue;
            //        break;
            //    case 2:
            //        person.Age = (int)cellValue;
            //        break;
            //    case 3:
            //        person.City = (string)cellValue;
            //        break;
            //    case 4:
            //        person.Address = (string)cellValue;
            //        break;
            //    case 5:
            //        person.PhoneNumber = (int)cellValue;
            //        break;
            //    case 6:
            //        person.EmailAddress = (string)cellValue;
            //        break;
            //    default:
            //        MessageBox.Show("Поля нельзя редактировать");
            //        break;
            //}
        }

        //private async void SavingChangesUsersPersonalData(string item)
        //{
        //    var dto = new DataForChangingUsersPersonalDataDTO()
        //    {
        //        DataToChange = item,
        //    };

        //    using var httpClient = new HttpClient();
        //    var response = await httpClient.PutAsync(ServerConst.URL + $"Admin/ChangingUserData", ServerToBody.ToBody(dto));
        //}

        private void ExitButton_Click(object sender, EventArgs e)
        {
        Close();
    }

        private void PrintExcelButton_Click(object sender, EventArgs e)
        {
            PrintExcel();
        }

        /// <summary>
        /// Выгрузка данных из DataGrid в Excel
        /// </summary>
        private void PrintExcel()
        {
            Excel.Application application = null;
            Excel.Workbook workbook = null;
            Excel.Worksheet worksheet = null;

            try
            {
                application = new Excel.Application
                {
                    Visible = true
                };

                workbook = application.Workbooks.Add();
                worksheet = workbook.Worksheets.Item[1];

                worksheet.Cells[1, 1].Value = "# Пользователя";

                var amountUsers = _user.Count;

                for (int i = 0, rows = 1, cols = 2; i < _personData.Count; i++, cols++)
                {
                    worksheet.Cells[rows, cols].Value = _personData[i];
                }

                for (int userNumber = 0, rows = 2, cols = 1; rows < amountUsers + 2; userNumber++, rows++)
                {
                    var person = _user[userNumber];

                    worksheet.Cells[rows, cols].Value = userNumber + 1;
                    worksheet.Cells[rows, cols + 1].Value = person.Name;
                    worksheet.Cells[rows, cols + 2].Value = person.Surname;
                    worksheet.Cells[rows, cols + 3].Value = person.Age;
                    worksheet.Cells[rows, cols + 4].Value = person.City;
                    worksheet.Cells[rows, cols + 5].Value = person.Address;
                    worksheet.Cells[rows, cols + 6].Value = person.PhoneNumber;
                    worksheet.Cells[rows, cols + 7].Value = person.EmailAddress;
                    worksheet.Cells[rows, cols + 8].Value = person.Login;
                    worksheet.Cells[rows, cols + 9].Value = person.Password;
                    worksheet.Cells[rows, cols + 10].Value = string.Join("-", person.Id);

                    worksheet.Cells[rows, cols + 11].Value = person.IsBanned ? "Да" : "Нет";
                }

                for (var i = 1; i <= worksheet.UsedRange.Columns.Count; i++)
                {
                    worksheet.Columns[i].AutoFit();
                    worksheet.Columns[i].HorizontalAlignment = Excel.Constants.xlCenter;
                }

                worksheet.Protect();
            }

            finally
            {
                Marshal.ReleaseComObject(worksheet);
                Marshal.ReleaseComObject(workbook);
                Marshal.ReleaseComObject(application);
            }
        }

        private void UserInformationDataGridView_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right) return;
            var hitTestInfo = userInformationDataGridView.HitTest(e.X, e.Y);
            if (hitTestInfo.RowIndex >= 0 && hitTestInfo.ColumnIndex >= 0)
            {
                userInformationDataGridView.ClearSelection();
                userInformationDataGridView.Rows[hitTestInfo.RowIndex].Selected = true;
                cancelContextMenu = false;
            }
            else
            {
                cancelContextMenu = true;
            }
        }

        private void ContextMenuStripForGrid_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (cancelContextMenu)
            {
                e.Cancel = true;
            }
        }

        private void BanUser_Click(object sender, EventArgs e)
        {
            //var selectedRows = userInformationDataGridView.SelectedRows;
            //foreach (DataGridViewRow selectedRow in selectedRows)
            //{
            //    var rowIndex = selectedRow.Index;

            //    if (rowIndex < 0)
            //    {
            //        continue;
            //    }

            //    var person = _user[rowIndex];
            //    var dlgConfirm =
            //        MessageBox.Show(
            //            "Забанить пользователя?\r\n\r\nИмя: " + person.Name + "\r\n Фамилия: " + person.Surname,
            //            "Подтвердите", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            //    if (dlgConfirm == DialogResult.Yes)
            //    {
            //        ActionsWithUsers.UserActions(_db, person, AdministratorActionsWithUser.banUser, _id, _context);
            //    }
            //    RefreshDataGridView();
            //}
        }

        private void RestoreUser_Click(object sender, EventArgs e)
        {
            //var selectedRows = userInformationDataGridView.SelectedRows;
            //foreach (DataGridViewRow selectedRow in selectedRows)
            //{
            //    var rowIndex = selectedRow.Index;

            //    if (rowIndex < 0)
            //    {
            //        continue;
            //    }

            //    var person = _user[rowIndex];
            //    var dlgConfirm =
            //        MessageBox.Show(
            //            "Разбанить пользователя?\r\n\r\nИмя: " + person.Name + "\r\nФамилия: " + person.Surname,
            //            "Подтвердите", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            //    if (dlgConfirm == DialogResult.Yes)
            //    {
            //        ActionsWithUsers.UserActions(_db, person, AdministratorActionsWithUser.unbanUser, _id, _context);
            //    }
            //    RefreshDataGridView();
            //}
        }

        private void MakeAdministrator_Click(object sender, EventArgs e)
        {
            //var selectedRows = userInformationDataGridView.SelectedRows;
            //foreach (DataGridViewRow selectedRow in selectedRows)
            //{
            //    var rowIndex = selectedRow.Index;

            //    if (rowIndex < 0)
            //    {
            //        continue;
            //    }

            //    var person = _user[rowIndex];
            //    if (person.IsBanned)
            //    {
            //        MessageBox.Show("Пользователь забанен. Присвоение ему статуса администратора не возможно!");
            //        return;
            //    }
            //    var dlgConfirm =
            //        MessageBox.Show(
            //            "Доавить пользователю права адмнистратора?\r\n\r\nИмя: " + person.Name + "\r\nФамилия: " +
            //            person.Surname, "Подтвердите", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            //    if (dlgConfirm == DialogResult.Yes)
            //    {
            //        var name = person.Name;
            //        var surName = person.Surname;
            //        ActionsWithUsers.CreatingAdministratorFormUsers(_db, name, surName, _context);
            //    }
            //    RefreshDataGridView();
            //}
        }

        private void ShowHistoryOperations_Click(object sender, EventArgs e)
        {
            //var selectedRows = userInformationDataGridView.SelectedRows;
            //foreach (DataGridViewRow selectedRow in selectedRows)
            //{
            //    var rowIndex = selectedRow.Index;

            //    if (rowIndex < 0)
            //    {
            //        continue;
            //    }

            //    var person = _user[rowIndex];
            //    var userTransactionHistory = new UserTransactionHistory(_db, _formData, person, _context);
            //    userTransactionHistory.Show();
            //}
        }

        void DeleteMenuItem_Click(object sender, EventArgs e)
        {
            //var selectedRows = userInformationDataGridView.SelectedRows;
            //foreach (DataGridViewRow selectedRow in selectedRows)
            //{
            //    var rowIndex = selectedRow.Index;

            //    if (rowIndex < 0)
            //    {
            //        continue;
            //    }

            //    var person = _user[rowIndex];
            //    var dlgConfirm =
            //        MessageBox.Show(
            //            "Удалить пользователя?\r\n\r\nИмя: " + person.Name + "\r\nФамилия: " + person.Surname,
            //            "Подтвердите", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            //    if (dlgConfirm == DialogResult.Yes)
            //    {
            //        ActionsWithUsers.UserActions(_db, person, AdministratorActionsWithUser.deleteUser, _id, _context);
            //    }
            //    RefreshDataGridView();
            //}
        }
    }
}
