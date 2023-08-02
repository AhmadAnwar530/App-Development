using System.Windows.Input;
using Xamarin.Forms;
using ScreenTemplate.Models;
using SQLite;
using System.Collections.ObjectModel;
using System.ComponentModel;
using ScreenTemplate.Views;
using System;

namespace ScreenTemplate.ViewModels
{
    public class AddUserViewModel : BaseViewModel, INotifyPropertyChanged
    {
        // Display List of Users
        private ObservableCollection<UserData> users;
        public ObservableCollection<UserData> Users
        {
            get { return users; }
            set
            {
                users = value;
                OnPropertyChanged(nameof(Users));
            }
        }
        private string name;
        private string email;
        private string password;
        private SQLiteConnection database;
        public ICommand EditCommand { get; private set; }
        public ICommand DeleteCommand { get; private set; }

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged(nameof(Name));
            }
        }
        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                OnPropertyChanged(nameof(Email));
            }
        }

        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        public ICommand SaveCommand { get; private set; }

        public AddUserViewModel()
        {
            database = DependencyService.Get<ISQLiteDb>().GetConnection();
            SaveCommand = new Command(SaveUser);
            EditCommand = new Command<UserData>(EditUser);
            DeleteCommand = new Command<UserData>(DeleteUser);
            //RefreshUsers();
        }

        private void SaveUser()
        {
            if (string.IsNullOrWhiteSpace(Email) || string.IsNullOrWhiteSpace(Password))
            {
                Application.Current.MainPage.DisplayAlert("Invalid", "Blank or whitespace value is invalid!", "OK");
                return;
            }
            else
            {

                var user = new UserData
                {
                    Name = Name,
                    Email = Email,
                    Password = Password
                };

                database.Insert(user);

                // Reset the email and password fields
                Name = string.Empty;
                Email = string.Empty;
                Password = string.Empty;

                // Refresh the list of users
                RefreshUsers();
            }
        }
        private async void EditUser(UserData user)
        {
            // Assuming you have a separate page for editing user details
            await Application.Current.MainPage.Navigation.PushAsync(new EditUserPage(user));
        }

        private async void DeleteUser(UserData user)
        {
            bool answer = await Application.Current.MainPage.DisplayAlert("Delete User", "Are you sure you want to delete this user?", "Yes", "No");

            if (answer)
            {
                database.Delete(user);

                // Refresh the list of users
                RefreshUsers();

                // Display an alert to indicate successful deletion
                await Application.Current.MainPage.DisplayAlert("Success", "User deleted successfully", "OK");
            }
        }

        public void RefreshUsers()
        {
            Users = new ObservableCollection<UserData>(database.Table<UserData>().ToList());
            OnPropertyChanged(nameof(Users)); // Raise PropertyChanged event for the Users property
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
