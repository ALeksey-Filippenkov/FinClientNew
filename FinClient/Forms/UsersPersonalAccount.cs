using System.Net.Http.Json;
using System.Text.Json;
using System.Text;
using FinCommon.DTO;
using FinCommon.Models;

namespace FinancialApp.Forms
{
    public partial class UsersPersonalAccount : Form
    {
        private readonly Guid _id;
        private readonly Form _form;

        public UsersPersonalAccount(Guid id, Form form)
        {
            InitializeComponent();
            _id = id;
            _form = form;
        }

        private async void EnterForm_Load(object sender, EventArgs e)
        {
            using var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(ServerConst.URL + $"Person/UserData/{_id}");
            var result = await response.Content.ReadFromJsonAsync<UserDataAccountInformationDTO>();

            name.Text = result.Name;
            surname.Text = result.Surname;
            age.Text = result.Age.ToString();
            city.Text = result.City;
            adress.Text = result.Adress;
            phone.Text = result.PhoneNumber.ToString();
            email.Text = result.EmailAdress;
            login.Text = result.Login;
            password.Text = result.Password;
        }

        private async void SaveLKButton_Click(object sender, EventArgs e)
        {
            var dto = new PutUserDataDTO()
            {
                Id = _id,
                Name = name.Text,
                Surname = surname.Text,
                Age = age.Text,
                City = city.Text,
                Adress = adress.Text,
                PhoneNumber = phone.Text,
                EmailAdress = email.Text,
                Login = login.Text,
                Password = password.Text,
            };

            using var httpClient = new HttpClient();
            var response = await httpClient.PutAsync(ServerConst.URL +$"Person/PutUserData/{_id}", ToBody(dto));

            var result = await response.Content.ReadFromJsonAsync<ResultDTO>();
            switch (result.IsSuccess)
            {
                case true:
                    MessageBox.Show("Поздравляем! Вы успешно изменили данные");
                    Close();
                    break;
                case false:
                    MessageBox.Show(result.Message);
                    break;
            }
        }

        public StringContent ToBody(object model)
        {
            return new(
                JsonSerializer.Serialize(model),
                Encoding.UTF8,
                "application/json");
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(
                "Вы действительно хотите выйти?",
                "Подтверждение выхода",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Information,
                MessageBoxDefaultButton.Button1,
                MessageBoxOptions.DefaultDesktopOnly);
            if (result != DialogResult.Yes) return;
            _form.Show();
            Close();
        }

        private void TabPage2_Click(object sender, EventArgs e)
        {
            EnterLabelText();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            //var addMoney = new AddMoney(_db, _id, _formDataData, _context);
            //addMoney.Show();
        }

        private void CreateAccount_Click(object sender, EventArgs e)
        {
            //var creatingAccount = new CreatingAccount(_db, _id, _context);
            //creatingAccount.Show();
        }

        private void EnterLabelText()
        {
            //RebootLabelText.LabelText(_db, _id, _formDataData, _context);
        }

        private void MoneyTransferButton_Click(object sender, EventArgs e)
        {
            //var moneyTransfer = new MoneyTransfer(_db, _id, _formDataData, _context);
            //moneyTransfer.Show();
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            //var operationSearch = new OperationSearch(_db, _id, _context);
            //operationSearch.Show();
        }

        private void HistoryOperationExcel_Click(object sender, EventArgs e)
        {
            //var newExcel = new DataOutputInExcel(_db, _context);
            //newExcel.GetDataOutputInExcel(CommonMethod.GetHistoryTransfer(_db, _id, _context));
        }

        private void TabPage3_Click(object sender, EventArgs e)
        {
            //CommonMethod.GetHistoryTransfer(_db, _id, _context);
            //EnterLabelText();
            //RefreshDataGridView();
            //var panel = new Panel
            //{
            //    Location = new Point(30, 30),
            //    Visible = true
            //};
            //tabPage3.Controls.Add(panel);
        }

        //private void RefreshDataGridView()
        //{
        //    PrintHistory.GetPrintHistory(_db, CommonMethod.GetHistoryTransfer(_db, _id, _context), _formDataData, _context);
        //}
    }
}