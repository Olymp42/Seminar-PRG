using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace classes
{
    internal class Enemy
    {
         int healthBase;
        int health;
        int damage;
         int damageBase;
         int level;
        Random rnd;

        public Enemy (int healthBase, int damageBase, int level)
        {
            this.healthBase = healthBase;
            health = healthBase * level;

            this.damageBase = damageBase;
            damage = damageBase * level;

            this.level = level;
            rnd = new Random();
        }
        public int Hurt(int amaount)
        {
            health -= amaount;
            Console.WriteLine("Enemy got hit for: " + amaount + " damage" );
            if(health<=0)
            {
                Console.WriteLine("Enemy is death");
            }
            return health;
        }
        public int GetHealth() {return health;}
        public int GetDamage() { return damage; }

        public int GetRandomizedDamage()
        {
            return rnd.Next(damage / 2, damage + 1);
        }
        public bool IsDead()
        {
            return health <= 0;
        }
    }
}
