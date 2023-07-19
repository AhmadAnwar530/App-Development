using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;
using ScreenTemplate.Views;
using ScreenTemplate.Models;
using ScreenTemplate.ViewModels;
using SQLite;
using System;
using Xamarin.Essentials;

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

        public ICommand AddUserCommand { get; private set; }

        public UserPageViewModel()
        {
            ProfileCommand = new Command(ProfilePage);
            ToDoListCommand = new Command(ToDoList);
            AddUserCommand = new Command(AddUserPage);
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

        private void AddUserPage()
        {
            Application.Current.MainPage.Navigation.PushAsync(new AddUser());
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

            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    //public event PropertyChangedEventHandler PropertyChanged;
    //This line declares an event named PropertyChanged of a specific type called PropertyChangedEventHandler.
    //An event is a way for one part of the code to notify other parts of the code when something important happens. 
    //In this case, the event is used to notify subscribers (typically UI elements) that a property's value has changed.


    //protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    //    This is a method that is called when a property's value has changed. It is responsible for raising the PropertyChanged event. 
    //    The method has a parameter named propertyName, which represents the name of the property that has changed. 
    //By using the [CallerMemberName] attribute, we don't need to explicitly pass the property name when calling this method—it will be automatically inferred based on the calling member's name.

    //Inside the method, we check if there are any subscribers(i.e., if the PropertyChanged event is not null) using the null-conditional operator ?.. 
    //    If there are subscribers, we invoke the PropertyChanged event by passing this (the current instance of the class) and a new instance of PropertyChangedEventArgs containing the propertyName.

    //The purpose of raising the PropertyChanged event is to notify any subscribers (such as UI elements) that a specific property's value has changed. This allows them to update their visuals or perform any other
    //    necessary actions based on the new value.
}
