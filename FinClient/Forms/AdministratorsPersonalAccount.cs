using FinCommon.DTO;
using FinCommon.Models;
using System.Net.Http.Json;

namespace FinancialApp.Forms
{
    public partial class AdministratorsPersonalAccount : Form
    {
        private readonly Guid _id;
        private readonly Form _authorizationForm;
        private readonly bool _isGeneralAdmin;


        public AdministratorsPersonalAccount(Guid id, Form form, bool isGeneralAdmin)
        {
            InitializeComponent();
            _isGeneralAdmin = isGeneralAdmin;
            _authorizationForm = form;
            _id = id;
        }


        private async void EnterForm_Load(object sender, EventArgs e)
        {
            dateTime.Text = DateOnly.FromDateTime(DateTime.Now).ToString();
            if (_isGeneralAdmin)
            {
                workingWithAdministratorButton.Visible = true;
                nameAdministration.Text = "Супер адмнистратор";
            }
            else
            {
                using var httpClient = new HttpClient();
                var response = await httpClient.GetAsync(ServerConst.URL + $"Admin/Name/{_id}");
                var result = await response.Content.ReadFromJsonAsync<AdminNameDTO>();

                nameAdministration.Text = result.AdministratorName;
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(
                "Вы действительно хотите выйти?",
                "Подтверждение выхода",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Information,
                MessageBoxDefaultButton.Button1,
                MessageBoxOptions.DefaultDesktopOnly);
            if (result != DialogResult.Yes) return;
            _authorizationForm.Show();
            Close();
        }

        private void WorkingWithUserButton_Click(object sender, EventArgs e)
        {
            showUserPersonalDataButton.Visible = true;
            banUserButton.Visible = true;
            deleteUserButton.Visible = true;
            findUserOperationsButton.Visible = true;
            restoreUserButton.Visible = true;
            label1.Visible = true;

            showAdministratorDataButton.Visible = false;
            addAdministratorButton.Visible = false;
            deleteAdministratorButton.Visible = false;
            searchAdministratorActionsButton.Visible = false;
        }

        private void ShowUserPersonalDataButton_Click(object sender, EventArgs e)
        {
            //var showUserInformation = new ShowUserInformation(_db, _id, _context, _isGeneralAdmin);
            //showUserInformation.Show();
        }

        private void BanUserButton_Click(object sender, EventArgs e)
        {
            //VisibleButtonTrue();
            //_userActions = AdministratorActionsWithUser.banUser;
        }

        private void DeleteUserButton_Click(object sender, EventArgs e)
        {
            //VisibleButtonTrue();
            //_userActions = AdministratorActionsWithUser.deleteUser;
        }

        private void FindUserOperationsButton_Click(object sender, EventArgs e)
        {
            //var findUserOperations = new FindUserOperations(_db, _formData, _context);
            //findUserOperations.Show();
        }

        private void RestoreUserButton_Click(object sender, EventArgs e)
        {
            //VisibleButtonTrue();
            //_userActions = AdministratorActionsWithUser.unbanUser;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            //if (comboBox1.Visible == true)
            //{
            //    switch (comboBox1.SelectedIndex)
            //    {
            //        case 0:

            //            var user = _context.Persons.FirstOrDefault(u =>
            //                u.Name.ToLower() == nameTextBox.Text.ToLower() && u.Surname.ToLower() == surnameTextBox.Text.ToLower());
            //            if (user.IsBanned)
            //            {
            //                MessageBox.Show("Пользователь забанен. Присвоение ему статуса администратора не возможно!");
            //                return;
            //            }
            //            if (user == null)
            //            {
            //                MessageBox.Show(
            //                    $"Пользователь с именем: {nameTextBox.Text} и фамилией {surnameTextBox.Text} не найдены");
            //                return;
            //            }

            //            ActionsWithUsers.CreatingAdministratorFormUsers(_db, nameTextBox.Text, surnameTextBox.Text, _context);
            //            break;
            //        case 1:
            //            ActionsWithUsers.CreatingAdministrator(_db, nameTextBox.Text, surnameTextBox.Text, _context);
            //            break;
            //    }
            //}
            //else
            //{
            //    var person = SearchPerson();
            //    UserActions(person);
            //}
        }
        /// <summary>
        /// Поиск пользователя
        /// </summary>
        /// <returns></returns>
        //private DbPerson SearchPerson()
        //{
        //    var searchPerson = _context.Persons.FirstOrDefault(p => p.Name == nameTextBox.Text);
        //    return searchPerson;
        //}

        /// <summary>
        /// Действия администратора с пользователем
        /// </summary>
        /// <param name="person"></param>
        //private void UserActions(DbPerson person)
        //{
        //    if (person == null)
        //    {
        //        MessageBox.Show("Пользователя с таким именем нет");
        //        return;
        //    }

        //    ActionsWithUsers.UserActions(_db, person, _userActions, _id, _context);

        //    VisibleButtonFalse();
        //}

        //private void VisibleButtonTrue()
        //{
        //    nameTextBox.Visible = true;
        //    nameLabel.Visible = true;
        //    saveButton.Visible = true;
        //}

        //private void VisibleButtonFalse()
        //{
        //    nameTextBox.Visible = false;
        //    nameLabel.Visible = false;
        //    saveButton.Visible = false;
        //}

        private void WorkingWithAdministratorButton_Click(object sender, EventArgs e)
        {
            label1.Visible = true;
            showAdministratorDataButton.Visible = true;
            addAdministratorButton.Visible = true;
            deleteAdministratorButton.Visible = true;
            searchAdministratorActionsButton.Visible = true;

            showUserPersonalDataButton.Visible = false;
            banUserButton.Visible = false;
            deleteUserButton.Visible = false;
            findUserOperationsButton.Visible = false;
            restoreUserButton.Visible = false;
        }

        private void AddAdministratorButton_Click(object sender, EventArgs e)
        {
            comboBox1.Visible = true;
        }

        private void SearchAdministratorActionsButton_Click(object sender, EventArgs e)
        {
            //var administratorActions = new HistoryAdministratorsActions(_db, _context);
            //administratorActions.Show();
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 1)
            {
                nameLabel.Visible = true;
                nameTextBox.Visible = true;
                surnameLabel.Visible = true;
                surnameTextBox.Visible = true;
                saveButton.Visible = true;
            }
            else
            {
                nameLabel.Visible = false;
                nameTextBox.Visible = false;
                surnameLabel.Visible = false;
                surnameTextBox.Visible = false;
                saveButton.Visible = true;
            }
        }
    }
}
