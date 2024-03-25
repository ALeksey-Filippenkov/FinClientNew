namespace FinClient.Forms
{
    public partial class Registration : Form
    {
        public Registration()
        {
            InitializeComponent();
        }

        private async void AddButton_Click(object sender, EventArgs e)
        {
            var dto = new UserDataDTO()
            {
                Name = name.Text,
                Surname = surnameInput.Text,
                Age = ageInput.Text,
                City = cityInput.Text,
                Address = adressInput.Text,
                PhoneNumber = phoneInput.Text,
                EmailAddress = emailInput.Text,
                Login = loginInput.Text,
                Password = passwordInput.Text,
                IsBanned = false
            };

            using var httpClient = new HttpClient();
            var response = await httpClient.PostAsync(ServerConst.URL + "Person/Registration", ServerToBody.ToBody(dto));

            var validationResult = await response.Content.ReadFromJsonAsync<ValidationRegistrationResultDTO>();

            if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                this.AutoSize = true;

                if (validationResult.Errors.ContainsKey("Name"))
                {
                    errorAge.Visible = true;
                    foreach (var item in validationResult.Errors["Name"])
                    {
                        errorName.Text = $"{item}\n\n";
                    }
                }

                if (validationResult.Errors.ContainsKey("Surname"))
                {
                    errorAge.Visible = true;
                    foreach (var item in validationResult.Errors["Surname"])
                    {
                        errorSurname.Text = $"{item}\n\n";
                    }
                }

                if (validationResult.Errors.ContainsKey("Age"))
                {
                    errorAge.Visible = true;
                    foreach (var item in validationResult.Errors["Age"])
                    {
                        errorAge.Text = $"{item}\n\n";
                    }
                }

                if (validationResult.Errors.ContainsKey("PhoneNumber"))
                {
                    errorPhoneNumber.Visible = true;
                    foreach (var item in validationResult.Errors["PhoneNumber"])
                    {
                        errorPhoneNumber.Text = $"{item}\n\n";
                    }
                }

                if (validationResult.Errors.ContainsKey("EmailAddress"))
                {
                    errorEmail.Visible = true;
                    foreach (var item in validationResult.Errors["EmailAddress"])
                    {
                        errorPhoneNumber.Text = $"{item}\n\n";
                    }
                }

                if (validationResult.Errors.ContainsKey("Login"))
                {
                    errorLogin.Visible = true;
                    foreach (var item in validationResult.Errors["Login"])
                    {
                        errorLogin.Text = $"{item}\n\n";
                    }
                }

                if (validationResult.Errors.ContainsKey("Password"))
                {
                    errorPassword.Visible = true;
                    foreach (var item in validationResult.Errors["Password"])
                    {
                        errorPassword.Text = $"{item}\n\n";
                    }
                }
            }
            else
            {
                if (!validationResult.IsSuccess)
                {
                    MessageBox.Show(validationResult.Message["LoginError"]);
                }
                else
                {
                    MessageBox.Show(validationResult.Message["Congratulations"]);
                    Close();
                }
            }
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
