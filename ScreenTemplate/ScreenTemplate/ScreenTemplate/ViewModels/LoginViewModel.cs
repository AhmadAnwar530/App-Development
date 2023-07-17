using ScreenTemplate.Models;
using ScreenTemplate.Models.ScreenTemplate.Data;
using ScreenTemplate.Views;
using SQLite;
using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace ScreenTemplate.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private User user;
        private ICommand loginCommand;
        private SQLiteConnection database;

        public LoginViewModel()
        {
            user = new User();
            loginCommand = new Command(Login);

            // Initialize the database connection
            database = DependencyService.Get<ISQLiteDb>().GetConnection();

            // Create the User table if it doesn't exist
            database.CreateTable<User>();

            // Check if the user already exists in the database
            //var existingUser = database.Table<User>().FirstOrDefault(u => u.Email == "belports.com");
            //if (existingUser == null)
            //{
            //    // User does not exist, add it to the database
            //    var newUser = new User { Email = "belports.com", Password = "123" };
            //    database.Insert(newUser);
            //}

            var existingUser = database.Table<User>().FirstOrDefault(u => u.Email == "belports.com");
            if (existingUser == null)
            {
                // User does not exist, add it to the database
                var newUser1 = new User { Email = "belports.com", Password = "123" };
                var newUser2 = new User { Email = "ahmad123", Password = "123" };

                // Insert the new users into the database
                database.Insert(newUser1);
                database.Insert(newUser2);
            }

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
                var retrievedUser = database.Table<User>().FirstOrDefault(u => u.Email == Email);

                if (retrievedUser != null && retrievedUser.Password == Password)
                {
                    // User credentials are valid, navigate to UserPage
                    Application.Current.MainPage.Navigation.PushAsync(new userPage());
                }
                else
                {
                    // Invalid credentials
                    Application.Current.MainPage.DisplayAlert("Login Failed", "Invalid credentials. Please try again.", "OK");
                }

                // Store the user data in the database
                var newUser = new User { Email = Email, Password = Password };
                database.InsertOrReplace(newUser);
            }
            catch (Exception ex)
            {
                // Handle the exception (e.g., display an error message)
                Application.Current.MainPage.DisplayAlert("Error", "An error occurred: " + ex.Message, "OK");
            }
        }


    }
}
