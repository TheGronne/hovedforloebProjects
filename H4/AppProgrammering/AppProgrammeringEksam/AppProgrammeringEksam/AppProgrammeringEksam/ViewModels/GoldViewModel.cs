using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using System.ComponentModel;

namespace AppProgrammeringEksam
{
    public class GoldViewModel : INotifyPropertyChanged
    {
        public string Gold { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        
        public GoldViewModel()
        {
            this.Gold = "Gold: " + App.player.gold;
            OnPropertyChanged("Gold");
        }

        public void Update()
        {
            this.Gold = "Gold: " + App.player.gold;
            OnPropertyChanged("Gold");

            Shop shop = TabbedPage1.shop;
            shop.UpdateGold();
            Inventory inventory = TabbedPage1.inventoryPage;
            inventory.UpdateGold();
            Main mainPage = TabbedPage1.mainPage;
            mainPage.UpdateProperties();
        }
        protected void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}