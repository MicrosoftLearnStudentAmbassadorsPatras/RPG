using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG
{
    class Bandit
    {
        static Random rand = new Random();
        int health;
        int damage;
        string type;

        public Bandit()
        {
            int tempType = rand.Next() % 3;
            switch (tempType)
            {
                case 0:
                    {
                        health = 80;
                        damage = 5;
                        type = "Pickpocket";
                        break;
                    }
                case 1:
                    {
                        health = 160;
                        damage = 15;
                        type = "Burglar";
                        break;
                    }
                case 2:
                    {
                        health = 250;
                        damage = 30;
                        type = "Robber";
                        break;
                    }
            }
        }

        public int attack()
        {
            return damage;
        }

        public void takeDamage(int d)
        {
            health -= d;
        }

        public int getHealth()
        {
            return health;
        }
    }
}
