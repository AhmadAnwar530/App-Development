using System;
using System.Collections.Generic;
using NoWaste.Enums;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;

namespace NoWaste.View.Sort
{
    public partial class SortPopup : PopupPage
    {
        public Action<SortEnum> Apply;
        public SortPopup()
        {
            InitializeComponent();
            CheckCurrentOrder();
        }

        void CheckCurrentOrder()
        {
            var currentSort = (SortEnum)Util.CurrentSetting.SortOrder;
            switch(currentSort)
            {
                case SortEnum.CategoryAscending:
                    categoryCheck.IsChecked = true;
                    ascendingCheck.IsChecked = true;
                    break;
                case SortEnum.CategoryDescending:
                    categoryCheck.IsChecked = true;
                    descendingCheck.IsChecked = true;
                    break;
                case SortEnum.NameAscending:
                    nameCheck.IsChecked = true;
                    ascendingCheck.IsChecked = true;
                    break;
                case SortEnum.NameDescending:
                    nameCheck.IsChecked = true;
                    descendingCheck.IsChecked = true;
                    break;
                case SortEnum.ExpiryAscending:
                    expiryCheck.IsChecked = true;
                    ascendingCheck.IsChecked = true;
                    break;
                case SortEnum.ExpiryDescending:
                    expiryCheck.IsChecked = true;
                    descendingCheck.IsChecked = true;
                    break;
            }
        }

        void Ascending_CheckedChanged(System.Object sender, Xamarin.Forms.CheckedChangedEventArgs e)
        {
            if(e.Value)
            {
                descendingCheck.IsChecked = false;
            }
            else
            {
                if (!descendingCheck.IsChecked)
                    ascendingCheck.IsChecked = true;
            }

        }
        void Descending_CheckedChanged(System.Object sender, Xamarin.Forms.CheckedChangedEventArgs e)
        {
            if (e.Value)
            {
                ascendingCheck.IsChecked = false;
            }
            else
            {
                if (!ascendingCheck.IsChecked)
                    descendingCheck.IsChecked = true;
            }
        }

        void Name_CheckedChanged(System.Object sender, Xamarin.Forms.CheckedChangedEventArgs e)
        {
            if (e.Value)
            {
                categoryCheck.IsChecked = false;
                expiryCheck.IsChecked = false;
            }
            else
            {
                if (!categoryCheck.IsChecked && !expiryCheck.IsChecked)
                    nameCheck.IsChecked = true;
            }
        }

        void Category_CheckedChanged(System.Object sender, Xamarin.Forms.CheckedChangedEventArgs e)
        {
            if (e.Value)
            {
                nameCheck.IsChecked = false;
                expiryCheck.IsChecked = false;
            }
            else
            {
                if (!nameCheck.IsChecked && !expiryCheck.IsChecked)
                    categoryCheck.IsChecked = true;
            }
        }

        void Expiry_CheckedChanged(System.Object sender, Xamarin.Forms.CheckedChangedEventArgs e)
        {
            if (e.Value)
            {
                categoryCheck.IsChecked = false;
                nameCheck.IsChecked = false;
            }
            else
            {
                if (!categoryCheck.IsChecked && !nameCheck.IsChecked)
                    expiryCheck.IsChecked = true;
            }
        }

        void Apply_Clicked(System.Object sender, System.EventArgs e)
        {
            if(ascendingCheck.IsChecked)
            {
                if (nameCheck.IsChecked)
                    Apply?.Invoke(SortEnum.NameAscending);
                if (categoryCheck.IsChecked)
                    Apply?.Invoke(SortEnum.CategoryAscending);
                if (expiryCheck.IsChecked)
                    Apply?.Invoke(SortEnum.ExpiryAscending);
            }
            else
            {
                if (nameCheck.IsChecked)
                    Apply?.Invoke(SortEnum.NameDescending);
                if (categoryCheck.IsChecked)
                    Apply?.Invoke(SortEnum.CategoryDescending);
                if (expiryCheck.IsChecked)
                    Apply?.Invoke(SortEnum.ExpiryDescending);
            }
            ClosePopup();

        }

        void Cancel_Clicked(System.Object sender, System.EventArgs e)
        {
            ClosePopup();
        }

            void ClosePopup()
        {
            try
            {
                if (PopupNavigation.Instance.PopupStack.Count > 0)
                    PopupNavigation.Instance.PopAsync();
            }
            catch { }
        }
    }
}
