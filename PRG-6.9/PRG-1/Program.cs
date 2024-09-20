using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRG_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random rng = new Random();
            for (int i = 10; i > 0; i--)
            {
                // Console.WriteLine(i);
                int a = rng.Next(100);
                if (a > 50)
                {
                    Console.WriteLine("Vetsi nez 50.");
                }
                else if( a > 25)
                {
                    Console.WriteLine("vetsi nez 25.");
                }
                else //a bude vetsi nebo rovno 50
                {
                    Console.WriteLine("Promena a byla mensi nebo rovna 25.");
                }
                Console.WriteLine(a);
            }
            bool canContinue = true;
            do
            {
                int a = rng.Next(100);
                Console.WriteLine(a);
                string userInput = Console.ReadLine();
                if (userInput == "n" || userInput == "N" || userInput == "x")// nebo ||, zaroven &&
                {
                    canContinue = false;
                    Console.WriteLine("uzivatel chce skoncit");
                }
            } while (canContinue);
            /*
            string text;
            int yesOrNO -rng.Next(100);
            if (yesOrNO > 50)
            {
                text = "yes";
            }
            else
            {
                text = "yes";
            }
            */
            string text = rng.Next(100) > 50 ? "yes" : "no";

            Console.WriteLine(text);
            
            
            Console.ReadKey();
        }
    }
}
