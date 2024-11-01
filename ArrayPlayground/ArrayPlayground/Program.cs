using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

/*
 * Made by Jan Borecky for PRG seminar at Gymnazium Voderadska, year 2024-2025.
 * Extended by students.
 */

namespace ArrayPlayground
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //TODO 1: Vytvoř integerové pole a naplň ho pěti libovolnými čísly.
            int[] myArray = { 10, 20, 30, 40, 50 };

            //TODO 2: Vypiš do konzole všechny prvky pole, zkus jak klasický for, kde i využiješ jako index v poli, tak foreach.
            Console.WriteLine("vypisovani forem");
            for (int i = 0; i < myArray.Length; i++)
            {
                Console.WriteLine(myArray[i]);
            }
            Console.WriteLine("vypisovani foreachem");
            foreach(int number in myArray)
            {
                Console.WriteLine(number);
            }
            //TODO 3: Spočti sumu všech prvků v poli a vypiš ji uživateli.
            
            int sum = 0;
           /* 
            * for (int i = 0; i < myArray.Length; i++)
            {
                sum += myArray[i];
            }
            foreach (int number in myArray)
            {
                sum += number;
            }
           */
            sum = myArray.Sum();
            Console.WriteLine("suma: " + sum);



            //TODO 4: Spočti průměr prvků v poli a vypiš ho do konzole.
            int average = sum / myArray.Length;
            Console.WriteLine("average: " + average);
            

            //TODO 5: Najdi maximum v poli a vypiš ho do konzole.
            int max; 
            max = myArray.Max();
            Console.WriteLine("maximum: "+ max);

            //TODO 6: Najdi minimum v poli a vypiš ho do konzole.
            int min;
            min = myArray.Min();
            Console.WriteLine("minimun: "+ min);

            //TODO 7: Vyhledej v poli číslo, které zadá uživatel, a vypiš index nalezeného prvku do konzole.
            Console.WriteLine("napis cislo, ktere chces najit");          
            int numberToFind = int.Parse(Console.ReadLine());
            int foundIndex = -1;
            for (int i = 0; i < myArray.Length; i++)
            {
                if (myArray[i] == numberToFind)
                { 
                    foundIndex = i; 
                    break; 
                }
            }
            if (foundIndex == -1)
            {
                Console.WriteLine("cislo v poli neni");
            }
            else
            {
                Console.WriteLine("index cisla " + numberToFind + " je " + foundIndex);
            }

            //TODO 8: Přepiš pole na úplně nové tak, že bude obsahovat 100 náhodně vygenerovaných čísel od 0 do 9.
            Random rng = new Random();
            myArray = new int[100];
            for (int i = 0;i < myArray.Length;i++) 
            {
                myArray[i] = rng.Next(0, 10);
                Console.Write(myArray[i] + " ");
            }

            //TODO 9: Spočítej kolikrát se každé číslo v poli vyskytuje a spočítané četnosti vypiš do konzole.
            int[] counts = new int[10];
            foreach (int number in myArray) 
            {
                counts[number]++;
            }
            for (int i = 0; i < counts.Length; i++)
            {
                Console.WriteLine("cetnost cislice " + i + " je " + counts[i]);
            }

            //TODO 10: Vytvoř druhé pole, do kterého zkopíruješ prvky z prvního pole v opačném pořadí.
            int[] reverseArray = new int[100];
            for(int i = 0;i < reverseArray.Length ; i++) 
            {
                reverseArray[i] = myArray[myArray.Length - 1 - i];
                Console.Write(reverseArray[i]+ " ");
            }

            //Zkus is dál hrát s polem dle své libosti. Můžeš třeba prohodit dva prvky, ukládat do pole prvky nějaké posloupnosti (a pak si je vyhledávat) nebo cokoliv dalšího tě napadne

            Console.ReadKey();
        }
    }
}
