using FinClient.Forms;

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
            var dto = new UserDataDTO()
            {
                Id = _id,
                Name = name.Text,
                Surname = surname.Text,
                Age = age.Text,
                City = city.Text,
                Address = adress.Text,
                PhoneNumber = phone.Text,
                EmailAddress = email.Text,
                Login = login.Text,
                Password = password.Text,
            };

            using var httpClient = new HttpClient();
            var response = await httpClient.PutAsync(ServerConst.URL + $"Person/UpdateUsersPersonalData", ServerToBody.ToBody(dto));

            var validationResult = await response.Content.ReadFromJsonAsync<ValidationRegistrationResultDTO>();

            MessageBox.Show(response.Content.ToString());

            if (response.StatusCode == HttpStatusCode.BadRequest)
            {

                if (validationResult.Errors.ContainsKey("Name"))
                {
                    errorAge.Visible = true;
                    foreach (var item in validationResult.Errors["Name"])
                    {
                        errorName.Text = $"{item}\n\n";
                    }
                }

                if (validationResult.Errors.ContainsKey("Surname"))
                {
                    errorAge.Visible = true;
                    foreach (var item in validationResult.Errors["Surname"])
                    {
                        errorSurname.Text = $"{item}\n\n";
                    }
                }

                if (validationResult.Errors.ContainsKey("Age"))
                {
                    errorAge.Visible = true;
                    foreach (var item in validationResult.Errors["Age"])
                    {
                        errorAge.Text = $"{item}\n\n";
                    }
                }

                if (validationResult.Errors.ContainsKey("PhoneNumber"))
                {
                    errorPhoneNumber.Visible = true;
                    foreach (var item in validationResult.Errors["PhoneNumber"])
                    {
                        errorPhoneNumber.Text = $"{item}\n\n";
                    }
                }

                if (validationResult.Errors.ContainsKey("EmailAddress"))
                {
                    errorEmail.Visible = true;
                    foreach (var item in validationResult.Errors["EmailAddress"])
                    {
                        errorPhoneNumber.Text = $"{item}\n\n";
                    }
                }

                if (validationResult.Errors.ContainsKey("Login"))
                {
                    errorLogin.Visible = true;
                    foreach (var item in validationResult.Errors["Login"])
                    {
                        errorLogin.Text = $"{item}\n\n";
                    }
                }

                if (validationResult.Errors.ContainsKey("Login"))
                {
                    errorPassword.Visible = true;
                    foreach (var item in validationResult.Errors["Password"])
                    {
                        errorPassword.Text = $"{item}\n\n";
                    }
                }
            }
            if (!validationResult.IsSuccess)
            {
                MessageBox.Show(validationResult.Message["LoginError"]);
            }
            else
            {
                MessageBox.Show(validationResult.Message["Congratulations"]);
                Close();
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
            _form.Show();
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
            var response = await httpClient.GetAsync(ServerConst.URL + $"PersonMoney/UserTransfer/{_id}");
            var result = await response.Content.ReadFromJsonAsync<TransferHistoryDataDTO>();

            foreach (var transferItem in result.HistoryTransfers)
            {
                var index = historyOperationDataGridView.Rows.Add();

                historyOperationDataGridView.Rows[index].Cells[0].Value = transferItem.DateOperation;
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