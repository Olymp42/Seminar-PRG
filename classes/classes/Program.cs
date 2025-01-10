using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace classes
{
    internal class Program
    {
        static void Duel(Player player, Enemy enemy)
        {
            while (!player.IsDead() && !enemy.IsDead())
            {
                enemy.Hurt(player.GetRandomizedDamage());
                if (!enemy.IsDead())
                {
                    player.Hurt(enemy.GetRandomizedDamage());
                }

                Console.WriteLine("player health: " + player.GetHealth());
                Console.WriteLine("enemy health: " + enemy.GetHealth());
                Console.WriteLine();
            }
            
        }
        static void Main(string[] args)
        {
            Player player = new Player(100, 10, "Ignác");
            Enemy enemy = new Enemy(20, 2, 1);
            Duel(player, enemy);
             Enemy enemy2 = new Enemy(20, 2, 2);
            Duel(player, enemy2);
            Console.ReadKey();
        }
    }
}
