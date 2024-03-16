using FinCommon.DTO;
using FinCommon.Models;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

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
                Adress = adressInput.Text,
                PhoneNumber = phoneInput.Text,
                EmailAdress = emailInput.Text,
                Login = loginInput.Text,
                Password = passwordInput.Text,
                IsBanned = false
            };

            using var httpClient = new HttpClient();
            var response = await httpClient.PostAsync(ServerConst.URL + "Person/Registration", ToBody(dto));

            var result = await response.Content.ReadFromJsonAsync<ResultDTO>();

            if (result.IsSuccess == false)
            {
                MessageBox.Show(result.Message);
            }
            else
            {
                MessageBox.Show("Поздравляем! Вы успешно прошли регистрацию");
                Close();
            }
        }
 
        public StringContent ToBody(object model)
        {
            return new(
                JsonSerializer.Serialize(model),
                Encoding.UTF8,
                "application/json");
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
