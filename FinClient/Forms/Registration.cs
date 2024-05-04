using FinClient.GeneralMethodsClient;
using FinCommon.DTO;
using FinCommon.Models;
using FinServer.AdditionalClasses;
using System.Net.Http.Json;

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
            errorAge.Visible = false;
            errorPhoneNumber.Visible = false;
            errorEmail.Visible = false;
            errorLogin.Visible = false;
            errorPassword.Visible = false;
            errorSurname.Visible = false;
            errorName.Visible = false;

            var ageValue = int.TryParse(ageInput.Text, out var ageInt);
            if (!ageValue)
            {
                errorAge.Visible = true;
                errorAge.Text = @"В поле ""Возраст"" должно быть введено число и оно не может быть пустым.";
                this.AutoSize = true;
            }
            var phoneNumberValue = int.TryParse(phoneInput.Text, out var phoneNumberInt);
            if (!phoneNumberValue)
            {
                errorPhoneNumber.Visible = true;
                errorPhoneNumber.Text = @"В поле ""Номер телефона"" должно быть введено число и оно не может быть пустым.";
                this.AutoSize = true;
            }

            if (ageValue && phoneNumberValue)
            {
                var dto = new UserDataDTO()
                {
                    Name = name.Text,
                    Surname = surnameInput.Text,
                    Age = ageInt,
                    City = cityInput.Text,
                    Address = adressInput.Text,
                    PhoneNumber = phoneNumberInt,
                    EmailAddress = emailInput.Text,
                    Login = loginInput.Text,
                    Password = passwordInput.Text,
                };

                using var httpClient = new HttpClient();
                var response = await httpClient.PostAsync(ServerConst.URL + "Person/Registration", ServerToBody.ToBody(dto));

                var validationResult = await response.Content.ReadFromJsonAsync<ValidationRegistrationResultDTO>();

                if (validationResult.Status == 400 || !validationResult.IsSuccess)
                {
                    var formDataClient = new FormUsersPersonalDataClient
                    {
                        ErrorName = errorName,
                        ErrorSurname = errorSurname,
                        ErrorAge = errorAge,
                        ErrorPhoneNumber = errorPhoneNumber,
                        ErrorEmail = errorEmail,
                        ErrorLogin = errorLogin,
                        ErrorPassword = errorPassword,
                    };
                    CommonMethodClient.ShowErrorsPersonData(formDataClient, validationResult);
                    this.AutoSize = true;
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