using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppProgrammeringEksam
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Main : ContentPage
    {
        public double HP {get; set;}
        public Color SquareColour { get; set; }
        public Square square = new Square("Silly Slime", 10, 1);
        public string SquareImage { get; set; }
        public int squareNumber = 1;
        public bool isBoss = false;
        public int level { get; set; }
        public string Gold
        {
            get => App.viewmodel.Gold;
            set
            {
                App.viewmodel.Gold = value;
                OnPropertyChanged(nameof(Gold));
            }
        }
        public string Damage { get; set; }
        public string CritChance { get; set; }
        public string CritDamage { get; set; }
        public string GoldMultiplier { get; set; }
        public string GoldChance { get; set; }
        public string ItemCosts { get; set; }
        public List<string> sources = new List<string>
        {
            "wtf.png",
            "damn.png",
            "lol.png",
            "yo.png"
        };
        public List<Color> colours = new List<Color>()
        {
            Color.SaddleBrown,
            Color.CadetBlue,
            Color.DarkSeaGreen,
            Color.DimGray
        };
        public Main()
        {
            InitializeComponent();
            BindingContext = this;
            SquareImage = "wtf.png";
            level = 1;
            HP = 1;
            UpdateProperties();
        }

        private void Tapped(object sender, EventArgs e)
        {
            double damage = App.player.damage / square.health;
            double health = HP - 0.00000001;
            Random random = new Random();
            int crit = random.Next(1, 202) / 2;
            int bonusGold = random.Next(1, 202) / 2;
            if (crit <= App.player.critChance)
            {
                damage *= App.player.critDamage;
            }
            if (health <= damage)
            {
                if (bonusGold <= App.player.bonusGoldChance)
                {
                    App.player.gold += (int)Math.Round(square.goldOnDeath * App.player.goldMultiplier * 10);
                }else
                {
                    App.player.gold += (int)Math.Round(square.goldOnDeath * App.player.goldMultiplier);
                }
                level++;
                App.viewmodel.Update();
                newSquare();
            } else
            {
                HP -= damage;
            }
            UpdateProperties();
        }

        //Generates new enemy
        private void newSquare()
        {
            //Chooses random picture
            Random random = new Random();
            int image = random.Next(0, 3);
            SquareImage = sources[image];
            TabbedPage1.mainPage.BackgroundColor = colours[image];
            //Every 5th enemy is a boss
            if (squareNumber % 4 == 0)
            {
                TabbedPage1.mainPage.BackgroundColor = colours[3];
                SquareImage = sources[3];
                isBoss = true;
                square = new Square("New Slime", square.health * 5, square.goldOnDeath * 2);
            } else if(isBoss == true)
            {
                isBoss = false;
                square = new Square("New Slime", square.health - (square.health * 0.5), square.goldOnDeath);
            } else
            {
                isBoss = false;
                square = new Square("New Slime", square.health, square.goldOnDeath);
            }
            HP = 1;
            squareNumber++;
            UpdateProperties();
        }

        public void Prestige(object sender, EventArgs e)
        {
            App.player.gold += (int)Math.Round(level * 2 * App.player.goldMultiplier);
            square.goldOnDeath = 1;
            square.health = 10;
            squareNumber = 1;
            HP = 1;
            level = 0;
            App.viewmodel.Update();
            UpdateProperties();
        }
        //Updates all properties
        public void UpdateProperties()
        {
            Damage = "Tap Damage: " + App.player.damage.ToString();
            CritDamage = "Crit Multiplier: " + App.player.critDamage.ToString();
            CritChance = "Crit Chance: " + App.player.critChance.ToString();
            GoldMultiplier = "Gold Multiplier: " + App.player.goldMultiplier.ToString();
            GoldChance = "Bonus Gold Chance: " + App.player.bonusGoldChance.ToString();

            OnPropertyChanged("GoldChance");
            OnPropertyChanged("GoldMultiplier");
            OnPropertyChanged("Gold");
            OnPropertyChanged("HP");
            OnPropertyChanged("SquareImage");
            OnPropertyChanged("Damage");
            OnPropertyChanged("CritDamage");
            OnPropertyChanged("CritChance");
            OnPropertyChanged("level");
        }
    }
}