using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;
using ScreenTemplate.Models;
using SQLite;

namespace ScreenTemplate.ViewModels
{
    public class EditUserModel : BaseViewModel, INotifyPropertyChanged
    {
        private string email;
        private string password;
        private SQLiteConnection database;
        private User user;

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

        public ICommand SaveChangesCommand { get; private set; }
        public ICommand CancelCommand { get; private set; }

        public EditUserModel(User user)
        {
            database = DependencyService.Get<ISQLiteDb>().GetConnection();
            this.user = user;

            // Set the initial email and password values
            Email = user.Email;
            Password = user.Password;

            SaveChangesCommand = new Command(SaveChanges);
            CancelCommand = new Command(Cancel);
        }

        private void SaveChanges()
        {
            if (string.IsNullOrWhiteSpace(Email) || string.IsNullOrWhiteSpace(Password))
            {
                Application.Current.MainPage.DisplayAlert("Invalid", "Blank or whitespace value is invalid!", "OK");
                return;
            }

            // Update the user data
            user.Email = Email;
            user.Password = Password;

            // Implement the logic to update the user data in the database
            database.Update(user);

            // Navigate back to the AddUserPage
            Application.Current.MainPage.Navigation.PopAsync();
        }

        private void Cancel()
        {
            // Navigate back to the AddUserPage without saving any changes
            Application.Current.MainPage.Navigation.PopAsync();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
