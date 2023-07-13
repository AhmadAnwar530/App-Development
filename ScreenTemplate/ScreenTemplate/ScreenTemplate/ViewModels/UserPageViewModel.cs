using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ScreenTemplate.ViewModels
{
    public class UserPageViewModel : INotifyPropertyChanged
    {
        private string email;
        private string password;

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
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
