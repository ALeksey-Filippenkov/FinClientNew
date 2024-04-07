using System.ComponentModel.DataAnnotations;
using System.Net.Http.Json;
using FinCommon.DTO;
using FinCommon.Models;
using FinServer.AdditionalClasses;
using FinServer.DbModels;
using FinServer.Enum;

namespace FinancialApp.Forms
{
    public partial class OperationSearch : Form
    {
        private readonly Guid _id;
        private List<DbHistoryTransfer> _historyOperation;

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

            var response = await httpClient.PostAsync(ServerConst.URL + $"OperationHistory/SearchUserOperation", ServerToBody.ToBody(dto));

            var result = await response.Content.ReadFromJsonAsync<FilteredUserTransactionHistoryDTO>();

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
                operationHistory.Text = "История операций";
                foreach (var transferItem in result.HistoryTransfers)
                {
                    operationHistory.Text +=
                        $"\n{transferItem.DateOperation} {transferItem.SendersName} {transferItem.TypeAction} {transferItem.Money} {transferItem.CurrencyType} {transferItem.RecipientsName}";
                }
                this.AutoSize = true;
            }


            //var operationSearch = _context.HistoryTransfers.Where(h => h.SenderId == _id || h.RecipientId == _id).ToList();

            //if (operationSearch.Count == 0)
            //{
            //    operationHistory.Text = "История операций";
            //    operationHistory.Text += $"\nУ Вас еще небыло операций!";
            //    return;
            //}
            //else
            //{
            //    _historyOperation = EventSearch.GetEventSearch(_db, operationSearch, startingDateSearch, endDateSearch, currencyTypeValue, personRecipientName, _context);
            //}

            //if (_historyOperation == null)
            //{
            //    operationHistory.Text = "История операций";
            //    operationHistory.Text += $"\nОпераций с пользователем {personRecipientName} не найдены!";
            //    return;
            //}
            //else
            //{
            //    if (_historyOperation.Count == 0)
            //    {
            //        operationHistory.Text = "История операций";
            //        operationHistory.Text += $"\n{DateOnly.FromDateTime(startingDateSearch)} небыло произведено операций!";
            //        return;
            //    }

            //    if (_historyOperation == null) return;
            //    operationHistory.Text = "История операций";
            //    PrintEvent(_historyOperation);
            //}
        }

        //private void PrintEvent(List<DbHistoryTransfer> historyOperation)
        //{

        //    if (historyOperation.Count == 0)
        //    {
        //        operationHistory.Text += $"\nЕще небыло произведено операций";
        //        return;
        //    }
        //    else
        //    {
        //        foreach (var transferItem in historyOperation)
        //        {
        //            var personSender = _context.Persons.First(p => p.Id == transferItem.SenderId);
        //            var personRecipient = _context.Persons.FirstOrDefault(p => p.Id == transferItem.RecipientId);

        //            operationHistory.Text += transferItem.OperationType switch
        //            {
        //                TypeOfOperation.refill => $"\n{personSender.Name} {transferItem.DateTime} произвел {TypeOperation.GetTypeOfOperation(TypeOfOperation.refill)}  {transferItem.Type} на {transferItem.MoneyTransfer}",
        //                TypeOfOperation.moneyTransfer => $"\n{personSender.Name} {transferItem.DateTime} произвел {TypeOperation.GetTypeOfOperation(TypeOfOperation.moneyTransfer)}  {transferItem.MoneyTransfer} {transferItem.Type} {personRecipient.Name}",
        //                TypeOfOperation.exchange => $"\n{personSender.Name} {transferItem.DateTime} произвел {TypeOperation.GetTypeOfOperation(TypeOfOperation.exchange)}  {transferItem.Type} на {transferItem.MoneyTransfer}",
        //                _ => throw new ArgumentOutOfRangeException(),
        //            };
        //        }
        //    }
        //}

        private void HistoryOperationExcel_Click(object sender, EventArgs e)
        {
            //var newExcel = new DataOutputInExcel(_db, _context);
            //newExcel.GetDataOutputInExcel(_historyOperation);
        }
    }
}
