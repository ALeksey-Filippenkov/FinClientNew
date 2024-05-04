using FinClient.Forms;
using FinClient.GeneralMethodsClient;
using FinCommon.DTO;
using FinCommon.Models;
using FinServer.AdditionalClasses;
using System.Net.Http.Json;

namespace FinancialApp.Forms
{
    public partial class UsersPersonalAccount : Form
    {
        private readonly Guid _id;
        private readonly AuthorizationForm _authorizationForm;
        private List<HistoryMoneyTransactions> _historyOperation;

        public UsersPersonalAccount(Guid id, AuthorizationForm authorizationForm)
        {
            InitializeComponent();
            _id = id;
            _authorizationForm = authorizationForm;
        }

        private async void EnterForm_Load(object sender, EventArgs e)
        {
            this.AutoSize = true;

            using var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(ServerConst.URL + $"Person/UserData/{_id}");
            var result = await response.Content.ReadFromJsonAsync<UserDataAccountInformationDTO>();

            name.Text = result.Name;
            surname.Text = result.Surname;
            age.Text = result.Age.ToString();
            city.Text = result.City;
            adress.Text = result.Address;
            phone.Text = result.PhoneNumber.ToString();
            email.Text = result.EmailAddress;
            login.Text = result.Login;
            password.Text = result.Password;

            EnterLabelText();
            RefreshDataGridView();
        }

        private async void SaveLKButton_Click(object sender, EventArgs e)
        {
            errorAge.Visible = false;
            errorPhoneNumber.Visible = false;
            errorEmail.Visible = false;
            errorLogin.Visible = false;
            errorPassword.Visible = false;
            errorSurname.Visible = false;
            errorName.Visible = false;

            var ageValue = int.TryParse(age.Text, out var ageInt);
            if (!ageValue)
            {
                errorAge.Visible = true;
                errorAge.Text = @"В поле ""Возраст"" должно быть введено число и оно не может быть пустым.";
                this.AutoSize = true;
            }

            var phoneNumberValue = int.TryParse(phone.Text, out var phoneNumberInt);
            if (!phoneNumberValue)
            {
                errorPhoneNumber.Visible = true;
                errorPhoneNumber.Text = @"В поле ""Номер телефона"" должно быть введено число и оно не может быть пустым.";
                this.AutoSize = true;
            }

            if (ageValue && phoneNumberValue)
            {
                var dto = new UserDataDTO()
                {
                    Id = _id,
                    Name = name.Text,
                    Surname = surname.Text,
                    Age = ageInt,
                    City = city.Text,
                    Address = adress.Text,
                    PhoneNumber = phoneNumberInt,
                    EmailAddress = email.Text,
                    Login = login.Text,
                    Password = password.Text,
                };

                using var httpClient = new HttpClient();
                var response = await httpClient.PutAsync(ServerConst.URL + $"Person/UpdateUsersPersonalData", ServerToBody.ToBody(dto));

                var validationResult = await response.Content.ReadFromJsonAsync<ValidationRegistrationResultDTO>();

                if (validationResult.Status == 400 || !validationResult.IsSuccess)
                {
                    var formDataClient = new FormUsersPersonalDataClient
                    {
                        ErrorName = errorName,
                        ErrorSurname = errorSurname,
                        ErrorAge = errorAge,
                        ErrorPhoneNumber = errorPhoneNumber,
                        ErrorEmail = errorEmail,
                        ErrorLogin = errorLogin,
                        ErrorPassword = errorPassword,
                    };
                    CommonMethodClient.ShowErrorsPersonData(formDataClient, validationResult);
                }
                else
                {
                    MessageBox.Show(validationResult.Message["Congratulations"]);
                    Close();
                }
            }
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
            _authorizationForm.Show();
            Close();
        }

        private void TabPage2_Click(object sender, EventArgs e)
        {
            this.AutoSize = true;
            EnterLabelText();
        }

        private void ReplenishmentCashAccountButton_Click(object sender, EventArgs e)
        {
            var addMoney = new ReplenishmentCashAccount(_id);
            addMoney.Show();
        }

        private void CreateCashAccount_Click(object sender, EventArgs e)
        {
            var creatingAccount = new CreatingMoneyAccount(_id);
            creatingAccount.Show();
        }

        private async void EnterLabelText()
        {
            using var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(ServerConst.URL + $"PersonMoney/UserCashBalance/{_id}");
            var result = await response.Content.ReadFromJsonAsync<CashAccountBalanceDTO>();

            rubLebel.Text = result.Rub.ToString();
            usdLebel.Text = result.Usd.ToString();
            eurLebel.Text = result.Eur.ToString();
        }

        private void MoneyTransferButton_Click(object sender, EventArgs e)
        {
            var moneyTransfer = new MoneyTransfer(_id);
            moneyTransfer.Show();
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            var operationSearch = new OperationSearch(_id);
            operationSearch.Show();
        }

        private async void HistoryOperationExcel_Click(object sender, EventArgs e)
        {
            var newExcel = new DataOutputInExcel();
            newExcel.GetDataOutputInExcel(_historyOperation);
        }

        private void TabPage3_Click(object sender, EventArgs e)
        {
            EnterLabelText();
            RefreshDataGridView();
            var panel = new Panel
            {
                Location = new Point(30, 30),
                Visible = true
            };
            tabPage3.Controls.Add(panel);
        }

        private async void RefreshDataGridView()
        {
            historyOperationDataGridView.Rows.Clear();

            using var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(ServerConst.URL + $"OperationHistory/UserTransfer/{_id}");
            var result = await response.Content.ReadFromJsonAsync<TransferHistoryDataDTO>();
            result.HistoryTransfers.Sort((x,y) => y.DateOperation.CompareTo(x.DateOperation));
            _historyOperation = result.HistoryTransfers;

            foreach (var transferItem in result.HistoryTransfers)
            {
                var index = historyOperationDataGridView.Rows.Add();

                historyOperationDataGridView.Rows[index].Cells[0].Value = DateOnly.FromDateTime(transferItem.DateOperation);
                historyOperationDataGridView.Rows[index].Cells[3].Value = transferItem.CurrencyType;
                historyOperationDataGridView.Rows[index].Cells[4].Value = transferItem.Money;

                if (transferItem.TypeAction == "Перевод денег")
                {
                    historyOperationDataGridView.Rows[index].Cells[1].Value = transferItem.TypeAction;
                    historyOperationDataGridView.Rows[index].Cells[2].Value = transferItem.SendersName;
                    historyOperationDataGridView.Rows[index].Cells[5].Value = transferItem.RecipientsName;
                }
                else
                {
                    historyOperationDataGridView.Rows[index].Cells[1].Value = transferItem.TypeAction;
                    historyOperationDataGridView.Rows[index].Cells[2].Value = transferItem.SendersName;
                }
            }
        }
    }
}