using FinClient.AdditionalClassesClient;
using FinCommon.DTO;
using FinServer.AdditionalClasses;

namespace FinClient.GeneralMethodsClient
{
    public class CommonMethodClient
    {
        public static void ShowErrorsPersonData(FormUsersPersonalDataClient formDataClient, ValidationRegistrationResultDTO validationResult)
        {
            if (validationResult.Errors != null)
            {
                if (validationResult.Errors.ContainsKey("Name"))
                {
                    formDataClient.ErrorName.Visible = true;
                    foreach (var item in validationResult.Errors["Name"])
                    {
                        formDataClient.ErrorName.Text = $"{item}\n";
                    }
                }

                if (validationResult.Errors.ContainsKey("Surname"))
                {
                    formDataClient.ErrorSurname.Visible = true;
                    foreach (var item in validationResult.Errors["Surname"])
                    {
                        formDataClient.ErrorSurname.Text = $"{item}\n";
                    }
                }

                if (validationResult.Errors.ContainsKey("PhoneNumber"))
                {
                    formDataClient.ErrorPhoneNumber.Visible = true;
                    foreach (var item in validationResult.Errors["PhoneNumber"])
                    {
                        formDataClient.ErrorPhoneNumber.Text = $"{item}\n";
                    }
                }

                if (validationResult.Errors.ContainsKey("EmailAddress"))
                {
                    formDataClient.ErrorEmail.Visible = true;
                    foreach (var item in validationResult.Errors["EmailAddress"])
                    {
                        formDataClient.ErrorEmail.Text = $"{item}\n";
                    }
                }

                if (validationResult.Errors.ContainsKey("Login"))
                {
                    formDataClient.ErrorLogin.Visible = true;
                    foreach (var item in validationResult.Errors["Login"])
                    {
                        formDataClient.ErrorLogin.Text = $"{item}\n";
                    }
                }

                if (validationResult.Errors.ContainsKey("Password"))
                {
                    formDataClient.ErrorPassword.Visible = true;
                    foreach (var item in validationResult.Errors["Password"])
                    {
                        formDataClient.ErrorPassword.Text = $"{item}\n";
                    }
                }
            }

            if (!validationResult.IsSuccess && validationResult.Message != null)
            {
                if (validationResult.Message.ContainsKey("LoginError"))
                {
                    formDataClient.ErrorLogin.Visible = true;
                    formDataClient.ErrorLogin.Text = validationResult.Message["LoginError"];
                }

                if (validationResult.Message.ContainsKey("PhoneNumberError"))
                {
                    formDataClient.ErrorPhoneNumber.Visible = true;
                    formDataClient.ErrorPhoneNumber.Text = validationResult.Message["PhoneNumberError"];
                }
            }
        }

        public static void ShowErrorAuthorizationForm(ValidationAuthorizationResultDTO authorizationResult)
        {
            if (authorizationResult.Errors != null)
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

            if (!authorizationResult.IsSuccess && authorizationResult.Message != null)
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
        }

        public static void ShowErrorMoneyTransfer(ValidationMoneyTransferResultDTO moneyTransferResult, FormMoneyTransferClient formData)
        {
            if (moneyTransferResult.Message.ContainsKey("MoneyTransfer"))
            {
                formData.MoneyTransfer.Visible = true;
                formData.MoneyTransfer.Text = moneyTransferResult.Message["MoneyTransfer"];
            }

            if (moneyTransferResult.Message.ContainsKey("CurrencyTypeError"))
            {
                formData.CurrencyType.Visible = true;
                formData.CurrencyType.Text = moneyTransferResult.Message["CurrencyTypeError"];
            }

            if (moneyTransferResult.Message.ContainsKey("PersonSenderError"))
            {
                formData.CurrencyType.Visible = true;
                formData.CurrencyType.Text = moneyTransferResult.Message["PersonSenderError"];
            }

            if (moneyTransferResult.Message.ContainsKey("PersonRecipientError"))
            {
                formData.PhoneNumber.Visible = true;
                formData.PhoneNumber.Text = moneyTransferResult.Message["PersonRecipientError"];
            }

            if (moneyTransferResult.Message.ContainsKey("LackMoneyAccountError"))
            {
                formData.MoneyTransfer.Visible = true;
                formData.MoneyTransfer.Text = moneyTransferResult.Message["LackMoneyAccountError"];
            }
        }

        public static void ShowErrorMoneyExchange(ValidationMoneyExchangeResultDTO moneyExchangeResult,
            FormMoneyExchangeClient formData)
        {
            if (moneyExchangeResult.Message.ContainsKey("The currency type for debiting is not selected"))
            {
                formData.DebitAccountError.Visible = true;
                formData.DebitAccountError.Text = moneyExchangeResult.Message["The currency type for debiting is not selected"];
            }

            if (moneyExchangeResult.Message.ContainsKey("The type of currency to deposit is not selected"))
            {
                formData.ReplenishmentAccountError.Visible = true;
                formData.ReplenishmentAccountError.Text = moneyExchangeResult.Message["The type of currency to deposit is not selected"];
            }

            if (moneyExchangeResult.Message.ContainsKey("DebitAccount"))
            {
                formData.DebitAccountError.Visible = true;
                formData.DebitAccountError.Text = moneyExchangeResult.Message["DebitAccount"];
            }

            if (moneyExchangeResult.Message.ContainsKey("AccountForReplenishment"))
            {
                formData.ReplenishmentAccountError.Visible = true;
                formData.ReplenishmentAccountError.Text = moneyExchangeResult.Message["AccountForReplenishment"];
            }

            if (moneyExchangeResult.Message.ContainsKey("MoneyError"))
            {
                formData.MoneyExchangeError.Visible = true;
                formData.MoneyExchangeError.Text = moneyExchangeResult.Message["MoneyError"];
            }
        }
    }
}
