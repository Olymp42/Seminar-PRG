using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace classes
{
    internal class Player
    {
        private int health;
        public int damage;
        public string name;
        private Random rnd;

        public Player (int health, int damage, string name)
        {
            SetHealth(health);
            this.damage = damage;
            this.name = name;
            rnd = new Random();
        }
        public Player()
        {
            health = 100;
            damage = 20;
            name = "Player";
        }
        public void SetHealth(int value)
        {
            health = value;
            if(health < 0) 
            {
                health = 0;
            }
        }
        public int GetHealth()
        {
            return health;
        }
        public int GetDamage() { return damage; }
        public int GetRandomizedDamage()
        {
            //float rondomizedDamage = damage * rnd.Next(5, 15) / 10f;
            //return (int)(rondomizedDamage);
            return rnd.Next(damage / 2, damage + damage / 2 + 1);
        }
        
        public void Hurt(int amaount)
        {
            health -= amaount;
            Console.WriteLine("Player got hit for: " + amaount + " damage");
            if (health <= 0)
            {
                Console.WriteLine("Player is death");
            }
           
        }
        public bool IsDead()
        {
            return health <= 0;
        }



    }
}
