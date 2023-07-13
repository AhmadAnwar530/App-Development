using ScreenTemplate.Views;
using System.Windows.Input;
using ScreenTemplate.Models;
using Xamarin.Forms;
using System;

namespace ScreenTemplate.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private User user;
        private ICommand loginCommand;

        //Constructor
        public LoginViewModel()
        {
            user = new User();
            loginCommand = new Command(Login);
        }

        public string Email
        {
            get { return user.Email; }
            set
            {
                user.Email = value;
                OnPropertyChanged(nameof(Email));
            }
        }

        public string Password
        {
            get { return user.Password; }
            set
            {
                user.Password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        public ICommand LoginCommand => loginCommand;

        private void Login()
        {
            try
            {
                if (Email == "ahmad123@gmail.com" && Password == "123")
                {
                    UserPageViewModel userPageViewModel = new UserPageViewModel(Email, Password);

                    Application.Current.MainPage.Navigation.PushAsync(new userPage() { BindingContext = userPageViewModel });
                }
                else
                {
                    // Invalid credentials
                    Application.Current.MainPage.DisplayAlert("Login Failed", "Invalid credentials. Please try again.", "OK");
                }
            }
            catch (Exception ex)
            {
                // Handle the exception
                Application.Current.MainPage.DisplayAlert("Error", $"An error occurred: {ex.Message}", "OK");
            }
        }

    }
}
