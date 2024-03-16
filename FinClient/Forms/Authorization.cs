using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using FinancialApp.Forms;
using FinCommon.DTO;
using FinCommon.Models;

namespace FinClient.Forms
{
    public partial class Authorization : Form
    {
        public Authorization()
        {
            InitializeComponent();
        }

        private async void EnterButton_Click(object sender, EventArgs e)
        {
            var dto = new LoginDTO()
            {
                Login = loginInput.Text,
                Password = passwordInput.Text,
            };
            using var httpClient = new HttpClient();
            var response = await httpClient.PostAsync(ServerConst.URL + "Person/Login", ToBody(dto));

            var result = await response.Content.ReadFromJsonAsync<ResultDTO>();

            if (result.IsSuccess == false)
            {
                MessageBox.Show(result.Message);
                return;
            }

            var usersPersonalAccount = new UsersPersonalAccount(result.idAccount, this);
            usersPersonalAccount.Show();

            Hide();
        }

        public StringContent ToBody(object model)
        {
            return new(
                JsonSerializer.Serialize(model),
                Encoding.UTF8,
                "application/json");
        }

        private void RegistrationButton_Click(object sender, EventArgs e)
        {
          var registration = new Registration();
          registration.Show();
        }
    }
}