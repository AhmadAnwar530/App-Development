using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;

namespace NoWaste.ViewModels.Categories
{
    public class CategoryPopupViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<string> Categories { get; set; }  

        private bool isSelectAllChecked;
        public bool IsSelectAllChecked
        {
            get => isSelectAllChecked;
            set
            {
                isSelectAllChecked = value;

                IsGeneralChecked = value;
                IsDairyChecked = value;
                IsFruitsVegetablesChecked = value;
                IsGrainsCerealChecked = value;
                IsBakeryChecked = value;
                IsMeatFishChecked = value;
                OnPropertyChanged(nameof(IsGeneralChecked));
                OnPropertyChanged(nameof(IsDairyChecked));
                OnPropertyChanged(nameof(IsFruitsVegetablesChecked));
                OnPropertyChanged(nameof(IsGrainsCerealChecked));
                OnPropertyChanged(nameof(IsBakeryChecked));
                OnPropertyChanged(nameof(IsMeatFishChecked));
            }
        }

        public ICommand ApplyCommand { get; set; }
        public List<string> SelectedCategories { get; set; }

        // You should bind these properties to each CheckBox's IsChecked property
        public bool IsGeneralChecked { get; set; }
        public bool IsDairyChecked { get; set; }
        public bool IsFruitsVegetablesChecked { get; set; }
        public bool IsGrainsCerealChecked { get; set; }
        public bool IsBakeryChecked { get; set; }
        public bool IsMeatFishChecked { get; set; }

        public CategoryPopupViewModel()
        {
            ApplyCommand = new Command(Apply);
            Categories = new ObservableCollection<string> { "General", "Dairy", "Fruits & Vegetables", "Grains & Cereal", "Bakery", "Meat & Fish" };
        }

        private void Apply()
        {
            SelectedCategories = new List<string>();

            if (IsGeneralChecked)
                SelectedCategories.Add("General");
            if (IsDairyChecked)
                SelectedCategories.Add("Dairy");
            if (IsFruitsVegetablesChecked)
                SelectedCategories.Add("Fruits & Vegetables");
            if (IsGrainsCerealChecked)
                SelectedCategories.Add("Grains & Cereal");
            if (IsBakeryChecked)
                SelectedCategories.Add("Bakery");
            if (IsMeatFishChecked)
                SelectedCategories.Add("Meat & Fish");

            OnApply?.Invoke(SelectedCategories);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public event Action<List<string>> OnApply;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


    }
}
