using FinServer.AdditionalClasses;
using FinServer.Enum;
using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel;

namespace FinClient.GeneralMethodsClient
{
    public class DataOutputInExcel
    {
        public void GetDataOutputInExcel(List<HistoryMoneyTransactions> operationHistory)
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

                var row = 2;
                const int column = 1;
 
                worksheet.Cells[1, column].Value = Headlines.GetHeadlinesTypes(HeadlinesTypes.Date);
                worksheet.Cells[1, column + 1].Value = Headlines.GetHeadlinesTypes(HeadlinesTypes.Sender);
                worksheet.Cells[1, column + 2].Value = Headlines.GetHeadlinesTypes(HeadlinesTypes.TypeOfOperation);
                worksheet.Cells[1, column + 3].Value = Headlines.GetHeadlinesTypes(HeadlinesTypes.CurrencyType);
                worksheet.Cells[1, column + 4].Value = Headlines.GetHeadlinesTypes(HeadlinesTypes.Money);
                worksheet.Cells[1, column + 5].Value = Headlines.GetHeadlinesTypes(HeadlinesTypes.Recipient);

                foreach (var transferItem in operationHistory)
                {
                    worksheet.Cells[row, column].Value = transferItem.DateOperation;
                    worksheet.Cells[row, column + 1].Value = transferItem.SendersName;
                    worksheet.Cells[row, column + 3].Value = transferItem.CurrencyType;
                    worksheet.Cells[row, column + 4].Value = transferItem.Money;
                    worksheet.Cells[row, column + 2].Value = transferItem.TypeAction;
                    worksheet.Cells[row, column + 5].Value = transferItem.RecipientsName;

                    row++;
                }

                for (var i = 1; i <= worksheet.UsedRange.Columns.Count; i++)
                {
                    worksheet.Columns[i].AutoFit();
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
    }
}

