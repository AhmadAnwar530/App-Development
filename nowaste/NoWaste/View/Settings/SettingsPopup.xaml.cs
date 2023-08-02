using System;
using System.Collections.Generic;
using NoWaste.ViewModels.Settings;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;

namespace NoWaste.View.Settings
{
    public partial class SettingsPopup : PopupPage
    {
        SettingsViewModel VM;
        public Action<bool> SettingChanged;
        public SettingsPopup()
        {
            VM = new SettingsViewModel();
            InitializeComponent();
            BindingContext = VM;
            VM.HideExpiryChanged+= () =>{ SettingChanged?.Invoke(false); };
            VM.PriceChanged += () => { SettingChanged?.Invoke(false); };
            VM.DatePurchaseChanged += () => { SettingChanged?.Invoke(false); };
        }

        void TapGestureRecognizer_Tapped(System.Object sender, System.EventArgs e)
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
