using ScreenTemplate.Models;
using ScreenTemplate.Views;
using SQLite;
using System;
using System.Linq.Expressions;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace ScreenTemplate.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private User user;
        private ICommand loginCommand;
        private ICommand cameraButtonCommand;
        private SQLiteConnection database;

        public LoginViewModel()
        {
            user = new User();
            loginCommand = new Command(Login);

            cameraButtonCommand = new Command(CameraButton);

            // Initialize the database connection
            database = DependencyService.Get<ISQLiteDb>().GetConnection();

            // Create the User table if it doesn't exist
            database.CreateTable<User>();

            var existingUser = database.Table<User>().FirstOrDefault(u => u.Email == "belports.com");
            if (existingUser == null)
            {
                // User does not exist, add it to the database
                var newUser1 = new User { Email = "belports.com", Password = "123" };
             
                // Insert the new users into the database
                database.Insert(newUser1);
            }
            //This accesses the table named "User" in the database and returns a collection of all the rows in that table.
            //    FirstOrDefault(u => u.Email == "belports.com"): It retrieves the first element from the collection that satisfies the condition specified within the lambda expression.
            //    In this case, it checks if the Email property of the user object is equal to "belports.com".If a matching user is found, it is assigned to the variable
            //        existingUser.Otherwise, existingUser is set to null.
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

        public ICommand CameraButtonCommand => cameraButtonCommand;

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


        private void CameraButton()
        {
            try
            {
                Application.Current.MainPage.Navigation.PushAsync(new CameraPage());
            }
            catch (Exception ex)
            {
                // Handle the exception (e.g., display an error message)
                Application.Current.MainPage.DisplayAlert("Error", "An error occurred: " + ex.Message, "OK");
            }
        }


    }
}
