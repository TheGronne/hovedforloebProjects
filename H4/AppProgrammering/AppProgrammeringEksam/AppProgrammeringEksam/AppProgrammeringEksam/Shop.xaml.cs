using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppProgrammeringEksam
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Shop : ContentPage
    {
        private ObservableCollection<Item> liste = new ObservableCollection<Item>();
        public ObservableCollection<Item> itemsource { get { return liste; } }
        public int selectedItem;
        public string ShopGold
        {
            get => App.viewmodel.Gold;
            set
            {
                App.viewmodel.Gold = value;
                OnPropertyChanged(nameof(ShopGold));
            }
        }
        public Shop()
        {
            InitializeComponent();
            BindingContext = this;
            AddItems();
        }

        private void BuyItem(object sender, EventArgs e)
        {
            Inventory inventory = TabbedPage1.inventoryPage;
            if (App.player.gold >= itemsource[selectedItem].cost && itemsource[selectedItem].statItem == true)
            {
                App.player.AddStatItemToInventory(itemsource[selectedItem]);
                inventory.UpdateInventory(itemsource[selectedItem]);
                itemsource.RemoveAt(selectedItem);
                ShopGold = "Gold: " + App.player.gold.ToString();
                App.viewmodel.Update();
            } else if(App.player.gold >= itemsource[selectedItem].cost) {
                App.player.AddBuffItemToInventory(itemsource[selectedItem]);
                inventory.UpdateInventory(itemsource[selectedItem]);
                itemsource.RemoveAt(selectedItem);
                ShopGold = "Gold: " + App.player.gold.ToString();
                App.viewmodel.Update();
            }
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            selectedItem = e.SelectedItemIndex;
        }

        public void UpdateGold()
        {
            OnPropertyChanged("ShopGold");
        }

        private void AddItems()
        {
            Item item1 = new Item(10, 2, "Bonus tap dmg", App.bonusDmg, true, 1.2);
            itemsource.Add(item1);
            item1 = new Item(1, 3, "Bonus crit chance", App.bonusCritChnce, true, 1.5);
            itemsource.Add(item1);
            item1 = new Item(5, 1, "Bonus crit dmg", App.bonusCritDmg, true, 1.35);
            itemsource.Add(item1);
            item1 = new Item(20, 4, "Bonus gold", App.bonusGold, true, 2);
            itemsource.Add(item1);
            item1 = new Item(5, 1, "Bonus gold chance", App.bonusGoldChance, true, 1.25);
            itemsource.Add(item1);
        }
    }
}