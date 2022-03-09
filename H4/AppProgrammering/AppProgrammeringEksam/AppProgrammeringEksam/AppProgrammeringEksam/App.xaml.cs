using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppProgrammeringEksam
{
    public partial class App : Application
    {
        public static Player player = new Player("You");
        public static GoldViewModel viewmodel = new GoldViewModel();
        public static StatEffect bonusDmg = new StatEffect(player, 0);
        public static StatEffect bonusCritChnce = new StatEffect(player, 1);
        public static StatEffect bonusCritDmg = new StatEffect(player, 2);
        public static StatEffect bonusGold = new StatEffect(player, 3);
        public static StatEffect bonusGoldChance = new StatEffect(player, 4);
        public App()
        {
            InitializeComponent();
            MainPage = new TabbedPage1();
        }

        protected override void OnStart()
        {

        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
