using FinClient.AdditionalClassesClient;
using FinCommon.DTO;
using FinCommon.Models;
using FinServer.Enum;
using System.Net.Http.Json;

namespace FinClient.Forms
{
    public partial class MoneyTransfer : Form
    {
        private readonly Guid _id;


        public MoneyTransfer(Guid id)
        {
            InitializeComponent();
            _id = id;
            ViewRichTextBoxOutData();
            linkLabel1.LinkClicked += LinkLabel1_LinkClicked;
        }

        private async void TransferButton_Click(object sender, EventArgs e)
        {
            PhoneNumberError.Visible = false;
            CurrencyTypeError.Visible = false;
            MoneyError.Visible = false;

            var phoneNumberTransferValue = int.TryParse(phoneNumerTransferInput.Text, out var phoneNumberTransferInt);
            if (phoneNumerTransferInput.Text == string.Empty)
            {
                MessageBox.Show("Необходимо указать номер телефона получателя в виде числа.");
                return;
            }

            if (!phoneNumberTransferValue)
            {
                MessageBox.Show("Вы ввели не номер телефона.");
                return;
            }

            var moneyTransferValue = double.TryParse(moneyTransferInput.Text, out var moneyTransferDouble);
            if (moneyTransferInput.Text == string.Empty)
            {
                MessageBox.Show($"Вы не ввели сумму для {TypeOperation.GetTypeOfOperation(TypeOfOperation.moneyTransfer).ToLower()}а");
                return;
            }

            if (!moneyTransferValue)
            {
                MessageBox.Show("Деньги могут быть только ввиде чисел");
                return;
            }

            var dto = new MoneyTransferDTO()
            {
                Id = _id,
                RecipientsPhoneNumber = phoneNumberTransferInt,
                Index = currencyList.SelectedIndex,
                MoneyTransfer = moneyTransferDouble
            };

            using var httpClient = new HttpClient();
            var response = await httpClient.PutAsync(ServerConst.URL + $"PersonMoney/MoneyTransfer", ServerToBody.ToBody(dto));

            var moneyTransferResult = await response.Content.ReadFromJsonAsync<ValidationMoneyTransferResultDTO>();

            if (!moneyTransferResult.IsSuccess)
            {
                var formData = new FormMoneyTransferClient()
                {
                    PhoneNumber = PhoneNumberError,
                    CurrencyType = CurrencyTypeError,
                    MoneyTransfer = MoneyError
                };
                GeneralMethodsClient.CommonMethodClient.ShowErrorMoneyTransfer(moneyTransferResult, formData);
            }
            else
            {
                MessageBox.Show(moneyTransferResult.Message["Congratulation"]);
                Close();
            }
        }

        private async void ViewRichTextBoxOutData()
        {
            using var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(ServerConst.URL + $"PersonMoney/ExchangeRateCB");
            var result = await response.Content.ReadFromJsonAsync<ExchangeRateCBDTO>();

            label7.Text = $"Курс основных валют\nДоллар: {result.Usd}\nЕвро: {result.Eur}";
        }

        private async void ExchangeButton_Click(object sender, EventArgs e)
        {
            DebitAccountError.Visible = false;
            ReplenishmentAccountError.Visible = false;
            MoneyExchangeError.Visible = false;

            var moneyValue = double.TryParse(moneyTextBox.Text, out var money);
            if (!moneyValue)
            {
                MessageBox.Show("Вы ввели не число.");
                return;
            }

            var dto = new MoneyExchangeDTO()
            {
                Id = _id,
                DebitAccountIndex = debitAccountComboBox.SelectedIndex,
                AccountForReplenishmentIndex = replenishmentAccountComboBox.SelectedIndex,
                Money = money
            };

            using var httpClient = new HttpClient();
            var response = await httpClient.PutAsync(ServerConst.URL + $"PersonMoney/MoneyExchange", ServerToBody.ToBody(dto));
            var moneyExchangeResult = await response.Content.ReadFromJsonAsync<ValidationMoneyExchangeResultDTO>();


            if (!moneyExchangeResult.IsSuccess)
            {
                var formData = new FormMoneyExchangeClient()
                {
                    DebitAccountError = DebitAccountError,
                    ReplenishmentAccountError = ReplenishmentAccountError,
                    MoneyExchangeError = MoneyExchangeError
                };
                GeneralMethodsClient.CommonMethodClient.ShowErrorMoneyExchange(moneyExchangeResult, formData);
            }
            else
            {
                MessageBox.Show(moneyExchangeResult.Message["Congratulation"]);
                Close();
            }
        }
        
        private void ExitButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.linkLabel1.LinkVisited = true;
            System.Diagnostics.Process.Start("https://cbr.ru");
        }
    }
}