using System.Net;
using System.Net.Http.Json;
using FinCommon.DTO;
using FinCommon.Models;

namespace FinancialApp.Forms
{
    public partial class ReplenishmentCashAccount : Form
    {
        private readonly Guid _id;

        public ReplenishmentCashAccount(Guid id)
        {
            InitializeComponent();
            _id = id;
        }

        private async void AddMoneyButton_Click(object sender, EventArgs e)
        {
            var dto = new MoneyAccountDetailsDTO()
            {
                Balance = addMoneyBox.Text,
                PersonId = _id,
                Index = currencyList.SelectedIndex
            };

            using var httpClient = new HttpClient();
            var response = await httpClient.PostAsync(ServerConst.URL + "PersonMoney/ReplenishmentCashAccount", ServerToBody.ToBody(dto));
            var result = await response.Content.ReadFromJsonAsync<ValidationMoneyReplenishmentDTO>();
            if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                if (result.Errors.ContainsKey("Balance"))
                {
                    foreach (var item in result.Errors["Balance"])
                    {
                        MessageBox.Show(item);
                    }
                }
            }
            else
            {
                if (!result.IsSuccess)
                {
                    MessageBox.Show(result.Message);
                }
                else
                {
                    MessageBox.Show(result.Message);
                    Close();
                }
            }
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}