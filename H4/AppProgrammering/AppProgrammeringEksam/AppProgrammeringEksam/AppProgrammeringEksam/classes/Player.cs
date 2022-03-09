using System;
using System.Collections.Generic;
using System.Text;

namespace AppProgrammeringEksam
{
    public class Player
    {
        public string name;
        public double damage;
        public double critChance;
        public double critDamage;
        public long gold;
        public double goldMultiplier;
        public double bonusGoldChance;
        public List<Item> statItems = new List<Item>();
        public List<Item> buffItems = new List<Item>();

        public Player(string name)
        {
            this.name = name;
            this.damage = 1;
            this.critChance = 0;
            this.critDamage = 1.5;
            this.gold = 1000000000;
            this.goldMultiplier = 1;
            this.bonusGoldChance = 0;
        }

        public void AddStatItemToInventory(Item item)
        {
            statItems.Add(item);
            gold -= item.cost;
            item.statEffect.effect();
        }

        public void AddBuffItemToInventory(Item item)
        {
            statItems.Add(item);
            gold -= item.cost;
            item.statEffect.effect();
        }
    }
}
