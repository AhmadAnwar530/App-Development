using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;
using ScreenTemplate.Views;

namespace ScreenTemplate.ViewModels
{
    
    public class UserPageViewModel : INotifyPropertyChanged
    {
        private string email;
        private string password;
        public ICommand ProfileCommand { get; private set; }
        public ICommand ToDoListCommand { get; private set; }       

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

        public UserPageViewModel(string email, string password)
        {
            Email = email;
            Password = password;
            ProfileCommand = new Command(ProfilePage);
            ToDoListCommand = new Command(ToDoList);
        }
        private void ProfilePage()
        {
            Application.Current.MainPage.Navigation.PushAsync(new Profile());
        }

        private void ToDoList()
        {
            Application.Current.MainPage.Navigation.PushAsync(new ToDoList());
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
