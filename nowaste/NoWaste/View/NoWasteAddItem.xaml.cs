using NoWaste.Domain.Models.Aggregates;
using NoWaste.Models;
using NoWaste.ViewModels;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;

using Xamarin.Forms;
using ZXing.Mobile;

namespace NoWaste
{
    public partial class NoWasteAddItem : ContentPage
    {

        public AddItemViewModel VM;
        bool IsNameGet;
        public NoWasteAddItem(ItemModel item = null)
        {
            InitializeComponent();
            VM = new AddItemViewModel();
            VM.DontFocusEntry += () => { IsFocusName = false; namesListView.IsVisible = false; };
            if (item != null)
            {
                VM.Item = item;
                VM.Title = "Edit Item";
                VM.UpdateSelectedCategory();
                VM.UpdateValues(true);
                VM.UpdateSaveEditText();
            }
            BindingContext = VM;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (!IsNameGet)
            {
                IsNameGet = true;
                VM.GetNames();
            }
        }

        private void Date_DateSelected(object sender, DateChangedEventArgs e)
        {
            VM.UpdateDays();
           
        }

        private void PurchaseDate_DateSelected(object sender, DateChangedEventArgs e)
        {
           
            VM.PurchaseUpdateDays();
        }

        async void OnCancelClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }



        private void SearchBar_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            namesListView.IsVisible = true;
            namesListView.BeginRefresh();

            try
            {
                var dataEmpty = VM.NamesList.Where(i => i.ToLower().Contains(e.NewTextValue.ToLower()));

                if (string.IsNullOrWhiteSpace(e.NewTextValue))
                    namesListView.IsVisible = false;
                else if (dataEmpty.Max().Length == 0)
                    namesListView.IsVisible = false;
                else
                    namesListView.ItemsSource = VM.NamesList.Where(i => i.ToLower().Contains(e.NewTextValue.ToLower()));
            }
            catch (Exception)
            {
                namesListView.IsVisible = false;

            }
            namesListView.EndRefresh();

        }


        private void ListView_OnItemTapped(Object sender, ItemTappedEventArgs e)
        {
            //EmployeeListView.IsVisible = false;  

            String listsd = e.Item as string;
            VM.Item.Name = listsd;
            IsFocusName = false;
            VM.UpdateItemWithFoundValues(listsd);
            namesListView.IsVisible = false;

            ((ListView)sender).SelectedItem = null;
        }

        bool IsFocusName = true;

        void Picker_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
            if (VM.SelectedCategory == null)
                return;
            if (VM.AllItems != null)
            {
                VM.NamesList.Clear();
                if (VM.SelectedCategory.Name != "Unsorted")
                {
                    foreach (var item in VM.AllItems.FindAll((x) => x.CategoryName == VM.SelectedCategory.Name))
                    {
                        if (!string.IsNullOrEmpty(item.Name) && !VM.NamesList.Contains(item.Name))
                            VM.NamesList.Add(item.Name);
                    }
                }
                else
                {
                    foreach (var item in VM.AllItems)
                    {
                        if (!string.IsNullOrEmpty(item.Name) && !VM.NamesList.Contains(item.Name))
                            VM.NamesList.Add(item.Name);
                    }
                }
                if (string.IsNullOrWhiteSpace(VM.Item.Name))
                {
                    namesListView.ItemsSource = VM.NamesList;
                    namesListView.IsVisible = VM.NamesList.Count > 0;
                }
                else
                {
                    try
                    {
                        var dataEmpty = VM.NamesList.Where(i => i.ToLower().Contains(VM.Item.Name.ToLower()));

                        if (string.IsNullOrWhiteSpace(VM.Item.Name))
                            namesListView.IsVisible = false;
                        else if (dataEmpty.Max().Length == 0)
                            namesListView.IsVisible = false;
                        else
                            namesListView.ItemsSource = VM.NamesList.Where(i => i.ToLower().Contains(VM.Item.Name.ToLower()));
                    }
                    catch (Exception )
                    {
                        namesListView.IsVisible = false;

                    }
                }

            }
            if (IsFocusName)
                NameEntry.Focus();
            else
                IsFocusName = true;
        }
    }
}