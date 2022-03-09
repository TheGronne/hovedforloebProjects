using System;
using System.Collections.Generic;
using System.Text;

namespace AppProgrammeringEksam
{
    public class StatEffect
    {
        List<Delegate> functions = new List<Delegate>();
        public Action effect;
        public Player player;
        public int itemLevel;

        public StatEffect(Player player, int effectID)
        {
            this.functions.Add((Action)BonusDamage);
            this.functions.Add((Action)BonusCritChance);
            this.functions.Add((Action)BonusCritDamage);
            this.functions.Add((Action)BonusGold);
            this.functions.Add((Action)BonusGoldChance);
            this.player = player;
            this.effect = (Action)this.functions[effectID];
            this.itemLevel = 1;
        }

        public void BonusDamage()
        {
            player.damage += 1 * itemLevel;
        }

        public void BonusCritChance()
        {
            player.critChance += 0.5 * itemLevel;
        }

        public void BonusCritDamage()
        {
            player.critDamage += 2 * itemLevel;
        }

        public void BonusGold()
        {
            player.goldMultiplier += 1 * itemLevel;
        }

        public void BonusGoldChance()
        {
            player.bonusGoldChance += 0.5 * itemLevel;
        }
    }
}
