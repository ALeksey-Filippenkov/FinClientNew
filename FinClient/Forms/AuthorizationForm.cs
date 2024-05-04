using FinancialApp.Forms;
using FinCommon.DTO;
using FinCommon.Models;
using System.Net.Http.Json;

namespace FinClient.Forms
{
    public partial class AuthorizationForm : Form
    {
        public AuthorizationForm()
        {
            InitializeComponent();
        }

        private async void EnterButton_Click(object sender, EventArgs e)
        {
            var dto = new LoginInputDataDTO()
            {
                Login = loginInput.Text,
                Password = passwordInput.Text,
            };

            using var httpClient = new HttpClient();
            var response = await httpClient.PostAsync(ServerConst.URL + "Person/Login", ServerToBody.ToBody(dto));

            var authorizationResult = await response.Content.ReadFromJsonAsync<ValidationAuthorizationResultDTO>();

            if (authorizationResult.Status == 400 || !authorizationResult.IsSuccess)
            {
                GeneralMethodsClient.CommonMethodClient.ShowErrorAuthorizationForm(authorizationResult);
            }
            else
            {
                var usersPersonalAccount = new UsersPersonalAccount(authorizationResult.idAccount, this);
                usersPersonalAccount.Show();

                Hide();
            }
        }

        private void RegistrationButton_Click(object sender, EventArgs e)
        {
            var registrationForms = new Registration();
            registrationForms.Show();
        }
    }
}