using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;
using ScreenTemplate.Views;
using ScreenTemplate.Models;
using ScreenTemplate.Models.ScreenTemplate.Data;
using ScreenTemplate.ViewModels;
using SQLite;
using System;

namespace ScreenTemplate.ViewModels
{
    public class UserPageViewModel : INotifyPropertyChanged
    {
        private string email;
        private string password;
        private SQLiteConnection database;

        public string Email
        {
            get { return email; }
            set
            {
                if (email != value)
                {
                    email = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Password
        {
            get { return password; }
            set
            {
                if (password != value)
                {
                    password = value;
                    OnPropertyChanged();
                }
            }
        }

        public ICommand ProfileCommand { get; private set; }
        public ICommand ToDoListCommand { get; private set; }

        public UserPageViewModel()
        {
            ProfileCommand = new Command(ProfilePage);
            ToDoListCommand = new Command(ToDoList);
            // Initialize the database connection
            database = DependencyService.Get<ISQLiteDb>().GetConnection();

            LoadUserData();
        }

        private void ProfilePage()
        {
            Application.Current.MainPage.Navigation.PushAsync(new Profile());
        }

        private void ToDoList()
        {
            Application.Current.MainPage.Navigation.PushAsync(new ToDoList());
        }

        private void LoadUserData()
        {
            try
            {
                // Retrieve the user data from the database
                var user = database.Table<User>().FirstOrDefault();

                if (user != null)
                {
                    // Set the email and password properties with the retrieved data
                    Email = user.Email;
                    Password = user.Password;
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occur during database operations
                Console.WriteLine($"Error loading user data: {ex.Message}");
                // You can display an error message or take other appropriate actions here
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
