using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG
{
    class Player
    {
        public String name;

        int health;
        int maxHealth;

        int damage;
        public int money = 600;

        public Player()
        {
            maxHealth = 500;
            health = maxHealth;
            money = 600;
            damage = 150;
        }

        public int attack()
        {
            return damage;
        }

        public void upgradeH()
        {
            maxHealth += maxHealth / 4;
            health = maxHealth;
        }

        public void upgradeD()
        {
            damage += damage / 5;
        }

        public int getHealth()
        {
            return health;
        }

        public void heal(int h)
        {
            health += h;
            if (health > maxHealth)
            {
                health = maxHealth;
            }
        }
    }
}
