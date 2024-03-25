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

            if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                if (authorizationResult.Errors.ContainsKey("Login"))
                {
                    foreach (var item in authorizationResult.Errors["Login"])
                    {
                        MessageBox.Show($"{item}");
                    }
                }

                if (authorizationResult.Errors.ContainsKey("Password"))
                {
                    foreach (var item in authorizationResult.Errors["Password"])
                    {
                        MessageBox.Show($"{item}");
                    }
                }
            }
            if (!authorizationResult.IsSuccess)
            {
                if (authorizationResult.Message.ContainsKey("SearchUserError"))
                {
                    MessageBox.Show($"{authorizationResult.Message["SearchUserError"]}");
                }

                if (authorizationResult.Message.ContainsKey("PasswordError"))
                {
                    MessageBox.Show($"{authorizationResult.Message["PasswordError"]}");
                }

                if (authorizationResult.Message.ContainsKey("UserIsBannedError"))
                {
                    MessageBox.Show($"{authorizationResult.Message["UserIsBannedError"]}");
                }
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