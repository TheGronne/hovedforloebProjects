using System;
using System.Collections.Generic;
using System.Text;

namespace AppProgrammeringEksam
{
    public class Item
    {
        public int cost { get; set; }
        public int level { get; set; }
        public int rarity { get; set; }
        public string description { get; set; }
        public StatEffect statEffect;
        public bool statItem;
        public double costIncrease { get; set; }

        public Item(int cost, int rarity, string description, StatEffect statEffect, bool statItem, double costIncrease)
        {
            this.cost = cost;
            this.level = 1;
            this.rarity = rarity;
            this.description = description;
            this.statEffect = statEffect;
            this.statItem = statItem;
            this.costIncrease = costIncrease;
        }

        public void Upgrade()
        {
            statEffect.effect();
            level += 1;
            cost = (int)Math.Round(cost * costIncrease) + 1;
        }
    }
}
