using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.ComponentModel;

namespace AppProgrammeringEksam
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Inventory : ContentPage, INotifyPropertyChanged
    {
        private ObservableCollection<Item> liste = new ObservableCollection<Item>();
        public ObservableCollection<Item> itemsource { get { return liste; } }
        public int selectedItem;
        public string Gold
        {
            get => App.viewmodel.Gold;
            set
            {
                App.viewmodel.Gold = value;
                OnPropertyChanged(nameof(Gold));
            }
        }

        public Inventory()
        {
            InitializeComponent();
            BindingContext = this;
        }

        private void UpgradeItem(object sender, EventArgs e)
        {
            if (App.player.gold >= itemsource[selectedItem].cost)
            {
                App.player.gold -= itemsource[selectedItem].cost;
                itemsource[selectedItem].Upgrade();
                App.viewmodel.Update();
                itemsource[selectedItem] = itemsource[selectedItem];
            }
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            selectedItem = e.SelectedItemIndex;
        }

        public void UpdateInventory(Item item)
        {
            itemsource.Add(item);
        }

        public void UpdateGold()
        {
            OnPropertyChanged("Gold");
        }
    }
}