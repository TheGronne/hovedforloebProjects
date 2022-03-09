using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppProgrammeringEksam
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TabbedPage1 : TabbedPage
    {
        public static TabbedPage pages;
        public static Inventory inventoryPage = new Inventory();
        public static Main mainPage = new Main();
        public static Shop shop = new Shop();
        public TabbedPage1()
        {
            InitializeComponent();
            pages = new TabbedPage();
            inventoryPage.Title = "Inventory";
            Children.Add(inventoryPage);
            mainPage.Title = "Main";
            Children.Add(mainPage);
            shop.Title = "Shop";
            Children.Add(shop);
        }
    }
}