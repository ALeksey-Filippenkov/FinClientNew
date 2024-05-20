using FinancialApp.Forms;
using FinCommon.DTO;
using FinCommon.Models;
using FinServer.Enum;
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

            var authorizationResult = await response.Content.ReadFromJsonAsync<AuthorizationResultDTO>();

            if (authorizationResult.Status == 400 || !authorizationResult.IsSuccess)
            {
                GeneralMethodsClient.CommonMethodClient.ShowErrorAuthorizationForm(authorizationResult);
            }
            else if (authorizationResult.UserRole == RoleInTheProgram.GetUsersRoleInTheProgram(TheUsersRoleInTheProgram.User))
            {
                var usersPersonalAccount = new UsersPersonalAccount(authorizationResult.IdAccount, this);
                usersPersonalAccount.Show();

                Hide();
            }
            else if (authorizationResult.UserRole == RoleInTheProgram.GetUsersRoleInTheProgram(TheUsersRoleInTheProgram.Admin))
            {
                var isGeneralAdmin = false;
                var administratorsPersonalAccount =
                    new AdministratorsPersonalAccount(authorizationResult.IdAccount, this, isGeneralAdmin);
                administratorsPersonalAccount.Show();
            }
            else if (authorizationResult.UserRole == RoleInTheProgram.GetUsersRoleInTheProgram(TheUsersRoleInTheProgram.SuperAdmin))
            {
                var isGeneralAdmin = true;
                var administratorsPersonalAccount =
                    new AdministratorsPersonalAccount(authorizationResult.IdAccount, this, isGeneralAdmin);
                administratorsPersonalAccount.Show();
            }
        }

        private void RegistrationButton_Click(object sender, EventArgs e)
        {
            var registrationForms = new Registration();
            registrationForms.Show();
        }
    }
}