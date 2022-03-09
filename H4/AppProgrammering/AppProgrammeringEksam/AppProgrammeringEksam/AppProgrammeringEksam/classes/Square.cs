using System;
using System.Collections.Generic;
using System.Text;

namespace AppProgrammeringEksam
{
    public class Square
    {
        public string name;
        public double health;
        public int goldOnDeath;

        public Square(string name, double health, int goldOnDeath)
        {
            this.name = name;
            this.health = health;
            this.goldOnDeath = goldOnDeath;
        }
    }
}
