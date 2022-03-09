using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppProgrammering2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Essentials : ContentPage
    {
        public string Link { get; set; }
        public string ChargeText { get; set; }
        public string Charging { get; set; }
        public string ImagePath { get; set; }
        public string SMS { get; set; }
        public Essentials()
        {
            InitializeComponent();
            BindingContext = this;
            ChargeText = (Battery.ChargeLevel * 100).ToString() + "%";
            OnPropertyChanged("ChargeText");
            Battery.BatteryInfoChanged += Battery_BatteryInfoChanged;
        }

        private async void OpenBrowser(object sender, EventArgs e)
        {
            await Browser.OpenAsync(new Uri("https://" + Link), BrowserLaunchMode.SystemPreferred);
        }

        void Battery_BatteryInfoChanged(object sender, BatteryInfoChangedEventArgs e)
        {
            ChargeText = (e.ChargeLevel * 100).ToString() + "%";
            OnPropertyChanged("ChargeText");
        }

        private void UpdateData(object sender, EventArgs e)
        {
            Charging = Battery.State.ToString();
            OnPropertyChanged("Charging");
        }

        private async void GetPicture(object sender, EventArgs e)
        {
            var pickedImage = await FilePicker.PickAsync(new PickOptions());
            ImagePath = pickedImage.FullPath;
            OnPropertyChanged("ImagePath");
        }
        private async void SendSMS(object sender, EventArgs e)
        {
            string recipient = "+1-555-521-5554";
            SmsMessage message = new SmsMessage(SMS, recipient);
            await Sms.ComposeAsync(message);
        }
    }
}