using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;
using NoWaste.View.Popup;

namespace NoWaste.ViewModels.Categories
{
    public class ExpiryPopupViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<string> Expiry { get; set; }

        private bool isSelectAllChecked;
        public bool IsSelectAllChecked
        {
            get => isSelectAllChecked;
            set
            {
                isSelectAllChecked = value;

                IsOneDayAgoChecked = value;
                IsTodayChecked = value;
                IsTomorrowChecked = value;
                OnPropertyChanged(nameof(IsOneDayAgoChecked));
                OnPropertyChanged(nameof(IsTodayChecked));
                OnPropertyChanged(nameof(IsTomorrowChecked));
            }
        }

        public ICommand ApplyCommand { get; set; }
        public List<string> selectedExpiry { get; set; }

        // You should bind these properties to each CheckBox's IsChecked property
        public bool IsOneDayAgoChecked { get; set; }
        public bool IsTodayChecked { get; set; }
        public bool IsTomorrowChecked { get; set; }

        public ExpiryPopupViewModel()
        {
            ApplyCommand = new Command(Apply);
            Expiry = new ObservableCollection<string> { "1 Day Ago", "Today", "Tomorrow" };
        }

        private void Apply()
        {
            selectedExpiry = new List<string>();

            if (IsOneDayAgoChecked)
                selectedExpiry.Add("1 Day Ago");
            if (IsTodayChecked)
                selectedExpiry.Add("Today");
            if (IsTomorrowChecked)
                selectedExpiry.Add("Tomorrow");

            OnApply?.Invoke(selectedExpiry);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public event Action<List<string>> OnApply;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


    }
}
