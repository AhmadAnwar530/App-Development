using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using NoWaste.Domain.Models.Aggregates;
using NoWaste.Domain.Models.Common;

using Rg.Plugins.Popup.Services;

using Xamarin.Forms;

namespace NoWaste.ViewModels.Categories
{
    public class AddCategoryViewModel : ObservableObject
    {
        string _name ;
        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

    bool _isDeleteShow;
    public bool IsDeleteShow
    {
      get => _isDeleteShow;
      set => SetProperty(ref _isDeleteShow, value);
    }

    string _saveEditText = "Save";
        public string SaveEditText
        {
            get => _saveEditText;
            set => SetProperty(ref _saveEditText, value);
        }

        public Category category;
        public Command SaveCommand { get; set; }
        public Command DeleteCommand { get; set; }
        public Command CancelCommand { get; set; }
        public Action<Category> CategoryAddedOrUpdated;
        public Action CategoryDeleted;
        List<Category> AllCategories;
        public AddCategoryViewModel()
        {
            SaveCommand = new Command(async () => await SaveCommandRun());
            DeleteCommand = new Command(async () => await DeleteCommandRun());
            CancelCommand = new Command(async () => await CancelCommandRun());
            AllCategories = App._categoryRepository.GetAllCategories().ToList();
        }

        async Task SaveCommandRun()
        {
            if(string.IsNullOrWhiteSpace(Name))
            {
                await Application.Current.MainPage.DisplayAlert("", "Please enter category name", "OK");
                return;
            }

            if (AllCategories.FirstOrDefault((x)=>x.Name.ToLower()==Name.ToLower())!=null)
            {
                await Application.Current.MainPage.DisplayAlert("", "This category is already added", "OK");
                return;
            }
            if(category==null)
            {
                category = new Category { Name = Name };
                App._categoryRepository.AddUpdateCategory(category);
            }
            else
            {
                UpdateItemCategories(category.Name, Name);
                category.Name = Name;
                App._categoryRepository.AddUpdateCategory(category);
            }
            CategoryAddedOrUpdated?.Invoke(category);
            await CancelCommandRun();
        }



        async Task DeleteCommandRun()
        {
            App._categoryRepository.DelteCategory(category);
            DeleteItemCategories(category.Name);
            CategoryDeleted?.Invoke();
            await CancelCommandRun();
        }

        async Task CancelCommandRun()
        {
            await PopupNavigation.Instance.PopAsync();
        }

        void DeleteItemCategories(string oldName)
        {
            var itemsToUpdate = App._itemRepository.GetAllItems().Where((x) => x.CategoryName == oldName);
            foreach (var item in itemsToUpdate)
            {
                item.CategoryName = "General";
                App._itemRepository.AddUpdateItem(item);
            }
        }

        void UpdateItemCategories(string oldName, string NewName)
        {
            var itemsToUpdate = App._itemRepository.GetAllItems().Where((x) => x.CategoryName == oldName);
            foreach(var item in itemsToUpdate)
            {
                item.CategoryName = NewName;
                App._itemRepository.AddUpdateItem(item);
            }
        }
    }
}
