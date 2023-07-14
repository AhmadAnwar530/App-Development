//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Runtime.CompilerServices;
//using System.Text;
//using System.Windows.Input;
//using Xamarin.Essentials;
//using Xamarin.Forms;

//namespace ScreenTemplate.ViewModels
//{
//    public class FingerprintViewModel : INotifyPropertyChanged
//    {
//        private ICommand scanFingerprintCommand;

//        public ICommand ScanFingerprintCommand
//        {
//            get { return scanFingerprintCommand; }
//            set
//            {
//                scanFingerprintCommand = value;
//                OnPropertyChanged(nameof(ScanFingerprintCommand));
//            }
//        }

//        public FingerprintViewModel()
//        {
//            ScanFingerprintCommand = new Command(ScanFingerprint);
//        }

//        private async void ScanFingerprint()
//        {
//            try
//            {
//                // Check if fingerprint authentication is available on the device
//                if (DeviceSecurity.IsSupported && await DeviceSecurity.IsAvailableAsync())
//                {
//                    // Request fingerprint authentication
//                    var authResult = await SecureStorage.RequestAsync(new SecureStorageRequestOptions
//                    {
//                        AuthenticationMode = SecureAuthenticationMode.Biometric,
//                        Title = "Authenticate using fingerprint"
//                    });

//                    // Check the authentication result
//                    if (authResult == SecureStorageRequestResult.Unlocked)
//                    {
//                        // Fingerprint authentication successful
//                        // Navigate to the new page
//                        await Application.Current.MainPage.Navigation.PushAsync(new NewPage());
//                    }
//                    else
//                    {
//                        // Fingerprint authentication failed or was canceled
//                        await Application.Current.MainPage.DisplayAlert("Failure", "Fingerprint authentication failed or was canceled.", "OK");
//                    }
//                }
//                else
//                {
//                    // Fingerprint authentication not available
//                    await Application.Current.MainPage.DisplayAlert("Not Supported", "Fingerprint authentication is not supported on this device.", "OK");
//                }
//            }
//            catch (Exception ex)
//            {
//                // Handle any errors
//                await Application.Current.MainPage.DisplayAlert("Error", $"An error occurred: {ex.Message}", "OK");
//            }
//        }

//        // INotifyPropertyChanged implementation
//        public event PropertyChangedEventHandler PropertyChanged;

//        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
//        {
//            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
//        }
//    }

//}
