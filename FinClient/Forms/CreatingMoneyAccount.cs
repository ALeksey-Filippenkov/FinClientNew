namespace FinancialApp.Forms
{
    public partial class CreatingMoneyAccount : Form
    {
        private readonly Guid _id;

        public CreatingMoneyAccount(Guid id)
        {
            InitializeComponent();
            _id = id;
        }

        private async void CreatingCashAccount_Click(object sender, EventArgs e)
        {
            var dto = new CurrencyNumberIndexDTO()
            {
               Index = listBox1.SelectedIndex,
               PersonId = _id
            };

            using var httpClient = new HttpClient();
            var response = await httpClient.PostAsync(ServerConst.URL + "PersonMoney/CreatingCashAccount", ServerToBody.ToBody(dto));
            var result = await response.Content.ReadFromJsonAsync<ValidationCreatingMoneyAccountDTO>();

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
        
        private void Exit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
