using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Nightmare
{
    public class StatsComponent
    {
        public int Health { get; private set; }
        public int Atk { get; private set; }
        public int Def { get; private set; }
        public int Speed { get; private set;  }

        public StatsComponent(int health, int atk, int def, int speed)
        {
            Health = health;
            Atk = atk;
            Def = def;
            Speed = speed;
        }

        public void TakeDamage(int damage)
        {
            int actualDamage = Math.Max(damage - Def, 0);
            Health -= actualDamage;
            if (Health < 0)
            {
                Health = 0;
            }
        }
    }
}
