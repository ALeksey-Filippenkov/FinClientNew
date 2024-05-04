using FinClient.GeneralMethodsClient;
using FinCommon.DTO;
using FinCommon.Models;
using FinServer.AdditionalClasses;
using System.Net.Http.Json;

namespace FinancialApp.Forms
{
    public partial class OperationSearch : Form
    {
        private readonly Guid _id;
        private List<HistoryMoneyTransactions> _historyOperation;

        public OperationSearch(Guid id)
        {
            InitializeComponent();
            monthCalendar1.MaxSelectionCount = 31;
            monthCalendar1.TodayDate = DateTime.Now;
            monthCalendar1.ShowToday = true;
            _id = id;
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void SearchButton_Click(object sender, EventArgs e)
        {
            var dto = new SearchOperationDataDTO()
            {
                Id = _id,
                StartingDateSearch = monthCalendar1.SelectionRange.Start.Date,
                EndingDateSearch = monthCalendar1.SelectionRange.End.Date,
                CurrencyTypeValue = currencyTypeTextBox.Text.ToUpper(),
                PersonRecipientName = personRecipientNameTextBox.Text
            };


            using var httpClient = new HttpClient();

            var response = await httpClient.PostAsync(ServerConst.URL + $"OperationHistory/SearchUserOperation",
                ServerToBody.ToBody(dto));

            var result = await response.Content.ReadFromJsonAsync<TransferHistoryDataDTO>();
            if (!result.IsSuccess && result.Message != null)
            {
                operationHistory.Text = "История операций";
                if (result.Message.ContainsKey("OperationCountError"))
                {
                    operationHistory.Text += $"\n{result.Message["OperationCountError"]}";
                }

                if (result.Message.ContainsKey("OperationsByNameError"))
                {
                    operationHistory.Text += $"\n{result.Message["OperationsByNameError"]}";
                }

                if (result.Message.ContainsKey("OperationsByDateError"))
                {
                    operationHistory.Text += $"\n{result.Message["OperationsByDateError"]}";
                }

                if (result.Message.ContainsKey("CurrencyTypeError"))
                {
                    operationHistory.Text += $"\n{result.Message["CurrencyTypeError"]}";
                }
            }
            else
            {
                result.HistoryTransfers.Sort((x, y) => y.DateOperation.CompareTo(x.DateOperation));
                _historyOperation = result.HistoryTransfers;
                operationHistory.Text = "История операций";
                foreach (var transferItem in result.HistoryTransfers)
                {
                    operationHistory.Text +=
                        $"\n{transferItem.DateOperation} {transferItem.SendersName} {transferItem.TypeAction} {transferItem.Money} {transferItem.CurrencyType} {transferItem.RecipientsName}";
                }

                this.AutoSize = true;
            }
        }
        private void HistoryOperationExcel_Click(object sender, EventArgs e)
        {
            var newExcel = new DataOutputInExcel();
            newExcel.GetDataOutputInExcel(_historyOperation);
        }
    }
}
